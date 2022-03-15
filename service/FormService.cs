using PM_plus;
using PM_plus.bean;
using PM_plus.config;
using PM_plus.utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using static System.Windows.Forms.Control;

namespace PM_plus.service {
    class FormService {

        /// <summary>
        /// 初始化主窗体
        /// 将主窗体放到缓存当中供，其它窗口使用
        /// </summary>
        /// <param name="form"></param>
        public static void initMainForm(Form1 form) {
            // 设置项目面板水平滚动条不可用
            form.Projects_Panel.HorizontalScroll.Maximum = 0;
            form.Projects_Panel.AutoScroll = false;
            form.Projects_Panel.VerticalScroll.Visible = false;
            form.Projects_Panel.AutoScroll = true;
            // 赋值项目面板初始宽度参数
            Form1.panelCurrentWidth = form.Projects_Panel.ClientSize.Width;
            // 按钮置顶(添加，全部开启，全部停止)
            form.ProjectAdd_Button.BringToFront();
            form.AllStart_Button.BringToFront();
            form.AllStop_Button.BringToFront();
            //帮助页面加载
            form.HelpRichTextBox.ReadOnly = true;
            form.HelpRichTextBox.LoadFile("help.rtf", RichTextBoxStreamType.RichText);
        }

        /// <summary>
        /// 初始化显示加载窗口
        /// </summary>
        /// <param name="mainForm"></param>
        public static void initWaitForm(Form1 mainForm) {
            WaitForm waitForm = new WaitForm();
            waitForm.Show();
            waitForm.Update();
            Config.waitForm = waitForm;
        }
        internal static void initFont() {
            InstalledFontCollection installedFontCollection = new InstalledFontCollection();
            foreach(FontFamily fontFamily in installedFontCollection.Families) {
                if (fontFamily.IsStyleAvailable(FontStyle.Regular)) {
                    Config.mainForm.FontFamilyComboBox.Items.Add(fontFamily.Name);
                }
            }
           // 字体配置读取
           String fontFamilyName = IniUtils.IniReadValue(Config.SystemIniPath, Config.INI_SECTION_SYSTEM, Config.INI_KEY_SYSTEM_FONT_FAMILY);
            if (StringUtils.isEmpty(fontFamilyName)) {
                // 未设置，使用默认
                fontFamilyName = Config.DEFAULT_FONT_FAMILY;
                IniUtils.IniWriteValue(Config.SystemIniPath, Config.INI_SECTION_SYSTEM, Config.INI_KEY_SYSTEM_FONT_FAMILY, Config.DEFAULT_FONT_FAMILY);
            }
            // 控件字体设置
            foreach (Control child in Config.mainForm.Controls) {
                ControlUtils.SetControlFont(child, fontFamilyName, true);
            }
            // 字体项选择
            Config.mainForm.FontFamilyComboBox.SelectedItem = fontFamilyName;
        }


        internal static void initSkin() {
            FileInfo[] skinFileArray = new DirectoryInfo("Skins").GetFiles("*.ssk", SearchOption.AllDirectories);
            List<Skin> skinList = new List<Skin>();
            foreach(FileInfo fileInfo in skinFileArray) {
                Skin skin = new Skin();
                skin.Name = fileInfo.Name;
                skin.FullName = fileInfo.FullName;
                skin.RelativeName = fileInfo.FullName.Replace(Config.AppPath, "");
                skinList.Add(skin);
            }
            Config.mainForm.SkinListBox.DataSource = skinList;
            // 皮肤展示名
            Config.mainForm.SkinListBox.DisplayMember = "Name";
            // 用于展示选中项通过value进行比较
            Config.mainForm.SkinListBox.ValueMember = "RelativeName";
            // 获取皮肤配置
            String skinFile = IniUtils.IniReadValue(Config.SystemIniPath, Config.INI_SECTION_SYSTEM, Config.INI_KEY_SYSTEM_SKIN);
            if (StringUtils.isEmpty(skinFile)) {
                // 默认的皮肤
                skinFile = Config.DEFAULT_SKIN;
                IniUtils.IniWriteValue(Config.SystemIniPath, Config.INI_SECTION_SYSTEM, Config.INI_KEY_SYSTEM_SKIN, Config.DEFAULT_SKIN);
            }
            Config.mainForm.se.SkinFile = skinFile;
            Config.mainForm.SkinListBox.SelectedValue = skinFile;
            Config.mainForm.SkinShowPictureBox.Image = Image.FromFile(SkinUtils.getSkinShowPath(skinFile));
        }
        /// <summary>
        ///  初始化偏好设置
        /// </summary>
        internal static void initDiySet() {
            // 字体初始化
            initFont();
            // 皮肤初始化
            initSkin();
        }

