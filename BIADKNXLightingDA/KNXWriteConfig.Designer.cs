namespace BIADKNXLightingDA {
    partial class KNXWriteConfig {
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox_lessThan7Bit = new System.Windows.Forms.CheckBox();
            this.textBox_routingCount = new System.Windows.Forms.TextBox();
            this.comboBox_priority = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Routing Count:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Priority:";
            // 
            // checkBox_lessThan7Bit
            // 
            this.checkBox_lessThan7Bit.Location = new System.Drawing.Point(23, 82);
            this.checkBox_lessThan7Bit.Name = "checkBox_lessThan7Bit";
            this.checkBox_lessThan7Bit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox_lessThan7Bit.Size = new System.Drawing.Size(220, 24);
            this.checkBox_lessThan7Bit.TabIndex = 2;
            this.checkBox_lessThan7Bit.Text = ":Less than 7 bit";
            this.checkBox_lessThan7Bit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox_lessThan7Bit.UseVisualStyleBackColor = true;
            // 
            // textBox_routingCount
            // 
            this.textBox_routingCount.Location = new System.Drawing.Point(122, 21);
            this.textBox_routingCount.Name = "textBox_routingCount";
            this.textBox_routingCount.Size = new System.Drawing.Size(121, 20);
            this.textBox_routingCount.TabIndex = 3;
            this.textBox_routingCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_routingCount_KeyPress);
            // 
            // comboBox_priority
            // 
            this.comboBox_priority.FormattingEnabled = true;
            this.comboBox_priority.Items.AddRange(new object[] {
            "System",
            "High",
            "Alarm",
            "Low"});
            this.comboBox_priority.Location = new System.Drawing.Point(122, 54);
            this.comboBox_priority.Name = "comboBox_priority";
            this.comboBox_priority.Size = new System.Drawing.Size(121, 21);
            this.comboBox_priority.TabIndex = 4;
            this.comboBox_priority.Text = "Low";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(279, 58);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 24);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(279, 18);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(80, 24);
            this.btnOk.TabIndex = 13;
            this.btnOk.Text = "Ok";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // KNXWriteConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 124);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.comboBox_priority);
            this.Controls.Add(this.textBox_routingCount);
            this.Controls.Add(this.checkBox_lessThan7Bit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "KNXWriteConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "KNXWriteConfig";
            this.Load += new System.EventHandler(this.KNXWriteConfig_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox_lessThan7Bit;
        private System.Windows.Forms.TextBox textBox_routingCount;
        private System.Windows.Forms.ComboBox comboBox_priority;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
    }
}