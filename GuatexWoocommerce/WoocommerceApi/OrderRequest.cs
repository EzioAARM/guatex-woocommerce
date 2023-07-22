using GuatexWoocommerce.Models;
using System.Configuration;
using WooCommerceNET;
using WooCommerceNET.WooCommerce.v3;

namespace GuatexWoocommerce.WoocommerceApi
{
    public class OrderRequest
    {
        /// <summary>
        /// Busca una orden en Woocommerce
        /// </summary>
        /// <param name="query">Término de busqueda</param>
        /// <returns>Listado de ordenes</returns>
        /// <exception cref="ConfigurationErrorsException">Error cuando no están configuradas las credenciales de Woocommerce</exception>
        public static async Task<List<WoocommerceOrder>> FindOrderAsync(string query)
        {
            (string endpoint, string key, string secret) = Program.GetWoocommerceSettings();
            if (string.IsNullOrEmpty(endpoint) || string.IsNullOrEmpty(key) || string.IsNullOrEmpty(secret))
            {
                throw new ConfigurationErrorsException("Debe configurar las credenciales de Woocommerce");
            }

            RestAPI rest = new($"{endpoint}/wp-json/wc/v3/", key, secret);
            WCObject wc = new(rest);
            List<Order> requestedOrders = await wc.Order.GetAll(new Dictionary<string, string>
                    {
                        { "search", query },
                        { "per_page", "100" },
                        { "order", "desc" },
                        { "orderby", "date" }
                    });
            List<WoocommerceOrder> orders = requestedOrders
                .Select(x => new WoocommerceOrder
                {
                    Id = x.id,
                    ParentId = x.parent_id,
                    Number = x.number,
                    OrderKey = x.order_key,
                    CreatedVia = x.created_via,
                    Version = x.version,
                    Status = x.status,
                    Currency = x.currency,
                    DateCreated = x.date_created,
                    DateCreatedGmt = x.date_created_gmt,
                    DateModified = x.date_modified,
                    DateModifiedGmt = x.date_modified_gmt,
                    DiscountTotal = x.discount_total,
                    DiscountTax = x.discount_tax,
                    ShippingTotal = x.shipping_total,
                    ShippingTax = x.shipping_tax,
                    CartTax = x.cart_tax,
                    Total = x.total,
                    TotalTax = x.total_tax,
                    PricesIncludeTax = x.prices_include_tax,
                    CustomerId = x.customer_id,
                    CustomerIpAddress = x.customer_ip_address,
                    CustomerUserAgent = x.customer_user_agent,
                    CustomerNote = x.customer_note,
                    Billing = new WoocommerceBilling
                    {
                        FirstName = x.billing.first_name,
                        LastName = x.billing.last_name,
                        Company = x.billing.company,
                        Address1 = x.billing.address_1,
                        Address2 = x.billing.address_2,
                        City = x.billing.city,
                        State = x.billing.state,
                        Postcode = x.billing.postcode,
                        Country = x.billing.country,
                        Email = x.billing.email,
                        Phone = x.billing.phone
                    },
                    Shipping = new WoocommerceShipping
                    {
                        FirstName = x.shipping.first_name,
                        LastName = x.shipping.last_name,
                        Company = x.shipping.company,
                        Address1 = x.shipping.address_1,
                        Address2 = x.shipping.address_2,
                        City = x.shipping.city,
                        State = x.shipping.state,
                        Postcode = x.shipping.postcode,
                        Country = x.shipping.country
                    },
                    PaymentMethod = x.payment_method,
                    PaymentMethodTitle = x.payment_method_title,
                    TransactionId = x.transaction_id,
                    DatePaid = x.date_paid,
                    DatePaidGmt = x.date_paid_gmt,
                    DateCompleted = x.date_completed,
                    DateCompletedGmt = x.date_completed_gmt,
                    CartHash = x.cart_hash
                })
                .ToList();
            return orders;
        }

