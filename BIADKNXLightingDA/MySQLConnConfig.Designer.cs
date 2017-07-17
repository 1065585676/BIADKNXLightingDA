namespace BIADKNXLightingDA
{
    partial class MySQLConnConfig
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button_change_mysql_connect_config = new System.Windows.Forms.Button();
            this.textBox_mysql_server_ip = new System.Windows.Forms.TextBox();
            this.textBox_mysql_user_id = new System.Windows.Forms.TextBox();
            this.textBox_mysql_password = new System.Windows.Forms.TextBox();
            this.textBox_mysql_database_name = new System.Windows.Forms.TextBox();
            this.textBox_mysql_table_name = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server IP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "User ID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Database name:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Table name:";
            // 
            // button_change_mysql_connect_config
            // 
            this.button_change_mysql_connect_config.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_change_mysql_connect_config.Location = new System.Drawing.Point(209, 150);
            this.button_change_mysql_connect_config.Name = "button_change_mysql_connect_config";
            this.button_change_mysql_connect_config.Size = new System.Drawing.Size(75, 23);
            this.button_change_mysql_connect_config.TabIndex = 5;
            this.button_change_mysql_connect_config.Text = "OK";
            this.button_change_mysql_connect_config.UseVisualStyleBackColor = true;
            this.button_change_mysql_connect_config.Click += new System.EventHandler(this.button_change_mysql_connect_config_Click);
            // 
            // textBox_mysql_server_ip
            // 
            this.textBox_mysql_server_ip.Location = new System.Drawing.Point(119, 16);
            this.textBox_mysql_server_ip.Name = "textBox_mysql_server_ip";
            this.textBox_mysql_server_ip.Size = new System.Drawing.Size(165, 20);
            this.textBox_mysql_server_ip.TabIndex = 6;
            this.textBox_mysql_server_ip.Text = "127.0.0.1";
            this.textBox_mysql_server_ip.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_mysql_user_id
            // 
            this.textBox_mysql_user_id.Location = new System.Drawing.Point(119, 42);
            this.textBox_mysql_user_id.Name = "textBox_mysql_user_id";
            this.textBox_mysql_user_id.Size = new System.Drawing.Size(165, 20);
            this.textBox_mysql_user_id.TabIndex = 7;
            this.textBox_mysql_user_id.Text = "ibms";
            this.textBox_mysql_user_id.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_mysql_password
            // 
            this.textBox_mysql_password.Location = new System.Drawing.Point(119, 68);
            this.textBox_mysql_password.Name = "textBox_mysql_password";
            this.textBox_mysql_password.Size = new System.Drawing.Size(165, 20);
            this.textBox_mysql_password.TabIndex = 8;
            this.textBox_mysql_password.Text = "toor";
            this.textBox_mysql_password.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_mysql_password.UseSystemPasswordChar = true;
            // 
            // textBox_mysql_database_name
            // 
            this.textBox_mysql_database_name.Location = new System.Drawing.Point(119, 94);
            this.textBox_mysql_database_name.Name = "textBox_mysql_database_name";
            this.textBox_mysql_database_name.Size = new System.Drawing.Size(165, 20);
            this.textBox_mysql_database_name.TabIndex = 9;
            this.textBox_mysql_database_name.Text = "ibmsappdb";
            this.textBox_mysql_database_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_mysql_table_name
            // 
            this.textBox_mysql_table_name.Location = new System.Drawing.Point(119, 120);
            this.textBox_mysql_table_name.Name = "textBox_mysql_table_name";
            this.textBox_mysql_table_name.Size = new System.Drawing.Size(165, 20);
            this.textBox_mysql_table_name.TabIndex = 10;
            this.textBox_mysql_table_name.Text = "knx_device";
            this.textBox_mysql_table_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MySQLConnConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 185);
            this.Controls.Add(this.textBox_mysql_table_name);
            this.Controls.Add(this.textBox_mysql_database_name);
            this.Controls.Add(this.textBox_mysql_password);
            this.Controls.Add(this.textBox_mysql_user_id);
            this.Controls.Add(this.textBox_mysql_server_ip);
            this.Controls.Add(this.button_change_mysql_connect_config);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MySQLConnConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MySQLConnConfig";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_change_mysql_connect_config;
        private System.Windows.Forms.TextBox textBox_mysql_server_ip;
        private System.Windows.Forms.TextBox textBox_mysql_user_id;
        private System.Windows.Forms.TextBox textBox_mysql_password;
        private System.Windows.Forms.TextBox textBox_mysql_database_name;
        private System.Windows.Forms.TextBox textBox_mysql_table_name;
    }
}