namespace StudentSystemManagement.GUI
{
    partial class AcademicStaffForm
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.classToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.schedulaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.ListClass = new System.Windows.Forms.ComboBox();
            this.ClassDetail = new System.Windows.Forms.ListView();
            this.ListClass1 = new System.Windows.Forms.ComboBox();
            this.ListCourse = new System.Windows.Forms.ComboBox();
            this.CourseListView = new System.Windows.Forms.ListView();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.listView3 = new System.Windows.Forms.ListView();
            this.ScheduleListView = new System.Windows.Forms.ListView();
            this.ScheduleClassComboBox = new System.Windows.Forms.ComboBox();
            this.menuStrip2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Location = new System.Drawing.Point(0, 52);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Location = new System.Drawing.Point(0, 28);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuStrip2
            // 
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(800, 28);
            this.menuStrip2.TabIndex = 3;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.classToolStripMenuItem,
            this.schedulaToolStripMenuItem,
            this.scoreToolStripMenuItem});
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
            this.importToolStripMenuItem.Text = "Import";
            // 
            // classToolStripMenuItem
            // 
            this.classToolStripMenuItem.Name = "classToolStripMenuItem";
            this.classToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.classToolStripMenuItem.Text = "Class";
            this.classToolStripMenuItem.Click += new System.EventHandler(this.ClassToolStripMenuItem_Click);
            // 
            // schedulaToolStripMenuItem
            // 
            this.schedulaToolStripMenuItem.Name = "schedulaToolStripMenuItem";
            this.schedulaToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.schedulaToolStripMenuItem.Text = "Schedula";
            this.schedulaToolStripMenuItem.Click += new System.EventHandler(this.SchedulaToolStripMenuItem_Click);
            // 
            // scoreToolStripMenuItem
            // 
            this.scoreToolStripMenuItem.Name = "scoreToolStripMenuItem";
            this.scoreToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.scoreToolStripMenuItem.Text = "Score";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(0, 28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 427);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ClassDetail);
            this.tabPage1.Controls.Add(this.ListClass);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 398);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Class";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.CourseListView);
            this.tabPage2.Controls.Add(this.ListCourse);
            this.tabPage2.Controls.Add(this.ListClass1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(792, 398);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Course";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.listView3);
            this.tabPage3.Controls.Add(this.comboBox4);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(792, 398);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Score";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.ScheduleClassComboBox);
            this.tabPage4.Controls.Add(this.ScheduleListView);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(792, 398);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Schedule";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // ListClass
            // 
            this.ListClass.FormattingEnabled = true;
            this.ListClass.Location = new System.Drawing.Point(0, 2);
            this.ListClass.Name = "ListClass";
            this.ListClass.Size = new System.Drawing.Size(792, 24);
            this.ListClass.TabIndex = 0;
            this.ListClass.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // ClassDetail
            // 
            this.ClassDetail.Location = new System.Drawing.Point(0, 27);
            this.ClassDetail.Name = "ClassDetail";
            this.ClassDetail.Size = new System.Drawing.Size(796, 371);
            this.ClassDetail.TabIndex = 1;
            this.ClassDetail.UseCompatibleStateImageBehavior = false;
            this.ClassDetail.SelectedIndexChanged += new System.EventHandler(this.ListView1_SelectedIndexChanged);
            this.ClassDetail.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListView1_MouseDoubleClick);
            // 
            // ListClass1
            // 
            this.ListClass1.FormattingEnabled = true;
            this.ListClass1.Location = new System.Drawing.Point(0, 3);
            this.ListClass1.Name = "ListClass1";
            this.ListClass1.Size = new System.Drawing.Size(789, 24);
            this.ListClass1.TabIndex = 0;
            this.ListClass1.SelectedIndexChanged += new System.EventHandler(this.ComboBox2_SelectedIndexChanged);
            // 
            // ListCourse
            // 
            this.ListCourse.FormattingEnabled = true;
            this.ListCourse.Location = new System.Drawing.Point(0, 27);
            this.ListCourse.Name = "ListCourse";
            this.ListCourse.Size = new System.Drawing.Size(789, 24);
            this.ListCourse.TabIndex = 1;
            this.ListCourse.SelectedIndexChanged += new System.EventHandler(this.ComboBox3_SelectedIndexChanged);
            // 
            // CourseListView
            // 
            this.CourseListView.Location = new System.Drawing.Point(0, 57);
            this.CourseListView.Name = "CourseListView";
            this.CourseListView.Size = new System.Drawing.Size(789, 338);
            this.CourseListView.TabIndex = 2;
            this.CourseListView.UseCompatibleStateImageBehavior = false;
            this.CourseListView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ListView2_KeyDown);
            this.CourseListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListView2_MouseDoubleClick);
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(0, 2);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(789, 24);
            this.comboBox4.TabIndex = 5;
            // 
            // listView3
            // 
            this.listView3.Location = new System.Drawing.Point(0, 27);
            this.listView3.Name = "listView3";
            this.listView3.Size = new System.Drawing.Size(792, 375);
            this.listView3.TabIndex = 6;
            this.listView3.UseCompatibleStateImageBehavior = false;
            // 
            // ScheduleListView
            // 
            this.ScheduleListView.Location = new System.Drawing.Point(0, 27);
            this.ScheduleListView.Name = "ScheduleListView";
            this.ScheduleListView.Size = new System.Drawing.Size(792, 375);
            this.ScheduleListView.TabIndex = 7;
            this.ScheduleListView.UseCompatibleStateImageBehavior = false;
            // 
            // ScheduleClassComboBox
            // 
            this.ScheduleClassComboBox.FormattingEnabled = true;
            this.ScheduleClassComboBox.Location = new System.Drawing.Point(0, 3);
            this.ScheduleClassComboBox.Name = "ScheduleClassComboBox";
            this.ScheduleClassComboBox.Size = new System.Drawing.Size(792, 24);
            this.ScheduleClassComboBox.TabIndex = 8;
            this.ScheduleClassComboBox.SelectedIndexChanged += new System.EventHandler(this.ComboBox5_SelectedIndexChanged);
            // 
            // AcademicStaffForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.menuStrip2);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AcademicStaffForm";
            this.Text = "AcademicStaffForm";
            this.MaximumSizeChanged += new System.EventHandler(this.AcademicStaffForm_MaximumSizeChanged);
            this.Load += new System.EventHandler(this.AcademicStaffForm_Load);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem classToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem schedulaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scoreToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ListView ClassDetail;
        private System.Windows.Forms.ComboBox ListClass;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox ListCourse;
        private System.Windows.Forms.ComboBox ListClass1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ListView CourseListView;
        private System.Windows.Forms.ListView listView3;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.ComboBox ScheduleClassComboBox;
        private System.Windows.Forms.ListView ScheduleListView;
    }
}