using GuatexWoocommerce.Models;
using GuatexWoocommerce.WoocommerceApi;
using System.Configuration;
using System.Reflection;

namespace GuatexWoocommerce
{
    public partial class GuatexSendings : Form
    {
        public bool IsRunning { get; set; } = false;

        public GuatexSendings()
        {
            InitializeComponent();
            DataGridViewCellStyle dgvCellStyle = new()
            {
                Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0)
            };
            DataGridViewTextBoxColumn[] woocommerceOrderFields = typeof(WoocommerceOrder)
                .GetProperties()
                .Where(x =>
                {
                    object[] attributes = x.GetCustomAttributes(true);
                    foreach (object attribute in attributes)
                    {
                        if (attribute is ModelAttributes modelAttribute)
                        {
                            return modelAttribute.IncludeInView;
                        }
                    }
                    return false;
                })
                .Select(x =>
                {
                    string name = x.Name;
                    int width = 100;
                    int position = 1;
                    string title = name;
                    object[] attributes = x.GetCustomAttributes(true);
                    foreach (object attribute in attributes)
                    {
                        if (attribute is ModelAttributes modelAttribute)
                        {
                            width = modelAttribute.Width;
                            position = modelAttribute.Position;
                            title = modelAttribute.Title;
                        }
                    }
                    return new
                    {
                        Name = name,
                        Width = width,
                        Position = position,
                        Title = title
                    };
                })
                .OrderBy(x => x.Position)
                .Select(f => new DataGridViewTextBoxColumn
                {
                    Name = f.Name,
                    HeaderText = f.Title,
                    DataPropertyName = f.Name,
                    DefaultCellStyle = dgvCellStyle,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                    MinimumWidth = f.Width,
                })
                .ToArray();
            dgv_orders.Columns.AddRange(woocommerceOrderFields);

            Program._context = new DatabaseContext();

            (string endpoint, string key, string secret) = Program.GetWoocommerceSettings();
            (string host, string user, string password, string database) = Program.GetMysqlSettings();
            (string urlMunicipios, string municipiosUsername, string municipiosPassword, string codigoCobro) = Program.GetGuatexMunicipiosSettings();
            (string urlServicio, string servicioUsername, string servicioPassword, string codigoCobroServicio) = Program.GetGuatexTomaServiciosSettings();
            if (string.IsNullOrEmpty(endpoint) || string.IsNullOrEmpty(key) || string.IsNullOrEmpty(secret) ||
                string.IsNullOrEmpty(host) || string.IsNullOrEmpty(user) || string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(database) || string.IsNullOrEmpty(urlMunicipios) || string.IsNullOrEmpty(municipiosUsername) ||
                string.IsNullOrEmpty(municipiosPassword) || string.IsNullOrEmpty(codigoCobro) || string.IsNullOrEmpty(urlServicio) ||
                string.IsNullOrEmpty(servicioUsername) || string.IsNullOrEmpty(servicioPassword) || string.IsNullOrEmpty(codigoCobroServicio))
            {
                _ = MessageBox.Show("Se deben configurar las credenciales para el correcto funcionamiento de la aplicación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Preferences settingsForm = new(displayIcon: true);
                _ = settingsForm.ShowDialog();
            }
        }

        private void administrarDireccionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txt_order.Clear();
            dgv_orders.Rows.Clear();
            Addresses addressesForm = new();
            _ = addressesForm.ShowDialog();
        }

        private void preferenciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Mostrar las configuraciones para conectar con Woocommerce y Guatex
            Preferences settingsForm = new();
            _ = settingsForm.ShowDialog();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult exitMessageResult = MessageBox.Show(
                text: "¿Seguro que desea salir?",
                caption: "Salir",
                buttons: MessageBoxButtons.YesNo,
                icon: MessageBoxIcon.Question);
            if (exitMessageResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        /// <summary>
        /// Ejecuta una busqueda en Woocommerce
        /// </summary>
        private async Task RunSearch()
        {
            try
            {
                SetLoading(true, "Buscando...");
                dgv_orders.Rows.Clear();
                if (txt_order.Text.Length <= 2)
                {
                    return;
                }
                List<WoocommerceOrder> orders = await OrderRequest.FindOrderAsync(txt_order.Text);
                int index = 0;
                foreach (WoocommerceOrder order in orders)
                {
                    _ = dgv_orders.Rows.Add(new DataGridViewRow());
                    foreach (PropertyInfo header in order.GetType().GetProperties())
                    {
                        if (dgv_orders.Columns.Contains(header.Name))
                        {
                            dgv_orders[header.Name, index] = new DataGridViewTextBoxCell
                            {
                                Value = order.GetType().GetProperty(header.Name).GetValue(order, null)
                            };
                        }
                    }
                    index++;
                }
            }
            catch (ConfigurationErrorsException ex)
            {
                _ = MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SetLoading(false);
            }
        }

        /// <summary>
        /// Coloca el form en el estado indicado y muestra el mensaje de carga
        /// </summary>
        /// <param name="loading">Indica si debe colocarse el form en estado de carga</param>
        /// <param name="loadingText">Texto a mostrar de estado</param>
        private void SetLoading(bool loading, string loadingText = "")
        {
            if (loading)
            {
                lblStatus.Text = loadingText;
                lblStatus.Visible = true;
                pb_loader.Visible = true;
                Enabled = false;
            }
            else
            {
                Enabled = true;
                lblStatus.Visible = false;
                pb_loader.Visible = false;
            }
        }

        /// <summary>
        /// Ejecuta la consulta en la página
        /// </summary>
        private async Task ExecuteRunner()
        {
            SetLoading(true, "Consultando información en la página...");
            if (!IsRunning)
            {
                IsRunning = true;
            }
            else
            {
                SetLoading(false);
                return;
            }
            await RunSearch();
            IsRunning = false;
            SetLoading(false);
        }

        private void btnGenerarEnvio_Click(object sender, EventArgs e)
        {
            Enabled = false;
            decimal d = decimal.Parse(dgv_orders.SelectedRows[0].Cells[0].Value.ToString());
            ulong u = (ulong)d;
            GenerateGuatexService generateGuatexService = new(u);
            _ = generateGuatexService.ShowDialog();
            Enabled = true;
        }

        private async void txt_order_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                await ExecuteRunner();
            }
            btn_search.Enabled = txt_order.Text.Length > 2;
        }

        private void txt_order_Leave(object sender, EventArgs e)
        {

        }

        private async void btn_search_Click(object sender, EventArgs e)
        {
            await ExecuteRunner();
        }

        private void dgv_orders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Enabled = false;
            decimal d = decimal.Parse(dgv_orders.SelectedRows[0].Cells[0].Value.ToString());
            ulong u = (ulong)d;
            GenerateGuatexService generateGuatexService = new(u);
            _ = generateGuatexService.ShowDialog();
            Enabled = true;
        }

        private void dgv_orders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnGenerarEnvio.Enabled = true;
        }

        private void GuatexSendings_Load(object sender, EventArgs e)
        {

        }
    }
}