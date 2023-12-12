using GuatexWoocommerce.Database;
using GuatexWoocommerce.GuatexService;
using GuatexWoocommerce.Models;
using GuatexWoocommerce.WoocommerceApi;
using Microsoft.VisualBasic;
using System.Drawing.Printing;
using System.Net;
using System.Reflection;

namespace GuatexWoocommerce
{
    public partial class GenerateGuatexService : Form
    {
        private readonly ulong _orderId;

        private WoocommerceOrder _order;

        private GuiasGeneradas _guiaEncontrada;

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

        /// <summary>
        /// Carga los productos del pedido en un datagridview
        /// </summary>
        /// <param name="products"></param>
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

        /// <summary>
        /// Coloca la el form en estado de carga
        /// </summary>
        /// <param name="loading">Indica si está cargando</param>
        /// <param name="loadingText">Texto de estado</param>
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

        private async void GenerateGuatexService_Shown(object sender, EventArgs e)
        {
            SetLoading(true, "Cargando información de la orden...");

            _order = await OrderRequest.GetOrderAsync(_orderId);
            if (_order.Status.Equals("completed"))
            {
                generate_panel.Visible = false;
            }
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
            }
            else
            {
                MessageBox.Show("Hubo un error cargando la información de Guatex, intente nuevamente en unos momentos");
                Close();
            }
            _guiaEncontrada = Program._context.Guias.FirstOrDefault(x => x.IdOrden == _orderId && !x.Anulada);
            if (_guiaEncontrada == null)
            {
                generate_panel.Visible = true;
                panelGuia.Visible = false;
            }
            else
            {
                generate_panel.Visible = false;
                panelGuia.Visible = true;
                GeneratePlz(
                    numero_guia: _guiaEncontrada.NumeroGuia,
                    remitente: _guiaEncontrada.Remitente,
                    direccion_remitente: _guiaEncontrada.DireccionRemitente,
                    telefono_remitente: _guiaEncontrada.TelefonoRemitente,
                    destinatario: _guiaEncontrada.Destinatario,
                    direccion_destinatario: _guiaEncontrada.DireccionDestinatario,
                    telefono_destinatario: _guiaEncontrada.TelefonoDestinatario,
                    descripcion_envio: _guiaEncontrada.DescripcionEnvio,
                    guia_actual: _guiaEncontrada.GuiaActual,
                    total_guias: _guiaEncontrada.TotalGuias,
                    cantidad_piezas: _guiaEncontrada.CantidadPiezas,
                    peso: _guiaEncontrada.PesoTotal,
                    forma_pago: _guiaEncontrada.FormaPago,
                    codigo_cobro: _guiaEncontrada.CodigoCobro,
                    fecha: _guiaEncontrada.Fecha,
                    codigoOrigen: _guiaEncontrada.CodigoOrigen,
                    codigoDestino: _guiaEncontrada.CodigoDestino);
            }
            SetLoading(false);
        }

