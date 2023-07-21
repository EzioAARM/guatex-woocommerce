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
            Properties.Settings.Default.Save();



            _ = MessageBox.Show("Cambios guardados con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        private void Preferences_Load(object sender, EventArgs e)
        {

        }
    }
}
