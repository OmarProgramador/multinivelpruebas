using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class PayDetail
    {
        public int Id { get; set; }
        public string QuoteDescription { get; set; }
        public string NextExpiration { get; set; }
        public decimal CapitalBalance { get; set; }
        public decimal Amortization { get; set; }
        public decimal Interested { get; set; }
        public decimal Quote { get; set; }
        public int Status { get; set; }
        public string TicketImage { get; set; }
        public string Obs { get; set; }
        public string ReceiptNro { get; set; }
        public int verif { get; set; }
        public string IdAccountTypeMembership { get; set; }
        public string Identifier { get; set; }
        public decimal pts { get; set; }
        public string PayDate { get; set; }
        public int IdPenalty { get; set; }
        public decimal Percent { get; set; }
    }
}
