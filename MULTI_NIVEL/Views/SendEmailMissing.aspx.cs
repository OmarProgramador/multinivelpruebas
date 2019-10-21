using BussinesRules;
using BussinesRules.TypeMembership;
using BussinesRules.User;
using Entities;
using System;
using System.Globalization;
using System.Threading;
using System.Web;

namespace MULTI_NIVEL.Views
{
    public partial class SendEmailMissing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void SendEmail_Click(object sender, EventArgs e)
        {
            bool anwser = false;
            string nombre = "", dni = "", username = "", correo = "";
            //Session["datos"] = "Aaaaa|Aaaa|birthDay|M|DocumentType|88884444$NombreC|ApellidoC|1|313231c$bankName|nombreBankAccount|TypeAccount|nroAccount|nroTaxer|SocialReason|fiscalAdress|UserType$programador.pazo@gmail.com|nroCell|nroCell2|country|State|City|Adress";
            //Session["carrito"] = "6000.00|descripcionDB|60|9750.00|3.25|10|TOP";
            //Session["cronograma"] = "6000|222";

            username = txtUserName.Text;

            if (string.IsNullOrEmpty(username))
            {
                return;
            }

            BrUser brUser = new BrUser();
            MyMessages mm = new MyMessages();

            var arrayperson = brUser.GetPersonalInformation(username).Split('|');
            if (arrayperson.Length < 5)
            {
                return;
            }
            correo = arrayperson[5];
            nombre = arrayperson[1] + " " + arrayperson[2];
            dni = arrayperson[13];
            username = arrayperson[1].Substring(0, 1).ToUpper() + arrayperson[2].Substring(0, 1).ToUpper() + dni;
            string gender = arrayperson[4];
            string name = arrayperson[1];

            BrAccount brAccount = new BrAccount();

            string codeMemb = brAccount.GetLastCodeMembership(username).Trim();

            if (string.IsNullOrEmpty(codeMemb))
            {
                MessageError.Text = "no tiene membresia.";
                return;
            }

            if (rbDoc.Checked)
            {
                BrTypeMembership brTypeMembership = new BrTypeMembership();
                var correlativo = int.Parse(brTypeMembership.GetTotalMemberships(username));
                correlativo--;
                if (correlativo < 0)
                {
                    correlativo = 0;
                }
                username = $"{username}{correlativo}";
                var ruta = HttpContext.Current.Server.MapPath("~/Resources/PoliticsPdf/");
                if (codeMemb == "KIT")
                {
                    anwser = this.SendEmailKit(name, gender, username, ruta, correo);
                }
                if (codeMemb == "EXP" || codeMemb == "LHT" || codeMemb == "STD" ||
                            codeMemb == "PLUS" || codeMemb == "TOP" || codeMemb == "VIT")
                {
                    anwser = this.SendEmailClub(name, gender, username, ruta, correo);
                }
                if (codeMemb == "EVOL" || codeMemb == "MVC")
                {
                    anwser = this.SendEmailVacational(name, gender, username, ruta, correo);
                }
                if (codeMemb == "SBY")
                {
                    anwser = this.SendEmailFounder(name, gender, username, ruta, correo);
                }
            }

