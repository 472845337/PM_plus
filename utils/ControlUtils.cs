using PM_plus.config;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PM_plus.utils {
    class ControlUtils {

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
