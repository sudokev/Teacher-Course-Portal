namespace StudentAssmentProgram
{
    partial class HomePage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomePage));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.programToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LogOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Button_AntiCheat = new System.Windows.Forms.Button();
            this.Button_Attendance = new System.Windows.Forms.Button();
            this.Button_Cirriculum = new System.Windows.Forms.Button();
            this.Button_Grades = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Button_Help = new System.Windows.Forms.Button();
            this.Button_LogOut = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Khaki;
            this.menuStrip1.Font = new System.Drawing.Font("Rockwell", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.programToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(837, 33);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // programToolStripMenuItem
            // 
            this.programToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LogOutToolStripMenuItem});
            this.programToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.LemonChiffon;
            this.programToolStripMenuItem.Name = "programToolStripMenuItem";
            this.programToolStripMenuItem.Size = new System.Drawing.Size(117, 29);
            this.programToolStripMenuItem.Text = "Program";
            // 
            // LogOutToolStripMenuItem
            // 
            this.LogOutToolStripMenuItem.BackColor = System.Drawing.Color.Khaki;
            this.LogOutToolStripMenuItem.Name = "LogOutToolStripMenuItem";
            this.LogOutToolStripMenuItem.Size = new System.Drawing.Size(197, 34);
            this.LogOutToolStripMenuItem.Text = "Log-Out";
            this.LogOutToolStripMenuItem.Click += new System.EventHandler(this.LogOutToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.InformationToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(77, 29);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // InformationToolStripMenuItem
            // 
            this.InformationToolStripMenuItem.BackColor = System.Drawing.Color.Khaki;
            this.InformationToolStripMenuItem.Name = "InformationToolStripMenuItem";
            this.InformationToolStripMenuItem.Size = new System.Drawing.Size(232, 34);
            this.InformationToolStripMenuItem.Text = "Information";
            this.InformationToolStripMenuItem.Click += new System.EventHandler(this.InformationToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Button_AntiCheat);
            this.groupBox1.Controls.Add(this.Button_Attendance);
            this.groupBox1.Controls.Add(this.Button_Cirriculum);
            this.groupBox1.Controls.Add(this.Button_Grades);
            this.groupBox1.Location = new System.Drawing.Point(14, 89);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(536, 532);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // Button_AntiCheat
            // 
            this.Button_AntiCheat.BackColor = System.Drawing.Color.DarkOrange;
            this.Button_AntiCheat.BackgroundImage = global::StudentAssmentProgram.Properties.Resources.Anticheat;
            this.Button_AntiCheat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Button_AntiCheat.Cursor = System.Windows.Forms.Cursors.Default;
            this.Button_AntiCheat.Font = new System.Drawing.Font("Rockwell", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_AntiCheat.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Button_AntiCheat.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Button_AntiCheat.Location = new System.Drawing.Point(272, 269);
            this.Button_AntiCheat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Button_AntiCheat.Name = "Button_AntiCheat";
            this.Button_AntiCheat.Size = new System.Drawing.Size(235, 234);
            this.Button_AntiCheat.TabIndex = 3;
            this.Button_AntiCheat.Text = "Anti-Cheat";
            this.Button_AntiCheat.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Button_AntiCheat.UseVisualStyleBackColor = false;
            this.Button_AntiCheat.Click += new System.EventHandler(this.Button_AntiCheat_Click);
            // 
            // Button_Attendance
            // 
            this.Button_Attendance.BackColor = System.Drawing.Color.MediumOrchid;
            this.Button_Attendance.BackgroundImage = global::StudentAssmentProgram.Properties.Resources.Roster;
            this.Button_Attendance.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Button_Attendance.Font = new System.Drawing.Font("Rockwell", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Attendance.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Button_Attendance.Location = new System.Drawing.Point(30, 30);
            this.Button_Attendance.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Button_Attendance.Name = "Button_Attendance";
            this.Button_Attendance.Size = new System.Drawing.Size(235, 234);
            this.Button_Attendance.TabIndex = 0;
            this.Button_Attendance.Text = "Attendance";
            this.Button_Attendance.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Button_Attendance.UseVisualStyleBackColor = false;
            this.Button_Attendance.Click += new System.EventHandler(this.Button_Attendance_Click);
            // 
            // Button_Cirriculum
            // 
            this.Button_Cirriculum.BackColor = System.Drawing.Color.MediumTurquoise;
            this.Button_Cirriculum.BackgroundImage = global::StudentAssmentProgram.Properties.Resources.Syllabus;
            this.Button_Cirriculum.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Button_Cirriculum.Font = new System.Drawing.Font("Rockwell", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Cirriculum.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Button_Cirriculum.Location = new System.Drawing.Point(30, 269);
            this.Button_Cirriculum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Button_Cirriculum.Name = "Button_Cirriculum";
            this.Button_Cirriculum.Size = new System.Drawing.Size(235, 234);
            this.Button_Cirriculum.TabIndex = 1;
            this.Button_Cirriculum.Text = "Curriculum";
            this.Button_Cirriculum.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Button_Cirriculum.UseVisualStyleBackColor = false;
            this.Button_Cirriculum.Click += new System.EventHandler(this.Button_Cirriculum_Click);
            // 
            // Button_Grades
            // 
            this.Button_Grades.BackColor = System.Drawing.Color.IndianRed;
            this.Button_Grades.BackgroundImage = global::StudentAssmentProgram.Properties.Resources.Grades;
            this.Button_Grades.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Button_Grades.Cursor = System.Windows.Forms.Cursors.Default;
            this.Button_Grades.Font = new System.Drawing.Font("Rockwell", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Grades.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Button_Grades.Location = new System.Drawing.Point(272, 30);
            this.Button_Grades.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Button_Grades.Name = "Button_Grades";
            this.Button_Grades.Size = new System.Drawing.Size(235, 234);
            this.Button_Grades.TabIndex = 2;
            this.Button_Grades.Text = "Check Grades";
            this.Button_Grades.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Button_Grades.UseVisualStyleBackColor = false;
            this.Button_Grades.Click += new System.EventHandler(this.Button_Grades_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Button_Help);
            this.groupBox2.Controls.Add(this.Button_LogOut);
            this.groupBox2.Location = new System.Drawing.Point(556, 89);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(254, 532);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            // 
            // Button_Help
            // 
            this.Button_Help.BackColor = System.Drawing.Color.Peru;
            this.Button_Help.BackgroundImage = global::StudentAssmentProgram.Properties.Resources.Help;
            this.Button_Help.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Button_Help.Cursor = System.Windows.Forms.Cursors.Default;
            this.Button_Help.Font = new System.Drawing.Font("Rockwell", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Help.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Button_Help.Location = new System.Drawing.Point(12, 25);
            this.Button_Help.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Button_Help.Name = "Button_Help";
            this.Button_Help.Size = new System.Drawing.Size(235, 234);
            this.Button_Help.TabIndex = 4;
            this.Button_Help.Text = "Help";
            this.Button_Help.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Button_Help.UseVisualStyleBackColor = false;
            this.Button_Help.Click += new System.EventHandler(this.Button_Help_Click);
            // 
            // Button_LogOut
            // 
            this.Button_LogOut.BackColor = System.Drawing.Color.SeaGreen;
            this.Button_LogOut.BackgroundImage = global::StudentAssmentProgram.Properties.Resources.LogOut;
            this.Button_LogOut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Button_LogOut.Font = new System.Drawing.Font("Rockwell", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_LogOut.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Button_LogOut.Location = new System.Drawing.Point(7, 269);
            this.Button_LogOut.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Button_LogOut.Name = "Button_LogOut";
            this.Button_LogOut.Size = new System.Drawing.Size(235, 234);
            this.Button_LogOut.TabIndex = 4;
            this.Button_LogOut.Text = "Log-Out";
            this.Button_LogOut.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Button_LogOut.UseVisualStyleBackColor = false;
            this.Button_LogOut.Click += new System.EventHandler(this.Button_LogOut_Click);
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LemonChiffon;
            this.ClientSize = new System.Drawing.Size(837, 658);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "HomePage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home Page";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.HomePage_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Button_Attendance;
        private System.Windows.Forms.Button Button_Cirriculum;
        private System.Windows.Forms.Button Button_Grades;
        private System.Windows.Forms.Button Button_AntiCheat;
        private System.Windows.Forms.Button Button_LogOut;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem programToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LogOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem InformationToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button Button_Help;
    }
}