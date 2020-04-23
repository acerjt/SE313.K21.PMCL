namespace AStarSearch
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
            this.rdBtnWall = new System.Windows.Forms.RadioButton();
            this.rdBtnAstar = new System.Windows.Forms.RadioButton();
            this.rdbtnStep = new System.Windows.Forms.RadioButton();
            this.rdBtnStart = new System.Windows.Forms.RadioButton();
            this.rdBtnDest = new System.Windows.Forms.RadioButton();
            this.rdBtnOnlyResult = new System.Windows.Forms.RadioButton();
            this.rdBtnBFS = new System.Windows.Forms.RadioButton();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdBtnWall
            // 
            this.rdBtnWall.AutoSize = true;
            this.rdBtnWall.Location = new System.Drawing.Point(23, 37);
            this.rdBtnWall.Name = "rdBtnWall";
            this.rdBtnWall.Size = new System.Drawing.Size(64, 24);
            this.rdBtnWall.TabIndex = 0;
            this.rdBtnWall.TabStop = true;
            this.rdBtnWall.Text = "Wall";
            this.rdBtnWall.UseVisualStyleBackColor = true;
            // 
            // rdBtnAstar
            // 
            this.rdBtnAstar.AutoSize = true;
            this.rdBtnAstar.Location = new System.Drawing.Point(21, 80);
            this.rdBtnAstar.Name = "rdBtnAstar";
            this.rdBtnAstar.Size = new System.Drawing.Size(72, 24);
            this.rdBtnAstar.TabIndex = 1;
            this.rdBtnAstar.TabStop = true;
            this.rdBtnAstar.Text = "Astar";
            this.rdBtnAstar.UseVisualStyleBackColor = true;
            // 
            // rdbtnStep
            // 
            this.rdbtnStep.AutoSize = true;
            this.rdbtnStep.Location = new System.Drawing.Point(19, 36);
            this.rdbtnStep.Name = "rdbtnStep";
            this.rdbtnStep.Size = new System.Drawing.Size(68, 24);
            this.rdbtnStep.TabIndex = 2;
            this.rdbtnStep.TabStop = true;
            this.rdbtnStep.Text = "Step";
            this.rdbtnStep.UseVisualStyleBackColor = true;
            // 
            // rdBtnStart
            // 
            this.rdBtnStart.AutoSize = true;
            this.rdBtnStart.Location = new System.Drawing.Point(23, 76);
            this.rdBtnStart.Name = "rdBtnStart";
            this.rdBtnStart.Size = new System.Drawing.Size(69, 24);
            this.rdBtnStart.TabIndex = 3;
            this.rdBtnStart.TabStop = true;
            this.rdBtnStart.Text = "Start";
            this.rdBtnStart.UseVisualStyleBackColor = true;
            // 
            // rdBtnDest
            // 
            this.rdBtnDest.AutoSize = true;
            this.rdBtnDest.Location = new System.Drawing.Point(23, 119);
            this.rdBtnDest.Name = "rdBtnDest";
            this.rdBtnDest.Size = new System.Drawing.Size(115, 24);
            this.rdBtnDest.TabIndex = 4;
            this.rdBtnDest.TabStop = true;
            this.rdBtnDest.Text = "Destination";
            this.rdBtnDest.UseVisualStyleBackColor = true;
            // 
            // rdBtnOnlyResult
            // 
            this.rdBtnOnlyResult.AutoSize = true;
            this.rdBtnOnlyResult.Location = new System.Drawing.Point(19, 70);
            this.rdBtnOnlyResult.Name = "rdBtnOnlyResult";
            this.rdBtnOnlyResult.Size = new System.Drawing.Size(80, 24);
            this.rdBtnOnlyResult.TabIndex = 5;
            this.rdBtnOnlyResult.TabStop = true;
            this.rdBtnOnlyResult.Text = "Result";
            this.rdBtnOnlyResult.UseVisualStyleBackColor = true;
            // 
            // rdBtnBFS
            // 
            this.rdBtnBFS.AutoSize = true;
            this.rdBtnBFS.Location = new System.Drawing.Point(21, 39);
            this.rdBtnBFS.Name = "rdBtnBFS";
            this.rdBtnBFS.Size = new System.Drawing.Size(66, 24);
            this.rdBtnBFS.TabIndex = 6;
            this.rdBtnBFS.TabStop = true;
            this.rdBtnBFS.Text = "BFS";
            this.rdBtnBFS.UseVisualStyleBackColor = true;
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(1097, 513);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 38);
            this.btnFind.TabIndex = 7;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(962, 513);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 37);
            this.btnNew.TabIndex = 8;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdBtnWall);
            this.groupBox1.Controls.Add(this.rdBtnStart);
            this.groupBox1.Controls.Add(this.rdBtnDest);
            this.groupBox1.Location = new System.Drawing.Point(962, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 165);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Draw";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdBtnBFS);
            this.groupBox2.Controls.Add(this.rdBtnAstar);
            this.groupBox2.Location = new System.Drawing.Point(962, 222);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 130);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Algorithm";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdbtnStep);
            this.groupBox3.Controls.Add(this.rdBtnOnlyResult);
            this.groupBox3.Location = new System.Drawing.Point(962, 385);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 100);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Show";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1386, 773);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnFind);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rdBtnWall;
        private System.Windows.Forms.RadioButton rdBtnAstar;
        private System.Windows.Forms.RadioButton rdbtnStep;
        private System.Windows.Forms.RadioButton rdBtnStart;
        private System.Windows.Forms.RadioButton rdBtnDest;
        private System.Windows.Forms.RadioButton rdBtnOnlyResult;
        private System.Windows.Forms.RadioButton rdBtnBFS;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}

