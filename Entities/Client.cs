
namespace Entities
{
    using Newtonsoft.Json;

    public class Client
    {
        [JsonProperty(PropertyName = "ip")]
        public string Ip { get; set; }

        [JsonProperty(PropertyName = "ip_country")]
        public string Ip_country { get; set; }

        [JsonProperty(PropertyName = "ip_country_code")]
        public string Ip_country_code { get; set; }

        [JsonProperty(PropertyName = "browser")]
        public object Browser { get; set; }

        [JsonProperty(PropertyName = "device_fingerprint")]
        public string Device_fingerprint { get; set; }

        [JsonProperty(PropertyName = "device_type")]
        public string Device_type { get; set; }
    }
}
