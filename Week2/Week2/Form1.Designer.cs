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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtthuonggianumber = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtonlinenumber = new System.Windows.Forms.Label();
            this.txtthuongnumber = new System.Windows.Forms.Label();
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
            // 
            // gateB
            // 
            this.gateB.AutoSize = true;
            this.gateB.Location = new System.Drawing.Point(731, 154);
            this.gateB.Name = "gateB";
            this.gateB.Size = new System.Drawing.Size(20, 20);
            this.gateB.TabIndex = 1;
            this.gateB.Text = "B";
            // 
            // gateC
            // 
            this.gateC.AutoSize = true;
            this.gateC.Location = new System.Drawing.Point(731, 270);
            this.gateC.Name = "gateC";
            this.gateC.Size = new System.Drawing.Size(20, 20);
            this.gateC.TabIndex = 2;
            this.gateC.Text = "C";
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
            this.timer3.Interval = 10;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // timer4
            // 
            this.timer4.Interval = 1000;
            this.timer4.Tick += new System.EventHandler(this.timer4_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 371);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "thuonggia";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(351, 371);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "online";
            // 
            // txtthuonggianumber
            // 
            this.txtthuonggianumber.AutoSize = true;
            this.txtthuonggianumber.Location = new System.Drawing.Point(161, 371);
            this.txtthuonggianumber.Name = "txtthuonggianumber";
            this.txtthuonggianumber.Size = new System.Drawing.Size(0, 20);
            this.txtthuonggianumber.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(580, 371);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "thuong";
            // 
            // txtonlinenumber
            // 
            this.txtonlinenumber.AutoSize = true;
            this.txtonlinenumber.Location = new System.Drawing.Point(437, 371);
            this.txtonlinenumber.Name = "txtonlinenumber";
            this.txtonlinenumber.Size = new System.Drawing.Size(0, 20);
            this.txtonlinenumber.TabIndex = 7;
            // 
            // txtthuongnumber
            // 
            this.txtthuongnumber.AutoSize = true;
            this.txtthuongnumber.Location = new System.Drawing.Point(692, 371);
            this.txtthuongnumber.Name = "txtthuongnumber";
            this.txtthuongnumber.Size = new System.Drawing.Size(0, 20);
            this.txtthuongnumber.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtthuongnumber);
            this.Controls.Add(this.txtonlinenumber);
            this.Controls.Add(this.txtthuonggianumber);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label txtthuonggianumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label txtonlinenumber;
        private System.Windows.Forms.Label txtthuongnumber;
    }
}

