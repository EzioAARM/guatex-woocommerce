namespace GuatexWoocommerce.Models
{
    public class WoocommerceProduct
    {
        /// <summary>
        /// Unique identifier for the resource.
        /// </summary>
        public ulong? Id { get; set; }

        /// <summary>
        /// Product name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Product slug
        /// </summary>
        public string Slug { get; set; }

        /// <summary>
        /// Product URL
        /// </summary>
        public string Permalink { get; set; }

        /// <summary>
        /// Unique identifier
        /// </summary>
        public string Sku { get; set; }

        /// <summary>
        /// Current product price
        /// </summary>
        public decimal? Price { get; set; }

        /// <summary>
        /// Product weight
        /// </summary>
        public decimal? Weight { get; set; }
    }
}
