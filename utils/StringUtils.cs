using PM_plus.config;
using System;
using System.Collections.Generic;
using System.Text;

namespace PM_plus.utils
{
    class StringUtils
    {
        public static bool IsNotEmpty(String str)
        {
            return !IsEmpty(str);
        }
        public static bool IsEmpty(String str)
        {
            bool isEmpty = false;
            if(null == str || "".Equals(str) || "null".Equals(str.ToLower()))
            {
                isEmpty = true;
            }
            return isEmpty;
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
    }
}
