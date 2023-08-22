namespace GuatexWoocommerce
{
    internal static class Program
    {
        public static DatabaseContext _context;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new GuatexSendings());
        }

        public static (string endpoint, string key, string secret) GetWoocommerceSettings()
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

        public static (string urlMunicipios, string municipiosUsername, string municipiosPassword, string codigoCobro) GetGuatexMunicipiosSettings()
        {
            Properties.Settings settings = Properties.Settings.Default;
            string urlMunicipios = settings["UrlMunicipios"].ToString();
            string municipiosUsername = settings["UsuarioMunicipios"].ToString();
            string municipiosPassword = settings["PasswordMunicipios"].ToString();
            string codigoCobro = settings["CodigoCobroMunicipios"].ToString();

            return (urlMunicipios, municipiosUsername, municipiosPassword, codigoCobro);
        }

        public static (string urlServicio, string servicioUsername, string servicioPassword, string codigoCobro) GetGuatexTomaServiciosSettings()
        {
            Properties.Settings settings = Properties.Settings.Default;
            string urlServicio = settings["UrlTomaServicio"].ToString();
            string servicioUsername = settings["UsuarioTomaServicio"].ToString();
            string servicioPassword = settings["PasswordTomaServicio"].ToString();
            string codigoCobro = settings["CodigoCobroTomaServicio"].ToString();

            return (urlServicio, servicioUsername, servicioPassword, codigoCobro);
        }
    }
}