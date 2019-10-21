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
    public partial class TravelBenefits : System.Web.UI.Page
    {
        BrUser brUser = new BrUser();
        string[] obj = HttpContext.Current.User.Identity.Name.Split('¬');

        string def = "profile.png";
        string extu = ".png";
        string name = "";
        string nombreu = "";
        string _nameTraveler = "";
        string _lastnameTraveler = "";
        string _emailTraveler = "";
        string _phoneTraveler = "";
        DateTime now = DateTime.Now;
        
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


        protected void btnComprar_Click(object sender, EventArgs e)
        {

            _nameTraveler = nameTraveler.Text.Trim();
            _lastnameTraveler = lastNameTraveler.Text.Trim();
            _emailTraveler = emailTraveler.Text.Trim();
            _phoneTraveler = phoneTraveler.Text.Trim();
            string _codePhone = codePhone.Text.Trim();

            string req2 = "";

            //if (!string.IsNullOrEmpty(req2))
            //{
                var reg = _nameTraveler + "|" + _lastnameTraveler + "|" + _emailTraveler + "|" + _phoneTraveler + "|" + obj[1] + "|" + _codePhone;
                //Response.Redirect("PayType.aspx");
                bool qwe = brUser.RegisterTraveler(reg);
                if (qwe == true)
                {
                   Response.Redirect("TravelBenefits.aspx");
            }
                //Response.Redirect("HistorialCompras.aspx");
        }




        protected void lbkBtnSalir_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            FormsAuthentication.SignOut();
            HttpContext.Current.Response.Redirect("Index.aspx", true);
        }
    }
}