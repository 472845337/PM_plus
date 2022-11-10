﻿using System;
using System.Diagnostics;

namespace PM_plus.utils {
    class ProcessUtils {
        public String[] scriptLineArray;
        public String batFilePath;
        public ProcessUtils(String[] scriptLineArray) {
            this.scriptLineArray = scriptLineArray;
        }
        public ProcessUtils(String batFilePath) {
            this.batFilePath = batFilePath;
        }
        public void RunScript() {
            Process proc = new Process {
                StartInfo = new ProcessStartInfo {
                    FileName = @"C:\WINDOWS\system32\cmd.exe ",
                    UseShellExecute = false,
                    CreateNoWindow = false,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true
                }
            };
            proc.Start();
            // 执行脚本
            for (int i = 0; i < scriptLineArray.Length; i++) {
                proc.StandardInput.WriteLine(scriptLineArray[i]);
            }
            proc.WaitForExit();
            proc.Close();
            proc.Dispose();
        }

        public void RunBat() {
            Process.Start(batFilePath);
        }
    }
}
