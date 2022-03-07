namespace StudentSystemManagement.GUI
{
    partial class EditScoreForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.MssvBox = new System.Windows.Forms.TextBox();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.MidtermScoreBox = new System.Windows.Forms.TextBox();
            this.FinaltermScoreBox = new System.Windows.Forms.TextBox();
            this.OtherScoreBox = new System.Windows.Forms.TextBox();
            this.AvgBox = new System.Windows.Forms.TextBox();
            this.OKBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "MSSV";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Họ Tên";
            this.label2.Click += new System.EventHandler(this.Label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Điểm Cuối Kì";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 239);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Điểm Giữa Kì";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 310);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Điểm Khác";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 375);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Điểm Tổng";
            // 
            // MssvBox
            // 
            this.MssvBox.Location = new System.Drawing.Point(129, 49);
            this.MssvBox.Name = "MssvBox";
            this.MssvBox.Size = new System.Drawing.Size(100, 22);
            this.MssvBox.TabIndex = 6;
            this.MssvBox.TextChanged += new System.EventHandler(this.MssvBox_TextChanged);
            // 
            // NameBox
            // 
            this.NameBox.Location = new System.Drawing.Point(129, 107);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(100, 22);
            this.NameBox.TabIndex = 7;
            // 
            // MidtermScoreBox
            // 
            this.MidtermScoreBox.Location = new System.Drawing.Point(129, 172);
            this.MidtermScoreBox.Name = "MidtermScoreBox";
            this.MidtermScoreBox.Size = new System.Drawing.Size(100, 22);
            this.MidtermScoreBox.TabIndex = 8;
            this.MidtermScoreBox.TextChanged += new System.EventHandler(this.MidtermScoreBox_TextChanged);
            // 
            // FinaltermScoreBox
            // 
            this.FinaltermScoreBox.Location = new System.Drawing.Point(129, 234);
            this.FinaltermScoreBox.Name = "FinaltermScoreBox";
            this.FinaltermScoreBox.Size = new System.Drawing.Size(100, 22);
            this.FinaltermScoreBox.TabIndex = 9;
            this.FinaltermScoreBox.TextChanged += new System.EventHandler(this.FinaltermScoreBox_TextChanged);
            // 
            // OtherScoreBox
            // 
            this.OtherScoreBox.Location = new System.Drawing.Point(129, 305);
            this.OtherScoreBox.Name = "OtherScoreBox";
            this.OtherScoreBox.Size = new System.Drawing.Size(100, 22);
            this.OtherScoreBox.TabIndex = 10;
            // 
            // AvgBox
            // 
            this.AvgBox.Location = new System.Drawing.Point(129, 370);
            this.AvgBox.Name = "AvgBox";
            this.AvgBox.Size = new System.Drawing.Size(100, 22);
            this.AvgBox.TabIndex = 11;
            // 
            // OKBtn
            // 
            this.OKBtn.Location = new System.Drawing.Point(382, 146);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new System.Drawing.Size(123, 76);
            this.OKBtn.TabIndex = 12;
            this.OKBtn.Text = "OK";
            this.OKBtn.UseVisualStyleBackColor = true;
            this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Location = new System.Drawing.Point(666, 146);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(101, 76);
            this.CancelBtn.TabIndex = 13;
            this.CancelBtn.Text = "Cancle";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // EditScoreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.OKBtn);
            this.Controls.Add(this.AvgBox);
            this.Controls.Add(this.OtherScoreBox);
            this.Controls.Add(this.FinaltermScoreBox);
            this.Controls.Add(this.MidtermScoreBox);
            this.Controls.Add(this.NameBox);
            this.Controls.Add(this.MssvBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "EditScoreForm";
            this.Text = "EditScoreForm";
            this.Load += new System.EventHandler(this.EditScoreForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox MssvBox;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.TextBox MidtermScoreBox;
        private System.Windows.Forms.TextBox FinaltermScoreBox;
        private System.Windows.Forms.TextBox OtherScoreBox;
        private System.Windows.Forms.TextBox AvgBox;
        private System.Windows.Forms.Button OKBtn;
        private System.Windows.Forms.Button CancelBtn;
    }
}