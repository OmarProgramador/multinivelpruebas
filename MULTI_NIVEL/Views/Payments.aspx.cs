
namespace MULTI_NIVEL.Views
{
    using BussinesRules;
    using Entities;
    using System;
    using System.IO;
    using System.Web;
    using System.Web.Security;

    public partial class Payments : System.Web.UI.Page
    {
        string def = "profile.png";
        string extension = ".png";
        string name = "";
        string nombreu = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            var obj = HttpContext.Current.User.Identity.Name.Split('¬');
            // txtAct.Text = new HtmlGenericControl("txtAnt").InnerText;
            if (obj.Length == 1)
            {
                Response.Redirect("Register.aspx", true);
            }

            //txtInterest.Text = "10%";
            for (var x = 1; x <= 10; x++)
            {
                ddlInterest.Items.Add(x.ToString() + "%");
            }
            for (var x = 1; x <= 24; x++)
            {
                ddlSons.Items.Add(x.ToString());
            }
            ddlSons.DataBind();
            if (!IsPostBack)
            {
                this.lblUser.Text = "Hola " + obj[0];
                this.lblUserName.Text = obj[0];
                this.lblNumPartner.Text = "N° Asociado: " + obj[4];
                this.imgProfile.ImageUrl = "~/Resources/Images/profile.png";
                this.imgProfileFl.ImageUrl = "~/Resources/Images/profile.png";

                for (int i = 0; i < 32; i++)
                {
                    ddlQuote.Items.Add((i + 1).ToString());
                }
                //BrUser brUser = new BrUser();
                //int idMember = int.Parse(brUser.GetMembershipType(obj[1]));
                //brUser = null;

                //var div = new HtmlGenericControl("myModal");
                //div.Style("display")="block";
                //div.Attributes.Add("style", "display:block");

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
                imgProfileFl.Style.Add("width", "40px");
                imgProfileFl.Style.Add("height", "40px");
                imgProfileFl.Style.Add("margin", "0 auto");

            }


            //BrDaysFree brDaysFree = new BrDaysFree();

            //var data = brDaysFree.GetDaysByUserName(User.Identity.Name.Split('¬')[1], 0).Split('|');

            //LblDataDayFre.Text = $"{data[0]} de {data[1]} dias utilizados de holgura."; 

            //LinkButton linkButton = new LinkButton();

            //linkButton.n = "";
            //linkButton.OnClientClick = "";

        }


        protected void btnSubirImagen_Click(object sender, EventArgs e)
        {
            try
            {
                MyConstants mc = new MyConstants();
                var arrayLogin = HttpContext.Current.User.Identity.Name.Split('¬');

                Session["SwitchAmort"] = "1";

                var idMemership = int.Parse(lblIdMembership.Text);
                Session["IdImg"] = idMemership.ToString();

                BrMembershipPayDetail brPay = new BrMembershipPayDetail();

                var arrayQuote = brPay.GetFullDescriptionQuote(idMemership, arrayLogin[1]).Split('|');

                if (arrayQuote.Length < 2)
                {
                     
                    return;
                }

                var typeChange = decimal.Parse(arrayQuote[10]);
                var currencyCode = arrayQuote[11].Trim();

                var description = txtMemb.Text.Trim();
                var numberQuotesCurrent = int.Parse(txtTest.Text);
                var numberQuotesDismis = int.Parse(txtCount.Text);

                var newNumberQuote = numberQuotesCurrent - numberQuotesDismis;

                var amountAmortize = decimal.Parse(txtAct.Text);

                var percentInteres = mc.AmountInteresAnual;

                //descripcion-numero de cuotas -monto- numero de %
                Session["dataAmort"] = description + '|' + newNumberQuote.ToString() + '|' + amountAmortize.ToString() + '|' + percentInteres.ToString() + "|" + typeChange.ToString() + "|" + currencyCode;
                Session["Amount"] = amountAmortize.ToString();
                Session["CurrencyCode"] = currencyCode;

            }
            catch (Exception ex)
            {
                Response.Redirect("Index.aspx?error=" + ex.Message);
            }
            Response.Redirect("PayQuote.aspx");
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            FormsAuthentication.SignOut();
            Response.Redirect("Index.aspx", true);
        }
    }
}






