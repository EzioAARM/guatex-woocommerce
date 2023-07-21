﻿namespace GuatexWoocommerce
{
    partial class Preferences
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Preferences));
            woocommerceSettings = new GroupBox();
            txt_consumer_secret = new TextBox();
            label3 = new Label();
            txt_consumer_key = new TextBox();
            label2 = new Label();
            txt_endpoint = new TextBox();
            label1 = new Label();
            btn_save = new Button();
            btn_cancel = new Button();
            groupBox2 = new GroupBox();
            txt_dbName = new TextBox();
            label7 = new Label();
            txt_dbPass = new TextBox();
            label4 = new Label();
            txt_dbUser = new TextBox();
            label5 = new Label();
            txt_dbHost = new TextBox();
            label6 = new Label();
            groupBox3 = new GroupBox();
            txtCodigoCobroMunicipios = new TextBox();
            label8 = new Label();
            txtPasswordMunicipios = new TextBox();
            label9 = new Label();
            txtUsernameMunicipios = new TextBox();
            label10 = new Label();
            txtUrlMunicipios = new TextBox();
            label11 = new Label();
            statusStrip1 = new StatusStrip();
            panel2 = new Panel();
            woocommerceSettings.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // woocommerceSettings
            // 
            woocommerceSettings.Controls.Add(txt_consumer_secret);
            woocommerceSettings.Controls.Add(label3);
            woocommerceSettings.Controls.Add(txt_consumer_key);
            woocommerceSettings.Controls.Add(label2);
            woocommerceSettings.Controls.Add(txt_endpoint);
            woocommerceSettings.Controls.Add(label1);
            woocommerceSettings.Location = new Point(12, 12);
            woocommerceSettings.Name = "woocommerceSettings";
            woocommerceSettings.Size = new Size(668, 223);
            woocommerceSettings.TabIndex = 0;
            woocommerceSettings.TabStop = false;
            woocommerceSettings.Text = "Woocommerce";
            // 
            // txt_consumer_secret
            // 
            txt_consumer_secret.Location = new Point(29, 179);
            txt_consumer_secret.Name = "txt_consumer_secret";
            txt_consumer_secret.Size = new Size(611, 23);
            txt_consumer_secret.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(29, 161);
            label3.Name = "label3";
            label3.Size = new Size(182, 15);
            label3.TabIndex = 4;
            label3.Text = "Woocommerce Consumer Secret";
            // 
            // txt_consumer_key
            // 
            txt_consumer_key.Location = new Point(29, 115);
            txt_consumer_key.Name = "txt_consumer_key";
            txt_consumer_key.Size = new Size(611, 23);
            txt_consumer_key.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(29, 97);
            label2.Name = "label2";
            label2.Size = new Size(169, 15);
            label2.TabIndex = 2;
            label2.Text = "Woocommerce Consumer Key";
            // 
            // txt_endpoint
            // 
            txt_endpoint.Location = new Point(29, 51);
            txt_endpoint.Name = "txt_endpoint";
            txt_endpoint.Size = new Size(611, 23);
            txt_endpoint.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 33);
            label1.Name = "label1";
            label1.Size = new Size(156, 15);
            label1.TabIndex = 0;
            label1.Text = "Endpoint de Woocommerce";
            // 
            // btn_save
            // 
            btn_save.Location = new Point(605, 1021);
            btn_save.Name = "btn_save";
            btn_save.Size = new Size(75, 23);
            btn_save.TabIndex = 2;
            btn_save.Text = "Guardar";
            btn_save.UseVisualStyleBackColor = true;
            btn_save.Click += btn_save_Click;
            // 
            // btn_cancel
            // 
            btn_cancel.Location = new Point(12, 1021);
            btn_cancel.Name = "btn_cancel";
            btn_cancel.Size = new Size(75, 23);
            btn_cancel.TabIndex = 3;
            btn_cancel.Text = "Cancelar";
            btn_cancel.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txt_dbName);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(txt_dbPass);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(txt_dbUser);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(txt_dbHost);
            groupBox2.Controls.Add(label6);
            groupBox2.Location = new Point(12, 254);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(668, 295);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "Base de datos";
            // 
            // txt_dbName
            // 
            txt_dbName.Location = new Point(29, 243);
            txt_dbName.Name = "txt_dbName";
            txt_dbName.Size = new Size(611, 23);
            txt_dbName.TabIndex = 7;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(29, 225);
            label7.Name = "label7";
            label7.Size = new Size(154, 15);
            label7.TabIndex = 6;
            label7.Text = "Nombre de la base de datos";
            // 
            // txt_dbPass
            // 
            txt_dbPass.Location = new Point(29, 179);
            txt_dbPass.Name = "txt_dbPass";
            txt_dbPass.PasswordChar = '*';
            txt_dbPass.Size = new Size(611, 23);
            txt_dbPass.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(29, 161);
            label4.Name = "label4";
            label4.Size = new Size(67, 15);
            label4.TabIndex = 4;
            label4.Text = "Contraseña";
            // 
            // txt_dbUser
            // 
            txt_dbUser.Location = new Point(29, 115);
            txt_dbUser.Name = "txt_dbUser";
            txt_dbUser.Size = new Size(611, 23);
            txt_dbUser.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(29, 97);
            label5.Name = "label5";
            label5.Size = new Size(109, 15);
            label5.TabIndex = 2;
            label5.Text = "Nombre de usuario";
            // 
            // txt_dbHost
            // 
            txt_dbHost.Location = new Point(29, 51);
            txt_dbHost.Name = "txt_dbHost";
            txt_dbHost.Size = new Size(611, 23);
            txt_dbHost.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(29, 33);
            label6.Name = "label6";
            label6.Size = new Size(32, 15);
            label6.TabIndex = 0;
            label6.Text = "Host";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(txtCodigoCobroMunicipios);
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(txtPasswordMunicipios);
            groupBox3.Controls.Add(label9);
            groupBox3.Controls.Add(txtUsernameMunicipios);
            groupBox3.Controls.Add(label10);
            groupBox3.Controls.Add(txtUrlMunicipios);
            groupBox3.Controls.Add(label11);
            groupBox3.Location = new Point(12, 555);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(668, 460);
            groupBox3.TabIndex = 7;
            groupBox3.TabStop = false;
            groupBox3.Text = "Servicio de Guatex";
            // 
            // txtCodigoCobroMunicipios
            // 
            txtCodigoCobroMunicipios.Location = new Point(29, 242);
            txtCodigoCobroMunicipios.Name = "txtCodigoCobroMunicipios";
            txtCodigoCobroMunicipios.Size = new Size(611, 23);
            txtCodigoCobroMunicipios.TabIndex = 15;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(29, 224);
            label8.Name = "label8";
            label8.Size = new Size(96, 15);
            label8.TabIndex = 14;
            label8.Text = "Código de cobro";
            // 
            // txtPasswordMunicipios
            // 
            txtPasswordMunicipios.Location = new Point(29, 178);
            txtPasswordMunicipios.Name = "txtPasswordMunicipios";
            txtPasswordMunicipios.PasswordChar = '*';
            txtPasswordMunicipios.Size = new Size(611, 23);
            txtPasswordMunicipios.TabIndex = 13;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(29, 160);
            label9.Name = "label9";
            label9.Size = new Size(67, 15);
            label9.TabIndex = 12;
            label9.Text = "Contraseña";
            // 
            // txtUsernameMunicipios
            // 
            txtUsernameMunicipios.Location = new Point(29, 114);
            txtUsernameMunicipios.Name = "txtUsernameMunicipios";
            txtUsernameMunicipios.Size = new Size(611, 23);
            txtUsernameMunicipios.TabIndex = 11;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(29, 96);
            label10.Name = "label10";
            label10.Size = new Size(109, 15);
            label10.TabIndex = 10;
            label10.Text = "Nombre de usuario";
            // 
            // txtUrlMunicipios
            // 
            txtUrlMunicipios.Location = new Point(29, 50);
            txtUrlMunicipios.Name = "txtUrlMunicipios";
            txtUrlMunicipios.Size = new Size(611, 23);
            txtUrlMunicipios.TabIndex = 9;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(29, 32);
            label11.Name = "label11";
            label11.Size = new Size(106, 15);
            label11.TabIndex = 8;
            label11.Text = "URL de municipios";
            // 
            // statusStrip1
            // 
            statusStrip1.Location = new Point(0, 1081);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(704, 22);
            statusStrip1.SizingGrip = false;
            statusStrip1.TabIndex = 8;
            statusStrip1.Text = "statusStrip1";
            // 
            // panel2
            // 
            panel2.Location = new Point(12, 1050);
            panel2.Name = "panel2";
            panel2.Size = new Size(668, 10);
            panel2.TabIndex = 9;
            // 
            // Preferences
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            AutoScrollMinSize = new Size(0, 500);
            ClientSize = new Size(704, 1103);
            Controls.Add(panel2);
            Controls.Add(statusStrip1);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(btn_cancel);
            Controls.Add(btn_save);
            Controls.Add(woocommerceSettings);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Preferences";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Preferencias";
            Load += Preferences_Load;
            woocommerceSettings.ResumeLayout(false);
            woocommerceSettings.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox woocommerceSettings;
        private TextBox txt_consumer_secret;
        private Label label3;
        private TextBox txt_consumer_key;
        private Label label2;
        private TextBox txt_endpoint;
        private Label label1;
        private GroupBox groupBox1;
        private Button btn_save;
        private Button btn_cancel;
        private Panel panel1;
        private GroupBox groupBox2;
        private TextBox txt_dbName;
        private Label label7;
        private TextBox txt_dbPass;
        private Label label4;
        private TextBox txt_dbUser;
        private Label label5;
        private TextBox txt_dbHost;
        private Label label6;
        private GroupBox groupBox3;
        private StatusStrip statusStrip1;
        private TextBox txtCodigoCobroMunicipios;
        private Label label8;
        private TextBox txtPasswordMunicipios;
        private Label label9;
        private TextBox txtUsernameMunicipios;
        private Label label10;
        private TextBox txtUrlMunicipios;
        private Label label11;
        private Panel panel2;
    }
}