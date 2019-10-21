


namespace Entities
{
    using System;
    public class beFeesPayDetail
    {
      
        public string IdMembership { get; set; }
        public int IdPerson { get; set; }
        public string LastnameName { get; set; }
        public string DocumentNumber { get; set; }
        public string IdMembershipType { get; set; }
        public string MembershipType { get; set; }

        public double AmountUSD { get; set; }
        public double AmountPEN { get; set; }
        public double FinancedAmount { get; set; }
        public double ExchangeRate { get; set; }
        public string IdEmployeeLiner { get; set; }
        public string IdEmployeeCloser { get; set; }
        public int NumberQuoteOfPay { get; set; }
        public DateTime DateQuoteStart { get; set; }
        public double InitialFeeAmount { get; set; }
        public double AnualEffectiveRate { get; set; }
        public string Obs { get; set; }
        public double TotalAmountOfInterest { get; set; }
        public string periodicity = "Mensual";

        public int NumberOfInitialOfPay { get; set; }
        public DateTime DateInitial1 { get; set; }
        public DateTime DateInitial2 { get; set; }
        public DateTime DateInitial3 { get; set; }
        public DateTime DateInitial4 { get; set; }

        //datos calculables
        public double Amortization { get; set; }
        public double MonthlyRate { get; set; }
        public double Interests { get; set; }
        public double Quote { get; set; }
        public double interestingInitial = 0.00;
        public double FinancingPercentage { get; set; }
        public double CapitalBalance { get; set; }
    }
}
