
namespace Entities
{
    public class MyConstants
    {
        public string ErrorEmail { get; set; }

        public string NumberFormat { get; set; }

        public string DateFormatUser { get; set; }

        public string DateFormatBd { get; set; }

        public double AmountInteresAnual { get; set; }

        public string BankAccount { get; set; }

        public string BankAccountDolar { get; set; }

        public string InterbankAccount { get; set; }

        public string InterbankAccountDolar { get; set; }

        public string SwiftBcp { get; set; }

        public string EmailEmpresa { get; set; }

        public string EmailEmpresaBonus { get; set; }

        public decimal Surcharge { get; set; }

        public MyConstants()
        {
            this.ErrorEmail = "omarurteaga@gmail.com";
            this.NumberFormat = "#,###,###,##0.00";
            this.DateFormatUser = "dd/MM/yyyy";
            this.DateFormatBd = "yyyy-MM-dd";
            this.AmountInteresAnual = 0;
            this.BankAccount = "191-2606708-0-82";
            this.BankAccountDolar = "191-2616687-1-90";
            this.InterbankAccount = "002 191 002606708082 55";
            this.InterbankAccountDolar = "00219100261668719050";
            this.SwiftBcp = "BCPLPEPL";
            this.EmailEmpresa = "cobranza.inresorts@gmail.com";
            this.EmailEmpresaBonus = "pagos.inresorts@gmail.com";
            this.Surcharge = 0.045m;
        }
    }
}
