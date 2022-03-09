using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace PM_plus.utils
{
    /// <summary>
    /// 该类工具是用于判断某个控件中滚动条是否出现
    /// 暂未使用到
    /// </summary>
    class ScrollBarUtils
    {
        private const int WS_HSCROLL = 0x100000;
        private const int WS_VSCROLL = 0x200000;
        private const int GWL_STYLE = (-16);

        [System.Runtime.InteropServices.DllImport("user32", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        private static extern int GetWindowLong(IntPtr hwnd, int nIndex);

        /// <summary>
        /// 判断是否出现垂直滚动条
        /// </summary>
        /// <param name="ctrl">待测控件</param>
        /// <returns>出现垂直滚动条返回true，否则为false</returns>
        internal static bool IsVerticalScrollBarVisible(Control ctrl)
        {
            if (!ctrl.IsHandleCreated) { 
                return false;
            }
            return (GetWindowLong(ctrl.Handle, GWL_STYLE) & WS_VSCROLL) != 0;
        }

        /// <summary>
        /// 判断是否出现水平滚动条
        /// </summary>
        /// <param name="ctrl">待测控件</param>
        /// <returns>出现水平滚动条返回true，否则为false</returns>
        internal static bool IsHorizontalScrollBarVisible(Control ctrl)
        {
            if (!ctrl.IsHandleCreated)
            {
                return false;
            }
            return (GetWindowLong(ctrl.Handle, GWL_STYLE) & WS_HSCROLL) != 0;
        }
    }
}
