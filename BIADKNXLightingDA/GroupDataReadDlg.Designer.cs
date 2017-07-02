namespace BIADKNXLightingDA {
    partial class GroupDataReadDlg {

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtGroupAddress;
        private System.Windows.Forms.TextBox txtRoutingCount;
        private System.Windows.Forms.Label lblGroupaddress;
        private System.Windows.Forms.Label lblRoutingCount;
        private System.Windows.Forms.Label lblPriority;
        private System.Windows.Forms.ComboBox cmbPriority;

        /// <summary>
        /// Required designer variable.
        /// </summary>
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
            this.Text = "GroupDataReadDlg";

            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtGroupAddress = new System.Windows.Forms.TextBox();
            this.txtRoutingCount = new System.Windows.Forms.TextBox();
            this.lblGroupaddress = new System.Windows.Forms.Label();
            this.lblRoutingCount = new System.Windows.Forms.Label();
            this.lblPriority = new System.Windows.Forms.Label();
            this.cmbPriority = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(224, 16);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(80, 24);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "&Ok";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(224, 64);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 24);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtGroupAddress
            // 
            this.txtGroupAddress.Location = new System.Drawing.Point(104, 16);
            this.txtGroupAddress.Name = "txtGroupAddress";
            this.txtGroupAddress.Size = new System.Drawing.Size(96, 20);
            this.txtGroupAddress.TabIndex = 1;
            this.txtGroupAddress.Text = "";
            // 
            // txtRoutingCount
            // 
            this.txtRoutingCount.Location = new System.Drawing.Point(104, 64);
            this.txtRoutingCount.Name = "txtRoutingCount";
            this.txtRoutingCount.Size = new System.Drawing.Size(96, 20);
            this.txtRoutingCount.TabIndex = 2;
            this.txtRoutingCount.Text = "6";
            this.txtRoutingCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRoutingCount_KeyPress);
            // 
            // lblGroupaddress
            // 
            this.lblGroupaddress.Location = new System.Drawing.Point(8, 16);
            this.lblGroupaddress.Name = "lblGroupaddress";
            this.lblGroupaddress.Size = new System.Drawing.Size(88, 24);
            this.lblGroupaddress.TabIndex = 7;
            this.lblGroupaddress.Text = "&Group address: ";
            // 
            // lblRoutingCount
            // 
            this.lblRoutingCount.Location = new System.Drawing.Point(8, 64);
            this.lblRoutingCount.Name = "lblRoutingCount";
            this.lblRoutingCount.Size = new System.Drawing.Size(88, 24);
            this.lblRoutingCount.TabIndex = 8;
            this.lblRoutingCount.Text = "&Routing count: ";
            // 
            // lblPriority
            // 
            this.lblPriority.Location = new System.Drawing.Point(8, 104);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Size = new System.Drawing.Size(88, 24);
            this.lblPriority.TabIndex = 9;
            this.lblPriority.Text = "&Priority:";
            // 
            // cmbPriority
            // 
            this.cmbPriority.Items.AddRange(new object[] {
                                                     "System",
                                                     "High",
                                                     "Alarm",
                                                     "Low"});
            this.cmbPriority.Location = new System.Drawing.Point(104, 104);
            this.cmbPriority.Name = "cmbPriority";
            this.cmbPriority.Size = new System.Drawing.Size(104, 21);
            this.cmbPriority.TabIndex = 3;
            // 
            // GroupDataReadDlg
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(312, 149);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.cmbPriority,
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
            this.Name = "GroupDataReadDlg";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "GroupDataReadDlg";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.GroupDataReadDlg_Closing);
            this.Load += new System.EventHandler(this.GroupDataReadDlg_Load);
            this.ResumeLayout(false);

        }

        #endregion
    }
}