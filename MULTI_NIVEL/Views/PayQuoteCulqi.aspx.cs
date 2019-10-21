using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MULTI_NIVEL.Views
{
    public partial class PayQuoteCulqi : System.Web.UI.Page
    {
        string def = "profile.png";
        string extension = ".png";
        string name = "";
        string nombreu = "";

        protected void Page_Load(object sender, EventArgs e)
        {

            //hasta ahora 4 
            //nombree completo ¬ userName ¬ id person¬ status payments
            //login con usuario y contraseña

            if (!IsPostBack)
            {
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
                    titlePAY.Text = "Pago De Mi Cuota Inicial ";
                    typeMembreship.Text = "Tipo de membresía:  " + parameterList[1];
                    int ej = (int)Session["JustKit"];
                    var cono = parameterList[0];
                    //double tipoCambio = Double.Parse(obj[5]);
                    double tipoCambio = Double.Parse(parameterList[4]);
                    //if (!string.IsNullOrEmpty(Session["exchange"].ToString())) { tipoCambio = (double)Session["exchange"]; }
                    if (string.IsNullOrEmpty(parameterList[0]) || ej == 0)
                    {
                        if (codeCurrency == "PEN")
                        {
                            amountTotal.Text = "Costo total de membresía: " + ((double.Parse(cono) - 10.00) * (tipoCambio)).ToString() + " PEN";
                            amountTotal.Text = "Costo total de membresía: " + ((double.Parse(cono) - 10.00) * (tipoCambio)).ToString() + " PEN";
                        }
                        else
                        {
                            amountTotal.Text = "Costo total de membresía: " + (double.Parse(cono) - 10.00).ToString() + " USD";
                            amountTotal.Text = "Costo total de membresía: " + (double.Parse(cono) - 10.00).ToString() + " USD";
                        }
                    }
                    else
                    {
                        string amountv = Session["Amount"].ToString();

                        amountTotal.Text = "Costo De Inicial: " + amountv + " " + codeCurrency;
                    }

                    decimal tipocambio = decimal.Parse(Session["carrito"].ToString().Split('|')[4]);
                    decimal totalPagar = decimal.Parse(parameterList[3]) * tipocambio;

                    decimal amountSoles = decimal.Parse(Session["Amount"].ToString());
                    decimal amountDolares = amountSoles / tipocambio;

                    string sQuoteAux = Session["QuoteAux"].ToString().Replace("S/.", "");
                    decimal amountQuotesSoles = decimal.Parse(sQuoteAux);
                    decimal amountQuotesDolares = amountQuotesSoles / tipocambio;
                    if (codeCurrency == "PEN")
                    {
                        amountInitialQuote.Text = "Costo De Inicial: " + amountSoles.ToString() + " PEN";
                        numQuotes.Text = "La Membresia esta Dividida en:  " + parameterList[2] + " En Cuotas de " + amountQuotesSoles.ToString() + " PEN";
                        amountAPayCulqui.Text = "Costo Inicial: " + amountSoles.ToString() + " PEN";
                    }
                    else
                    {
                        amountInitialQuote.Text = "Costo De Inicial: " + amountDolares.ToString() + " USD";
                        numQuotes.Text = "La Membresia esta Dividida en:  " + parameterList[2] + " En Cuotas de " + amountQuotesDolares.ToString() + " USD";
                        amountAPayCulqui.Text = "Costo Inicial: " + amountDolares.ToString() + " USD";
                    }
                }
                else
                {
                    // Response.Redirect("Index.aspx",true);
                    var flag = (string)Session["dataQuote"];
                    string[] listParameters;
                    listParameters = new string[300];
                    if (!string.IsNullOrEmpty(flag))
                    {
                        listParameters = Session["dataQuote"].ToString().Split('|');
                        amountInitialQuote.Text = "Costo de la cuota a Pagar $" + listParameters[1];
                        amountAPayCulqui.Text = "S/ " + listParameters[1];
                    }
                    else
                    {
                        var quotePay = (string)Session["quotePay"];
                        if (!string.IsNullOrEmpty(quotePay))
                        {
                            string codeCurrency = Session["CurrencyCode"].ToString();
                            amountInitialQuote.Text = "Costo de la cuota a Pagar " + quotePay + " " + codeCurrency;
                            amountAPayCulqui.Text = quotePay + " " + codeCurrency;

                        }
                        else
                        {
                            amountInitialQuote.Text = "Costo de la cuota a Pagar $" + (string)Session["Amount"];
                            amountAPayCulqui.Text = "S/ " + (string)Session["Amount"];
                        }

                        //Response.Redirect("Index",true);
                    }
                }

                //Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
                //Response.Cache.SetAllowResponseInBrowserHistory(false);
                //Response.Cache.SetNoStore();

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

        protected void lblSalir_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            HttpContext.Current.Response.Redirect("Index.aspx", true);
        }
    }
}