            if (rbRece.Checked)
            {
                MyConstants mc = new MyConstants();
                var bankAccount = mc.BankAccount;
                var repsonse_ = brAccount.GetFirtsPayCurrency(username).Split('|');

                var infoAfiliate = brAccount.GetSponsorInfo(username).Split('|');

                var nameAfiliate = infoAfiliate[0];
                var correoAfiliate = infoAfiliate[1];

                var firtsPay = repsonse_[0];
                var currencyCode = repsonse_[1];
                string fullname = arrayperson[1].Trim().ToLower() + " " + arrayperson[2].Trim().ToLower();
                fullname = ToCapitalize(fullname);
                string[] sepName = arrayperson[1].Split(' ');
                var fName = ToCapitalize(sepName[0]);
                var bienvenido = "Bienvenido";
                if (arrayperson[4] == "F")
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

                cuerpo += "<center style=' margin: 12px;'> " + firtsPay + " (" + currencyCode + ")</center>";
                cuerpo += "</div></center>";

                //cuerpo += "<center><img src='http://www.inresorts.club/Views/img/recibo.png' align='left' style='width: 100%'></center></div>";
                cuerpo += "<div style='margin-left: 9%;'>";
                cuerpo += "<p style='margin:5px'>Patrocinador: " + nameAfiliate + "</p>";
                cuerpo += "<p style='margin:5px'>Saludos Cordiales</p><p  style='margin:5px'>Equipo inResorts</p></div>";
                cuerpo += "<div style='margin: 5%; width: 70%;background-image: url('https://lh3.googleusercontent.com/NSDQDl8ytJrWSwMe0b3b9DlxubIal-RBEPIWI1a-15f9ynEGQ9eYjTnm-PVqst26f4KJThmjOEPK4lcVoaUw=w1016-h917-rw');'></ div > ";
                cuerpo += "<img style='width: 100%' src='https://preview.ibb.co/ixY7iL/fondo222.png'>";
                cuerpo += "</div>";

                cuerpo += "</body>";
                cuerpo += "</html>";

                Email email = new Email();
                anwser = email.SubmitEmail(correo, "[Ribera del Rio - Inresorts, Registro en Proceso] ", cuerpo);

                string correoOamr = "omarurteaga@gmail.com";

                email.SubmitEmail(correoOamr, "[Ribera del Rio - Inresorts, Registro en Proceso] ", cuerpo);

                if (correoAfiliate != "")
                {
                    email.SubmitEmail(correoAfiliate, "[Ribera del Rio - Inresorts, Registro en Proceso] ", cuerpo);
                }
            }

            if (rbQuote.Checked)
            {



                //SendEmailAmountRestante(username, "PEN", "", "", "", "", "");
            }

            MessageError.Text = string.Empty;
            MessageSucces.Text = string.Empty;
            if (!anwser)
            {
                MessageError.Text = "ocurred error.";
                return;
            }
            MessageSucces.Text = "correo enviado.";
        }

        protected void Confirmar_Click(object sender, EventArgs e)
        {
            var username = txtUserName.Text;

            if (string.IsNullOrEmpty(username))
            {
                return;
            }

            BrUser brUser = new BrUser();
            MyMessages mm = new MyMessages();

            var arrayperson = brUser.GetPersonalInformation(username).Split('|');
            if (arrayperson.Length < 5)
            {
                return;
            }
            var correo = arrayperson[5];
            var nombre = arrayperson[1] + " " + arrayperson[2];
            EmailUser.Text = correo;
            NameUser.Text = nombre;

        }



