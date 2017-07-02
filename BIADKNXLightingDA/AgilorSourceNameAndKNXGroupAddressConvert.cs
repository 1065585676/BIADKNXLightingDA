using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIADKNXLightingDA {
    class AgilorSourceNameAndKNXGroupAddressConvert {
        private static string _deviceName = "TC";

        public AgilorSourceNameAndKNXGroupAddressConvert(string deviceName) {
            _deviceName = deviceName;
        }

        public static string getSourceNameByGroupAddress(string groupAddress) {
            return _deviceName + "&" + groupAddress;
        }

        public static string getSourceNameByGroupAddress(string groupAddress, string deviceName) {
            return deviceName + "&" + groupAddress;
        }

        public static string getGroupAddressBySourceName(string sourceName) {
            return sourceName.Split('&')[1];
        }

    }
}
