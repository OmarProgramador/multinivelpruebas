
namespace Entities
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Issuer
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }

        [JsonProperty(PropertyName = "country_code")]
        public string Country_code { get; set; }

        [JsonProperty(PropertyName = "website")]
        public object Website { get; set; }

        [JsonProperty(PropertyName = "phone_number")]
        public object Phone_number { get; set; }
    }
}
