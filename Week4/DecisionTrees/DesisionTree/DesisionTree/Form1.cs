using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Globalization;
using System.Runtime.InteropServices;

namespace DesisionTree
{
    public partial class Form1 : Form
    {

        private DataTable dt;
        private Node decisionTrees;
        private int levels = 0;
        private float hs = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void bFlatBtnChooseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                this.Txt_File.Text = openFileDialog.FileName;
        }

        private void bFlatBtnLoadDataFromExcel_Click(object sender, EventArgs e)
        {
            // string PathConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Txt_File.Text + ";Extended properties=\"Excel 8.0;HDR=Yes;\";";
            richTextBox1.Clear();

            string PathConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Txt_File.Text + ";Extended properties=\"Excel 12.0 Xml;HDR=Yes;\";";
            OleDbConnection conn = new OleDbConnection(PathConn);
            OleDbDataAdapter myDataAdapter = new OleDbDataAdapter("Select *from [" + Txt_Sheet.Text + "$]", conn);
            dt = new DataTable();
            myDataAdapter.Fill(dt);
            Dgv_Excel.DataSource = dt;
            Dgv_Excel.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        private void bFlatBtnExecute_Click_1(object sender, EventArgs e)
        {
            List<Attribute> attributes = createAttribute();
            List<DecisionQuery> decision = createDecisionQuery();

            if (decision.Count == 0 || attributes.Count == 0)
            {
                MessageBox.Show("File imported is empty!");
                return;
            }
            DecisionQuery result = decision[decision.Count - 1];
            decision.Remove(result);


            int total = attributes.Count;
            List<float> calcultaHS = new List<float>();
            foreach (Answer question in result.possibleAnswers)
            {
                int count = 0;
                foreach (Attribute attribute in attributes)
                {
                    if (question.answer == attribute.answers[attribute.answers.Count - 1])
                        count++;
                }
                calcultaHS.Add(count);
            }
            hs = -calcultaHS[0] / total * (float)Math.Log(calcultaHS[0] / total) - calcultaHS[1] / total * (float)Math.Log(calcultaHS[1] / total);
            richTextBox1.Text += "HS: " + -calcultaHS[0] + "/" + total + "*log(" + calcultaHS[0] + "/" + total + ")" + -calcultaHS[1] + "/" + total + "*log(" + calcultaHS[1] + "/" + total + ")=";
            richTextBox1.Text += hs + "\n\n";



            decisionTrees = new Node(null, decision, attributes);

            levels = partition(decisionTrees, result, 1, String.Empty) + 1;
            graph_Panel.Refresh();

            return;
        }

        private List<DecisionQuery> createDecisionQuery()
        {
            int questions_count = dt.Columns.Count;
            List<DecisionQuery> decisionQueries = new List<DecisionQuery>();
            for (int i = 1; i < questions_count; i++)
            {
                string question = dt.Columns[i].ColumnName;
                List<Answer> possibleAnswers = new List<Answer>();
                foreach (DataRow r in dt.Rows)
                {
                    if (!possibleAnswers.Contains(possibleAnswers.Find(a => a.ANSWER == r[i].ToString())))
                    {
                        Answer answer = new Answer();
                        answer.answer = r[i].ToString();
                        answer.yes = 0;
                        answer.no = 0;
                        string x = r[questions_count - 1].ToString();
                        if (x == "yes" || x == "YES")
                            answer.yes++;
                        else if (x == "NO" || x == "no")
                            answer.no++;
                        possibleAnswers.Add(answer);
                    }
                    else
                    {
                        Answer answer = possibleAnswers.Find(ans => ans.answer == r[i].ToString());
                        if (r[questions_count - 1].ToString() == "yes" || r[questions_count - 1].ToString() == "YES")
                            answer.yes++;
                        else if (r[questions_count - 1].ToString() == "no" || r[questions_count - 1].ToString() == "NO")
                            answer.no++;
                    }
                }
                decisionQueries.Add(new DecisionQuery(question, possibleAnswers));
            }
            return decisionQueries;
        }

        private List<Attribute> createAttribute()
        {
            List<Attribute> attributes = new List<Attribute>();
            foreach (DataRow r in dt.Rows)
            {
                List<string> answers = new List<string>();

                for (int i = 1; i < r.ItemArray.Length; i++)
                {
                    answers.Add(r.ItemArray[i].ToString());
                }
                attributes.Add(new Attribute(answers, r.ItemArray[0].ToString()));
            }
            return attributes;
        }

        private int getBestFeature(List<List<List<float>>> featureVectors)
        {
            List<int> unitVectorCount = new List<int>();
            foreach (List<List<float>> featureVector in featureVectors)
            {
                int count = 0;
                foreach (List<float> vector in featureVector)
                {
                    if (vector.Max() == 1) count++;
                }
                unitVectorCount.Add(count);
                //richTextBox1.Text += featureVector;
            }

            return unitVectorCount.IndexOf(unitVectorCount.Max());
        }

        private int getBestFeature(List<float> hsList)
        {
            return hsList.IndexOf(hsList.Min());
        }

        private List<List<List<float>>> computeFeatureVectors(List<DecisionQuery> decisionQueries, List<Attribute> attributes, DecisionQuery result, ref List<List<List<KeyValuePair<float, float>>>> featurePairsVectors)
        {
            List<List<List<float>>> featureVectors = new List<List<List<float>>>();
            for (int c = 0; c < decisionQueries.Count; c++)
            {
                List<List<float>> featureVector = new List<List<float>>();
                List<List<KeyValuePair<float, float>>> lKeyValuePairs = new List<List<KeyValuePair<float, float>>>();
                for (int i = 0; i < decisionQueries[c].possibleAnswers.Count; i++)
                {
                    List<float> vector = new List<float>();
                    List<KeyValuePair<float, float>> keyValue = new List<KeyValuePair<float, float>>();

                    for (int j = 0; j < result.possibleAnswers.Count; j++)
                    {
                        int count = 0;
                        int total = 0;
                        foreach (Attribute attribute in attributes)
                        {
                            if (attribute.answers[c] == decisionQueries[c].possibleAnswers[i].ANSWER)
                            {
                                total++;
                                if (attribute.answers[attribute.answers.Count - 1] == result.possibleAnswers[j].answer)
                                {
                                    count++;
                                }
                            }

                        }
                        vector.Add((float)count / total);
                        keyValue.Add(new KeyValuePair<float, float>(count, total));
                    }
                    lKeyValuePairs.Add(keyValue);
                    featureVector.Add(vector);
                    //richTextBox1.Text += "H(S" + decisionQueries[c].possibleAnswers[i].answer +featureVector[i]..ToString()+ ")="+"\n";
                }
                featureVectors.Add(featureVector);
                featurePairsVectors.Add(lKeyValuePairs);
            }

            return featureVectors;
        }

        private int partition(Node parent, DecisionQuery result, int level, string possibleAnswerBranch)
        {
            if (parent.attributes.Count == 0 || parent.questions.Count == 0 || checkPartition(parent.attributes))
            {
                return level;

            }
            List<List<List<KeyValuePair<float, float>>>> featurePairsVectors = new List<List<List<KeyValuePair<float, float>>>>();
            List<List<List<float>>> featureVectors = computeFeatureVectors(parent.questions, parent.attributes, result, ref featurePairsVectors);
            List<float> hsList = new List<float>();
            for (int i = 0; i < featureVectors.Count; i++)
            {

                List<List<KeyValuePair<float, float>>> hs_question = new List<List<KeyValuePair<float, float>>>();
                List<KeyValuePair<float, float>> hs_question1 = new List<KeyValuePair<float, float>>();
                for (int j = 0; j < featureVectors[i].Count; j++)
                {
                    
                    richTextBox1.Text += "H(S" + possibleAnswerBranch + "_"  + parent.questions[i].possibleAnswers[j].answer + "):";
                    float hs = 0;
                    for (int k = 0; k < featureVectors[i][j].Count; k++)
                    {

                        float hs1 = -featurePairsVectors[i][j][k].Key / featurePairsVectors[i][j][k].Value * (float)Math.Log(featurePairsVectors[i][j][k].Key / featurePairsVectors[i][j][k].Value);
                        richTextBox1.Text += -featurePairsVectors[i][j][k].Key + "/" + featurePairsVectors[i][j][k].Value;
                        richTextBox1.Text += "*log(" + featurePairsVectors[i][j][k].Key + "/" + featurePairsVectors[i][j][k].Value + ")";
                        if (featurePairsVectors[i][j][k].Key == 0)
                            hs1 = 0;
                        hs += hs1;
                    }
                    hs_question1.Add(new KeyValuePair<float, float>(hs, featurePairsVectors[i][j][0].Value));
                    richTextBox1.Text += "=" + hs + "\n";
                }
                float hs2 = 0;
                float total = 0;
                richTextBox1.Text += "H(S" + parent.questions[i].question + "):";

       
                for (int t = 0; t < hs_question1.Count;  t++)
                {
                    total += hs_question1[t].Value;
                }
                for (int t = 0; t < hs_question1.Count; t++)
                {
                    hs2 += hs_question1[t].Key * hs_question1[t].Value / total;
                    richTextBox1.Text += hs_question1[t].Value + "/" + total + "*" + hs_question1[t].Key;
                    if (t != hs_question1.Count - 1)
                        richTextBox1.Text += "+";
                }
                richTextBox1.Text += "=" + hs2 + "\n\n";
                hsList.Add(hs2);
            }

            //int bestFeature = getBestFeature(featureVectors);
            int bestFeature = getBestFeature(hsList);

            richTextBox1.Text += "  Ta chọn đặc tính tốt nhất: "+ parent.questions[bestFeature].question.ToString()+"\n";
            parent.partition_question = parent.questions[bestFeature];
            List<DecisionQuery> brandClauses = new List<DecisionQuery>();
            for (int i = 0; i < parent.questions.Count; i++)
            {

                if (i != bestFeature)
                {
                    brandClauses.Add(parent.questions[i]);
                }
            }
            List<List<Attribute>> brandsAttributes = new List<List<Attribute>>();

            for (int i = 0; i < parent.questions[bestFeature].possibleAnswers.Count; i++)
            {
                List<Attribute> brandAttribute = new List<Attribute>();
                foreach (Attribute attribute in parent.attributes)
                {
                    if (attribute.answers[bestFeature] == parent.questions[bestFeature].possibleAnswers[i].answer)
                    {
                        Attribute temp = attribute.copy();
                        temp.answers.RemoveAt(bestFeature);
                        brandAttribute.Add(temp);

                    }

                }
                brandsAttributes.Add(brandAttribute);
            }
            parent.branch = new List<Node>();
            int maxlv = level;
            for (int i = 0; i < parent.questions[bestFeature].possibleAnswers.Count; i++)
            {
                // richTextBox1.Text += "-----Xét " + parent.questions[bestFeature].possibleAnswers.ToString() + "------";
                Node brand = new Node(null, brandClauses, brandsAttributes[i]);
                if (featureVectors[bestFeature][i].Max() != 1)
                {
                    int lv = partition(brand, result, level + 1, parent.questions[bestFeature].possibleAnswers[i].answer);
                    if (lv > maxlv) maxlv = lv;
                }
                parent.branch.Add(brand);
            }
            return maxlv;
        }

        private bool checkPartition(List<Attribute> attributes)
        {
            string first = attributes[0].answers[attributes[0].answers.Count - 1];
            foreach (Attribute attribute in attributes)
            {
                if (attribute.answers[attribute.answers.Count - 1] != first)
                {
                    return false;
                }
            }
            return true;
        }



        private void graph_Panel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            drawGraph(e.Graphics);
        }

