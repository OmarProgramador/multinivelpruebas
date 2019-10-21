
namespace Entities
{
    using Newtonsoft.Json;

    public class Metadata2
    {
        [JsonProperty(PropertyName = "account_userName")]
        public string Account_userName { get; set; }
    }
}
