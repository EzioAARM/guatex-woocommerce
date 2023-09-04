using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuatexWoocommerce.Database
{
    public class GuiasGeneradas : IEntityDate
    {
        /// <summary>
        /// Id of the address
        /// </summary>
        [Required]
        [Key]
        [ModelAttributes(IncludeInView = true, Width = 100, Position = 0, Title = "ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Id de la orden de Woocommerce
        /// </summary>
        [Required]
        [Index(IsUnique = true)]
        public ulong IdOrden { get; set; }

        /// <summary>
        /// Número de la guía de Guatex
        /// </summary>
        [Required]
        public string NumeroGuia { get; set; }

        /// <summary>
        /// Nombre del remitente
        /// </summary>
        [Required]
        public string Remitente { get; set; }

        /// <summary>
        /// Dirección del remitente
        /// </summary>
        [Required]
        public string DireccionRemitente { get; set; }

        /// <summary>
        /// Número de teléfono del remitente
        /// </summary>
        [Required]
        public string TelefonoRemitente { get; set; }

        /// <summary>
        /// Nombre del destinatario
        /// </summary>
        [Required]
        public string Destinatario { get; set; }

        /// <summary>
        /// Dirección del destinatario
        /// </summary>
        [Required]
        public string DireccionDestinatario { get; set; }

        /// <summary>
        /// Número del teléfono del destinatario
        /// </summary>
        [Required]
        public string TelefonoDestinatario { get; set; }

        /// <summary>
        /// Posición de la guía generada
        /// </summary>
        [Required]
        public string GuiaActual { get; set; }

        /// <summary>
        /// Total de guías generadas
        /// </summary>
        [Required]
        public string TotalGuias { get; set; }

        /// <summary>
        /// Descripción del envío
        /// </summary>
        [Required]
        public string DescripcionEnvio { get; set; }

        /// <summary>
        /// Cantidad de piezas del envío
        /// </summary>
        [Required]
        public string CantidadPiezas { get; set; }

        /// <summary>
        /// Peso total del envío
        /// </summary>
        [Required]
        public string PesoTotal { get; set; }

        /// <summary>
        /// Forma de pago utilizada
        /// </summary>
        [Required]
        public string FormaPago { get; set; }

        /// <summary>
        /// Código de cobro de Guatex
        /// </summary>
        [Required]
        public string CodigoCobro { get; set; }

        /// <summary>
        /// Fecha de envío de la guía en formato dd/mm/yyyy
        /// </summary>
        [Required]
        public string Fecha { get; set; }

        /// <summary>
        /// Indica si la guía fue anulada
        /// </summary>
        [Required]
        public bool Anulada { get; set; }

        /// <summary>
        /// Created at
        /// </summary>
        [Required]
        [ModelAttributes(IncludeInView = true, Width = 100, Position = 6, Title = "Fecha de creación")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Updated at
        /// </summary>
        [Required]
        public DateTime UpdatedAt { get; set; }
    }
}
