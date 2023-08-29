namespace GuatexWoocommerce
{
    partial class GuatexSendings
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GuatexSendings));
            menuStrip1 = new MenuStrip();
            archivoToolStripMenuItem = new ToolStripMenuItem();
            administrarDireccionesToolStripMenuItem = new ToolStripMenuItem();
            preferenciasToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            salirToolStripMenuItem = new ToolStripMenuItem();
            txt_order = new TextBox();
            dgv_orders = new DataGridView();
            label1 = new Label();
            btnGenerarEnvio = new Button();
            btn_search = new Button();
            statusStrip1 = new StatusStrip();
            lblStatus = new ToolStripStatusLabel();
            pb_loader = new ToolStripProgressBar();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_orders).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { archivoToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1130, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            archivoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { administrarDireccionesToolStripMenuItem, preferenciasToolStripMenuItem, toolStripSeparator1, salirToolStripMenuItem });
            archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            archivoToolStripMenuItem.Size = new Size(60, 20);
            archivoToolStripMenuItem.Text = "Archivo";
            // 
            // administrarDireccionesToolStripMenuItem
            // 
            administrarDireccionesToolStripMenuItem.Name = "administrarDireccionesToolStripMenuItem";
            administrarDireccionesToolStripMenuItem.Size = new Size(200, 22);
            administrarDireccionesToolStripMenuItem.Text = "Administrar Direcciones";
            administrarDireccionesToolStripMenuItem.Click += administrarDireccionesToolStripMenuItem_Click;
            // 
            // preferenciasToolStripMenuItem
            // 
            preferenciasToolStripMenuItem.Name = "preferenciasToolStripMenuItem";
            preferenciasToolStripMenuItem.Size = new Size(200, 22);
            preferenciasToolStripMenuItem.Text = "Preferencias";
            preferenciasToolStripMenuItem.Click += preferenciasToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(197, 6);
            // 
            // salirToolStripMenuItem
            // 
            salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            salirToolStripMenuItem.Size = new Size(200, 22);
            salirToolStripMenuItem.Text = "Salir";
            salirToolStripMenuItem.Click += salirToolStripMenuItem_Click;
            // 
            // txt_order
            // 
            txt_order.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            txt_order.Location = new Point(218, 51);
            txt_order.Name = "txt_order";
            txt_order.PlaceholderText = "Número de orden";
            txt_order.Size = new Size(548, 34);
            txt_order.TabIndex = 2;
            txt_order.KeyUp += txt_order_KeyUp;
            txt_order.Leave += txt_order_Leave;
            // 
            // dgv_orders
            // 
            dgv_orders.AllowUserToAddRows = false;
            dgv_orders.AllowUserToDeleteRows = false;
            dgv_orders.AllowUserToOrderColumns = true;
            dgv_orders.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgv_orders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_orders.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgv_orders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgv_orders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_orders.Location = new Point(12, 103);
            dgv_orders.MultiSelect = false;
            dgv_orders.Name = "dgv_orders";
            dgv_orders.ReadOnly = true;
            dgv_orders.RowTemplate.Height = 25;
            dgv_orders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_orders.Size = new Size(1106, 400);
            dgv_orders.TabIndex = 3;
            dgv_orders.CellClick += dgv_orders_CellClick;
            dgv_orders.CellDoubleClick += dgv_orders_CellDoubleClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 54);
            label1.Name = "label1";
            label1.Size = new Size(200, 28);
            label1.TabIndex = 4;
            label1.Text = "Término de búsqueda";
            // 
            // btnGenerarEnvio
            // 
            btnGenerarEnvio.Enabled = false;
            btnGenerarEnvio.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            btnGenerarEnvio.Location = new Point(948, 52);
            btnGenerarEnvio.Name = "btnGenerarEnvio";
            btnGenerarEnvio.Size = new Size(170, 34);
            btnGenerarEnvio.TabIndex = 5;
            btnGenerarEnvio.Text = "Generar envío";
            btnGenerarEnvio.UseVisualStyleBackColor = true;
            btnGenerarEnvio.Click += btnGenerarEnvio_Click;
            // 
            // btn_search
            // 
            btn_search.Enabled = false;
            btn_search.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            btn_search.Location = new Point(772, 52);
            btn_search.Name = "btn_search";
            btn_search.Size = new Size(170, 34);
            btn_search.TabIndex = 7;
            btn_search.Text = "Buscar";
            btn_search.UseVisualStyleBackColor = true;
            btn_search.Click += btn_search_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblStatus, pb_loader });
            statusStrip1.Location = new Point(0, 527);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1130, 22);
            statusStrip1.SizingGrip = false;
            statusStrip1.TabIndex = 9;
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
            // GuatexSendings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1130, 549);
            Controls.Add(statusStrip1);
            Controls.Add(btn_search);
            Controls.Add(btnGenerarEnvio);
            Controls.Add(label1);
            Controls.Add(dgv_orders);
            Controls.Add(txt_order);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "GuatexSendings";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Envíos Guatex - Woocommerce";
            Load += GuatexSendings_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_orders).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem archivoToolStripMenuItem;
        private ToolStripMenuItem administrarDireccionesToolStripMenuItem;
        private ToolStripMenuItem preferenciasToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem salirToolStripMenuItem;
        private TextBox txt_order;
        private DataGridView dgv_orders;
        private Label label1;
        private Button btnGenerarEnvio;
        private Button btn_search;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblStatus;
        private ToolStripProgressBar pb_loader;
    }
}