        #region Methods
        private bool SendEmailKit(string name, string gender, string userName, string ruta, string email)
        {
            string subjet = "", messagge = "";
            string[] sepName = name.Split(' ');
            var fName = ToCapitalize(sepName[0]);
            var bienvenido = "Bienvenido";
            if (gender == "F")
            {
                bienvenido = "Bienvenida";
            }
            subjet = "[RIBERA DEL RIO - BIENVENIDO]";
            messagge = "<html><head><title></title></head><body style='color:black'>";
            messagge += "<div style='width: 100%'>";
            messagge += "<div style='display:flex;'>";
            messagge += "<div style='width:50%;'>";
            messagge += " <img src='http://www.inresorts.club/Views/img/novologo.png' align='left' style='width: 98px;'>";
            messagge += "</div>";
            messagge += "<div style='width:50%;'>";
            messagge += "<img src='http://cieneguillariberadelrio.com/riberadelrio/img/image006.png' align='right' style='width: 120px;padding-top: 7px;'>";
            messagge += "</div>";
            messagge += "</div>";
            messagge += "<img style='width: 100%' src='http://www.inresorts.club/Views/img/fondo.png'>";
            messagge += "<h1 style='margin-top: 2px ;text-align: center;font-weight: bold;font-style: italic;'>" + bienvenido + " " + fName + "</h1>";
            messagge += "<h2 style='text-align: center;'>Socio de Ribera del Rio Club Resort</h2>";
            messagge += "<p style='margin-left: 10%;margin-right: 10%; '>En nombre de InResorts y Ribera del Rio es un placer darle la bienvenida, esperando que disfrute con nosotros las mejores experiencias. Ribera del Río Club Resort está abierto a su participación en nuestras diversas actividades, puede consultar en cualquier momento cualquier duda o enviarnos cualquier sugerencia.</p> ";
            messagge += "<p style='margin-left: 10%;margin-right: 10%; '>A continuación, le resumimos un poco la información sobre los beneficios con los que contará por formar parte de la familia de Ribera del Río Club Resort como Socio.</p> </div>";

            messagge += "<div style='width: 100%;text-align: center;display: flex; margin: 0 auto;'>";
            messagge += "<ul style='list-style: none;text-align: center; width: 88px;display: inline-block;padding: 0;margin: auto auto;'>";
            messagge += "<li> Club 365.</li><li> Noches Hoteleras.</li></ul>";
            messagge += "<ul style='list-style: none;text-align: center; width: 88px;display: inline-block;padding: 0;margin: auto auto;'>";
            messagge += "<li> Descuentos.</li><li> Viajes.</li></ul>";
            messagge += "<ul style='list-style: none;text-align: center; width: 88px;display: inline-block;padding: 0;margin: auto auto;'>";
            messagge += "<li> Valorización de Inversión.</li><li> Plan de Referencias.</li></ul></div>";

            messagge += "<div style='width: 100%'>";
            messagge += "<p style='margin-left: 10%;margin-right: 10%; '>Para Ribera del Río Club Resort, es de gran satisfacción contar con clientes tan importantes como usted y su familia que son participes del crecimiento de nuestra empresa, es por eso que, de quedar alguna interrogante al respecto, puede consultar nuestra pagina web www.cieneguillariberadelrio.com o comunicarse al telefono 938627411 o al correo de socios@cieneguillariberadelrio.com en donde estamos prestos a cualquier inquietud, aclaración o trámites para el uso de su Membresía.</p>";
            messagge += "<p style='margin-left: 10%;margin-right: 10%; '>Para realizar cualquier pago relacionado con el contrato adquirido de la Membresía de Ribera del Rio Club Resort, recuerde que esto lo puede hacer mediante su oficina virtual o a travez de nuestras cuentas de recaudo empresarial.Es de resaltar que sus pagos sólo deberá realizarlos a las cuentas que se indican en su contrato, de lo contrario, la compañia No responderá por pagos realizados a cuenta de terceros.</p>";

            messagge += "<center><div style='width: 100%'>";
            messagge += "<a style='text-decoration: none;' href='https://inresorts.club'>";
            messagge += "<center><div style='background: #0d80ea;border-radius:10px;width: 180px;height: 58px;font-size: 16px;color: white;font-weight: bold;padding: 5px;cursor: pointer;text-align: center;margin: 23px;'>Acceso a Oficina Virtual<div></center>";
            messagge += "</a></div></center>";

            messagge += "<div style='border: 2px solid gray;margin-left: 30%;margin-right: 30%;border-radius: 8px '>";
            messagge += "<center><p> Usuario: <b>" + userName.Substring(0, userName.Length - 1) + "</b></p><p> Password: <b>" + userName.Substring(0, userName.Length - 1) + "</b></p></center></div>";
            messagge += "<p style='margin-left: 10%;margin-right: 10%; '>";
            messagge += "Le adjuntamos toda la documentación y anexos, relacionados a su afilicación </p>";
            messagge += "<div style='margin-left: 10%;'>";
            messagge += "<p style=''>Saludos Cordiales</p><p  style=''>Equipo inResorts</p> <p  style=''></p></div>";
            messagge += "<div style='margin: 5%; width: 70%;background-image: url('https://lh3.googleusercontent.com/NSDQDl8ytJrWSwMe0b3b9DlxubIal-RBEPIWI1a-15f9ynEGQ9eYjTnm-PVqst26f4KJThmjOEPK4lcVoaUw=w1016-h917-rw');'></ div > ";
            messagge += "<img style='width: 100%' src='https://preview.ibb.co/ixY7iL/fondo222.png'>";
            messagge += "</div>";


            messagge += "</body>";
            messagge += "</html>";




            Email oemail = new Email();
            bool isSend = oemail.SubmitEmailNotFiles(email, subjet, messagge, true, ruta, userName);

            return isSend;
        }

