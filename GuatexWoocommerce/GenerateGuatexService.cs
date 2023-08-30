using GuatexWoocommerce.Database;
using GuatexWoocommerce.GuatexService;
using GuatexWoocommerce.Models;
using GuatexWoocommerce.WoocommerceApi;
using Microsoft.VisualBasic;
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
                .Select(f =>
                {
                    return new DataGridViewTextBoxColumn
                    {
                        Name = f.Name,
                        HeaderText = f.Title,
                        DataPropertyName = f.Name,
                        DefaultCellStyle = dgvCellStyle,
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                        MinimumWidth = f.Width,
                    };
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
            var runningTask = Task.Run(() =>
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
            if (await Task.WhenAny(runningTask, Task.Delay((int)TimeSpan.FromSeconds(30).TotalMilliseconds)) == runningTask)
            {
                List<string> departamentos = await runningTask;
                cmbDepartamento.Items.AddRange(departamentos.ToArray());
                cmbMunicipio.DataSource = null;
                cmbMunicipio.Enabled = false;
                SetLoading(false);
            }
            else
            {
                MessageBox.Show("Hubo un error cargando la información de Guatex, intente nuevamente en unos momentos");
                Close();
            }
        }

        private static string GenerateApiloDate()
        {
            return $"[{DateTime.Now:yyyy'-'MM'-'dd'T'HH':'mm':'ss}]";
        }

        private async void btnCrearActualizar_Click(object sender, EventArgs e)
        {
            string divider = "------------------------------------------------------------------------------------------------";
            List<string> errorLines = new()
            {
                divider
            };
            bool continueRunning = true;
            if (!txtClientAddress.Text.Trim().Equals(txtDireccion.Text.Trim()))
            {
                if (MessageBox.Show("¿Está seguro que desea generar el envío a una dirección diferente a la que ingresó el cliente?", "Generar Guía", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    continueRunning = false;
                }
            }
            errorLines.Add($"{GenerateApiloDate()} Dirección: '{txtDireccion.Text.Trim()}'");

            if (continueRunning)
            {
                Enabled = false;
                try
                {
                    Destino municipio = MunicipiosEncontrados.Destinos
                        .Where(x => x.Departamento == cmbDepartamento.Text)
                        .Where(x => x.Nombre == cmbMunicipio.Text)
                        .FirstOrDefault();
                    errorLines.Add($"{GenerateApiloDate()} Orden: '{_order.Id}'");
                    errorLines.Add($"{GenerateApiloDate()} Municipio: '{municipio.Municipio}'");
                    errorLines.Add($"{GenerateApiloDate()} Código de municipio: '{municipio.Codigo}'");

                    List<LineaDetalleGuia> detalleGuia = new();
                    detalleGuia = _order.LineItems
                        .Select(x =>
                        {
                            try
                            {

                                WoocommerceProduct product = ProductRequest.GetProduct(x.Sku)
                                    .GetAwaiter()
                                    .GetResult();
                                string peso = product.Weight;
                                bool falla = true;
                                if (string.IsNullOrEmpty(peso))
                                {
                                    int intentos = 0;
                                    while (intentos <= 3)
                                    {
                                        peso = Interaction.InputBox($"Ingrese peso en libras del producto con el sku {x.Sku}. Intento {intentos + 1}/4", "El producto no tiene peso registrado");
                                        try
                                        {
                                            Convert.ToDecimal(peso);
                                            intentos = 4;
                                            falla = false;
                                        }
                                        catch
                                        {
                                            MessageBox.Show("El peso ingresado no es válido, debe ser un numero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                        intentos++;
                                    }
                                }
                                if (falla)
                                {
                                    throw new ArgumentException("El peso ingresado no es válido, generación de guía cancelada");
                                }
                                var detalle = new LineaDetalleGuia()
                                {
                                    Cantidad = Convert.ToInt32(x.Quantity),
                                    Peso = Convert.ToDecimal(peso),
                                    TipoEnvio = "2"
                                };
                                errorLines.Add($"{GenerateApiloDate()} Id: '{product.Id}', Producto: '{product.Name}', Peso: '{peso}', Cantidad: '{x.Quantity}'");
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
                    errorLines.Add($"{GenerateApiloDate()} Enviado desde: '{sendFromAddress.Name}'");

                    string clientPhone = txtClientPhone.Text;
                    string clientId = txtClientId.Text;
                    string firstName = txtClientFirstName.Text;
                    string lastName = txtClientLastName.Text;
                    string phone = txtClientPhone.Text;
                    string address = txtDireccion.Text;
                    string orderNote = txtOrderNote.Text;
                    bool pickInOffice = cb_recogerOficina.Checked;
                    var runningTask = Task.Run(() =>
                    {
                        GuatexSolicitudServicio requestedService = servicio.Solicitar(
                            addressPhone: clientPhone,
                            sendFromAddress: sendFromAddress.FullAddress,
                            idMunicipalityFrom: sendFromAddress.MunicipalityId,
                            clientId: clientId,
                            codigoCobroGuia: Properties.Settings.Default["CodigoCobroTomaServicio"].ToString(),
                            clientName: $"{firstName} {lastName}",
                            clientPhone: clientPhone,
                            clientFullAddress: address,
                            clientMunicipalityId: municipio.Codigo,
                            description: orderNote,
                            pickInOffice: pickInOffice,
                            products: detalleGuia);
                        return requestedService;
                    });
                    if (await Task.WhenAny(runningTask, Task.Delay((int)TimeSpan.FromMinutes(5).TotalMilliseconds)) != runningTask)
                    {
                        Enabled = true;
                        Close();
                    }
                    GuatexSolicitudServicio servicioSolicitado = await runningTask;

                    errorLines.Add($"{GenerateApiloDate()} Solicitud de servicio: Ok");
                    var result = OrderRequest.UpdateOrder(
                            orderId: _order.Id.Value,
                            status: "completed");
                    errorLines.Add($"{GenerateApiloDate()} Actualización de estado de la orden: Ok");
                    string note = $@"Su número de guía Guatex es: {servicioSolicitado.Guias.First().Numero}, puede consultarla <a href='https://servicios.guatex.gt/Guatex/Tracking/'>aquí</a>.";
                    OrderRequest.AddNoteToOrder(
                            orderId: _order.Id.Value,
                            note: note);
                    errorLines.Add($"{GenerateApiloDate()} Nota agregada a la orden: '{note}'");
                    MessageBox.Show($"La guía se generó correctamente, el número de guía es: {servicioSolicitado.Guias.First().Numero}", "Guía generada", MessageBoxButtons.OK);
                    Enabled = true;
                    Close();
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    errorLines.Add($"{GenerateApiloDate()} Excepción: '{ex.Message}'");
                    errorLines.Add($"{GenerateApiloDate()} StackTrace: '{ex.StackTrace}'");
                    File.AppendAllLines("error.log", errorLines);
                    MessageBox.Show("Hubo un error inesperado");
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
