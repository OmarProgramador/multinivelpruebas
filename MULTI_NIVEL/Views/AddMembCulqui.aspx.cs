using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MULTI_NIVEL.Views
{
    public partial class AddMembCulqui : System.Web.UI.Page
    {
         string def = "profile.png";
        string extension = ".png";
        string name = "";
        string nombreu = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string[] arrayLogin = HttpContext.Current.User.Identity.Name.Split('¬');
                if (arrayLogin.Length == 1)
                {
                    Response.Redirect("error.aspx?error=El usuario no esta logeado", true);
                }
                if (!IsPostBack)
                {                   
                    this.lblUser.Text = "Hola " + arrayLogin[0];
                    this.lblUserName.Text = arrayLogin[0];
                    this.lblNumPartner.Text = "N° Asociado: " + arrayLogin[4];
                    for (int i = 0; i < 32; i++)
                    {
                        ddlQuote.Items.Add((i + 1).ToString());
                    }

                    this.imgProfile.ImageUrl = "~/Resources/Images/profile.png";
                    this.imgProfileFl.ImageUrl = "~/Resources/Images/profile.png";

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
                }
                // Imagen de PErfil
                var rutaImgP = HttpContext.Current.Server.MapPath("~/Resources/imguser");
                DirectoryInfo di1 = new DirectoryInfo(rutaImgP);
                nombreu = arrayLogin[1];
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
            catch (Exception ex)
            {
                Response.Redirect("error.aspx?error=" + ex.Message, true);
            }
            //var token = txtTo.Text;

        }
    }
}