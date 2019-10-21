
namespace Entities
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class Iin
    {
        [JsonProperty(PropertyName = "object")]
        public string Object { get; set; }

        [JsonProperty(PropertyName = "bin")]
        public string Bin { get; set; }

        [JsonProperty(PropertyName = "card_brand")]
        public string Card_brand { get; set; } 

        [JsonProperty(PropertyName = "card_type")]
        public string Card_type { get; set; }

        [JsonProperty(PropertyName = "card_category")]
        public string Card_category { get; set; }

        [JsonProperty(PropertyName = "issuer")]
        public Issuer Issuer { get; set; }

        [JsonProperty(PropertyName = "installments_allowed")]
        public List<int> Installments_allowed { get; set; }
    }
}
