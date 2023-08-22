using GuatexWoocommerce.Database;
using GuatexWoocommerce.GuatexService;
using GuatexWoocommerce.Models;
using GuatexWoocommerce.WoocommerceApi;
using System.Reflection;

namespace GuatexWoocommerce
{
    public partial class GenerateGuatexService : Form
    {
        private readonly ulong _orderId;

        private WoocommerceOrder _order;

        private GuatexConsultaMunicipios MunicipiosEncontrados = null;

        public GenerateGuatexService(ulong orderId)
        {
            InitializeComponent();
            _orderId = orderId;
            _order = null;

            DataGridViewCellStyle dgvCellStyle = new()
            {
                Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0)
            };
            DataGridViewTextBoxColumn[] addressFields = typeof(WoocommerceOrderLine)
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
            dgvOrderItems.Columns.AddRange(addressFields);

            List<Address> addressess = Program._context.Addresses
                .OrderBy(x => x.Id)
                .ToList();
            int position = -1;
            if (!string.IsNullOrEmpty(Properties.Settings.Default["DefaultAddressId"].ToString()))
            {
                int defaultAddressId = int.Parse(Properties.Settings.Default["DefaultAddressId"].ToString());
                var defaultAddress = addressess.SingleOrDefault(x => x.Id == defaultAddressId);
                if (defaultAddress != null)
                    position = addressess.IndexOf(defaultAddress);
            }
            cmbSendFrom.Items.AddRange(addressess.Select(x => x.Name).ToArray());
            cmbSendFrom.SelectedIndex = position;
        }

