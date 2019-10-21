﻿

namespace MULTI_NIVEL.Views
{
    using System;
    using System.IO;
    using System.Web;
    using System.Web.Security;
    using BussinesRules.User;

    public partial class Red : System.Web.UI.Page
    {
        string def = "profile.png";
        string extension = ".png";
        string name = "";
        string nombreu = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            var obj = HttpContext.Current.User.Identity.Name.Split('¬');

            if (obj.Length == 1)
            {
                Response.Redirect("Register.aspx", true);
            }

            if (!IsPostBack)
            {
                this.lblUser.Text = "Hola " + obj[0];
                this.lblUserName.Text = obj[0];
                this.lblNumPartner.Text = "N° Asociado: " + obj[4];
                this.imgProfile.ImageUrl = "~/Resources/Images/profile.png";
                this.imgProfileFl.ImageUrl = "~/Resources/Images/profile.png";
                             
                BrUser brUser = new BrUser();
                string[] arrayRange = brUser.GetRange(obj[1]).Split('|');               
                Ranguito.Text = arrayRange[2];
                string arrayStatus = brUser.GetAccountStatus(obj[1]).Split('|')[0];
                Status.Text = arrayStatus;

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
                
        }

        protected void lblSalir_Click(object sender, EventArgs e)
        {
            Session.Contents.RemoveAll();
            FormsAuthentication.SignOut();
            HttpContext.Current.Response.Redirect("Index.aspx", true);
        }
    }
}