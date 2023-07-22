namespace GuatexWoocommerce
{
    partial class GenerateGuatexService
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
            menuStrip1 = new MenuStrip();
            archivoToolStripMenuItem = new ToolStripMenuItem();
            salirToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            lblStatus = new ToolStripStatusLabel();
            pb_loader = new ToolStripProgressBar();
            txtOrderId = new TextBox();
            lblId = new Label();
            groupBox1 = new GroupBox();
            txtOrderNote = new RichTextBox();
            label15 = new Label();
            label5 = new Label();
            txtOrderTotal = new TextBox();
            label4 = new Label();
            txtOrderShippingTotal = new TextBox();
            label3 = new Label();
            txtOrderCreatedDate = new TextBox();
            label2 = new Label();
            txtOrderStatus = new TextBox();
            label1 = new Label();
            txtOrderNumber = new TextBox();
            dgvOrderItems = new DataGridView();
            groupBox2 = new GroupBox();
            label12 = new Label();
            txtClientPostalCode = new TextBox();
            txtClientState = new TextBox();
            label13 = new Label();
            label14 = new Label();
            txtClientCity = new TextBox();
            label6 = new Label();
            txtClientAddress = new TextBox();
            label7 = new Label();
            txtClientEmail = new TextBox();
            label8 = new Label();
            txtClientPhone = new TextBox();
            label9 = new Label();
            txtClientLastName = new TextBox();
            label10 = new Label();
            txtClientFirstName = new TextBox();
            label11 = new Label();
            txtClientId = new TextBox();
            label16 = new Label();
            txtDireccion = new TextBox();
            label17 = new Label();
            label18 = new Label();
            cmbDepartamento = new ComboBox();
            cmbMunicipio = new ComboBox();
            btnCrearActualizar = new Button();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrderItems).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { archivoToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1199, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            archivoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { salirToolStripMenuItem });
            archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            archivoToolStripMenuItem.Size = new Size(60, 20);
            archivoToolStripMenuItem.Text = "Archivo";
            // 
            // salirToolStripMenuItem
            // 
            salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            salirToolStripMenuItem.Size = new Size(96, 22);
            salirToolStripMenuItem.Text = "Salir";
            salirToolStripMenuItem.Click += salirToolStripMenuItem_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblStatus, pb_loader });
            statusStrip1.Location = new Point(0, 723);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1199, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(39, 17);
            lblStatus.Text = "Status";
            lblStatus.Visible = false;
            // 
            // pb_loader
            // 
            pb_loader.MarqueeAnimationSpeed = 10;
            pb_loader.Name = "pb_loader";
            pb_loader.Size = new Size(100, 16);
            pb_loader.Style = ProgressBarStyle.Marquee;
            pb_loader.Visible = false;
            // 
            // txtOrderId
            // 
            txtOrderId.BackColor = SystemColors.ControlLightLight;
            txtOrderId.BorderStyle = BorderStyle.None;
            txtOrderId.Enabled = false;
            txtOrderId.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtOrderId.Location = new Point(177, 37);
            txtOrderId.Name = "txtOrderId";
            txtOrderId.Size = new Size(326, 22);
            txtOrderId.TabIndex = 19;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblId.Location = new Point(139, 37);
            lblId.Name = "lblId";
            lblId.Size = new Size(32, 25);
            lblId.TabIndex = 18;
            lblId.Text = "ID";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtOrderNote);
            groupBox1.Controls.Add(label15);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(txtOrderTotal);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtOrderShippingTotal);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtOrderCreatedDate);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtOrderStatus);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtOrderNumber);
            groupBox1.Controls.Add(lblId);
            groupBox1.Controls.Add(txtOrderId);
            groupBox1.Location = new Point(12, 36);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(530, 409);
            groupBox1.TabIndex = 20;
            groupBox1.TabStop = false;
            groupBox1.Text = "Información de la orden";
            // 
            // txtOrderNote
            // 
            txtOrderNote.BackColor = SystemColors.ControlLightLight;
            txtOrderNote.BorderStyle = BorderStyle.None;
            txtOrderNote.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtOrderNote.Location = new Point(177, 283);
            txtOrderNote.Name = "txtOrderNote";
            txtOrderNote.ReadOnly = true;
            txtOrderNote.Size = new Size(326, 104);
            txtOrderNote.TabIndex = 31;
            txtOrderNote.Text = "";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label15.Location = new Point(116, 283);
            label15.Name = "label15";
            label15.Size = new Size(55, 25);
            label15.TabIndex = 30;
            label15.Text = "Nota";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(118, 242);
            label5.Name = "label5";
            label5.Size = new Size(53, 25);
            label5.TabIndex = 28;
            label5.Text = "Total";
            // 
            // txtOrderTotal
            // 
            txtOrderTotal.BackColor = SystemColors.ControlLightLight;
            txtOrderTotal.BorderStyle = BorderStyle.None;
            txtOrderTotal.Enabled = false;
            txtOrderTotal.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtOrderTotal.Location = new Point(177, 242);
            txtOrderTotal.Name = "txtOrderTotal";
            txtOrderTotal.Size = new Size(326, 22);
            txtOrderTotal.TabIndex = 29;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(32, 201);
            label4.Name = "label4";
            label4.Size = new Size(139, 25);
            label4.TabIndex = 26;
            label4.Text = "Costo de envío";
            // 
            // txtOrderShippingTotal
            // 
            txtOrderShippingTotal.BackColor = SystemColors.ControlLightLight;
            txtOrderShippingTotal.BorderStyle = BorderStyle.None;
            txtOrderShippingTotal.Enabled = false;
            txtOrderShippingTotal.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtOrderShippingTotal.Location = new Point(177, 201);
            txtOrderShippingTotal.Name = "txtOrderShippingTotal";
            txtOrderShippingTotal.Size = new Size(326, 22);
            txtOrderShippingTotal.TabIndex = 27;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(6, 160);
            label3.Name = "label3";
            label3.Size = new Size(165, 25);
            label3.TabIndex = 24;
            label3.Text = "Fecha de creación";
            // 
            // txtOrderCreatedDate
            // 
            txtOrderCreatedDate.BackColor = SystemColors.ControlLightLight;
            txtOrderCreatedDate.BorderStyle = BorderStyle.None;
            txtOrderCreatedDate.Enabled = false;
            txtOrderCreatedDate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtOrderCreatedDate.Location = new Point(177, 160);
            txtOrderCreatedDate.Name = "txtOrderCreatedDate";
            txtOrderCreatedDate.Size = new Size(326, 22);
            txtOrderCreatedDate.TabIndex = 25;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(102, 119);
            label2.Name = "label2";
            label2.Size = new Size(69, 25);
            label2.TabIndex = 22;
            label2.Text = "Estado";
            // 
            // txtOrderStatus
            // 
            txtOrderStatus.BackColor = SystemColors.ControlLightLight;
            txtOrderStatus.BorderStyle = BorderStyle.None;
            txtOrderStatus.Enabled = false;
            txtOrderStatus.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtOrderStatus.Location = new Point(177, 119);
            txtOrderStatus.Name = "txtOrderStatus";
            txtOrderStatus.Size = new Size(326, 22);
            txtOrderStatus.TabIndex = 23;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(88, 78);
            label1.Name = "label1";
            label1.Size = new Size(83, 25);
            label1.TabIndex = 20;
            label1.Text = "Número";
            // 
            // txtOrderNumber
            // 
            txtOrderNumber.BackColor = SystemColors.ControlLightLight;
            txtOrderNumber.BorderStyle = BorderStyle.None;
            txtOrderNumber.Enabled = false;
            txtOrderNumber.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtOrderNumber.Location = new Point(177, 78);
            txtOrderNumber.Name = "txtOrderNumber";
            txtOrderNumber.Size = new Size(326, 22);
            txtOrderNumber.TabIndex = 21;
            // 
            // dgvOrderItems
            // 
            dgvOrderItems.AllowUserToAddRows = false;
            dgvOrderItems.AllowUserToDeleteRows = false;
            dgvOrderItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrderItems.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvOrderItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrderItems.Location = new Point(12, 451);
            dgvOrderItems.Name = "dgvOrderItems";
            dgvOrderItems.RowTemplate.Height = 25;
            dgvOrderItems.Size = new Size(619, 258);
            dgvOrderItems.TabIndex = 31;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label12);
            groupBox2.Controls.Add(txtClientPostalCode);
            groupBox2.Controls.Add(txtClientState);
            groupBox2.Controls.Add(label13);
            groupBox2.Controls.Add(label14);
            groupBox2.Controls.Add(txtClientCity);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(txtClientAddress);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(txtClientEmail);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(txtClientPhone);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(txtClientLastName);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(txtClientFirstName);
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(txtClientId);
            groupBox2.Location = new Point(548, 36);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(630, 409);
            groupBox2.TabIndex = 30;
            groupBox2.TabStop = false;
            groupBox2.Text = "Información del cliente";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label12.Location = new Point(36, 201);
            label12.Name = "label12";
            label12.Size = new Size(170, 25);
            label12.TabIndex = 34;
            label12.Text = "Correo electrónico";
            // 
            // txtClientPostalCode
            // 
            txtClientPostalCode.BackColor = SystemColors.ControlLightLight;
            txtClientPostalCode.BorderStyle = BorderStyle.None;
            txtClientPostalCode.Enabled = false;
            txtClientPostalCode.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtClientPostalCode.Location = new Point(212, 365);
            txtClientPostalCode.Name = "txtClientPostalCode";
            txtClientPostalCode.Size = new Size(392, 22);
            txtClientPostalCode.TabIndex = 35;
            // 
            // txtClientState
            // 
            txtClientState.BackColor = SystemColors.ControlLightLight;
            txtClientState.BorderStyle = BorderStyle.None;
            txtClientState.Enabled = false;
            txtClientState.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtClientState.Location = new Point(212, 324);
            txtClientState.Name = "txtClientState";
            txtClientState.Size = new Size(392, 22);
            txtClientState.TabIndex = 33;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label13.Location = new Point(20, 160);
            label13.Name = "label13";
            label13.Size = new Size(186, 25);
            label13.TabIndex = 32;
            label13.Text = "Número de teléfono";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label14.Location = new Point(76, 365);
            label14.Name = "label14";
            label14.Size = new Size(130, 25);
            label14.TabIndex = 30;
            label14.Text = "Código postal";
            // 
            // txtClientCity
            // 
            txtClientCity.BackColor = SystemColors.ControlLightLight;
            txtClientCity.BorderStyle = BorderStyle.None;
            txtClientCity.Enabled = false;
            txtClientCity.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtClientCity.Location = new Point(212, 283);
            txtClientCity.Name = "txtClientCity";
            txtClientCity.Size = new Size(392, 22);
            txtClientCity.TabIndex = 31;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(137, 324);
            label6.Name = "label6";
            label6.Size = new Size(69, 25);
            label6.TabIndex = 28;
            label6.Text = "Estado";
            // 
            // txtClientAddress
            // 
            txtClientAddress.BackColor = SystemColors.ControlLightLight;
            txtClientAddress.BorderStyle = BorderStyle.None;
            txtClientAddress.Enabled = false;
            txtClientAddress.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtClientAddress.Location = new Point(212, 242);
            txtClientAddress.Name = "txtClientAddress";
            txtClientAddress.Size = new Size(392, 22);
            txtClientAddress.TabIndex = 29;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(134, 283);
            label7.Name = "label7";
            label7.Size = new Size(72, 25);
            label7.TabIndex = 26;
            label7.Text = "Ciudad";
            // 
            // txtClientEmail
            // 
            txtClientEmail.BackColor = SystemColors.ControlLightLight;
            txtClientEmail.BorderStyle = BorderStyle.None;
            txtClientEmail.Enabled = false;
            txtClientEmail.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtClientEmail.Location = new Point(212, 201);
            txtClientEmail.Name = "txtClientEmail";
            txtClientEmail.Size = new Size(392, 22);
            txtClientEmail.TabIndex = 27;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label8.Location = new Point(113, 242);
            label8.Name = "label8";
            label8.Size = new Size(93, 25);
            label8.TabIndex = 24;
            label8.Text = "Dirección";
            // 
            // txtClientPhone
            // 
            txtClientPhone.BackColor = SystemColors.ControlLightLight;
            txtClientPhone.BorderStyle = BorderStyle.None;
            txtClientPhone.Enabled = false;
            txtClientPhone.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtClientPhone.Location = new Point(212, 160);
            txtClientPhone.Name = "txtClientPhone";
            txtClientPhone.Size = new Size(392, 22);
            txtClientPhone.TabIndex = 25;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label9.Location = new Point(123, 119);
            label9.Name = "label9";
            label9.Size = new Size(83, 25);
            label9.TabIndex = 22;
            label9.Text = "Apellido";
            // 
            // txtClientLastName
            // 
            txtClientLastName.BackColor = SystemColors.ControlLightLight;
            txtClientLastName.BorderStyle = BorderStyle.None;
            txtClientLastName.Enabled = false;
            txtClientLastName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtClientLastName.Location = new Point(212, 119);
            txtClientLastName.Name = "txtClientLastName";
            txtClientLastName.Size = new Size(392, 22);
            txtClientLastName.TabIndex = 23;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label10.Location = new Point(123, 78);
            label10.Name = "label10";
            label10.Size = new Size(83, 25);
            label10.TabIndex = 20;
            label10.Text = "Nombre";
            // 
            // txtClientFirstName
            // 
            txtClientFirstName.BackColor = SystemColors.ControlLightLight;
            txtClientFirstName.BorderStyle = BorderStyle.None;
            txtClientFirstName.Enabled = false;
            txtClientFirstName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtClientFirstName.Location = new Point(212, 78);
            txtClientFirstName.Name = "txtClientFirstName";
            txtClientFirstName.Size = new Size(392, 22);
            txtClientFirstName.TabIndex = 21;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label11.Location = new Point(174, 37);
            label11.Name = "label11";
            label11.Size = new Size(32, 25);
            label11.TabIndex = 18;
            label11.Text = "ID";
            // 
            // txtClientId
            // 
            txtClientId.BackColor = SystemColors.ControlLightLight;
            txtClientId.BorderStyle = BorderStyle.None;
            txtClientId.Enabled = false;
            txtClientId.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtClientId.Location = new Point(212, 37);
            txtClientId.Name = "txtClientId";
            txtClientId.Size = new Size(392, 22);
            txtClientId.TabIndex = 19;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label16.Location = new Point(702, 554);
            label16.Name = "label16";
            label16.Size = new Size(93, 25);
            label16.TabIndex = 36;
            label16.Text = "Dirección";
            // 
            // txtDireccion
            // 
            txtDireccion.BackColor = SystemColors.ControlLightLight;
            txtDireccion.BorderStyle = BorderStyle.None;
            txtDireccion.Enabled = false;
            txtDireccion.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtDireccion.Location = new Point(801, 557);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(351, 22);
            txtDireccion.TabIndex = 37;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label17.Location = new Point(697, 513);
            label17.Name = "label17";
            label17.Size = new Size(98, 25);
            label17.TabIndex = 34;
            label17.Text = "Municipio";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label18.Location = new Point(657, 472);
            label18.Name = "label18";
            label18.Size = new Size(138, 25);
            label18.TabIndex = 32;
            label18.Text = "Departamento";
            // 
            // cmbDepartamento
            // 
            cmbDepartamento.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDepartamento.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cmbDepartamento.FormattingEnabled = true;
            cmbDepartamento.ImeMode = ImeMode.Off;
            cmbDepartamento.Location = new Point(801, 472);
            cmbDepartamento.Name = "cmbDepartamento";
            cmbDepartamento.Size = new Size(351, 29);
            cmbDepartamento.TabIndex = 38;
            // 
            // cmbMunicipio
            // 
            cmbMunicipio.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMunicipio.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cmbMunicipio.FormattingEnabled = true;
            cmbMunicipio.ImeMode = ImeMode.Off;
            cmbMunicipio.Location = new Point(801, 513);
            cmbMunicipio.Name = "cmbMunicipio";
            cmbMunicipio.Size = new Size(351, 29);
            cmbMunicipio.TabIndex = 39;
            // 
            // btnCrearActualizar
            // 
            btnCrearActualizar.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnCrearActualizar.Location = new Point(989, 671);
            btnCrearActualizar.Name = "btnCrearActualizar";
            btnCrearActualizar.Size = new Size(163, 38);
            btnCrearActualizar.TabIndex = 40;
            btnCrearActualizar.Text = "Generar Guía";
            btnCrearActualizar.UseVisualStyleBackColor = true;
            // 
            // GenerateGuatexService
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1199, 745);
            Controls.Add(btnCrearActualizar);
            Controls.Add(cmbMunicipio);
            Controls.Add(cmbDepartamento);
            Controls.Add(label16);
            Controls.Add(txtDireccion);
            Controls.Add(label17);
            Controls.Add(label18);
            Controls.Add(dgvOrderItems);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "GenerateGuatexService";
            Text = "GenerateGuatexService";
            Load += GenerateGuatexService_Load;
            Shown += GenerateGuatexService_Shown;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrderItems).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private StatusStrip statusStrip1;
        private ToolStripMenuItem archivoToolStripMenuItem;
        private ToolStripMenuItem salirToolStripMenuItem;
        private ToolStripStatusLabel lblStatus;
        private ToolStripProgressBar pb_loader;
        private TextBox txtOrderId;
        private Label lblId;
        private GroupBox groupBox1;
        private Label label2;
        private TextBox txtOrderStatus;
        private Label label1;
        private TextBox txtOrderNumber;
        private Label label3;
        private TextBox txtOrderCreatedDate;
        private Label label5;
        private TextBox txtOrderTotal;
        private Label label4;
        private TextBox txtOrderShippingTotal;
        private GroupBox groupBox2;
        private Label label6;
        private TextBox txtClientAddress;
        private Label label7;
        private TextBox txtClientEmail;
        private Label label8;
        private TextBox txtClientPhone;
        private Label label9;
        private TextBox txtClientLastName;
        private Label label10;
        private TextBox txtClientFirstName;
        private Label label11;
        private TextBox txtClientId;
        private Label label12;
        private TextBox txtClientPostalCode;
        private Label label13;
        private TextBox txtClientState;
        private Label label14;
        private TextBox txtClientCity;
        private RichTextBox txtOrderNote;
        private Label label15;
        private DataGridView dgvOrderItems;
        private Label label16;
        private TextBox txtDireccion;
        private Label label17;
        private Label label18;
        private ComboBox cmbDepartamento;
        private ComboBox cmbMunicipio;
        private Button btnCrearActualizar;
    }
}