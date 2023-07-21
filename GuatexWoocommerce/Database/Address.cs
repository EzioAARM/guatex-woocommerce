using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuatexWoocommerce.Database
{
    public class Address : IEntityDate
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
        /// Name of the address
        /// </summary>
        [Required]
        [ModelAttributes(IncludeInView = true, Width = 100, Position = 1, Title = "Nombre")]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        /// <summary>
        /// Phone of the address
        /// </summary>
        [Required]
        [ModelAttributes(IncludeInView = true, Width = 100, Position = 2, Title = "Número de teléfono")]
        public string Phone { get; set; }

        /// <summary>
        /// Full address of the address
        /// </summary>
        [Required]
        [ModelAttributes(IncludeInView = true, Width = 200, Position = 3, Title = "Dirección")]
        public string FullAddress { get; set; }

        /// <summary>
        /// Department of the address
        /// </summary>
        [Required]
        [ModelAttributes(IncludeInView = true, Width = 150, Position = 4, Title = "Departamento (Guatex)")]
        public string Department { get; set; }

        /// <summary>
        /// Id of the department of the address
        /// </summary>
        [Required]
        public int DepartmentId { get; set; }

        /// <summary>
        /// Municipality of the address
        /// </summary>
        [Required]
        [ModelAttributes(IncludeInView = true, Width = 150, Position = 5, Title = "Municipio (Guatex)")]
        public string Municipality { get; set; }

        /// <summary>
        /// Id of the municipality of the address
        /// </summary>
        [Required]
        public int MunicipalityId { get; set; }

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
