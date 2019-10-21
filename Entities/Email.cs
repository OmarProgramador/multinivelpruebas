
namespace Entities
{
    using System;
    using System.Net.Mail;

    public class Email
    {
        private string host;
        private int port;
        private string credentialAddress;
        private string credentialClave;
        private string displayName;

        public Email()
        {
            this.host = "cieneguillariberadelrio.com";
            this.port = 587;
            this.credentialAddress = "knava@cieneguillariberadelrio.com";
            this.credentialClave = "Sistemas1";
            this.displayName = "InResorts";
        }
        public bool SendEmail(string email, string subject, string body, bool isHtml)
        {
            try
            {
                //La cadena "servidor" es el servidor de correo que enviará tu mensaje
                SmtpClient server = new SmtpClient(host, port);
                // Crea el mensaje estableciendo quién lo manda y quién lo recibe
                //Envía el mensaje.
                server.Credentials = new System.Net.NetworkCredential(credentialAddress, credentialClave);
                server.EnableSsl = false;
                //Añade credenciales si el servidor lo requiere.
                MailMessage mnsj = new MailMessage();
                mnsj.Subject = subject;
                mnsj.IsBodyHtml = isHtml;
                mnsj.To.Add(new MailAddress(email));
                //mnsj.To.Add(new MailAddress("ingresosocios@inresorts.club"));
                mnsj.From = new MailAddress(credentialAddress, displayName);

                /* Si deseamos Adjuntar algún archivo*/
                mnsj.Body = body;
                // mnsj.Body = "<html><title></title><head></head><header></header><body>tanga de tigre</body></html>";
                server.Send(mnsj);
                /* Enviar */
                //Response.Redirect("PostRegister.aspx");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool SubmitEmail(string email, string subject, string body)
        {
            try
            {
                //La cadena "servidor" es el servidor de correo que enviará tu mensaje
                SmtpClient server = new SmtpClient(host, port);
                // Crea el mensaje estableciendo quién lo manda y quién lo recibe
                //Envía el mensaje.
                server.Credentials = new System.Net.NetworkCredential(credentialAddress, credentialClave);
                server.EnableSsl = false;
                //Añade credenciales si el servidor lo requiere.
                MailMessage mnsj = new MailMessage();
                mnsj.Subject = subject;
                mnsj.IsBodyHtml = true;
                mnsj.To.Add(new MailAddress(email));
                //mnsj.To.Add(new MailAddress("ingresosocios@inresorts.club"));
                mnsj.From = new MailAddress(credentialAddress, displayName);

                /* Si deseamos Adjuntar algún archivo*/
                mnsj.Body = body;
                // mnsj.Body = "<html><title></title><head></head><header></header><body>tanga de tigre</body></html>";
                server.Send(mnsj);
                /* Enviar */
                //Response.Redirect("PostRegister.aspx");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool SubmitEmail(string email, string subject, string body, bool isBodyHtml, string ruta, string userName)
        {
            try
            {
                using (SmtpClient server = new SmtpClient(host, port))
                {
                    // Crea el mensaje estableciendo quién lo manda y quién lo recibe
                    //Envía el mensaje.
                    server.Credentials = new System.Net.NetworkCredential(credentialAddress, credentialClave);
                    server.EnableSsl = true;
                    //Añade credenciales si el servidor lo requiere.
                    MailMessage mnsj = new MailMessage();
                    mnsj.Subject = subject;
                    mnsj.IsBodyHtml = true;
                    mnsj.To.Add(new MailAddress(email));
                    //mnsj.To.Add(new MailAddress("ingresosocios@inresorts.club"));
                    mnsj.From = new MailAddress(credentialAddress, displayName);
                    /* Si deseamos Adjuntar algún archivo*/
                    mnsj.Body = body;

                    Attachment _attachment = new Attachment(ruta + "CON" + userName + ".pdf");
                    mnsj.Attachments.Add(_attachment);
                    Attachment _attachment2 = new Attachment(ruta + "CER" + userName + ".pdf");
                    mnsj.Attachments.Add(_attachment2);
                    Attachment _attachment3 = new Attachment(ruta + "RCI" + userName + ".pdf");
                    mnsj.Attachments.Add(_attachment3);
                    Attachment _attachment4 = new Attachment(ruta + "CRO" + userName + ".pdf");
                    mnsj.Attachments.Add(_attachment4);
                    Attachment _attachment5 = new Attachment(ruta + "PAG" + userName + ".pdf");
                    mnsj.Attachments.Add(_attachment5);

                    Attachment _attachment6 = new Attachment(ruta + "PLAN_COMPENSACION_INRESORTS" + ".pdf");
                    mnsj.Attachments.Add(_attachment6);

                    Attachment _attachment7 = new Attachment(ruta + "PLAN_DE_BENEFICIOS_INRESORTS" + ".pdf");
                    mnsj.Attachments.Add(_attachment7);

                    Attachment _attachment8 = new Attachment(ruta + "Reglamento_de_Ética_inResorts" + ".pdf");
                    mnsj.Attachments.Add(_attachment8);

                    server.Send(mnsj);
                }

                return true;
            }
            catch (Exception e)
            {
                
                return false;
            }
        }


        public bool SubmitEmailNotFiles2(string email, string subject, string body, bool isBodyHtml, string ruta, string userName)
        {
            try
            {
                using (SmtpClient server = new SmtpClient(host, port))
                {
                    // Crea el mensaje estableciendo quién lo manda y quién lo recibe
                    //Envía el mensaje.
                    server.Credentials = new System.Net.NetworkCredential(credentialAddress, credentialClave);
                    server.EnableSsl = true;
                    //Añade credenciales si el servidor lo requiere.
                    MailMessage mnsj = new MailMessage();
                    mnsj.Subject = subject;
                    mnsj.IsBodyHtml = true;
                    mnsj.To.Add(new MailAddress(email));
                    //mnsj.To.Add(new MailAddress("ingresosocios@inresorts.club"));
                    mnsj.From = new MailAddress(credentialAddress, displayName);
                    /* Si deseamos Adjuntar algún archivo*/
                    mnsj.Body = body;


                    server.Send(mnsj);
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool SubmitEmailNotFiles3(string email, string subject, string body, bool isBodyHtml)
        {
            try
            {
                SmtpClient server = new SmtpClient(host, port);
                // Crea el mensaje estableciendo quién lo manda y quién lo recibe
                //Envía el mensaje.
                server.Credentials = new System.Net.NetworkCredential(credentialAddress, credentialClave);
                server.EnableSsl = true;
                //Añade credenciales si el servidor lo requiere.
                MailMessage mnsj = new MailMessage();
                mnsj.Subject = subject;
                mnsj.IsBodyHtml = true;
                mnsj.To.Add(new MailAddress(email));
                //mnsj.To.Add(new MailAddress("ingresosocios@inresorts.club"));
                mnsj.From = new MailAddress(credentialAddress, displayName);
                /* Si deseamos Adjuntar algún archivo*/
                mnsj.Body = body;


                server.Send(mnsj);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool SubmitEmailNotFiles(string email, string subject, string body, bool isBodyHtml, string ruta, string userName)
        {
            try
            {
                SmtpClient server = new SmtpClient(host, port);
                // Crea el mensaje estableciendo quién lo manda y quién lo recibe
                //Envía el mensaje.
                server.Credentials = new System.Net.NetworkCredential(credentialAddress, credentialClave);
                server.EnableSsl = true;
                //Añade credenciales si el servidor lo requiere.
                MailMessage mnsj = new MailMessage();
                mnsj.Subject = subject;
                mnsj.IsBodyHtml = true;
                mnsj.To.Add(new MailAddress(email));
                //mnsj.To.Add(new MailAddress("ingresosocios@inresorts.club"));
                mnsj.From = new MailAddress(credentialAddress, displayName);
                /* Si deseamos Adjuntar algún archivo*/
                mnsj.Body = body;



                Attachment _attachment6 = new Attachment(ruta + "PLAN_COMPENSACION_INRESORTS" + ".pdf");
                mnsj.Attachments.Add(_attachment6);
                Attachment _attachment7 = new Attachment(ruta + "PLAN_DE_BENEFICIOS_INRESORTS" + ".pdf");
                mnsj.Attachments.Add(_attachment7);
                Attachment _attachment8 = new Attachment(ruta + "Reglamento_de_Ética_inResorts" + ".pdf");
                mnsj.Attachments.Add(_attachment8);
                server.Send(mnsj);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }


        public bool SubmitEmailKit(string email, string subject, string body, bool isBodyHtml, string ruta)
        {
            try
            {
                SmtpClient server = new SmtpClient(host, port);
                // Crea el mensaje estableciendo quién lo manda y quién lo recibe
                //Envía el mensaje.
                server.Credentials = new System.Net.NetworkCredential(credentialAddress, credentialClave);
                server.EnableSsl = true;
                //Añade credenciales si el servidor lo requiere.
                MailMessage mnsj = new MailMessage();
                mnsj.Subject = subject;
                mnsj.IsBodyHtml = true;
                mnsj.To.Add(new MailAddress(email));
                //mnsj.To.Add(new MailAddress("ingresosocios@inresorts.club"));
                mnsj.From = new MailAddress(credentialAddress, displayName);
                /* Si deseamos Adjuntar algún archivo*/
                mnsj.Body = body;
                // mnsj.Body = "jeje";
                Attachment _attachment6 = new Attachment(ruta + "PLAN_COMPENSACION_INRESORTS" + ".pdf");
                mnsj.Attachments.Add(_attachment6);
                Attachment _attachment8 = new Attachment(ruta + "Reglamento_de_Ética_inResorts" + ".pdf");
                mnsj.Attachments.Add(_attachment8);


                server.Send(mnsj);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool SubmitEmailStore(string email, string subject, string body, bool isBodyHtml, string ruta, string userName)
        {
            try
            {
                SmtpClient server = new SmtpClient(host, port);
                // Crea el mensaje estableciendo quién lo manda y quién lo recibe
                //Envía el mensaje.
                server.Credentials = new System.Net.NetworkCredential(credentialAddress, credentialClave);
                server.EnableSsl = true;
                //Añade credenciales si el servidor lo requiere.
                MailMessage mnsj = new MailMessage();
                mnsj.Subject = subject;
                mnsj.IsBodyHtml = true;
                mnsj.To.Add(new MailAddress(email));
                //mnsj.To.Add(new MailAddress("ingresosocios@inresorts.club"));
                mnsj.From = new MailAddress(credentialAddress, displayName);
                /* Si deseamos Adjuntar algún archivo*/
                mnsj.Body = body;

                Attachment _attachment = new Attachment(ruta + "CON" + userName + ".pdf");
                mnsj.Attachments.Add(_attachment);
                Attachment _attachment2 = new Attachment(ruta + "CER" + userName + ".pdf");
                mnsj.Attachments.Add(_attachment2);
                Attachment _attachment3 = new Attachment(ruta + "RCI" + userName + ".pdf");
                mnsj.Attachments.Add(_attachment3);
                Attachment _attachment4 = new Attachment(ruta + "CRO" + userName + ".pdf");
                mnsj.Attachments.Add(_attachment4);
                Attachment _attachment5 = new Attachment(ruta + "PAG" + userName + ".pdf");
                mnsj.Attachments.Add(_attachment5);
                //Attachment _attachment7 = new Attachment(ruta + "Plan_beneficios_riberadelrio_inResorts" + ".pdf");
                //mnsj.Attachments.Add(_attachment7);

                server.Send(mnsj);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool SendNotificationEmail(string[] listEmail, string subject, string body, bool isBodyHtml)
        {
            try
            {
                SmtpClient server = new SmtpClient(host, port);
                // Crea el mensaje estableciendo quién lo manda y quién lo recibe
                //Envía el mensaje.
                server.Credentials = new System.Net.NetworkCredential(credentialAddress, credentialClave);
                server.EnableSsl = true;
                //Añade credenciales si el servidor lo requiere.
                MailMessage mnsj = new MailMessage();
                mnsj.Subject = subject;
                mnsj.IsBodyHtml = true;

                for (int i = 0; i < listEmail.Length; i++)
                {
                    if (!string.IsNullOrEmpty(listEmail[i]))
                    {
                        try
                        {
                            string[] row = listEmail[i].Split('^');
                            for (int j = 0; j < row.Length; j++)
                            {
                                mnsj.To.Add(new MailAddress(row[0]));
                            }
                        }
                        catch (Exception ex)
                        {
                            string message = ex.Message;
                        }
                    }
                }

                //mnsj.To.Add(new MailAddress("ingresosocios@inresorts.club"));
                mnsj.From = new MailAddress(credentialAddress, displayName);
                /* Si deseamos Adjuntar algún archivo*/
                mnsj.Body = body;

                server.Send(mnsj);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool SendNotificationEmailCharge(string[] listEmail, string subject, string body, bool isBodyHtml)
        {
            try
            {
                SmtpClient server = new SmtpClient(host, port);
                // Crea el mensaje estableciendo quién lo manda y quién lo recibe
                //Envía el mensaje.
                server.Credentials = new System.Net.NetworkCredential(credentialAddress, credentialClave);
                server.EnableSsl = true;
                //Añade credenciales si el servidor lo requiere.
                MailMessage mnsj = new MailMessage();
                mnsj.Subject = subject;
                mnsj.IsBodyHtml = true;

                for (int i = 0; i < listEmail.Length; i++)
                {
                    if (!string.IsNullOrEmpty(listEmail[i]))
                    {
                        try
                        {
                            string[] row = listEmail[i].Split('|');
                            for (int j = 0; j < row.Length; j++)
                            {
                                mnsj.To.Add(new MailAddress(row[0]));
                            }
                        }
                        catch (Exception ex)
                        {
                            string message = ex.Message;
                        }
                    }
                }

                body = "<html><head><title></title></head><body style='color:black'>";
                body += "<div style='width: 100%'>";
                body += "<img src='http://www.inresorts.club/Views/img/novologo.png' align='left' style='width: 130px; padding-left: 35px'>";
                body += "<img src='http://cieneguillariberadelrio.com/riberadelrio/img/image006.png' align='right' style='width: 130px;padding-right: 55px;padding-top: 15px'>";
                body += "<img style='width: 100%' src='http://www.inresorts.club/Views/img/fondo.png'>";
                //body += "<h1 style='margin-top: 2px ;text-align: center;font-weight: bold;font-style: italic;'>Bienvenido</h1>";
                body += "<h2 style='text-align: center;'>TIENES DEUDAS PENDIENTES</h2>";
                //  body += "<p style='margin-left: 10%;margin-right: 10%; '>En nombre de InResorts y Ribera del Rio es un placer darle la bienvenida, esperando que disfrute con nosotros las mejores experiencias. Ribera del Río Club Resort está abierto a su participación en nuestras diversas actividades, puede consultar en cualquier momento cualquier duda o enviarnos cualquier sugerencia.</p> ";
                //   body += "<p style='margin-left: 10%;margin-right: 10%; '>A continuación, le resumimos un poco la información sobre los beneficios con los que contará por formar parte de la familia de Ribera del Río Club Resort como Socio.</p> </div>";

                /* body += "<div style='width: 100%;text-align: center;'>";
                 body += "<ul style='list-style: none;text-align: center; width: 88px;display: inline-block;'><li> Club 365.</li><li> Noches Hoteleras.</li></ul>";
                 body += "<ul style='list-style: none;text-align: center;  width: 88px;display: inline-block;'><li> Descuentos.</li><li> Viajes.</li></ul>";
                 body += "<ul style='list-style: none;text-align: center;  width: 88px;display: inline-block;'><li> Valorización de Inversión.</li>	<li> Plan de Referencias.</li></ul></div>";

                 body += "<div style='width: 100%'>";
                 body += "<p style='margin-left: 10%;margin-right: 10%; '>Para Ribera del Río Club Resort, es de gran satisfacción contar con clientes tan importantes como usted y su familia que son participes del crecimiento de nuestra empresa, es por eso que, de quedar alguna interrogante al respecto, puede consultar nuestra pagina web www.cieneguillariberadelrio.com o comunicarse al telefono de nuestra oficina central 01 - 4349481 o al correo de socios@cieneguillariberadelrio.com en donde estamos prestos a cualquier inquietud, aclaración o trámites para el uso de su Membresía.</p>";
                 body += "<p style='margin-left: 10%;margin-right: 10%; '>Para realizar cualquier pago relacionado con el contrato adquirido de la Membresía de Ribera del Rio Club Resort, recuerde que esto lo puede hacer mediante su oficina virtual o a travez de nuestras cuentas de recaudo empresarial.Es de resaltar que sus pagos sólo deberá realizarlos a las cuentas que se indican en su contrato, de lo contrario, la compañia No responderá por pagos realizados a cuenta de terceros.</p>";

                 body += "<h3 style='text-align: center;'>Acceso a Oficina Virtual</h3>";
                 body += "<div style='border: 2px solid gray;margin-left: 30%;margin-right: 30%;border-radius: 8px '>";
               //  body += "<center><p> Usuario: <b>" + username + "</b></p><p> Password: <b>" + username + "</b></p></center></div>";*/
                body += "<p style='margin-left: 10%;margin-right: 10%; '>";
                body += "Le invitamos ponerse al dia con el pago de Cuotas </p>";
                body += "<div style='margin-left: 10%;'>";
                body += "<p style=''>Saludos Cordinales</p><p  style=''>...</p> <p  style=''>Equipo Inresorts</p></div>";
                body += "<div style='margin: 5%; width: 70%;background-image: url('https://lh3.googleusercontent.com/NSDQDl8ytJrWSwMe0b3b9DlxubIal-RBEPIWI1a-15f9ynEGQ9eYjTnm-PVqst26f4KJThmjOEPK4lcVoaUw=w1016-h917-rw');'></ div > ";
                body += "<img style='width: 100%' src='https://preview.ibb.co/ixY7iL/fondo222.png'>";
                body += "</div>";


                body += "</body>";
                body += "</html>";



                //mnsj.To.Add(new MailAddress("ingresosocios@inresorts.club"));
                mnsj.From = new MailAddress(credentialAddress, displayName);
                /* Si deseamos Adjuntar algún archivo*/
                mnsj.Body = body;

                server.Send(mnsj);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }


        public bool SendEmailFounder(string email, string subject, string body, bool isBodyHtml, string ruta, string userName)
        {
            try
            {
                using (SmtpClient server = new SmtpClient(host, port))
                {
                    // Crea el mensaje estableciendo quién lo manda y quién lo recibe
                    //Envía el mensaje.
                    server.Credentials = new System.Net.NetworkCredential(credentialAddress, credentialClave);
                    server.EnableSsl = true;
                    //Añade credenciales si el servidor lo requiere.
                    MailMessage mnsj = new MailMessage();
                    mnsj.Subject = subject;
                    mnsj.IsBodyHtml = true;
                    mnsj.To.Add(new MailAddress(email));
                    //mnsj.To.Add(new MailAddress("ingresosocios@inresorts.club"));
                    mnsj.From = new MailAddress(credentialAddress, displayName);
                    /* Si deseamos Adjuntar algún archivo*/
                    mnsj.Body = body;

                    Attachment _attachment = new Attachment(ruta + "CON" + userName + ".pdf");
                    mnsj.Attachments.Add(_attachment);

                    Attachment _attachment6 = new Attachment(ruta + "PLAN_COMPENSACION_INRESORTS" + ".pdf");
                    mnsj.Attachments.Add(_attachment6);

                    Attachment _attachment7 = new Attachment(ruta + "Reglamento_de_Ética_inResorts" + ".pdf");
                    mnsj.Attachments.Add(_attachment7);
                    Attachment _attachment8 =new Attachment(ruta + "Certi" + userName + ".pdf");
                    mnsj.Attachments.Add(_attachment8);

                    Attachment _attachment9 = new Attachment(ruta + "PLAN_DE_BENEFICIOS_INRESORTS" + ".pdf");
                    mnsj.Attachments.Add(_attachment9);

                    server.Send(mnsj);
                }
                return true;
            }
            catch (Exception e)
            {
                
                SendEmail("omarurteaga@gmail.com", "[error inresorts]",e.Message, false);
                return false;
            }
        }
    }
}
