using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace BIADKNXLightingDA {
    public partial class KNXWriteConfig : Form {

        public int _nPriority;
        public int _nRoutingCount;
        public bool _bLessthan7bits;

        public KNXWriteConfig() {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e) {
            _nPriority = comboBox_priority.SelectedIndex;
            _nRoutingCount = Convert.ToInt32(textBox_routingCount.Text.ToString());
            _bLessthan7bits = checkBox_lessThan7Bit.Checked;
            if (_nRoutingCount < 0 || _nRoutingCount > 7) // value is wrong
            {
                MessageBox.Show("Please enter a value between 0 and 7");
                textBox_routingCount.Select();
            } else {
                FileStream fs = null;
                StreamWriter sw = null;
                try {
                    fs = new FileStream("KNXWriteConfig.config", FileMode.OpenOrCreate);
                    sw = new StreamWriter(fs);

                    sw.WriteLine("_nPriority:" + _nPriority.ToString());
                    sw.WriteLine("_nRoutingCount:" + _nRoutingCount.ToString());
                    sw.WriteLine("_bLessthan7bits:" + _bLessthan7bits.ToString());

                    Form1.needReloadConfig = true;

                } catch(Exception ex) {
                    MessageBox.Show("保存配置失败:" + ex.ToString());
                } finally {
                    if (sw != null) sw.Close();
                    if (fs != null) fs.Close();
                }
                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            Close();
        }

        private void textBox_routingCount_KeyPress(object sender, KeyPressEventArgs e) {
            if (!Char.IsDigit(e.KeyChar))        // allow only number in the field
            {
                e.Handled = true;
            }
        }

        private void KNXWriteConfig_Load(object sender, EventArgs e) {
            FileStream fs = null;
            StreamReader sr = null;
            try {
                fs = new FileStream("KNXWriteConfig.config", FileMode.Open);
                sr = new StreamReader(fs);

                comboBox_priority.SelectedIndex = int.Parse(sr.ReadLine().Split(':')[1]);
                textBox_routingCount.Text = sr.ReadLine().Split(':')[1];
                checkBox_lessThan7Bit.Checked = bool.Parse(sr.ReadLine().Split(':')[1]);

            } catch (Exception ex) {
                MessageBox.Show("读取配置失败:" + ex.ToString());
            } finally {
                if (sr != null) sr.Close();
                if (fs != null) fs.Close();
            }
        }
    }
}
