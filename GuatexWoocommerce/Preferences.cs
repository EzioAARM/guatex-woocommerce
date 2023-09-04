using CsvHelper;
using System.Configuration;
using System.Globalization;

namespace GuatexWoocommerce
{
    public partial class Preferences : Form
    {
        List<(string propName, TextBox input)> propertiesMapping;

        public Preferences(bool displayIcon = false)
        {
            InitializeComponent();
            propertiesMapping = new()
            {
                ("WoocommerceEndpoint", txt_endpoint),
                ("WoocomerceConsumerKey", txt_consumer_key),
                ("WoocommerceSecretKey", txt_consumer_secret),

                ("MysqlHost", txt_dbHost),
                ("MysqlUser", txt_dbUser),
                ("MysqlPassword", txt_dbPass),
                ("MysqlDatabase", txt_dbName),

                ("UrlMunicipios", txtUrlMunicipios),
                ("UsuarioMunicipios", txtUsernameMunicipios),
                ("PasswordMunicipios", txtPasswordMunicipios),
                ("CodigoCobroMunicipios", txtCodigoCobroMunicipios),

                ("UrlTomaServicio", txtUrlTomarServicio),
                ("UrlEliminarGuia", txtUrlEliminarGuia),
                ("UsuarioTomaServicio", txtUsernameServicio),
                ("PasswordTomaServicio", txtPasswordServicio),
                ("CodigoCobroTomaServicio", txtCodigoCobroServicio),

                ("NombreRemitente", txtNombreRemitente),
                ("TelefonoRemitente", txtTelefonoRemitente),
            };
            Height = 500;

            ShowInTaskbar = displayIcon;
            ShowIcon = displayIcon;

            // Load settings
            foreach ((string propName, TextBox input) in propertiesMapping)
            {
                input.Text = Properties.Settings.Default[propName].ToString();
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (txt_endpoint.Text == "" || txt_consumer_key.Text == "" || txt_consumer_secret.Text == "")
            {
                _ = MessageBox.Show("Todos los campos son obligatorios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach ((string propName, TextBox input) in propertiesMapping)
            {
                Properties.Settings.Default[propName] = input.Text;
            }

            Properties.Settings.Default.Save();



            _ = MessageBox.Show("Cambios guardados con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        private void Preferences_Load(object sender, EventArgs e)
        {

        }

        private void btnSalirMenu_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnImportarMenu_Click(object sender, EventArgs e)
        {
            using OpenFileDialog fileDialog = new();
            fileDialog.Multiselect = false;
            fileDialog.Title = "Seleccionar archivo a importar";
            fileDialog.Filter = "Archivos CSV|*.csv";
            fileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            DialogResult selectedFolder = fileDialog.ShowDialog();
            if (selectedFolder == DialogResult.OK)
            {
                string fileName = fileDialog.FileName;
                using StreamReader reader = new(fileName);
                using CsvReader csv = new(reader, CultureInfo.InvariantCulture);
                try
                {
                    List<KeyValueSettings> data = csv.GetRecords<KeyValueSettings>()
                        .ToList();

                    // Load settings
                    foreach ((string propName, TextBox input) in propertiesMapping)
                    {
                        KeyValueSettings setting = data.FirstOrDefault(x => x.Key.Equals(propName));
                        if (setting != null)
                        {
                            input.Text = setting?.Value;
                        }
                    }

                    _ = MessageBox.Show("Cambios importados con éxito, antes de salir debe guardar las configuraciones importadas", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    _ = MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnExportarMenu_Click(object sender, EventArgs e)
        {
            List<KeyValueSettings> list = new();
            foreach (SettingsProperty currentProperty in Properties.Settings.Default.Properties)
            {
                list.Add(new KeyValueSettings
                {
                    Key = currentProperty.Name,
                    Value = Properties.Settings.Default[currentProperty.Name].ToString()
                });
            }
            string fileName = "settings-export-guatex-decorazul.csv";
            using SaveFileDialog saveFileDialog = new();
            saveFileDialog.Title = "Guardar archivo de configuración";
            saveFileDialog.Filter = "Archivos CSV|*.csv";
            saveFileDialog.FileName = fileName;
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            DialogResult selectedFolder = saveFileDialog.ShowDialog();
            if (selectedFolder == DialogResult.OK)
            {
                fileName = saveFileDialog.FileName;
                using StreamWriter streamWriter = new(fileName);
                using CsvWriter csvWriter = new(streamWriter, CultureInfo.InvariantCulture);
                csvWriter.WriteRecords(list);
                _ = MessageBox.Show("Configuraciones exportadas con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }

    internal class KeyValueSettings
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
