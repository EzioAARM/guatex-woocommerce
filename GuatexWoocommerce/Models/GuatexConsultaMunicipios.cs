namespace GuatexWoocommerce.Models
{
    public class GuatexConsultaMunicipios
    {
        public GuatexConsultaMunicipios()
        {
            Destinos = new List<Destino>();
            TiposEnvio = new List<TipoEnvio>();
        }
        /// <summary>
        /// Listado de destinos permitidos por GUATEX
        /// </summary>
        public List<Destino> Destinos { get; set; }

        /// <summary>
        /// Tipos de envío permitidos por GUATEX
        /// </summary>
        public List<TipoEnvio> TiposEnvio { get; set; }
    }

    public class TipoEnvio
    {
        /// <summary>
        /// Código del tipo de envío
        /// </summary>
        public int Codigo { get; set; }

        /// <summary>
        /// Nombre del tipo de envío
        /// </summary>
        public string Nombre { get; set; }
    }

    public class Destino
    {
        /// <summary>
        /// Código del destino
        /// </summary>
        public int Codigo { get; set; }

        /// <summary>
        /// Nombre del destino
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Punto de cobertura del destino
        /// </summary>
        public string PuntoCobertura { get; set; }

        /// <summary>
        /// tipo de tarifa del destino
        /// </summary>
        public string TipoTarifa { get; set; }

        /// <summary>
        /// Nombre del departamento
        /// </summary>
        public string Departamento { get; set; }

        /// <summary>
        /// Nombre del municipio
        /// </summary>
        public string Municipio { get; set; }

        /// <summary>
        /// Días que se visita el destino
        /// </summary>
        public string FrecuenciaVisita { get; set; }

        /// <summary>
        /// Indica si el destino es una oficina de GUATEX
        /// </summary>
        public bool RecogeOficina { get; set; }

        /// <summary>
        /// Código del departamento
        /// </summary>
        public int? Depto { get; set; }

        /// <summary>
        /// Código del municipio
        /// </summary>
        public int? Muni { get; set; }
    }

}
