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
    }
}
