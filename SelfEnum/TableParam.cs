using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PM_plus.SelfEnum{
    class TableParam :Attribute{
        public bool isKey;
        public String param;
        public String type;

        public TableParam(String param, String type) {
            this.param = param;
            this.type = type;
        }

        public TableParam(bool isKey, String param, String type) {
            this.isKey = isKey;
            this.param = param;
            this.type = type;
        }
    }
}
