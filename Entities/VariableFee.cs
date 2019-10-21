
namespace Entities
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class VariableFee
    {
        [JsonProperty(PropertyName = "currency_code")]
        public string Currency_code { get; set; }
        [JsonProperty(PropertyName = "commision")]
        public double Commision { get; set; }
        [JsonProperty(PropertyName = "total")]
        public int Total { get; set; }
    }
}
