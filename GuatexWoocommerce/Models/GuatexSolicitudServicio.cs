namespace GuatexWoocommerce.Models
{
    public class GuatexSolicitudServicio
    {
        /// <summary>
        /// Código generado por GUATEX para identificar el envío
        /// </summary>
        public string Codigo { get; set; }

        /// <summary>
        /// Listado de guias generadas por GUATEX
        /// </summary>
        public List<Guia> Guias { get; set; }
    }

    public class Guia
    {
        /// <summary>
        /// Id de la guia
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Número de la guia
        /// </summary>
        public string Numero { get; set; }

        /// <summary>
        /// Listado de guias hijas
        /// </summary>
        public List<string> GuiasHijas { get; set; }
    }
}
