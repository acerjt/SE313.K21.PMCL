namespace Week2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gateA = new System.Windows.Forms.Label();
            this.gateB = new System.Windows.Forms.Label();
            this.gateC = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.timer4 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // gateA
            // 
            this.gateA.AutoSize = true;
            this.gateA.Location = new System.Drawing.Point(731, 38);
            this.gateA.Name = "gateA";
            this.gateA.Size = new System.Drawing.Size(20, 20);
            this.gateA.TabIndex = 0;
            this.gateA.Text = "A";
            this.gateA.Click += new System.EventHandler(this.label1_Click);
            // 
            // gateB
            // 
            this.gateB.AutoSize = true;
            this.gateB.Location = new System.Drawing.Point(731, 154);
            this.gateB.Name = "gateB";
            this.gateB.Size = new System.Drawing.Size(20, 20);
            this.gateB.TabIndex = 1;
            this.gateB.Text = "B";
            this.gateB.Click += new System.EventHandler(this.label2_Click);
            // 
            // gateC
            // 
            this.gateC.AutoSize = true;
            this.gateC.Location = new System.Drawing.Point(731, 270);
            this.gateC.Name = "gateC";
            this.gateC.Size = new System.Drawing.Size(20, 20);
            this.gateC.TabIndex = 2;
            this.gateC.Text = "C";
            this.gateC.Click += new System.EventHandler(this.label3_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // timer4
            // 
            this.timer4.Interval = 1000;
            this.timer4.Tick += new System.EventHandler(this.timer4_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gateC);
            this.Controls.Add(this.gateB);
            this.Controls.Add(this.gateA);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label gateA;
        private System.Windows.Forms.Label gateB;
        private System.Windows.Forms.Label gateC;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Timer timer4;
    }
}