        private bool SendEmailFounder(string name, string gender, string userName, string ruta, string emailUser)
        {

            string subjet = "", messagge = "";
            string[] sepName = name.Split(' ');
            var fName = ToCapitalize(sepName[0]);
            var bienvenido = "Bienvenido";
            if (gender == "F")
            {
                bienvenido = "Bienvenida";
            }
            subjet = "[RIBERA DEL RIO - BIENVENIDO]";
            messagge = "<html><head><title></title></head><body style='color:black'>";
            messagge += "<div style='width: 100%'>";
            messagge += "<div style='display:flex;'>";
            messagge += "<div style='width:50%;'>";
            messagge += " <img src='http://www.inresorts.club/Views/img/novologo.png' align='left' style='width: 98px;'>";
            messagge += "</div>";
            messagge += "<div style='width:50%;'>";
            messagge += "<img src='http://cieneguillariberadelrio.com/riberadelrio/img/image006.png' align='right' style='width: 120px;padding-top: 7px;'>";
            messagge += "</div>";
            messagge += "</div>";
            messagge += "<img style='width: 100%' src='http://www.inresorts.club/Views/img/fondo.png'>";
            messagge += "<h1 style='margin-top: 2px ;text-align: center;font-weight: bold;font-style: italic;'>" + bienvenido + " " + fName + "</h1>";
            messagge += "<h2 style='text-align: center;'>Socio de Ribera del Rio Club Resort</h2>";
            messagge += "<p style='margin-left: 10%;margin-right: 10%; '>En nombre de InResorts y Ribera del Rio es un placer darle la bienvenida como futuro socio fundador, esperando que disfrute con nosotros las mejores experiencias. Ribera del Río Club Resort está abierto a su participación en nuestras diversas actividades, puede consultar en cualquier momento cualquier duda o enviarnos cualquier sugerencia.</p> ";
            messagge += "<p style='margin-left: 10%;margin-right: 10%; '>A continuación, le resumimos un poco la información sobre los beneficios con los que contará por formar parte de la familia de Ribera del Río Club Resort como Socio.</p> </div>";

            messagge += "<div style='width: 100%;text-align: center;display: flex; margin: 0 auto;'>";
            messagge += "<ul style='list-style: none;text-align: center; width: 88px;display: inline-block;padding: 0;margin: auto auto;'>";
            messagge += "<li> Club 365.</li><li> Noches Hoteleras.</li></ul>";
            messagge += "<ul style='list-style: none;text-align: center; width: 88px;display: inline-block;padding: 0;margin: auto auto;'>";
            messagge += "<li> Descuentos.</li><li> Viajes.</li></ul>";
            messagge += "<ul style='list-style: none;text-align: center; width: 88px;display: inline-block;padding: 0;margin: auto auto;'>";
            messagge += "<li> Valorización de Inversión.</li><li> Plan de Referencias.</li></ul></div>";

            messagge += "<div style='width: 100%'>";
            messagge += "<p style='margin-left: 10%;margin-right: 10%; '>Para Ribera del Río Club Resort, es de gran satisfacción contar con clientes tan importantes como usted y su familia que son participes del crecimiento de nuestra empresa, es por eso que, de quedar alguna interrogante al respecto, puede consultar nuestra pagina web www.cieneguillariberadelrio.com o comunicarse al telefono 938627411 o al correo de socios@cieneguillariberadelrio.com en donde estamos prestos a cualquier inquietud, aclaración o trámites para el uso de su Membresía.</p>";
            messagge += "<p style='margin-left: 10%;margin-right: 10%; '>Para realizar cualquier pago relacionado con el contrato adquirido de la Membresía de Ribera del Rio Club Resort, recuerde que esto lo puede hacer mediante su oficina virtual o a travez de nuestras cuentas de recaudo empresarial.Es de resaltar que sus pagos sólo deberá realizarlos a las cuentas que se indican en su contrato, de lo contrario, la compañia No responderá por pagos realizados a cuenta de terceros.</p>";

            messagge += "<center><div style='width: 100%'>";
            messagge += "<a style='text-decoration: none;' href='https://inresorts.club'>";
            messagge += "<center><div style='background: #0d80ea;border-radius:10px;width: 180px;height: 58px;font-size: 16px;color: white;font-weight: bold;padding: 5px;cursor: pointer;text-align: center;margin: 23px;'>Acceso a Oficina Virtual<div></center>";
            messagge += "</a></div></center>";

            messagge += "<div style='border: 2px solid gray;margin-left: 30%;margin-right: 30%;border-radius: 8px '>";
            messagge += "<center><p> Usuario: <b>" + userName.Substring(0, userName.Length - 1) + "</b></p><p> Password: <b>" + userName.Substring(0, userName.Length - 1) + "</b></p></center></div>";
            messagge += "<p style='margin-left: 10%;margin-right: 10%; '>";
            messagge += "Le adjuntamos toda la documentación y anexos, relacionados a su afilicación </p>";
            messagge += "<div style='margin-left: 10%;'>";
            messagge += "<p style=''>Saludos Cordiales</p><p  style=''>Equipo inResorts</p> <p  style=''></p></div>";
            messagge += "<div style='margin: 5%; width: 70%;background-image: url('https://lh3.googleusercontent.com/NSDQDl8ytJrWSwMe0b3b9DlxubIal-RBEPIWI1a-15f9ynEGQ9eYjTnm-PVqst26f4KJThmjOEPK4lcVoaUw=w1016-h917-rw');'></ div > ";
            messagge += "<img style='width: 100%' src='https://preview.ibb.co/ixY7iL/fondo222.png'>";
            messagge += "</div>";


            messagge += "</body>";
            messagge += "</html>";



            Email oemail = new Email();

            bool isSend = oemail.SendEmailFounder(emailUser, subjet, messagge, true, ruta, userName);

            oemail = null;
            oemail = new Email();
            string correoOamr = "omarurteaga@gmail.com";

            var isSend2 = oemail.SendEmailFounder(correoOamr, subjet, messagge, true, ruta, userName);
            return isSend;
        }

