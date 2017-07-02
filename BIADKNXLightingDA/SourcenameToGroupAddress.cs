using System;
using System.Data;
using System.Windows.Forms;

namespace BIADKNXLightingDA {
    public partial class SourcenameToGroupAddress : Form {

        private string connStr = String.Format("server={0}; uid={1}; pwd={2}; database=biad; Charset=utf8",
                "127.0.0.1", "root", "toor"
                );

        public SourcenameToGroupAddress() {
            InitializeComponent();
        }

        private void btn_search_Click(object sender, EventArgs e) {
            if (se_sourcename.Text != "") {
                try {
                    string cmdText = "SELECT groupaddress FROM groupaddress2sourcename WHERE sourcename='" + se_sourcename.Text + "';";

                    DataSet data = MySqlHelper.GetDataSet(connStr, CommandType.Text, cmdText);
                    if (data.Tables[0].Rows.Count <= 0) {
                        tbx_logging.AppendText("There is no sourcename:" + se_sourcename.Text + " found.\r\n");
                    } else {
                        string gettedGroupAddress = data.Tables[0].Rows[0]["groupaddress"].ToString();
                        tbx_logging.AppendText("sourcename:" + se_sourcename.Text + " ==> groupaddress:" + gettedGroupAddress + "\r\n");
                        if (se_groupaddress.Text == gettedGroupAddress) return;
                    }
                } catch (Exception ex) {
                    tbx_logging.AppendText(ex.ToString() + "\r\n");
                }
            }

            if (se_groupaddress.Text != "") {
                try {
                    string cmdText = "SELECT sourcename FROM groupaddress2sourcename WHERE groupaddress='" + se_groupaddress.Text + "';";

                    DataSet data = MySqlHelper.GetDataSet(connStr, CommandType.Text, cmdText);
                    if (data.Tables[0].Rows.Count <= 0) {
                        tbx_logging.AppendText("There is no groupaddress:" + se_groupaddress.Text + " found.\r\n");
                    } else {
                        string gettedSourceName = data.Tables[0].Rows[0]["sourcename"].ToString();
                        tbx_logging.AppendText("sourcename:" + gettedSourceName + " ==> groupaddress:" + se_groupaddress.Text + "\r\n");
                    }
                } catch (Exception ex) {
                    tbx_logging.AppendText(ex.ToString() + "\r\n");
                }
            }
        }

        private void btn_add_Click(object sender, EventArgs e) {

            if((Control.ModifierKeys & Keys.Shift) == Keys.Shift) {
                // 同时按住了 Shift 键
            } else {
                try {
                    if (se_groupaddress.Text == "" || se_sourcename.Text == "") return;

                    string cmdText = "INSERT INTO groupaddress2sourcename VALUES('" + se_groupaddress.Text + "', '" + se_sourcename.Text + "'); ";
                    MySqlHelper.ExecuteNonQuery(connStr, CommandType.Text, cmdText);
                    tbx_logging.AppendText("Add sourcename:" + se_sourcename.Text + " ==> groupaddress:" + se_groupaddress.Text + " Success!\r\n");
                } catch (Exception ex) {
                    tbx_logging.AppendText(ex.ToString() + "\r\n");
                }
            }
        }

        private void btn_delete_Click(object sender, EventArgs e) {
            try {
                if (se_groupaddress.Text == "" || se_sourcename.Text == "") return;

                string cmdText = "DELETE IGNORE FROM groupaddress2sourcename WHERE groupaddress='" + se_groupaddress.Text + "' and sourcename = '" + se_sourcename.Text + "'; ";
                MySqlHelper.ExecuteNonQuery(connStr, CommandType.Text, cmdText);
                tbx_logging.AppendText("Delete sourcename:" + se_sourcename.Text + " ==> groupaddress:" + se_groupaddress.Text + " Success!\r\n");
            } catch (Exception ex) {
                tbx_logging.AppendText(ex.ToString() + "\r\n");
            }
        }

        private void btn_update_Click(object sender, EventArgs e) {
            try {
                if (se_groupaddress.Text == "" || se_sourcename.Text == "") return;
                string cmdText = "UPDATE groupaddress2sourcename SET sourcename='" + se_sourcename.Text  + "' WHERE groupaddress='" + se_groupaddress.Text + "';";
                MySqlHelper.ExecuteNonQuery(connStr, CommandType.Text, cmdText);
                tbx_logging.AppendText("Update Success!\r\n");
            } catch (Exception ex) {
                tbx_logging.AppendText(ex.ToString() + "\r\n");
            }
        }
    }
}
