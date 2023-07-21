namespace GuatexWoocommerce.Models
{
    /// <summary>
    /// For more information go to <a href="https://woocommerce.github.io/woocommerce-rest-api-docs/#order-billing-properties">https://woocommerce.github.io/woocommerce-rest-api-docs/#order-billing-properties</a>
    /// </summary>
    public class WoocommerceBilling
    {
        /// <summary>
        /// First name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Company name
        /// </summary>
        public string Company { get; set; }

        /// <summary>
        /// Address line 1
        /// </summary>
        public string Address1 { get; set; }

        /// <summary>
        /// Address line 2
        /// </summary>
        public string Address2 { get; set; }

        /// <summary>
        /// City name
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// ISO code or name of the state, province or district.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Postal code
        /// </summary>
        public string Postcode { get; set; }

        /// <summary>
        /// Country code in ISO 3166-1 alpha-2 format
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Email address
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Phone number
        /// </summary>
        public string Phone { get; set; }
    }
}
