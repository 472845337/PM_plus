using System;
using System.Runtime.InteropServices;

namespace PM_plus.utils {
    class User32Dll {
        // 关闭窗口
        public static UInt16 SHOW_WINDOW_CLOSE = 0;
        // 正常显示
        public static UInt16 SHOW_WINDOW_OPEN = 1;
        // 最小化窗口
        public static UInt16 SHOW_WINDOW_MIN = 2;
        // 最大化窗口
        public static UInt16 SHOW_WINDOW_MAX = 3;



        [DllImport("User32.dll ", EntryPoint = "SetParent")]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        /// <summary>
        /// 窗口操作，关闭请不要随意使用
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="nCmdShow"></param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "ShowWindow", SetLastError = true)]
        public static extern bool ShowWindow(IntPtr hWnd, UInt16 nCmdShow);
        /// <summary>
        /// 窗口置最前，最小化也会置
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="fAltTab"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool SwitchToThisWindow(IntPtr hWnd, Boolean fAltTab);
    }
}
