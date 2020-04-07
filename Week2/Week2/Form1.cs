using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Week2
{
    public partial class Form1 : Form
    {
        private Queue<HanhKhach> keyValuePairs = new Queue<HanhKhach>();
        private HanhKhach test;
        private List<HanhKhach> s = new List<HanhKhach>(10);

        private Queue<HanhKhach> thuonggia = new Queue<HanhKhach>();
        private Queue<HanhKhach> online = new Queue<HanhKhach>();
        private Queue<HanhKhach> thuong = new Queue<HanhKhach>();

        private Queue<HanhKhach> thuonggiainprocess = new Queue<HanhKhach>();
        private Queue<HanhKhach> onlineinprocess = new Queue<HanhKhach>();
        private Queue<HanhKhach> thuonginprocess = new Queue<HanhKhach>();

        private int counter = 0;

        private int n = 10;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer2.Start();
            timer3.Start();

            keyValuePairs.Enqueue(new HanhKhach(1, 1, 2));/*,30,50));*/
            keyValuePairs.Enqueue(new HanhKhach(2, 3, 7));/*,80,100));*/
            keyValuePairs.Enqueue(new HanhKhach(3, 3, 6));/*,70,100));*/
            keyValuePairs.Enqueue(new HanhKhach(8, 2, 2));/*,50,70));*/
            keyValuePairs.Enqueue(new HanhKhach(6, 2, 4));/*,40,70));*/
            keyValuePairs.Enqueue(new HanhKhach(4, 2, 3));/*,30,70));*/
            keyValuePairs.Enqueue(new HanhKhach(5, 3, 7));/*,60,100));*/
            keyValuePairs.Enqueue(new HanhKhach(7, 3, 7));/*,50,100));*/
            keyValuePairs.Enqueue(new HanhKhach(9, 3, 7));/*,40,100));*/
            keyValuePairs.Enqueue(new HanhKhach(10, 3, 7));/*,30,100));*/


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (keyValuePairs.Count != 0)
            {
                test = keyValuePairs.Dequeue();



                if (test.TYPE == 1)
                {
                    test.LABEL.Location = new System.Drawing.Point(gateA.Location.X - 200, gateA.Location.Y);
                    test.LABEL.Text = test.DURATION.ToString();
                    test.LABEL.AutoSize = true;
                    this.Controls.Add(test.LABEL);
                    thuonggia.Enqueue(test);
                }
                else if (test.TYPE == 2)
                {

                    test.LABEL.Location = new System.Drawing.Point(gateB.Location.X - 200, gateB.Location.Y);
                    test.LABEL.Text = test.DURATION.ToString();
                    test.LABEL.AutoSize = true;
                    this.Controls.Add(test.LABEL);
                    online.Enqueue(test);
                }
                else if (test.TYPE == 3)
                {
                    test.LABEL.Location = new System.Drawing.Point(gateC.Location.X - 200, gateC.Location.Y);
                    test.LABEL.Text = test.DURATION.ToString();
                    test.LABEL.AutoSize = true;
                    this.Controls.Add(test.LABEL);
                    thuong.Enqueue(test);
                }

                s.Add(test);
            }
            //label.Location = new System.Drawing.Point(label.Location.X + 20, label.Location.Y);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //counter++;
            foreach (HanhKhach x in s.ToList<HanhKhach>())
            {
                x.LABEL.Location = new Point(x.LABEL.Location.X + 20, x.LABEL.Location.Y);
                if (x.LABEL.Location.X >= gateA.Location.X - 20)
                //if (counter >= 10)
                {
                    x.LABEL.Location = new Point(gateA.Location.X - 20, x.LABEL.Location.Y);

                    if (x.TYPE == 1)
                    {
                        if (thuonggia.Count != 0 && thuonggiainprocess.Count == 0)
                        {
                            HanhKhach a = thuonggia.Dequeue();
                            thuonggiainprocess.Enqueue(a);
                           
                        }
                        if(thuonggiainprocess.Count != 0 && x.ID == thuonggiainprocess.Peek().ID)
                        {
                            x.DURATION -= 1;
                            x.LABEL.Text = x.DURATION.ToString();

                            if (x.DURATION == 0)
                            {
                                //x.LABEL.Visible = false;
                                this.Controls.Remove(x.LABEL);
                                s.Remove(x);
                                n--;
                                thuonggiainprocess.Dequeue();
                                if (thuonggia.Count != 0 && thuonggiainprocess.Count == 0)
                                {
                                    HanhKhach a = thuonggia.Dequeue();
                                    thuonggiainprocess.Enqueue(a);

                                }
                            }
                        }
                    }
                    else if (x.TYPE == 2)
                    {
                        if (online.Count != 0 && onlineinprocess.Count == 0)
                        {
                            HanhKhach a = online.Dequeue();
                            onlineinprocess.Enqueue(a);
                            
                        }
                        if(onlineinprocess.Count != 0 && x.ID == onlineinprocess.Peek().ID)
                        {
                            x.DURATION -= 1;
                            x.LABEL.Text = x.DURATION.ToString();

                            if (x.DURATION == 0)
                            {
                                //x.LABEL.Visible = false;

                                this.Controls.Remove(x.LABEL);
                                s.Remove(x);
                                n--;
                                onlineinprocess.Dequeue();
                                if (online.Count != 0 && onlineinprocess.Count == 0)
                                {
                                    HanhKhach a = online.Dequeue();
                                    onlineinprocess.Enqueue(a);

                                }
                            }

                           
                        }
                        
                    }
                    else if (x.TYPE == 3)
                    {
                        if (thuong.Count != 0 && thuonginprocess.Count == 0)
                        {
                            HanhKhach a = thuong.Dequeue();
                            thuonginprocess.Enqueue(a);

                        }
                        if (thuonginprocess.Count != 0)
                        {


                            if (x.ID == thuonginprocess.Peek().ID)
                            {
                                x.DURATION -= 1;
                                x.LABEL.Text = x.DURATION.ToString();

                                if (x.DURATION == 0)
                                {
                                    //x.LABEL.Visible = false;

                                    this.Controls.Remove(x.LABEL);
                                    
                                    thuonginprocess.Dequeue();
                                    s.Remove(x);
                                    n--;
                                    if (thuong.Count != 0 && thuonginprocess.Count == 0)
                                    {
                                        HanhKhach a = thuong.Dequeue();
                                        thuonginprocess.Enqueue(a);

                                    }
                                }
                            }
                            if (thuong.Count != 0 && thuonginprocess.Count != 0 && thuonggiainprocess.Count == 0 && thuonggia.Count == 0 && keyValuePairs.Count == 0)
                            {
                                HanhKhach c = thuong.Dequeue();
                                c.TYPE = 1;
                                c.LABEL.Location = new Point(c.LABEL.Location.X, gateA.Location.Y);
                                thuonggia.Enqueue(c);
                               
                            }
                            if (thuong.Count != 0 && thuonginprocess.Count != 0 && onlineinprocess.Count == 0 && online.Count == 0 && keyValuePairs.Count == 0)
                            {
                                HanhKhach b = thuong.Dequeue();
                                b.TYPE = 2;
                                b.LABEL.Location = new Point(b.LABEL.Location.X, gateB.Location.Y);
                                online.Enqueue(b);
                            }
                        }
                    }
                }
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (keyValuePairs.Count == 0)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = i + 1; j < n; j++)
                        if (s[i].LABEL.Bounds.IntersectsWith(s[j].LABEL.Bounds))
                            s[j].LABEL.Location = new Point(s[i].LABEL.Location.X - 20, s[i].LABEL.Location.Y);
                }
            }
        }
    }
}
    