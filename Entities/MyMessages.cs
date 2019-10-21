using System;
using System.Globalization;
using System.Threading;

namespace Entities
{
    public class MyMessages : MyFunctions
    {
        public MyMessages()
        {

        }

        public string EmailPago()
        {
            return "<html><head><title></title></head><body style='color:black;'>"
             + "<div style='width: 100%;'>"
             + "<img src='http://www.inresorts.club/Views/img/novologo.png' align='left' style='width: 130px ;padding-left: 35px;'>"
             + "<img src='http://cieneguillariberadelrio.com/riberadelrio/img/image006.png' align='right' style='width: 130px;padding-right: 55px;padding-top: 15px;'>"
             + "<img style='width: 100%;' src='http://www.inresorts.club/Views/img/fondo.png'>"
             + "<h1 style='margin-top: 2px ;text-align: center;font-weight: bold;font-style: italic;'>PAGO</h1>"
             + "<h2 style='text-align: center;'></h2>"
             + "<p style='margin-left: 10%;margin-right: 10%; '></p> "
             + "<p style='margin-left: 10%;margin-right: 10% ;'></p></div>"

             + "<div style='width: 100%;'>"
             + "<p style='margin-left: 10%;margin-right: 10%; '></p>"
             + "<p style='margin-left: 10%;margin-right: 10%; '></p>"

             + "<h3 style='text-align: center;'></h3>"
             + "<div style='border: 2px solid gray;margin-left: 30%;margin-right: 30%;border-radius: 8px ;padding:10px;'>"
             + "Ha efectuado su pago con éxito</div>"
             + "<p style='margin-left: 10%;margin-right: 10% ;'>"
             + " </p>"
             + "<div style='margin-left: 10%;'>"
             + "<p style=''>Saludos Cordinales</p><p  style=''>Equipo Inresorts</p> <p  style=''>Gerente General</p></div>"
             + "<div style='margin: 5% ;width: 70%;background-image: url('https://lh3.googleusercontent.com/NSDQDl8ytJrWSwMe0b3b9DlxubIal-RBEPIWI1a-15f9ynEGQ9eYjTnm-PVqst26f4KJThmjOEPK4lcVoaUw=w1016-h917-rw')'></div> "
             + "<img style='width: 100%;' src='https://preview.ibb.co/ixY7iL/fondo222.png'>"
             + "</div>";
        }

