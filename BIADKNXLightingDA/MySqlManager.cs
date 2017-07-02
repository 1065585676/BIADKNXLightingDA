using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIADKNXLightingDA {
    class MySqlManager {
        private string _ip;
        private string _uid;
        private string _pwd;
        private string _database;

        private MySql.Data.MySqlClient.MySqlConnection _conn = null;

        public MySqlManager(string ip, string uid, string pwd, string database) {
            _ip = ip;
            _uid = uid;
            _pwd = pwd;
            _database = database;
        }

        public bool connect() {
            string myConnectionString;

            myConnectionString = "server=" + _ip + ";uid=" + _uid + ";" + "pwd=" + _pwd + ";database=" + _database + ";";
            try {
                _conn = new MySql.Data.MySqlClient.MySqlConnection(myConnectionString);
                _conn.Open();
            } catch (MySql.Data.MySqlClient.MySqlException ex) {
                Console.WriteLine(ex.ToString());
                _conn = null;
                return false;
            }

            return true;
        }


    }
}
