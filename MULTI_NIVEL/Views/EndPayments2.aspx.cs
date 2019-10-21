using BussinesRules.User;
using Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MULTI_NIVEL.Views
{
    public partial class EndPayments2 : System.Web.UI.Page
    {
        BrPayments brPayments;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty((string)Session["datos"]))
                {
                    string nombre = "", dni = "", username = "", correo = "";

                    //Session["datos"] = "Aaaaa|Aaaa|birthDay|M|DocumentType|88884444$NombreC|ApellidoC|1|313231c$bankName|nombreBankAccount|TypeAccount|nroAccount|nroTaxer|SocialReason|fiscalAdress|UserType$programador.pazo@gmail.com|nroCell|nroCell2|country|State|City|Adress";
                    //Session["carrito"] = "6000.00|descripcionDB|60|9750.00|3.25|10|TOP";
                    //Session["cronograma"] = "6000|222";

                    string[] datos = Session["datos"].ToString().Split('$');

                    string[] arraycontacto = datos[3].Split('|');
                    string[] arrayperson = datos[0].Split('|');

                    correo = arraycontacto[0];
                    nombre = arrayperson[0] + " " + arrayperson[1];
                    dni = arrayperson[5];
                    username = arrayperson[0].Substring(0, 1).ToUpper() + arrayperson[1].Substring(0, 1).ToUpper() + dni;

                    string fullname = arrayperson[0].Trim().ToLower() + " " + arrayperson[1].Trim().ToLower();
                    fullname = ToCapitalize(fullname);
                    string[] sepName = arrayperson[0].Split(' ');
                    var fName = ToCapitalize(sepName[0]);
                    var bienvenido = "Bienvenido";
                    if (arrayperson[3] == "F")
                    {
                        bienvenido = "Bienvenida";
                    }

                    var cuerpo = "<html><head><title></title></head><body style='color:black'>";

                    cuerpo += "<div style='width: 100%'>";
                    cuerpo += "<div style='display:flex;'>";
                    cuerpo += "<div style='width:50%;'>";
                    cuerpo += " <img src='http://www.inresorts.club/Views/img/novologo.png' align='left' style='width: 98px;'>";
                    cuerpo += "</div>";
                    cuerpo += "<div style='width:50%;'>";
                    cuerpo += "<img src='http://cieneguillariberadelrio.com/riberadelrio/img/image006.png' align='right' style='width: 120px;padding-top: 7px;'>";
                    cuerpo += "</div>";
                    cuerpo += "</div>";

                    cuerpo += "<img style='width: 100%' src='http://www.inresorts.club/Views/img/fondo.png'>";
                    cuerpo += "<h1 style='margin-top: 2px ;text-align: center;font-weight: bold;font-style: italic;'>" + bienvenido + " " + fName + "</h1>";
                    cuerpo += "<h2 style='text-align: center;'>Estamos Validando tu comprobante, se te estará enviando tus credenciales dentro de las proximas 24 horas.</h2>";
                    cuerpo += "<center><p style='margin-left: 10%;margin-right: 10%;'> </p></center> ";
                    cuerpo += "";
                    //cuerpo += "<div style='width: 100%'>";
                    //cuerpo += "<p style='margin-left: 10%;margin-right: 10%; '> </p>";
                    //cuerpo += "<a href='http://www.inresorts.club'>";
                    //cuerpo += "<center><img src='http://www.inresorts.club/Views/img/recibo.png' align='left' style='width: 100%'></center>";
                    //cuerpo += "</a></div>";

                    cuerpo += "<div style='margin-left: 0%;'>";
                    cuerpo += "<p style=''>Saludos Cordiales</p><p  style=''>Equipo inResorts</p> <p  style=''></p></div>";
                    //cuerpo += "<div style='margin: 5%; width: 70%;background-image: url('https://lh3.googleusercontent.com/NSDQDl8ytJrWSwMe0b3b9DlxubIal-RBEPIWI1a-15f9ynEGQ9eYjTnm-PVqst26f4KJThmjOEPK4lcVoaUw=w1016-h917-rw');'></ div > ";
                    cuerpo += "<img style='width: 100%' src='https://www.inresorts.club/views/img/fondo.png'>";
                    cuerpo += "</div>";

                    cuerpo += "</body>";
                    cuerpo += "</html>";

                    Email email = new Email();
                    bool ssa = email.SubmitEmail(correo, "[Ribera del Rio - Inresorts, Registro en Proceso] ", cuerpo);

                    string correoOamr = "omarurteaga@gmail.com";
                    ssa = email.SubmitEmail(correoOamr, "[Ribera del Rio - Inresorts, Registro en Proceso] ", cuerpo);
                    Session.Contents.RemoveAll();
                }
            }
            else if (Session["SwitchEmailPayQuote"]!=null && (string)Session["SwitchEmailPayQuote"] == "1")
            {

                var calendar = (string)Session["StatusCalendar"];
                var data = (string)Session["StatusCalendar"];
                var listParameters = data.Split('|');
                var data2 = listParameters[0];
                string quotePay = (string)Session["quotePay"];
                brPayments = new BrPayments();
                string EmailUser = brPayments.PayQuoteMembership(data2,"0","recibo.png");

            }
            else {
                Response.Redirect("Index.aspx");
            }
            Session.RemoveAll();

            Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
            Response.Cache.SetAllowResponseInBrowserHistory(false);
            Response.Cache.SetNoStore();
            Session.Clear();
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }

        private string ToCapitalize(string _text)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;

            return textInfo.ToTitleCase(_text);
        }
    }
}