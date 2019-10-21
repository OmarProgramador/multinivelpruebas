

namespace Entities
{
    using Newtonsoft.Json;
    using System;

    public class FeeDetails
    {
        [JsonProperty(PropertyName = "fixed_fee")]
        public Object Fixed_fee { get; set; }

        [JsonProperty(PropertyName = "variable_fee")]
        public VariableFee Variable_fee { get; set; }
    }
}
