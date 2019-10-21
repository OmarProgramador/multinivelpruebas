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
    public partial class PayServices : System.Web.UI.Page
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
                if (Session["servicio"] != null)
                {
                    string[] parameterList = Session["servicio"].ToString().Split('|');

                    titlePAY.Text = "Pago De Servicios ";
                    nameBenef.Text = "Nombre del Beneficiario: " + parameterList[0];
                    typeMembreship.Text = "Tipo de servicio:  " + parameterList[5];
                    //costeAdulto.Text = "Costo por Adulto:  "+parameterList[6];
                    //costeNino.Text = "Costo por Niño:  "+parameterList[7];
                    fVig.Text = "Vigencia:  " + parameterList[1];
                    var cono = parameterList[0];
                    //double tipoCambio = Double.Parse(parameterList[4]);
                    //amountTotal.Text = "Costo De Inicial: S/ " + Session["Amount"].ToString();
                    amountTotal.Text = "Costo total: S/ " + Session["precio"].ToString();
                    //amountInitialQuote.Text = "Costo De Inicial: S/ " + Session["Amount"].ToString();
                    //numQuotes.Text = "La Membresia esta Dividida en:  " + parameterList[2] + " En Cuotas de " + Session["QuoteAux"].ToString();
                    //double tipocambio = double.Parse(Session["carrito"].ToString().Split('|')[4]);
                    //double totalPagar = double.Parse(parameterList[3]) * tipocambio;
                    string totalPagar = Session["precio"].ToString();
                    //amountAPayCulqui.Text = "Costo Inicial: s/." + Session["precio"].ToString();                              
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
        }
        protected void lblSalir_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            HttpContext.Current.Response.Redirect("Index.aspx", true);
        }
    }
}