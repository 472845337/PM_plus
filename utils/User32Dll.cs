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

        public static Int32 AW_ACTIVATE = 0x00020000;// 激活窗口。 不要将此值用于 AW_HIDE。
        public static Int32 AW_BLEND = 0x00080000;// 使用淡化效果。 仅当 hwnd 是顶级窗口时，才能使用此标志。
        public static Int32 AW_CENTER = 0x00000010;// 如果使用AW_HIDE，或者如果未使用AW_HIDE，则使窗口显示为向内折叠。 各种方向标志不起作用。
        public static Int32 AW_HIDE = 0x00010000;// 隐藏窗口。 默认情况下，将显示窗口。
        public static Int32 AW_HOR_POSITIVE = 0x00000001;// 将窗口从左到右进行动画处理。 此标志可用于滚动或幻灯片动画。 与 AW_CENTER 或 AW_BLEND一起使用时，将忽略它。
        public static Int32 AW_HOR_NEGATIVE = 0x00000002;// 将窗口从右到左进行动画处理。 此标志可用于滚动或幻灯片动画。 与 AW_CENTER 或 AW_BLEND一起使用时，将忽略它。
        public static Int32 AW_SLIDE = 0x00040000;// 使用幻灯片动画。 默认情况下，使用滚动动画。 与 AW_CENTER一起使用时，将忽略此标志。
        public static Int32 AW_VER_POSITIVE = 0x00000004;// 对窗口进行从上到下动画。 此标志可用于滚动或幻灯片动画。 与 AW_CENTER 或 AW_BLEND一起使用时，将忽略它。
        public static Int32 AW_VER_NEGATIVE = 0x00000008;// 对窗口进行从下到上动画。 此标志可用于滚动或幻灯片动画。 与 AW_CENTER 或 AW_BLEND一起使用时，将忽略它。


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

        [DllImport("user32.dll", EntryPoint = "AnimateWindow", SetLastError = true)]
        public static extern bool AnimateWindow(IntPtr hWnd, UInt16 dwTime, UInt16 dwFlags);
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
