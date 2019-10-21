using BussinesRules.User;
using Entities;
using System;
using System.Globalization;
using System.Threading;
using System.Web;

namespace MULTI_NIVEL.Views
{
    public partial class EndPayments3 : System.Web.UI.Page
    {
        BrUser brUser;
        string fName;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string nombre = "", dni = "", username = "", correo = "";
                string symbol = "S/";
                bool sendEmail = false;
                string currencyCode = "PEN";

                //if (Session["TypeCurrency"] != null)
                //{
                //    currencyCode = Session["TypeCurrency"].ToString();
                //}

                var userNameAfiliate = "";
                var affiliate = "";
                var correoaffiliate = "";
                if (Session["MyAffiliate"] != null)
                {
                    userNameAfiliate = Session["MyAffiliate"].ToString();
                    if (!string.IsNullOrEmpty(userNameAfiliate))
                    {
                        brUser = new BrUser();
                        var dataAfiliate = brUser.GetPersonalInformation(userNameAfiliate).Split('|');
                        affiliate = dataAfiliate[1] + " " + dataAfiliate[2];
                        correoaffiliate = dataAfiliate[5];
                    }
                }

                MyConstants mc = new MyConstants();
                var bankAccount = mc.BankAccount;
                var interbankAccount = mc.InterbankAccount;
                var cuenta = "en Soles";

                var typeChange = 3.30m;

                var oacarrito = Session["carrito"];

                if (oacarrito != null)
                {
                    var acarrito = oacarrito.ToString().Split('|');
                    typeChange = decimal.Parse(acarrito[4]);
                }

                //firtspay es el monto en soles   
                decimal firtsPay = 85 * typeChange;

                if (Session["FirtsPay"] != null)
                {
                    firtsPay = decimal.Parse(Session["FirtsPay"].ToString());
                }

                string moneda = "";
                var omoneda = Session["moneda"];
                if (omoneda != null)
                {
                    moneda = omoneda.ToString();
                }

                if (moneda == "dolar")
                {
                    firtsPay = firtsPay / typeChange;
                    currencyCode = "USD";
                    symbol = "$";
                    bankAccount = mc.BankAccountDolar;
                    interbankAccount = mc.InterbankAccountDolar;
                    cuenta = "en Dolares";
                }


                //Session["datos"] = "Aaaaa|Aaaa|birthDay|M|DocumentType|88884444$NombreC|ApellidoC|1|313231c$bankName|nombreBankAccount|TypeAccount|nroAccount|nroTaxer|SocialReason|fiscalAdress|UserType$samirpazo08@gmail.com|nroCell|nroCell2|country|State|City|Adress";
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
                fName = ToCapitalize(sepName[0]);
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
                cuerpo += $"<p style='margin-left: 10%;margin-right: 10%; '>Cuenta Bancaria {cuenta}</p>";
                cuerpo += $"<center>BCP: N° {bankAccount} - Valle Encantado S.A.C</center>";
                cuerpo += $"<center>BCP: Cuenta Interbancaria N° {interbankAccount} - Valle Encantado S.A.C</center>";
                cuerpo += "</div></center>";

                cuerpo += "<center><p>Monto a depositar</p></center>";

                cuerpo += $"<center><p>{symbol} {firtsPay.ToString("0.00")} ( {currencyCode} )</p></center>";

                //cuerpo += "<center><img src='http://www.inresorts.club/Views/img/recibo.png' align='left' style='width: 100%'></center></div>";
                cuerpo += "<div style='margin-left: 9%;'>";
                cuerpo += "<p style='margin:5px'>Patrocinador: " + affiliate + "</p>";
                cuerpo += "<p style='margin:5px'>Saludos Cordiales</p><p  style='margin:5px'>Equipo inResorts</p></div>";
                cuerpo += "<div style='margin: 5%; width: 70%;background-image: url('https://lh3.googleusercontent.com/NSDQDl8ytJrWSwMe0b3b9DlxubIal-RBEPIWI1a-15f9ynEGQ9eYjTnm-PVqst26f4KJThmjOEPK4lcVoaUw=w1016-h917-rw');'></ div > ";
                cuerpo += "<img style='width: 100%' src='https://preview.ibb.co/ixY7iL/fondo222.png'>";
                cuerpo += "</div>";

                cuerpo += "</body>";
                cuerpo += "</html>";

                Email email = new Email();
                email.SubmitEmail(correo, "[Ribera del Rio - Inresorts, Registro en Proceso] ", cuerpo);

                string correoOamr = "omarurteaga@gmail.com";

                sendEmail = email.SubmitEmail(correoOamr, "[Ribera del Rio - Inresorts, Registro en Proceso] ", cuerpo);

                if (correoaffiliate != "")
                {
                    sendEmail = email.SubmitEmail(correoaffiliate, "[Ribera del Rio - Inresorts, Registro en Proceso] ", cuerpo);
                }

                Session.Contents.RemoveAll();
            }
            Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
            Response.Cache.SetAllowResponseInBrowserHistory(false);
            Response.Cache.SetNoStore();
        }

        private string ToCapitalize(string _text)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;

            return textInfo.ToTitleCase(_text);
        }
    }
}