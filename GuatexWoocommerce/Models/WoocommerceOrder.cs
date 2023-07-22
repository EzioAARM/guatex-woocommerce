namespace GuatexWoocommerce.Models
{
    /// <summary>
    /// For more information go to <a href="https://woocommerce.github.io/woocommerce-rest-api-docs/#order-properties">https://woocommerce.github.io/woocommerce-rest-api-docs/#order-properties</a>
    /// </summary>
    public class WoocommerceOrder
    {
        /// <summary>
        /// Id de la orden
        /// </summary>
        [ModelAttributes(IncludeInView = true, Width = 100, Position = 0, Title = "ID")]
        public ulong? Id { get; set; }

        /// <summary>
        /// Parent order ID
        /// </summary>
        public ulong? ParentId { get; set; }

        /// <summary>
        /// Order number
        /// </summary>
        [ModelAttributes(IncludeInView = true, Width = 200, Position = 1, Title = "Número de orden")]
        public string Number { get; set; }

        /// <summary>
        /// Order key
        /// </summary>
        public string OrderKey { get; set; }

        /// <summary>
        /// Shows where the order was created
        /// </summary>
        public string CreatedVia { get; set; }

        /// <summary>
        /// Version of WooCommerce which last updated the order
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Order status. Options:
        /// <br />
        /// - <strong>pending</strong><br />
        /// - <strong>processing</strong><br />
        /// - <strong>on-hold</strong><br />
        /// - <strong>completed</strong><br />
        /// - <strong>cancelled</strong><br />
        /// - <strong>refunded</strong><br />
        /// - <strong>failed</strong><br />
        /// - <strong>trash</strong><br />
        /// <br />
        /// Default is pending
        /// </summary>
        [ModelAttributes(IncludeInView = true, Width = 125, Position = 2, Title = "Estado de la orden")]
        public string Status { get; set; }

        /// <summary>
        /// Currency the order was created with, in ISO format
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// The date the order was created, in the site's timezone
        /// </summary>
        [ModelAttributes(IncludeInView = true, Width = 150, Position = 6, Title = "Fecha de creación")]
        public DateTime? DateCreated { get; set; }

        /// <summary>
        /// The date the order was created, as GMT
        /// </summary>
        public DateTime? DateCreatedGmt { get; set; }

        /// <summary>
        /// The date the order was last modified, in the site's timezone
        /// </summary>
        public DateTime? DateModified { get; set; }

        /// <summary>
        /// The date the order was last modified, as GMT
        /// </summary>
        public DateTime? DateModifiedGmt { get; set; }

        /// <summary>
        /// Total discount amount for the order
        /// </summary>
        public decimal? DiscountTotal { get; set; }

        /// <summary>
        /// Total discount tax amount for the order
        /// </summary>
        public decimal? DiscountTax { get; set; }

        /// <summary>
        /// Total shipping amount for the order
        /// </summary>
        [ModelAttributes(IncludeInView = true, Width = 150, Position = 3, Title = "Total del envío")]
        public decimal? ShippingTotal { get; set; }

        /// <summary>
        /// Total shipping tax amount for the order
        /// </summary>
        public decimal? ShippingTax { get; set; }

        /// <summary>
        /// Sum of line item taxes only
        /// </summary>
        public decimal? CartTax { get; set; }

        /// <summary>
        /// Grand total
        /// </summary>
        [ModelAttributes(IncludeInView = true, Width = 150, Position = 4, Title = "Total")]
        public decimal? Total { get; set; }

        /// <summary>
        /// Sum of all taxes
        /// </summary>
        public decimal? TotalTax { get; set; }

        /// <summary>
        /// True the prices included tax during checkout
        /// </summary>
        public bool? PricesIncludeTax { get; set; }

        /// <summary>
        /// User ID who owns the order. 0 for guests. Default is 0
        /// </summary>
        [ModelAttributes(IncludeInView = true, Width = 150, Position = 5, Title = "ID del cliente")]
        public ulong? CustomerId { get; set; }

        /// <summary>
        /// Customer's IP address
        /// </summary>
        public string CustomerIpAddress { get; set; }

        /// <summary>
        /// User agent of the customer
        /// </summary>
        public string CustomerUserAgent { get; set; }

        /// <summary>
        /// Note left by customer during checkout
        /// </summary>
        public string CustomerNote { get; set; }

        /// <summary>
        /// Billing address
        /// </summary>
        public WoocommerceBilling Billing { get; set; }

        /// <summary>
        /// Shipping address
        /// </summary>
        public WoocommerceShipping Shipping { get; set; }

        /// <summary>
        /// Items of the order
        /// </summary>
        public List<WoocommerceOrderLine> LineItems { get; set; }

        /// <summary>
        /// Payment method ID
        /// </summary>
        public string PaymentMethod { get; set; }

        /// <summary>
        /// Payment method title
        /// </summary>
        [ModelAttributes(IncludeInView = true, Width = 150, Position = 7, Title = "Método de pago")]
        public string PaymentMethodTitle { get; set; }

        /// <summary>
        /// Unique transaction ID
        /// </summary>
        [ModelAttributes(IncludeInView = true, Width = 150, Position = 8, Title = "ID de la transacción")]
        public string TransactionId { get; set; }

        /// <summary>
        /// The date the order was paid, in the site's timezone
        /// </summary>
        [ModelAttributes(IncludeInView = true, Width = 150, Position = 9, Title = "Fecha de pago")]
        public DateTime? DatePaid { get; set; }

        /// <summary>
        /// The date the order was paid, as GMT
        /// </summary>
        public DateTime? DatePaidGmt { get; set; }

        /// <summary>
        /// The date the order was completed, in the site's timezone
        /// </summary>
        public DateTime? DateCompleted { get; set; }

        /// <summary>
        /// The date the order was completed, as GMT
        /// </summary>
        public DateTime? DateCompletedGmt { get; set; }

        /// <summary>
        /// MD5 hash of cart items to ensure orders are not modified
        /// </summary>
        public string CartHash { get; set; }
    }
}