        public string DocumentosRegister(string userName)
        {
            return "<html><head><title></title></head><body style='color:black;'>"
             + "<div style='width: 100%;'>"
             + "<img src='http://www.inresorts.club/Views/img/novologo.png' align='left' style='width: 130px ;padding-left: 35px;'>"
             + "<img src='http://cieneguillariberadelrio.com/riberadelrio/img/image006.png' align='right' style='width: 130px;padding-right: 55px;padding-top: 15px;'>"
             + "<img style='width: 100%;' src='http://www.inresorts.club/Views/img/fondo.png'>"
             + "<h1 style='margin-top: 2px ;text-align: center;font-weight: bold;font-style: italic;'>Bienvenido</h1>"
             + "<h2 style='text-align: center;'>Socio de Ribera del Rio Club Resort</h2>"
             + "<p style='margin-left: 10%;margin-right: 10%; '>En nombre de InResorts y Ribera del Rio es un placer darle la bienvenida, esperando que disfrute con nosotros las mejores experiencias. Ribera del Río Club Resort está abierto a su participación en nuestras diversas actividades, puede consultar en cualquier momento cualquier duda o enviarnos cualquier sugerencia.</p> "
             + "<p style='margin-left: 10%;margin-right: 10% ;'>A continuación, le resumimos un poco la información sobre los beneficios con los que contará por formar parte de la familia de Ribera del Río Club Resort como Socio.</p> </div>"

             + "<div style='width: 100%;text-align: center'>"
             + "<ul style='list-style: none;text-align: center; width: 22%;display: inline-block;'><li> Club 365.</li><li> Noches Hoteleras.</li></ul>"
             + "<ul style='list-style: none;text-align: center; width: 22%;display: inline-block;'><li> Descuentos.</li><li> Viajes.</li></ul>"
             + "<ul style='list-style: none;text-align: center; width: 22%;display: inline-block;'><li> Valorización de Inversión.</li>	<li> Plan de Referencias.</li></ul></div>"

             + "<div style='width: 100%;'>"
             + "<p style='margin-left: 10%;margin-right: 10%; '>Para Ribera del Río Club Resort, es de gran satisfacción contar con clientes tan importantes como usted y su familia que son participes del crecimiento de nuestra empresa, es por eso que, de quedar alguna interrogante al respecto, puede consultar nuestra pagina web www.cieneguillariberadelrio.com o comunicarse al telefono de nuestra oficina central 01 - 4349481 o al correo de socios@cieneguillariberadelrio.com en donde estamos prestos a cualquier inquietud, aclaración o trámites para el uso de su Membresía.</p>"
             + "<p style='margin-left: 10%;margin-right: 10%; '>Para realizar cualquier pago relacionado con el contrato adquirido de la Membresía de Ribera del Rio Club Resort, recuerde que esto lo puede hacer mediante su oficina virtual o a travez de nuestras cuentas de recaudo empresarial.Es de resaltar que sus pagos sólo deberá realizarlos a las cuentas que se indican en su contrato, de lo contrario, la compañia No responderá por pagos realizados a cuenta de terceros.</p>"

             + "<h3 style='text-align: center;'>Acceso a Oficina Virtual</h3>"
             + "<div style='border: 2px solid gray;margin-left: 30%;margin-right: 30%;border-radius: 8px ;'>"
             + "<center><p> Usuario: <b>" + userName + "</b></p><p> Password: <b>" + userName + "</b></p></center></div>"
             + "<p style='margin-left: 10%;margin-right: 10% ;'>"
             + "Le adjuntamos toda la documentación y anexos, relacionados a su afilicación </p>"
             + "<div style='margin-left: 10%;'>"
             + "<p style=''>Saludos Cordinales</p><p  style=''>Equipo Inresorts</p> <p  style=''>Gerente General</p></div>"
             + "<div style='margin: 5% ;width: 70%;background-image: url('https://lh3.googleusercontent.com/NSDQDl8ytJrWSwMe0b3b9DlxubIal-RBEPIWI1a-15f9ynEGQ9eYjTnm-PVqst26f4KJThmjOEPK4lcVoaUw=w1016-h917-rw')'></ div > "
             + "<img style='width: 100%;' src='https://preview.ibb.co/ixY7iL/fondo222.png'>"
             + "</div>";
        }

        public string EmailClaveDigital(string claveDigital, string name)
        {
            string email = "<!DOCTYPEhtml><html><head><title></title></head>";
            email = "<body><div style='font-family:sans-serif;display:block;padding:20px;margin:10px auto;width:700px;height:700px;background-color:white;'>";
            email += "<div style=' justify-content:space-between;text-align:center;'>";
            email += "<div style='display:flex;'>";
            email += "<div style='width:50%;'>";
            email += " <img src='http://www.inresorts.club/Views/img/novologo.png' align='left' style='width: 98px;'>";
            email += "</div>";
            email += "<div style='width:50%;'>";
            email += "<img src='http://cieneguillariberadelrio.com/riberadelrio/img/image006.png' align='right' style='width: 120px;padding-top: 7px;'>";
            email += "</div>";
            email += "</div>";
            email += "<img style='width: 100%' src='http://www.inresorts.club/Views/img/fondo.png'>";
            email += "</div>";
            email += "";

            email += "<h1>Hola " + name + "</h1><br><br>";
            email += "<div>Hay un intento de Tranferencia en tu Wallet.";
            email += "<br> <p style='margin-left: 10%;margin-right: 10%;text-align: center; '><b>Esta es la Clave Digital</b></p> ";
            email += "<h1 style='margin-left: 10%;margin-right: 10%;text-align: center;'>" + claveDigital + "</h1>";
            email += "</div><div> <p style='margin-left: 10%;margin-right: 10%;text-align: center; '>Expirará en 5 minutos</p>";


            email += "<div>Si tu no Haz sido la persona que ha realizado esta operacion, Por Favor te pedimos ponerte en contacto con el area de tesoreria ( 938 627 411 ). ";
            email += "Para poder bloquear la cuenta del usuario destinatario mientras de realiza las indagaciones del caso.</div>";

            email += "<br>";
            email += "<br>";
            email += "<div style='margin-left: 9%;'>";
            email += "<p style='margin:5px'>Saludos Cordiales</p><p  style='margin:5px'>Equipo inResorts</p></div>";
            email += "<div style='margin: 5%; width: 70%;background-image: url('https://lh3.googleusercontent.com/NSDQDl8ytJrWSwMe0b3b9DlxubIal-RBEPIWI1a-15f9ynEGQ9eYjTnm-PVqst26f4KJThmjOEPK4lcVoaUw=w1016-h917-rw');'></ div > ";
            email += "<img style='width: 100%' src='https://preview.ibb.co/ixY7iL/fondo222.png'>";
            email += "</div></body></html>";
            return email;
        }

