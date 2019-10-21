using BussinesRules;
using Entities;
using System;
using System.IO;
using System.Web;

namespace MULTI_NIVEL.Views
{
    public partial class PayOnLineQuote : System.Web.UI.Page
    {
        string def = "profile.png";
        string extension = ".png";
        string name = "";
        string nombreu = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var obj = HttpContext.Current.User.Identity.Name.Split('¬');
                this.lblUser.Text = "Hola " + obj[0];
                this.lblUserName.Text = obj[0];
                this.imgProfile.ImageUrl = "~/Resources/Images/profile.png";
                this.imgProfileFl.ImageUrl = "~/Resources/Images/profile.png";


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

                if (!string.IsNullOrEmpty(def))
                {
                    imgProfile.ImageUrl = "~/Resources/imguser/" + def;
                    imgProfile.Style.Add("width", "40px");
                    imgProfile.Style.Add("height", "40px");
                    imgProfile.Style.Add("margin", "0 auto");
                    imgProfileFl.ImageUrl = "~/Resources/imguser/" + def;
                    imgProfileFl.Style.Add("width", "80px");
                    imgProfileFl.Style.Add("height", "80px");
                    imgProfileFl.Style.Add("margin", "0 auto");
                }

                for (int i = 0; i < 32; i++)
                {
                    ddlQuote.Items.Add((i + 1).ToString());
                }


                var description = string.Empty;
                var amountPay = string.Empty;
                var currencyCodecro = string.Empty;


                if (Session["numCuota"] != null)
                {
                    description = Session["numCuota"].ToString();
                }
                if (Session["quotePay"] != null)
                {
                    amountPay = Session["quotePay"].ToString();
                }
                if (Session["CurrencyCode"] != null)
                {
                    currencyCodecro = Session["CurrencyCode"].ToString();
                }

                MyConstants mc = new MyConstants();

                var amountTotal = decimal.Parse(amountPay) * (1 + mc.Surcharge);


                Description.Text = description;
                AmountTotal.Text = $"{amountTotal.ToString("0.00")}";
                Note.Text = $"Se asume un recargo del {(mc.Surcharge * 100).ToString("0.00")}% en el monto, El cual ya ha sido incluido en el monto mostrado.";

                Session["amountpaywallet"] = amountTotal.ToString("0.00");

                CurrencyCode.Text = currencyCodecro;


                BrTypeChange brTypeChange = new BrTypeChange();

                var array_ = brTypeChange.GetTypesChange().Split('|');
                TypeChange.Text = decimal.Parse(array_[0]).ToString();

                var tcCro = decimal.Parse(Session["tcCro"].ToString());

                if (currencyCodecro == "PEN")
                {
                    DivType.Style.Add("display", "none");
                    ddlcurrencyCode.Style.Add("display", "none");
                    TypeChange.Text = tcCro.ToString();
                }

                if (currencyCodecro == "USD")
                {
                    TypeChange.Text = decimal.Parse(array_[0]).ToString();
                }
            }
        }
    }
}