        private void drawGraph(Graphics g)
        {
            if (decisionTrees == null) return;
            int levelHeight = graph_Panel.Height / (levels + 1);
            drawNode(g, decisionTrees, 1, levelHeight, 0, graph_Panel.Width);
        }

        private Point drawNode(Graphics g, Node node, int level, int levelHeight, int begin, int end)
        {
            int area = (end - begin) / 3;
            int pos_x = begin + area;
            int pos_y = levelHeight * level;
            Font font = new Font("Arial", 12);
            if (node.partition_question != null)
            {

                SizeF question_size = g.MeasureString(node.partition_question.question, font);
                pos_x = (int)(pos_x + (area - (question_size.Width - question_size.Height)) / 2);
                g.DrawRectangle(new Pen(Color.Black), pos_x, pos_y, question_size.Width, question_size.Height);
                g.DrawString(node.partition_question.question, font, new SolidBrush(Color.Red), pos_x, pos_y);

            }
            else
            {
                string attributeNames = "";
                foreach (Attribute attribute in node.attributes)
                {
                    attributeNames += attribute.title + "(" + attribute.answers[attribute.answers.Count - 1] + ")" + "\n";
                }
                g.DrawString(attributeNames, font, new SolidBrush(Color.Black), pos_x, pos_y);


            }
            if (node.branch != null)
            {
                List<Node> drawBranch = new List<Node>();
                foreach (Node brand in node.branch)
                {
                    if (brand.attributes.Count > 0)
                    {
                        drawBranch.Add(brand);
                    }
                }
                int branArea = (end - begin) / drawBranch.Count;
                for (int i = 0; i < drawBranch.Count; i++)
                {
                    Point des = drawNode(g, drawBranch[i], level + 1, levelHeight, begin + branArea * i, begin + branArea * (i + 1));
                    g.DrawLine(new Pen(Color.Green), pos_x + 30, pos_y + 20, des.X, des.Y);
                    g.DrawString(node.partition_question.possibleAnswers[i].answer, font, new SolidBrush(Color.Black), (pos_x + des.X) / 2, (pos_y + des.Y) / 2);
                }
            }
            return new Point(pos_x, pos_y);
        }

