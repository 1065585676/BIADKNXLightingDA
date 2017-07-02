using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIADKNXLightingDA {
    /// <summary>
    /// Summary description for FalconDemoHelper.
    /// </summary>
    public class FalconDemoHelper {
        public FalconDemoHelper() {
            //
            // TODO: Add constructor logic here
            //
        }

        public string GetBusPriorityText(EIBA.Interop.Falcon.Priority Prio) {
            string sPriority;
            switch (Prio) {
                case EIBA.Interop.Falcon.Priority.PrioritySystem:
                    sPriority = "PrioritySystem";
                    break;
                case EIBA.Interop.Falcon.Priority.PriorityAlarm:
                    sPriority = "PriorityAlarm";
                    break;
                case EIBA.Interop.Falcon.Priority.PriorityLow:
                    sPriority = "PriorityLow";
                    break;
                case EIBA.Interop.Falcon.Priority.PriorityHigh:
                    sPriority = "PriorityHigh";
                    break;
                default:
                    sPriority = "Unknown";
                    break;
            }
            return sPriority;
        }

        static public byte[] StringToByteArray(string dataAsString) {
            const string exceptionMessage = "Invalid data string";
            string seperator = " ";
            string[] splittedDataString = dataAsString.Split(seperator.ToCharArray());

            byte[] data = new byte[splittedDataString.GetLength(0)];
            int counter = 0;

            foreach (string sub in splittedDataString) {
                if (sub.Length != 4) {
                    throw new ArgumentException(exceptionMessage);
                }

                if (!sub.StartsWith("0x") && !sub.StartsWith("0X")) {
                    throw new ArgumentException(exceptionMessage);
                }

                data[counter] = Convert.ToByte(sub.Substring(2, 2), 16);
                ++counter;
            }

            return data;
        }
        static public int PropertyDataTypeFromString(string typeAsString) {
            int type = -1;
            switch (typeAsString) {
                case "PT_CONTROL": {
                        type = 0;
                        break;
                    }
                case "PT_CHAR": {
                        type = 1;
                        break;
                    }
                case "PT_UNSIGNED_CHAR": {
                        type = 2;
                        break;
                    }
                case "PT_INT": {
                        type = 3;
                        break;
                    }
                case "PT_UNSIGNED_INT": {
                        type = 4;
                        break;
                    }
                case "PT_EIB_FLOAT": {
                        type = 5;
                        break;
                    }
                case "PT_DATE": {
                        type = 6;
                        break;
                    }
                case "PT_TIME": {
                        type = 7;
                        break;
                    }
                case "PT_LONG": {
                        type = 8;
                        break;
                    }
                case "PT_UNSIGNED_LONG": {
                        type = 9;
                        break;
                    }
                case "PT_FLOAT": {
                        type = 10;
                        break;
                    }
                case "PT_DOUBLE": {
                        type = 11;
                        break;
                    }
                case "PT_CHAR_BLOCK": {
                        type = 12;
                        break;
                    }
                case "PT_POLL_GROUP_SETTINGS": {
                        type = 13;
                        break;
                    }
                case "PT_SHORT_CHAR_BLOCK": {
                        type = 14;
                        break;
                    }
                case "PT_GENERIC_01": {
                        type = 17;
                        break;
                    }
                case "PT_GENERIC_02": {
                        type = 18;
                        break;
                    }
                case "PT_GENERIC_03": {
                        type = 19;
                        break;
                    }
                case "PT_GENERIC_04": {
                        type = 20;
                        break;
                    }
                case "PT_GENERIC_05": {
                        type = 21;
                        break;
                    }
                case "PT_GENERIC_06": {
                        type = 22;
                        break;
                    }
                case "PT_GENERIC_07": {
                        type = 23;
                        break;
                    }
                case "PT_GENERIC_08": {
                        type = 1;
                        break;
                    }
                default: {
                        type = -1;
                        break;
                    }
            }
            return type;
        }
    }
}