        private bool SendEmailVacational(string name, string gender, string userName, string ruta, string emailUser)
        {
            string subjet = "", messagge = "";
            string[] sepName = name.Split(' ');
            var fName = ToCapitalize(sepName[0]);
            var bienvenido = "Bienvenido";
            if (gender == "F")
            {
                bienvenido = "Bienvenida";
            }
            subjet = "[RIBERA DEL RIO - BIENVENIDO]";
            messagge = "<html><head><title></title></head><body style='color:black'>";
            messagge += "<div style='width: 100%'>";
            messagge += "<div style='display:flex;'>";
            messagge += "<div style='width:50%;'>";
            messagge += " <img src='http://www.inresorts.club/Views/img/novologo.png' align='left' style='width: 98px;'>";
            messagge += "</div>";
            messagge += "<div style='width:50%;'>";
            messagge += "<img src='http://cieneguillariberadelrio.com/riberadelrio/img/image006.png' align='right' style='width: 120px;padding-top: 7px;'>";
            messagge += "</div>";
            messagge += "</div>";
            messagge += "<img style='width: 100%' src='http://www.inresorts.club/Views/img/fondo.png'>";
            messagge += "<h1 style='margin-top: 2px ;text-align: center;font-weight: bold;font-style: italic;'>" + bienvenido + " " + fName + "</h1>";
            messagge += "<h2 style='text-align: center;'>Socio de Ribera del Rio Club Resort</h2>";
            messagge += "<p style='margin-left: 10%;margin-right: 10%; '>En nombre de InResorts y Ribera del Rio es un placer darle la bienvenida como socio, esperando que disfrute con nosotros las mejores experiencias. Ribera del Río Club Resort está abierto a su participación en nuestras diversas actividades, puede consultar en cualquier momento cualquier duda o enviarnos cualquier sugerencia.</p> ";
            messagge += "<p style='margin-left: 10%;margin-right: 10%; '>A continuación, le resumimos un poco la información sobre los beneficios con los que contará por formar parte de la familia de Ribera del Río Club Resort como Socio.</p> </div>";

            messagge += "<div style='width: 100%;text-align: center;display: flex; margin: 0 auto;'>";
            messagge += "<ul style='list-style: none;text-align: center; width: 88px;display: inline-block;padding: 0;margin: auto auto;'>";
            messagge += "<li> Club 365.</li><li> Noches Hoteleras.</li></ul>";
            messagge += "<ul style='list-style: none;text-align: center; width: 88px;display: inline-block;padding: 0;margin: auto auto;'>";
            messagge += "<li> Descuentos.</li><li> Viajes.</li></ul>";
            messagge += "<ul style='list-style: none;text-align: center; width: 88px;display: inline-block;padding: 0;margin: auto auto;'>";
            messagge += "<li> Valorización de Inversión.</li><li> Plan de Referencias.</li></ul></div>";

            messagge += "<div style='width: 100%'>";
            messagge += "<p style='margin-left: 10%;margin-right: 10%; '>Para Ribera del Río Club Resort, es de gran satisfacción contar con clientes tan importantes como usted y su familia que son participes del crecimiento de nuestra empresa, es por eso que, de quedar alguna interrogante al respecto, puede consultar nuestra pagina web www.cieneguillariberadelrio.com o comunicarse al telefono 938627411 o al correo de socios@cieneguillariberadelrio.com en donde estamos prestos a cualquier inquietud, aclaración o trámites para el uso de su Membresía.</p>";
            messagge += "<p style='margin-left: 10%;margin-right: 10%; '>Para realizar cualquier pago relacionado con el contrato adquirido de la Membresía de Ribera del Rio Club Resort, recuerde que esto lo puede hacer mediante su oficina virtual o a travez de nuestras cuentas de recaudo empresarial.Es de resaltar que sus pagos sólo deberá realizarlos a las cuentas que se indican en su contrato, de lo contrario, la compañia No responderá por pagos realizados a cuenta de terceros.</p>";

            messagge += "<center><div style='width: 100%'>";
            messagge += "<a style='text-decoration: none;' href='https://inresorts.club'>";
            messagge += "<center><div style='background: #0d80ea;border-radius:10px;width: 180px;height: 58px;font-size: 16px;color: white;font-weight: bold;padding: 5px;cursor: pointer;text-align: center;margin: 23px;'>Acceso a Oficina Virtual<div></center>";
            messagge += "</a></div></center>";

            messagge += "<div style='border: 2px solid gray;margin-left: 30%;margin-right: 30%;border-radius: 8px '>";
            messagge += "<center><p> Usuario: <b>" + userName.Substring(0, userName.Length - 1) + "</b></p><p> Password: <b>" + userName.Substring(0, userName.Length - 1) + "</b></p></center></div>";
            messagge += "<p style='margin-left: 10%;margin-right: 10%; '>";
            messagge += "Le adjuntamos toda la documentación y anexos, relacionados a su afilicación </p>";
            messagge += "<div style='margin-left: 10%;'>";
            messagge += "<p style=''>Saludos Cordiales</p><p  style=''>Equipo inResorts</p> <p  style=''></p></div>";
            messagge += "<div style='margin: 5%; width: 70%;background-image: url('https://lh3.googleusercontent.com/NSDQDl8ytJrWSwMe0b3b9DlxubIal-RBEPIWI1a-15f9ynEGQ9eYjTnm-PVqst26f4KJThmjOEPK4lcVoaUw=w1016-h917-rw');'></ div > ";
            messagge += "<img style='width: 100%' src='https://preview.ibb.co/ixY7iL/fondo222.png'>";
            messagge += "</div>";


            messagge += "</body>";
            messagge += "</html>";






            Email oemail = new Email();
            bool isSend = oemail.SubmitEmail(emailUser, subjet, messagge, true, ruta, userName);
            string correoOamr = "omarurteaga@gmail.com";

            oemail = null;
            oemail = new Email();
            var isSend2 = oemail.SubmitEmail(correoOamr, subjet, messagge, true, ruta, userName);
            return isSend;
        }