        //después del vencimiento
        public string EmailDeuda(string description, string date, decimal quote, string name, string lastName, string quoteLeter, string currentDate)
        {
            /*<img src='#'style='position:absolute;top:24%;left:28%;opacity:0.1;"; email += "z-index:1;width:515px;'>*/
            string email = "<!DOCTYPEhtml><html><head><title></title></head>";
            email = "<body><div style='font-family:sans-serif;display:block;padding:20px;margin:10px auto;width:700px;height:700px;background-color:white;'>";
            email += "<div style=' justify-content:space-between;text-align:center;'>";
            email += "<div style='display:flex;'>";
            email += "<div style='width:50%;'>";
            email += " <img src='http://www.inresorts.club/Views/img/novologo.png' align='left' style='width: 98px;'>";
            email += "</div>";
            email += "<div style='width:50%;'>";
            email += "<img src='http://cieneguillariberadelrio.com/riberadelrio/img/image006.png' align='right' style='width: 120px;padding-top: 7px;'>";
            email += "</div>";
            email += "</div>";
            email += "<img style='width: 100%' src='http://www.inresorts.club/Views/img/fondo.png'>";
            email += "</div>";
            email += "";

            email += "<div style='display:block;margin: 10px auto;text-align:center;'>";
            email += "<h2><b>VALLE ENCANTADO S.A.C</b></h2> <h2><b>RUC 20601460271</b></h2>";
            email += "</div><br>";
            email += "<div>Estimado cliente " + name.ToUpper() + " " + lastName.ToUpper() + "</div><br><br>";
            email += "<div>Por medio de la presente queremos recordarle que el día " +
                date.Split('-')[2] + " de " + GetMonth(date.Split('-')[1]) + " del " + date.Split('-')[0] + " es el vencimiento de su " + description + ".";
            email += "<br> <p style='margin-left: 10%;margin-right: 10%;text-align: center; '><b>Monto a pagar</b></p> ";
            email += "<p style='margin-left: 10%;margin-right: 10%;text-align: center;'>S/." + quote.ToString() + "</p>";
            email += "</div><div> <p style='margin-left: 10%;margin-right: 10%;text-align: center; '><b>Cuenta corriente:</b></p>";
            email += "<p style='margin-left: 10%;margin-right: 10%;text-align: center;'>N° 191-2606708-0-82</p>";
            email += "<p style='margin-left: 10%;margin-right: 10%; text-align: center;'>Banco de Credito del Perú.(BCP)</p>";
            email += "<div>Recuerde que el pago lo puede realizar mediante deposito en nuestra cuenta corriente a travéz de Agente BCP, Agencia BCP O transferencia bancaria desde Banca por Internet.</div>";
            email += "<center><p style='margin-left: 10%;margin-right: 10%;text-align: center;'>El motivo de esta carta de aviso es que no hemos recibo la confirmación del pago pendiente mencionado por lo que le agradeceríamos que efectuara el abono de la misma con la mayor brevedad posible.</p></center>";
            email += "<center><p style='margin-left: 10%;margin-right: 10%;text-align: center;'>Cuando lo tenga listo, solo tienes que subirlo a nuestra página y enseguida lo estaremos validando</p></center>";
            email += "<center><div style='width: 100%'>";
            email += "<p style='margin-left: 10%;margin-right: 10%;'>Clic en el botón para validar el pago.</p>";
            email += "<a style='text-decoration: none;' href='https://inresorts.club/Views/Payments.aspx'>";
            email += "<center><div style='background: #0d80ea;border-radius:10px;width: 158px;height: 30px;font-size: 16px;color: white;font-weight: bold;padding: 4px;padding-top: 10px;cursor: pointer;text-align: center;margin: 23px;'>Validar pago<div></center>";
            email += "</a></div></center>";
            email += "</div>";

            email += "<br>";
            email += "<br>";
            email += "<div style='margin-left: 9%;'>";
            email += "<p style='margin:5px'>Saludos Cordiales</p><p  style='margin:5px'>Equipo inResorts</p></div>";
            email += "<div style='margin: 5%; width: 70%;background-image: url('https://lh3.googleusercontent.com/NSDQDl8ytJrWSwMe0b3b9DlxubIal-RBEPIWI1a-15f9ynEGQ9eYjTnm-PVqst26f4KJThmjOEPK4lcVoaUw=w1016-h917-rw');'></ div > ";
            email += "<img style='width: 100%' src='https://preview.ibb.co/ixY7iL/fondo222.png'>";
            email += "</div></body></html>";
            return email;
        }

