namespace GuatexWoocommerce
{
    partial class Addresses
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Addresses));
            dgv_addresses = new DataGridView();
            label1 = new Label();
            txtAddressName = new TextBox();
            txtAddressPhone = new TextBox();
            label2 = new Label();
            txtAddressFullAddress = new TextBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            cmbAddressDepartamento = new ComboBox();
            cmbAddressMunicipio = new ComboBox();
            btnCrearActualizar = new Button();
            menuStrip1 = new MenuStrip();
            opcionesToolStripMenuItem = new ToolStripMenuItem();
            limpiarYCrearNuevaDirecciónToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            salirToolStripMenuItem = new ToolStripMenuItem();
            gbInformacionDestino = new GroupBox();
            pbViewRecogeOficina = new PictureBox();
            txtViewFrecuenciaVisita = new TextBox();
            txtViewMunicipio = new TextBox();
            txtViewDepartamento = new TextBox();
            txtViewTipoTarifa = new TextBox();
            txtViewPuntoCobertura = new TextBox();
            txtViewNombre = new TextBox();
            txtViewCodigo = new TextBox();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            statusStrip1 = new StatusStrip();
            lblStatus = new ToolStripStatusLabel();
            pb_loader = new ToolStripProgressBar();
            lblId = new Label();
            txtId = new TextBox();
            btnClearAndAdd = new Button();
            cmsSelectedCellMenu = new ContextMenuStrip(components);
            tsmiSetAsDefault = new ToolStripMenuItem();
            tsmiEdit = new ToolStripMenuItem();
            tsmiDelete = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dgv_addresses).BeginInit();
            menuStrip1.SuspendLayout();
            gbInformacionDestino.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbViewRecogeOficina).BeginInit();
            statusStrip1.SuspendLayout();
            cmsSelectedCellMenu.SuspendLayout();
            SuspendLayout();
            // 
            // dgv_addresses
            // 
            dgv_addresses.AllowUserToAddRows = false;
            dgv_addresses.AllowUserToDeleteRows = false;
            dgv_addresses.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgv_addresses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_addresses.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv_addresses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_addresses.ContextMenuStrip = cmsSelectedCellMenu;
            dgv_addresses.Location = new Point(17, 336);
            dgv_addresses.MultiSelect = false;
            dgv_addresses.Name = "dgv_addresses";
            dgv_addresses.ReadOnly = true;
            dgv_addresses.RowTemplate.Height = 25;
            dgv_addresses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_addresses.Size = new Size(740, 253);
            dgv_addresses.TabIndex = 0;
            dgv_addresses.CellDoubleClick += dgv_addresses_CellDoubleClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(17, 86);
            label1.Name = "label1";
            label1.Size = new Size(212, 25);
            label1.TabIndex = 1;
            label1.Text = "Nombre de la dirección";
            // 
            // txtAddressName
            // 
            txtAddressName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtAddressName.Location = new Point(235, 86);
            txtAddressName.Name = "txtAddressName";
            txtAddressName.Size = new Size(522, 29);
            txtAddressName.TabIndex = 2;
            // 
            // txtAddressPhone
            // 
            txtAddressPhone.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtAddressPhone.Location = new Point(235, 128);
            txtAddressPhone.Name = "txtAddressPhone";
            txtAddressPhone.Size = new Size(522, 29);
            txtAddressPhone.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(43, 128);
            label2.Name = "label2";
            label2.Size = new Size(186, 25);
            label2.TabIndex = 3;
            label2.Text = "Número de teléfono";
            // 
            // txtAddressFullAddress
            // 
            txtAddressFullAddress.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtAddressFullAddress.Location = new Point(235, 170);
            txtAddressFullAddress.Name = "txtAddressFullAddress";
            txtAddressFullAddress.Size = new Size(522, 29);
            txtAddressFullAddress.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(136, 170);
            label3.Name = "label3";
            label3.Size = new Size(93, 25);
            label3.TabIndex = 5;
            label3.Text = "Dirección";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(91, 212);
            label4.Name = "label4";
            label4.Size = new Size(138, 25);
            label4.TabIndex = 7;
            label4.Text = "Departamento";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(131, 251);
            label5.Name = "label5";
            label5.Size = new Size(98, 25);
            label5.TabIndex = 9;
            label5.Text = "Municipio";
            // 
            // cmbAddressDepartamento
            // 
            cmbAddressDepartamento.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAddressDepartamento.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cmbAddressDepartamento.FormattingEnabled = true;
            cmbAddressDepartamento.ImeMode = ImeMode.Off;
            cmbAddressDepartamento.Location = new Point(235, 212);
            cmbAddressDepartamento.Name = "cmbAddressDepartamento";
            cmbAddressDepartamento.Size = new Size(522, 29);
            cmbAddressDepartamento.TabIndex = 10;
            cmbAddressDepartamento.SelectedIndexChanged += cmbAddressDepartamento_SelectedIndexChanged;
            // 
            // cmbAddressMunicipio
            // 
            cmbAddressMunicipio.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAddressMunicipio.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cmbAddressMunicipio.FormattingEnabled = true;
            cmbAddressMunicipio.Location = new Point(235, 251);
            cmbAddressMunicipio.Name = "cmbAddressMunicipio";
            cmbAddressMunicipio.Size = new Size(522, 29);
            cmbAddressMunicipio.TabIndex = 11;
            cmbAddressMunicipio.SelectedIndexChanged += cmbAddressMunicipio_SelectedIndexChanged;
            // 
            // btnCrearActualizar
            // 
            btnCrearActualizar.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnCrearActualizar.Location = new Point(594, 287);
            btnCrearActualizar.Name = "btnCrearActualizar";
            btnCrearActualizar.Size = new Size(163, 38);
            btnCrearActualizar.TabIndex = 12;
            btnCrearActualizar.Text = "Guardar cambios";
            btnCrearActualizar.UseVisualStyleBackColor = true;
            btnCrearActualizar.Click += btnCrearActualizar_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { opcionesToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1278, 24);
            menuStrip1.TabIndex = 13;
            menuStrip1.Text = "menuStrip1";
            // 
            // opcionesToolStripMenuItem
            // 
            opcionesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { limpiarYCrearNuevaDirecciónToolStripMenuItem, toolStripSeparator1, salirToolStripMenuItem });
            opcionesToolStripMenuItem.Name = "opcionesToolStripMenuItem";
            opcionesToolStripMenuItem.Size = new Size(69, 20);
            opcionesToolStripMenuItem.Text = "Opciones";
            // 
            // limpiarYCrearNuevaDirecciónToolStripMenuItem
            // 
            limpiarYCrearNuevaDirecciónToolStripMenuItem.Name = "limpiarYCrearNuevaDirecciónToolStripMenuItem";
            limpiarYCrearNuevaDirecciónToolStripMenuItem.Size = new Size(239, 22);
            limpiarYCrearNuevaDirecciónToolStripMenuItem.Text = "Limpiar y crear nueva dirección";
            limpiarYCrearNuevaDirecciónToolStripMenuItem.Click += limpiarYCrearNuevaDirecciónToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(236, 6);
            // 
            // salirToolStripMenuItem
            // 
            salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            salirToolStripMenuItem.Size = new Size(239, 22);
            salirToolStripMenuItem.Text = "Salir";
            salirToolStripMenuItem.Click += salirToolStripMenuItem_Click;
            // 
            // gbInformacionDestino
            // 
            gbInformacionDestino.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            gbInformacionDestino.Controls.Add(pbViewRecogeOficina);
            gbInformacionDestino.Controls.Add(txtViewFrecuenciaVisita);
            gbInformacionDestino.Controls.Add(txtViewMunicipio);
            gbInformacionDestino.Controls.Add(txtViewDepartamento);
            gbInformacionDestino.Controls.Add(txtViewTipoTarifa);
            gbInformacionDestino.Controls.Add(txtViewPuntoCobertura);
            gbInformacionDestino.Controls.Add(txtViewNombre);
            gbInformacionDestino.Controls.Add(txtViewCodigo);
            gbInformacionDestino.Controls.Add(label13);
            gbInformacionDestino.Controls.Add(label12);
            gbInformacionDestino.Controls.Add(label11);
            gbInformacionDestino.Controls.Add(label10);
            gbInformacionDestino.Controls.Add(label9);
            gbInformacionDestino.Controls.Add(label8);
            gbInformacionDestino.Controls.Add(label7);
            gbInformacionDestino.Controls.Add(label6);
            gbInformacionDestino.FlatStyle = FlatStyle.Popup;
            gbInformacionDestino.Location = new Point(776, 44);
            gbInformacionDestino.Name = "gbInformacionDestino";
            gbInformacionDestino.Size = new Size(490, 545);
            gbInformacionDestino.TabIndex = 14;
            gbInformacionDestino.TabStop = false;
            gbInformacionDestino.Text = "Información del destino";
            gbInformacionDestino.Visible = false;
            // 
            // pbViewRecogeOficina
            // 
            pbViewRecogeOficina.Location = new Point(205, 448);
            pbViewRecogeOficina.Name = "pbViewRecogeOficina";
            pbViewRecogeOficina.Size = new Size(25, 25);
            pbViewRecogeOficina.TabIndex = 15;
            pbViewRecogeOficina.TabStop = false;
            // 
            // txtViewFrecuenciaVisita
            // 
            txtViewFrecuenciaVisita.Enabled = false;
            txtViewFrecuenciaVisita.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtViewFrecuenciaVisita.Location = new Point(205, 389);
            txtViewFrecuenciaVisita.Name = "txtViewFrecuenciaVisita";
            txtViewFrecuenciaVisita.Size = new Size(270, 29);
            txtViewFrecuenciaVisita.TabIndex = 14;
            // 
            // txtViewMunicipio
            // 
            txtViewMunicipio.Enabled = false;
            txtViewMunicipio.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtViewMunicipio.Location = new Point(205, 330);
            txtViewMunicipio.Name = "txtViewMunicipio";
            txtViewMunicipio.Size = new Size(270, 29);
            txtViewMunicipio.TabIndex = 13;
            // 
            // txtViewDepartamento
            // 
            txtViewDepartamento.Enabled = false;
            txtViewDepartamento.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtViewDepartamento.Location = new Point(205, 271);
            txtViewDepartamento.Name = "txtViewDepartamento";
            txtViewDepartamento.Size = new Size(270, 29);
            txtViewDepartamento.TabIndex = 12;
            // 
            // txtViewTipoTarifa
            // 
            txtViewTipoTarifa.Enabled = false;
            txtViewTipoTarifa.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtViewTipoTarifa.Location = new Point(205, 212);
            txtViewTipoTarifa.Name = "txtViewTipoTarifa";
            txtViewTipoTarifa.Size = new Size(270, 29);
            txtViewTipoTarifa.TabIndex = 11;
            // 
            // txtViewPuntoCobertura
            // 
            txtViewPuntoCobertura.Enabled = false;
            txtViewPuntoCobertura.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtViewPuntoCobertura.Location = new Point(205, 153);
            txtViewPuntoCobertura.Name = "txtViewPuntoCobertura";
            txtViewPuntoCobertura.Size = new Size(270, 29);
            txtViewPuntoCobertura.TabIndex = 10;
            // 
            // txtViewNombre
            // 
            txtViewNombre.Enabled = false;
            txtViewNombre.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtViewNombre.Location = new Point(205, 94);
            txtViewNombre.Name = "txtViewNombre";
            txtViewNombre.Size = new Size(270, 29);
            txtViewNombre.TabIndex = 9;
            // 
            // txtViewCodigo
            // 
            txtViewCodigo.Enabled = false;
            txtViewCodigo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtViewCodigo.Location = new Point(205, 35);
            txtViewCodigo.Name = "txtViewCodigo";
            txtViewCodigo.Size = new Size(270, 29);
            txtViewCodigo.TabIndex = 8;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label13.Location = new Point(29, 448);
            label13.Name = "label13";
            label13.Size = new Size(170, 25);
            label13.TabIndex = 7;
            label13.Text = "Recoger en oficina";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label12.Location = new Point(19, 389);
            label12.Name = "label12";
            label12.Size = new Size(180, 25);
            label12.TabIndex = 6;
            label12.Text = "Frecuencia de visita";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label11.Location = new Point(101, 330);
            label11.Name = "label11";
            label11.Size = new Size(98, 25);
            label11.TabIndex = 5;
            label11.Text = "Municipio";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label10.Location = new Point(61, 271);
            label10.Name = "label10";
            label10.Size = new Size(138, 25);
            label10.TabIndex = 4;
            label10.Text = "Departamento";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label9.Location = new Point(73, 212);
            label9.Name = "label9";
            label9.Size = new Size(126, 25);
            label9.TabIndex = 3;
            label9.Text = "Tipo de tarifa";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label8.Location = new Point(21, 153);
            label8.Name = "label8";
            label8.Size = new Size(178, 25);
            label8.TabIndex = 2;
            label8.Text = "Punto de cobertura";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(116, 94);
            label7.Name = "label7";
            label7.Size = new Size(83, 25);
            label7.TabIndex = 1;
            label7.Text = "Nombre";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(126, 35);
            label6.Name = "label6";
            label6.Size = new Size(73, 25);
            label6.TabIndex = 0;
            label6.Text = "Código";
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblStatus, pb_loader });
            statusStrip1.Location = new Point(0, 595);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1278, 22);
            statusStrip1.SizingGrip = false;
            statusStrip1.TabIndex = 15;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(22, 17);
            lblStatus.Text = "Ok";
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
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblId.Location = new Point(197, 41);
            lblId.Name = "lblId";
            lblId.Size = new Size(32, 25);
            lblId.TabIndex = 16;
            lblId.Text = "ID";
            lblId.Visible = false;
            // 
            // txtId
            // 
            txtId.Enabled = false;
            txtId.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtId.Location = new Point(235, 41);
            txtId.Name = "txtId";
            txtId.Size = new Size(522, 29);
            txtId.TabIndex = 17;
            txtId.Visible = false;
            // 
            // btnClearAndAdd
            // 
            btnClearAndAdd.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnClearAndAdd.Location = new Point(17, 287);
            btnClearAndAdd.Name = "btnClearAndAdd";
            btnClearAndAdd.Size = new Size(163, 38);
            btnClearAndAdd.TabIndex = 18;
            btnClearAndAdd.Text = "Nueva dirección";
            btnClearAndAdd.UseVisualStyleBackColor = true;
            btnClearAndAdd.Click += btnClearAndAdd_Click;
            // 
            // cmsSelectedCellMenu
            // 
            cmsSelectedCellMenu.Items.AddRange(new ToolStripItem[] { tsmiEdit, tsmiSetAsDefault, tsmiDelete });
            cmsSelectedCellMenu.Name = "cmsSelectedCellMenu";
            cmsSelectedCellMenu.Size = new Size(189, 92);
            // 
            // tsmiSetAsDefault
            // 
            tsmiSetAsDefault.Name = "tsmiSetAsDefault";
            tsmiSetAsDefault.Size = new Size(188, 22);
            tsmiSetAsDefault.Text = "Dirección por defecto";
            // 
            // tsmiEdit
            // 
            tsmiEdit.Name = "tsmiEdit";
            tsmiEdit.Size = new Size(188, 22);
            tsmiEdit.Text = "Editar";
            // 
            // tsmiDelete
            // 
            tsmiDelete.Name = "tsmiDelete";
            tsmiDelete.Size = new Size(188, 22);
            tsmiDelete.Text = "Eliminar";
            // 
            // Addresses
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1278, 617);
            Controls.Add(btnClearAndAdd);
            Controls.Add(txtId);
            Controls.Add(lblId);
            Controls.Add(statusStrip1);
            Controls.Add(gbInformacionDestino);
            Controls.Add(btnCrearActualizar);
            Controls.Add(cmbAddressMunicipio);
            Controls.Add(cmbAddressDepartamento);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(txtAddressFullAddress);
            Controls.Add(label3);
            Controls.Add(txtAddressPhone);
            Controls.Add(label2);
            Controls.Add(txtAddressName);
            Controls.Add(label1);
            Controls.Add(dgv_addresses);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "Addresses";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Direcciones";
            Load += Addresses_Load;
            Shown += Addresses_Shown;
            ((System.ComponentModel.ISupportInitialize)dgv_addresses).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            gbInformacionDestino.ResumeLayout(false);
            gbInformacionDestino.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbViewRecogeOficina).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            cmsSelectedCellMenu.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgv_addresses;
        private Label label1;
        private TextBox txtAddressName;
        private TextBox txtAddressPhone;
        private Label label2;
        private TextBox txtAddressFullAddress;
        private Label label3;
        private Label label4;
        private Label label5;
        private ComboBox cmbAddressDepartamento;
        private ComboBox cmbAddressMunicipio;
        private Button btnCrearActualizar;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem opcionesToolStripMenuItem;
        private ToolStripMenuItem limpiarYCrearNuevaDirecciónToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem salirToolStripMenuItem;
        private GroupBox gbInformacionDestino;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblStatus;
        private ToolStripProgressBar pb_loader;
        private Label label7;
        private Label label6;
        private Label label13;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private TextBox txtViewFrecuenciaVisita;
        private TextBox txtViewMunicipio;
        private TextBox txtViewDepartamento;
        private TextBox txtViewTipoTarifa;
        private TextBox txtViewPuntoCobertura;
        private TextBox txtViewNombre;
        private TextBox txtViewCodigo;
        private PictureBox pbViewRecogeOficina;
        private Label lblId;
        private TextBox txtId;
        private Button btnClearAndAdd;
        private ContextMenuStrip cmsSelectedCellMenu;
        private ToolStripMenuItem tsmiEdit;
        private ToolStripMenuItem tsmiSetAsDefault;
        private ToolStripMenuItem tsmiDelete;
    }
}