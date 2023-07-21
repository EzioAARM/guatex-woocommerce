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
    }
}