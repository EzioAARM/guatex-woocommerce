using GuatexWoocommerce.Models;
using Newtonsoft.Json;
using System.Configuration;
using System.Net.Http.Headers;
using System.Text;

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

            // Create http client
            HttpClient client = new();

            // Create request
            HttpRequestMessage request = new(HttpMethod.Get, $"{endpoint}/wp-json/wc/v3/products?sku={sku}");
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes($"{key}:{secret}")));

            // Send request
            HttpResponseMessage response = client.Send(request);
            string content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<List<WoocommerceProduct>>(content);
                return result.FirstOrDefault();
            }
            else
            {
                return null;
            }
        }
    }
}
