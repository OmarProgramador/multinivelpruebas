using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class CulqiAnwser
    {
        [JsonProperty(PropertyName = "duplicated")]
        public bool Duplicated { get; set; }

        [JsonProperty(PropertyName = "object")]
        public string Object { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "creation_date")]
        public long Creation_date { get; set; }

        [JsonProperty(PropertyName = "amount")]
        public int Amount { get; set; }

        [JsonProperty(PropertyName = "amount_refunded")]
        public int Amount_refunded { get; set; }

        [JsonProperty(PropertyName = "current_amount")]
        public int Current_amount { get; set; }

        [JsonProperty(PropertyName = "installments")]
        public int Installments { get; set; }

        [JsonProperty(PropertyName = "installments_amount")]
        public object Installments_amount { get; set; }

        [JsonProperty(PropertyName = "currency_code")]
        public string Currency_code { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "description")]
        public object Description { get; set; }

        [JsonProperty(PropertyName = "source")]
        public Source Source { get; set; }

        [JsonProperty(PropertyName = "outcome")]
        public Outcome Outcome { get; set; }

        [JsonProperty(PropertyName = "fraud_score")]
        public double Fraud_score { get; set; }

        [JsonProperty(PropertyName = "dispute")]
        public bool Dispute { get; set; }

        [JsonProperty(PropertyName = "capture")]
        public bool Capture { get; set; }

        [JsonProperty(PropertyName = "reference_code")]
        public string Reference_code { get; set; }

        [JsonProperty(PropertyName = "authorization_code")]
        public string Authorization_code { get; set; }

        [JsonProperty(PropertyName = "metadata")]
        public Metadata2 Metadata { get; set; }

        [JsonProperty(PropertyName = "total_fee")]
        public int Total_fee { get; set; }

        [JsonProperty(PropertyName = "fee_details")]
        public FeeDetails Fee_details { get; set; }

        [JsonProperty(PropertyName = "total_fee_taxes")]
        public int Total_fee_taxes { get; set; }

        [JsonProperty(PropertyName = "transfer_amount")]
        public int Transfer_amount { get; set; }

        [JsonProperty(PropertyName = "paid")]
        public bool Paid { get; set; }

        [JsonProperty(PropertyName = "statement_descriptor")]
        public string Statement_descriptor { get; set; }

        [JsonProperty(PropertyName = "transfer_id")]
        public object Transfer_id { get; set; }
    }
}