        public static int initPanelRightMenu(int usedProgress, int giveProgress) {

            /* 启动程序按钮 */
            ContextMenuStrip rightMenu = new ContextMenuStrip();
            /* 添加按钮-------------------------------- */
            ControlUtils.AddToolStripMenu(rightMenu, Config.BLANK_STR, Config.PROJECT_PANEL_RIGHT_ADD_NAME, Config.PROJECT_PANEL_RIGHT_ADD_TEXT, new EventHandler(Config.mainForm.ProjectAdd_Button_Click));
            /** 启动按钮 -------------------------------*/
            ControlUtils.AddToolStripMenu(rightMenu, Config.BLANK_STR, Config.PROJECT_PANEL_RIGHT_ALLSTART_NAME, Config.PROJECT_PANEL_RIGHT_ALLSTART_TEXT, new EventHandler(Config.mainForm.AllStart_Button_Click));
            /* 停止按钮-------------------------------- */
            ControlUtils.AddToolStripMenu(rightMenu, Config.BLANK_STR, Config.PROJECT_PANEL_RIGHT_ALLSTOP_NAME, Config.PROJECT_PANEL_RIGHT_ALLSTOP_TEXT, new EventHandler(Config.mainForm.AllStop_Button_Click));
            /* 刷新按钮-------------------------------- */
            ControlUtils.AddToolStripMenu(rightMenu, Config.BLANK_STR, Config.PROJECT_PANEL_RIGHT_FRESH_NAME, Config.PROJECT_PANEL_RIGHT_FRESH_TEXT, new EventHandler(Config.mainForm.Fresh_Button_Click));
            /* 装载右键 */
            Config.mainForm.Projects_Panel.ContextMenuStrip = rightMenu;
            return usedProgress + giveProgress;
        }

        public static int initProjectButton(int usedProgress, int giveProgress) {
            List<String> sectionList = IniUtils.ReadSections(Config.ProjectsIniPath);
            Config.waitForm.freshProgress(usedProgress + 5);
            for (int i = 0; i < sectionList.Count; i++) {
                String section = sectionList[i];
                // 标题
                String buttonText = IniUtils.IniReadValue(Config.ProjectsIniPath, section, Config.INI_KEY_PROJECT_TITLE);
                // jar包路径
                String jar = IniUtils.IniReadValue(Config.ProjectsIniPath, section, Config.INI_KEY_PROJECT_JAR);
                // 端口
                String port = IniUtils.IniReadValue(Config.ProjectsIniPath, section, Config.INI_KEY_PROJECT_PORT);
                // 是否在控制台打印日志
                String isPrintLog = IniUtils.IniReadValue(Config.ProjectsIniPath, section, Config.INI_KEY_PROJECT_PRINT_LOG);
                bool isPrintLogBl = Config.IS_PRINT_LOG_YES.Equals(isPrintLog) ? true : false;
                // 心跳地址
                String heartBeat = IniUtils.IniReadValue(Config.ProjectsIniPath, section, Config.INI_KEY_PROJECT_HEART_BEAT);
                // 监控地址
                String actuator = IniUtils.IniReadValue(Config.ProjectsIniPath, section, Config.INI_KEY_PROJECT_ACTUATOR);
                // 启动参数
                String param = IniUtils.IniReadValue(Config.ProjectsIniPath, section, Config.INI_KEY_PROJECT_PARAM);
                // 创建按钮
                ProjectSections.ProjectSection projectSection = new ProjectSections.ProjectSection();
                projectSection.section = section;
                projectSection.title = buttonText;
                projectSection.jar = jar;
                projectSection.port = port;
                projectSection.isPrintLog = isPrintLogBl;
                projectSection.heartBeat = heartBeat;
                projectSection.actuator = actuator;
                projectSection.param = param;
                addButton(projectSection);

                // 初始化为未运行
                projectSection.runStat = Config.PROJECT_RUN_STAT_UNRUN;
                projectSection.isRunning = false;
                ProjectSections.updateProjectSection(section, projectSection);
                // 校验section
                FormService.checkSection(projectSection, false);
                Config.waitForm.freshProgress(usedProgress + ((giveProgress - 5) / sectionList.Count) * (i + 1));
            }
            return usedProgress + giveProgress;
        }

        public static void freshProjectButtonSort() {
            ControlCollection controls = Config.mainForm.Projects_Panel.Controls;
            foreach (Control con in controls) {
                int index = controls.GetChildIndex(con, false);
                IniUtils.IniWriteValue(Config.ProjectsIniPath, con.Name, Config.INI_KEY_PROJECT_SORT, Convert.ToString(index));
            }
        }

