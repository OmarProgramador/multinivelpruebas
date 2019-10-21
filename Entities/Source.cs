
namespace Entities
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Source
    {
        [JsonProperty(PropertyName = "object")]
        public string Object { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "creation_date")]
        public long Creation_date { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "card_number")]
        public string Card_number { get; set; }

        [JsonProperty(PropertyName = "last_four")]
        public string Last_four { get; set; }

        [JsonProperty(PropertyName = "active")]
        public bool Active { get; set; }

        [JsonProperty(PropertyName = "iin")]
        public Iin Iin { get; set; }

        [JsonProperty(PropertyName = "client")]
        public Client Client { get; set; }

        [JsonProperty(PropertyName = "metadata")]
        public Metadata Metadata { get; set; }

    }
}
