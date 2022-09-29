using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PM_plus.utils {
    class DateTimeUtils {

        public DateTime getNow() {
            return new DateTime();
        }
        public String formatDate(DateTime datetime, String format) {
            return datetime.ToString(format);
        }
    }
}