        private bool SendEmailClub(string name, string gender, string userName, string ruta, string emailUser)
        {
            string subjet = "", messagge = "";
            //string fullname = arrayperson[0].Trim().ToLower() + " " + arrayperson[1].Trim().ToLower();
            //fullname = ToCapitalize(fullname);
            string[] sepName = name.Split(' ');
            var fName = ToCapitalize(sepName[0]);
            var bienvenido = "Bienvenido";
            if (gender == "F")
            {
                bienvenido = "Bienvenida";
            }

            subjet = "[RIBERA DEL RIO - BIENVENIDO]";
            // messagge = "buenas tardes";
            messagge = "<html><head><title></title></head><body style='color:black'>";

            messagge += "<div style='width: 100%'>";
            messagge += "<div style='display:flex;'>";
            messagge += "<div style='width:50%;'>";
            messagge += " <img src='http://www.inresorts.club/Views/img/novologo.png' align='left' style='width: 98px;'>";
            messagge += "</div>";
            messagge += "<div style='width:50%;'>";
            messagge += "<img src='http://cieneguillariberadelrio.com/riberadelrio/img/image006.png' align='right' style='width: 120px;padding-top: 7px;'>";
            messagge += "</div>";
            messagge += "</div>";

            messagge += "<img style='width: 100%' src='http://www.inresorts.club/Views/img/fondo.png'>";
            messagge += "<h1 style='margin-top: 2px ;text-align: center;font-weight: bold;font-style: italic;'>" + bienvenido + " " + fName + "</h1>";
            messagge += "<h2 style='text-align: center;'></h2>";
            messagge += "<p style='margin-left: 10%;margin-right: 10%; '>En nombre de InResorts y Ribera del Rio es un placer darle la bienvenida, esperando que disfrute con nosotros las mejores experiencias. Ribera del Río Club Resort está abierto a su participación en nuestras diversas actividades, puede consultar en cualquier momento cualquier duda o enviarnos cualquier sugerencia.</p> ";
            messagge += "<p style='margin-left: 10%;margin-right: 10%; '>A continuación, le resumimos un poco la información sobre los beneficios con los que contará por formar parte de la familia de Ribera del Río Club Resort como Socio.</p> </div>";

            messagge += "<div style='width: 100%;text-align: center;display: flex; margin: 0 auto;'>";
            messagge += "<ul style='list-style: none;text-align: center; width: 88px;display: inline-block;padding: 0;margin: auto auto;'>";
            messagge += "<li> Club 365.</li><li> Noches Hoteleras.</li></ul>";
            messagge += "<ul style='list-style: none;text-align: center; width: 88px;display: inline-block;padding: 0;margin: auto auto;'>";
            messagge += "<li> Descuentos.</li><li> Viajes.</li></ul>";
            messagge += "<ul style='list-style: none;text-align: center; width: 88px;display: inline-block;padding: 0;margin: auto auto;'>";
            messagge += "<li> Valorización de Inversión.</li><li> Plan de Referencias.</li></ul></div>";

            messagge += "<div style='width: 100%'>";
            messagge += "<p style='margin-left: 10%;margin-right: 10%; '>Para Ribera del Río Club Resort, es de gran satisfacción contar con clientes tan importantes como usted y su familia que son participes del crecimiento de nuestra empresa, es por eso que, de quedar alguna interrogante al respecto, puede consultar nuestra pagina web www.cieneguillariberadelrio.com o comunicarse al telefono 938627411 o al correo de socios@cieneguillariberadelrio.com en donde estamos prestos a cualquier inquietud, aclaración o trámites para el uso de su Membresía.</p>";
            messagge += "<p style='margin-left: 10%;margin-right: 10%; '>Para realizar cualquier pago relacionado con el contrato adquirido de la Membresía de Ribera del Rio Club Resort, recuerde que esto lo puede hacer mediante su oficina virtual o a través de nuestras cuentas de recaudo empresarial. Es de resaltar que sus pagos sólo deberá realizarlos a las cuentas que se indican en su contrato, de lo contrario, la compañía No responderá por pagos realizados a cuenta de terceros.</p>";

            messagge += "<center><div style='width: 100%'>";
            messagge += "<a style='text-decoration: none;' href='https://inresorts.club'>";
            messagge += "<center><div style='background: #0d80ea;border-radius:10px;width: 180px;height: 58px;font-size: 16px;color: white;font-weight: bold;padding: 5px;cursor: pointer;text-align: center;margin: 23px;'>Acceso a Oficina Virtual<div></center>";
            messagge += "</a></div></center>";

            messagge += "<div style='border: 2px solid gray;margin-left: 30%;margin-right: 30%;border-radius: 8px '>";
            messagge += "<center><p> Usuario: <b>" + userName.Substring(0, userName.Length - 1) + "</b></p><p> Password: <b>" + userName.Substring(0, userName.Length - 1) + "</b></p></center></div>";
            messagge += "<p style='margin-left: 10%;margin-right: 10%; '>";
            messagge += "Le adjuntamos toda la documentación y anexos, relacionados a su afiliación </p>";
            messagge += "<div style='margin-left: 10%;'>";
            messagge += "<p style=''>Saludos Cordiales</p><p  style=''>Equipo inResorts</p> <p  style=''></p></div>";

            messagge += "<img style='width: 100%' src='http://www.inresorts.club/Views/img/fondo222.png'>";
            messagge += "</div>";


            messagge += "</body>";
            messagge += "</html>";

            Email oemail = new Email();
            bool isSend = false;
            try
            {
                isSend = oemail.SubmitEmail(emailUser, subjet, messagge, false, ruta, userName);
            }
            catch (Exception ex)
            {
                BrTesteo brTesteo = new BrTesteo();
                brTesteo.Put(ex.Message);
            }

            string correoOamr = "omarurteaga@gmail.com";

            //if (!isSend)
            //{
            //    bool isSend2 = oemail.submitEmailNotFiles2(emailUser, subjet, messagge, true, ruta, userName);
            //    if (!isSend2)
            //    {
            //        Response.Write("false¬Ha Ocurrido un Error al enviar el Correo de verificacion o de rechazo");
            //        return;
            //    }
            //}
            var isSend2 = oemail.SubmitEmail(correoOamr, subjet, messagge, true, ruta, userName);
            return isSend;
        }

