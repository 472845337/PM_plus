using System;

namespace PM_plus.utils {
    class SkinUtils {
        public static String GetSkinShowPath(String skinPath) {
            return skinPath.Replace(".ssk", ".gif");
        }
    }
}
