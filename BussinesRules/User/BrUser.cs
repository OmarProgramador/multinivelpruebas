
namespace BussinesRules.User
{

    using DataAccess.User;
    using Entities;
    using System;
    using System.Data.SqlClient;
    using System.Globalization;
    using System.Threading;

    public class BrUser : brConnection
    {
        public string LoginUser(string user, string pass)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaUser odaUser = new DaUser();
                    answer = odaUser.LoginUser(connection, user, pass);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                    answer = "";
                }
            }
            return answer;
        }

        public string GetPartnerDirect(string userName)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaUser odaUser = new DaUser();
                    answer = odaUser.GetPartnerDirect(connection, userName);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public string GetSponsor(string userName)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaUser odaUser = new DaUser();
                    answer = odaUser.GetSponsor(connection, userName);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public string GetMembershipFirts(string userName)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaUser odaUser = new DaUser();
                    answer = odaUser.GetMembershipFirts(connection, userName);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        /*MERGE*/


        public string GetAccountBank()
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaUser odaUser = new DaUser();
                    answer = odaUser.GetAccountBank(connection);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public string GetCronograma(string codeMembership, string userName)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaUser odaUser = new DaUser();
                    answer = odaUser.GetCronograma(connection, codeMembership, userName);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public string GetCoAfiliateInformation(string userName)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaUser odaUser = new DaUser();
                    answer = odaUser.GetCoAfiliateInformation(connection, userName);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public string GetBankInformation(string data)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaUser odaUser = new DaUser();
                    answer = odaUser.GetBankInformation(connection, data);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public string LoginUserBackend(string data)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaUser odaUser = new DaUser();
                    answer = odaUser.LoginUserBackend(connection, data);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public string getAmountPay(string userName)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaUser odaUser = new DaUser();
                    answer = odaUser.getAmountPay(connection, userName);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }


        public string GetNotifications(string data)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaUser odaUser = new DaUser();
                    answer = odaUser.GetNotifications(connection, data);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }


        public string GetAmountPay(int idAccountTypeMembership)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaUser odaUser = new DaUser();
                    answer = odaUser.GetAmountPay(connection, idAccountTypeMembership);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public string GetPointsQuotePay(string userName)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaUser odaUser = new DaUser();
                    answer = odaUser.GetPointsQuotePay(connection, userName);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                    answer = "";
                }
            }
            return answer;
        }

        public string GetDataPerson(string data)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaUser odaUser = new DaUser();
                    answer = odaUser.GetDataPerson(connection, data);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public string GetUpliners(string data)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaUser odaUser = new DaUser();
                    answer = odaUser.GetUpliners(connection, data);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }


        public string getAmountPay(int idPayDetails, string userName)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaUser odaUser = new DaUser();
                    answer = odaUser.getAmountPay(connection, idPayDetails, userName);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public string getName(string userName)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaUser odaUser = new DaUser();
                    answer = odaUser.getName(connection, userName);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public bool PorVerificar(string idMembership_UserName)
        {
            bool answer = false;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaUser odaUser = new DaUser();
                    answer = odaUser.PorVerificar(connection, idMembership_UserName);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }


        public bool UpdateNotifications(string data)
        {
            bool answer = false;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaUser odaUser = new DaUser();
                    answer = odaUser.UpdateNotifications(connection, data);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }


        public bool PayInitial(string data)
        {
            bool answer = false;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaUser odaUser = new DaUser();
                    //answer = odaUser.PayInitial(connection, data);
                    answer = odaUser.PayInitial(connection, data);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        //TODO: ENVIO DE NOTIFICACIONES PARA USURIOS SIN CONFIRMAR
        public bool NotifRegPendients()
        {
            bool answer = false;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaUser odaUser = new DaUser();

                    //consulta mensajes enviados
                    //var arraLogin = HttpContext.Current.User.Identity.Name.Split('¬');
                    //int isadmin = int.Parse(arraLogin[2]);


                    MyConstants mc = new MyConstants();

                    var hoy = DateTime.Now.ToString(mc.DateFormatBd);
                    //var sociospendientes = odaUser.MailsRegPendients(connection);
                    //obtener 3 fechas de base de datos
                    var fechas = odaUser.NotifDates(connection);
                    var fcdb = fechas.Split('¬');
                    for (int i = 0; i < fcdb.Length; i++)
                    {
                        var datosocio = fcdb[i].Split('|');


                        //var datos = sociospendientes.Split('¬');
                        //var datosocio = datos[i].Split('|');
                        var email = datosocio[0];
                        var name = datosocio[1];
                        var lastName = datosocio[2];
                        var dni = datosocio[3];
                        var quote = datosocio[4];
                        var firstdate = datosocio[5];
                        var seconddate = datosocio[6];
                        var thirddate = datosocio[7];

                        string completename = name.Trim().ToLower() + " " + lastName.Trim().ToLower();
                        completename = ToCapitalize(completename);

                        //BrInformacion brInformacion = new BrInformacion();
                        //string[] arrayData = brInformacion.GetBYIdMembershipDetail(isadmin).Split('|');
                        //envio de mensajes faltantes

                        if (hoy == firstdate)
                        {
                            string subjet = "", messagge = "";
                            //string[] sepName = name.Split(' ');
                            //var fName = ToCapitalize(sepName[0]);
                            //var bienvenido = "Bienvenido";
                            //if (gender == "F")
                            //{
                            //    bienvenido = "Bienvenida";
                            //}
                            subjet = "[RIBERA DEL RIO - ALERTA DE REGISTRO]";
                            messagge = "<html><head><title></title></head><body style='color:black;'>";
                            messagge = "<body><div style='font-family:sans-serif;display:block;padding:20px;margin:10px auto;width:700px;height:100%;background-color:white;'>";
                            messagge += "<div style=' justify-content:space-between;text-align:center;'>";
                            messagge += "<div style='display:flex;'>";
                            messagge += "<div style='width:50%;'>";
                            messagge += " <img src='http://www.inresorts.club/Views/img/novologo.png' align='left' style='width: 98px;'>";
                            messagge += "</div>";
                            messagge += "<div style='width:50%;'>";
                            messagge += "<img src='http://cieneguillariberadelrio.com/riberadelrio/img/image006.png' align='right' style='width: 120px;padding-top: 7px;'>";
                            messagge += "</div>";
                            messagge += "</div>";
                            messagge += "<img style='width: 100%' src='http://www.inresorts.club/Views/img/fondo.png'>";
                            messagge += "</div>";
                            messagge += "";


                            messagge += "<div style='display:block;margin: 10px auto;text-align:center;'>";
                            messagge += "<h2><b>VALLE ENCANTADO S.A.C</b></h2> <h2><b>RUC 20601460271</b></h2>";
                            messagge += "</div><br>";
                            messagge += "<div>Estimado cliente " + name.ToUpper() + " " + lastName.ToUpper() + "</div><br><br>";
                            messagge += "<div>Por medio de la presente queremos recordarle que se encuentra pendiente el pago de su registro.";

                            messagge += "<br> <p style='margin-left: 10%;margin-right: 10%;text-align: center; '><b>Monto a pagar</b></p> ";
                            messagge += "<p style='margin-left: 10%;margin-right: 10%;text-align: center;'>S/." + quote.ToString() + "</p>";
                            messagge += "</div><div> <p style='margin-left: 10%;margin-right: 10%;text-align: center; '><b>Cuenta corriente:</b></p>";
                            messagge += "<p style='margin-left: 10%;margin-right: 10%;text-align: center;'>N° 191-2606708-0-82</p>";
                            messagge += "<p style='margin-left: 10%;margin-right: 10%; text-align: center;'>Banco de Credito del Perú.(BCP)</p>";
                            messagge += "<div>Recuerde que el pago lo puede realizar mediante deposito en nuestra cuenta corriente a travéz de Agente BCP, Agencia BCP O transferencia bancaria desde Banca por Internet.</div>";
                            messagge += "<center><p style='margin-left: 10%;margin-right: 10%;text-align: center;'>Cuando lo tenga listo, solo tienes que subirlo a nuestra página y enseguida lo estaremos validando</p></center>";
                            messagge += "<center><div style='width: 100%'>";
                            messagge += "<p style='margin-left: 10%;margin-right: 10%;'>Clic en el botón para validar el pago.</p>";
                            messagge += "<a style='text-decoration: none;' href='https://inresorts.club'>";
                            messagge += "<center><div style='background: #0d80ea;border-radius:10px;width: 158px;height: 30px;font-size: 16px;color: white;font-weight: bold;padding: 4px;padding-top: 10px;cursor: pointer;text-align: center;margin: 23px;'>Validar pago<div></center>";
                            messagge += "</a></div></center>";
                            messagge += "</div>";

                            messagge += "<br>";
                            messagge += "<br>";
                            messagge += "<div style='margin-left: 9%;'>";
                            messagge += "<p style='margin:5px'>Saludos Cordiales</p><p  style='margin:5px'>Equipo inResorts</p></div>";
                            messagge += "<div style='margin: 5%; width: 70%;background-image: url('https://lh3.googleusercontent.com/NSDQDl8ytJrWSwMe0b3b9DlxubIal-RBEPIWI1a-15f9ynEGQ9eYjTnm-PVqst26f4KJThmjOEPK4lcVoaUw=w1016-h917-rw');'></ div > ";
                            messagge += "<img style='width: 100%' src='https://preview.ibb.co/ixY7iL/fondo222.png'>";
                            messagge += "</div></body></html>";

                            Email oemail = new Email();
                            oemail.SubmitEmailNotFiles3(email, subjet, messagge, true);
                        }
                        if (hoy == seconddate)
                        {
                            string subjet = "", messagge = "";
                            //string[] sepName = name.Split(' ');
                            //var fName = ToCapitalize(sepName[0]);
                            //var bienvenido = "Bienvenido";
                            //if (gender == "F")
                            //{
                            //    bienvenido = "Bienvenida";
                            //}
                            subjet = "[RIBERA DEL RIO - ALERTA DE REGISTRO]";
                            messagge = "<html><head><title></title></head><body style='color:black'>";
                            messagge = "<body><div style='font-family:sans-serif;display:block;padding:20px;margin:10px auto;width:700px;height:100%;background-color:white;'>";
                            messagge += "<div style=' justify-content:space-between;text-align:center;'>";
                            messagge += "<div style='display:flex;'>";
                            messagge += "<div style='width:50%;'>";
                            messagge += " <img src='http://www.inresorts.club/Views/img/novologo.png' align='left' style='width: 98px;'>";
                            messagge += "</div>";
                            messagge += "<div style='width:50%;'>";
                            messagge += "<img src='http://cieneguillariberadelrio.com/riberadelrio/img/image006.png' align='right' style='width: 120px;padding-top: 7px;'>";
                            messagge += "</div>";
                            messagge += "</div>";
                            messagge += "<img style='width: 100%' src='http://www.inresorts.club/Views/img/fondo.png'>";
                            messagge += "</div>";
                            messagge += "";


                            messagge += "<div style='display:block;margin: 10px auto;text-align:center;'>";
                            messagge += "<h2><b>VALLE ENCANTADO S.A.C</b></h2> <h2><b>RUC 20601460271</b></h2>";
                            messagge += "</div><br>";
                            messagge += "<div>Estimado cliente " + name.ToUpper() + " " + lastName.ToUpper() + "</div><br><br>";
                            messagge += "<div>Por medio de la presente queremos recordarle que se encuentra pendiente el pago de su registro.";

                            messagge += "<br> <p style='margin-left: 10%;margin-right: 10%;text-align: center; '><b>Monto a pagar</b></p> ";
                            messagge += "<p style='margin-left: 10%;margin-right: 10%;text-align: center;'>S/." + quote.ToString() + "</p>";
                            messagge += "</div><div> <p style='margin-left: 10%;margin-right: 10%;text-align: center; '><b>Cuenta corriente:</b></p>";
                            messagge += "<p style='margin-left: 10%;margin-right: 10%;text-align: center;'>N° 191-2606708-0-82</p>";
                            messagge += "<p style='margin-left: 10%;margin-right: 10%; text-align: center;'>Banco de Credito del Perú.(BCP)</p>";
                            messagge += "<div>Recuerde que el pago lo puede realizar mediante deposito en nuestra cuenta corriente a travéz de Agente BCP, Agencia BCP O transferencia bancaria desde Banca por Internet.</div>";
                            messagge += "<center><p style='margin-left: 10%;margin-right: 10%;text-align: center;'>Cuando lo tenga listo, solo tienes que subirlo a nuestra página y enseguida lo estaremos validando</p></center>";
                            messagge += "<center><div style='width: 100%'>";
                            messagge += "<p style='margin-left: 10%;margin-right: 10%;'>Clic en el botón para validar el pago.</p>";
                            messagge += "<a style='text-decoration: none;' href='https://inresorts.club'>";
                            messagge += "<center><div style='background: #0d80ea;border-radius:10px;width: 158px;height: 30px;font-size: 16px;color: white;font-weight: bold;padding: 4px;padding-top: 10px;cursor: pointer;text-align: center;margin: 23px;'>Validar pago<div></center>";
                            messagge += "</a></div></center>";
                            messagge += "</div>";

                            messagge += "<br>";
                            messagge += "<br>";
                            messagge += "<div style='margin-left: 9%;'>";
                            messagge += "<p style='margin:5px'>Saludos Cordiales</p><p  style='margin:5px'>Equipo inResorts</p></div>";
                            messagge += "<div style='margin: 5%; width: 70%;background-image: url('https://lh3.googleusercontent.com/NSDQDl8ytJrWSwMe0b3b9DlxubIal-RBEPIWI1a-15f9ynEGQ9eYjTnm-PVqst26f4KJThmjOEPK4lcVoaUw=w1016-h917-rw');'></ div > ";
                            messagge += "<img style='width: 100%' src='https://preview.ibb.co/ixY7iL/fondo222.png'>";
                            messagge += "</div></body></html>";

                            Email oemail = new Email();
                            oemail.SubmitEmailNotFiles3(email, subjet, messagge, true);
                        }
                        if (hoy == thirddate)
                        {
                            string subjet = "", messagge = "";
                            subjet = "[RIBERA DEL RIO - ALERTA DE REGISTRO]";
                            messagge = "<html><head><title></title></head><body style='color:black'>";
                            messagge = "<body><div style='font-family:sans-serif;display:block;padding:20px;margin:10px auto;width:700px;height:100%;background-color:white;'>";
                            messagge += "<div style=' justify-content:space-between;text-align:center;'>";
                            messagge += "<div style='display:flex;'>";
                            messagge += "<div style='width:50%;'>";
                            messagge += " <img src='http://www.inresorts.club/Views/img/novologo.png' align='left' style='width: 98px;'>";
                            messagge += "</div>";
                            messagge += "<div style='width:50%;'>";
                            messagge += "<img src='http://cieneguillariberadelrio.com/riberadelrio/img/image006.png' align='right' style='width: 120px;padding-top: 7px;'>";
                            messagge += "</div>";
                            messagge += "</div>";
                            messagge += "<img style='width: 100%' src='http://www.inresorts.club/Views/img/fondo.png'>";
                            messagge += "</div>";
                            messagge += "";


                            messagge += "<div style='display:block;margin: 10px auto;text-align:center;'>";
                            messagge += "<h2><b>VALLE ENCANTADO S.A.C</b></h2> <h2><b>RUC 20601460271</b></h2>";
                            messagge += "</div><br>";
                            messagge += "<div>Estimado cliente " + name.ToUpper() + " " + lastName.ToUpper() + "</div><br><br>";
                            messagge += "<div>Por medio de la presente queremos recordarle que se encuentra pendiente el pago de su registro.";

                            messagge += "<br> <p style='margin-left: 10%;margin-right: 10%;text-align: center; '><b>Monto a pagar</b></p> ";
                            messagge += "<p style='margin-left: 10%;margin-right: 10%;text-align: center;'>S/." + quote.ToString() + "</p>";
                            messagge += "</div><div> <p style='margin-left: 10%;margin-right: 10%;text-align: center; '><b>Cuenta corriente:</b></p>";
                            messagge += "<p style='margin-left: 10%;margin-right: 10%;text-align: center;'>N° 191-2606708-0-82</p>";
                            messagge += "<p style='margin-left: 10%;margin-right: 10%; text-align: center;'>Banco de Credito del Perú.(BCP)</p>";
                            messagge += "<div>Recuerde que el pago lo puede realizar mediante deposito en nuestra cuenta corriente a travéz de Agente BCP, Agencia BCP O transferencia bancaria desde Banca por Internet.</div>";
                            messagge += "<center><p style='margin-left: 10%;margin-right: 10%;text-align: center;'>Cuando lo tenga listo, solo tienes que subirlo a nuestra página y enseguida lo estaremos validando</p></center>";
                            messagge += "<center><div style='width: 100%'>";
                            messagge += "<p style='margin-left: 10%;margin-right: 10%;'>Clic en el botón para validar el pago.</p>";
                            messagge += "<a style='text-decoration: none;' href='https://inresorts.club'>";
                            messagge += "<center><div style='background: #0d80ea;border-radius:10px;width: 158px;height: 30px;font-size: 16px;color: white;font-weight: bold;padding: 4px;padding-top: 10px;cursor: pointer;text-align: center;margin: 23px;'>Validar pago<div></center>";
                            messagge += "</a></div></center>";
                            messagge += "</div>";

                            messagge += "<br>";
                            messagge += "<br>";
                            messagge += "<div style='margin-left: 9%;'>";
                            messagge += "<p style='margin:5px'>Saludos Cordiales</p><p  style='margin:5px'>Equipo inResorts</p></div>";
                            messagge += "<div style='margin: 5%; width: 70%;background-image: url('https://lh3.googleusercontent.com/NSDQDl8ytJrWSwMe0b3b9DlxubIal-RBEPIWI1a-15f9ynEGQ9eYjTnm-PVqst26f4KJThmjOEPK4lcVoaUw=w1016-h917-rw');'></ div > ";
                            messagge += "<img style='width: 100%' src='https://preview.ibb.co/ixY7iL/fondo222.png'>";
                            messagge += "</div></body></html>";

                            Email oemail = new Email();
                            oemail.SubmitEmailNotFiles3(email, subjet, messagge, true);
                        }
                    }



                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        private string ToCapitalize(string _text)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;

            return textInfo.ToTitleCase(_text);
        }

        public bool AlertRegister(string data)
        {
            bool answer = false;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaUser odaUser = new DaUser();
                    answer = odaUser.AlertRegister(connection, data);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }


        public Int32 RegisterNmembership(string data, string amountFinanced, int isPredetermined, string codeCurrency)
        {
            Int32 answer = 0;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaUser odaUser = new DaUser();
                    answer = odaUser.RegisterNmembership(connection, data, amountFinanced, isPredetermined, codeCurrency);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }



        public bool RegisterRange(string data, string data2)
        {
            bool answer = false;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaUser odaUser = new DaUser();
                    answer = odaUser.RegisterRange(connection, data, data2);// revisa que hace NMembership pq tenia ese metodo
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public string GetLineActives(string userName)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaUser odaUser = new DaUser();
                    answer = odaUser.GetLineActives(connection, userName);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public bool RegisterService(string data)
        {
            bool answer = false;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaUser odaUser = new DaUser();
                    answer = odaUser.RegisterService(connection, data);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public bool RegisterTraveler(string data)
        {
            bool answer = false;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaUser odaUser = new DaUser();
                    answer = odaUser.RegisterTraveler(connection, data);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public bool RegisterNews(string data)
        {
            bool answer = false;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaUser odaUser = new DaUser();
                    answer = odaUser.RegisterNews(connection, data);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }
        public string GetNews()
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaUser odaUser = new DaUser();
                    answer = odaUser.getNews(connection);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }
        public int GetNewsCount()
        {
            int answer = 0;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaUser odaUser = new DaUser();
                    answer = odaUser.getNewsCount(connection);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }
        public int GetCountAccountNews(string data)
        {
            int answer = 0;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaUser odaUser = new DaUser();
                    answer = odaUser.GetCountAccountNews(connection, data);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }
        public bool RegNewsCount(string data)
        {
            bool answer = false;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaUser odaUser = new DaUser();
                    answer = odaUser.RegNewsCount(connection, data);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public string GetIdPerson(string userName)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaUser odaUser = new DaUser();
                    answer = odaUser.GetIdPerson(connection, userName);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                    answer = "0";
                }
            }
            return answer;
        }

        public bool IsTeamCompleted(int idPerson)
        {
            bool answer = false;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaUser odaUser = new DaUser();
                    answer = odaUser.IsTeamCompleted(connection, idPerson);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                    answer = true;
                }
            }
            return answer;
        }

        public bool IsHelpTeam(int idPerson)
        {
            bool answer = false;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaUser odaUser = new DaUser();
                    answer = odaUser.IsHelpTeam(connection, idPerson);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                    answer = true;
                }
            }
            return answer;
        }

        public bool UpdateAccountNewsCount(string data)
        {
            bool answer = false;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaUser odaUser = new DaUser();
                    answer = odaUser.UpdateAccountNewsCount(connection, data);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }



        public bool DisabledAccount(int data)
        {
            bool answer = false;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaUser odaUser = new DaUser();
                    answer = odaUser.DisabledAccount(connection, data);// revisa que hace NMembership pq tenia ese metodo
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }




        public bool ActivateAccount(string data)
        {
            bool answer = false;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaUser odaUser = new DaUser();
                    answer = odaUser.ActivateAccount(connection, data);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }


        public bool NotAvailableUser(string data)
        {
            bool answer = false;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaUser odaUser = new DaUser();
                    answer = odaUser.NotAvailableUser(connection, data);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public string getSons(string userName)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaUser odaUser = new DaUser();
                    answer = odaUser.getSons(connection, userName);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public string GetAccountStatus(string data)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaUser odaUser = new DaUser();
                    answer = odaUser.GetAccountStatus(connection, data);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public string GetDateUpgrade(int idN_MemberUpgrate)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaUser odaUser = new DaUser();
                    answer = odaUser.GetDateUpgrade(connection, idN_MemberUpgrate);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public string GetEmails()
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaUser odaUser = new DaUser();
                    answer = odaUser.GetEmails(connection);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }
        public string GetMembershipType(string data)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaUser odaUser = new DaUser();
                    answer = odaUser.GetMembershipType(connection, data);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public string GetCountsAsociate()
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaUser odaUser = new DaUser();
                    answer = odaUser.GetCountsAsociate(connection);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public string PossibleUser(string data)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaUser odaUser = new DaUser();
                    answer = odaUser.PossibleUser(connection, data);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }
        /*  public string getPersons()
          {
              string answer = "";
              using (SqlConnection connection = new SqlConnection(ConnectionString))
              {
                  try
                  {
                      connection.Open();
                      DaUser odaUser = new DaUser();
                      answer = odaUser.getPersons(connection);
                      connection.Close();
                  }
                  catch (Exception e)
                  {
                      RecordLog(e.Message, e.StackTrace);
                  }
              }
              return answer;
          }*/
        public string commissionsVerification(string idPerson)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaUser odaUser = new DaUser();
                    answer = odaUser.commissionsVerification(connection, idPerson);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public bool enableAcount(int idMembershipDetail, string nameTicket)
        {
            bool answer = false;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaUser odaUser = new DaUser();
                    answer = odaUser.enableAcount(connection, idMembershipDetail, nameTicket);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public string GetNafiliate(int idMembershipDetail)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaUser odaUser = new DaUser();
                    answer = odaUser.GetNafiliate(connection, idMembershipDetail);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                    answer = "0";
                }
            }
            return answer;
        }

        public string RegisterUser(string data, string data2)
        {
            string answer = "";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaUser odaUser = new DaUser();
                    answer = odaUser.RegisterUser(connection, data, data2);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public string GenerateAccount(string data)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaUser odaUser = new DaUser();
                    answer = odaUser.GenerateAccount(connection, data);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public bool PutBankInformation(string data)
        {
            bool answer = false;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaUser odaUser = new DaUser();
                    answer = odaUser.PutBankInformation(connection, data);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public bool UpdateUserDataAccount(string data)
        {
            bool answer = false;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaUser odaUser = new DaUser();
                    answer = odaUser.UpdateUserDataAccount(connection, data);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public bool UpdateNews(string data)
        {
            bool answer = false;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaUser odaUser = new DaUser();
                    answer = odaUser.UpdateNews(connection, data);
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public bool DeleteNews(string data)
        {
            bool answer = false;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaUser odaUser = new DaUser();
                    answer = odaUser.DeleteNews(connection, data);
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }


        public bool UpdateDataPerson(string data)
        {
            bool answer = false;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaUser odaUser = new DaUser();
                    answer = odaUser.UpdateDataPerson(connection, data);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }
        public bool UpdateDataAccountBanck(string data)
        {
            bool answer = false;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaUser odaUser = new DaUser();
                    answer = odaUser.UpdateDataAccountBanck(connection, data);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public string VerificarExiste(string numberDocumentVa)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaUser odaUser = new DaUser();
                    answer = odaUser.VerificarExiste(connection, numberDocumentVa);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public bool EnableAcountPromoter(int idMemberDetails, string ticketImg)
        {
            bool answer = false;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaUser odaUser = new DaUser();
                    answer = odaUser.EnableAcountPromoter(connection, idMemberDetails, ticketImg);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public string getPartner(string userName)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaUser odaUser = new DaUser();
                    answer = odaUser.getPartner(connection, userName);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }


        public string GetShopping(string userName)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaUser odaUser = new DaUser();
                    answer = odaUser.getShopping(connection, userName);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public string GetTravelers(string userName)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaUser odaUser = new DaUser();
                    answer = odaUser.getTravelers(connection, userName);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public bool PutRegisterkIT(string data, Int32 data2)
        {
            bool answer = false;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaUser odaUser = new DaUser();
                    answer = odaUser.PutRegisterkIT(connection, data, data2);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public bool UpdateInitialQuoteDescription(string data)
        {
            bool answer = false;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaUser odaUser = new DaUser();
                    answer = odaUser.UpdateInitialQuoteDescription(connection, data);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public string getPersons()
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaUser odaUser = new DaUser();
                    answer = odaUser.getPersons(connection);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public string getDoc(string data)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaUser odaUser = new DaUser();
                    answer = odaUser.getDoc(connection, data);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public string GetPersonalInformation(string userName)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaUser odaUser = new DaUser();
                    answer = odaUser.GetPersonalInformation(connection, userName);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public string GetAditionalInformation(string userName)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaUser odaUser = new DaUser();
                    answer = odaUser.GetAditionalInformation(connection, userName);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public bool PutPersonalInformation(string data)
        {
            bool answer = false;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaUser odaUser = new DaUser();
                    answer = odaUser.PutPersonalInformation(connection, data);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public string GetRange(string userName)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaUser odaUser = new DaUser();
                    answer = odaUser.GetRange(connection, userName);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }
        public string GetName(string dni)
        {
            string answer = "";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaUser odaUser = new DaUser();
                    answer = odaUser.GetName(connection, dni);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }
        public int ExistAccountLink(string data)
        {
            int answer = 0;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaUser odaUser = new DaUser();
                    answer = odaUser.ExistAccountLink(connection, data);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public bool GetNotPayInitial(string dateinitial, string newUserName, int ansNmembershi)
        {
            bool answer = false;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaUser odaUser = new DaUser();
                    answer = odaUser.GetNotPayInitial(connection, dateinitial, newUserName, ansNmembershi);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }

        public bool BiPayQuote(int idMemberDetails, string imgTicket, decimal amountWallet, decimal amountOthers, string method, string method2, int statusPay, decimal typeChangeSend)
        {
            bool answer = false;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    DaUser odaUser = new DaUser();
                    answer = odaUser.BiPayQuote(connection, idMemberDetails, imgTicket, amountWallet, amountOthers, method, method2, statusPay, typeChangeSend);
                    connection.Close();
                }
                catch (Exception e)
                {
                    RecordLog(e.Message, e.StackTrace);
                }
            }
            return answer;
        }
    }
}