        private string ToCapitalize(string _text)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;

            return textInfo.ToTitleCase(_text);
        }
        #endregion

        #region MyRegion
        private void SendEmailAmountRestante(string userName, string currencyCode, string amountRestn, string amountWalllet, string amountTotal, string idMembershipDetail, string description)
        {

            MyConstants mc = new MyConstants();
            MyFunctions mf = new MyFunctions();
            var bankAccount = mc.BankAccount;

            //1|Omar Fernando|Urteaga Cabrera|14/01/1983|M|omarurteaga@gmail.com|938627011||Peru|Lima|Lima|addres|DNI|41958311|1|admin987|Solter(a)
            BrUser brPerson = new BrUser();
            var arrayperson = brPerson.GetPersonalInformation(userName).Split('|');

            var correo = arrayperson[5];
            var nombre = arrayperson[1] + " " + arrayperson[2];
            var dni = arrayperson[13];
            var username = arrayperson[1].Substring(0, 1).ToUpper() + arrayperson[2].Substring(0, 1).ToUpper() + dni;
            string fullname = arrayperson[1].Trim().ToLower() + " " + arrayperson[2].Trim().ToLower();
            fullname = mf.ToCapitalize(fullname);
            string[] sepName = arrayperson[1].Split(' ');
            var fName = mf.ToCapitalize(sepName[0]);

            var bienvenido = "Estimado";
            if (arrayperson[4] == "F")
            {
                bienvenido = "Estimada";
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
            cuerpo += "<h2 style='text-align: center;'>Aqui te detallamos el pago de tu Cuota. Estamos a la espera de que nos brindes tu comprobante de pago</h2>";
            cuerpo += "<center><p style='margin-left: 10%;margin-right: 10%;'>Detalle de Pago</p></center> ";
            cuerpo += "<center><p style='margin-left: 10%;margin-right: 10%;'>Monto Wallet : S/ " + amountWalllet + "</p></center> ";
            cuerpo += "<center><p style='margin-left: 10%;margin-right: 10%;'>Monto Deposito : S/ " + amountRestn + "</p></center> ";
            cuerpo += "<center><p style='margin-left: 10%;margin-right: 10%;'>========================================</p></center> ";
            cuerpo += "<center><p style='margin-left: 10%;margin-right: 10%;'>Monto Total : S/ " + amountTotal + "</p></center> ";
            cuerpo += "<center><p style='margin-left: 10%;margin-right: 10%;'>Cuando lo tengas listo, solo tienes que subirlo a nuestra pagina y enseguida lo estaremos validando</p></center> ";
            cuerpo += "";
            cuerpo += "<center><div style='width: 100%'>";
            cuerpo += "<p style='margin-left: 10%;margin-right: 10%; '> Click en el boton para validar el pago.</p>";
            cuerpo += "<a style='text-decoration: none;' href='https://inresorts.club/Views/Login.aspx?usuario=" + dni + "&fullname=" + fullname + "&cod=" + idMembershipDetail + "&description=" + description + "'>";
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

            cuerpo += "<center style=' margin: 12px;'> S/." + amountRestn + " (" + currencyCode + ")</center>";
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
            //string correoOamr = "samirpazo08@gmail.com";

            email.SubmitEmail(correoOamr, "[Ribera del Rio - Inresorts, Registro en Proceso] ", cuerpo);
            Session.Contents.RemoveAll();
        }
        #endregion
    }
}