        public string EmailDeuda(string detail, string name, string lastName, string dateCurrent)
        {

            string email = "<!DOCTYPEhtml><html><head><title></title></head>";
            email = "<body><div style='font-family:sans-serif;display:block;padding:20px;margin:10px auto;width:700px;height:700px;background-color:white;'>";
            email += "<div style=' justify-content:space-between;text-align:center;'>";
            email += "<div style='display:flex;'>";
            email += "<div style='width:50%;'>";
            email += " <img src='http://www.inresorts.club/Views/img/novologo.png' align='left' style='width: 98px;'>";
            email += "</div>";
            email += "<div style='width:50%;'>";
            email += "<img src='http://cieneguillariberadelrio.com/riberadelrio/img/image006.png' align='right' style='width: 120px;padding-top: 7px;'>";
            email += "</div>";
            email += "</div>";
            email += "<img style='width: 100%' src='http://www.inresorts.club/Views/img/fondo.png'>";
            email += "</div>";
            email += "";

            email += "<div style='display:block;margin: 10px auto;text-align:center;'>";
            email += "</div>";
            email += "<div>Estimado cliente " + name.ToUpper() + " " + lastName.ToUpper() + "</div>";
            email += "<div>Por medio de la presente queremos recordarle el vencimiento de sus Cuotas.<br>";

            email += "<p style='margin-left: 10%;margin-right: 10%;text-align: center;'>Descripcion&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
            email += "Fecha &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Monto</p>";
            email += "<p style='margin-left: 10%;margin-right: 10%;text-align: center;'>==========================================</p>";

            var fechaCurren = DateTime.Now;
            var proxima = "";
            var proximaspace = "";

            decimal total = 0;
            var rows = detail.Split('¬');
            for (int i = 0; i < rows.Length; i++)
            {
                string symbol = "$";
                var row = rows[i].Split('|');
                string description = row[0];
                string date = row[1];
                decimal amount = decimal.Parse(row[2]);
                string currencycode = row[3];

                if (currencycode == "PEN")
                {
                    symbol = "S/ ";
                }

                if (DateTime.Parse(date) >= fechaCurren)
                {
                    proxima = " <b style='color:red;'>Proxima</b>";
                    proximaspace = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                }

                total += amount;

                email += $"<p style='margin-left: 10%;margin-right: 10%;text-align: center; '>{proximaspace}<b>{description}</b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                email += date.Split('-')[2] + " de " + GetMonth(date.Split('-')[1]) + " del " + date.Split('-')[0];
                email += $" &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>{symbol} {amount.ToString()}</b> {proxima}</p>";

            }


            email += "<p style='margin-left: 10%;margin-right: 10%;text-align: center;'>==========================================</p>";
            email += "<p style='margin-left: 10%;margin-right: 10%;text-align: center;'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Total: S/." + total.ToString() + "</p>";
            email += "</div><div> <p style='margin-left: 10%;margin-right: 10%;text-align: center; '><b>Cuenta corriente:</b></p>";
            email += "<p style='margin-left: 10%;margin-right: 10%;text-align: center;'>N° 191-2606708-0-82</p>";
            email += "<p style='margin-left: 10%;margin-right: 10%; text-align: center;'>Banco de Credito del Perú.(BCP)</p>";
            email += "<div>Recuerde que Pagando HOY su cuota mas antigua su <b>Cronograma se Reestructura quedando al dia</b> ya que todavia se encuentra dentro del periodo de holgura. El pago lo puede realizar mediante deposito en nuestra cuenta corriente a travéz de Agente BCP, Agencia BCP O transferencia bancaria desde Banca por Internet.</div>";
            email += "<center><p style='margin-left: 10%;margin-right: 10%;text-align: center;'>El motivo de esta carta de aviso es que no hemos recibo la confirmación del pago pendiente mencionado por lo que le agradeceríamos que efectuara el abono de la misma con la mayor brevedad posible.</p></center>";
            //email += "<center><p style='margin-left: 10%;margin-right: 10%;text-align: center;'>Cuando lo tenga listo, solo tienes que subirlo a nuestra página y enseguida lo estaremos validando</p></center>";
            email += "<center><div style='width: 100%'>";
            //email += "<p style='margin-left: 10%;margin-right: 10%;'>Clic en el botón para validar el pago.</p>";
            //email += "<a style='text-decoration: none;' href='https://inresorts.club/Views/Payments.aspx'>";
            //email += "<center><div style='background: #0d80ea;border-radius:10px;width: 158px;height: 30px;font-size: 16px;color: white;font-weight: bold;padding: 4px;padding-top: 10px;cursor: pointer;text-align: center;margin: 23px;'>Validar pago<div></center>";
            //email += "</a>";
            email += "</div></center></div>";


            // email += "<br>";
            email += "<div style='margin-left: 9%;'>";
            email += "<p style='margin:5px'>Saludos Cordiales</p><p  style='margin:5px'>Equipo inResorts</p></div>";
            email += "<div style='margin: 5%; width: 70%;background-image: url('https://lh3.googleusercontent.com/NSDQDl8ytJrWSwMe0b3b9DlxubIal-RBEPIWI1a-15f9ynEGQ9eYjTnm-PVqst26f4KJThmjOEPK4lcVoaUw=w1016-h917-rw');'></ div > ";
            email += "<img style='width: 100%' src='https://preview.ibb.co/ixY7iL/fondo222.png'>";
            email += "</div></body></html>";
            return email;
        }

