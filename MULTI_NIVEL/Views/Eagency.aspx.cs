using BussinesRules.User;
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
    public partial class Eagency : System.Web.UI.Page
    {
        string def = "profile.png";
        string extension = ".png";
        string name = "";
        string nombreu = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var arraLogin = HttpContext.Current.User.Identity.Name.Split('¬');
                if (arraLogin.Length == 1)
                {
                    Response.Redirect("Register.aspx", true);
                }


                Session["Referido"] = arraLogin[1];


                this.lblUser.Text = "Hola " + arraLogin[0];
                this.lblUserName.Text = arraLogin[0];
                this.lblNumPartner.Text = "N° Asociado: " + arraLogin[4];

                if (true)
                {
                    this.imgProfile.ImageUrl = "~/Resources/Images/profile.png";
                    this.imgProfileFl.ImageUrl = "~/Resources/Images/profile.png";
                }

                BrUser brUser = new BrUser();
                string nsocios = brUser.GetCountsAsociate();
                //lblnsocios.Text = nsocios;

                // Imagen de PErfil
                var rutaImgP = HttpContext.Current.Server.MapPath("~/Resources/imguser");
                DirectoryInfo di1 = new DirectoryInfo(rutaImgP);
                nombreu = arraLogin[1];
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
        }
        protected void lbkBtnSalir_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            FormsAuthentication.SignOut();
            HttpContext.Current.Response.Redirect("Index.aspx", true);
        }

    }
}