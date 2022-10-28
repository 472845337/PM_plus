using PM_plus.bean;
using PM_plus.config;
using PM_plus.pojo;
using PM_plus.service;
using PM_plus.utils;
using Sunisoft.IrisSkin;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Management;
using System.Windows.Forms;

namespace PM_plus {
    public partial class Form1 : Form {
        internal SkinEngine se = new SkinEngine();
        internal HttpSendHistoryService hshs = null;
        public Form1() {
            // 皮肤开关配置
            String skinSwithConfig = IniUtils.IniReadValue(Config.SystemIniPath, Config.INI_SECTION_SYSTEM, Config.INI_KEY_SYSTEM_SKIN_SWITCH);
            bool skinSwitch = bool.TrueString.Equals(skinSwithConfig);
            se.Active = skinSwitch;
            se.DrawFormIcon = true;
            /// 支持线程操作控件
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            hshs = new HttpSendHistoryService();
        }

        private void Form1_Load(object sender, EventArgs e) {
            this.Icon = new Icon("icons/disk.ico");
            se.DisableTag = 9999;
            InitData();
        }

        // 是否完成初始化属性，一些checkbox根据此属性进行判断changed,否则初始化就会发生冗余的changed事件
        bool isFinishedInit = false;
        /// <summary>
        /// 初始化相关数据
        /// </summary>
        private void InitData() {
            // 主窗体赋值，以便其它地方调用
            Config.mainForm = this;
            isFinishedInit = false;
            // 加载框显示，load函数中置主窗体不可用
            // 偏好加载,皮肤加载
            FormService.InitDiySet();
            // 窗口控件属性相关设置
            FormService.InitMainForm(this);
            // GC回收定时任务初始化
            TimerService.AutoGc();
            // 系统参数加载
            IniConfigService.InitSystemConfig();
            // 运行环境参数加载
            IniConfigService.InitProjectConfig();
            // 项目面板右键按钮
            FormService.InitPanelRightMenu();
            // 创建项目按钮控件
            FormService.InitProjectButton();
            TimerService.Monitor();
            // 高度设置
            String heightStr = IniUtils.IniReadValue(Config.SystemIniPath, Config.INI_SECTION_SYSTEM, Config.INI_KEY_SYSTEM_FORM_HEIGHT);
            String widthStr = IniUtils.IniReadValue(Config.SystemIniPath, Config.INI_SECTION_SYSTEM, Config.INI_KEY_SYSTEM_FORM_WIDTH);
            if (StringUtils.IsNotEmpty(heightStr)) {
                int height = Int32.Parse(heightStr);
                this.Size = new Size(this.Size.Width, height);
            }
            // 宽度设置
            if (StringUtils.IsNotEmpty(widthStr)) {
                int width = Int32.Parse(widthStr);
                this.Size = new Size(width, this.Size.Height);
            }
            // 工具面板中设置
            TypeComboBox.Text = TypeComboBox.Items[0].ToString();
            isFinishedInit = true;
            TimerService.MonitorServer();
            TimerService.MonitorProcess();
        }

        /// <summary>
        /// 添加窗口弹出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void ProjectAdd_Button_Click(object sender, EventArgs e) {
            String profile = ProjectUtils.profile;
            String jdkPath = ProjectUtils.jdkPath;
            if (StringUtils.IsEmpty(profile) || StringUtils.IsEmpty(jdkPath)) {
                MessageBox.Show("运行环境和JDK路径需配置并保存！");
                return;
            }
            ProjectForm addForm = new ProjectForm(Config.OPERATE_TYPE_ADD);
            // 先要把主窗口放以弹出窗口中，以便弹出窗口调用主窗口函数
            addForm.ShowDialog();
        }


        private System.Threading.Thread invokeThread;
        private DialogResult result;
        /// <summary>
        /// 选择JDK路径的文件夹选择框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void JDKPath_Dialog_Button_Click(object sender, EventArgs e) {
            JDKPath_FolderBrowserDialog.SelectedPath = JDKPath_TextBox.Text;
            JDKPath_FolderBrowserDialog.ShowNewFolderButton = false;
           /* if (JDKPath_FolderBrowserDialog.ShowDialog() == DialogResult.OK) {
                JDKPath_TextBox.Text = JDKPath_FolderBrowserDialog.SelectedPath;
            }*/