        public string ReportProblemWallet(string userName, string subjet, string messagge)
        {
            string email = "<!DOCTYPEhtml><html><head><title></title></head>";
            email = "<body><div style='font-family:sans-serif;display:block;padding:20px;margin:10px auto;width:700px;height:700px;background-color:white;'>";
            email += "<div style=' justify-content:space-between;text-align:center;'>";
            email += "<div style='display:flex;'>";
            email += "<div style='width:50%;'>";
            email += " <img src='http://www.inresorts.club/Views/img/novologo.png' align='left' style='width: 98px;'>";
            email += "</div>";
            email += "<div style='width:50%;'>";
            email += "<img src='http://cieneguillariberadelrio.com/riberadelrio/img/image006.png' align='right' style='width: 120px;padding-top: 7px;'>";
            email += "</div>";
            email += "</div>";
            email += "<img style='width: 100%' src='http://www.inresorts.club/Views/img/fondo.png'>";
            email += "</div>";
            email += "";

            email += "<h1 style='margin: 0 10%;'>" + subjet + "</h1><br><br>";
            email += "<div style='margin: 0 10%;'> ";
            email += $"<br><p>Mi Codigo es : {userName}</p><p>{messagge}</p></div>";

            email += "<div>";
            email += "<br>";
            email += "<br>";
            email += "<br>";
            email += "<br>";
            email += "<br>";
            email += "<br>";
            email += "<div style='margin-left: 9%;'>";
            email += "<p style='margin:5px'>Saludos Cordiales</p><p  style='margin:5px'>Equipo inResorts</p></div>";
            email += "<div style='margin: 5%; width: 70%;background-image: url('https://lh3.googleusercontent.com/NSDQDl8ytJrWSwMe0b3b9DlxubIal-RBEPIWI1a-15f9ynEGQ9eYjTnm-PVqst26f4KJThmjOEPK4lcVoaUw=w1016-h917-rw');'></ div > ";
            email += "<img style='width: 100%' src='https://preview.ibb.co/ixY7iL/fondo222.png'>";
            email += "</div></body></html>";
            return email;
        }

