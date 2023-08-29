using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace GuatexWoocommerce.Models
{
    public class WoocommerceProduct
    {
        /// <summary>
        /// Unique identifier for the resource.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        [JsonPropertyName("id")]
        public ulong? Id { get; set; }

        /// <summary>
        /// Product name
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Product slug
        /// </summary>
        [JsonProperty(PropertyName = "slug")]
        [JsonPropertyName("slug")]
        public string Slug { get; set; }

        /// <summary>
        /// Product URL
        /// </summary>
        [JsonProperty(PropertyName = "permalink")]
        [JsonPropertyName("permalink")]
        public string Permalink { get; set; }

        /// <summary>
        /// Unique identifier
        /// </summary>
        [JsonProperty(PropertyName = "sku")]
        [JsonPropertyName("sku")]
        public string Sku { get; set; }

        /// <summary>
        /// Current product price
        /// </summary>
        [JsonProperty(PropertyName = "price")]
        [JsonPropertyName("price")]
        public decimal? Price { get; set; }

        /// <summary>
        /// Product weight
        /// </summary>
        [JsonProperty(PropertyName = "weight")]
        [JsonPropertyName("weight")]
        public string Weight { get; set; }
    }
}
