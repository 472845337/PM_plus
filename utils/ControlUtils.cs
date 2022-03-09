using PM_plus.config;
using PM_plus.service;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PM_plus.utils {
    class ControlUtils {

        private static object lockObj = new object();
        /// <summary>
        /// 根据section获取运行窗口页
        /// </summary>
        /// <param name="section"></param>
        /// <returns></returns>
        public static RichTextBox getRichTextBoxControlBySection(String section) {
            lock (lockObj) {
                if (Config.richTextBoxControlDic == null || Config.richTextBoxControlDic.Count == 0) {
                    // 获取form中的所有控件，拿到richTextBox
                    foreach (Control single in getAllControl()) {
                        if (single is RichTextBox) {
                            Config.richTextBoxControlDic.Add(single.Name, (RichTextBox)single);
                        }
                    }
                }
                if (Config.richTextBoxControlDic.ContainsKey(section + "RichTextBox")) {
                    return Config.richTextBoxControlDic[section + "RichTextBox"];
                } else {
                    return null;
                }
            }
        }

        public static List<Control> getAllControl() {
            List<Control> controlList = new List<Control>();
            foreach (Control c in Config.mainForm.Controls) {
                controlList.Add(c);
                controlList.AddRange(getChildControlsFromControl(c, true));
            }
            return controlList;
        }

        public static List<Control> getChildControlsFromControl(Control c, bool child) {
            List<Control> controlList = new List<Control>();
            foreach (Control single in c.Controls) {
                controlList.Add(single);
                if (child) {
                    controlList.AddRange(getChildControlsFromControl(single, child));
                }
            }
            return controlList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tabControl"></param>
        /// <param name="section"></param>
        public static void addTabPage2TabControl(TabControl tabControl, String section) {
            // 标题
            String title = IniUtils.IniReadValue(Config.ProjectsIniPath, section, Config.INI_KEY_PROJECT_TITLE);
            // 创建新的tab页
            TabPage tabPage = ControlUtils.createTabPage(section, title);
            // tabPage中创建日志文本框
            ControlUtils.addRichTextBox2TabPage(tabPage, section, title);
            // 清除按钮添加
            ControlUtils.AddButton2TabPage(section, Config.RUNTAB_CONTROL_NAME_CLEAR_BUTTON_NAME, Config.RUNTAB_CONTROL_NAME_CLEAR_BUTTON_TEXT
                , Config.RUNTAB_CONTROL_BUTTON_SIZE, Config.RUNTAB_CONTROL_NAME_CLEAR_BUTTON_LOCATION
                , AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top
                , tabPage, new MouseEventHandler(EventService.RunTab_ClearButtonClick));
            // 启动按钮添加
            ControlUtils.AddButton2TabPage(section, Config.RUNTAB_CONTROL_NAME_START_BUTTON_NAME, Config.RUNTAB_CONTROL_NAME_START_BUTTON_TEXT
                , Config.RUNTAB_CONTROL_BUTTON_SIZE, Config.RUNTAB_CONTROL_NAME_START_BUTTON_LOCATION
                , AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Top
                , tabPage, new MouseEventHandler(EventService.RunTab_StartButtonClick));
            // 终止按钮添加
            ControlUtils.AddButton2TabPage(section, Config.RUNTAB_CONTROL_NAME_STOP_BUTTON_NAME, Config.RUNTAB_CONTROL_NAME_STOP_BUTTON_TEXT
                , Config.RUNTAB_CONTROL_BUTTON_SIZE, Config.RUNTAB_CONTROL_NAME_STOP_BUTTON_LOCATION
                , AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Top
                , tabPage, new MouseEventHandler(EventService.RunTab_StopButtonClick));

            tabControl.TabPages.Add(tabPage);
        }

        public static TabPage createTabPage(String section, String text) {
            TabPage tabPage = new TabPage();
            tabPage.Name = section + Config.RUNTAB_CONTROL_NAME_TABPAGE;
            tabPage.Text = text;
            tabPage.BackColor = Color.Transparent;
            tabPage.Size = Config.RUNTAB_CONTROL_TABPAGE_SIZE;
            tabPage.Tag = section;
            return tabPage;
        }

        public static void addRichTextBox2TabPage(TabPage tabPage, String section, String text) {
            // 日志文本框控件
            RichTextBox richTextBox = new RichTextBox();
            richTextBox.Name = section + Config.RUNTAB_CONTROL_NAME_RICHTEXTBOX;
            richTextBox.Size = Config.RUNTAB_CONTROL_RICHTEXTBOX_SIZE;
            richTextBox.Location = Config.RUNTAB_CONTROL_RICHTEXTBOX_LOCATION;
            richTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            richTextBox.Text = text;
            richTextBox.BackColor = SystemColors.WindowText;
            richTextBox.ForeColor = SystemColors.HighlightText;
            richTextBox.Tag = section;
            richTextBox.ReadOnly = true;
            // Config.richTextBoxControlDic.Add(richTextBox.Name, richTextBox);
            // 文本框放入TabPage
            tabPage.Controls.Add(richTextBox);
        }

        public static void AddButton2TabPage(String section, String name, String text, Size size, Point point, AnchorStyles anchor, TabPage tabPage, MouseEventHandler handler) {
            Button button = new Button();
            button.Name = section + name;
            button.Text = text;
            button.Size = size;
            button.Location = point;
            button.Anchor = anchor;
            button.Tag = section;
            button.MouseClick += handler;
            tabPage.Controls.Add(button);
        }

        public static void AddToolStripMenu(ContextMenuStrip rightMenu, String name, String typeName, String text, EventHandler eventHandler) {
            ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem.Name = name + typeName;
            toolStripMenuItem.Text = text;
            toolStripMenuItem.Tag = name;
            toolStripMenuItem.Click += eventHandler;
            rightMenu.Items.Add(toolStripMenuItem);
        }
    }
}