        public string EmailTranferSuccess(string name, string UserNameBeneficiary, string amount)
        {
            string email = "<!DOCTYPEhtml><html><head><title></title></head>";
            email = "<body><div style='font-family:sans-serif;display:block;padding:20px;margin:10px auto;width:700px;height:700px;background-color:white;'>";
            email += "<div style=' justify-content:space-between;text-align:center;'>";
            email += "<div style='display:flex;'>";
            email += "<div style='width:50%;'>";
            email += " <img src='http://www.inresorts.club/Views/img/novologo.png' align='left' style='width: 98px;'>";
            email += "</div>";
            email += "<div style='width:50%;'>";
            email += "<img src='http://cieneguillariberadelrio.com/riberadelrio/img/image006.png' align='right' style='width: 120px;padding-top: 7px;'>";
            email += "</div>";
            email += "</div>";
            email += "<img style='width: 100%' src='http://www.inresorts.club/Views/img/fondo.png'>";
            email += "</div>";
            email += "";

            email += "<h1 style='margin: 0 10%;'>Hola " + name + "</h1><br><br>";
            email += "<div style='margin: 0 10%;'> ";
            email += $"<br> <p>Se ha Realizado con exito la transferencia de Wallet a Wallet para el usuario <b>{UserNameBeneficiary}</b> por el monto de <b>S/ {amount}</b>.</p></div>";

            email += "<div>";


            email += "<div style='margin: 0 10%;'>Si tu no Haz sido la persona que ha realizado esta operacion, Por Favor te pedimos ponerte en contacto con el area de tesoreria ( 938 627 411 ). ";
            email += "Para poder bloquear la cuenta del usuario destinatario mientras de realiza las indagaciones del caso.</div>";

            email += "<br>";
            email += "<br>";
            email += "<div style='margin-left: 9%;'>";
            email += "<p style='margin:5px'>Saludos Cordiales</p><p  style='margin:5px'>Equipo inResorts</p></div>";
            email += "<div style='margin: 5%; width: 70%;background-image: url('https://lh3.googleusercontent.com/NSDQDl8ytJrWSwMe0b3b9DlxubIal-RBEPIWI1a-15f9ynEGQ9eYjTnm-PVqst26f4KJThmjOEPK4lcVoaUw=w1016-h917-rw');'></ div > ";
            email += "<img style='width: 100%' src='https://preview.ibb.co/ixY7iL/fondo222.png'>";
            email += "</div></body></html>";
            return email;
        }

