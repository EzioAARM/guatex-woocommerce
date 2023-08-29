namespace GuatexWoocommerce
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
            menuStrip1 = new MenuStrip();
            archivoToolStripMenuItem = new ToolStripMenuItem();
            btnImportarMenu = new ToolStripMenuItem();
            btnExportarMenu = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            btnSalirMenu = new ToolStripMenuItem();
            txtUrlTomarServicio = new TextBox();
            label12 = new Label();
            groupBox1 = new GroupBox();
            txtCodigoCobroServicio = new TextBox();
            label13 = new Label();
            txtPasswordServicio = new TextBox();
            label14 = new Label();
            txtUsernameServicio = new TextBox();
            label15 = new Label();
            txtNombreRemitente = new TextBox();
            label16 = new Label();
            woocommerceSettings.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            menuStrip1.SuspendLayout();
            groupBox1.SuspendLayout();
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
            woocommerceSettings.Location = new Point(12, 37);
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
            btn_save.Location = new Point(605, 1228);
            btn_save.Name = "btn_save";
            btn_save.Size = new Size(75, 23);
            btn_save.TabIndex = 2;
            btn_save.Text = "Guardar";
            btn_save.UseVisualStyleBackColor = true;
            btn_save.Click += btn_save_Click;
            // 
            // btn_cancel
            // 
            btn_cancel.Location = new Point(12, 1228);
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
            groupBox2.Location = new Point(12, 266);
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
            groupBox3.Location = new Point(12, 567);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(668, 285);
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
            statusStrip1.Location = new Point(0, 1268);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(704, 22);
            statusStrip1.SizingGrip = false;
            statusStrip1.TabIndex = 8;
            statusStrip1.Text = "statusStrip1";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { archivoToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(704, 24);
            menuStrip1.TabIndex = 10;
            menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            archivoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { btnImportarMenu, btnExportarMenu, toolStripSeparator1, btnSalirMenu });
            archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            archivoToolStripMenuItem.Size = new Size(60, 20);
            archivoToolStripMenuItem.Text = "Archivo";
            // 
            // btnImportarMenu
            // 
            btnImportarMenu.Name = "btnImportarMenu";
            btnImportarMenu.Size = new Size(120, 22);
            btnImportarMenu.Text = "Importar";
            btnImportarMenu.Click += btnImportarMenu_Click;
            // 
            // btnExportarMenu
            // 
            btnExportarMenu.Name = "btnExportarMenu";
            btnExportarMenu.Size = new Size(120, 22);
            btnExportarMenu.Text = "Exportar";
            btnExportarMenu.Click += btnExportarMenu_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(117, 6);
            // 
            // btnSalirMenu
            // 
            btnSalirMenu.Name = "btnSalirMenu";
            btnSalirMenu.Size = new Size(120, 22);
            btnSalirMenu.Text = "Salir";
            btnSalirMenu.Click += btnSalirMenu_Click;
            // 
            // txtUrlTomarServicio
            // 
            txtUrlTomarServicio.Location = new Point(29, 54);
            txtUrlTomarServicio.Name = "txtUrlTomarServicio";
            txtUrlTomarServicio.Size = new Size(611, 23);
            txtUrlTomarServicio.TabIndex = 19;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(29, 36);
            label12.Name = "label12";
            label12.Size = new Size(144, 15);
            label12.TabIndex = 18;
            label12.Text = "URL para toma de servicio";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtNombreRemitente);
            groupBox1.Controls.Add(label16);
            groupBox1.Controls.Add(txtCodigoCobroServicio);
            groupBox1.Controls.Add(label13);
            groupBox1.Controls.Add(txtPasswordServicio);
            groupBox1.Controls.Add(label14);
            groupBox1.Controls.Add(txtUsernameServicio);
            groupBox1.Controls.Add(label15);
            groupBox1.Controls.Add(label12);
            groupBox1.Controls.Add(txtUrlTomarServicio);
            groupBox1.Location = new Point(12, 858);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(668, 364);
            groupBox1.TabIndex = 16;
            groupBox1.TabStop = false;
            groupBox1.Text = "Servicio de Guatex";
            // 
            // txtCodigoCobroServicio
            // 
            txtCodigoCobroServicio.Location = new Point(29, 245);
            txtCodigoCobroServicio.Name = "txtCodigoCobroServicio";
            txtCodigoCobroServicio.Size = new Size(611, 23);
            txtCodigoCobroServicio.TabIndex = 25;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(29, 227);
            label13.Name = "label13";
            label13.Size = new Size(96, 15);
            label13.TabIndex = 24;
            label13.Text = "Código de cobro";
            // 
            // txtPasswordServicio
            // 
            txtPasswordServicio.Location = new Point(29, 181);
            txtPasswordServicio.Name = "txtPasswordServicio";
            txtPasswordServicio.PasswordChar = '*';
            txtPasswordServicio.Size = new Size(611, 23);
            txtPasswordServicio.TabIndex = 23;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(29, 163);
            label14.Name = "label14";
            label14.Size = new Size(67, 15);
            label14.TabIndex = 22;
            label14.Text = "Contraseña";
            // 
            // txtUsernameServicio
            // 
            txtUsernameServicio.Location = new Point(29, 117);
            txtUsernameServicio.Name = "txtUsernameServicio";
            txtUsernameServicio.Size = new Size(611, 23);
            txtUsernameServicio.TabIndex = 21;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(29, 99);
            label15.Name = "label15";
            label15.Size = new Size(109, 15);
            label15.TabIndex = 20;
            label15.Text = "Nombre de usuario";
            // 
            // txtNombreRemitente
            // 
            txtNombreRemitente.Location = new Point(29, 313);
            txtNombreRemitente.Name = "txtNombreRemitente";
            txtNombreRemitente.Size = new Size(611, 23);
            txtNombreRemitente.TabIndex = 27;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(29, 295);
            label16.Name = "label16";
            label16.Size = new Size(124, 15);
            label16.TabIndex = 26;
            label16.Text = "Nombre del remitente";
            // 
            // Preferences
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            AutoScrollMinSize = new Size(0, 500);
            ClientSize = new Size(704, 1290);
            Controls.Add(groupBox1);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(btn_cancel);
            Controls.Add(btn_save);
            Controls.Add(woocommerceSettings);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
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
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
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
        private MenuStrip menuStrip1;
        private ToolStripMenuItem archivoToolStripMenuItem;
        private ToolStripMenuItem btnImportarMenu;
        private ToolStripMenuItem btnExportarMenu;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem btnSalirMenu;
        private TextBox txtUrlTomarServicio;
        private Label label12;
        private TextBox txtCodigoCobroServicio;
        private Label label13;
        private TextBox txtPasswordServicio;
        private Label label14;
        private TextBox txtUsernameServicio;
        private Label label15;
        private TextBox txtNombreRemitente;
        private Label label16;
    }
}