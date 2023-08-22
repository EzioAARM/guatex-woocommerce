using GuatexWoocommerce.Models;
using System.Configuration;
using WooCommerceNET;
using WooCommerceNET.WooCommerce.v3;

namespace GuatexWoocommerce.WoocommerceApi
{
    public class ProductRequest
    {
        /// <summary>
        /// Obtener un producto por su Id de Woocommerce
        /// </summary>
        /// <param name="id">Id del producto</param>
        /// <returns>Producto de Woocommerce</returns>
        /// <exception cref="ConfigurationErrorsException"></exception>
        public static async Task<WoocommerceProduct> GetProduct(string sku)
        {
            (string endpoint, string key, string secret) = Program.GetWoocommerceSettings();
            if (string.IsNullOrEmpty(endpoint) || string.IsNullOrEmpty(key) || string.IsNullOrEmpty(secret))
            {
                throw new ConfigurationErrorsException("Debe configurar las credenciales de Woocommerce");
            }

            RestAPI rest = new($"{endpoint}/wp-json/wc/v3/", key, secret);
            WCObject wc = new(rest);
            List<Product> product = await wc.Product.GetAll(new Dictionary<string, string>()
            {
                { "sku", sku }
            });
            if (product.Count == 0)
            {
                return null;
            }
            WoocommerceProduct finalProduct = new()
            {
                Id = product.First().id,
                Name = product.First().name,
                Slug = product.First().slug,
                Permalink = product.First().permalink,
                Sku = product.First().sku,
                Price = product.First().price,
                Weight = product.First().weight
            };
            return finalProduct;
        }
    }
}