        private void result_Algrithm(List<Attribute> attributes, DecisionQuery result, List<DecisionQuery> decisions)
        {

            float total = attributes.Count;
            List<float> ratioHS = new List<float>();
            for (int j = 0; j < result.possibleAnswers.Count; j++)
            {
                float count = 0;
                for (int i = 0; i < attributes.Count; i++)
                {
                    {
                        if (result.possibleAnswers[j].answer == attributes[i].answers[attributes[i].answers.Count - 1])
                        {
                            count++;
                        }
                    }
                }
                ratioHS.Add(count);
            }
            float HS = -ratioHS[0] / total * (float)Math.Log(ratioHS[0] / total) - ratioHS[1] / total * (float)Math.Log(ratioHS[1] / total);
            richTextBox1.Text += "Entropy tại root node  của bài toán là:\n";
            richTextBox1.Text += "=> H(S)=" + -ratioHS[0] + "/" + total + ".log(" + ratioHS[0] + "/" + total + ")"
            + -ratioHS[1] + "/" + total + ".log(" + ratioHS[1] + "/" + total + ")=";
            richTextBox1.Text += HS + "\n";




            float Hmin = 0;
            List<float> H = new List<float>();
            int temp = 0;
            for (int i = 0; i < decisions.Count; i++)
            {
                richTextBox1.Text += "Xét " + decisions[i].question.ToString() + "\n";
                float Hsum = 0;
                for (int j = 0; j < decisions[i].possibleAnswers.Count; j++)
                {
                    float yes = decisions[i].possibleAnswers[j].yes;
                    float no = decisions[i].possibleAnswers[j].no;
                    float total1 = yes + no;
                    float HS1 = -yes / total1 * (float)Math.Log(yes / total1) - no / total1 * (float)Math.Log(no / total1);
                    if (yes == 0 || no == 0)
                        HS1 = 0;
                    richTextBox1.Text += "=> H(S" + decisions[i].possibleAnswers[j].answer + ")=" + -yes + "/" + total1 + ".log(" + yes + "/" + total1 + ")"
                + -no + "/" + total1 + ".log(" + no + "/" + total1 + ")=";
                    richTextBox1.Text += HS1 + "\n";
                    Hsum += HS1 * total1 / total;

                }
                H.Add(Hsum);

                richTextBox1.Text += "==>H(" + decisions[i].question + ",S)=" + Hsum + "\n";
            }


            Hmin = H[0];
            for (int k = 1; k < H.Count; k++)
            {
                if (H[k] < Hmin)
                {
                    Hmin = H[k];
                    temp = k;
                }
            }
            for (int i = 0; i < decisions.Count; i++)
            {
                if (i == temp)
                {
                    richTextBox1.Text += "H(" + decisions[i].question + ",S) nhỏ nhất nên Gain lớn nhất." +
                        "==> Chọn " + decisions[i].question + " làm node gốc \n";
                }

            }


            for (int i = 0; i < decisions[temp].possibleAnswers.Count; i++)
            {

            }
        }

    }
}
