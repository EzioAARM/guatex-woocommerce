using GuatexWoocommerce.Models;
using System.Reflection;
using WooCommerceNET;
using WooCommerceNET.WooCommerce.v3;

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
            (string endpoint, string key, string secret) = GetWoocommerceSettings();
            (string host, string user, string password, string database) = GetMysqlSettings();
            (string urlMunicipios, string municipiosUsername, string municipiosPassword, string codigoCobro) = GetGuatexMunicipiosSettings();
            if (string.IsNullOrEmpty(endpoint) || string.IsNullOrEmpty(key) || string.IsNullOrEmpty(secret) ||
                string.IsNullOrEmpty(host) || string.IsNullOrEmpty(user) || string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(database) || string.IsNullOrEmpty(urlMunicipios) || string.IsNullOrEmpty(municipiosUsername) ||
                string.IsNullOrEmpty(municipiosPassword) || string.IsNullOrEmpty(codigoCobro))
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

        private async Task RunSearch()
        {
            try
            {
                SetLoading(true, "Buscando...");
                if (txt_order.Text.Length <= 2)
                {
                    dgv_orders.DataSource = null;
                    return;
                }
                (string endpoint, string key, string secret) = GetWoocommerceSettings();
                if (string.IsNullOrEmpty(endpoint) || string.IsNullOrEmpty(key) || string.IsNullOrEmpty(secret))
                {
                    _ = MessageBox.Show("Debe configurar las credenciales de Woocommerce", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                RestAPI rest = new($"{endpoint}/wp-json/wc/v3/", key, secret);
                WCObject wc = new(rest);

                Console.WriteLine("Buscando");
                Task<List<Order>> orderRequest = wc.Order.GetAll(new Dictionary<string, string>
                    {
                        { "search", txt_order.Text },
                        { "per_page", "100" },
                        { "order", "desc" },
                        { "orderby", "date" }
                    });
                List<Order> requestedOrders = await orderRequest;
                if (requestedOrders.Count == 0)
                {
                    dgv_orders.Rows.Clear();
                }

                List<WoocommerceOrder> orders = requestedOrders
                    .Select(x => new WoocommerceOrder
                    {
                        Id = x.id,
                        ParentId = x.parent_id,
                        Number = x.number,
                        OrderKey = x.order_key,
                        CreatedVia = x.created_via,
                        Version = x.version,
                        Status = x.status,
                        Currency = x.currency,
                        DateCreated = x.date_created,
                        DateCreatedGmt = x.date_created_gmt,
                        DateModified = x.date_modified,
                        DateModifiedGmt = x.date_modified_gmt,
                        DiscountTotal = x.discount_total,
                        DiscountTax = x.discount_tax,
                        ShippingTotal = x.shipping_total,
                        ShippingTax = x.shipping_tax,
                        CartTax = x.cart_tax,
                        Total = x.total,
                        TotalTax = x.total_tax,
                        PricesIncludeTax = x.prices_include_tax,
                        CustomerId = x.customer_id,
                        CustomerIpAddress = x.customer_ip_address,
                        CustomerUserAgent = x.customer_user_agent,
                        CustomerNote = x.customer_note,
                        Billing = new WoocommerceBilling
                        {
                            FirstName = x.billing.first_name,
                            LastName = x.billing.last_name,
                            Company = x.billing.company,
                            Address1 = x.billing.address_1,
                            Address2 = x.billing.address_2,
                            City = x.billing.city,
                            State = x.billing.state,
                            Postcode = x.billing.postcode,
                            Country = x.billing.country,
                            Email = x.billing.email,
                            Phone = x.billing.phone
                        },
                        Shipping = new WoocommerceShipping
                        {
                            FirstName = x.shipping.first_name,
                            LastName = x.shipping.last_name,
                            Company = x.shipping.company,
                            Address1 = x.shipping.address_1,
                            Address2 = x.shipping.address_2,
                            City = x.shipping.city,
                            State = x.shipping.state,
                            Postcode = x.shipping.postcode,
                            Country = x.shipping.country
                        },
                        PaymentMethod = x.payment_method,
                        PaymentMethodTitle = x.payment_method_title,
                        TransactionId = x.transaction_id,
                        DatePaid = x.date_paid,
                        DatePaidGmt = x.date_paid_gmt,
                        DateCompleted = x.date_completed,
                        DateCompletedGmt = x.date_completed_gmt,
                        CartHash = x.cart_hash
                    })
                    .ToList();
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
            catch
            {
                Console.WriteLine("Error");
            }
            finally
            {
                SetLoading(false);
            }
        }

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

        private static (string endpoint, string key, string secret) GetWoocommerceSettings()
        {
            Properties.Settings settings = Properties.Settings.Default;
            string endpoint = settings["WoocommerceEndpoint"].ToString();
            string key = settings["WoocomerceConsumerKey"].ToString();
            string secret = settings["WoocommerceSecretKey"].ToString();

            return (endpoint, key, secret);
        }

        public static (string host, string user, string password, string database) GetMysqlSettings()
        {
            Properties.Settings settings = Properties.Settings.Default;
            string host = settings["MysqlHost"].ToString();
            string user = settings["MysqlUser"].ToString();
            string password = settings["MysqlPassword"].ToString();
            string database = settings["MysqlDatabase"].ToString();

            return (host, user, password, database);
        }

        public static (string urlMunicipios,
            string municipiosUsername,
            string municipiosPassword,
            string codigoCobro) GetGuatexMunicipiosSettings()
        {
            Properties.Settings settings = Properties.Settings.Default;
            string urlMunicipios = settings["UrlMunicipios"].ToString();
            string municipiosUsername = settings["UsuarioMunicipios"].ToString();
            string municipiosPassword = settings["PasswordMunicipios"].ToString();
            string codigoCobro = settings["CodigoCobroMunicipios"].ToString();

            return (urlMunicipios, municipiosUsername, municipiosPassword, codigoCobro);
        }

        private void btnGenerarEnvio_Click(object sender, EventArgs e)
        {
            _ = MessageBox.Show($"{dgv_orders.SelectedRows[0].Cells[0].Value}, {dgv_orders.SelectedRows[0].Cells[1].Value}, , {dgv_orders.SelectedRows[0].Cells[2].Value}");
        }

        private async void txt_order_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                await ExecuteRunner();
            }
            btn_search.Enabled = txt_order.Text.Length > 2;
        }

        private async void txt_order_Leave(object sender, EventArgs e)
        {
            await ExecuteRunner();
        }

        private async void btn_search_Click(object sender, EventArgs e)
        {
            await ExecuteRunner();
        }

        private void dgv_orders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _ = MessageBox.Show($"{dgv_orders.SelectedRows[0].Cells[0].Value}, {dgv_orders.SelectedRows[0].Cells[1].Value}, , {dgv_orders.SelectedRows[0].Cells[2].Value}");
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