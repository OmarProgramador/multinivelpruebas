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
    public partial class TransactionsDetail : System.Web.UI.Page
    {
        string def = "profile.png";
        string extu = ".png";
        string name = "";
        string nombreu = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            var obj = HttpContext.Current.User.Identity.Name.Split('¬'); ;

            if (!IsPostBack)
            {
                this.lblUser.Text = "Hola " + obj[0];
                this.lblUserName.Text = obj[0];
                this.lblNumPartner.Text = "N° Asociado: " + obj[4];

                this.imgProfile.ImageUrl = "~/Resources/Images/profile.png";
                this.imgProfileFl.ImageUrl = "~/Resources/Images/profile.png";
                
                hpStore.NavigateUrl = "AddMembership.aspx";
                hpStore1.NavigateUrl = "AddMembership.aspx";

                // Imagen de PErfil
                var rutaImgP = HttpContext.Current.Server.MapPath("~/Resources/imguser");
                DirectoryInfo niwi1 = new DirectoryInfo(rutaImgP);
                nombreu = obj[1];
                foreach (var fi2 in niwi1.GetFiles())
                {
                    var archivo = fi2.Name.Split('.');
                    name = archivo[archivo.Length - 2];
                    extu = archivo[archivo.Length - 1];
                    if (name == nombreu) { def = nombreu + "." + extu; }
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
            Session.Contents.RemoveAll();
            FormsAuthentication.SignOut();
            HttpContext.Current.Response.Redirect("Index.aspx", true);
        }
    }
}