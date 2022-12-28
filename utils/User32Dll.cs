using System;
using System.Runtime.InteropServices;

namespace PM_plus.utils {
    class User32Dll {

        public static UInt16 SW_HIDE = 0;//隐藏窗口并激活另一个窗口。
        public static UInt16 SW_NORMAL = 1;//	激活并显示窗口。 如果窗口最小化或最大化，系统会将其还原到其原始大小和位置。 首次显示窗口时，应用程序应指定此标志。
        public static UInt16 SW_SHOWMINIMIZED = 2;//	激活窗口并将其显示为最小化窗口。
        public static UInt16 SW_MAXIMIZE = 3;//	激活窗口并显示最大化的窗口。
        public static UInt16 SW_SHOWNOACTIVATE = 4;//	在其最近的大小和位置显示一个窗口。 此值类似于 SW_SHOWNORMAL，但窗口未激活。
        public static UInt16 SW_SHOW = 5;//	激活窗口并以当前大小和位置显示窗口。
        public static UInt16 SW_MINIMIZE = 6;//	最小化指定的窗口，并按 Z 顺序激活下一个顶级窗口。
        public static UInt16 SW_SHOWMINNOACTIVE = 7;//	将窗口显示为最小化窗口。 此值类似于 SW_SHOWMINIMIZED，但窗口未激活。
        public static UInt16 SW_SHOWNA = 8;//	以当前大小和位置显示窗口。 此值类似于 SW_SHOW，但窗口未激活。
        public static UInt16 SW_RESTORE = 9;//	激活并显示窗口。 如果窗口最小化或最大化，系统会将其还原到其原始大小和位置。 还原最小化窗口时，应用程序应指定此标志。
        public static UInt16 SW_SHOWDEFAULT = 10;//	根据启动应用程序的程序传递给 CreateProcess 函数的 STARTUPINFO 结构中指定的SW_值设置显示状态。
        public static UInt16 SW_FORCEMINIMIZE = 11;//即使拥有窗口的线程未响应，也会最小化窗口。 仅当将窗口从不同的线程最小化时，才应使用此标志。



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
