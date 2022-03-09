
namespace PM_plus {
    partial class Form1 {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.ProjectTagPage = new System.Windows.Forms.TabPage();
            this.OperateMsg_Label = new System.Windows.Forms.Label();
            this.ExitAfterClose_CheckBox = new System.Windows.Forms.CheckBox();
            this.LogSwitch_CheckBox = new System.Windows.Forms.CheckBox();
            this.Author_Label = new System.Windows.Forms.Label();
            this.ProjectGroupBox = new System.Windows.Forms.GroupBox();
            this.Projects_Panel = new System.Windows.Forms.FlowLayoutPanel();
            this.ProjectAdd_Button = new System.Windows.Forms.Button();
            this.AllStart_Button = new System.Windows.Forms.Button();
            this.AllStop_Button = new System.Windows.Forms.Button();
            this.FreshButton = new System.Windows.Forms.Button();
            this.System_GroupBox = new System.Windows.Forms.GroupBox();
            this.Profile_label = new System.Windows.Forms.Label();
            this.Profile_ComboBox = new System.Windows.Forms.ComboBox();
            this.JDKPath_Label = new System.Windows.Forms.Label();
            this.JDKPath_TextBox = new System.Windows.Forms.TextBox();
            this.JDPPath_Dialog_Button = new System.Windows.Forms.Button();
            this.SystemConfig_SaveLabel = new System.Windows.Forms.Label();
            this.SystemConfig_Save_Button = new System.Windows.Forms.Button();
            this.DiySetTabPage = new System.Windows.Forms.TabPage();
            this.SkinGroupBox = new System.Windows.Forms.GroupBox();
            this.SkinChangeApply_Button = new System.Windows.Forms.Button();
            this.SkinListBox = new System.Windows.Forms.ListBox();
            this.HelpTabPage = new System.Windows.Forms.TabPage();
            this.HelpRichTextBox = new System.Windows.Forms.RichTextBox();
            this.JDKPath_FolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.LabelTimer = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.ProjectTagPage.SuspendLayout();
            this.ProjectGroupBox.SuspendLayout();
            this.System_GroupBox.SuspendLayout();
            this.DiySetTabPage.SuspendLayout();
            this.SkinGroupBox.SuspendLayout();
            this.HelpTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.ProjectTagPage);
            this.tabControl1.Controls.Add(this.DiySetTabPage);
            this.tabControl1.Controls.Add(this.HelpTabPage);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(537, 380);
            this.tabControl1.TabIndex = 0;
            // 
            // ProjectTagPage
            // 
            this.ProjectTagPage.Controls.Add(this.OperateMsg_Label);
            this.ProjectTagPage.Controls.Add(this.ExitAfterClose_CheckBox);
            this.ProjectTagPage.Controls.Add(this.LogSwitch_CheckBox);
            this.ProjectTagPage.Controls.Add(this.Author_Label);
            this.ProjectTagPage.Controls.Add(this.ProjectGroupBox);
            this.ProjectTagPage.Controls.Add(this.System_GroupBox);
            this.ProjectTagPage.Location = new System.Drawing.Point(4, 22);
            this.ProjectTagPage.Name = "ProjectTagPage";
            this.ProjectTagPage.Padding = new System.Windows.Forms.Padding(3);
            this.ProjectTagPage.Size = new System.Drawing.Size(529, 354);
            this.ProjectTagPage.TabIndex = 0;
            this.ProjectTagPage.Text = "项目配置";
            this.ProjectTagPage.UseVisualStyleBackColor = true;
            // 
            // OperateMsg_Label
            // 
            this.OperateMsg_Label.AutoSize = true;
            this.OperateMsg_Label.Location = new System.Drawing.Point(161, 358);
            this.OperateMsg_Label.Name = "OperateMsg_Label";
            this.OperateMsg_Label.Size = new System.Drawing.Size(0, 12);
            this.OperateMsg_Label.TabIndex = 26;
            // 
            // ExitAfterClose_CheckBox
            // 
            this.ExitAfterClose_CheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ExitAfterClose_CheckBox.AutoSize = true;
            this.ExitAfterClose_CheckBox.Location = new System.Drawing.Point(83, 332);
            this.ExitAfterClose_CheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ExitAfterClose_CheckBox.Name = "ExitAfterClose_CheckBox";
            this.ExitAfterClose_CheckBox.Size = new System.Drawing.Size(72, 16);
            this.ExitAfterClose_CheckBox.TabIndex = 25;
            this.ExitAfterClose_CheckBox.Text = "关闭退出";
            this.ExitAfterClose_CheckBox.UseVisualStyleBackColor = true;
            // 
            // LogSwitch_CheckBox
            // 
            this.LogSwitch_CheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LogSwitch_CheckBox.AutoSize = true;
            this.LogSwitch_CheckBox.Location = new System.Drawing.Point(5, 332);
            this.LogSwitch_CheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LogSwitch_CheckBox.Name = "LogSwitch_CheckBox";
            this.LogSwitch_CheckBox.Size = new System.Drawing.Size(72, 16);
            this.LogSwitch_CheckBox.TabIndex = 24;
            this.LogSwitch_CheckBox.Text = "开启日志";
            this.LogSwitch_CheckBox.UseVisualStyleBackColor = true;
            // 
            // Author_Label
            // 
            this.Author_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Author_Label.AutoSize = true;
            this.Author_Label.Location = new System.Drawing.Point(385, 334);
            this.Author_Label.Name = "Author_Label";
            this.Author_Label.Size = new System.Drawing.Size(137, 12);
            this.Author_Label.TabIndex = 23;
            this.Author_Label.Text = "作者:1320311706@qq.com";
            // 
            // ProjectGroupBox
            // 
            this.ProjectGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProjectGroupBox.Controls.Add(this.Projects_Panel);
            this.ProjectGroupBox.Controls.Add(this.ProjectAdd_Button);
            this.ProjectGroupBox.Controls.Add(this.AllStart_Button);
            this.ProjectGroupBox.Controls.Add(this.AllStop_Button);
            this.ProjectGroupBox.Controls.Add(this.FreshButton);
            this.ProjectGroupBox.Location = new System.Drawing.Point(7, 81);
            this.ProjectGroupBox.Name = "ProjectGroupBox";
            this.ProjectGroupBox.Size = new System.Drawing.Size(517, 239);
            this.ProjectGroupBox.TabIndex = 22;
            this.ProjectGroupBox.TabStop = false;
            this.ProjectGroupBox.Text = "项目";
            // 
            // Projects_Panel
            // 
            this.Projects_Panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Projects_Panel.Location = new System.Drawing.Point(1, 21);
            this.Projects_Panel.Name = "Projects_Panel";
            this.Projects_Panel.Size = new System.Drawing.Size(516, 176);
            this.Projects_Panel.TabIndex = 21;
            // 
            // ProjectAdd_Button
            // 
            this.ProjectAdd_Button.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProjectAdd_Button.Font = new System.Drawing.Font("Microsoft YaHei UI", 15F);
            this.ProjectAdd_Button.Location = new System.Drawing.Point(7, 202);
            this.ProjectAdd_Button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ProjectAdd_Button.Name = "ProjectAdd_Button";
            this.ProjectAdd_Button.Size = new System.Drawing.Size(259, 32);
            this.ProjectAdd_Button.TabIndex = 15;
            this.ProjectAdd_Button.Text = "+";
            this.ProjectAdd_Button.UseVisualStyleBackColor = true;
            this.ProjectAdd_Button.Click += new System.EventHandler(this.ProjectAdd_Button_Click);
            // 
            // AllStart_Button
            // 
            this.AllStart_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AllStart_Button.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F);
            this.AllStart_Button.Location = new System.Drawing.Point(357, 202);
            this.AllStart_Button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AllStart_Button.Name = "AllStart_Button";
            this.AllStart_Button.Size = new System.Drawing.Size(81, 32);
            this.AllStart_Button.TabIndex = 19;
            this.AllStart_Button.Text = "全部启动";
            this.AllStart_Button.UseVisualStyleBackColor = true;
            this.AllStart_Button.Click += new System.EventHandler(this.AllStart_Button_Click);
            // 
            // AllStop_Button
            // 
            this.AllStop_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AllStop_Button.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F);
            this.AllStop_Button.Location = new System.Drawing.Point(442, 202);
            this.AllStop_Button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AllStop_Button.Name = "AllStop_Button";
            this.AllStop_Button.Size = new System.Drawing.Size(75, 32);
            this.AllStop_Button.TabIndex = 20;
            this.AllStop_Button.Text = "全部停止";
            this.AllStop_Button.UseVisualStyleBackColor = true;
            this.AllStop_Button.Click += new System.EventHandler(this.AllStop_Button_Click);
            // 
            // FreshButton
            // 
            this.FreshButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.FreshButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F);
            this.FreshButton.Location = new System.Drawing.Point(271, 202);
            this.FreshButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FreshButton.Name = "FreshButton";
            this.FreshButton.Size = new System.Drawing.Size(81, 32);
            this.FreshButton.TabIndex = 18;
            this.FreshButton.Text = "刷新";
            this.FreshButton.UseVisualStyleBackColor = true;
            this.FreshButton.Click += new System.EventHandler(this.Fresh_Button_Click);
            // 
            // System_GroupBox
            // 
            this.System_GroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.System_GroupBox.Controls.Add(this.Profile_label);
            this.System_GroupBox.Controls.Add(this.Profile_ComboBox);
            this.System_GroupBox.Controls.Add(this.JDKPath_Label);
            this.System_GroupBox.Controls.Add(this.JDKPath_TextBox);
            this.System_GroupBox.Controls.Add(this.JDPPath_Dialog_Button);
            this.System_GroupBox.Controls.Add(this.SystemConfig_SaveLabel);
            this.System_GroupBox.Controls.Add(this.SystemConfig_Save_Button);
            this.System_GroupBox.Location = new System.Drawing.Point(6, 6);
            this.System_GroupBox.Name = "System_GroupBox";
            this.System_GroupBox.Size = new System.Drawing.Size(518, 68);
            this.System_GroupBox.TabIndex = 21;
            this.System_GroupBox.TabStop = false;
            this.System_GroupBox.Text = "环境配置";
            // 
            // Profile_label
            // 
            this.Profile_label.AutoSize = true;
            this.Profile_label.Location = new System.Drawing.Point(4, 23);
            this.Profile_label.Name = "Profile_label";
            this.Profile_label.Size = new System.Drawing.Size(59, 12);
            this.Profile_label.TabIndex = 8;
            this.Profile_label.Text = "运行环境:";
            // 
            // Profile_ComboBox
            // 
            this.Profile_ComboBox.FormattingEnabled = true;
            this.Profile_ComboBox.Items.AddRange(new object[] {
            "dev",
            "test",
            "prod"});
            this.Profile_ComboBox.Location = new System.Drawing.Point(69, 19);
            this.Profile_ComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Profile_ComboBox.Name = "Profile_ComboBox";
            this.Profile_ComboBox.Size = new System.Drawing.Size(96, 20);
            this.Profile_ComboBox.TabIndex = 9;
            // 
            // JDKPath_Label
            // 
            this.JDKPath_Label.AutoSize = true;
            this.JDKPath_Label.Location = new System.Drawing.Point(170, 23);
            this.JDKPath_Label.Name = "JDKPath_Label";
            this.JDKPath_Label.Size = new System.Drawing.Size(53, 12);
            this.JDKPath_Label.TabIndex = 10;
            this.JDKPath_Label.Text = "JDK路径:";
            // 
            // JDKPath_TextBox
            // 
            this.JDKPath_TextBox.Location = new System.Drawing.Point(225, 19);
            this.JDKPath_TextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.JDKPath_TextBox.Name = "JDKPath_TextBox";
            this.JDKPath_TextBox.Size = new System.Drawing.Size(263, 21);
            this.JDKPath_TextBox.TabIndex = 11;
            // 
            // JDPPath_Dialog_Button
            // 
            this.JDPPath_Dialog_Button.Location = new System.Drawing.Point(490, 19);
            this.JDPPath_Dialog_Button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.JDPPath_Dialog_Button.Name = "JDPPath_Dialog_Button";
            this.JDPPath_Dialog_Button.Size = new System.Drawing.Size(22, 20);
            this.JDPPath_Dialog_Button.TabIndex = 12;
            this.JDPPath_Dialog_Button.Text = "...";
            this.JDPPath_Dialog_Button.UseVisualStyleBackColor = true;
            this.JDPPath_Dialog_Button.Click += new System.EventHandler(this.JDKPath_Dialog_Button_Click);
            // 
            // SystemConfig_SaveLabel
            // 
            this.SystemConfig_SaveLabel.AutoSize = true;
            this.SystemConfig_SaveLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.SystemConfig_SaveLabel.Location = new System.Drawing.Point(6, 47);
            this.SystemConfig_SaveLabel.Name = "SystemConfig_SaveLabel";
            this.SystemConfig_SaveLabel.Size = new System.Drawing.Size(53, 12);
            this.SystemConfig_SaveLabel.TabIndex = 14;
            this.SystemConfig_SaveLabel.Text = "保存成功";
            this.SystemConfig_SaveLabel.Visible = false;
            // 
            // SystemConfig_Save_Button
            // 
            this.SystemConfig_Save_Button.Location = new System.Drawing.Point(470, 52);
            this.SystemConfig_Save_Button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SystemConfig_Save_Button.Name = "SystemConfig_Save_Button";
            this.SystemConfig_Save_Button.Size = new System.Drawing.Size(46, 23);
            this.SystemConfig_Save_Button.TabIndex = 13;
            this.SystemConfig_Save_Button.Text = "保存";
            this.SystemConfig_Save_Button.UseVisualStyleBackColor = true;
            this.SystemConfig_Save_Button.Visible = false;
            // 
            // DiySetTabPage
            // 
            this.DiySetTabPage.Controls.Add(this.SkinGroupBox);
            this.DiySetTabPage.Location = new System.Drawing.Point(4, 22);
            this.DiySetTabPage.Name = "DiySetTabPage";
            this.DiySetTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.DiySetTabPage.Size = new System.Drawing.Size(529, 354);
            this.DiySetTabPage.TabIndex = 1;
            this.DiySetTabPage.Text = "偏好设置";
            this.DiySetTabPage.UseVisualStyleBackColor = true;
            // 
            // SkinGroupBox
            // 
            this.SkinGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SkinGroupBox.Controls.Add(this.SkinChangeApply_Button);
            this.SkinGroupBox.Controls.Add(this.SkinListBox);
            this.SkinGroupBox.Location = new System.Drawing.Point(340, 7);
            this.SkinGroupBox.Name = "SkinGroupBox";
            this.SkinGroupBox.Size = new System.Drawing.Size(182, 338);
            this.SkinGroupBox.TabIndex = 0;
            this.SkinGroupBox.TabStop = false;
            this.SkinGroupBox.Text = "皮肤";
            // 
            // SkinChangeApply_Button
            // 
            this.SkinChangeApply_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SkinChangeApply_Button.Location = new System.Drawing.Point(101, 309);
            this.SkinChangeApply_Button.Name = "SkinChangeApply_Button";
            this.SkinChangeApply_Button.Size = new System.Drawing.Size(75, 23);
            this.SkinChangeApply_Button.TabIndex = 1;
            this.SkinChangeApply_Button.Text = "应用";
            this.SkinChangeApply_Button.UseVisualStyleBackColor = true;
            this.SkinChangeApply_Button.Click += new System.EventHandler(this.SkinChangeApply_Button_Click);
            // 
            // SkinListBox
            // 
            this.SkinListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SkinListBox.FormattingEnabled = true;
            this.SkinListBox.ItemHeight = 12;
            this.SkinListBox.Location = new System.Drawing.Point(7, 21);
            this.SkinListBox.Name = "SkinListBox";
            this.SkinListBox.Size = new System.Drawing.Size(169, 280);
            this.SkinListBox.TabIndex = 0;
            this.SkinListBox.SelectedIndexChanged += new System.EventHandler(this.SkinListBox_SelectedIndexChanged);
            // 
            // HelpTabPage
            // 
            this.HelpTabPage.Controls.Add(this.HelpRichTextBox);
            this.HelpTabPage.Location = new System.Drawing.Point(4, 22);
            this.HelpTabPage.Name = "HelpTabPage";
            this.HelpTabPage.Size = new System.Drawing.Size(551, 378);
            this.HelpTabPage.TabIndex = 2;
            this.HelpTabPage.Text = "帮助";
            this.HelpTabPage.UseVisualStyleBackColor = true;
            // 
            // HelpRichTextBox
            // 
            this.HelpRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.HelpRichTextBox.Location = new System.Drawing.Point(3, 2);
            this.HelpRichTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.HelpRichTextBox.Name = "HelpRichTextBox";
            this.HelpRichTextBox.Size = new System.Drawing.Size(544, 374);
            this.HelpRichTextBox.TabIndex = 1;
            this.HelpRichTextBox.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 404);
            this.Controls.Add(this.tabControl1);
            this.MaximumSize = new System.Drawing.Size(577, 717);
            this.MinimumSize = new System.Drawing.Size(577, 251);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Java项目管理";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.ProjectTagPage.ResumeLayout(false);
            this.ProjectTagPage.PerformLayout();
            this.ProjectGroupBox.ResumeLayout(false);
            this.System_GroupBox.ResumeLayout(false);
            this.System_GroupBox.PerformLayout();
            this.DiySetTabPage.ResumeLayout(false);
            this.SkinGroupBox.ResumeLayout(false);
            this.HelpTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage ProjectTagPage;
        private System.Windows.Forms.TabPage DiySetTabPage;
        private System.Windows.Forms.GroupBox SkinGroupBox;
        internal System.Windows.Forms.ListBox SkinListBox;
        private System.Windows.Forms.GroupBox ProjectGroupBox;
        internal System.Windows.Forms.Button ProjectAdd_Button;
        internal System.Windows.Forms.Button AllStart_Button;
        internal System.Windows.Forms.Button AllStop_Button;
        internal System.Windows.Forms.Button FreshButton;
        private System.Windows.Forms.GroupBox System_GroupBox;
        private System.Windows.Forms.Label Profile_label;
        internal System.Windows.Forms.ComboBox Profile_ComboBox;
        private System.Windows.Forms.Label JDKPath_Label;
        internal System.Windows.Forms.TextBox JDKPath_TextBox;
        private System.Windows.Forms.Button JDPPath_Dialog_Button;
        private System.Windows.Forms.Label SystemConfig_SaveLabel;
        private System.Windows.Forms.Button SystemConfig_Save_Button;
        private System.Windows.Forms.FolderBrowserDialog JDKPath_FolderBrowserDialog;
        private System.Windows.Forms.Timer LabelTimer;
        internal System.Windows.Forms.CheckBox ExitAfterClose_CheckBox;
        internal System.Windows.Forms.CheckBox LogSwitch_CheckBox;
        private System.Windows.Forms.Label Author_Label;
        internal System.Windows.Forms.Label OperateMsg_Label;
        internal System.Windows.Forms.FlowLayoutPanel Projects_Panel;
        private System.Windows.Forms.TabPage HelpTabPage;
        internal System.Windows.Forms.RichTextBox HelpRichTextBox;
        private System.Windows.Forms.Button SkinChangeApply_Button;
    }
}

