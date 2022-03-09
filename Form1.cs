using PM_plus.config;
using PM_plus.service;
using PM_plus.utils;
using Sunisoft.IrisSkin;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace PM_plus {
    public partial class Form1 : Form {
        internal SkinEngine se = new SkinEngine();
        public Form1() {
            /// 支持线程操作控件
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
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
            // 皮肤加载
            FormService.initSkin();
            // 窗口控件属性相关设置
            FormService.initMainForm(this);
            // 加载框显示，load函数中置主窗体不可用
            FormService.initWaitForm(this);
            // GC回收定时任务初始化
            TimerService.autoGc();
            // 系统日志参数加载
            int usedProgress = 0;
            usedProgress = IniConfigService.initSystemConfig(usedProgress, 20);
            // 运行环境参数加载
            usedProgress = IniConfigService.initProjectConfig(usedProgress, 20);
            // 项目面板右键按钮
            usedProgress = FormService.initPanelRightMenu(usedProgress, 30);
            // 创建项目按钮控件
            usedProgress = FormService.initProjectButton(usedProgress, 30);
            TimerService.monitor();
            // 加载窗口关闭,close函数中置主窗体可用
            Config.waitForm.freshProgress(usedProgress);
            System.Threading.Thread.Sleep(200);
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
            AddForm addForm = new AddForm();
            // 先要把主窗口放以弹出窗口中，以便弹出窗口调用主窗口函数
            addForm.ShowDialog();
        }

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

        }

        /// <summary>
        /// 刷新启动文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void Fresh_Button_Click(object sender, EventArgs e) {

        }

        /// <summary>
        /// 全部启动按钮点击事件
        /// 遍历所有项重启
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void AllStart_Button_Click(object sender, EventArgs e) {

        }

        internal void AllStop_Button_Click(object sender, EventArgs e) {

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

        }

        private void Projects_Panel_DragEnter(object sender, DragEventArgs e) {
            e.Effect = DragDropEffects.Move;
        }

        private void SkinListBox_SelectedIndexChanged(object sender, EventArgs e) {
            if (isFinishedInit && SkinListBox.SelectedItem != null) {
                se.SkinFile = (SkinListBox.SelectedItem as FileInfo).FullName;
            }
        }

        private void SkinChangeApply_Button_Click(object sender, EventArgs e) {
            IniUtils.IniWriteValue(Config.SystemIniPath, Config.INI_SECTION_SYSTEM, Config.INI_KEY_SYSTEM_SKIN, (SkinListBox.SelectedItem as FileInfo).FullName);
        }
    }
}