        private void LoadProducts(List<WoocommerceOrderLine> products)
        {
            dgvOrderItems.Rows.Clear();
            int index = 0;
            foreach (WoocommerceOrderLine product in products)
            {
                _ = dgvOrderItems.Rows.Add(new DataGridViewRow());
                foreach (PropertyInfo header in product.GetType().GetProperties())
                {
                    if (dgvOrderItems.Columns.Contains(header.Name))
                    {
                        dgvOrderItems[header.Name, index] = new DataGridViewTextBoxCell
                        {
                            Value = product.GetType().GetProperty(header.Name).GetValue(product, null)
                        };
                    }
                }
                index++;
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

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void GenerateGuatexService_Load(object sender, EventArgs e)
        {

        }

        private async void GenerateGuatexService_Shown(object sender, EventArgs e)
        {
            SetLoading(true, "Cargando información de la orden...");

            _order = await OrderRequest.GetOrderAsync(_orderId);
            txtOrderId.Text = _order.Id.ToString();
            txtOrderNumber.Text = _order.Number.ToString();
            txtOrderStatus.Text = _order.Status;
            DateTime convertedDate = DateTime.SpecifyKind(
                DateTime.Parse(_order.DateCreated.ToString()),
                DateTimeKind.Utc);
            txtOrderCreatedDate.Text = convertedDate.ToLocalTime().ToString();
            txtOrderShippingTotal.Text = _order.ShippingTotal.ToString();
            txtOrderTotal.Text = _order.Total.ToString();
            txtOrderNote.Text = _order.CustomerNote;

            txtClientId.Text = _order.CustomerId.ToString();
            txtClientFirstName.Text = _order.Shipping.FirstName;
            txtClientLastName.Text = _order.Shipping.LastName;
            txtClientPhone.Text = _order.Billing.Phone;
            txtClientEmail.Text = _order.Billing.Email;
            txtClientAddress.Text = _order.Shipping.Address1;
            txtClientCity.Text = _order.Shipping.City;
            txtClientState.Text = _order.Shipping.State;
            txtClientPostalCode.Text = _order.Shipping.Postcode;

            txtDireccion.Text = txtClientAddress.Text;

            LoadProducts(_order.LineItems);

            SetLoading(true, "Cargando información de municipios de Guatex...");
            List<string> departamentos = await Task.Run(() =>
            {
                Consultas consultas = new();
                MunicipiosEncontrados = consultas.ConsultaMunicipios();
                List<string> departamentos = MunicipiosEncontrados.Destinos
                    .Select(x => x.Departamento)
                    .Distinct()
                    .Where(x => !string.IsNullOrEmpty(x))
                    .ToList();
                return departamentos;
            });
            cmbDepartamento.Items.AddRange(departamentos.ToArray());
            cmbMunicipio.DataSource = null;
            cmbMunicipio.Enabled = false;
            SetLoading(false);
        }

        private void btnCrearActualizar_Click(object sender, EventArgs e)
        {
            bool continueRunning = true;
            if (!txtClientAddress.Text.Trim().Equals(txtDireccion.Text.Trim()))
            {
                if (MessageBox.Show("¿Está seguro que desea generar el envío a una dirección diferente a la que ingresó el cliente?", "Generar Guía", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    continueRunning = false;
                }
            }

            if (continueRunning)
            {
                Enabled = false;
                try
                {
                    Destino municipio = MunicipiosEncontrados.Destinos
                        .Where(x => x.Departamento == cmbDepartamento.Text)
                        .Where(x => x.Nombre == cmbMunicipio.Text)
                        .FirstOrDefault();

                    List<LineaDetalleGuia> detalleGuia = new();
                    detalleGuia = _order.LineItems
                        .Select(x =>
                        {
                            try
                            {

                                WoocommerceProduct product = ProductRequest.GetProduct(x.Sku)
                                    .GetAwaiter()
                                    .GetResult();
                                var detalle = new LineaDetalleGuia()
                                {
                                    Cantidad = Convert.ToInt32(x.Quantity),
                                    Peso = product.Weight.Value,
                                    TipoEnvio = "2"
                                };
                                return detalle;
                            }
                            catch (Exception)
                            {
                                throw;
                            }
                        })
                        .ToList();
                    Servicio servicio = new();
                    var sendFromAddress = Program._context.Addresses.Single(x => x.Name.Equals(cmbSendFrom.Text));
                    servicio.Solicitar(
                        addressPhone: txtClientPhone.Text,
                        sendFromAddress: sendFromAddress.FullAddress,
                        idMunicipalityFrom: sendFromAddress.MunicipalityId,
                        clientId: txtClientId.Text,
                        codigoCobroGuia: Properties.Settings.Default["CodigoCobroTomaServicio"].ToString(),
                        clientName: $"{txtClientFirstName.Text} {txtClientLastName.Text}",
                        clientPhone: txtClientPhone.Text,
                        clientFullAddress: txtDireccion.Text,
                        clientMunicipalityId: municipio.Codigo,
                        description: txtOrderNote.Text,
                        pickInOffice: cb_recogerOficina.Checked,
                        products: detalleGuia);
                }
                catch (Exception ex)
                {
                    string test = ex.Message;
                }
                finally
                {
                    Enabled = true;
                }
            }
        }

        private void cmbDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbMunicipio.Enabled = true;
            cmbMunicipio.Items.Clear();
            List<string> municipios = MunicipiosEncontrados.Destinos
                .Where(x => x.Departamento == cmbDepartamento.Text)
                .Where(x => x.RecogeOficina == cb_recogerOficina.Checked)
                .Select(x => x.Nombre)
                .Distinct()
                .Where(x => !string.IsNullOrEmpty(x))
                .ToList();
            cmbMunicipio.Items.AddRange(municipios.ToArray());
        }

        private void cb_recogerOficina_CheckedChanged(object sender, EventArgs e)
        {
            cmbDepartamento.SelectedIndex = -1;
            cmbMunicipio.SelectedIndex = -1;
            cmbMunicipio.Enabled = true;
            cmbMunicipio.Items.Clear();

            txtDireccion.Visible = !cb_recogerOficina.Checked;
            lblDireccion.Visible = !cb_recogerOficina.Checked;
        }
    }
}
