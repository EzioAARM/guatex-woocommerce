using GuatexWoocommerce.Models;
using GuatexWoocommerce.WoocommerceApi;
using System.Reflection;

namespace GuatexWoocommerce
{
    public partial class GenerateGuatexService : Form
    {
        private readonly ulong _orderId;

        private WoocommerceOrder _order;

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

            LoadProducts(_order.LineItems);
            SetLoading(false);
        }
    }
}
