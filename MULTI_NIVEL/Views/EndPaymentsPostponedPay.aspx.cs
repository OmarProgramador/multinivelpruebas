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
    public partial class EndPaymentsPostponedPay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                if (Session["carrito"] != null)
                {
                    string[] arrayCarrito = Session["carrito"].ToString().Split('|');
                    string codeMembership = arrayCarrito[6].Trim();
                  
                    SendEmailFaltaPago();

                    if (codeMembership == "EXP" || codeMembership == "LHT" || codeMembership == "STD" ||
                        codeMembership == "PLUS" || codeMembership == "TOP" || codeMembership == "VIT")
                    {
                        this.SendEmailClub();
                    }

                    if (codeMembership == "MVC" || codeMembership == "EVOL")
                    {
                        this.SendEmailVacacional();
                    }

                    if (codeMembership == "SBY")
                    {
                        this.SendEmailFounder();
                    }

                }


                Session.Contents.RemoveAll();
                Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
                Response.Cache.SetAllowResponseInBrowserHistory(false);
                Response.Cache.SetNoStore();


                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                }
            }
            Session.Clear();
        }

        private void SendEmailFounder()
        {
            string nombre = "", dni = "", username = "", correo = "", correlativo = "";
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
            cuerpo += "<h2 style='text-align: center;'>Socio de Ribera del Rio Club Resort</h2>";
            cuerpo += "<p style='margin-left: 10%;margin-right: 10%; '>En nombre de InResorts y Ribera del Rio es un placer darle la bienvenida como futuro socio fundador, esperando que disfrute con nosotros las mejores experiencias. Ribera del Río Club Resort está abierto a su participación en nuestras diversas actividades, puede consultar en cualquier momento cualquier duda o enviarnos cualquier sugerencia.</p> ";
            cuerpo += "<p style='margin-left: 10%;margin-right: 10%; '>A continuación, le resumimos un poco la información sobre los beneficios con los que contará por formar parte de la familia de Ribera del Río Club Resort como Socio.</p> </div>";

            cuerpo += "<div style='width: 100%;text-align: center;display: flex; margin: 0 auto;'>";
            cuerpo += "<ul style='list-style: none;text-align: center; width: 88px;display: inline-block;padding: 0;margin: auto auto;'>";
            cuerpo += "<li> Club 365.</li><li> Noches Hoteleras.</li></ul>";
            cuerpo += "<ul style='list-style: none;text-align: center; width: 88px;display: inline-block;padding: 0;margin: auto auto;'>";
            cuerpo += "<li> Descuentos.</li><li> Viajes.</li></ul>";
            cuerpo += "<ul style='list-style: none;text-align: center; width: 88px;display: inline-block;padding: 0;margin: auto auto;'>";
            cuerpo += "<li> Valorización de Inversión.</li><li> Plan de Referencias.</li></ul></div>";

            cuerpo += "<div style='width: 100%'>";
            cuerpo += "<p style='margin-left: 10%;margin-right: 10%; '>Para Ribera del Río Club Resort, es de gran satisfacción contar con clientes tan importantes como usted y su familia que son participes del crecimiento de nuestra empresa, es por eso que, de quedar alguna interrogante al respecto, puede consultar nuestra pagina web www.cieneguillariberadelrio.com o comunicarse al telefono 938627411 o al correo de socios@cieneguillariberadelrio.com en donde estamos prestos a cualquier inquietud, aclaración o trámites para el uso de su Membresía.</p>";
            cuerpo += "<p style='margin-left: 10%;margin-right: 10%; '>Para realizar cualquier pago relacionado con el contrato adquirido de la Membresía de Ribera del Rio Club Resort, recuerde que esto lo puede hacer mediante su oficina virtual o a travez de nuestras cuentas de recaudo empresarial.Es de resaltar que sus pagos sólo deberá realizarlos a las cuentas que se indican en su contrato, de lo contrario, la compañia No responderá por pagos realizados a cuenta de terceros.</p>";

            cuerpo += "<center><div style='width: 100%'>";
            cuerpo += "<a style='text-decoration: none;' href='https://inresorts.club'>";
            cuerpo += "<center><div style='background: #0d80ea;border-radius:10px;width: 180px;height: 58px;font-size: 16px;color: white;font-weight: bold;padding: 5px;cursor: pointer;text-align: center;margin: 23px;'>Acceso a Oficina Virtual<div></center>";
            cuerpo += "</a></div></center>";

            cuerpo += "<div style='border: 2px solid gray;margin-left: 30%;margin-right: 30%;border-radius: 8px '>";
            cuerpo += "<center><p> Usuario: <b>" + username + "</b></p><p> Password: <b>" + username + "</b></p></center></div>";
            cuerpo += "<p style='margin-left: 10%;margin-right: 10%; '>";
            cuerpo += "Le adjuntamos toda la documentación y anexos, relacionados a su afilicación </p>";
            cuerpo += "<div style='margin-left: 10%;'>";
            cuerpo += "<p style=''>Saludos Cordiales</p><p  style=''>Equipo inResorts</p> <p  style=''></p></div>";
            cuerpo += "<div style='margin: 5%; width: 70%;background-image: url('https://lh3.googleusercontent.com/NSDQDl8ytJrWSwMe0b3b9DlxubIal-RBEPIWI1a-15f9ynEGQ9eYjTnm-PVqst26f4KJThmjOEPK4lcVoaUw=w1016-h917-rw');'></ div > ";
            cuerpo += "<img style='width: 100%' src='https://preview.ibb.co/ixY7iL/fondo222.png'>";
            cuerpo += "</div>";


            cuerpo += "</body>";
            cuerpo += "</html>";


            string ruta = HttpContext.Current.Server.MapPath("~/Resources/PoliticsPdf/");
            Email email = new Email();
            if (!string.IsNullOrEmpty((string)Session["arrayKit"]))
            {
                email.SubmitEmailKit(correo, "[RIBERA DEL RIO - INRESORTS , Registro Exitoso]", cuerpo, true, ruta);
                return;
            }
            correlativo = Session["correlativoDoc"].ToString();
            username = username + correlativo;

            bool sendemail = email.SubmitEmail(correo, "[RIBERA DEL RIO - INRESORTS , Registro Exitoso]", cuerpo, true, ruta, username);
            string correoOamr = "omarurteaga@gmail.com";

            sendemail = email.SubmitEmail(correoOamr, "[RIBERA DEL RIO - INRESORTS , Registro Exitoso]", cuerpo, true, ruta, username);

        }

        private void SendEmailVacacional()
        {
            string nombre = "", dni = "", username = "", correo = "", correlativo = "";
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
            cuerpo += "<h2 style='text-align: center;'>Socio de Ribera del Rio Club Resort</h2>";
            cuerpo += "<p style='margin-left: 10%;margin-right: 10%; '>En nombre de InResorts y Ribera del Rio es un placer darle la bienvenida como socio, esperando que disfrute con nosotros las mejores experiencias. Ribera del Río Club Resort está abierto a su participación en nuestras diversas actividades, puede consultar en cualquier momento cualquier duda o enviarnos cualquier sugerencia.</p> ";
            cuerpo += "<p style='margin-left: 10%;margin-right: 10%; '>A continuación, le resumimos un poco la información sobre los beneficios con los que contará por formar parte de la familia de Ribera del Río Club Resort como Socio.</p> </div>";

            cuerpo += "<div style='width: 100%;text-align: center;display: flex; margin: 0 auto;'>";
            cuerpo += "<ul style='list-style: none;text-align: center; width: 88px;display: inline-block;padding: 0;margin: auto auto;'>";
            cuerpo += "<li> Club 365.</li><li> Noches Hoteleras.</li></ul>";
            cuerpo += "<ul style='list-style: none;text-align: center; width: 88px;display: inline-block;padding: 0;margin: auto auto;'>";
            cuerpo += "<li> Descuentos.</li><li> Viajes.</li></ul>";
            cuerpo += "<ul style='list-style: none;text-align: center; width: 88px;display: inline-block;padding: 0;margin: auto auto;'>";
            cuerpo += "<li> Valorización de Inversión.</li><li> Plan de Referencias.</li></ul></div>";

            cuerpo += "<div style='width: 100%'>";
            cuerpo += "<p style='margin-left: 10%;margin-right: 10%; '>Para Ribera del Río Club Resort, es de gran satisfacción contar con clientes tan importantes como usted y su familia que son participes del crecimiento de nuestra empresa, es por eso que, de quedar alguna interrogante al respecto, puede consultar nuestra pagina web www.cieneguillariberadelrio.com o comunicarse al telefono 938627411 o al correo de socios@cieneguillariberadelrio.com en donde estamos prestos a cualquier inquietud, aclaración o trámites para el uso de su Membresía.</p>";
            cuerpo += "<p style='margin-left: 10%;margin-right: 10%; '>Para realizar cualquier pago relacionado con el contrato adquirido de la Membresía de Ribera del Rio Club Resort, recuerde que esto lo puede hacer mediante su oficina virtual o a travez de nuestras cuentas de recaudo empresarial.Es de resaltar que sus pagos sólo deberá realizarlos a las cuentas que se indican en su contrato, de lo contrario, la compañia No responderá por pagos realizados a cuenta de terceros.</p>";

            cuerpo += "<center><div style='width: 100%'>";
            cuerpo += "<a style='text-decoration: none;' href='https://inresorts.club'>";
            cuerpo += "<center><div style='background: #0d80ea;border-radius:10px;width: 180px;height: 58px;font-size: 16px;color: white;font-weight: bold;padding: 5px;cursor: pointer;text-align: center;margin: 23px;'>Acceso a Oficina Virtual<div></center>";
            cuerpo += "</a></div></center>";

            cuerpo += "<div style='border: 2px solid gray;margin-left: 30%;margin-right: 30%;border-radius: 8px '>";
            cuerpo += "<center><p> Usuario: <b>" + username + "</b></p><p> Password: <b>" + username + "</b></p></center></div>";
            cuerpo += "<p style='margin-left: 10%;margin-right: 10%; '>";
            cuerpo += "Le adjuntamos toda la documentación y anexos, relacionados a su afilicación </p>";
            cuerpo += "<div style='margin-left: 10%;'>";
            cuerpo += "<p style=''>Saludos Cordiales</p><p  style=''>Equipo inResorts</p> <p  style=''></p></div>";
            cuerpo += "<div style='margin: 5%; width: 70%;background-image: url('https://lh3.googleusercontent.com/NSDQDl8ytJrWSwMe0b3b9DlxubIal-RBEPIWI1a-15f9ynEGQ9eYjTnm-PVqst26f4KJThmjOEPK4lcVoaUw=w1016-h917-rw');'></ div > ";
            cuerpo += "<img style='width: 100%' src='https://preview.ibb.co/ixY7iL/fondo222.png'>";
            cuerpo += "</div>";


            cuerpo += "</body>";
            cuerpo += "</html>";


            string ruta = HttpContext.Current.Server.MapPath("~/Resources/PoliticsPdf/");
            Email email = new Email();
            if (!string.IsNullOrEmpty((string)Session["arrayKit"]))
            {
                email.SubmitEmailKit(correo, "[RIBERA DEL RIO - INRESORTS , Registro Exitoso]", cuerpo, true, ruta);
                return;
            }
            correlativo = Session["correlativoDoc"].ToString();
            username = username + correlativo;

            email.SubmitEmail(correo, "[RIBERA DEL RIO - INRESORTS , Registro Exitoso]", cuerpo, true, ruta, username);
            string correoOamr = "omarurteaga@gmail.com";

            email.SubmitEmail(correoOamr, "[RIBERA DEL RIO - INRESORTS , Registro Exitoso]", cuerpo, true, ruta, username);

        }

        private void SendEmailClub()
        {
            string nombre = "", dni = "", username = "", correo = "", correlativo = "";
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
            cuerpo += "<h2 style='text-align: center;'>Socio de Ribera del Rio Club Resort</h2>";
            cuerpo += "<p style='margin-left: 10%;margin-right: 10%; '>En nombre de InResorts y Ribera del Rio es un placer darle la bienvenida, esperando que disfrute con nosotros las mejores experiencias. Ribera del Río Club Resort está abierto a su participación en nuestras diversas actividades, puede consultar en cualquier momento cualquier duda o enviarnos cualquier sugerencia.</p> ";
            cuerpo += "<p style='margin-left: 10%;margin-right: 10%; '>A continuación, le resumimos un poco la información sobre los beneficios con los que contará por formar parte de la familia de Ribera del Río Club Resort como Socio.</p> </div>";

            cuerpo += "<div style='width: 100%;text-align: center;display: flex; margin: 0 auto;'>";
            cuerpo += "<ul style='list-style: none;text-align: center; width: 88px;display: inline-block;padding: 0;margin: auto auto;'>";
            cuerpo += "<li> Club 365.</li><li> Noches Hoteleras.</li></ul>";
            cuerpo += "<ul style='list-style: none;text-align: center; width: 88px;display: inline-block;padding: 0;margin: auto auto;'>";
            cuerpo += "<li> Descuentos.</li><li> Viajes.</li></ul>";
            cuerpo += "<ul style='list-style: none;text-align: center; width: 88px;display: inline-block;padding: 0;margin: auto auto;'>";
            cuerpo += "<li> Valorización de Inversión.</li><li> Plan de Referencias.</li></ul></div>";

            cuerpo += "<div style='width: 100%'>";
            cuerpo += "<p style='margin-left: 10%;margin-right: 10%; '>Para Ribera del Río Club Resort, es de gran satisfacción contar con clientes tan importantes como usted y su familia que son participes del crecimiento de nuestra empresa, es por eso que, de quedar alguna interrogante al respecto, puede consultar nuestra pagina web www.cieneguillariberadelrio.com o comunicarse al telefono 938627411 o al correo de socios@cieneguillariberadelrio.com en donde estamos prestos a cualquier inquietud, aclaración o trámites para el uso de su Membresía.</p>";
            cuerpo += "<p style='margin-left: 10%;margin-right: 10%; '>Para realizar cualquier pago relacionado con el contrato adquirido de la Membresía de Ribera del Rio Club Resort, recuerde que esto lo puede hacer mediante su oficina virtual o a travez de nuestras cuentas de recaudo empresarial.Es de resaltar que sus pagos sólo deberá realizarlos a las cuentas que se indican en su contrato, de lo contrario, la compañia No responderá por pagos realizados a cuenta de terceros.</p>";

            cuerpo += "<center><div style='width: 100%'>";
            cuerpo += "<a style='text-decoration: none;' href='https://inresorts.club'>";
            cuerpo += "<center><div style='background: #0d80ea;border-radius:10px;width: 180px;height: 58px;font-size: 16px;color: white;font-weight: bold;padding: 5px;cursor: pointer;text-align: center;margin: 23px;'>Acceso a Oficina Virtual<div></center>";
            cuerpo += "</a></div></center>";

            cuerpo += "<div style='border: 2px solid gray;margin-left: 30%;margin-right: 30%;border-radius: 8px '>";
            cuerpo += "<center><p> Usuario: <b>" + username + "</b></p><p> Password: <b>" + username + "</b></p></center></div>";
            cuerpo += "<p style='margin-left: 10%;margin-right: 10%; '>";
            cuerpo += "Le adjuntamos toda la documentación y anexos, relacionados a su afilicación </p>";
            cuerpo += "<div style='margin-left: 10%;'>";
            cuerpo += "<p style=''>Saludos Cordiales</p><p  style=''>Equipo inResorts</p> <p  style=''></p></div>";
            cuerpo += "<div style='margin: 5%; width: 70%;background-image: url('https://lh3.googleusercontent.com/NSDQDl8ytJrWSwMe0b3b9DlxubIal-RBEPIWI1a-15f9ynEGQ9eYjTnm-PVqst26f4KJThmjOEPK4lcVoaUw=w1016-h917-rw');'></ div > ";
            cuerpo += "<img style='width: 100%' src='https://preview.ibb.co/ixY7iL/fondo222.png'>";
            cuerpo += "</div>";


            cuerpo += "</body>";
            cuerpo += "</html>";


            string ruta = HttpContext.Current.Server.MapPath("~/Resources/PoliticsPdf/");
            Email email = new Email();
            if (!string.IsNullOrEmpty((string)Session["arrayKit"]))
            {
                email.SubmitEmailKit(correo, "[RIBERA DEL RIO - INRESORTS , Registro Exitoso]", cuerpo, true, ruta);
                return;
            }
            correlativo = Session["correlativoDoc"].ToString();
            username = username + correlativo;

            email.SubmitEmail(correo, "[RIBERA DEL RIO - INRESORTS , Registro Exitoso]", cuerpo, true, ruta, username);
            string correoOamr = "omarurteaga@gmail.com";

            email.SubmitEmail(correoOamr, "[RIBERA DEL RIO - INRESORTS , Registro Exitoso]", cuerpo, true, ruta, username);

        }

        private void SendEmailFaltaPago()
        {
            string nombre = "", dni = "", username = "", correo = "", correlativo = "";
            //Session["datos"] = "Aaaaa|Aaaa|birthDay|M|DocumentType|88884444$NombreC|ApellidoC|1|313231c$bankName|nombreBankAccount|TypeAccount|nroAccount|nroTaxer|SocialReason|fiscalAdress|UserType$programador.pazo@gmail.com|nroCell|nroCell2|country|State|City|Adress";
            //Session["carrito"] = "6000.00|descripcionDB|60|9750.00|3.25|10|TOP";
            //Session["cronograma"] = "6000|222";
            string[] datos = Session["datos"].ToString().Split('$');
            string[] arraycontacto = datos[3].Split('|');
            string[] arrayperson = datos[0].Split('|');

            MyConstants mc = new MyConstants();
            var bankAccount = mc.BankAccount;

            double firtsPay = 100;

            if (Session["FirtsPay"] != null)
            {
                firtsPay = double.Parse(Session["FirtsPay"].ToString());
            }
            string currencyCode = "PEN";

            if (Session["TypeCurrency"] != null)
            {
                currencyCode = Session["TypeCurrency"].ToString();
            }

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
            cuerpo += "<h2 style='text-align: center;'>Muy pronto formarás parte de la familia inResorts. Estamos a la espera de que nos brindes tu comprobante de pago</h2>";
            cuerpo += "<center><p style='margin-left: 10%;margin-right: 10%;'>Cuando lo tengas listo, solo tienes que subirlo a nuestra pagina y enseguida lo estaremos validando</p></center> ";
            cuerpo += "";
            cuerpo += "<center><div style='width: 100%'>";
            cuerpo += "<p style='margin-left: 10%;margin-right: 10%; '> Click en el boton para validar el pago.</p>";
            cuerpo += "<a style='text-decoration: none;' href='https://inresorts.club/Views/Login.aspx?usuario=" + dni + "&fullname=" + fullname + "'>";
            cuerpo += "<center><div style='background: #0d80ea;border-radius:10px;width: 158px;height: 30px;font-size: 16px;color: white;font-weight: bold;padding: 4px;padding-top: 10px;cursor: pointer;text-align: center;margin: 23px;'>Validar pago<div></center>";
            cuerpo += "</a></div></center>";

            cuerpo += "<center><div style='width: 100%'>";
            cuerpo += "<p style='margin-left: 10%;margin-right: 10%; '></p>";
            cuerpo += "<center>Recuerde que el pago lo puede realizar mediante deposito en nuestra cuenta corriente atravez de Agente BCP, Agencia BCP O transferencia bancaria desde Banca por Internet.</center>";
            cuerpo += "</div></center>";


            cuerpo += "<center><div style='width: 100%'>";
            cuerpo += "<p style='margin-left: 10%;margin-right: 10%; '>Cuenta Bancaria </p>";
            cuerpo += $"<center>BCP: N° {bankAccount} - Valle Encantado S.A.C</center>";
            cuerpo += "</div></center>";

            cuerpo += "<center><div style='width: 50%;display: flex;border-radius: 10px;margin: 11px;'>";
            cuerpo += "<p style='margin-left: 10%;margin-right: 10%;'>Monto a depositar</p>";

            cuerpo += "<center style=' margin: 12px;'> S/." + firtsPay.ToString() + " (" + currencyCode + ")</center>";
            cuerpo += "</div></center>";

            //cuerpo += "<center><img src='http://www.inresorts.club/Views/img/recibo.png' align='left' style='width: 100%'></center></div>";
            cuerpo += "<div style='margin-left: 9%;'>";
            cuerpo += "<p style='margin:5px'>Saludos Cordiales</p><p  style='margin:5px'>Equipo inResorts</p></div>";
            cuerpo += "<div style='margin: 5%; width: 70%;background-image: url('https://lh3.googleusercontent.com/NSDQDl8ytJrWSwMe0b3b9DlxubIal-RBEPIWI1a-15f9ynEGQ9eYjTnm-PVqst26f4KJThmjOEPK4lcVoaUw=w1016-h917-rw');'></ div > ";
            cuerpo += "<img style='width: 100%' src='https://preview.ibb.co/ixY7iL/fondo222.png'>";
            cuerpo += "</div>";

            cuerpo += "</body>";
            cuerpo += "</html>";

            Email email = new Email();
            email.SubmitEmail(correo, "[Ribera del Rio - Inresorts, Registro en Proceso] ", cuerpo);

            string correoOamr = "omarurteaga@gmail.com";

            email.SubmitEmail(correoOamr, "[Ribera del Rio - Inresorts, Registro en Proceso] ", cuerpo);


        }

        private string ToCapitalize(string _text)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;

            return textInfo.ToTitleCase(_text);
        }

    }
}