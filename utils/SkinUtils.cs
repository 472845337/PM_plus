using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PM_plus.utils {
    class SkinUtils {
        public static String getSkinShowPath(String skinPath) {
            return skinPath.Replace(".ssk", ".gif");
        }
    }
}
