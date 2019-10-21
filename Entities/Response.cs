
namespace Entities
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    public class Response
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }
        [JsonProperty(PropertyName = "merchant_message")]
        public string MerchantMessage { get; set; }
        [JsonProperty(PropertyName = "user_message")]
        public string UserMessage { get; set; }
    }
}