        /// <summary>
        /// Obtiene una order de Woocommerce por su Id
        /// </summary>
        /// <param name="orderId">Id de la orden</param>
        /// <returns>Orden</returns>
        /// <exception cref="ConfigurationErrorsException">Error cuando no están configuradas las credenciales de Woocommerce</exception>
        public static async Task<WoocommerceOrder> GetOrderAsync(ulong orderId)
        {
            (string endpoint, string key, string secret) = Program.GetWoocommerceSettings();
            if (string.IsNullOrEmpty(endpoint) || string.IsNullOrEmpty(key) || string.IsNullOrEmpty(secret))
            {
                throw new ConfigurationErrorsException("Debe configurar las credenciales de Woocommerce");
            }

            RestAPI rest = new($"{endpoint}/wp-json/wc/v3/", key, secret);
            WCObject wc = new(rest);
            Order requestedOrders = await wc.Order.Get(orderId);
            WoocommerceOrder order = new();
            if (requestedOrders != null)
            {
                order.Id = requestedOrders.id;
                order.ParentId = requestedOrders.parent_id;
                order.Number = requestedOrders.number;
                order.OrderKey = requestedOrders.order_key;
                order.CreatedVia = requestedOrders.created_via;
                order.Version = requestedOrders.version;
                order.Status = requestedOrders.status;
                order.Currency = requestedOrders.currency;
                order.DateCreated = requestedOrders.date_created;
                order.DateCreatedGmt = requestedOrders.date_created_gmt;
                order.DateModified = requestedOrders.date_modified;
                order.DateModifiedGmt = requestedOrders.date_modified_gmt;
                order.DiscountTotal = requestedOrders.discount_total;
                order.DiscountTax = requestedOrders.discount_tax;
                order.ShippingTotal = requestedOrders.shipping_total;
                order.ShippingTax = requestedOrders.shipping_tax;
                order.CartTax = requestedOrders.cart_tax;
                order.Total = requestedOrders.total;
                order.TotalTax = requestedOrders.total_tax;
                order.PricesIncludeTax = requestedOrders.prices_include_tax;
                order.CustomerId = requestedOrders.customer_id;
                order.CustomerIpAddress = requestedOrders.customer_ip_address;
                order.CustomerUserAgent = requestedOrders.customer_user_agent;
                order.CustomerNote = requestedOrders.customer_note;
                order.Billing = new WoocommerceBilling
                {
                    FirstName = requestedOrders.billing.first_name,
                    LastName = requestedOrders.billing.last_name,
                    Company = requestedOrders.billing.company,
                    Address1 = requestedOrders.billing.address_1,
                    Address2 = requestedOrders.billing.address_2,
                    City = requestedOrders.billing.city,
                    State = requestedOrders.billing.state,
                    Postcode = requestedOrders.billing.postcode,
                    Country = requestedOrders.billing.country,
                    Email = requestedOrders.billing.email,
                    Phone = requestedOrders.billing.phone
                };
                order.Shipping = new WoocommerceShipping
                {
                    FirstName = requestedOrders.shipping.first_name,
                    LastName = requestedOrders.shipping.last_name,
                    Company = requestedOrders.shipping.company,
                    Address1 = requestedOrders.shipping.address_1,
                    Address2 = requestedOrders.shipping.address_2,
                    City = requestedOrders.shipping.city,
                    State = requestedOrders.shipping.state,
                    Postcode = requestedOrders.shipping.postcode,
                    Country = requestedOrders.shipping.country
                };
                order.LineItems = requestedOrders.line_items
                    .Select(x => new WoocommerceOrderLine()
                    {
                        Id = x.id,
                        Name = x.name,
                        ProductId = x.product_id,
                        VariationId = x.variation_id,
                        Quantity = x.quantity,
                        Total = x.total,
                        Sku = x.sku,
                        Price = x.price,
                    })
                    .ToList();
                order.PaymentMethod = requestedOrders.payment_method;
                order.PaymentMethodTitle = requestedOrders.payment_method_title;
                order.TransactionId = requestedOrders.transaction_id;
                order.DatePaid = requestedOrders.date_paid;
                order.DatePaidGmt = requestedOrders.date_paid_gmt;
                order.DateCompleted = requestedOrders.date_completed;
                order.DateCompletedGmt = requestedOrders.date_completed_gmt;
                order.CartHash = requestedOrders.cart_hash;
            }
            return order;
        }
    }
}
