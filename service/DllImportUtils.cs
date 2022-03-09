using System;
using System.Runtime.InteropServices;

namespace PM_plus.service
{
    class DllImportUtils
    {
        public delegate bool ConsoleCtrlDelegate(int ctrlType);
        //当用户关闭Console时，系统会发送次消息
        public const int CTRL_CLOSE_EVENT = 2;
        //Ctrl+C，系统会发送次消息
        public const int CTRL_C_EVENT = 0;
        //Ctrl+break，系统会发送次消息
        public const int CTRL_BREAK_EVENT = 1;
        //用户退出（注销），系统会发送次消息
        public const int CTRL_LOGOFF_EVENT = 5;
        //系统关闭，系统会发送次消息
        public const int CTRL_SHUTDOWN_EVENT = 6;


        [DllImport("User32.dll ", EntryPoint = "SetParent")]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        [DllImport("user32.dll ", EntryPoint = "ShowWindow")]
        public static extern int ShowWindow(IntPtr hwnd, int nCmdShow);
        [DllImport("kernel32.dll")]
        public static extern bool GenerateConsoleCtrlEvent(int dwCtrlEvent, int dwProcessGroupId);

        /// <summary>
        /// 使用示例，传入关闭console指令
        /// SetConsoleCtrlHandler(new IntPtr(CTRL_CLOSE_EVENT), true);
        /// </summary>
        /// <param name="HandlerRoutine"></param>
        /// <param name="add"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        public static extern bool SetConsoleCtrlHandler(IntPtr HandlerRoutine, bool add);
        [DllImport("kernel32.dll")]
        public static extern bool AttachConsole(int dwProcessId);
        [DllImport("kernel32.dll")]
        public static extern bool FreeConsole();
    }
}
