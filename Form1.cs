using PM_plus.bean;
using PM_plus.config;
using PM_plus.service;
using PM_plus.utils;
using Sunisoft.IrisSkin;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PM_plus {
    public partial class Form1 : Form {
        internal SkinEngine se = new SkinEngine();
        public Form1() {
            se.DrawFormIcon = true;
            /// 支持线程操作控件
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            // this.Icon = new Icon("icons/disk.ico");
            se.DisableTag = 9999;
            initData();
        }

        // 是否完成初始化属性，一些checkbox根据此属性进行判断changed,否则初始化就会发生冗余的changed事件
        bool isFinishedInit = false;
        /// <summary>
        /// 初始化相关数据
        /// </summary>
        private void initData() {
            // 主窗体赋值，以便其它地方调用
            Config.mainForm = this;

            isFinishedInit = false;
            // 窗口控件属性相关设置
            FormService.initMainForm(this);
            // 加载框显示，load函数中置主窗体不可用
            FormService.initWaitForm(this);
            // GC回收定时任务初始化
            TimerService.autoGc();
            // 偏好加载,皮肤加载
            FormService.initDiySet();
            int usedProgress = 0;
            // 系统参数加载
            usedProgress = IniConfigService.initSystemConfig(usedProgress, 25);
            // 运行环境参数加载
            usedProgress = IniConfigService.initProjectConfig(usedProgress, 25);
            // 项目面板右键按钮
            usedProgress = FormService.initPanelRightMenu(usedProgress, 25);
            // 创建项目按钮控件
            usedProgress = FormService.initProjectButton(usedProgress, 25);
            TimerService.monitor();
            // 加载窗口关闭,close函数中置主窗体可用
            Config.waitForm.freshProgress(usedProgress);
            Config.waitForm.Close();
            isFinishedInit = true;
        }

        /// <summary>
        /// 添加窗口弹出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void ProjectAdd_Button_Click(object sender, EventArgs e) {
            String profile = ProjectUtils.profile;
            String jdkPath = ProjectUtils.jdkPath;
            if (StringUtils.isEmpty(profile) || StringUtils.isEmpty(jdkPath)) {
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
            if (JDKPath_FolderBrowserDialog.ShowDialog() == DialogResult.OK) {
                JDKPath_TextBox.Text = JDKPath_FolderBrowserDialog.SelectedPath;
            }


            invokeThread = new System.Threading.Thread(new System.Threading.ThreadStart(InvokeMethod));
            invokeThread.SetApartmentState(System.Threading.ApartmentState.STA);
            invokeThread.Start();
            invokeThread.Join();

            if (result == DialogResult.OK) {
                JDKPath_TextBox.Text = JDKPath_FolderBrowserDialog.SelectedPath;
            } 
        }
        private void InvokeMethod() {
            result = JDKPath_FolderBrowserDialog.ShowDialog();
        }

        /// <summary>
        /// 系统参数保存按钮点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SystemConfig_Save_Button_Click(object sender, EventArgs e) {
            long saveProfileResult = saveProfile();
            long saveJDKPathresult = saveJdkPath();

            if (saveProfileResult > 0 && saveJDKPathresult > 0) {
                MessageBox.Show("保存成功！");
            } else {
                MessageBox.Show("保存失败，请联系作者！");
            }

        }
        /// <summary>
        /// 保存运行环境配置项
        /// </summary>
        /// <returns></returns>
        private long saveProfile() {
            String profile = Profile_ComboBox.Text;
            // 放入缓存
            ProjectUtils.profile = profile;
            // 写进配置文件
            long saveProfileResult = IniUtils.IniWriteValue(Config.SystemIniPath, Config.INI_SECTION_SYSTEM, Config.INI_KEY_SYSTEM_PROFILE, profile);
            SystemConfig_SaveLabel.Visible = true;
            initLabelMsgTimerout();
            return saveProfileResult;
        }

        /// <summary>
        /// 保存JDK配置路径
        /// </summary>
        /// <returns></returns>
        private long saveJdkPath() {
            String JDKPath = JDKPath_TextBox.Text;
            // 写入ini配置文件
            long saveJDKPathresult = IniUtils.IniWriteValue(Config.SystemIniPath, Config.INI_SECTION_SYSTEM, Config.INI_KEY_SYSTEM_JDKPATH, JDKPath);
            ProjectUtils.jdkPath = JDKPath;
            if (saveJDKPathresult > 0) {
                // 动态创建按钮控件
                Dictionary<String, ProjectSections.ProjectSection> sectionList = ProjectSections.getAllSectionDic();
                if (null != sectionList) {
                    foreach (KeyValuePair<String, ProjectSections.ProjectSection> projectSectionEntry in sectionList) {
                        // 校验section
                        FormService.checkSection(projectSectionEntry.Value, true);
                    }
                }
            }
            return saveJDKPathresult;
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
            if (isFinishedInit && panelCurrentWidth != width && null != ProjectSections.getAllSections()) {
                // 将所有的按钮尺寸减少滚动条宽度
                foreach (String section in ProjectSections.getAllSections()) {
                    Button btn = (Button)Projects_Panel.Controls[section];
                    btn.Width = Convert.ToInt32(Projects_Panel.ClientSize.Width * 0.98);
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
            Dictionary<String, ProjectSections.ProjectSection> sectionList = ProjectSections.getAllSectionDic();
            if (null != sectionList) {
                foreach (KeyValuePair<String, ProjectSections.ProjectSection> projectSectionEntry in sectionList) {
                    // 校验section
                    FormService.checkSection(projectSectionEntry.Value, true);
                }
            }
            OperateMsg_Label.Text = "刷新成功";
            OperateMsg_Label.ForeColor = Color.Green;
            initLabelMsgTimerout();
        }

        /// <summary>
        /// 全部启动按钮点击事件
        /// 遍历所有项重启
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void AllStart_Button_Click(object sender, EventArgs e) {
            ProjectUtils.allProjectOperate(Config.PROJECT_OPERATE_TYPE_START);
        }

        internal void AllStop_Button_Click(object sender, EventArgs e) {
            ProjectUtils.allProjectOperate(Config.PROJECT_OPERATE_TYPE_STOP);
        }


        private void Profile_ComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            if (isFinishedInit) {
                saveProfile();
            }
        }

        private void JDKPath_TextBox_TextChanged(object sender, EventArgs e) {
            if (isFinishedInit) {
                saveJdkPath();
            }
        }

        private void LabelTimer_Tick(object sender, EventArgs e) {
            SystemConfig_SaveLabel.Visible = false;
            OperateMsg_Label.Text = Config.BLANK_STR;
            DiySetMsgLabel.Text = Config.BLANK_STR;
            LabelTimer.Enabled = false;
        }

        internal void initLabelMsgTimerout() {
            LabelTimer.Enabled = true;
            LabelTimer.Interval = 3000;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            if (Config.exitAfterClose) {
                ProjectUtils.allProjectOperate(Config.PROJECT_OPERATE_TYPE_STOP);
            }
        }

        private void Projects_Panel_DragDrop(object sender, DragEventArgs e) {
            Button btn = (Button)e.Data.GetData(typeof(Button));
            Point p = Projects_Panel.PointToClient(new Point(e.X, e.Y));
            Control control = Projects_Panel.GetChildAtPoint(p);
            int index = Projects_Panel.Controls.GetChildIndex(control, false);
            Projects_Panel.Controls.SetChildIndex(btn, index);
            FormService.freshProjectButtonSort();
        }

        private void Projects_Panel_DragEnter(object sender, DragEventArgs e) {
            e.Effect = DragDropEffects.Move;
        }

        private void SkinListBox_SelectedIndexChanged(object sender, EventArgs e) {
            if (isFinishedInit && SkinListBox.SelectedItem != null) {
                // se.SkinFile = (SkinListBox.SelectedItem as Skin).RelativeName;
                SkinShowPictureBox.Image = Image.FromFile(SkinUtils.getSkinShowPath((SkinListBox.SelectedItem as Skin).RelativeName));
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
            se.SkinFile = (SkinListBox.SelectedItem as Skin).RelativeName;
            IniUtils.IniWriteValue(Config.SystemIniPath, Config.INI_SECTION_SYSTEM, Config.INI_KEY_SYSTEM_SKIN, (SkinListBox.SelectedItem as Skin).RelativeName);
            IniUtils.IniWriteValue(Config.SystemIniPath, Config.INI_SECTION_SYSTEM, Config.INI_KEY_SYSTEM_FONT_FAMILY, FontFamilyComboBox.SelectedItem as String);
            DiySetMsgLabel.Text = "设置成功!";
            DiySetMsgLabel.ForeColor = Color.Green;
            DiySetMsgLabel.Visible = true;
            initLabelMsgTimerout();
        }

        private void FontFamilyComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            if (isFinishedInit && FontFamilyComboBox.SelectedItem != null) {
                foreach (Control con in Config.mainForm.Controls) {
                    ControlUtils.SetControlFont(con, FontFamilyComboBox.SelectedItem as String, true);
                }
            }
        }

        private void ResetButton_Click(object sender, EventArgs e) {
            // 皮肤恢复默认
            se.SkinFile = Config.DEFAULT_SKIN;
            IniUtils.IniWriteValue(Config.SystemIniPath, Config.INI_SECTION_SYSTEM, Config.INI_KEY_SYSTEM_SKIN, Config.DEFAULT_SKIN);
            SkinListBox.SelectedValue = Config.DEFAULT_SKIN;
            // 字体恢复默认
            foreach(Control con in Config.mainForm.Controls) {
                ControlUtils.SetControlFont(con, Config.DEFAULT_FONT_FAMILY, true);
            }
            IniUtils.IniWriteValue(Config.SystemIniPath, Config.INI_SECTION_SYSTEM, Config.INI_KEY_SYSTEM_FONT_FAMILY, Config.DEFAULT_FONT_FAMILY);
            FontFamilyComboBox.SelectedItem = Config.DEFAULT_FONT_FAMILY;

            DiySetMsgLabel.Text = "恢复默认成功！";
            DiySetMsgLabel.ForeColor = Color.Green;
            initLabelMsgTimerout();
        }
    }
}