        /// <summary>
        /// 项目运行窗口初始化
        /// </summary>
        /// <param name="projectRunTabControl"></param>
        /// <param name="usedProgress"></param>
        /// <param name="giveProgress"></param>
        /// <returns></returns>
        public static int initProjectTab(TabControl projectRunTabControl, int usedProgress, int giveProgress) {
            List<String> sectionList = IniUtils.ReadSections(Config.ProjectsIniPath);
            // 先移除首页外的所有
            foreach (TabPage tabPage in projectRunTabControl.TabPages) {
                if (!"HomeTabPage".Equals(tabPage.Name)) {
                    projectRunTabControl.TabPages.Remove(tabPage);
                }
            }
            Config.waitForm.freshProgress(usedProgress + 5);
            Thread.Sleep(100);
            int surplusProgress = giveProgress - 10;
            for (int i = 0; i < sectionList.Count; i++) {
                String section = sectionList[i];
                // 添加项目运行窗口的所有控件
                ControlUtils.addTabPage2TabControl(projectRunTabControl, section);
                // 
                Config.waitForm.freshProgress(usedProgress + (surplusProgress / sectionList.Count) * (i + 1));
                Thread.Sleep(100);
            }
            return usedProgress + giveProgress;
        }
        /// <summary>
        /// 调整项目按钮上的右键菜单可用性
        /// </summary>
        /// <param name="section">当前按钮编码</param>
        /// <param name="isRunning">当前项目是否运行</param>
        internal static void updateButtonEnabledOfMenuStrip(String section, short runStat) {
            Color backColor = Color.LightGray;
            bool startEnabled = false;
            bool stopEnabled = false;
            bool updateEnabled = false;
            if (Config.PROJECT_RUN_STAT_RUNNING == runStat || Config.PROJECT_RUN_STAT_STOPPING == runStat) {
                // 运行或停止中，黄绿色按钮，所有按钮不可用
                backColor = Color.YellowGreen;
                startEnabled = false;
                stopEnabled = false;
                updateEnabled = false;
            } else if (Config.PROJECT_RUN_STAT_SUCCESS == runStat) {
                // 启动成功 按钮绿色，只可停止操作
                backColor = Color.LightGreen;
                startEnabled = false;
                stopEnabled = true;
                updateEnabled = false;
            } else if (Config.PROJECT_RUN_STAT_FAIL == runStat || Config.PROJECT_RUN_STAT_UNRUN == runStat) {

                if (Config.PROJECT_RUN_STAT_FAIL == runStat) {
                    // 启动失败
                    backColor = Color.OrangeRed;
                } else if (Config.PROJECT_RUN_STAT_UNRUN == runStat) {
                    backColor = Color.LightGray;
                }
                // 可启动和编辑
                startEnabled = true;
                stopEnabled = false;
                updateEnabled = true;
            }
            Button btn = (Button)Config.mainForm.Projects_Panel.Controls[section];
            if (null != btn) {
                // 按钮背景调整为绿色
                btn.BackColor = backColor;
                // 运行中，只能停止操作
                btn.ContextMenuStrip.Items[section + "MouseRightMenu_Start"].Enabled = startEnabled;
                btn.ContextMenuStrip.Items[section + "MouseRightMenu_Stop"].Enabled = stopEnabled;
                btn.ContextMenuStrip.Items[section + "MouseRightMenu_Update"].Enabled = updateEnabled;
            }
        }

