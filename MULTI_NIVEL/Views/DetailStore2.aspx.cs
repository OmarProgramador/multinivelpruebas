using BussinesRules.User;
using Entities;
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
    public partial class DetailStore2 : System.Web.UI.Page
    {
        BrUser brUser = new BrUser();
        string[] obj = HttpContext.Current.User.Identity.Name.Split('¬');
        string code = "";
        string nombreBenef = "";
        string vigencia = "";
        int cantidad1 = 0;
        int cantidad2 = 0;
        int cantidad = 0;
        int padulto;
        int pniño;
        string CodigoReserva = "";
        int IdServicio = 0;
        DateTime now = DateTime.Now;
        string fAd = "";
        string fVig = "";
        string def = "profile.png";
        string extension = ".png";
        string name = "";
        string nombreu = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            MyConstants myConstants = new MyConstants();
            code = Request["id"];
            fVig = now.AddDays(+180).ToString(myConstants.DateFormatUser);
            fAd = new DateTime(now.Year, now.Month, now.Day).ToString(myConstants.DateFormatUser);

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
                imgProfileFl.Style.Add("width", "80px");
                imgProfileFl.Style.Add("height", "80px");
                imgProfileFl.Style.Add("margin", "0 auto");
            }

            if (code.Equals("c1"))
            {
                Image1.ImageUrl = "~/Views/img/full1.jpg";
                titulo1.Text = "FullDay";
                padulto = 20;
                pniño = 15;
                fAdqui.Text = fAd;
                TxtVig.Text = fVig.ToString();
                IdServicio = 4;
                Session["fAdqui"] = fAdqui.Text;
                Session["IdServicio"] = IdServicio;
                tituPaq.Text = titulo1.Text;
            }
            if (code.Equals("c2"))
            {
                Image1.ImageUrl = "~/Views/img/camping.jpg";
                titulo1.Text = "Camping";
                padulto = 35;
                pniño = 25;
                TxtVig.Text = fVig.ToString();
                fAdqui.Text = fAd;
                IdServicio = 5;
                Session["fAdqui"] = fAdqui.Text;
                Session["IdServicio"] = IdServicio;
                tituPaq.Text = titulo1.Text;
            }

            if (code.Equals("c3"))
            {
                Image1.ImageUrl = "~/Views/img/fulldayTodoIncluido.png";
                titulo1.Text = "Full Day Todo Incluido";
                padulto = 35;
                pniño = 25;
                TxtVig.Text = fVig.ToString();
                fAdqui.Text = fAd;
                IdServicio = 6;
                Session["fAdqui"] = fAdqui.Text;
                Session["IdServicio"] = IdServicio;
                tituPaq.Text = titulo1.Text;
            }

        }

        protected void btnComprar_Click(object sender, EventArgs e)
        {
            int numero = 0;
            nombreBenef = TextName.Text;

            if (!string.IsNullOrEmpty(TextCant1.Text))
            {
                if (!int.TryParse(TextCant1.Text, out numero))
                {
                    lblErrorSi.Text="no es un numero valido";
                    return ;
                }
                else
                {
                    cantidad1 = int.Parse(TextCant1.Text);
                }
                
            }
            if (!string.IsNullOrEmpty(TextCant2.Text))
            {
                if (!int.TryParse(TextCant2.Text, out numero))
                {
                    lblErrorSi.Text = "no es un numero valido";
                    return;
                }
                else
                {
                    cantidad2 = int.Parse(TextCant2.Text);
                }

            }

            vigencia = fVig;
            CodigoReserva = "";

            cantidad = cantidad1 + cantidad2;
            var prec = cantidad1 * padulto + cantidad2 * pniño;
            Session["precio"] = prec;

            
            Session["servicio"] = (nombreBenef + "|" + vigencia + "|" + cantidad + "|" + fAd + "|" + IdServicio + "|" + titulo1.Text + "|" + padulto + "|" + pniño);
            Response.Redirect("PayType.aspx");
            //Response.Redirect("HistorialCompras.aspx");
        }

        protected void lblSalir_Click(object sender, EventArgs e)
        {
            Session.Contents.RemoveAll();
            FormsAuthentication.SignOut();
            HttpContext.Current.Response.Redirect("Index.aspx", true);
        }

        
    }
}