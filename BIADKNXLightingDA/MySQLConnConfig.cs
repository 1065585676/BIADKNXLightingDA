using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BIADKNXLightingDA
{
    public partial class MySQLConnConfig : Form
    {
        public string mysql_server_ip = "127.0.0.1";
        public string mysql_user_id = "ibms";
        public string mysql_password = "toor";
        public string mysql_database_name = "ibmsappdb";
        public string mysql_table_name = "knx_device";

        public MySQLConnConfig()
        {
            InitializeComponent();


        }

        private void button_change_mysql_connect_config_Click(object sender, EventArgs e)
        {
            
        }
    }
}
