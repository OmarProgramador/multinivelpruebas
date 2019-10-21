using System;
using System.IO;
using System.Web;

namespace MULTI_NIVEL.Views
{
    public partial class PayOnLine : System.Web.UI.Page
    {
        string def = "profile.png";
        string extension = ".png";
        string name = "";
        string nombreu = "";

        public string Token { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            //hasta ahora 4 
            //nombree completo ¬ userName ¬ id person¬ status payments
            //login con usuario y contraseña
            if (!IsPostBack)
            {
                //Session["datos"] = "Aaaaa|Aaaa|birthDay|M|DocumentType|88884444$NombreC|ApellidoC|1|313231c$bankName|nombreBankAccount|TypeAccount|nroAccount|nroTaxer|SocialReason|fiscalAdress|UserType$programador.pazo@gmail.com|nroCell|nroCell2|country|State|City|Adress";
                //Session["carrito"] = "1105.00|Experience|12|85.00|3.29|10|EXP";
                //Session["cronograma"] = "6000|222";
                //Session["TypeCurrency"] = "USD";
                //Session["FirtsPay"] = "280";

                var obj = HttpContext.Current.User.Identity.Name.Split('¬');
                this.lblUser.Text = "Hola " + obj[0];
                this.lblUserName.Text = obj[0];
                if (obj.Length > 2)
                {
                    this.lblNumPartner.Text = "N° Asociado: " + obj[4];
                }

                for (int i = 0; i < 32; i++)
                {
                    ddlQuote.Items.Add((i + 1).ToString());
                }
                if (true)
                {
                    this.imgProfile.ImageUrl = "~/Resources/Images/profile.png";
                    this.imgProfileFl.ImageUrl = "~/Resources/Images/profile.png";
                }
                if (Session["carrito"] != null)
                {
                    string[] parameterList = Session["carrito"].ToString().Split('|');
                    string codeCurrency = Session["TypeCurrency"].ToString();

                    var amountTotalMember = decimal.Parse(parameterList[0]);
                    typeMembreship.Text = parameterList[1];
                    var numberQuotes = decimal.Parse(parameterList[2]);
                    var amountInitial = decimal.Parse(parameterList[3]);
                    var tipoCambio = decimal.Parse(parameterList[4]);


                    var amountQuote = (amountTotalMember - amountInitial) / numberQuotes;

                    var format = "0.00";
                    //salidas
                    AmountTotal.Text = amountTotalMember.ToString(format);
                    AmountInitialQuote.Text = amountInitial.ToString(format);
                    NumQuotes.Text = numberQuotes.ToString(format);
                    AmountQuotes.Text = amountQuote.ToString(format);
                    AmountAPayCulqui.Text = amountInitial.ToString(format);
                    TypeChange.Text = tipoCambio.ToString(format);

                    CurrencyCode.Text = codeCurrency;
                    CurrencyCode2.Text = codeCurrency;
                    CurrencyCode3.Text = codeCurrency;
                    CurrencyCode4.Text = codeCurrency;


                }

                // Imagen de PErfil
                var rutaImgP = HttpContext.Current.Server.MapPath("~/Resources/imguser");
                DirectoryInfo di1 = new DirectoryInfo(rutaImgP);
                nombreu = obj[1];
                foreach (var fi2 in di1.GetFiles())
                {
                    var archivo = fi2.Name.Split('.');
                    name = archivo[archivo.Length - 2];
                    extension = archivo[archivo.Length - 1];
                    if (name == nombreu) { def = nombreu + "." + extension; }
                }
                imgProfile.ImageUrl = "~/Resources/imguser/" + def;
                imgProfile.Style.Add("width", "40px");
                imgProfile.Style.Add("height", "40px");
                imgProfile.Style.Add("margin", "0 auto");
                imgProfileFl.ImageUrl = "~/Resources/imguser/" + def;
                imgProfileFl.Style.Add("width", "80px");
                imgProfileFl.Style.Add("height", "80px");
                imgProfileFl.Style.Add("margin", "0 auto");

            }
            //var token = txtTo.Text;
        }
    }
}