        //antes del vencimiento
        public string EmailDebePagar(string description, string date, decimal quote, string name, string lastName, string quoteLeter, string currentDate, string pin, string currencycode)
        {
            string symbol = "$";

            if (currencycode == "PEN")
            {
                symbol = "S/ ";
            }

            string email = "<!DOCTYPE html><html><head><title></title></head>";
            email = "<body><div style='font-family:sans-serif;display:block;padding:20px;margin:10px auto;width:700px;height:700px;background-color:white;'>";
            email += "<div style=' justify-content:space-between;text-align:center;'>";
            email += "<div style='display:flex;'>";
            email += "<div style='width:50%;'>";
            email += "<img src='http://www.inresorts.club/Views/img/novologo.png' align='left' style='width: 98px;'>";
            email += "</div>";
            email += "<div style='width:50%;'>";
            email += "<img src='http://cieneguillariberadelrio.com/riberadelrio/img/image006.png' align='right' style='width: 120px;padding-top: 7px;'>";
            email += "</div>";
            email += "</div>";
            email += "<img style='width: 100%' src='http://www.inresorts.club/Views/img/fondo.png'>";
            email += "</div>";
            email += "";

            email += "<div style='display:block;margin: 10px auto;text-align:center;'>";
            //email += "<h2><b>VALLE ENCANTADO S.A.C</b></h2> <h2><b>RUC 20601460271</b></h2>";
            email += "</div>";
            email += "<div>Estimado cliente <b>" + name.ToUpper() + " " + lastName.ToUpper() + "</b></div>";
            email += "<div>Por medio de la presente queremos recordarle que el día " +
                date.Split('-')[2] + " de " + GetMonth(date.Split('-')[1]) + " del " + date.Split('-')[0] + " es el vencimiento de su " + description + ".";
            email += $"<p>El Pin es <b>{pin}</b>.</p> ";
            email += "<p style='margin-left: 10%;margin-right: 10%;text-align: center; '><b>Monto a pagar</b></p> ";
            email += $"<p style='margin-left: 10%;margin-right: 10%;text-align: center;'>{symbol} {quote.ToString()} {currencycode}</p>";
            email += "</div><div> <p style='margin-left: 10%;margin-right: 10%;text-align: center; '><b>Cuenta corriente:</b></p>";
            email += "<p style='margin-left: 10%;margin-right: 10%;text-align: center;'>N° 191-2606708-0-82</p>";
            email += "<p style='margin-left: 10%;margin-right: 10%; text-align: center;'>Banco de Credito del Perú.(BCP)</p>";
            email += "<div>Recuerde que el pago lo puede realizar mediante deposito en nuestra cuenta corriente a travéz de Agente BCP, Agencia BCP O transferencia bancaria desde Banca por Internet.</div>";
            email += "<center><p style='margin-left: 10%;margin-right: 10%;text-align: center;'>Cuando lo tenga listo, solo tienes que subirlo a nuestra página y enseguida lo estaremos validando</p></center>";
            email += "<center><div style='width: 100%'>";
            email += "<p style='margin-left: 10%;margin-right: 10%;'>Clic en el botón para validar el pago.</p>";
            email += "<a style='text-decoration: none;' href='https://inresorts.club/Views/Payments.aspx'>";
            email += "<center><div style='background: #0d80ea;border-radius:10px;width: 158px;height: 30px;font-size: 16px;color: white;font-weight: bold;padding: 4px;padding-top: 10px;cursor: pointer;text-align: center;margin: 23px;'>Validar pago<div></center>";
            email += "</a></div></center>";
            email += "</div>";

            //email += "<br>";
            email += "<br>";
            email += "<div style='margin-left: 9%;'>";
            email += "<p style='margin:5px'>Saludos Cordiales</p><p  style='margin:5px'>Equipo inResorts</p></div>";
            email += "<div style='margin: 5%; width: 70%;background-image: url('https://lh3.googleusercontent.com/NSDQDl8ytJrWSwMe0b3b9DlxubIal-RBEPIWI1a-15f9ynEGQ9eYjTnm-PVqst26f4KJThmjOEPK4lcVoaUw=w1016-h917-rw');'></ div > ";
            email += "<img style='width: 100%' src='https://preview.ibb.co/ixY7iL/fondo222.png'>";
            email += "</div></body></html>";
            return email;
        }

