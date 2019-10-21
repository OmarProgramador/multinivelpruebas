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
    public partial class DetailStore : System.Web.UI.Page
    {
        BrUser brUser = new BrUser();
        string[] obj = HttpContext.Current.User.Identity.Name.Split('¬');
        string code = "";
        string nombreBenef = "";
        string vigencia = "";
        int cantidad = 1;
        string CodigoReserva = "";
        int IdServicio = 0;
        string fVig="";
        DateTime now = DateTime.Now;
        string fAd = "";
        string prec = "0.0";
        string def = "profile.png";
        string extension = ".png";
        string name = "";
        string nombreu = "";

        protected void Page_Load(object sender, EventArgs e)
        {
           code = Request["id"];
            MyConstants myConstants = new MyConstants();

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
            fVig = now.AddDays(+30).ToString(myConstants.DateFormatUser);
            fAd = new DateTime(now.Year, now.Month, now.Day).ToString(myConstants.DateFormatUser);
            if (code.Equals("v1"))
            {
                Image1.ImageUrl = "~/Views/img/collage5.png";
                titulo1.Text = "Paquete vacacional";
                //precio1.Text = "100";
               
                TxtVig.Text = fVig.ToString();
                IdServicio = 1;
                tituPaq.Text = titulo1.Text;
            }

            if (code.Equals("v2"))
            {
                Image1.ImageUrl = "~/Views/img/ticketaereo.png";
                titulo1.Text = "Ticket Aereo";
                //precio1.Text = "200";
               
                TxtVig.Text = fVig.ToString();
                IdServicio = 2;
                tituPaq.Text = titulo1.Text;
            }
            if (code.Equals("v3"))
            {
                Image1.ImageUrl = "~/Views/img/hotel10.jpg";
                //precio1.Text = "300";
               
                titulo1.Text = "Hotel";
                TxtVig.Text = fVig.ToString();
                IdServicio = 3;
                tituPaq.Text = titulo1.Text;
            }
            if (code.Equals("s6"))
            {
                Image1.ImageUrl = "~/Views/img/hotel10.jpg";
                //precio1.Text = "300";

                titulo1.Text = "Hotel";
                TxtVig.Text = fVig.ToString();
                IdServicio = 8;
                tituPaq.Text = titulo1.Text;
            }
            //if (code.Equals("v4"))
            //{
            //    Image1.ImageUrl = "~/Views/img/hotel10.jpg";
            //    precio1.Text = "xx.xx";
            //    titulo1.Text = "Hotel";
            //    prec = precio1.Text;
            //    TxtVig.Text = fVig.ToString();
            //    IdServicio = 3;

            //}
            //if (code.Equals("v5"))
            //{
            //    Image1.ImageUrl = "~/Views/img/hotel10.jpg";
            //    precio1.Text = "xx.xx";
            //    titulo1.Text = "Hotel";
            //    prec = precio1.Text;
            //    TxtVig.Text = fVig.ToString();
            //    IdServicio = 3;

            //}

        }

        protected void btnComprar_Click(object sender, EventArgs e)
         {

            nombreBenef = TextName.Text;
            vigencia = fVig;
            CodigoReserva = TextCod.Text;
            //var reg = nombreBenef + "|" + vigencia + "|" + CodigoReserva + "|" + cantidad + "|" + fAd + "|" + IdServicio + "|" + obj[3];
            //brUser.RegisterService(reg);
           
            string req2 = "";

            if (Session["precio"] != null)
            {
                req2 = Session["precio"].ToString();
            }

            if (!string.IsNullOrEmpty(req2)) // precio vacio apartado 1;  lleno = apartado2; 
            {

                Session["servicio"] = (nombreBenef +"|"+ vigencia + "|"+ cantidad + "|" + fAd + "|" + IdServicio + "|" + titulo1.Text );

                Response.Redirect("PayType.aspx");
            } 
            else
            { //apartado 1

                var reg = nombreBenef + "|" + vigencia + "|" + CodigoReserva + "|" + cantidad + "|" + fAd + "|" + IdServicio + "|" + obj[1] + "|" + "2" + "|" + "culqui.png";
                bool qwe = brUser.RegisterService(reg);
                if (IdServicio == 8)
                {
                    Response.Redirect("TravelBenefits.aspx#listHotel2");
                }
                else
                {
                    Response.Redirect("HistorialCompras.aspx");
                }
            }

            //Response.Redirect("HistorialCompras.aspx");


            //if (code.Equals("v1"))
            //{
            //    nombreBenef = TextName.Text;
            //    vigencia = fVig;
            //    CodigoReserva = TextCod.Text;
            //    IdServicio = 1;

            //}
            //if (code.Equals("v2"))
            //{

            //    nombreBenef = TextName.Text;
            //    vigencia = fVig;
            //    CodigoReserva = TextCod.Text;
            //    IdServicio = 1;
            //}
            //if (code.Equals("v3"))
            //{

            //    nombreBenef = TextName.Text;
            //    vigencia = fVig;
            //    CodigoReserva = "";
            //    IdServicio = 1;
            //}


        }


        protected void lblSalir_Click(object sender, EventArgs e)
        {
            Session.Contents.RemoveAll();
            FormsAuthentication.SignOut();
            HttpContext.Current.Response.Redirect("Index.aspx", true);
        }

        
    }
}