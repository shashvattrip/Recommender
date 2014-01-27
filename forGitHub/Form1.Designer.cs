namespace FinalReco
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
            this.btnLoadData = new System.Windows.Forms.Button();
            this.txtcon = new System.Windows.Forms.TextBox();
            this.btnRecommend = new System.Windows.Forms.Button();
            this.input1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.input2 = new System.Windows.Forms.TextBox();
            this.btnClearConsole = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnHelp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLoadData
            // 
            this.btnLoadData.Location = new System.Drawing.Point(614, 51);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(131, 43);
            this.btnLoadData.TabIndex = 0;
            this.btnLoadData.Text = "Load Data";
            this.btnLoadData.UseVisualStyleBackColor = true;
            this.btnLoadData.Visible = false;
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            // 
            // txtcon
            // 
            this.txtcon.Location = new System.Drawing.Point(21, 51);
            this.txtcon.Multiline = true;
            this.txtcon.Name = "txtcon";
            this.txtcon.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtcon.Size = new System.Drawing.Size(535, 421);
            this.txtcon.TabIndex = 1;
            // 
            // btnRecommend
            // 
            this.btnRecommend.Location = new System.Drawing.Point(614, 274);
            this.btnRecommend.Name = "btnRecommend";
            this.btnRecommend.Size = new System.Drawing.Size(131, 43);
            this.btnRecommend.TabIndex = 2;
            this.btnRecommend.Text = "Recommend";
            this.btnRecommend.UseVisualStyleBackColor = true;
            this.btnRecommend.Click += new System.EventHandler(this.btnRecommend_Click);
            // 
            // input1
            // 
            this.input1.Location = new System.Drawing.Point(614, 171);
            this.input1.Name = "input1";
            this.input1.Size = new System.Drawing.Size(131, 20);
            this.input1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(581, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Who do you want to recommend movies?";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(570, 203);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(235, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "How many movies do you want to Recommend?";
            // 
            // input2
            // 
            this.input2.Location = new System.Drawing.Point(614, 230);
            this.input2.Name = "input2";
            this.input2.Size = new System.Drawing.Size(131, 20);
            this.input2.TabIndex = 6;
            // 
            // btnClearConsole
            // 
            this.btnClearConsole.Location = new System.Drawing.Point(614, 323);
            this.btnClearConsole.Name = "btnClearConsole";
            this.btnClearConsole.Size = new System.Drawing.Size(131, 43);
            this.btnClearConsole.TabIndex = 7;
            this.btnClearConsole.Text = "Clear Console";
            this.btnClearConsole.UseVisualStyleBackColor = true;
            this.btnClearConsole.Click += new System.EventHandler(this.btnClearConsole_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("OCR A Std", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label3.Location = new System.Drawing.Point(91, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(682, 34);
            this.label3.TabIndex = 8;
            this.label3.Text = "Recommendation App for Movies";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Meiryo", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(653, 459);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "By Shashvat Tripathi";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(611, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "UserID : Enter a value 0-942";
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(614, 78);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(131, 43);
            this.btnHelp.TabIndex = 11;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 484);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnClearConsole);
            this.Controls.Add(this.input2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.input1);
            this.Controls.Add(this.btnRecommend);
            this.Controls.Add(this.txtcon);
            this.Controls.Add(this.btnLoadData);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadData;
        private System.Windows.Forms.TextBox txtcon;
        private System.Windows.Forms.Button btnRecommend;
        private System.Windows.Forms.TextBox input1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox input2;
        private System.Windows.Forms.Button btnClearConsole;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnHelp;
    }
}

