using PM_plus.config;
using System;

namespace PM_plus.utils {
    class StringUtils {
        public static bool IsNotEmpty(string str) {
            return !IsEmpty(str);
        }
        public static bool IsEmpty(string str) {
            return string.IsNullOrEmpty(str);
        }

        public static String TxtEncode(String str) {
            if (IsNotEmpty(str)) {
                str = str.Replace(Config.ENTER_STR, "\\r\\n").Replace("\n", "\\n").Replace("\r", "\\r");
            }
            return str;
        }

        public static String TxtDecode(String str) {
            if (IsNotEmpty(str)) {
                str = str.Replace("\\r\\n", Config.ENTER_STR).Replace("\\n", "\n").Replace("\\r", "\r");
            }
            return str;
        }

        public static String FormatSize(float byteSize) {
            string unit;
            float count = byteSize;
            if (byteSize > (1024 * 1024 * 1024 / 2)) {
                // GB
                unit = "GB";
                count = byteSize / 1024.0F / 1024.0F / 1024.0F;
            } else if (byteSize > (1024 * 1024 / 2)) {
                // MB
                unit = "MB";
                count = byteSize / 1024.0F / 1024.0F;
            } else if (byteSize > (1024 / 2)) {
                // KB
                unit = "KB";
                count = byteSize / 1024.0F;
            } else {
                unit = "B";
            }

            return string.Format("{0:###,##0.00}" + unit, count);
        }
    }
}