            invokeThread = new System.Threading.Thread(new System.Threading.ThreadStart(InvokeMethodJDKPath));
            invokeThread.SetApartmentState(System.Threading.ApartmentState.STA);
            invokeThread.Start();
            invokeThread.Join();

            if (result == DialogResult.OK) {
                JDKPath_TextBox.Text = JDKPath_FolderBrowserDialog.SelectedPath;
            }
        }
        private void InvokeMethodJDKPath() {
            result = JDKPath_FolderBrowserDialog.ShowDialog();
        }
        /// <summary>
        /// 选择日志路径的文件夹选择框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LogPath_Dialog_Button_Click(object sender, EventArgs e) {
            LogPath_FolderBrowserDialog.SelectedPath = LogPath_TextBox.Text;
            LogPath_FolderBrowserDialog.ShowNewFolderButton = false;
            /* if (LogPath_FolderBrowserDialog.ShowDialog() == DialogResult.OK) {
                 LogPath_TextBox.Text = LogPath_FolderBrowserDialog.SelectedPath;
             }*/


            invokeThread = new System.Threading.Thread(new System.Threading.ThreadStart(InvokeMethodLogPath));
            invokeThread.SetApartmentState(System.Threading.ApartmentState.STA);
            invokeThread.Start();
            invokeThread.Join();

            if (result == DialogResult.OK) {
                LogPath_TextBox.Text = LogPath_FolderBrowserDialog.SelectedPath;
            }
        }
        private void InvokeMethodLogPath() {
            result = LogPath_FolderBrowserDialog.ShowDialog();
        }

        /// <summary>
        /// 系统参数保存按钮点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SystemConfig_Save_Button_Click(object sender, EventArgs e) {
            long saveProfileResult = SaveProfile();
            long saveJDKPathresult = SaveJdkPath();
            long saveLogPathResult = SaveLogPath();

            if (saveProfileResult > 0 && saveJDKPathresult > 0 && saveLogPathResult > 0) {
                TimerService.showOperateLabelMessage("保存成功!", Color.DarkGreen);
            } else {
                MessageBox.Show("保存失败，请联系作者！","警告");
            }

        }
        /// <summary>
        /// 保存运行环境配置项
        /// </summary>
        /// <returns></returns>
        private long SaveProfile() {
            String profile = Profile_TextBox.Text;
            // 放入缓存
            ProjectUtils.profile = profile;
            // 写进配置文件
            return IniUtils.IniWriteValue(Config.SystemIniPath, Config.INI_SECTION_SYSTEM, Config.INI_KEY_SYSTEM_PROFILE, profile);
        }

        /// <summary>
        /// 保存JDK配置路径
        /// </summary>
        /// <returns></returns>
        private long SaveJdkPath() {
            String JDKPath = JDKPath_TextBox.Text;
            // 写入ini配置文件
            long saveJDKPathresult = IniUtils.IniWriteValue(Config.SystemIniPath, Config.INI_SECTION_SYSTEM, Config.INI_KEY_SYSTEM_JDKPATH, JDKPath);
            ProjectUtils.jdkPath = JDKPath;
            if (saveJDKPathresult > 0) {
                // 动态创建按钮控件
                Dictionary<String, ProjectSections.ProjectSection> sectionList = ProjectSections.GetAllSectionDic();
                if (null != sectionList) {
                    foreach (KeyValuePair<String, ProjectSections.ProjectSection> projectSectionEntry in sectionList) {
                        // 校验section
                        FormService.CheckSection(projectSectionEntry.Value, true);
                    }
                }
            }
            return saveJDKPathresult;
        }

        /// <summary>
        /// 保存JDK配置路径
        /// </summary>
        /// <returns></returns>
        private long SaveLogPath() {
            String logPath = LogPath_TextBox.Text;
            // 写入ini配置文件
            long saveLogPathresult = IniUtils.IniWriteValue(Config.SystemIniPath, Config.INI_SECTION_SYSTEM, Config.INI_KEY_SYSTEM_LOGPATH, logPath);
            ProjectUtils.logPath = logPath;
            if (saveLogPathresult > 0) {
                // 动态创建按钮控件
                Dictionary<String, ProjectSections.ProjectSection> sectionList = ProjectSections.GetAllSectionDic();
                if (null != sectionList) {
                    foreach (KeyValuePair<String, ProjectSections.ProjectSection> projectSectionEntry in sectionList) {
                        // 校验section
                        FormService.CheckSection(projectSectionEntry.Value, true);
                    }
                }
            }
            return saveLogPathresult;
        }

        internal static int panelCurrentWidth;
        /// <summary>
        /// 判断滚动条是否出现，当项目面板的尺寸变化的时候，引起的宽度变化
        /// （滚动条出现会占用宽度 ，项目面板的宽度会减少对应的宽度）
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Projects_Panel_ClientSizeChanged(object sender, EventArgs e) {
            int width = Projects_Panel.ClientSize.Width;
            if (isFinishedInit && panelCurrentWidth != width && null != ProjectSections.GetAllSections()) {
                // 将所有的按钮尺寸减少滚动条宽度
                foreach (String section in ProjectSections.GetAllSections()) {
                    Button btn = (Button)Projects_Panel.Controls[section];
                    if (null != btn) {
                        btn.Width = Convert.ToInt32(Projects_Panel.ClientSize.Width * 0.98);
                    }
                }
                panelCurrentWidth = width;
            }
        }

        private void LogSwitch_CheckBox_CheckedChanged(object sender, EventArgs e) {
            if (isFinishedInit) {
                bool logSwitch = LogSwitch_CheckBox.Checked;
                Config.logSwitch = logSwitch;
                IniUtils.IniWriteValue(Config.SystemIniPath, Config.INI_SECTION_LOG, Config.INI_KEY_LOG_SWITCH, logSwitch.ToString());
            }
        }
        private void ExitAfterClose_CheckBox_CheckedChanged(object sender, EventArgs e) {
            if (isFinishedInit) {
                bool exitAfterClose = ExitAfterClose_CheckBox.Checked;
                Config.exitAfterClose = exitAfterClose;
                IniUtils.IniWriteValue(Config.SystemIniPath, Config.INI_SECTION_SYSTEM, Config.INI_KEY_SYSTEM_EXITAFTERCLOSE, exitAfterClose.ToString());
            }
        }
        /// <summary>
        /// 刷新启动文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void Fresh_Button_Click(object sender, EventArgs e) {
            if(MessageBox.Show("确认刷新所有启动脚本吗？", "信息",MessageBoxButtons.YesNo) == DialogResult.Yes) {
                Dictionary<String, ProjectSections.ProjectSection> sectionList = ProjectSections.GetAllSectionDic();
                if (null != sectionList) {
                    foreach (KeyValuePair<String, ProjectSections.ProjectSection> projectSectionEntry in sectionList) {
                        // 校验section
                        FormService.CheckSection(projectSectionEntry.Value, true);
                    }
                }
                OperateMsg_Label.Text = "刷新成功";
                OperateMsg_Label.ForeColor = Color.Green;
                InitLabelMsgTimerout();
            }
        }

        /// <summary>
        /// 全部启动按钮点击事件
        /// 遍历所有项重启
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void AllStart_Button_Click(object sender, EventArgs e) {
            ProjectUtils.AllProjectOperate(Config.PROJECT_OPERATE_TYPE_START);
        }

        /// <summary>
        /// 全部停止
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void AllStop_Button_Click(object sender, EventArgs e) {
            // 执行全部停止
            ProjectUtils.AllProjectOperate(Config.PROJECT_OPERATE_TYPE_STOP);
        }

        private void LabelTimer_Tick(object sender, EventArgs e) {
            Config.mainForm.OperateMessageLabel.Text = "";
            LabelTimer.Enabled = false;
        }

        internal void InitLabelMsgTimerout() {
            LabelTimer.Enabled = true;
            LabelTimer.Interval = 3000;
        }

        internal void InitLabelMsgTimerout(int second) {
            LabelTimer.Enabled = true;
            LabelTimer.Interval = second * 1000;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            if (Config.exitAfterClose) {
                ProjectUtils.AllProjectOperate(Config.PROJECT_OPERATE_TYPE_STOP);
            }
            // 关闭所有SQLite连接
            data.SQLiteFactory.CloseAllSQLite();
            // 所有定时器资源回收
            TimerService.DisposeAllTimer();
        }

        private void Projects_Panel_DragDrop(object sender, DragEventArgs e) {
            Button btn = (Button)e.Data.GetData(typeof(Button));
            Point p = Projects_Panel.PointToClient(new Point(e.X, e.Y));
            Control control = Projects_Panel.GetChildAtPoint(p);
            int index = Projects_Panel.Controls.GetChildIndex(control, false);
            Projects_Panel.Controls.SetChildIndex(btn, index);
            FormService.FreshProjectButtonSort();
        }

        private void Projects_Panel_DragEnter(object sender, DragEventArgs e) {
            e.Effect = DragDropEffects.Move;
        }

        private void SkinListBox_SelectedIndexChanged(object sender, EventArgs e) {
            if (isFinishedInit && SkinListBox.SelectedItem != null) {
                // se.SkinFile = (SkinListBox.SelectedItem as Skin).RelativeName;
                SkinShowPictureBox.Image = Image.FromFile(SkinUtils.GetSkinShowPath((SkinListBox.SelectedItem as Skin).RelativeName));
            }
        }
        private void FontFamilyComboBox_DrawItem(object sender, DrawItemEventArgs e) {
            e.DrawBackground();
            ComboBox cmb = (ComboBox)sender;
            string txt = e.Index > -1 ? cmb.Items[e.Index].ToString() : cmb.Text;
            Font f = new Font(txt, cmb.Font.Size);
            //使用格式刷
            Brush b = new SolidBrush(e.ForeColor);
            //字符串描绘
            float ym = (e.Bounds.Height - e.Graphics.MeasureString(txt, f).Height) / 2;
            e.Graphics.DrawString(txt, f, b, e.Bounds.X, e.Bounds.Y + ym);
            f.Dispose();
            b.Dispose();
            //描绘四角表示焦点的形状
            e.DrawFocusRectangle();
        }
        private void DiySetChangeApply_Button_Click(object sender, EventArgs e) {
            se.Active = SkinSwitchChecked.Checked;
            se.SkinFile = (SkinListBox.SelectedItem as Skin).RelativeName;
            IniUtils.IniWriteValue(Config.SystemIniPath, Config.INI_SECTION_SYSTEM, Config.INI_KEY_SYSTEM_SKIN, (SkinListBox.SelectedItem as Skin).RelativeName);
            IniUtils.IniWriteValue(Config.SystemIniPath, Config.INI_SECTION_SYSTEM, Config.INI_KEY_SYSTEM_SKIN_SWITCH, SkinSwitchChecked.Checked.ToString());
            IniUtils.IniWriteValue(Config.SystemIniPath, Config.INI_SECTION_SYSTEM, Config.INI_KEY_SYSTEM_FONT_FAMILY, FontFamilyComboBox.SelectedItem as String);
            IniUtils.IniWriteValue(Config.SystemIniPath, Config.INI_SECTION_SYSTEM, Config.INI_KEY_SYSTEM_FONT_SIZE, FontSizeComboBox.SelectedItem as String);
            IniUtils.IniWriteValue(Config.SystemIniPath, Config.INI_SECTION_SYSTEM, Config.INI_KEY_SYSTEM_FONT_COLOR, ColorTranslator.ToHtml(FontColorTextBox.BackColor));
            DiySetMsgLabel.Text = "设置成功!";
            DiySetMsgLabel.ForeColor = Color.Green;
            DiySetMsgLabel.Visible = true;
            InitLabelMsgTimerout();
        }

        private void FontFamilyComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            if (isFinishedInit && FontFamilyComboBox.SelectedItem != null) {
                FormService.ChangeProjectButtonFont();
            }
        }

        private void ResetButton_Click(object sender, EventArgs e) {
            // 皮肤恢复默认
            se.SkinFile = Config.DEFAULT_SKIN;
            IniUtils.IniWriteValue(Config.SystemIniPath, Config.INI_SECTION_SYSTEM, Config.INI_KEY_SYSTEM_SKIN, Config.DEFAULT_SKIN);
            SkinListBox.SelectedValue = Config.DEFAULT_SKIN;
            // 字体恢复默认
            foreach (Control con in Config.mainForm.Projects_Panel.Controls) {
                ControlUtils.SetControlFont(con, Config.DEFAULT_FONT_FAMILY, Config.DEFAULT_FONT_SIZE, ColorTranslator.FromHtml(Config.DEFAULT_FONT_COLOR), true);
            }
            IniUtils.IniWriteValue(Config.SystemIniPath, Config.INI_SECTION_SYSTEM, Config.INI_KEY_SYSTEM_FONT_FAMILY, Config.DEFAULT_FONT_FAMILY);
            FontFamilyComboBox.SelectedItem = Config.DEFAULT_FONT_FAMILY;
            FontSizeComboBox.SelectedItem = Config.DEFAULT_FONT_SIZE.ToString();
            FontColorTextBox.BackColor = ColorTranslator.FromHtml(Config.DEFAULT_FONT_COLOR);

            DiySetMsgLabel.Text = "恢复默认成功！";
            DiySetMsgLabel.ForeColor = Color.Green;
            InitLabelMsgTimerout();
        }

        /// <summary>
        /// 窗口尺寸变化保存尺寸
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_ResizeEnd(object sender, EventArgs e) {
            int height = this.Size.Height;
            int width = this.Size.Width;
            IniUtils.IniWriteValue(Config.SystemIniPath, Config.INI_SECTION_SYSTEM, Config.INI_KEY_SYSTEM_FORM_HEIGHT, height.ToString());
            IniUtils.IniWriteValue(Config.SystemIniPath, Config.INI_SECTION_SYSTEM, Config.INI_KEY_SYSTEM_FORM_WIDTH, width.ToString());
        }

        /// <summary>
        /// 发送Http请求
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HttpSendButton_Click(object sender, EventArgs e) {
            HttpSendButton.Enabled = false;

            String httpUrl = UrlTextBox.Text;
            String httpType = TypeComboBox.Text;
            if (StringUtils.IsEmpty(httpUrl)) {
                MessageBox.Show("未填写URL;");
                goto end;
            }else {
                if (!httpUrl.ToLower().StartsWith("http")) {
                    httpUrl = "http://" + httpUrl;
                }
            }
            if (StringUtils.IsEmpty(httpType)) {
                MessageBox.Show("未选择请求类型;");
                goto end;
            }
            // 当前数据写进文件中
            HttpSendHistory hsh = new HttpSendHistory {
                Url = httpUrl,
                Type = httpType
            };
            hshs.SaveData(hsh);
            String result;
            if (Config.HTTP_TYPE_POST.Equals(httpType)) {
                result = HttpUtils.PostRequest(httpUrl, "", null);
            }else if(Config.HTTP_TYPE_GET.Equals(httpType)) {
                result = HttpUtils.GetRequest(httpUrl, null);
            }else {
                MessageBox.Show("非法请求类型;");
                goto end;
            }
            HttpSendResponseRichTextBox.Text = result;

            end:
                HttpSendButton.Enabled = true;
            

        }
        /// <summary>
        /// 清除http请求反馈中文件框内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HttpResponseClearButton_Click(object sender, EventArgs e) {
            HttpSendResponseRichTextBox.Text = "";
        }

        private void SendHistoryButton_Click(object sender, EventArgs e) {
            if (false == Config.historyFormShow) {
                SendHistoryForm sendHistoryForm = new SendHistoryForm();
                sendHistoryForm.Show();
                Config.historyFormShow = true;
            }
        }

        private void MonitorFreqComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            int monitorFrequenceInterval = Convert.ToInt32(MonitorFreqComboBox.Text);
            Config.monitorServerInterval = monitorFrequenceInterval;
            // 写入配置
            IniUtils.IniWriteValue(Config.SystemIniPath, Config.INI_SECTION_MONITOR, Config.INI_KEY_MONITOR_SERVER_FREQUENCE, monitorFrequenceInterval.ToString());
            if (monitorFrequenceInterval > 0) {
                TimerService.ServerInfoTimer.Enabled = true;
                TimerService.ServerInfoTimer.Interval = monitorFrequenceInterval * 1000;
            } else {
                TimerService.ServerInfoTimer.Enabled = false;
                // 清空监控中所有数据
                CpuUsedTextBox.Text = "";
                CpuIdleTextBox.Text = "";
                MemoryTotalTextBox.Text = "";
                MemoryAvailableTextBox.Text = "";
                MemoryUsedTextBox.Text = "";
                NetWorkDownloadTextBox.Text = "";
                NetWorkUploadTextBox.Text = "";
            }
        }
        /// <summary>
        /// 进程项被选择后，根据是否激活窗口进行置顶当前所选的进程对应的窗口
        /// 展示该进程的详细信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProcessListBox_SelectedIndexChanged(object sender, EventArgs e) {
            if (ProcessListBox.Items.Count > 0 && ProcessListBox.SelectedIndex > -1) {
                Process selectProcess = (ProcessListBox.SelectedItem as Process);
                Process javaParentProcess = selectProcess.ProcessName.Equals("java")?selectProcess.Parent():null;
                // 展示相关信息
                ProcessIdTextBox.Text = selectProcess.Id.ToString();
                ProcessTitleTextBox.Text = null == javaParentProcess? selectProcess.MainWindowTitle: javaParentProcess.MainWindowTitle;
                // 展示内存占用和子进程
                ShowMemAndChildProcess(selectProcess);

                if (ClickActiveCmdCheckBox.Checked) {
                    if (selectProcess.ProcessName.Equals("java")) {
                        // 并将父窗口置顶
                        User32Dll.SwitchToThisWindow(selectProcess.Parent().MainWindowHandle, true);
                    } else {
                        // 并将当前窗口置顶
                        User32Dll.SwitchToThisWindow(selectProcess.MainWindowHandle, true);
                    }
                }

            } else {
                ClearProcessInfo();
            }
        }

        private void ShowMemAndChildProcess(Process p) {
            // 内存占用量，需要将子进程也进行统计
            float mem = 0.0F;
            ChildProcessListBox.Items.Clear();
            int pid = p.ProcessName == "java"? p.Parent().Id: p.Id;
            // 当前进程的所有子进程
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("Select * From Win32_Process Where ParentProcessID=" + pid);
            ManagementObjectCollection moc = searcher.Get();
            foreach (ManagementObject mo in moc) {
                int childPID = Convert.ToInt32(mo["ProcessID"]);
                Process childProcess = Process.GetProcessById(childPID);
                mem += childProcess.WorkingSet64;
                string childProcessInfo = childProcess.Id + "\t" + childProcess.ProcessName + "\t" + StringUtils.FormatSize(childProcess.WorkingSet64);
                ChildProcessListBox.Items.Add(childProcessInfo);
            }
            ProcessMemTextBox.Text = StringUtils.FormatSize(mem + p.WorkingSet64);
        }

        private void ClearProcessInfo() {
            ProcessIdTextBox.Text = "";
            ProcessTitleTextBox.Text = "";
            ProcessMemTextBox.Text = "";
            ChildProcessListBox.Items.Clear();
        }

        private void ClickActiveCmdCheckBox_CheckedChanged(object sender, EventArgs e) {
            IniUtils.IniWriteValue(Config.SystemIniPath, Config.INI_SECTION_SYSTEM, Config.INI_KEY_SYSTEM_CLICK_ACTIVE, ClickActiveCmdCheckBox.Checked.ToString()); ;
        }

        private void FreshProcessButton_Click(object sender, EventArgs e) {
            // 重新获取进程
            TimerService.MonitorProcess();
            // 清空进程详细显示
            ClearProcessInfo();
        }

        /// <summary>
        /// 所有进程对应的窗口最小化到任务栏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProcessWindowMinButton_Click(object sender, EventArgs e) {
            if (ProcessListBox.Items.Count > 0) {
                foreach (Process process in ProcessListBox.Items) {
                    User32Dll.ShowWindow(process.MainWindowHandle, User32Dll.SHOW_WINDOW_MIN);
                }
            }
        }

        private void FontSizeComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            if (isFinishedInit && FontSizeComboBox.SelectedItem != null) {
                FormService.ChangeProjectButtonFont();
            }
        }

        private void FontColorTextBox_Click(object sender, EventArgs e) {
            if (FontColorDialog.ShowDialog() == DialogResult.OK) {
                FontColorTextBox.BackColor = FontColorDialog.Color;
                FormService.ChangeProjectButtonFont();
            }
        }
    }
}