        //se vence hoy
        public string EmailPagarHoy(string description, string date, decimal quote, string name, string lastName, string quoteLeter, string currentDate)
        {
            string email = "<!DOCTYPE html><html><head><title></title></head>";
            email = "<body><div style='font-family:sans-serif;display:block;padding:20px;margin:10px auto;width:700px;height:700px;background-color:white;'>";
            email += "<div style=' justify-content:space-between;text-align:center;'>";
            email += "<div style='display:flex;'>";
            email += "<div style='width:50%;'>";
            email += " <img src='http://www.inresorts.club/Views/img/novologo.png' align='left' style='width: 98px;'>";
            email += "</div>";
            email += "<div style='width:50%;'>";
            email += "<img src='http://cieneguillariberadelrio.com/riberadelrio/img/image006.png' align='right' style='width: 120px;padding-top: 7px;'>";
            email += "</div>";
            email += "</div>";
            email += "<img style='width: 100%' src='http://www.inresorts.club/Views/img/fondo.png'>";
            email += "</div>";
            email += "";

            email += "<div style='display:block;margin: 10px auto;text-align:center;'>";
            //email += "<h2><b>VALLE ENCANTADO S.A.C</b></h2> <h2><b>RUC 20601460271</b></h2>";
            email += "</div><br>";
            email += "<div>Estimado cliente " + name.ToUpper() + " " + lastName.ToUpper() + "</div><br><br>";
            email += "<div>Por medio de la presente queremos recordarle que el día " +
                date.Split('-')[2] + " de " + GetMonth(date.Split('-')[1]) + " del " + date.Split('-')[0] + " es el vencimiento de su cuota.";
            email += "<br> <p style='margin-left: 10%;margin-right: 10%;text-align: center; '><b>Monto a pagar</b></p> ";
            email += "<p style='margin-left: 10%;margin-right: 10%;text-align: center;'>S/." + quote.ToString() + "</p>";
            email += "</div><div> <p style='margin-left: 10%;margin-right: 10%;text-align: center; '><b>Cuenta corriente:</b></p>";
            email += "<p style='margin-left: 10%;margin-right: 10%;text-align: center;'>N° 191-2606708-0-82</p>";
            email += "<p style='margin-left: 10%;margin-right: 10%; text-align: center;'>Banco de Credito del Perú.(BCP)</p>";
            email += "<div>Recuerde que el pago lo puede realizar mediante deposito en nuestra cuenta corriente a travéz de Agente BCP, Agencia BCP O transferencia bancaria desde Banca por Internet.</div>";
            email += "<center><p style='margin-left: 10%;margin-right: 10%;text-align: center;'>Cuando lo tenga listo, solo tienes que subirlo a nuestra página y enseguida lo estaremos validando</p></center>";
            email += "<center><div style='width: 100%'>";
            email += "<p style='margin-left: 10%;margin-right: 10%;'>Clic en el botón para validar el pago.</p>";
            email += "<a style='text-decoration: none;' href='https://inresorts.club/Views/Payments.aspx'>";
            email += "<center><div style='background: #0d80ea;border-radius:10px;width: 158px;height: 30px;font-size: 16px;color: white;font-weight: bold;padding: 4px;padding-top: 10px;cursor: pointer;text-align: center;margin: 23px;'>Validar pago<div></center>";
            email += "</a></div></center>";
            email += "</div>";

            email += "<br>";
            email += "<br>";
            email += "<div style='margin-left: 9%;'>";
            email += "<p style='margin:5px'>Saludos Cordiales</p><p  style='margin:5px'>Equipo inResorts</p></div>";
            email += "<div style='margin: 5%; width: 70%;background-image: url('https://lh3.googleusercontent.com/NSDQDl8ytJrWSwMe0b3b9DlxubIal-RBEPIWI1a-15f9ynEGQ9eYjTnm-PVqst26f4KJThmjOEPK4lcVoaUw=w1016-h917-rw');'></ div > ";
            email += "<img style='width: 100%' src='https://preview.ibb.co/ixY7iL/fondo222.png'>";
            email += "</div></body></html>";
            return email;
        }

        public string SubjetEmailPartner()
        {
            return "Un Nuevo Socio -Inresorts";
        }

        public string EmailPartner()
        {
            return "mensaje para email";
        }


        public string MessageComprobandoImagen(string fName, string gender)
        {
            string bienvenido = "Bienvenido";
            if (gender == "F")
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
            return cuerpo;

        }

        public string ToCapitalize(string _text)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;

            return textInfo.ToTitleCase(_text);
        }
    }
}
