namespace BIADKNXLightingDA {
    partial class GroupDataWriteDlg {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        /// 
        private System.Windows.Forms.Label lblPriority;
        private System.Windows.Forms.Label lblRoutingCount;
        private System.Windows.Forms.Label lblGroupaddress;
        private System.Windows.Forms.TextBox txtRoutingCount;
        private System.Windows.Forms.TextBox txtGroupAddress;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.CheckBox chbLess7Bits;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.ComboBox cmbPriority;
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Text = "GroupDataWriteDlg";


            this.lblPriority = new System.Windows.Forms.Label();
            this.lblRoutingCount = new System.Windows.Forms.Label();
            this.lblGroupaddress = new System.Windows.Forms.Label();
            this.txtRoutingCount = new System.Windows.Forms.TextBox();
            this.txtGroupAddress = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.chbLess7Bits = new System.Windows.Forms.CheckBox();
            this.lblData = new System.Windows.Forms.Label();
            this.txtData = new System.Windows.Forms.TextBox();
            this.cmbPriority = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblPriority
            // 
            this.lblPriority.Location = new System.Drawing.Point(8, 96);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Size = new System.Drawing.Size(88, 24);
            this.lblPriority.TabIndex = 17;
            this.lblPriority.Text = "&Priority:";
            // 
            // lblRoutingCount
            // 
            this.lblRoutingCount.Location = new System.Drawing.Point(8, 56);
            this.lblRoutingCount.Name = "lblRoutingCount";
            this.lblRoutingCount.Size = new System.Drawing.Size(88, 24);
            this.lblRoutingCount.TabIndex = 16;
            this.lblRoutingCount.Text = "&Routing count: ";
            // 
            // lblGroupaddress
            // 
            this.lblGroupaddress.Location = new System.Drawing.Point(8, 8);
            this.lblGroupaddress.Name = "lblGroupaddress";
            this.lblGroupaddress.Size = new System.Drawing.Size(88, 24);
            this.lblGroupaddress.TabIndex = 15;
            this.lblGroupaddress.Text = "&Group address: ";
            // 
            // txtRoutingCount
            // 
            this.txtRoutingCount.Location = new System.Drawing.Point(108, 52);
            this.txtRoutingCount.Name = "txtRoutingCount";
            this.txtRoutingCount.Size = new System.Drawing.Size(104, 20);
            this.txtRoutingCount.TabIndex = 2;
            this.txtRoutingCount.Text = "6";
            this.txtRoutingCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRoutingCount_KeyPress);
            // 
            // txtGroupAddress
            // 
            this.txtGroupAddress.Location = new System.Drawing.Point(108, 8);
            this.txtGroupAddress.Name = "txtGroupAddress";
            this.txtGroupAddress.Size = new System.Drawing.Size(104, 20);
            this.txtGroupAddress.TabIndex = 1;
            this.txtGroupAddress.Text = "";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(224, 48);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 24);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(224, 8);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(80, 24);
            this.btnOk.TabIndex = 11;
            this.btnOk.Text = "&Ok";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // chbLess7Bits
            // 
            this.chbLess7Bits.Location = new System.Drawing.Point(8, 136);
            this.chbLess7Bits.Name = "chbLess7Bits";
            this.chbLess7Bits.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chbLess7Bits.Size = new System.Drawing.Size(200, 24);
            this.chbLess7Bits.TabIndex = 4;
            this.chbLess7Bits.Text = "&Less than 7 bit";
            this.chbLess7Bits.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblData
            // 
            this.lblData.Location = new System.Drawing.Point(8, 184);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(112, 24);
            this.lblData.TabIndex = 20;
            this.lblData.Text = "&Data:";
            // 
            // txtData
            // 
            this.txtData.Location = new System.Drawing.Point(120, 176);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(88, 20);
            this.txtData.TabIndex = 5;
            this.txtData.Text = "0x00";
            // 
            // cmbPriority
            // 
            this.cmbPriority.Items.AddRange(new object[] {
                                                     "System",
                                                     "High",
                                                     "Alarm",
                                                     "Low"});
            this.cmbPriority.Location = new System.Drawing.Point(108, 97);
            this.cmbPriority.Name = "cmbPriority";
            this.cmbPriority.Size = new System.Drawing.Size(104, 21);
            this.cmbPriority.TabIndex = 3;
            this.cmbPriority.SelectedIndex = 3;
            // 
            // GroupDataWriteDlg
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(320, 215);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.cmbPriority,
                                                                  this.txtData,
                                                                  this.lblData,
                                                                  this.chbLess7Bits,
                                                                  this.lblPriority,
                                                                  this.lblRoutingCount,
                                                                  this.lblGroupaddress,
                                                                  this.txtRoutingCount,
                                                                  this.txtGroupAddress,
                                                                  this.btnCancel,
                                                                  this.btnOk});
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GroupDataWriteDlg";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Group Data Write";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.GroupDataWriteDlg_Closing);
            this.Load += new System.EventHandler(this.GroupDataWriteDlg_Load);
            this.ResumeLayout(false);
        }

        #endregion
    }
}