using GuatexWoocommerce.Database;
using GuatexWoocommerce.GuatexService;
using GuatexWoocommerce.Models;
using System.Reflection;

namespace GuatexWoocommerce
{
    public partial class Addresses : Form
    {
        private GuatexConsultaMunicipios MunicipiosEncontrados = null;

        public Addresses()
        {
            InitializeComponent();
            DataGridViewCellStyle dgvCellStyle = new()
            {
                Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0)
            };
            DataGridViewTextBoxColumn[] addressFields = typeof(Address)
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
            dgv_addresses.Columns.AddRange(addressFields);
        }

        private void LoadAddresses(Address[] addressList)
        {
            dgv_addresses.Rows.Clear();
            int index = 0;
            foreach (Address address in addressList)
            {
                _ = dgv_addresses.Rows.Add(new DataGridViewRow());
                foreach (PropertyInfo header in address.GetType().GetProperties())
                {
                    if (dgv_addresses.Columns.Contains(header.Name))
                    {
                        dgv_addresses[header.Name, index] = new DataGridViewTextBoxCell
                        {
                            Value = address.GetType().GetProperty(header.Name).GetValue(address, null)
                        };
                    }
                }
                index++;
            }
        }

        private void cmbAddressDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbAddressMunicipio.Enabled = true;
            cmbAddressMunicipio.Items.Clear();
            List<string> municipios = MunicipiosEncontrados.Destinos
                .Where(x => x.Departamento == cmbAddressDepartamento.Text)
                .Select(x => x.Nombre)
                .Distinct()
                .Where(x => !string.IsNullOrEmpty(x))
                .ToList();
            cmbAddressMunicipio.Items.AddRange(municipios.ToArray());
        }

        private void Addresses_Load(object sender, EventArgs e)
        {

        }

        private void ClearInputs()
        {
            txtAddressName.Clear();
            txtAddressPhone.Clear();
            txtAddressFullAddress.Clear();
            txtId.Clear();
            txtId.Visible = false;
            lblId.Visible = false;
            cmbAddressDepartamento.SelectedIndex = -1;
            cmbAddressDepartamento.Text = "";
            cmbAddressMunicipio.SelectedIndex = -1;
            cmbAddressMunicipio.Text = "";
            btnCrearActualizar.Text = "Guardar cambios";
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void limpiarYCrearNuevaDirecciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtAddressName.Clear();
            txtAddressPhone.Clear();
            txtAddressFullAddress.Clear();

            cmbAddressDepartamento.SelectedIndex = -1;
            cmbAddressDepartamento.Text = "";
            cmbAddressMunicipio.SelectedIndex = -1;
            cmbAddressMunicipio.Text = "";
        }

        private async void Addresses_Shown(object sender, EventArgs e)
        {
            SetLoading(true, "Consultando información en GUATEX...");

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

                cmbAddressDepartamento.Items.AddRange(departamentos.ToArray());
                cmbAddressMunicipio.DataSource = null;
                cmbAddressMunicipio.Enabled = false;

                SetLoading(true, "Consultando direcciones existentes...");

                Address[] addressList = await Task.Run(() =>
                {
                    return Program._context
                        .Addresses
                        .ToArray();
                });
                LoadAddresses(addressList);

                SetLoading(false);
            }
            else
            {
                MessageBox.Show("No se pudo conectar con el servidor de GUATEX, intente de nuevo más tarde.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void cmbAddressMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {
            gbInformacionDestino.Visible = true;
            string departamento = cmbAddressDepartamento.Text;
            string municipio = cmbAddressMunicipio.Text;

            Destino destino = MunicipiosEncontrados.Destinos
                .Where(x => x.Departamento == departamento && x.Nombre == municipio)
                .FirstOrDefault();
            if (destino == null)
            {
                return;
            }
            txtViewCodigo.Text = destino.Codigo.ToString();
            txtViewNombre.Text = destino.Nombre;
            txtViewPuntoCobertura.Text = destino.PuntoCobertura;
            txtViewTipoTarifa.Text = destino.TipoTarifa;
            txtViewDepartamento.Text = $"{destino.Departamento} ({destino.Depto})";
            txtViewMunicipio.Text = $"{destino.Municipio} ({destino.Codigo})";
            txtViewFrecuenciaVisita.Text = destino.FrecuenciaVisita;
            pbViewRecogeOficina.BackColor = destino.RecogeOficina ? System.Drawing.Color.Green : System.Drawing.Color.Red;
        }

        private async Task CrearDireccion(string name, string phone, string fullAddress, string department,
            int departmentId, string municipality, int municipalityId, string puntoCobertura)
        {
            var runningTask = Task.Run(() =>
            {
                if (Program._context.Addresses.Any(x => x.Name.ToUpper().Equals(name.ToUpper())))
                {
                    _ = MessageBox.Show("Ya existe una dirección con el mismo nombre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                _ = Program._context.Addresses.Add(new Address
                {
                    Name = name,
                    Phone = phone,
                    FullAddress = fullAddress,
                    Department = department,
                    DepartmentId = departmentId,
                    Municipality = municipality,
                    MunicipalityId = municipalityId,
                    PuntoCobertura = puntoCobertura
                });
                _ = Program._context.SaveChanges();
            });
            if (await Task.WhenAny(runningTask, Task.Delay((int)TimeSpan.FromSeconds(30).TotalMilliseconds)) == runningTask)
            {
                await runningTask;
            }
            else
            {
                MessageBox.Show("Hubo un problema creando la dirección", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private async Task ActualizarDireccion(int id, string name, string phone, string fullAddress, string department,
            int departmentId, string municipality, int municipalityId, string puntoCobertura)
        {
            var runningTask = Task.Run(() =>
            {
                Address address = Program._context.Addresses.FirstOrDefault(x => x.Id == id);
                if (address == null)
                {
                    _ = MessageBox.Show("No se encontró la dirección", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                address.Name = name;
                address.Phone = phone;
                address.FullAddress = fullAddress;
                address.Department = department;
                address.DepartmentId = departmentId;
                address.Municipality = municipality;
                address.MunicipalityId = municipalityId;
                address.PuntoCobertura = puntoCobertura;
                _ = Program._context.Addresses.Update(address);
                _ = Program._context.SaveChanges();
            });
            if (await Task.WhenAny(runningTask, Task.Delay((int)TimeSpan.FromSeconds(30).TotalMilliseconds)) == runningTask)
            {
                await runningTask;
            }
            else
            {
                MessageBox.Show("Hubo un problema actualizando la dirección", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
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

        private async void btnCrearActualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAddressName.Text))
            {
                _ = MessageBox.Show("El nombre es requerido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtAddressPhone.Text))
            {
                _ = MessageBox.Show("El teléfono es requerido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtAddressFullAddress.Text))
            {
                _ = MessageBox.Show("La dirección es requerida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(cmbAddressDepartamento.Text))
            {
                _ = MessageBox.Show("El departamento es requerido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(cmbAddressMunicipio.Text))
            {
                _ = MessageBox.Show("El municipio es requerido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtId.Text == "" && !txtId.Visible)
            {
                SetLoading(true, "Creando dirección");
                string name = txtAddressName.Text;
                string phone = txtAddressPhone.Text;
                string fullAddress = txtAddressFullAddress.Text;
                string department = cmbAddressDepartamento.Text;
                int departmentId = (int)MunicipiosEncontrados.Destinos
                    .Where(x => !string.IsNullOrEmpty(x.Departamento))
                    .Where(x => x.Departamento.Equals(cmbAddressDepartamento.Text))
                    .FirstOrDefault()
                    .Depto;
                string municipality = cmbAddressMunicipio.Text;
                int municipalityId = MunicipiosEncontrados.Destinos
                    .Where(x => !string.IsNullOrEmpty(x.Departamento) && !string.IsNullOrEmpty(x.Nombre))
                    .Where(x => x.Departamento.Equals(cmbAddressDepartamento.Text) && x.Nombre.Equals(cmbAddressMunicipio.Text))
                    .FirstOrDefault()
                    .Codigo;
                string puntoCobertura = MunicipiosEncontrados.Destinos
                    .Where(x => !string.IsNullOrEmpty(x.Departamento) && !string.IsNullOrEmpty(x.Nombre))
                    .Where(x => x.Departamento.Equals(cmbAddressDepartamento.Text) && x.Nombre.Equals(cmbAddressMunicipio.Text))
                    .FirstOrDefault()
                    .PuntoCobertura;
                await Task.Run(() => CrearDireccion(name, phone, fullAddress, department, departmentId, municipality, municipalityId, puntoCobertura));
                Address[] addressList = await Task.Run(() =>
                {
                    return Program._context
                        .Addresses
                        .ToArray();
                });
                LoadAddresses(addressList);
            }
            else
            {
                SetLoading(true, "Actualizando dirección");
                int id = int.Parse(txtId.Text);
                string name = txtAddressName.Text;
                string phone = txtAddressPhone.Text;
                string fullAddress = txtAddressFullAddress.Text;
                string department = cmbAddressDepartamento.Text;
                int departmentId = (int)MunicipiosEncontrados.Destinos
                    .Where(x => !string.IsNullOrEmpty(x.Departamento))
                    .Where(x => x.Departamento.Equals(cmbAddressDepartamento.Text))
                    .FirstOrDefault()
                    .Depto;
                string municipality = cmbAddressMunicipio.Text;
                int municipalityId = MunicipiosEncontrados.Destinos
                    .Where(x => !string.IsNullOrEmpty(x.Departamento) && !string.IsNullOrEmpty(x.Nombre))
                    .Where(x => x.Departamento.Equals(cmbAddressDepartamento.Text) && x.Nombre.Equals(cmbAddressMunicipio.Text))
                    .FirstOrDefault()
                    .Codigo;
                string puntoCobertura = MunicipiosEncontrados.Destinos
                    .Where(x => !string.IsNullOrEmpty(x.Departamento) && !string.IsNullOrEmpty(x.Nombre))
                    .Where(x => x.Departamento.Equals(cmbAddressDepartamento.Text) && x.Nombre.Equals(cmbAddressMunicipio.Text))
                    .FirstOrDefault()
                    .PuntoCobertura;
                await Task.Run(() => ActualizarDireccion(id, name, phone, fullAddress, department, departmentId, municipality, municipalityId, puntoCobertura));
                Address[] addressList = await Task.Run(() =>
                {
                    return Program._context
                        .Addresses
                        .ToArray();
                });
                LoadAddresses(addressList);
            }
            ClearInputs();
            SetLoading(false);
        }

        private void dgv_addresses_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Cargar data para editarla
            if (e.RowIndex < 0)
            {
                return;
            }
            DataGridViewRow row = dgv_addresses.Rows[e.RowIndex];
            txtId.Text = row.Cells[0].Value.ToString();
            lblId.Visible = true;
            txtId.Visible = true;
            txtAddressName.Text = row.Cells[1].Value.ToString();
            txtAddressPhone.Text = row.Cells[2].Value.ToString();
            txtAddressFullAddress.Text = row.Cells[3].Value.ToString();
            cmbAddressDepartamento.SelectedItem = row.Cells[4].Value.ToString();
            cmbAddressMunicipio.SelectedItem = row.Cells[5].Value.ToString();
            btnCrearActualizar.Text = "Actualizar";
        }

        private void btnClearAndAdd_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void tsmiEdit_Click(object sender, EventArgs e)
        {
            // Cargar data para editarla
            DataGridViewRow row = dgv_addresses.SelectedRows[0];
            txtId.Text = row.Cells[0].Value.ToString();
            lblId.Visible = true;
            txtId.Visible = true;
            txtAddressName.Text = row.Cells[1].Value.ToString();
            txtAddressPhone.Text = row.Cells[2].Value.ToString();
            txtAddressFullAddress.Text = row.Cells[3].Value.ToString();
            cmbAddressDepartamento.SelectedItem = row.Cells[4].Value.ToString();
            cmbAddressMunicipio.SelectedItem = row.Cells[5].Value.ToString();
            btnCrearActualizar.Text = "Actualizar";
        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            DialogResult confirmResult = MessageBox.Show("¿Está seguro que desea eliminar la dirección?", "Confirmar acción", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (confirmResult == DialogResult.OK)
            {
                // Eliminar data
                SetLoading(true, "Eliminando dirección");
                DataGridViewRow row = dgv_addresses.SelectedRows[0];
                int id = int.Parse(row.Cells[0].Value.ToString());
                Address address = Program._context.Addresses.SingleOrDefault(x => x.Id == id);
                if (address != null)
                {
                    _ = Program._context.Addresses.Remove(address);
                    _ = Program._context.SaveChanges();
                }
                Address[] addressList = Program._context.Addresses.ToArray();
                LoadAddresses(addressList);
                SetLoading(false);
            }
        }

        private void tsmiSetAsDefault_Click(object sender, EventArgs e)
        {
            DialogResult confirmResult = MessageBox.Show(
                "¿Está seguro que desea establecer la dirección como predeterminada? \n\nSi está de acuerdo todos los pedidos se enviarán por defecto de esta dirección, aunque siempre podrá modificar la dirección en la generación del pedido", "Confirmar acción", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (confirmResult == DialogResult.OK)
            {
                // Establecer como predeterminada
                SetLoading(true, "Estableciendo dirección como predeterminada");
                DataGridViewRow row = dgv_addresses.SelectedRows[0];
                int id = int.Parse(row.Cells[0].Value.ToString());
                Properties.Settings.Default["DefaultAddressId"] = id.ToString();
                Properties.Settings.Default.Save();
                SetLoading(false);
            }
        }
    }
}
