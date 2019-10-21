
namespace Entities
{
    using Newtonsoft.Json;

    public class Metadata
    {
        [JsonProperty(PropertyName = "method")]
        public string Method { get; set; }

        [JsonProperty(PropertyName = "client_ip")]
        public string Client_ip { get; set; }

        [JsonProperty(PropertyName = "secure")]
        public string Secure { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }
    }
}
