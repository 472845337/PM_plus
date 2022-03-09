using System;
using System.Collections.Generic;
using System.Text;

namespace PM_plus.utils
{
    class StringUtils
    {
        public static bool isNotEmpty(String str)
        {
            return !isEmpty(str);
        }
        public static bool isEmpty(String str)
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
