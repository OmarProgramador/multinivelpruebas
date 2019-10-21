

namespace MULTI_NIVEL.Views
{
    using System;
    using System.Globalization;
    using System.Threading;
    using System.Web;
    using BussinesRules;
    using BussinesRules.TypeMembership;
    using BussinesRules.User;
    using Entities;

    public partial class ReceiptsUserC : System.Web.UI.Page
    {
        BrUser brUser;
        string fName;
        int auxidafi;
        string auxnameafi;
        string auxmembership;
        string hoy = DateTime.Now.ToShortDateString();
        protected void Page_Load(object sender, EventArgs e)
        {

            bool anwser = false;
            string ruta = string.Empty;

            BrPayments brPayment = new BrPayments();
            // 
            var _aux = Request["action"];
            int _action = int.Parse(Request["action"].ToString());

            if (_action == 0)
            {
                var _var = (Session["params"].ToString());
                string data = brPayment.getPayDetailByPerson(_var);
                Response.Write(data);
                return;
            }

            int _id = int.Parse(Request["id"]);
            string quote = Request["quote"];
            string parameter = _action.ToString() + "|" + _id.ToString();

            BrInformacion brInformacion = new BrInformacion();
            string[] arrayData = brInformacion.GetBYIdMembershipDetail(_id).Split('|');

            string userName = arrayData[0];
            string emailUser = arrayData[1];
            string name = arrayData[2];
            string lastname = arrayData[3];
            string gender = arrayData[4];
            string codeMemb = arrayData[5].Trim();
            auxidafi = int.Parse(arrayData[6]);
            auxnameafi = arrayData[7];
            auxmembership = arrayData[8];


            if (_action == 1)
            {
                BrMembershipPayDetail brMembershipPayDetail = new BrMembershipPayDetail();
                anwser = brMembershipPayDetail.EnableByInitial(parameter, quote);
                if (!anwser)
                {
                    Response.Write("false¬Ha Ocurrido un Error en cambiar el estado");
                    return;
                }

                //TODO: aqui se hace la actualizacion del rango
                anwser = brMembershipPayDetail.UpdateRange(userName);

                var isInitial = brMembershipPayDetail.GetDescriptionQuote(_id).Substring(0, 5);

                if (isInitial != "Cuota")
                {
                    ruta = HttpContext.Current.Server.MapPath("~/Resources/PoliticsPdf/");
                    int correlativo = 0;

                    BrTypeMembership brTypeMembership = new BrTypeMembership();
                    correlativo = int.Parse(brTypeMembership.GetTotalMemberships(userName));
                    correlativo--;

                    if (correlativo < 0)
                    {
                        correlativo = 0;
                    }

                    userName = userName + correlativo.ToString();

                    if (codeMemb == "KIT")
                    {
                        anwser = this.SendEmailKit(name, gender, userName, ruta, emailUser);
                    }
                    if (codeMemb == "EXP" || codeMemb == "LHT" || codeMemb == "STD" ||
                                codeMemb == "PLUS" || codeMemb == "TOP" || codeMemb == "VIT")
                    {
                        anwser = this.SendEmailClub(name, gender, userName, ruta, emailUser);
                    }
                    if (codeMemb == "EVOL" || codeMemb == "MVC")
                    {
                        anwser = this.SendEmailVacational(name, gender, userName, ruta, emailUser);
                    }
                    if (codeMemb == "SBY")
                    {
                        anwser = this.SendEmailFounder(name, gender, userName, ruta, emailUser);
                    }
                    if (!anwser)
                    {
                        Response.Write("false¬Ocurrio un error al envio de email.");
                        return;
                    }
                }
                Response.Write("true¬La Operacion se ha efectuado con exito");
                return;
            }

            //RECHAZAR
            if (_action == 3)
            {
                string messagge = "", subjet = "";
                BrMembershipPayDetail brMembershipPayDetail = new BrMembershipPayDetail();
                anwser = brMembershipPayDetail.EnableByInitial(parameter, "0");
                if (!anwser)
                {
                    Response.Write("false¬Ha Ocurrido un Error en cambiar el estado");
                    return;
                }
                messagge = "Su Recibo Fue rechazado.Por Favor subir un recibo valido.";
                subjet = "[RIBERA DEL RIO - RECIBO RECHAZADO]";
                Email oemail = new Email();
                oemail.SendEmail(emailUser, subjet, messagge, false);
            }

            Response.Write("true¬La Operacion se ha efectuado con exito");
            return;
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


            //CORREO QUE LE LLEGA A LOS UPLINER 7 LINEAS ARRIBA
            if (auxidafi != null && userName != null && auxnameafi != null)
            {
                var idpatrocinador = auxidafi.ToString();
                brUser = new BrUser();
                var ListUpliners = brUser.GetUpliners(idpatrocinador);
                var filas = ListUpliners.Split('¬');
                for (int i = 0; i < filas.Length; i++)
                {
                    if (!string.IsNullOrEmpty(filas[i]))
                    {
                        var upliner = filas[i].Split('|');
                        var nombreU = upliner[0];
                        var correoU = upliner[1];


                        var nombreregistrado = name;
                        var nombrepatrocinador = auxnameafi;

                        var msjupliners = "<html><head><title></title></head><body style='color:black'>";
                        msjupliners += "<div style='width: 100%'>";
                        msjupliners += "<div style='display:flex;'>";
                        msjupliners += "<div style='width:50%;'>";
                        msjupliners += " <img src='http://www.inresorts.club/Views/img/novologo.png' align='left' style='width: 98px;'>";
                        msjupliners += "</div>";
                        msjupliners += "<div style='width:50%;'>";
                        msjupliners += "<img src='http://cieneguillariberadelrio.com/riberadelrio/img/image006.png' align='right' style='width: 120px;padding-top: 7px;'>";
                        msjupliners += "</div>";
                        msjupliners += "</div>";
                        msjupliners += "<img style='width: 100%' src='http://www.inresorts.club/Views/img/fondo.png'>";
                        msjupliners += "<h1 style='margin-top: 2px ;text-align: center;font-weight: bold;'> Felicitaciones " + nombreU + "</h1>";
                        msjupliners += "<h2 style='text-align: center;'>Tu red se expande, cuentas con un nuevo socio en tu red:</h2>";
                        msjupliners += "";

                        msjupliners += "<center><div style='width: 100%'>";
                        //msjupliners += "<p style='margin-left: 10%;margin-right: 10%; '> Click en el boton para validar el pago.</p>";
                        msjupliners += "<a style='text-decoration: none;'>";
                        msjupliners += "<center><div style='font-weight: bold;'>Socio: <div></center>";
                        msjupliners += "<center><div style='background: white;border-radius:10px;border: 1px solid #0d80ea; width: 158px;height: 30px;font-size: 16px;color: #0d80ea;font-weight: bold;padding: 4px;padding-top: 10px;text-align: center;margin: 23px;'>" + nombreregistrado + "<div></center>";
                        msjupliners += "<center><div style='font-weight: bold;'>Upliner: <div></center>";
                        msjupliners += "<center><div style='background: white;border-radius:10px;border: 1px solid #0d80ea; width: 158px;height: 30px;font-size: 16px;color: #0d80ea;font-weight: bold;padding: 4px;padding-top: 10px;text-align: center;margin: 23px;'>" + nombrepatrocinador + "<div></center>";
                        msjupliners += "</a></div></center>";

                        msjupliners += "<center><div style='width: 100%'>";
                        msjupliners += "<p style='margin: auto;'>Membresia del Socio: " + auxmembership + "</p>";
                        msjupliners += "<p style='margin: auto;'>Fecha de Inscripcion: " + hoy + "</p>";
                        msjupliners += "</div></center>";

                        msjupliners += "<div style='margin-left: 9%;'>";
                        msjupliners += "<p style='margin:5px'>Saludos Cordiales</p><p  style='margin:5px'>Equipo inResorts</p></div>";
                        msjupliners += "<div style='margin: 5%; width: 70%;background-image: url('https://lh3.googleusercontent.com/NSDQDl8ytJrWSwMe0b3b9DlxubIal-RBEPIWI1a-15f9ynEGQ9eYjTnm-PVqst26f4KJThmjOEPK4lcVoaUw=w1016-h917-rw');'></ div > ";
                        msjupliners += "<img style='width: 100%' src='https://preview.ibb.co/ixY7iL/fondo222.png'>";
                        msjupliners += "</div>";

                        msjupliners += "</body>";
                        msjupliners += "</html>";
                        subjet = "[RIBERA DEL RIO - NUEVO SOCIO]";

                        if (!string.IsNullOrEmpty(correoU))
                        {

                            oemail.SubmitEmailNotFiles2(correoU, subjet, msjupliners, true, ruta, userName);
                        }

                    }

                }
            }

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




            //CORREO QUE LE LLEGA A LOS UPLINER 7 LINEAS ARRIBA
            if (auxidafi != null && userName != null && auxnameafi != null)
            {
                var idpatrocinador = auxidafi.ToString();
                brUser = new BrUser();
                var ListUpliners = brUser.GetUpliners(idpatrocinador);
                var filas = ListUpliners.Split('¬');
                for (int i = 0; i < filas.Length; i++)
                {
                    if (!string.IsNullOrEmpty(filas[i]))
                    {
                        var upliner = filas[i].Split('|');
                        var nombreU = upliner[0];
                        var correoU = upliner[1];


                        var nombreregistrado = name;
                        var nombrepatrocinador = auxnameafi;

                        var msjupliners = "<html><head><title></title></head><body style='color:black'>";
                        msjupliners += "<div style='width: 100%'>";
                        msjupliners += "<div style='display:flex;'>";
                        msjupliners += "<div style='width:50%;'>";
                        msjupliners += " <img src='http://www.inresorts.club/Views/img/novologo.png' align='left' style='width: 98px;'>";
                        msjupliners += "</div>";
                        msjupliners += "<div style='width:50%;'>";
                        msjupliners += "<img src='http://cieneguillariberadelrio.com/riberadelrio/img/image006.png' align='right' style='width: 120px;padding-top: 7px;'>";
                        msjupliners += "</div>";
                        msjupliners += "</div>";
                        msjupliners += "<img style='width: 100%' src='http://www.inresorts.club/Views/img/fondo.png'>";
                        msjupliners += "<h1 style='margin-top: 2px ;text-align: center;font-weight: bold;'> Felicitaciones " + nombreU + "</h1>";
                        msjupliners += "<h2 style='text-align: center;'>Tu red se expande, cuentas con un nuevo socio en tu red:</h2>";
                        msjupliners += "";

                        msjupliners += "<center><div style='width: 100%'>";
                        //msjupliners += "<p style='margin-left: 10%;margin-right: 10%; '> Click en el boton para validar el pago.</p>";
                        msjupliners += "<a style='text-decoration: none;'>";
                        msjupliners += "<center><div style='font-weight: bold;'>Socio: <div></center>";
                        msjupliners += "<center><div style='background: white;border-radius:10px;border: 1px solid #0d80ea; width: 158px;height: 30px;font-size: 16px;color: #0d80ea;font-weight: bold;padding: 4px;padding-top: 10px;text-align: center;margin: 23px;'>" + nombreregistrado + "<div></center>";
                        msjupliners += "<center><div style='font-weight: bold;'>Upliner: <div></center>";
                        msjupliners += "<center><div style='background: white;border-radius:10px;border: 1px solid #0d80ea; width: 158px;height: 30px;font-size: 16px;color: #0d80ea;font-weight: bold;padding: 4px;padding-top: 10px;text-align: center;margin: 23px;'>" + nombrepatrocinador + "<div></center>";
                        msjupliners += "</a></div></center>";

                        msjupliners += "<center><div style='width: 100%'>";
                        msjupliners += "<p style='margin: auto;'>Membresia del Socio: " + auxmembership + "</p>";
                        msjupliners += "<p style='margin: auto;'>Fecha de Inscripcion: " + hoy + "</p>";
                        msjupliners += "</div></center>";

                        msjupliners += "<div style='margin-left: 9%;'>";
                        msjupliners += "<p style='margin:5px'>Saludos Cordiales</p><p  style='margin:5px'>Equipo inResorts</p></div>";
                        msjupliners += "<div style='margin: 5%; width: 70%;background-image: url('https://lh3.googleusercontent.com/NSDQDl8ytJrWSwMe0b3b9DlxubIal-RBEPIWI1a-15f9ynEGQ9eYjTnm-PVqst26f4KJThmjOEPK4lcVoaUw=w1016-h917-rw');'></ div > ";
                        msjupliners += "<img style='width: 100%' src='https://preview.ibb.co/ixY7iL/fondo222.png'>";
                        msjupliners += "</div>";

                        msjupliners += "</body>";
                        msjupliners += "</html>";
                        subjet = "[RIBERA DEL RIO - NUEVO SOCIO]";

                        if (!string.IsNullOrEmpty(correoU))
                        {

                            oemail.SubmitEmailNotFiles2(correoU, subjet, msjupliners, true, ruta, userName);
                        }

                    }

                }
            }

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




            //CORREO QUE LE LLEGA A LOS UPLINER 7 LINEAS ARRIBA
            //if (auxidafi != null && userName != null && auxnameafi != null)
            //{
            //    var idpatrocinador = auxidafi.ToString();
            //    brUser= new BrUser();
            //    var ListUpliners = brUser.GetUpliners(idpatrocinador);
            //    var filas = ListUpliners.Split('¬');
            //    for (int i = 0; i < filas.Length; i++)
            //    {
            //        if (!string.IsNullOrEmpty(filas[i]))
            //        {
            //        var upliner = filas[i].Split('|');
            //        var nombreU = upliner[0];
            //        var correoU = upliner[1];


            //        var nombreregistrado = name;
            //        var nombrepatrocinador = auxnameafi;

            //            var msjupliners = "<html><head><title></title></head><body style='color:black'>";
            //            msjupliners += "<div style='width: 100%'>";
            //            msjupliners += "<div style='display:flex;'>";
            //            msjupliners += "<div style='width:50%;'>";
            //            msjupliners += " <img src='http://www.inresorts.club/Views/img/novologo.png' align='left' style='width: 98px;'>";
            //            msjupliners += "</div>";
            //            msjupliners += "<div style='width:50%;'>";
            //            msjupliners += "<img src='http://cieneguillariberadelrio.com/riberadelrio/img/image006.png' align='right' style='width: 120px;padding-top: 7px;'>";
            //            msjupliners += "</div>";
            //            msjupliners += "</div>";
            //            msjupliners += "<img style='width: 100%' src='http://www.inresorts.club/Views/img/fondo.png'>";
            //            msjupliners += "<h1 style='margin-top: 2px ;text-align: center;font-weight: bold;'> Felicitaciones " + nombreU + "</h1>";
            //            msjupliners += "<h2 style='text-align: center;'>Tu red se expande, cuentas con un nuevo socio en tu red:</h2>";
            //            msjupliners += "";

            //            msjupliners += "<center><div style='width: 100%'>";
            //            //msjupliners += "<p style='margin-left: 10%;margin-right: 10%; '> Click en el boton para validar el pago.</p>";
            //            msjupliners += "<a style='text-decoration: none;'>";
            //            msjupliners += "<center><div style='font-weight: bold;'>Socio: <div></center>";
            //            msjupliners += "<center><div style='background: white;border-radius:10px;border: 1px solid #0d80ea; width: 158px;height: 30px;font-size: 16px;color: #0d80ea;font-weight: bold;padding: 4px;padding-top: 10px;text-align: center;margin: 23px;'>" + nombreregistrado + "<div></center>";
            //            msjupliners += "<center><div style='font-weight: bold;'>Upliner: <div></center>";
            //            msjupliners += "<center><div style='background: white;border-radius:10px;border: 1px solid #0d80ea; width: 158px;height: 30px;font-size: 16px;color: #0d80ea;font-weight: bold;padding: 4px;padding-top: 10px;text-align: center;margin: 23px;'>" + nombrepatrocinador + "<div></center>";
            //            msjupliners += "</a></div></center>";

            //            msjupliners += "<center><div style='width: 100%'>";
            //            msjupliners += "<p style='margin: auto;'>Membresia del Socio: " + auxmembership + "</p>";
            //            msjupliners += "<p style='margin: auto;'>Fecha de Inscripcion: " + hoy + "</p>";
            //            msjupliners += "</div></center>";

            //            msjupliners += "<div style='margin-left: 9%;'>";
            //            msjupliners += "<p style='margin:5px'>Saludos Cordiales</p><p  style='margin:5px'>Equipo inResorts</p></div>";
            //            msjupliners += "<div style='margin: 5%; width: 70%;background-image: url('https://lh3.googleusercontent.com/NSDQDl8ytJrWSwMe0b3b9DlxubIal-RBEPIWI1a-15f9ynEGQ9eYjTnm-PVqst26f4KJThmjOEPK4lcVoaUw=w1016-h917-rw');'></ div > ";
            //            msjupliners += "<img style='width: 100%' src='https://preview.ibb.co/ixY7iL/fondo222.png'>";
            //            msjupliners += "</div>";

            //            msjupliners += "</body>";
            //            msjupliners += "</html>";
            //            subjet = "[RIBERA DEL RIO - NUEVO SOCIO]";

            //            if (!string.IsNullOrEmpty(correoU))
            //            {

            //                oemail.submitEmailNotFiles2(correoU, subjet, msjupliners, true, ruta, userName);
            //            }

            //        }

            //    }
            //}



            return isSend;
        }

        private string ToCapitalize(string _text)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;

            return textInfo.ToTitleCase(_text);
        }
        #endregion
    }
}












