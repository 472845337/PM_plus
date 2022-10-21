using PM_plus.config;
using PM_plus.service;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PM_plus.utils {
    class ControlUtils {

        private static readonly object lockObj = new object();
        /// <summary>
        /// 根据section获取运行窗口页
        /// </summary>
        /// <param name="section"></param>
        /// <returns></returns>
        public static RichTextBox GetRichTextBoxControlBySection(String section) {
            lock (lockObj) {
                if (Config.richTextBoxControlDic == null || Config.richTextBoxControlDic.Count == 0) {
                    // 获取form中的所有控件，拿到richTextBox
                    foreach (Control single in GetAllControl()) {
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

        public static List<Control> GetAllControl() {
            List<Control> controlList = new List<Control>();
            foreach (Control c in Config.mainForm.Controls) {
                controlList.Add(c);
                controlList.AddRange(GetChildControlsFromControl(c, true));
            }
            return controlList;
        }

        public static List<Control> GetChildControlsFromControl(Control c, bool child) {
            List<Control> controlList = new List<Control>();
            foreach (Control single in c.Controls) {
                controlList.Add(single);
                if (child) {
                    controlList.AddRange(GetChildControlsFromControl(single, child));
                }
            }
            return controlList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tabControl"></param>
        /// <param name="section"></param>
        public static void AddTabPage2TabControl(TabControl tabControl, String section) {
            // 标题
            String title = IniUtils.IniReadValue(Config.ProjectsIniPath, section, Config.INI_KEY_PROJECT_TITLE);
            // 创建新的tab页
            TabPage tabPage = ControlUtils.CreateTabPage(section, title);
            // tabPage中创建日志文本框
            ControlUtils.AddRichTextBox2TabPage(tabPage, section, title);
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

        public static TabPage CreateTabPage(String section, String text) {
            TabPage tabPage = new TabPage {
                Name = section + Config.RUNTAB_CONTROL_NAME_TABPAGE,
                Text = text,
                BackColor = Color.Transparent,
                Size = Config.RUNTAB_CONTROL_TABPAGE_SIZE,
                Tag = section
            };
            return tabPage;
        }

        public static void AddRichTextBox2TabPage(TabPage tabPage, String section, String text) {
            // 日志文本框控件
            RichTextBox richTextBox = new RichTextBox {
                Name = section + Config.RUNTAB_CONTROL_NAME_RICHTEXTBOX,
                Size = Config.RUNTAB_CONTROL_RICHTEXTBOX_SIZE,
                Location = Config.RUNTAB_CONTROL_RICHTEXTBOX_LOCATION,
                Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top,
                Text = text,
                BackColor = SystemColors.WindowText,
                ForeColor = SystemColors.HighlightText,
                Tag = section,
                ReadOnly = true
            };
            // Config.richTextBoxControlDic.Add(richTextBox.Name, richTextBox);
            // 文本框放入TabPage
            tabPage.Controls.Add(richTextBox);
        }

        public static void AddButton2TabPage(String section, String name, String text, Size size, Point point, AnchorStyles anchor, TabPage tabPage, MouseEventHandler handler) {
            Button button = new Button {
                Name = section + name,
                Text = text,
                Size = size,
                Location = point,
                Anchor = anchor,
                Tag = section
            };
            button.MouseClick += handler;
            tabPage.Controls.Add(button);
        }

        public static void AddToolStripMenu(ContextMenuStrip rightMenu, String name, String typeName, String text, String imagePath, EventHandler eventHandler) {
            ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem {
                Name = name + typeName,
                Text = text,
                Tag = name
            };
            if (StringUtils.IsNotEmpty(imagePath)) {
                toolStripMenuItem.Image = Image.FromFile(imagePath);
            }
            toolStripMenuItem.Click += eventHandler;
            rightMenu.Items.Add(toolStripMenuItem);
        }

        /// <summary>
        /// 不可用Form直接修改，这样会造成窗口变样
        /// </summary>
        /// <param name="con"></param>
        /// <param name="FontFamilyName"></param>
        /// <param name="isChildren"></param>
        public static void SetControlFont(Control con, String FontFamilyName, int fontSize, Color fontColor, bool isChildren) {
            if ("FontFamilyComboBox".Equals(con.Name)) {
                return;
            }
            con.Font = new Font(StringUtils.IsEmpty(FontFamilyName) ? Config.DEFAULT_FONT_FAMILY : FontFamilyName, fontSize == 0 ? con.Font.Size : fontSize);
            con.ForeColor = fontColor;
            if (isChildren && con.HasChildren) {
                foreach (Control children in con.Controls) {
                    SetControlFont(children, FontFamilyName, fontSize, fontColor, isChildren);
                }
            }

        }
    }
}
