namespace GuatexWoocommerce.Models
{
    public class WoocommerceOrderLine
    {
        /// <summary>
        /// Line item ID
        /// </summary>
        public ulong? Id { get; set; }

        /// <summary>
        /// Product Name
        /// </summary>
        [ModelAttributes(IncludeInView = true, Width = 400, Position = 2, Title = "Nombre")]
        public string Name { get; set; }

        /// <summary>
        /// Product Id
        /// </summary>
        public ulong? ProductId { get; set; }

        /// <summary>
        /// Product Variation Id
        /// </summary>
        public ulong? VariationId { get; set; }

        /// <summary>
        /// Quantity ordered
        /// </summary>
        [ModelAttributes(IncludeInView = true, Width = 150, Position = 1, Title = "Cantidad")]
        public decimal? Quantity { get; set; }

        /// <summary>
        /// Total items cost (after discounts)
        /// </summary>
        [ModelAttributes(IncludeInView = true, Width = 150, Position = 3, Title = "Total")]
        public decimal? Total { get; set; }

        /// <summary>
        /// Sku
        /// </summary>
        [ModelAttributes(IncludeInView = true, Width = 100, Position = 0, Title = "Sku")]
        public string Sku { get; set; }

        /// <summary>
        /// Item individual price
        /// </summary>
        public decimal? Price { get; set; }
    }
}
