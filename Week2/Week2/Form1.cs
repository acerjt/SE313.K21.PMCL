using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Pipes;
using Week2.Properties;
using System.Reflection;

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


        private List<Image> simonImage = new List<Image>();
        private int simonImageMaxIndex = 4;

        private List<Image> ninjaImage = new List<Image>();
        private int ninjaImageMaxIndex = 3;

        private List<Image> hawImage = new List<Image>();
        private int hawImageMaxIndex = 4;


        private int n = 10;
        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            LoadResources();
            timer1.Interval = 100;
            timer2.Interval = 100;
            timer3.Interval = 100;
            timer4.Interval = 100;
        }


        private void LoadResources()
        {
            string path = System.Environment.CurrentDirectory;
            path  = Directory.GetParent(path).Parent.FullName;
            for (int i = 0; i < simonImageMaxIndex; i++)
            {
                Bitmap image = (Bitmap)Bitmap.FromFile(path+ @"\Resources\simon_" + i.ToString() + ".png");
                image.RotateFlip(RotateFlipType.RotateNoneFlipX);
               
                simonImage.Add(image);
            }
            for (int i = 0; i < ninjaImageMaxIndex; i++)
            {
                
                Bitmap image = (Bitmap)Bitmap.FromFile(path + @"\Resources\ninja_" + i.ToString() + ".png");
                //image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                ninjaImage.Add(image);
            }
            for (int i = 0; i < hawImageMaxIndex; i++)
            {
                Bitmap image = (Bitmap)Bitmap.FromFile(path + @"\Resources\haw_" + i.ToString() + ".png");
                image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                hawImage.Add(image);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            timer3.Start();
            timer1.Start();
            timer2.Start();
            timer4.Start();
            keyValuePairs.Enqueue(new HanhKhach(1, 1, 2));/*,30,50));*/
            keyValuePairs.Enqueue(new HanhKhach(2, 3, 7));/*,80,100));*/
            keyValuePairs.Enqueue(new HanhKhach(3, 3, 6));/*,70,100));*/
            keyValuePairs.Enqueue(new HanhKhach(5, 3, 13));/*,60,100));*/
            keyValuePairs.Enqueue(new HanhKhach(7, 3, 7));/*,50,100));*/
            keyValuePairs.Enqueue(new HanhKhach(9, 3, 7));/*,40,100));*/
            keyValuePairs.Enqueue(new HanhKhach(15, 3, 7));/*,40,100));*/
            keyValuePairs.Enqueue(new HanhKhach(14, 3, 7));/*,40,100));*/
            keyValuePairs.Enqueue(new HanhKhach(10, 3, 7));/*,30,100));*/
            keyValuePairs.Enqueue(new HanhKhach(11, 3, 7));/*,30,100));*/
            keyValuePairs.Enqueue(new HanhKhach(8, 2, 2));/*,50,70));*/
            keyValuePairs.Enqueue(new HanhKhach(12, 3, 7));/*,30,100));*/
            keyValuePairs.Enqueue(new HanhKhach(4, 2, 3));/*,30,70));*/
            keyValuePairs.Enqueue(new HanhKhach(13, 3, 7));/*,30,100));*/
            keyValuePairs.Enqueue(new HanhKhach(6, 2, 4));/*,40,70));*/
            //keyValuePairs.Enqueue(new HanhKhach(100, 3, 7));/*,30,50));*/
            //keyValuePairs.Enqueue(new HanhKhach(1000, 3, 4));/*,30,50));*/
            //keyValuePairs.Enqueue(new HanhKhach(121, 3, 5));/*,30,50));*/
            //keyValuePairs.Enqueue(new HanhKhach(1123, 3, 2));/*,30,50));*/
            //keyValuePairs.Enqueue(new HanhKhach(11234, 3, 7));/*,30,50));*/
            //keyValuePairs.Enqueue(new HanhKhach(11233, 3, 6));/*,30,50));*/
            //keyValuePairs.Enqueue(new HanhKhach(11235, 3, 2));/*,30,50));*/
            //keyValuePairs.Enqueue(new HanhKhach(11236, 3, 5));/*,30,50));*/
            //keyValuePairs.Enqueue(new HanhKhach(11237, 3, 7));/*,30,50));*/
            //keyValuePairs.Enqueue(new HanhKhach(112373, 3, 6));/*,30,50));*/
            //keyValuePairs.Enqueue(new HanhKhach(11233, 3, 6));/*,30,50));*/


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (keyValuePairs.Count != 0)
            {
                test = keyValuePairs.Dequeue();



                if (test.QUEUETYPE == 1)
                {
                    test.LABEL.Location = new System.Drawing.Point(gateA.Location.X - 200, gateA.Location.Y);
                    test.LABEL.Text = test.DURATION.ToString();
                    test.LABEL.AutoSize = true;
                    test.ANIMATION = simonImage;
                    test.POSX = gateA.Location.X - 200;
                    test.POSY = gateA.Location.Y;
                    this.Controls.Add(test.LABEL);
                    thuonggia.Enqueue(test);
                }
                else if (test.QUEUETYPE == 2)
                {

                    test.LABEL.Location = new System.Drawing.Point(gateB.Location.X - 200, gateB.Location.Y);
                    test.LABEL.Text = test.DURATION.ToString();
                    test.LABEL.AutoSize = true;
                    test.ANIMATION = ninjaImage;
                    test.POSX = gateB.Location.X - 200;
                    test.POSY = gateB.Location.Y;
                    this.Controls.Add(test.LABEL);
                    online.Enqueue(test);
                }
                else if (test.QUEUETYPE == 3)
                {
                    test.LABEL.Location = new System.Drawing.Point(gateC.Location.X - 200, gateC.Location.Y);
                    test.LABEL.Text = test.DURATION.ToString();
                    test.LABEL.AutoSize = true;
                    test.ANIMATION = hawImage;
                    test.POSX = gateC.Location.X - 200;
                    test.POSY = gateC.Location.Y;
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

                    if (x.QUEUETYPE == 1)
                    {
                        if (thuonggia.Count != 0 && thuonggiainprocess.Count == 0)
                        {
                            HanhKhach a = thuonggia.Dequeue();
                            thuonggiainprocess.Enqueue(a);
                           
                        }
                        if(thuonggiainprocess.Count != 0 )
                        {
                            if (x.ID == thuonggiainprocess.Peek().ID)
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

                            if (thuonggia.Count != 0 && thuonggiainprocess.Count != 0 && onlineinprocess.Count == 0 && online.Count == 0)
                            {
                                HanhKhach c = thuonggia.Dequeue();
                                c.QUEUETYPE = 2;
                                c.LABEL.Location = new Point(c.LABEL.Location.X, gateB.Location.Y);
                                c.POSY = gateB.Location.Y;
                                online.Enqueue(c);

                            }
                            if (thuonggia.Count != 0 && thuonggiainprocess.Count != 0 && thuonginprocess.Count == 0 && thuong.Count == 0)
                            {
                                HanhKhach b = thuonggia.Dequeue();
                                b.QUEUETYPE = 3;
                                b.LABEL.Location = new Point(b.LABEL.Location.X, gateC.Location.Y);
                                b.POSY = gateC.Location.Y;
                                thuong.Enqueue(b);
                            }
                        }
                    }
                    else if (x.QUEUETYPE == 2)
                    {
                        if (online.Count != 0 && onlineinprocess.Count == 0)
                        {
                            HanhKhach a = online.Dequeue();
                            onlineinprocess.Enqueue(a);
                            
                        }
                        if(onlineinprocess.Count != 0 )
                        {
                            if (x.ID == onlineinprocess.Peek().ID)
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

                            if (online.Count != 0 && onlineinprocess.Count != 0 && thuonggiainprocess.Count == 0 && thuonggia.Count == 0)
                            {
                                HanhKhach c = online.Dequeue();
                                c.QUEUETYPE = 1;
                                c.LABEL.Location = new Point(c.LABEL.Location.X, gateA.Location.Y);
                                c.POSY = gateA.Location.Y;
                                thuonggia.Enqueue(c);

                            }
                            if (online.Count != 0 && onlineinprocess.Count != 0 && thuonginprocess.Count == 0 && thuong.Count == 0)
                            {
                                HanhKhach b = online.Dequeue();
                                b.QUEUETYPE = 3;
                                b.LABEL.Location = new Point(b.LABEL.Location.X, gateC.Location.Y);
                                b.POSY = gateC.Location.Y;
                                thuong.Enqueue(b);
                            }

                        }
                        
                    }
                    else if (x.QUEUETYPE == 3)
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
                            if (thuong.Count != 0 && thuonginprocess.Count != 0 && thuonggiainprocess.Count == 0 && thuonggia.Count == 0)
                            {
                                HanhKhach c = thuong.Dequeue();
                                c.QUEUETYPE = 1;
                                c.LABEL.Location = new Point(c.LABEL.Location.X, gateA.Location.Y);
                                c.POSY = gateA.Location.Y;
                                thuonggia.Enqueue(c);
                               
                            }
                            if (thuong.Count != 0 && thuonginprocess.Count != 0 && onlineinprocess.Count == 0 && online.Count == 0)
                            {
                                HanhKhach b = thuong.Dequeue();
                                b.QUEUETYPE = 2;
                                b.LABEL.Location = new Point(b.LABEL.Location.X, gateB.Location.Y);
                                b.POSY = gateB.Location.Y;
                                online.Enqueue(b);
                            }
                        }
                    }
                }
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            //if (keyValuePairs.Count == 0)
            //{
                for (int i = 0; i < s.Count; i++)
                {
                    //if (i != 0 && s[i].LABEL.Bounds.IntersectsWith(s[i-1].LABEL.Bounds))
                    //    s[i -1].LABEL.Location = new Point(s[i].LABEL.Location.X - 20, s[i].LABEL.Location.Y);
                    for (int j = 0; j < s.Count; j++)
                    {
                    if (s[i] == s[j])
                        continue;
                    if (s[i].LABEL.Bounds.IntersectsWith(s[j].LABEL.Bounds))
                    {
                        s[j].LABEL.Location = new Point(s[i].LABEL.Location.X - 20, s[i].LABEL.Location.Y);
                        s[j].POSX = s[i].POSX - 20;
                    }

                    //Rectangle sourceRect = new Rectangle(s[i].POSX, s[i].POSY, s[i].LABEL.Width, s[i].ANIMATION[0].Height);
                    //Rectangle dectRect = new Rectangle(s[j].POSX, s[j].POSY, s[j].LABEL.Width, s[j].ANIMATION[0].Height);

                    //if (sourceRect.IntersectsWith(dectRect))
                    //    s[j].POSX = s[i].POSX - 5;

                }

            }
            //}
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach( HanhKhach x in s) {
                if(x.ANIMATION != null)
                    e.Graphics.DrawImage(x.ANIMATION[x.CURRENTFRAME], new Point(x.POSX, x.POSY));
            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            foreach(HanhKhach x in s)
            {
                if (x.TYPE == 1)
                {
                    if (x.CURRENTFRAME >= simonImageMaxIndex - 1)
                        x.CURRENTFRAME = 0;
                    else
                        x.CURRENTFRAME++;
                    x.POSX+= 20;
                    if (x.POSX >= gateA.Location.X - 20)
                    {
                        x.POSX = gateA.Location.X - 20;
                    }
                }
                else if (x.TYPE == 2)
                {
                    if (x.CURRENTFRAME >= ninjaImageMaxIndex - 1)
                        x.CURRENTFRAME = 0;
                    else
                        x.CURRENTFRAME++;
                    x.POSX += 20;
                    if (x.POSX >= gateA.Location.X - 20)
                    {
                        x.POSX = gateA.Location.X - 20;
                    }
                }
                else if (x.TYPE == 3)
                {
                    if (x.CURRENTFRAME >= hawImageMaxIndex - 1)
                        x.CURRENTFRAME = 0;
                    else
                        x.CURRENTFRAME++;
                    x.POSX += 20;
                    if (x.POSX >= gateA.Location.X - 20)
                    {
                        x.POSX = gateA.Location.X - 20;
                    }
                }

                this.Invalidate();
            }
        }
    }
}
    