using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIADKNXLightingDA {
    class AgilorKNXConvert {
        public struct WriteStruct {
            public object GroupAddress;
            public EIBA.Interop.Falcon.Priority Priority;
            public int RoutingCount;
            public bool LessThan7Bits;
            public object Data;
        };

        public static WriteStruct getWriteObject(Agilor.Interface.Val.Value val) {
            WriteStruct ws = new WriteStruct();
            ws.GroupAddress = "";
            ws.Priority = EIBA.Interop.Falcon.Priority.PriorityLow;
            return ws;
        }

        public static string getGroupAddressBySourceName(string sourcename) {
            return "";
        }
    }
}
