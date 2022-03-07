namespace StudentSystemManagement.GUI
{
    partial class ListStudentForm
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
            this.ListClass = new System.Windows.Forms.ComboBox();
            this.Students = new System.Windows.Forms.ListView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ListClass
            // 
            this.ListClass.FormattingEnabled = true;
            this.ListClass.Location = new System.Drawing.Point(0, 1);
            this.ListClass.Name = "ListClass";
            this.ListClass.Size = new System.Drawing.Size(797, 24);
            this.ListClass.TabIndex = 0;
            this.ListClass.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // Students
            // 
            this.Students.Location = new System.Drawing.Point(0, 31);
            this.Students.Name = "Students";
            this.Students.Size = new System.Drawing.Size(797, 323);
            this.Students.TabIndex = 1;
            this.Students.UseCompatibleStateImageBehavior = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(147, 383);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(601, 383);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // ListStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Students);
            this.Controls.Add(this.ListClass);
            this.Name = "ListStudent";
            this.Text = "ListStudent";
            this.Load += new System.EventHandler(this.ListStudent_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox ListClass;
        private System.Windows.Forms.ListView Students;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}