﻿
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
            this.Profile_TextBox = new System.Windows.Forms.TextBox();
            this.LogPath_Dialog_Button = new System.Windows.Forms.Button();
            this.LogPath_TextBox = new System.Windows.Forms.TextBox();
            this.LogPathLabel = new System.Windows.Forms.Label();
            this.Profile_label = new System.Windows.Forms.Label();
            this.JDKPath_Label = new System.Windows.Forms.Label();
            this.JDKPath_TextBox = new System.Windows.Forms.TextBox();
            this.JDKPath_Dialog_Button = new System.Windows.Forms.Button();
            this.SystemConfig_SaveLabel = new System.Windows.Forms.Label();
            this.SystemConfig_Save_Button = new System.Windows.Forms.Button();
            this.MonitorTabPage = new System.Windows.Forms.TabPage();
            this.MonitorFreqLabel = new System.Windows.Forms.Label();
            this.MonitorFreqComboBox = new System.Windows.Forms.ComboBox();
            this.ServerInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.MemoryAvailableLabel = new System.Windows.Forms.Label();
            this.MemoryAvailableTextBox = new System.Windows.Forms.TextBox();
            this.MemoryUsedTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.MemoryTotalLabel = new System.Windows.Forms.Label();
            this.MemoryTotalTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CpuIdleLabel = new System.Windows.Forms.Label();
            this.CpuUsedLabel = new System.Windows.Forms.Label();
            this.CpuUsedTextBox = new System.Windows.Forms.TextBox();
            this.CpuIdleTextBox = new System.Windows.Forms.TextBox();
            this.DiySetTabPage = new System.Windows.Forms.TabPage();
            this.SkinSwitchChecked = new System.Windows.Forms.CheckBox();
            this.DiySetMsgLabel = new System.Windows.Forms.Label();
            this.ResetButton = new System.Windows.Forms.Button();
            this.DiySetChangeApply_Button = new System.Windows.Forms.Button();
            this.FontFamilyComboBox = new System.Windows.Forms.ComboBox();
            this.FontLabel = new System.Windows.Forms.Label();
            this.SkinGroupBox = new System.Windows.Forms.GroupBox();
            this.SkinShowPictureBox = new System.Windows.Forms.PictureBox();
            this.SkinListBox = new System.Windows.Forms.ListBox();
            this.ToolTabPage = new System.Windows.Forms.TabPage();
            this.HttpRequestGroupBox = new System.Windows.Forms.GroupBox();
            this.SendHistoryButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.ResponseLabel = new System.Windows.Forms.Label();
            this.HttpSendResponseRichTextBox = new System.Windows.Forms.RichTextBox();
            this.HttpSendButton = new System.Windows.Forms.Button();
            this.TypeLabel = new System.Windows.Forms.Label();
            this.TypeComboBox = new System.Windows.Forms.ComboBox();
            this.UrlLabel = new System.Windows.Forms.Label();
            this.UrlTextBox = new System.Windows.Forms.RichTextBox();
            this.HelpTabPage = new System.Windows.Forms.TabPage();
            this.HelpRichTextBox = new System.Windows.Forms.RichTextBox();
            this.JDKPath_FolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.LabelTimer = new System.Windows.Forms.Timer(this.components);
            this.LogPath_FolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.tabControl1.SuspendLayout();
            this.ProjectTagPage.SuspendLayout();
            this.ProjectGroupBox.SuspendLayout();
            this.System_GroupBox.SuspendLayout();
            this.MonitorTabPage.SuspendLayout();
            this.ServerInfoGroupBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.DiySetTabPage.SuspendLayout();
            this.SkinGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SkinShowPictureBox)).BeginInit();
            this.ToolTabPage.SuspendLayout();
            this.HttpRequestGroupBox.SuspendLayout();
            this.HelpTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.ProjectTagPage);
            this.tabControl1.Controls.Add(this.MonitorTabPage);
            this.tabControl1.Controls.Add(this.DiySetTabPage);
            this.tabControl1.Controls.Add(this.ToolTabPage);
            this.tabControl1.Controls.Add(this.HelpTabPage);
            this.tabControl1.ItemSize = new System.Drawing.Size(60, 25);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(599, 465);
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
            this.ProjectTagPage.Location = new System.Drawing.Point(4, 29);
            this.ProjectTagPage.Name = "ProjectTagPage";
            this.ProjectTagPage.Padding = new System.Windows.Forms.Padding(3);
            this.ProjectTagPage.Size = new System.Drawing.Size(591, 432);
            this.ProjectTagPage.TabIndex = 0;
            this.ProjectTagPage.Text = "项目配置";
            this.ProjectTagPage.UseVisualStyleBackColor = true;
            // 
            // OperateMsg_Label
            // 
            this.OperateMsg_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.OperateMsg_Label.AutoSize = true;
            this.OperateMsg_Label.Location = new System.Drawing.Point(161, 411);
            this.OperateMsg_Label.Name = "OperateMsg_Label";
            this.OperateMsg_Label.Size = new System.Drawing.Size(0, 12);
            this.OperateMsg_Label.TabIndex = 26;
            // 
            // ExitAfterClose_CheckBox
            // 
            this.ExitAfterClose_CheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ExitAfterClose_CheckBox.AutoSize = true;
            this.ExitAfterClose_CheckBox.Location = new System.Drawing.Point(83, 410);
            this.ExitAfterClose_CheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ExitAfterClose_CheckBox.Name = "ExitAfterClose_CheckBox";
            this.ExitAfterClose_CheckBox.Size = new System.Drawing.Size(72, 16);
            this.ExitAfterClose_CheckBox.TabIndex = 25;
            this.ExitAfterClose_CheckBox.Text = "关闭退出";
            this.ExitAfterClose_CheckBox.UseVisualStyleBackColor = true;
            this.ExitAfterClose_CheckBox.Visible = false;
            this.ExitAfterClose_CheckBox.CheckedChanged += new System.EventHandler(this.ExitAfterClose_CheckBox_CheckedChanged);
            // 
            // LogSwitch_CheckBox
            // 
            this.LogSwitch_CheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LogSwitch_CheckBox.AutoSize = true;
            this.LogSwitch_CheckBox.Location = new System.Drawing.Point(5, 410);
            this.LogSwitch_CheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LogSwitch_CheckBox.Name = "LogSwitch_CheckBox";
            this.LogSwitch_CheckBox.Size = new System.Drawing.Size(72, 16);
            this.LogSwitch_CheckBox.TabIndex = 24;
            this.LogSwitch_CheckBox.Text = "开启日志";
            this.LogSwitch_CheckBox.UseVisualStyleBackColor = true;
            this.LogSwitch_CheckBox.CheckedChanged += new System.EventHandler(this.LogSwitch_CheckBox_CheckedChanged);
            // 
            // Author_Label
            // 
            this.Author_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Author_Label.AutoSize = true;
            this.Author_Label.Location = new System.Drawing.Point(414, 411);
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
            this.ProjectGroupBox.Location = new System.Drawing.Point(7, 105);
            this.ProjectGroupBox.Name = "ProjectGroupBox";
            this.ProjectGroupBox.Size = new System.Drawing.Size(579, 293);
            this.ProjectGroupBox.TabIndex = 22;
            this.ProjectGroupBox.TabStop = false;
            this.ProjectGroupBox.Text = "项目";
            // 
            // Projects_Panel
            // 
            this.Projects_Panel.AllowDrop = true;
            this.Projects_Panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Projects_Panel.Location = new System.Drawing.Point(6, 21);
            this.Projects_Panel.Name = "Projects_Panel";
            this.Projects_Panel.Size = new System.Drawing.Size(567, 230);
            this.Projects_Panel.TabIndex = 21;
            this.Projects_Panel.ClientSizeChanged += new System.EventHandler(this.Projects_Panel_ClientSizeChanged);
            this.Projects_Panel.DragDrop += new System.Windows.Forms.DragEventHandler(this.Projects_Panel_DragDrop);
            this.Projects_Panel.DragEnter += new System.Windows.Forms.DragEventHandler(this.Projects_Panel_DragEnter);
            // 
            // ProjectAdd_Button
            // 
            this.ProjectAdd_Button.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProjectAdd_Button.Font = new System.Drawing.Font("Microsoft YaHei UI", 15F);
            this.ProjectAdd_Button.Location = new System.Drawing.Point(7, 256);
            this.ProjectAdd_Button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ProjectAdd_Button.Name = "ProjectAdd_Button";
            this.ProjectAdd_Button.Size = new System.Drawing.Size(309, 32);
            this.ProjectAdd_Button.TabIndex = 15;
            this.ProjectAdd_Button.Text = "+";
            this.ProjectAdd_Button.UseVisualStyleBackColor = true;
            this.ProjectAdd_Button.Click += new System.EventHandler(this.ProjectAdd_Button_Click);
            // 
            // AllStart_Button
            // 
            this.AllStart_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AllStart_Button.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F);
            this.AllStart_Button.Location = new System.Drawing.Point(409, 256);
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
            this.AllStop_Button.Location = new System.Drawing.Point(496, 256);
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
            this.FreshButton.Location = new System.Drawing.Point(322, 256);
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
            this.System_GroupBox.Controls.Add(this.Profile_TextBox);
            this.System_GroupBox.Controls.Add(this.LogPath_Dialog_Button);
            this.System_GroupBox.Controls.Add(this.LogPath_TextBox);
            this.System_GroupBox.Controls.Add(this.LogPathLabel);
            this.System_GroupBox.Controls.Add(this.Profile_label);
            this.System_GroupBox.Controls.Add(this.JDKPath_Label);
            this.System_GroupBox.Controls.Add(this.JDKPath_TextBox);
            this.System_GroupBox.Controls.Add(this.JDKPath_Dialog_Button);
            this.System_GroupBox.Controls.Add(this.SystemConfig_SaveLabel);
            this.System_GroupBox.Controls.Add(this.SystemConfig_Save_Button);
            this.System_GroupBox.Location = new System.Drawing.Point(6, 6);
            this.System_GroupBox.Name = "System_GroupBox";
            this.System_GroupBox.Size = new System.Drawing.Size(580, 93);
            this.System_GroupBox.TabIndex = 21;
            this.System_GroupBox.TabStop = false;
            this.System_GroupBox.Text = "环境配置";
            // 
            // Profile_TextBox
            // 
            this.Profile_TextBox.Location = new System.Drawing.Point(77, 19);
            this.Profile_TextBox.Name = "Profile_TextBox";
            this.Profile_TextBox.Size = new System.Drawing.Size(96, 21);
            this.Profile_TextBox.TabIndex = 18;
            // 
            // LogPath_Dialog_Button
            // 
            this.LogPath_Dialog_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LogPath_Dialog_Button.Location = new System.Drawing.Point(542, 44);
            this.LogPath_Dialog_Button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LogPath_Dialog_Button.Name = "LogPath_Dialog_Button";
            this.LogPath_Dialog_Button.Size = new System.Drawing.Size(28, 22);
            this.LogPath_Dialog_Button.TabIndex = 17;
            this.LogPath_Dialog_Button.Text = "...";
            this.LogPath_Dialog_Button.UseVisualStyleBackColor = true;
            this.LogPath_Dialog_Button.Click += new System.EventHandler(this.LogPath_Dialog_Button_Click);
            // 
            // LogPath_TextBox
            // 
            this.LogPath_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogPath_TextBox.Location = new System.Drawing.Point(77, 45);
            this.LogPath_TextBox.Name = "LogPath_TextBox";
            this.LogPath_TextBox.Size = new System.Drawing.Size(459, 21);
            this.LogPath_TextBox.TabIndex = 16;
            this.LogPath_TextBox.TextChanged += new System.EventHandler(this.LogPath_TextBox_TextChanged);
            // 
            // LogPathLabel
            // 
            this.LogPathLabel.AutoSize = true;
            this.LogPathLabel.Location = new System.Drawing.Point(12, 49);
            this.LogPathLabel.Name = "LogPathLabel";
            this.LogPathLabel.Size = new System.Drawing.Size(59, 12);
            this.LogPathLabel.TabIndex = 15;
            this.LogPathLabel.Text = "日志路径:";
            // 
            // Profile_label
            // 
            this.Profile_label.AutoSize = true;
            this.Profile_label.Location = new System.Drawing.Point(12, 23);
            this.Profile_label.Name = "Profile_label";
            this.Profile_label.Size = new System.Drawing.Size(59, 12);
            this.Profile_label.TabIndex = 8;
            this.Profile_label.Text = "运行环境:";
            // 
            // JDKPath_Label
            // 
            this.JDKPath_Label.AutoSize = true;
            this.JDKPath_Label.Location = new System.Drawing.Point(179, 23);
            this.JDKPath_Label.Name = "JDKPath_Label";
            this.JDKPath_Label.Size = new System.Drawing.Size(53, 12);
            this.JDKPath_Label.TabIndex = 10;
            this.JDKPath_Label.Text = "JDK路径:";
            // 
            // JDKPath_TextBox
            // 
            this.JDKPath_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.JDKPath_TextBox.Location = new System.Drawing.Point(238, 19);
            this.JDKPath_TextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.JDKPath_TextBox.Name = "JDKPath_TextBox";
            this.JDKPath_TextBox.Size = new System.Drawing.Size(298, 21);
            this.JDKPath_TextBox.TabIndex = 11;
            this.JDKPath_TextBox.TextChanged += new System.EventHandler(this.JDKPath_TextBox_TextChanged);
            // 
            // JDKPath_Dialog_Button
            // 
            this.JDKPath_Dialog_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.JDKPath_Dialog_Button.Location = new System.Drawing.Point(542, 18);
            this.JDKPath_Dialog_Button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.JDKPath_Dialog_Button.Name = "JDKPath_Dialog_Button";
            this.JDKPath_Dialog_Button.Size = new System.Drawing.Size(28, 22);
            this.JDKPath_Dialog_Button.TabIndex = 12;
            this.JDKPath_Dialog_Button.Text = "...";
            this.JDKPath_Dialog_Button.UseVisualStyleBackColor = true;
            this.JDKPath_Dialog_Button.Click += new System.EventHandler(this.JDKPath_Dialog_Button_Click);
            // 
            // SystemConfig_SaveLabel
            // 
            this.SystemConfig_SaveLabel.AutoSize = true;
            this.SystemConfig_SaveLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.SystemConfig_SaveLabel.Location = new System.Drawing.Point(14, 75);
            this.SystemConfig_SaveLabel.Name = "SystemConfig_SaveLabel";
            this.SystemConfig_SaveLabel.Size = new System.Drawing.Size(53, 12);
            this.SystemConfig_SaveLabel.TabIndex = 14;
            this.SystemConfig_SaveLabel.Text = "保存成功";
            this.SystemConfig_SaveLabel.Visible = false;
            // 
            // SystemConfig_Save_Button
            // 
            this.SystemConfig_Save_Button.Location = new System.Drawing.Point(524, 71);
            this.SystemConfig_Save_Button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SystemConfig_Save_Button.Name = "SystemConfig_Save_Button";
            this.SystemConfig_Save_Button.Size = new System.Drawing.Size(46, 23);
            this.SystemConfig_Save_Button.TabIndex = 13;
            this.SystemConfig_Save_Button.Text = "保存";
            this.SystemConfig_Save_Button.UseVisualStyleBackColor = true;
            this.SystemConfig_Save_Button.Click += new System.EventHandler(this.SystemConfig_Save_Button_Click);
            // 
            // MonitorTabPage
            // 
            this.MonitorTabPage.Controls.Add(this.MonitorFreqLabel);
            this.MonitorTabPage.Controls.Add(this.MonitorFreqComboBox);
            this.MonitorTabPage.Controls.Add(this.ServerInfoGroupBox);
            this.MonitorTabPage.Location = new System.Drawing.Point(4, 29);
            this.MonitorTabPage.Name = "MonitorTabPage";
            this.MonitorTabPage.Size = new System.Drawing.Size(591, 432);
            this.MonitorTabPage.TabIndex = 4;
            this.MonitorTabPage.Text = "监控";
            this.MonitorTabPage.UseVisualStyleBackColor = true;
            // 
            // MonitorFreqLabel
            // 
            this.MonitorFreqLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.MonitorFreqLabel.AutoSize = true;
            this.MonitorFreqLabel.Location = new System.Drawing.Point(4, 388);
            this.MonitorFreqLabel.Name = "MonitorFreqLabel";
            this.MonitorFreqLabel.Size = new System.Drawing.Size(41, 12);
            this.MonitorFreqLabel.TabIndex = 2;
            this.MonitorFreqLabel.Text = "刷新率";
            // 
            // MonitorFreqComboBox
            // 
            this.MonitorFreqComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.MonitorFreqComboBox.FormattingEnabled = true;
            this.MonitorFreqComboBox.Items.AddRange(new object[] {
            "0",
            "1",
            "5",
            "10",
            "30"});
            this.MonitorFreqComboBox.Location = new System.Drawing.Point(51, 388);
            this.MonitorFreqComboBox.Name = "MonitorFreqComboBox";
            this.MonitorFreqComboBox.Size = new System.Drawing.Size(61, 20);
            this.MonitorFreqComboBox.TabIndex = 1;
            this.MonitorFreqComboBox.SelectedIndexChanged += new System.EventHandler(this.MonitorFreqComboBox_SelectedIndexChanged);
            // 
            // ServerInfoGroupBox
            // 
            this.ServerInfoGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ServerInfoGroupBox.Controls.Add(this.groupBox2);
            this.ServerInfoGroupBox.Controls.Add(this.groupBox1);
            this.ServerInfoGroupBox.Location = new System.Drawing.Point(4, 4);
            this.ServerInfoGroupBox.Name = "ServerInfoGroupBox";
            this.ServerInfoGroupBox.Size = new System.Drawing.Size(584, 377);
            this.ServerInfoGroupBox.TabIndex = 0;
            this.ServerInfoGroupBox.TabStop = false;
            this.ServerInfoGroupBox.Text = "服务器信息";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.MemoryAvailableLabel);
            this.groupBox2.Controls.Add(this.MemoryAvailableTextBox);
            this.groupBox2.Controls.Add(this.MemoryUsedTextBox);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.MemoryTotalLabel);
            this.groupBox2.Controls.Add(this.MemoryTotalTextBox);
            this.groupBox2.Location = new System.Drawing.Point(7, 78);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(571, 65);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "内存";
            // 
            // MemoryAvailableLabel
            // 
            this.MemoryAvailableLabel.AutoSize = true;
            this.MemoryAvailableLabel.Location = new System.Drawing.Point(381, 24);
            this.MemoryAvailableLabel.Name = "MemoryAvailableLabel";
            this.MemoryAvailableLabel.Size = new System.Drawing.Size(29, 12);
            this.MemoryAvailableLabel.TabIndex = 8;
            this.MemoryAvailableLabel.Text = "剩余";
            // 
            // MemoryAvailableTextBox
            // 
            this.MemoryAvailableTextBox.Location = new System.Drawing.Point(416, 20);
            this.MemoryAvailableTextBox.Name = "MemoryAvailableTextBox";
            this.MemoryAvailableTextBox.Size = new System.Drawing.Size(100, 21);
            this.MemoryAvailableTextBox.TabIndex = 7;
            // 
            // MemoryUsedTextBox
            // 
            this.MemoryUsedTextBox.Location = new System.Drawing.Point(229, 20);
            this.MemoryUsedTextBox.Name = "MemoryUsedTextBox";
            this.MemoryUsedTextBox.Size = new System.Drawing.Size(100, 21);
            this.MemoryUsedTextBox.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(193, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "已用";
            // 
            // MemoryTotalLabel
            // 
            this.MemoryTotalLabel.AutoSize = true;
            this.MemoryTotalLabel.Location = new System.Drawing.Point(13, 23);
            this.MemoryTotalLabel.Name = "MemoryTotalLabel";
            this.MemoryTotalLabel.Size = new System.Drawing.Size(17, 12);
            this.MemoryTotalLabel.TabIndex = 4;
            this.MemoryTotalLabel.Text = "总";
            // 
            // MemoryTotalTextBox
            // 
            this.MemoryTotalTextBox.Location = new System.Drawing.Point(48, 20);
            this.MemoryTotalTextBox.Name = "MemoryTotalTextBox";
            this.MemoryTotalTextBox.Size = new System.Drawing.Size(94, 21);
            this.MemoryTotalTextBox.TabIndex = 3;
            this.MemoryTotalTextBox.TextChanged += new System.EventHandler(this.MemoryUsedTextBox_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CpuIdleLabel);
            this.groupBox1.Controls.Add(this.CpuUsedLabel);
            this.groupBox1.Controls.Add(this.CpuUsedTextBox);
            this.groupBox1.Controls.Add(this.CpuIdleTextBox);
            this.groupBox1.Location = new System.Drawing.Point(7, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(571, 51);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CPU";
            // 
            // CpuIdleLabel
            // 
            this.CpuIdleLabel.AutoSize = true;
            this.CpuIdleLabel.Location = new System.Drawing.Point(194, 23);
            this.CpuIdleLabel.Name = "CpuIdleLabel";
            this.CpuIdleLabel.Size = new System.Drawing.Size(29, 12);
            this.CpuIdleLabel.TabIndex = 6;
            this.CpuIdleLabel.Text = "剩余";
            // 
            // CpuUsedLabel
            // 
            this.CpuUsedLabel.AutoSize = true;
            this.CpuUsedLabel.Location = new System.Drawing.Point(13, 21);
            this.CpuUsedLabel.Name = "CpuUsedLabel";
            this.CpuUsedLabel.Size = new System.Drawing.Size(29, 12);
            this.CpuUsedLabel.TabIndex = 5;
            this.CpuUsedLabel.Text = "已用";
            // 
            // CpuUsedTextBox
            // 
            this.CpuUsedTextBox.Location = new System.Drawing.Point(48, 18);
            this.CpuUsedTextBox.Name = "CpuUsedTextBox";
            this.CpuUsedTextBox.Size = new System.Drawing.Size(94, 21);
            this.CpuUsedTextBox.TabIndex = 1;
            // 
            // CpuIdleTextBox
            // 
            this.CpuIdleTextBox.Location = new System.Drawing.Point(229, 18);
            this.CpuIdleTextBox.Name = "CpuIdleTextBox";
            this.CpuIdleTextBox.Size = new System.Drawing.Size(100, 21);
            this.CpuIdleTextBox.TabIndex = 4;
            // 
            // DiySetTabPage
            // 
            this.DiySetTabPage.Controls.Add(this.SkinSwitchChecked);
            this.DiySetTabPage.Controls.Add(this.DiySetMsgLabel);
            this.DiySetTabPage.Controls.Add(this.ResetButton);
            this.DiySetTabPage.Controls.Add(this.DiySetChangeApply_Button);
            this.DiySetTabPage.Controls.Add(this.FontFamilyComboBox);
            this.DiySetTabPage.Controls.Add(this.FontLabel);
            this.DiySetTabPage.Controls.Add(this.SkinGroupBox);
            this.DiySetTabPage.Location = new System.Drawing.Point(4, 29);
            this.DiySetTabPage.Name = "DiySetTabPage";
            this.DiySetTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.DiySetTabPage.Size = new System.Drawing.Size(591, 432);
            this.DiySetTabPage.TabIndex = 1;
            this.DiySetTabPage.Text = "偏好设置";
            this.DiySetTabPage.UseVisualStyleBackColor = true;
            // 
            // SkinSwitchChecked
            // 
            this.SkinSwitchChecked.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SkinSwitchChecked.AutoSize = true;
            this.SkinSwitchChecked.Location = new System.Drawing.Point(537, 16);
            this.SkinSwitchChecked.Name = "SkinSwitchChecked";
            this.SkinSwitchChecked.Size = new System.Drawing.Size(48, 16);
            this.SkinSwitchChecked.TabIndex = 7;
            this.SkinSwitchChecked.Text = "皮肤";
            this.SkinSwitchChecked.UseVisualStyleBackColor = true;
            // 
            // DiySetMsgLabel
            // 
            this.DiySetMsgLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DiySetMsgLabel.AutoSize = true;
            this.DiySetMsgLabel.Location = new System.Drawing.Point(268, 507);
            this.DiySetMsgLabel.Name = "DiySetMsgLabel";
            this.DiySetMsgLabel.Size = new System.Drawing.Size(0, 12);
            this.DiySetMsgLabel.TabIndex = 5;
            // 
            // ResetButton
            // 
            this.ResetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ResetButton.Location = new System.Drawing.Point(429, 389);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(75, 32);
            this.ResetButton.TabIndex = 3;
            this.ResetButton.Text = "恢复";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // DiySetChangeApply_Button
            // 
            this.DiySetChangeApply_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DiySetChangeApply_Button.Location = new System.Drawing.Point(510, 389);
            this.DiySetChangeApply_Button.Name = "DiySetChangeApply_Button";
            this.DiySetChangeApply_Button.Size = new System.Drawing.Size(75, 32);
            this.DiySetChangeApply_Button.TabIndex = 4;
            this.DiySetChangeApply_Button.Text = "应用";
            this.DiySetChangeApply_Button.UseVisualStyleBackColor = true;
            this.DiySetChangeApply_Button.Click += new System.EventHandler(this.DiySetChangeApply_Button_Click);
            // 
            // FontFamilyComboBox
            // 
            this.FontFamilyComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.FontFamilyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FontFamilyComboBox.FormattingEnabled = true;
            this.FontFamilyComboBox.Location = new System.Drawing.Point(42, 10);
            this.FontFamilyComboBox.Name = "FontFamilyComboBox";
            this.FontFamilyComboBox.Size = new System.Drawing.Size(121, 22);
            this.FontFamilyComboBox.TabIndex = 1;
            this.FontFamilyComboBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.FontFamilyComboBox_DrawItem);
            this.FontFamilyComboBox.SelectedIndexChanged += new System.EventHandler(this.FontFamilyComboBox_SelectedIndexChanged);
            // 
            // FontLabel
            // 
            this.FontLabel.AutoSize = true;
            this.FontLabel.Location = new System.Drawing.Point(6, 15);
            this.FontLabel.Name = "FontLabel";
            this.FontLabel.Size = new System.Drawing.Size(29, 12);
            this.FontLabel.TabIndex = 1;
            this.FontLabel.Text = "字体";
            // 
            // SkinGroupBox
            // 
            this.SkinGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SkinGroupBox.Controls.Add(this.SkinShowPictureBox);
            this.SkinGroupBox.Controls.Add(this.SkinListBox);
            this.SkinGroupBox.Location = new System.Drawing.Point(8, 35);
            this.SkinGroupBox.Name = "SkinGroupBox";
            this.SkinGroupBox.Size = new System.Drawing.Size(577, 348);
            this.SkinGroupBox.TabIndex = 0;
            this.SkinGroupBox.TabStop = false;
            this.SkinGroupBox.Text = "皮肤";
            // 
            // SkinShowPictureBox
            // 
            this.SkinShowPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SkinShowPictureBox.Location = new System.Drawing.Point(182, 20);
            this.SkinShowPictureBox.Name = "SkinShowPictureBox";
            this.SkinShowPictureBox.Size = new System.Drawing.Size(389, 319);
            this.SkinShowPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SkinShowPictureBox.TabIndex = 3;
            this.SkinShowPictureBox.TabStop = false;
            // 
            // SkinListBox
            // 
            this.SkinListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.SkinListBox.FormattingEnabled = true;
            this.SkinListBox.ItemHeight = 12;
            this.SkinListBox.Location = new System.Drawing.Point(6, 20);
            this.SkinListBox.Name = "SkinListBox";
            this.SkinListBox.Size = new System.Drawing.Size(169, 316);
            this.SkinListBox.TabIndex = 2;
            this.SkinListBox.SelectedIndexChanged += new System.EventHandler(this.SkinListBox_SelectedIndexChanged);
            // 
            // ToolTabPage
            // 
            this.ToolTabPage.Controls.Add(this.HttpRequestGroupBox);
            this.ToolTabPage.Location = new System.Drawing.Point(4, 29);
            this.ToolTabPage.Name = "ToolTabPage";
            this.ToolTabPage.Size = new System.Drawing.Size(591, 432);
            this.ToolTabPage.TabIndex = 3;
            this.ToolTabPage.Text = "工具";
            this.ToolTabPage.UseVisualStyleBackColor = true;
            // 
            // HttpRequestGroupBox
            // 
            this.HttpRequestGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HttpRequestGroupBox.Controls.Add(this.SendHistoryButton);
            this.HttpRequestGroupBox.Controls.Add(this.button1);
            this.HttpRequestGroupBox.Controls.Add(this.ResponseLabel);
            this.HttpRequestGroupBox.Controls.Add(this.HttpSendResponseRichTextBox);
            this.HttpRequestGroupBox.Controls.Add(this.HttpSendButton);
            this.HttpRequestGroupBox.Controls.Add(this.TypeLabel);
            this.HttpRequestGroupBox.Controls.Add(this.TypeComboBox);
            this.HttpRequestGroupBox.Controls.Add(this.UrlLabel);
            this.HttpRequestGroupBox.Controls.Add(this.UrlTextBox);
            this.HttpRequestGroupBox.Location = new System.Drawing.Point(4, 4);
            this.HttpRequestGroupBox.Name = "HttpRequestGroupBox";
            this.HttpRequestGroupBox.Size = new System.Drawing.Size(584, 425);
            this.HttpRequestGroupBox.TabIndex = 0;
            this.HttpRequestGroupBox.TabStop = false;
            this.HttpRequestGroupBox.Text = "Http请求";
            // 
            // SendHistoryButton
            // 
            this.SendHistoryButton.Location = new System.Drawing.Point(0, 49);
            this.SendHistoryButton.Name = "SendHistoryButton";
            this.SendHistoryButton.Size = new System.Drawing.Size(49, 23);
            this.SendHistoryButton.TabIndex = 8;
            this.SendHistoryButton.Text = "历史";
            this.SendHistoryButton.UseVisualStyleBackColor = true;
            this.SendHistoryButton.Click += new System.EventHandler(this.SendHistoryButton_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(526, 396);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(52, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "清除";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ResponseLabel
            // 
            this.ResponseLabel.AutoSize = true;
            this.ResponseLabel.Location = new System.Drawing.Point(8, 152);
            this.ResponseLabel.Name = "ResponseLabel";
            this.ResponseLabel.Size = new System.Drawing.Size(35, 12);
            this.ResponseLabel.TabIndex = 6;
            this.ResponseLabel.Text = "反馈:";
            // 
            // HttpSendResponseRichTextBox
            // 
            this.HttpSendResponseRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HttpSendResponseRichTextBox.Location = new System.Drawing.Point(55, 138);
            this.HttpSendResponseRichTextBox.Name = "HttpSendResponseRichTextBox";
            this.HttpSendResponseRichTextBox.ReadOnly = true;
            this.HttpSendResponseRichTextBox.Size = new System.Drawing.Size(523, 252);
            this.HttpSendResponseRichTextBox.TabIndex = 5;
            this.HttpSendResponseRichTextBox.Text = "";
            // 
            // HttpSendButton
            // 
            this.HttpSendButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.HttpSendButton.Location = new System.Drawing.Point(526, 110);
            this.HttpSendButton.Name = "HttpSendButton";
            this.HttpSendButton.Size = new System.Drawing.Size(52, 26);
            this.HttpSendButton.TabIndex = 4;
            this.HttpSendButton.Text = "发送";
            this.HttpSendButton.UseVisualStyleBackColor = true;
            this.HttpSendButton.Click += new System.EventHandler(this.HttpSendButton_Click);
            // 
            // TypeLabel
            // 
            this.TypeLabel.AutoSize = true;
            this.TypeLabel.Location = new System.Drawing.Point(6, 115);
            this.TypeLabel.Name = "TypeLabel";
            this.TypeLabel.Size = new System.Drawing.Size(35, 12);
            this.TypeLabel.TabIndex = 3;
            this.TypeLabel.Text = "方式:";
            // 
            // TypeComboBox
            // 
            this.TypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TypeComboBox.FormattingEnabled = true;
            this.TypeComboBox.Items.AddRange(new object[] {
            "Get",
            "Post"});
            this.TypeComboBox.Location = new System.Drawing.Point(55, 112);
            this.TypeComboBox.Name = "TypeComboBox";
            this.TypeComboBox.Size = new System.Drawing.Size(55, 20);
            this.TypeComboBox.TabIndex = 2;
            // 
            // UrlLabel
            // 
            this.UrlLabel.AutoSize = true;
            this.UrlLabel.Location = new System.Drawing.Point(6, 24);
            this.UrlLabel.Name = "UrlLabel";
            this.UrlLabel.Size = new System.Drawing.Size(29, 12);
            this.UrlLabel.TabIndex = 1;
            this.UrlLabel.Text = "Url:";
            // 
            // UrlTextBox
            // 
            this.UrlTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UrlTextBox.DetectUrls = false;
            this.UrlTextBox.Location = new System.Drawing.Point(55, 21);
            this.UrlTextBox.Name = "UrlTextBox";
            this.UrlTextBox.Size = new System.Drawing.Size(523, 83);
            this.UrlTextBox.TabIndex = 0;
            this.UrlTextBox.Text = "";
            // 
            // HelpTabPage
            // 
            this.HelpTabPage.Controls.Add(this.HelpRichTextBox);
            this.HelpTabPage.Location = new System.Drawing.Point(4, 29);
            this.HelpTabPage.Name = "HelpTabPage";
            this.HelpTabPage.Size = new System.Drawing.Size(591, 432);
            this.HelpTabPage.TabIndex = 2;
            this.HelpTabPage.Text = "帮助";
            this.HelpTabPage.UseVisualStyleBackColor = true;
            // 
            // HelpRichTextBox
            // 
            this.HelpRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HelpRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.HelpRichTextBox.Location = new System.Drawing.Point(3, 2);
            this.HelpRichTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.HelpRichTextBox.Name = "HelpRichTextBox";
            this.HelpRichTextBox.Size = new System.Drawing.Size(585, 423);
            this.HelpRichTextBox.TabIndex = 1;
            this.HelpRichTextBox.Text = "";
            // 
            // LabelTimer
            // 
            this.LabelTimer.Tick += new System.EventHandler(this.LabelTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 489);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(639, 1080);
            this.MinimumSize = new System.Drawing.Size(639, 528);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Java项目管理";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.tabControl1.ResumeLayout(false);
            this.ProjectTagPage.ResumeLayout(false);
            this.ProjectTagPage.PerformLayout();
            this.ProjectGroupBox.ResumeLayout(false);
            this.System_GroupBox.ResumeLayout(false);
            this.System_GroupBox.PerformLayout();
            this.MonitorTabPage.ResumeLayout(false);
            this.MonitorTabPage.PerformLayout();
            this.ServerInfoGroupBox.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.DiySetTabPage.ResumeLayout(false);
            this.DiySetTabPage.PerformLayout();
            this.SkinGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SkinShowPictureBox)).EndInit();
            this.ToolTabPage.ResumeLayout(false);
            this.HttpRequestGroupBox.ResumeLayout(false);
            this.HttpRequestGroupBox.PerformLayout();
            this.HelpTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage DiySetTabPage;
        private System.Windows.Forms.GroupBox SkinGroupBox;
        internal System.Windows.Forms.ListBox SkinListBox;
        private System.Windows.Forms.FolderBrowserDialog JDKPath_FolderBrowserDialog;
        private System.Windows.Forms.Timer LabelTimer;
        private System.Windows.Forms.TabPage HelpTabPage;
        internal System.Windows.Forms.RichTextBox HelpRichTextBox;
        private System.Windows.Forms.Button DiySetChangeApply_Button;
        internal System.Windows.Forms.ComboBox FontFamilyComboBox;
        private System.Windows.Forms.Label FontLabel;
        private System.Windows.Forms.TabPage ProjectTagPage;
        internal System.Windows.Forms.Label OperateMsg_Label;
        internal System.Windows.Forms.CheckBox ExitAfterClose_CheckBox;
        internal System.Windows.Forms.CheckBox LogSwitch_CheckBox;
        private System.Windows.Forms.Label Author_Label;
        private System.Windows.Forms.GroupBox ProjectGroupBox;
        internal System.Windows.Forms.FlowLayoutPanel Projects_Panel;
        internal System.Windows.Forms.Button ProjectAdd_Button;
        internal System.Windows.Forms.Button AllStart_Button;
        internal System.Windows.Forms.Button AllStop_Button;
        internal System.Windows.Forms.Button FreshButton;
        private System.Windows.Forms.GroupBox System_GroupBox;
        private System.Windows.Forms.Label Profile_label;
        private System.Windows.Forms.Label JDKPath_Label;
        internal System.Windows.Forms.TextBox JDKPath_TextBox;
        private System.Windows.Forms.Button JDKPath_Dialog_Button;
        private System.Windows.Forms.Label SystemConfig_SaveLabel;
        private System.Windows.Forms.Button SystemConfig_Save_Button;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.Label DiySetMsgLabel;
        internal System.Windows.Forms.PictureBox SkinShowPictureBox;
        internal System.Windows.Forms.CheckBox SkinSwitchChecked;
        private System.Windows.Forms.Button LogPath_Dialog_Button;
        private System.Windows.Forms.Label LogPathLabel;
        private System.Windows.Forms.FolderBrowserDialog LogPath_FolderBrowserDialog;
        internal System.Windows.Forms.TextBox LogPath_TextBox;
        private System.Windows.Forms.TabPage ToolTabPage;
        private System.Windows.Forms.GroupBox HttpRequestGroupBox;
        private System.Windows.Forms.Button HttpSendButton;
        private System.Windows.Forms.Label TypeLabel;
        internal System.Windows.Forms.ComboBox TypeComboBox;
        private System.Windows.Forms.Label UrlLabel;
        internal System.Windows.Forms.RichTextBox UrlTextBox;
        private System.Windows.Forms.Label ResponseLabel;
        private System.Windows.Forms.RichTextBox HttpSendResponseRichTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button SendHistoryButton;
        internal System.Windows.Forms.TextBox Profile_TextBox;
        private System.Windows.Forms.TabPage MonitorTabPage;
        private System.Windows.Forms.Label MonitorFreqLabel;
        internal System.Windows.Forms.ComboBox MonitorFreqComboBox;
        private System.Windows.Forms.GroupBox ServerInfoGroupBox;
        internal System.Windows.Forms.TextBox MemoryTotalTextBox;
        internal System.Windows.Forms.TextBox CpuUsedTextBox;
        internal System.Windows.Forms.TextBox CpuIdleTextBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label MemoryAvailableLabel;
        internal System.Windows.Forms.TextBox MemoryAvailableTextBox;
        internal System.Windows.Forms.TextBox MemoryUsedTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label MemoryTotalLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label CpuIdleLabel;
        private System.Windows.Forms.Label CpuUsedLabel;
    }
}