        /// <summary>
        /// 校验项目配置参数
        /// </summary>
        /// <param name="projectSection">项目</param>
        /// <param name="force">是否强制更新bat文件</param>
        public static void checkSection(ProjectSections.ProjectSection projectSection, bool force) {
            // 校验端口启动进程的bat文件是否存在，不存在
            if (force || !File.Exists(FileUtils.getBatFilePath(projectSection.title, Config.BAT_FILE_TYPE_START))) {
                String logPath = null;
                if (!projectSection.isPrintLog) {
                    logPath = Path.GetDirectoryName(projectSection.jar) + Config.PATH_CHARACTER + projectSection.title;
                }
                ProjectUtils.createStartBat(projectSection, logPath, Config.LOG_FILE_INFO, Config.LOG_FILE_ERROR);
            }
            // 校验端口结束进程的bat文件是否存在，不存在
            if (force || !File.Exists(FileUtils.getBatFilePath(projectSection.title, Config.BAT_FILE_TYPE_STOP))) {
                ProjectUtils.createStopBat(projectSection);
            }
            // 识别运行状态

            if (null != projectSection) {
                if (PortUtils.PortInUse(Convert.ToInt16(projectSection.port))) {
                    projectSection.runStat = Config.PROJECT_RUN_STAT_SUCCESS;
                    projectSection.isRunning = true;
                }
                // 根据运行状态右键按钮的可操作性调整
                FormService.updateButtonEnabledOfMenuStrip(projectSection.section, projectSection.runStat);
            }
        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="buttonName">按钮的代码名 用的section</param>
        /// <param name="buttonText">按钮文本</param>
        /// <param name="jar">jar包路径</param>
        /// <param name="port">启动端口</param>
        /// <param name="heartBeat">心跳检测地址</param>
        public static void addButton(ProjectSections.ProjectSection projectSection) {
            Button button = new Button();
            #region 按钮基本属性
            button.ImageAlign = ContentAlignment.TopCenter;
            button.Location = new Point(3, 0);
            button.Name = projectSection.section;
            button.Size = new Size(Convert.ToInt32(Config.mainForm.Projects_Panel.Width * 0.98), 46);
            button.TabIndex = 0;
            // 按钮背景图片
            Image image = Image.FromFile(@"icons\computer.ico");
            button.BackgroundImageLayout = ImageLayout.None;
            button.BackgroundImage = image;
            // 按钮文本
            button.Text = projectSection.title;
            button.TextAlign = ContentAlignment.BottomCenter;
            button.Font = new Font("微软雅黑", 12);
            button.Tag = 9999;
            #endregion
            #region 按钮加载相关事件
            button.MouseHover += new EventHandler(EventService.BtnMouseHover);
            /** 
             * btn没有双击事件，只能单击，使用计时器模拟双击
             */
            button.MouseClick += new MouseEventHandler(EventService.BtnDoubleClick);
            button.MouseDown += new MouseEventHandler(EventService.btn_MouseDown);
            button.MouseMove += new MouseEventHandler(EventService.btn_MouseMove);
            button.MouseUp += new MouseEventHandler(EventService.btn_MouseUp);
            /** 右键按钮添加事件
             * 
             * */
            /* 启动程序按钮 */
            ContextMenuStrip rightMenu = new ContextMenuStrip();
            /* 查看按钮------------------------------------------------------------------ */
            ControlUtils.AddToolStripMenu(rightMenu, projectSection.section, Config.RIGHT_BUTTON_DETAIL_NAME, Config.RIGHT_BUTTON_DETAIL_TEXT, new EventHandler(EventService.BtnRightDetailClick));
            /* 启动按钮 ---------------------------------------------------------------*/
            ControlUtils.AddToolStripMenu(rightMenu, projectSection.section, Config.RIGHT_BUTTON_START_NAME, Config.RIGHT_BUTTON_START_TEXT, new EventHandler(EventService.BtnRightStartClick));
            /* 停止按钮--------------------------------------------------------------------- */
            ControlUtils.AddToolStripMenu(rightMenu, projectSection.section, Config.RIGHT_BUTTON_STOP_NAME, Config.RIGHT_BUTTON_STOP_TEXT, new EventHandler(EventService.BtnRightStopClick));
            /* 编辑按钮------------------------------------------------------------------ */
            ControlUtils.AddToolStripMenu(rightMenu, projectSection.section, Config.RIGHT_BUTTON_UPDATE_NAME, Config.RIGHT_BUTTON_UPDATE_TEXT, new EventHandler(EventService.BtnRightUpdateClick));
            /* 删除按钮---------------------------------------------------------------- */
            ControlUtils.AddToolStripMenu(rightMenu, projectSection.section, Config.RIGHT_BUTTON_DELETE_NAME, Config.RIGHT_BUTTON_DELETE_TEXT, new EventHandler(EventService.BtnRightDeleteClick));
            /* 刷新按钮------------------------------------------------------------------ */
            ControlUtils.AddToolStripMenu(rightMenu, projectSection.section, Config.RIGHT_BUTTON_FRESH_NAME, Config.RIGHT_BUTTON_FRESH_TEXT, new EventHandler(EventService.BtnRightFreshClick));
            /* 装载右键 */
            button.ContextMenuStrip = rightMenu;
            Config.mainForm.Projects_Panel.Controls.Add(button);
            #endregion
            
            // 创建新项目运行窗口tabPage

        }



        /// <summary>
        /// 修改按钮
        /// </summary>
        /// <param name="section"></param>
        public static void updateButton(ProjectSections.ProjectSection monitorSection) {
            Button btn = (Button)Config.mainForm.Projects_Panel.Controls[monitorSection.section];
            if (null != monitorSection) {
                String title = monitorSection.title;
                String port = monitorSection.port;
                btn.Text = title;
            } else {

            }
        }

        /// <summary>
        /// 移除按钮
        /// </summary>
        /// <param name="section"></param>
        public static void removeButton(String section) {
            // 按钮清除
            Button btn = (Button)Config.mainForm.Projects_Panel.Controls[section];
            Config.mainForm.Projects_Panel.Controls.Remove(btn);
            // project_section清除
            ProjectSections.removeProjectBySection(section);
            // 文件清除
            ProjectUtils.removeBat(btn.Text);
        }
    }
}
