
namespace MULTI_NIVEL.Views
{
    using BussinesRules;
    using Entities;
    using System;
    using System.Web;
    using System.Web.Security;
    using WhatsAppApi;

    public partial class MenuBackend : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void USERS_Click(object sender, EventArgs e)
        {
            Response.Redirect("Users.aspx");
        }
        protected void CODE_Click(object sender, EventArgs e)
        {
            Response.Redirect("Code.aspx");
        }
        protected void COMISSION_Click(object sender, EventArgs e)
        {
            Response.Redirect("Comission.aspx");
        }

        protected void btnViewPaysDefault_Click(object sender, EventArgs e)
        {
            Response.Redirect("PaysDefault.aspx");
        }
        protected void btnTools_Click(object sender, EventArgs e)
        {
            Response.Redirect("UploadTools.aspx");
        }
        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            FormsAuthentication.SignOut();
            HttpContext.Current.Response.Redirect("Index.aspx", true);
        }

        protected void btnSendAlertOfQuotes_Click(object sender, EventArgs e)
        {

            BrNotificationEmail brNotificationEmail = new BrNotificationEmail();

            string[] listEmail = brNotificationEmail.GetListEmail(7).Split('¬');
            SendEmailNotification(listEmail);

            listEmail = brNotificationEmail.GetListEmail(3).Split('¬');
            SendEmailNotification(listEmail);

            listEmail = brNotificationEmail.GetListEmail(1).Split('¬');
            SendEmailNotification(listEmail);

            listEmail = brNotificationEmail.GetListEmail(0).Split('¬');
            SendEmailNotification(listEmail);

            listEmail = brNotificationEmail.GetListEmail(-1).Split('¬');
            SendEmailNotification(listEmail);

            listEmail = brNotificationEmail.GetListEmail(-3).Split('¬');
            SendEmailNotification(listEmail);

            listEmail = brNotificationEmail.GetListEmail(-7).Split('¬');
            SendEmailNotification(listEmail);

            listEmail = brNotificationEmail.GetListEmail(-15).Split('¬');
            SendEmailNotification(listEmail);

            listEmail = brNotificationEmail.GetListEmail(-21).Split('¬');
            SendEmailNotification(listEmail);



            //deuda 2

            listEmail = brNotificationEmail.GetListDeudaEmail(7, 2).Split('$');
            SendEmailNotificationDeuda(listEmail);

            listEmail = brNotificationEmail.GetListDeudaEmail(3, 2).Split('$');
            SendEmailNotificationDeuda(listEmail);

            listEmail = brNotificationEmail.GetListDeudaEmail(1, 2).Split('$');
            SendEmailNotificationDeuda(listEmail);

            listEmail = brNotificationEmail.GetListDeudaEmail(0, 2).Split('$');
            SendEmailNotificationDeuda(listEmail);

            listEmail = brNotificationEmail.GetListDeudaEmail(-1, 2).Split('$');
            SendEmailNotificationDeuda(listEmail);

            listEmail = brNotificationEmail.GetListDeudaEmail(-3, 2).Split('$');
            SendEmailNotificationDeuda(listEmail);

            listEmail = brNotificationEmail.GetListDeudaEmail(-7, 2).Split('$');
            SendEmailNotificationDeuda(listEmail);

            listEmail = brNotificationEmail.GetListDeudaEmail(-15, 2).Split('$');
            SendEmailNotificationDeuda(listEmail);

            listEmail = brNotificationEmail.GetListDeudaEmail(-21, 2).Split('$');
            SendEmailNotificationDeuda(listEmail);


            //deuda 3

            listEmail = brNotificationEmail.GetListDeudaEmail(7, 3).Split('$');
            SendEmailNotificationDeuda(listEmail);

            listEmail = brNotificationEmail.GetListDeudaEmail(3, 3).Split('$');
            SendEmailNotificationDeuda(listEmail);

            listEmail = brNotificationEmail.GetListDeudaEmail(1, 3).Split('$');
            SendEmailNotificationDeuda(listEmail);

            listEmail = brNotificationEmail.GetListDeudaEmail(0, 3).Split('$');
            SendEmailNotificationDeuda(listEmail);

            listEmail = brNotificationEmail.GetListDeudaEmail(-1, 3).Split('$');
            SendEmailNotificationDeuda(listEmail);

            listEmail = brNotificationEmail.GetListDeudaEmail(-3, 3).Split('$');
            SendEmailNotificationDeuda(listEmail);

            listEmail = brNotificationEmail.GetListDeudaEmail(-7, 3).Split('$');
            SendEmailNotificationDeuda(listEmail);

            listEmail = brNotificationEmail.GetListDeudaEmail(-15, 3).Split('$');
            SendEmailNotificationDeuda(listEmail);

            listEmail = brNotificationEmail.GetListDeudaEmail(-21, 3).Split('$');
            SendEmailNotificationDeuda(listEmail);


            pnMessageSucces.Style.Add("Display", "inline");
            lblMessage.Text = "Mensaje enviado a todos los socios con pago pendiente";

        }

        protected void btnNews_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegisterNews.aspx");

        }

        protected void btnCorreos_Click(object sender, EventArgs e)
        {
            Response.Redirect("MailStatus.aspx");
        }

        private bool SendEmailNotificationDeuda(string[] listEmail)
        {
            bool answer = false;
            var emailEmpresa = "cobranza.inresorts@gmail.com";
            for (int i = 0; i < listEmail.Length; i++)
            {
                var rows = listEmail[i].Split('¬');

                string emailUser = "";
                string name = "";
                string lastName = "";
                string detail = "";

                for (int j = 0; j < rows.Length; j++)
                {
                    var row = rows[j].Split('|');
                    if (row.Length > 3)
                    {
                        string description = row[0];
                        string date = row[1];
                        decimal amount = decimal.Parse(row[2]);
                        name = row[3];
                        lastName = row[4];
                        emailUser = row[5];
                        string codecurrency = row[6];

                        decimal amountUsd = decimal.Parse(row[7]);

                        if (codecurrency == "USD")
                        {
                            amount = amountUsd;
                        }

                        if (j == 0)
                        {
                            detail = description + "|" + date + "|" + amount + "|" + codecurrency;
                        }
                        else
                        {
                            detail += "¬" + description + "|" + date + "|" + amount + "|" + codecurrency;
                        }
                    }
                }
                if (detail != "")
                {
                    MyMessages mm = new MyMessages();
                    Email email = new Email();

                    string body = mm.EmailDeuda(detail, name, lastName, "");

                    answer = email.SendEmail(emailUser, "PAGOS PENDIENTES EN INRESORTS", body, true);
                    answer = email.SendEmail(emailEmpresa, "PAGOS PENDIENTES EN INRESORTS", body, true);
                }
            }
            return answer;
        }

        private bool SendEmailNotification(string[] listEmail)
        {
            bool answer = false;
            var emailEmpresa = "cobranza.inresorts@gmail.com";
            string dateCurrent = DateTime.Now.ToString("yyyy-MM-dd");

            for (int i = 0; i < listEmail.Length; i++)
            {
                var row = listEmail[i].Split('|');
                if (row.Length > 3)
                {
                    string description = row[0];
                    string date = row[1];
                    decimal amount = decimal.Parse(row[2]);
                    string name = row[3];
                    string lastName = row[4];
                    string emailUser = row[5];
                    string pin = row[6];
                    string phoneuser = row[7];
                    string currencycode = row[8];
                    decimal amountUsd = decimal.Parse(row[9]);

                    if (currencycode == "USD")
                    {
                        amount = amountUsd;
                    }

                    MyMessages mm = new MyMessages();
                    Email email = new Email();
                    Numalet numalet = new Numalet();
                    MyFunctions mf = new MyFunctions();

                    string body = mm.EmailDebePagar(description, date, amount, name, lastName, numalet.ToCustomCardinal(amount), dateCurrent, pin, currencycode);

                    answer = email.SendEmail(emailUser, "PAGOS EN INRESORTS", body, true);
                    answer = email.SendEmail(emailEmpresa, "PAGOS EN INRESORTS", body, true);

                    string error = "";
                    WhatsApp whatsApp = new WhatsApp("51942953243", "", "INRESORTS", false, false);

                    whatsApp.OnConnectSuccess += () =>
                    {
                        whatsApp.OnLoginSuccess += (phone, data) =>
                        {
                            whatsApp.SendMessage("51969542529", "prueba de envio");
                        };

                        whatsApp.OnLoginFailed += (data) =>
                        {
                            error = data;
                        };
                    };

                    whatsApp.OnConnectFailed += (ex) =>
                    {
                        error = ex.Message;
                    };


                    whatsApp.Connect();

                    string vencio = "vencerá";

                    if (DateTime.Parse(date) < DateTime.Now)
                    {
                        vencio = "venció";
                    }

                    string mess = $"Hola {name} te queremos recordar que el dia {mf.DateFormatClient(date)} {vencio} tu {description} de Monto {amount.ToString()} {currencycode}. Saludos Inresorts";

                    phoneuser = phoneuser.Replace("+", "");

                    string sen = whatsApp.SendMessage(phoneuser, mess);
                    string sen2 = whatsApp.SendMessage("+51938627011", mess);

                    string url = $"<a target='_blank' href='https://api.whatsapp.com/send?phone={phoneuser}&text={mess}'>{name}</a>&nbsp;|&nbsp;";

                    ListMessaggeWhatsapp.Text += url;

                    whatsApp.Disconnect();

                }
            }
            return answer;
        }

    }
}