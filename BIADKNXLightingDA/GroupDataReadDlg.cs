using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BIADKNXLightingDA {
    public partial class GroupDataReadDlg : Form {

        public int _nPriority;
        public int _nRoutingCount;
        public string _sGroupAddress;
        private bool bNotClose = false; // to not allow to close with wrong data

        public GroupDataReadDlg() {
            InitializeComponent();

            btnOk.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;
        }

        private void GroupDataReadDlg_Load(object sender, System.EventArgs e) {
            txtGroupAddress.Text = _sGroupAddress;
            txtRoutingCount.Text = Convert.ToString(_nRoutingCount);
            cmbPriority.SelectedIndex = _nPriority;
        }

        private void btnOk_Click(object sender, System.EventArgs e) {
            bNotClose = false;
            _nPriority = cmbPriority.SelectedIndex;
            _nRoutingCount = Convert.ToInt32(txtRoutingCount.Text.ToString());
            if (_nRoutingCount < 0 || _nRoutingCount > 7) // value is wrong
            {
                MessageBox.Show("Please enter a value between 0 and 7");
                txtRoutingCount.Select();
                bNotClose = true;         // do close dialog
                return;
            }
            _sGroupAddress = txtGroupAddress.Text;
            Close();
        }

        private void btnCancel_Click(object sender, System.EventArgs e) {
            Close();
        }

        private void txtRoutingCount_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e) {
            if (!Char.IsDigit(e.KeyChar))        // allow only number in the field
            {
                e.Handled = true;
            }
        }

        private void GroupDataReadDlg_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            e.Cancel = bNotClose;
        }
    }
}
