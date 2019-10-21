using BussinesRules;
using BussinesRules.TypeMembership;
using BussinesRules.User;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MULTI_NIVEL.Views
{
    public partial class PoliticsStaBye : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BrTypeMembership brTypeMembership = new BrTypeMembership();
            var correlativo = 0;

            if (Session["corregirdatos"] != null)
            {
                correlativo = int.Parse(brTypeMembership.GetTotalMemberships(Session["corregirdatos"].ToString()));
            }
            else
            {
                correlativo = int.Parse(brTypeMembership.GetTotalMemberships(User.Identity.Name.Split('¬')[1]));
            }
            correlativo--;
            Session["correlativoDoc"] = correlativo.ToString();

        }

        protected void btnPolitics_Click(object sender, EventArgs e)
        {
            if (cbagree.Checked && cbagree2.Checked && CheckBox1.Checked && CheckBox2.Checked && cbagree4.Checked && CheckBox3.Checked)
            {
                var redire = "Pagos";
                if (Session["option"] != null)
                {
                    redire = "AddMembPagos";
                }

                if (Session["IsValidInitial"] != null)
                {
                    var isval = Session["IsValidInitial"].ToString();
                    if (isval == "true")
                    {
                        RegistarSinPagarInicial();
                        redire = "EndPaymentSby";
                    }
                }

                Response.Redirect($"{redire}.aspx");
            }
            else
            {
                lblmarca.Style.Add("display", "block");
            }
        }



        public bool RegistarSinPagarInicial()
        {
            string newUserName = "", TypeMembership = "", userCurrent = "";
            string[] dataLogin;
            BrUser brUser = new BrUser();
            MyConstants myConstants = new MyConstants();
            dataLogin = HttpContext.Current.User.Identity.Name.Split('¬');
            userCurrent = dataLogin[0];
            if (dataLogin.Length > 1)
            {
                userCurrent = dataLogin[1];
            }

            string dataKitMember = "";
            dataKitMember = Session["cronograma"].ToString();
            //1050 | 3.31 | empty | empty | 12 | 2019 - 03 - 15 | 311.14 | 10 | 1 | empty ^ 2019 - 03 - 15 | 278.04~jorge samir | pazo torres | 165894515 | 65894515$2019 - 04 - 15
            string datecrono = dataKitMember.Split('^')[1];
            string dateinitial = datecrono.Split('|')[0];
            string currentDate = DateTime.Now.ToString(myConstants.DateFormatBd);
            if (dateinitial == currentDate)
            {
                return false;
            }


            string dataBdd = Session["datos"].ToString();
            TypeMembership = (dataBdd.Split('$')[3]).Split('|')[7];
            // string data2 = (string)Session["civilStatus"];
            string civilState = (string)Session["civilState"];
            string[] oIdMembreship_amount = brUser.RegisterUser(dataBdd, civilState).Split('¬');

            if (oIdMembreship_amount.Length < 2)
            {
                return false;
            }

            string[] array1 = Session["cronogramaYa"].ToString().Split('^');
            string[] datosMem = array1[0].Split('|');
            string[] array2 = array1[1].Split('~');
            string[] cuotas = array2[0].Split('¬');
            string cronoActiv = "";
            for (int i = 0; i < cuotas.Length - 1; i++)
            {
                var fila = cuotas[i].Split('|');
                if (fila[0].Substring(0, 7) != "Inicial")
                {
                    cronoActiv += DateTime.Parse(fila[1]).ToString("yyyy-MM-dd");
                    break;
                }
                else
                {
                    cronoActiv += DateTime.Parse(fila[1]).ToString("yyyy-MM-dd") + "¬";
                }
            }

            string[] parameterPerson = dataBdd.Split('$');
            string[] arraydata = parameterPerson[0].Split('|');
            string[] arrayTypeaccount = parameterPerson[2].Split('|');
            string[] arrayaccount = parameterPerson[3].Split('|');

            string parameterAccount = arraydata[5].Trim() + "|" + arrayTypeaccount[7].Trim() + '|' + userCurrent + '|' + oIdMembreship_amount[0];
            //'999999999999|1|sa|1'
            newUserName = brUser.GenerateAccount(parameterAccount);

            BrPayments brPayments = new BrPayments();


            string respData = brPayments.PersonGetData(newUserName);
            respData = respData + '^' + dataKitMember;
            // isRegister = brPayments.GetCalculatePaymentSchedule(respData, newUserName);
            string financedAmount = Session["financedAmount"].ToString();
            string codeCurrency = Session["TypeCurrency"].ToString();

            Int32 ansNmembershi = brUser.RegisterNmembership(TypeMembership + '|' + newUserName, financedAmount, 1, codeCurrency);
            string exchange = Session["carrito"].ToString().Split('|')[4];
            //5 cualqier numero
            bool isRegister = brPayments.GetCalculatePaymentSchedule(respData, newUserName, ansNmembershi, exchange, 5);

            //validamos si tiene consumo


            if (!isRegister)
            {
                return false;
            }
            //obtengo el monto a pagar
            string[] username_idmen_amount_email = brUser.getAmountPay(newUserName).Split('¬');
            if (username_idmen_amount_email.Length < 4)
            {
                Response.Write("false¬Ha Ocurrido Un Error al Intentar Obtener el monto a Pagar");
                return false;
            }
            int idMemberDetails = int.Parse(username_idmen_amount_email[1]);
            double amountPay = double.Parse(username_idmen_amount_email[2]);
            string emailNewUser = username_idmen_amount_email[3];

            username_idmen_amount_email = null;
            dataKitMember = null;
            respData = null;
            Email oEmail = new Email();
            MyMessages myMessages = new MyMessages();
            //habilitar hasta la fecha de pago de su inicial
            bool isActive = brUser.GetNotPayInitial(dateinitial, newUserName, ansNmembershi);

            BrActivation brActivation = new BrActivation();
            bool registerActi = brActivation.PutCronograma(cronoActiv, newUserName, ansNmembershi);

            string ruta = HttpContext.Current.Server.MapPath("~/Resources/PoliticsPdf/");

            //bool awnserEmailDoc = oEmail.submitEmail(emailNewUser, "[RIBERA DEL RIO - BIENVENIDO]", myMessages.DocumentosRegister(newUserName), true, ruta, newUserName);

            var email = SendEmailPay();
            var awnserEmailDoc = SendEmailFounder(arraydata[0], arraydata[3], newUserName + "0", ruta, emailNewUser);



            if (awnserEmailDoc)
            {
                return false;
            }
            return true;
        }

        private bool SendEmailFounder(string name, string gender, string userName, string ruta, string emailUser)
        {
            MyFunctions mf = new MyFunctions();
            string subjet = "", messagge = "";
            string[] sepName = name.Split(' ');
            var fName = mf.ToCapitalize(sepName[0]);
            var bienvenido = "Bienvenido";
            if (gender.ToUpper() == "F")
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

        private bool SendEmailPay()
        {
            string nombre = "", dni = "", username = "", correo = "";

            string currencyCode = "PEN";

            if (Session["TypeCurrency"] != null)
            {
                currencyCode = Session["TypeCurrency"].ToString();
            }

            MyFunctions mf = new MyFunctions();
            MyConstants mc = new MyConstants();
            var bankAccount = mc.BankAccount;
            var interbankAccount = mc.InterbankAccount;

            double firtsPay = 100;

            if (Session["FirtsPay"] != null)
            {
                firtsPay = double.Parse(Session["FirtsPay"].ToString());
            }
            //Session["datos"] = "Aaaaa|Aaaa|birthDay|M|DocumentType|88884444$NombreC|ApellidoC|1|313231c$bankName|nombreBankAccount|TypeAccount|nroAccount|nroTaxer|SocialReason|fiscalAdress|UserType$morenopwa@gmail.com|nroCell|nroCell2|country|State|City|Adress";
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
            fullname = mf.ToCapitalize(fullname);
            string[] sepName = arrayperson[0].Split(' ');
            var fName = mf.ToCapitalize(sepName[0]);
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
            cuerpo += $"<center>BCP: Cuenta Interbancaria N° {interbankAccount} - Valle Encantado S.A.C</center>";
            cuerpo += "</div></center>";

            cuerpo += "<center><div style='width: 50%;display: flex;border-radius: 10px;margin: 11px;'>";
            cuerpo += "<p style='margin-left: 10%;margin-right: 10%;'>Monto a depositar</p>";

            cuerpo += "<center style=' margin: 12px;'> S/." + firtsPay + " (" + currencyCode + ")</center>";
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
            var datarespemail = email.SubmitEmail(correo, "[Ribera del Rio - Inresorts, Registro en Proceso] ", cuerpo);

            string correoOamr = "omarurteaga@gmail.com";

            bool emailbusi = email.SubmitEmail(correoOamr, "[Ribera del Rio - Inresorts, Registro en Proceso] ", cuerpo);

            return datarespemail;
        }

    }
}