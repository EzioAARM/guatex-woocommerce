using CsvHelper;
using System.Configuration;
using System.Globalization;

namespace GuatexWoocommerce
{
    public partial class Preferences : Form
    {
        public Preferences(bool displayIcon = false)
        {
            InitializeComponent();
            Height = 500;

            ShowInTaskbar = displayIcon;
            ShowIcon = displayIcon;

            // Load settings
            txt_endpoint.Text = Properties.Settings.Default["WoocommerceEndpoint"].ToString();
            txt_consumer_key.Text = Properties.Settings.Default["WoocomerceConsumerKey"].ToString();
            txt_consumer_secret.Text = Properties.Settings.Default["WoocommerceSecretKey"].ToString();

            txt_dbHost.Text = Properties.Settings.Default["MysqlHost"].ToString();
            txt_dbUser.Text = Properties.Settings.Default["MysqlUser"].ToString();
            txt_dbPass.Text = Properties.Settings.Default["MysqlPassword"].ToString();
            txt_dbName.Text = Properties.Settings.Default["MysqlDatabase"].ToString();


            txtUrlMunicipios.Text = Properties.Settings.Default["UrlMunicipios"].ToString();
            txtUsernameMunicipios.Text = Properties.Settings.Default["UsuarioMunicipios"].ToString();
            txtPasswordMunicipios.Text = Properties.Settings.Default["PasswordMunicipios"].ToString();
            txtCodigoCobroMunicipios.Text = Properties.Settings.Default["CodigoCobroMunicipios"].ToString();


            txtUrlTomarServicio.Text = Properties.Settings.Default["UrlTomaServicio"].ToString();
            txtUsernameServicio.Text = Properties.Settings.Default["UsuarioTomaServicio"].ToString();
            txtPasswordServicio.Text = Properties.Settings.Default["PasswordTomaServicio"].ToString();
            txtCodigoCobroServicio.Text = Properties.Settings.Default["CodigoCobroTomaServicio"].ToString();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (txt_endpoint.Text == "" || txt_consumer_key.Text == "" || txt_consumer_secret.Text == "")
            {
                _ = MessageBox.Show("Todos los campos son obligatorios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Properties.Settings.Default["WoocommerceEndpoint"] = txt_endpoint.Text;
            Properties.Settings.Default["WoocomerceConsumerKey"] = txt_consumer_key.Text;
            Properties.Settings.Default["WoocommerceSecretKey"] = txt_consumer_secret.Text;

            Properties.Settings.Default["MysqlHost"] = txt_dbHost.Text;
            Properties.Settings.Default["MysqlUser"] = txt_dbUser.Text;
            Properties.Settings.Default["MysqlPassword"] = txt_dbPass.Text;
            Properties.Settings.Default["MysqlDatabase"] = txt_dbName.Text;

            Properties.Settings.Default["UrlMunicipios"] = txtUrlMunicipios.Text;
            Properties.Settings.Default["UsuarioMunicipios"] = txtUsernameMunicipios.Text;
            Properties.Settings.Default["PasswordMunicipios"] = txtPasswordMunicipios.Text;
            Properties.Settings.Default["CodigoCobroMunicipios"] = txtCodigoCobroMunicipios.Text;

            Properties.Settings.Default["UrlTomaServicio"] = txtUrlTomarServicio.Text;
            Properties.Settings.Default["UsuarioTomaServicio"] = txtUsernameServicio.Text;
            Properties.Settings.Default["PasswordTomaServicio"] = txtPasswordServicio.Text;
            Properties.Settings.Default["CodigoCobroTomaServicio"] = txtCodigoCobroServicio.Text;

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
                    txt_endpoint.Text = data.FirstOrDefault(x => x.Key.Equals("WoocommerceEndpoint"))?.Value;
                    txt_consumer_key.Text = data.FirstOrDefault(x => x.Key.Equals("WoocomerceConsumerKey"))?.Value;
                    txt_consumer_secret.Text = data.FirstOrDefault(x => x.Key.Equals("WoocommerceSecretKey"))?.Value;

                    txt_dbHost.Text = data.FirstOrDefault(x => x.Key.Equals("MysqlHost"))?.Value;
                    txt_dbUser.Text = data.FirstOrDefault(x => x.Key.Equals("MysqlUser"))?.Value;
                    txt_dbPass.Text = data.FirstOrDefault(x => x.Key.Equals("MysqlPassword"))?.Value;
                    txt_dbName.Text = data.FirstOrDefault(x => x.Key.Equals("MysqlDatabase"))?.Value;


                    txtUrlMunicipios.Text = data.FirstOrDefault(x => x.Key.Equals("UrlMunicipios"))?.Value;
                    txtUsernameMunicipios.Text = data.FirstOrDefault(x => x.Key.Equals("UsuarioMunicipios"))?.Value;
                    txtPasswordMunicipios.Text = data.FirstOrDefault(x => x.Key.Equals("PasswordMunicipios"))?.Value;
                    txtCodigoCobroMunicipios.Text = data.FirstOrDefault(x => x.Key.Equals("CodigoCobroMunicipios"))?.Value;

                    txtUrlTomarServicio.Text = data.FirstOrDefault(x => x.Key.Equals("UrlTomaServicio"))?.Value; ;
                    txtUsernameServicio.Text = data.FirstOrDefault(x => x.Key.Equals("UsuarioTomaServicio"))?.Value; ;
                    txtPasswordServicio.Text = data.FirstOrDefault(x => x.Key.Equals("PasswordTomaServicio"))?.Value; ;
                    txtCodigoCobroServicio.Text = data.FirstOrDefault(x => x.Key.Equals("CodigoCobroTomaServicio"))?.Value; ;

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