        /// <summary>
        /// Genera una fecha en formato de apilo para log de errores
        /// </summary>
        /// <returns>Fecha en formato [{DateTime.Now:yyyy'-'MM'-'dd'T'HH':'mm':'ss}]</returns>
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
                                if (peso != "0" || !string.IsNullOrEmpty(peso))
                                    falla = false;
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
                                decimal weight = Convert.ToDecimal(peso) * Convert.ToInt32(x.Quantity);
                                int weightInt = Convert.ToInt32(weight);
                                var detalle = new LineaDetalleGuia()
                                {
                                    Cantidad = 1,
                                    Peso = weight > weightInt ? weightInt + 1 : weightInt,
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
                    LineaDetalleGuia finalDetalleGuia = new()
                    {
                        Cantidad = 1,
                        Peso = detalleGuia.Select(x => x.Peso).Sum(),
                        TipoEnvio = "2"
                    };
                    detalleGuia.Clear();
                    detalleGuia.Add(finalDetalleGuia);
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
                    // Solicita la generación de guía
                    var runningTask = Task.Run(() =>
                    {
                        GuatexSolicitudServicio requestedService = servicio.Solicitar(
                            addressPhone: $"{Properties.Settings.Default["TelefonoRemitente"]}",
                            sendFromAddress: $"{sendFromAddress.FullAddress}, {sendFromAddress.Municipality}, {sendFromAddress.Department}",
                            idMunicipalityFrom: sendFromAddress.MunicipalityId,
                            clientId: clientId,
                            codigoCobroGuia: Properties.Settings.Default["CodigoCobroTomaServicio"].ToString(),
                            clientName: $"{firstName} {lastName}",
                            clientPhone: clientPhone,
                            clientFullAddress: $"{address}, {municipio.Municipio}, {municipio.Departamento}",
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
                    string note = $@"Su número de guía Guatex es: {servicioSolicitado.Guias.First().Numero}, puede consultarla <a href='http://ws.guatex.gt/ConsultaWebPrm/Consultar.aspx?numerodeguia={servicioSolicitado.Codigo}'>aquí</a>.";
                    OrderRequest.AddNoteToOrder(
                            orderId: _order.Id.Value,
                            note: note);
                    errorLines.Add($"{GenerateApiloDate()} Nota agregada a la orden: '{note}'");
                    GuiasGeneradas guiaGenerada = new()
                    {
                        IdOrden = _order.Id.Value,
                        NumeroGuia = $"{servicioSolicitado.Guias.First().Numero}",
                        Remitente = $"{Properties.Settings.Default["NombreRemitente"]}",
                        DireccionRemitente = $"{sendFromAddress.FullAddress}, {sendFromAddress.Municipality}, {sendFromAddress.Department}",
                        TelefonoRemitente = $"{Properties.Settings.Default["TelefonoRemitente"]}",
                        Destinatario = $"{firstName} {lastName}",
                        DireccionDestinatario = $"{address}, {municipio.Municipio}, {municipio.Departamento}",
                        TelefonoDestinatario = $"{clientPhone}",
                        GuiaActual = $"1",
                        TotalGuias = $"1",
                        DescripcionEnvio = txtOrderNote.Text,
                        CantidadPiezas = $"1",
                        PesoTotal = $"{detalleGuia.Select(x => x.Peso).Sum()}",
                        FormaPago = $"CREDITO",
                        CodigoCobro = $"{Properties.Settings.Default["CodigoCobroTomaServicio"]}",
                        Fecha = $"{DateTime.Now:dd/MM/yyyy}",
                        Anulada = false,
                        CodigoDestino = municipio.PuntoCobertura,
                        CodigoOrigen = sendFromAddress.PuntoCobertura
                    };
                    Program._context.Guias.Add(guiaGenerada);
                    Program._context.SaveChanges();
                    MessageBox.Show($"La guía se generó correctamente, el número de guía es: {servicioSolicitado.Codigo}", "Guía generada", MessageBoxButtons.OK);
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    errorLines.Add($"{GenerateApiloDate()} Excepción: '{ex.Message}'");
                    errorLines.Add($"{GenerateApiloDate()} StackTrace: '{ex.StackTrace}'");
                    //File.AppendAllLines("error.log", errorLines);
                    MessageBox.Show("Hubo un error inesperado");
                }
                finally
                {
                    _guiaEncontrada = Program._context.Guias.FirstOrDefault(x => x.IdOrden == _orderId && !x.Anulada);
                    generate_panel.Visible = false;
                    panelGuia.Visible = true;
                    GeneratePlz(
                        numero_guia: _guiaEncontrada.NumeroGuia,
                        remitente: _guiaEncontrada.Remitente,
                        direccion_remitente: _guiaEncontrada.DireccionRemitente,
                        telefono_remitente: _guiaEncontrada.TelefonoRemitente,
                        destinatario: _guiaEncontrada.Destinatario,
                        direccion_destinatario: _guiaEncontrada.DireccionDestinatario,
                        telefono_destinatario: _guiaEncontrada.TelefonoDestinatario,
                        descripcion_envio: _guiaEncontrada.DescripcionEnvio,
                        guia_actual: _guiaEncontrada.GuiaActual,
                        total_guias: _guiaEncontrada.TotalGuias,
                        cantidad_piezas: _guiaEncontrada.CantidadPiezas,
                        peso: _guiaEncontrada.PesoTotal,
                        forma_pago: _guiaEncontrada.FormaPago,
                        codigo_cobro: _guiaEncontrada.CodigoCobro,
                        fecha: _guiaEncontrada.Fecha,
                        codigoOrigen: _guiaEncontrada.CodigoOrigen,
                        codigoDestino: _guiaEncontrada.CodigoDestino);
                    Enabled = true;
                }
            }
        }

        /// <summary>
        /// Genera la imágen de la guía en formato PLZ
        /// </summary>
        /// <param name="numero_guia">Número de la guía</param>
        /// <param name="remitente">Quien envía el paquete</param>
        /// <param name="direccion_remitente">Dirección desde donde se envía</param>
        /// <param name="telefono_remitente">Teléfono del remitente</param>
        /// <param name="destinatario">Quien recibe el paquete</param>
        /// <param name="direccion_destinatario">Dirección a la que se envía el paquete</param>
        /// <param name="telefono_destinatario">Teléfono del destinatario</param>
        /// <param name="descripcion_envio">Descripción de que contiene el pedido</param>
        /// <param name="guia_actual">Número de guía actual sobre la cantidad de guías a generar para este pedido</param>
        /// <param name="total_guias">Cantidad total de guías para este pedido</param>
        /// <param name="cantidad_piezas">Cantidad de piezas que se envían</param>
        /// <param name="peso">Peso del pedido</param>
        /// <param name="forma_pago"></param>
        /// <param name="codigo_cobro">Código de cobro de Guatex</param>
        /// <param name="fecha">Fecha que se realiza el envío</param>
        private void GeneratePlz(string numero_guia, string remitente, string direccion_remitente, string telefono_remitente,
            string destinatario, string direccion_destinatario, string telefono_destinatario,
            string descripcion_envio, string guia_actual, string total_guias, string cantidad_piezas,
            string peso, string forma_pago, string codigo_cobro, string fecha, string codigoOrigen, string codigoDestino)
        {
            if (direccion_destinatario.Length > 35)
            {
                direccion_destinatario = direccion_destinatario.Insert(35, "^FS^FO0,550,0^A0N,N,25,25^FH\\^FD");
            }
            if (direccion_remitente.Length > 35)
            {
                direccion_remitente = direccion_remitente.Insert(35, "^FS^FO0,295,0^A0N,N,25,25^FH\\^FD");
            }

            try
            {
                string plzText = @$"^XA^SZ2^PW609^LL1256^PON^PR6,6^PMN^MNY^LS-20^MTD^MMT,N^MPE^FS^JUS^LRN^CI0^FS^FO1,1,0^A0N,N,30,30^FD ^FS^FT1,160^BY3 ^A0N,40,30 ^BC,100,N,N,N,A^FD{numero_guia}^FS^FO3,170,0^AAN,N,15,15^FD{codigoOrigen} - {numero_guia}^FS^FO0,220,0^A0N,N,25,25^FDRemitente: {remitente} (CREDI^FS^FO0,245,0^A0N,N,25,25^FDTO)^FS^FO0,270,0^A0N,N,25,25^FH\\^FDDirección:{direccion_remitente}^FS^FO0,295,0^A0N,N,25,25^FH\\^FD{""}^FS^FO0,350,0^A0N,N,25,25^FH\\^FDTel\\82fono: {telefono_remitente}^FS^FO10,390,0^AAN,N,25,10^FD{numero_guia}^FS^FO340,350,0^IME:IMG.GRF,1,1^FS^FO0,475,0^A0N,N,25,25^FH\\^FDDestinatario: {destinatario}^FS^FO0,525,0^A0N,N,25,25^FH\\^FDDireccion:{direccion_destinatario}^FS^FO0,600,0^A0N,N,25,25^FH\\^FDTel\\82fono: {telefono_destinatario}^FS^FO45,625,0^A0N,N,250,70^FD{codigoDestino}^FS^LRY^FO230,1050,0^A0N,N,150,70^FD{guia_actual}/{total_guias}^FS^FO355,780,0^A0N,N,25,25^FD ^FS^FO10,830,0^A0N,N,20,24^FH\\^FDDesc. Env\\A1o: {descripcion_envio}^FS^FO0,930,0^A0N,N,24,24^FDNo. Piezas: {cantidad_piezas}   Peso: {peso}   Forma de pago :{forma_pago}   Co^FS^FO0,960,0^A0N,N,24,24^FDdigo de cobro:{codigo_cobro}   Fecha:   {fecha}^FS^FO0,1010,0^BQ,2,7^FDQA,{numero_guia}|{codigoDestino}^FS^FWN^XZ";
                string endpoint = $"http://api.labelary.com/v1/printers/8dpmm/labels/3x6/0/{plzText}";

                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(endpoint);
                HttpWebResponse response = (HttpWebResponse)req.GetResponse();

                Stream stream = response.GetResponseStream();
                System.Drawing.Image img = System.Drawing.Image.FromStream(stream);
                imagenGuia.BackgroundImage = img;
                if (!Directory.Exists("guias"))
                    Directory.CreateDirectory("guias");
                img.Save($"guias\\{numero_guia}.png");
                stream.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Hubo un error generando la guía, intente nuevamente en unos momentos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btn_ver_guia_Click(object sender, EventArgs e)
        {
            // Ver la imágen de la guía en la pantalla
            System.Diagnostics.Process.Start("explorer.exe", $"{Directory.GetCurrentDirectory()}\\guias\\{_guiaEncontrada.NumeroGuia}.png");
        }

        private void btnImprimirGuia_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new();
            pd.PrintPage += PrintPage;
            pd.DefaultPageSettings.PaperSize = new PaperSize("Custom", 609, 1256);
            PrintDialog printDialog = new()
            {
                Document = pd,
                AllowSomePages = false,
            };
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                pd.Print();
            }
        }
        private void PrintPage(object o, PrintPageEventArgs e)
        {
            System.Drawing.Image img = System.Drawing.Image.FromFile($"{Directory.GetCurrentDirectory()}\\guias\\{_guiaEncontrada.NumeroGuia}.png");
            System.Drawing.Point loc = new(0, 0);
            e.Graphics.DrawImage(img, loc);
        }

        private void btnCancelarGuia_Click(object sender, EventArgs e)
        {
            // Canclear la guía en Guatex y en la base de datos
            SetLoading(true, "Cancelando guía...");
            try
            {
                DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea cancelar la guía?", "Cancelar guía", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Servicio servicio = new();
                    servicio.Cancelar(_guiaEncontrada.NumeroGuia);
                    _guiaEncontrada.Anulada = true;
                    Program._context.Update(_guiaEncontrada);
                    Program._context.SaveChanges();

                    string note = $@"El envío de su pedido fue cancelado.";
                    OrderRequest.AddNoteToOrder(
                            orderId: _order.Id.Value,
                            note: note);

                    _guiaEncontrada = null;
                    generate_panel.Visible = true;
                    panelGuia.Visible = false;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                MessageBox.Show("No se pudo cancelar la guía", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SetLoading(false);
            }
        }
    }
}
