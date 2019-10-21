using BussinesRules;
using BussinesRules.TypeMembership;
using BussinesRules.User;
using Entities;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.IO;
using System.Web;

namespace MULTI_NIVEL.Views
{
    public partial class AddMembCulquiC : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    string quotesPendiente = "";
                    string namePeson = "";
                    string token = "", emailNewUser = "", userName = "", codeMembers = "";
                    int numberQuotes = 0, idMemberDetails = 0;
                    double amountPay = 0;
                    string currencyCode = string.Empty;

                    BrUser brUser = new BrUser();
                    BrPayments brPayments = new BrPayments();
                    BrTypeMembership brTypeMemb = new BrTypeMembership();

                    string[] dataLogin = HttpContext.Current.User.Identity.Name.Split('¬');
                    userName = dataLogin[1];

                    token = Request["tokenid"].ToString();
                    numberQuotes = int.Parse(Request["ddlQuote"].ToString());
                    currencyCode = Request["ddlcurrencyCode"].ToString();



                    if (numberQuotes < 0 || numberQuotes > 32)
                    {
                        Response.Write("false¬" + "Numero de Cuotas No Valido");
                        return;
                    }

                    codeMembers = Session["carrito"].ToString().Split('|')[6];

                    string dataBdd = Session["datos"].ToString();
                    string[] arraycontacto = dataBdd.Split('$')[3].Split('|');
                    string[] arrayperson = dataBdd.Split('$')[0].Split('|');

                    //correo = arraycontacto[0];
                    namePeson = arrayperson[0] + " " + arrayperson[1];

                    string[] acarrito = Session["carrito"].ToString().Split('|');
                    string TypeMembership = acarrito[6];

                    string cronograma = Session["cronograma"].ToString();
                    //string respData = brPayments.PersonGetData(userName);
                    string respData = "";
                    respData = respData + '^' + cronograma;

                    double amountFinanciade = 0;
                    string cronogramaYa = Session["cronogramaYa"].ToString();



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
                            amountFinanciade = double.Parse(fila[2].Replace("S/.", ""));
                            break;
                        }
                        else
                        {
                            cronoActiv += DateTime.Parse(fila[1]).ToString("yyyy-MM-dd") + "¬";
                        }
                    }
                    string codeCurrency = Session["TypeCurrency"].ToString();

                    int ansNmembershi = brUser.RegisterNmembership(TypeMembership + '|' + userName, amountFinanciade.ToString(), Int32.Parse(Session["membPred"].ToString()), codeCurrency);
                    bool isRegister = false;
                    string exchange = Session["carrito"].ToString().Split('|')[4];

                    var typeChange = double.Parse(exchange);

                    if (Session["codeUpgrate"] != null)
                    {
                        //si es upgrate

                        isRegister = brPayments.GetCalculatePaymentScheduleUpgrate(respData, userName, ansNmembershi, exchange, 1);
                        if (!isRegister)
                        {
                            Response.Write("false¬Ha Ocurrido Un Error al Intentar Registrar el Cronograma de Pagos del Usuario");
                            return;
                        }

                        if (Session["dateup"] != null)
                        {
                            string dateup = Session["dateup"].ToString();
                            bool an = brPayments.PutDateUpgrate(ansNmembershi, dateup);
                        }

                        //registramos si upgrate para 
                    }
                    else
                    {
                        //si no es upgrate

                        isRegister = brPayments.GetCalculatePaymentSchedule(respData, userName, ansNmembershi, exchange, 1);
                        if (!isRegister)
                        {
                            Response.Write("false¬Ha Ocurrido Un Error al Intentar Registrar el Cronograma de Pagos del Usuario");
                            return;
                        }
                        //cronograma de activacion
                        BrActivation brActivation = new BrActivation();
                        bool registerActi = brActivation.PutCronograma(cronoActiv, userName, ansNmembershi);
                    }

                    if (Session["codeUpgrate"] != null)
                    {
                        //el id de account n membership del upgrate ¬ y el nuevo 
                        int codeUpgrate = int.Parse(Session["codeUpgrate"].ToString());
                        bool upgrate = brTypeMemb.CancelMembershipUpgrate(codeUpgrate, ansNmembershi);
                        if (!upgrate)
                        {
                            Response.Write("false¬Ha Ocurrido Un Error al Intentar Registrar el Cronograma de Pagos del Usuario");
                            return;
                        }
                        BrActivation brActivation = new BrActivation();
                        string fechaAnterior = Session["fechaanterior"].ToString();
                        bool registerActi = brActivation.PutCronogramaUpgrade(fechaAnterior, userName, ansNmembershi, codeUpgrate);


                    }

                    //validamos si tiene consumo
                    if (!isRegister)
                    {
                        Response.Write("false¬Ha Ocurrido Un Error al Intentar Registrar el Cronograma de Pagos del Usuario");
                        return;
                    }

                    string[] username_idmen_amount_email = brUser.GetAmountPay(ansNmembershi).Split('|');

                    if (username_idmen_amount_email.Length < 4)
                    {
                        Response.Write("false¬Ha Ocurrido Un Error al Intentar Obtener el monto a Pagar");
                        return;
                    }
                    idMemberDetails = int.Parse(username_idmen_amount_email[1]);
                    amountPay = double.Parse(username_idmen_amount_email[2]);
                    emailNewUser = username_idmen_amount_email[3];

                    username_idmen_amount_email = null;
                    brPayments = null;
                    brUser = null;

                    if (idMemberDetails <= 0 || amountPay <= 0)
                    {
                        Response.Write("false¬Ha Ocurrido Un Error al Intentar Registrar al Usuario");
                        return;
                    }

                    if (currencyCode == "USD")
                    {
                        amountPay = amountPay / typeChange;
                    }

                    PayCulqi payCulqi = new PayCulqi();
                    string[] culqiAnwser = payCulqi.newPayment(userName, emailNewUser, amountPay, token, numberQuotes, currencyCode).Split('¬');
                    if (culqiAnwser[0] == "false")
                    {
                        Response.Write("false¬" + culqiAnwser[1]);
                        return;
                    }
                    //marcar como pagado en la tabla membershipdetails
                    BrMembershipPayDetail brMembershipPayDetail = new BrMembershipPayDetail();

                    if (Session["codeUpgrate"] != null)
                    {
                        bool habiliAccount = brMembershipPayDetail.UpgrateStatusPaymentInitial(ansNmembershi, 1, "");

                        //enviar el email de confirmacion con la data y lo redirecciona al post register
                        if (!habiliAccount)
                        {
                            Response.Write("false¬Ha Ocurrido un Error al Intentar Habilitar Su Cuenta.");
                            return;
                        }
                    }
                    else
                    {
                        var dateCurrent = DateTime.Now.ToString("yyyy-MM-dd").Split('-'); ;

                        string tranferId = culqiAnwser[2] == null ? "" : culqiAnwser[2];
                        string numReceipt = "0";
                        string date = dateCurrent[2] + " de " + GetMonth(dateCurrent[1]) + " del " + dateCurrent[0];
                        string nAffiliate = "";

                        string hour = DateTime.Now.ToString("HH:mm:ss");
                        string detalle = amountPay.ToString();


                        //cvbc
                        string nameTicket = GetRecibo(tranferId, userName, numReceipt, date, nAffiliate, TypeMembership, namePeson, hour, detalle, quotesPendiente);


                        bool habiliAccount = brMembershipPayDetail.UpgrateStatusPaymentInitial(ansNmembershi, 0, nameTicket);

                        //enviar el email de confirmacion con la data y lo redirecciona al post register
                        if (!habiliAccount)
                        {
                            Response.Write("false¬Ha Ocurrido un Error al Intentar Habilitar Su Cuenta.");
                            return;
                        }
                    }

                    Email oEmail = new Email();
                    bool awnserEmail = oEmail.SubmitEmail(emailNewUser, "[RIBERA DEL RIO - PAGO]", "Ud. Ha efectuado su pago en Ribera del Rio con Exito.");
                    if (!awnserEmail)
                    {
                        Response.Write("false¬" + culqiAnwser[1] + "\n" + "Ocurrio un Error al intentar enviar un Email de conformidad con su compra");
                        return;
                    }
                    //ejecutamos el core para los puntos de equipo
                    //BrCore_Automation brCore_Automation = new BrCore_Automation();
                    // bool isCoreRegister = brCore_Automation.ExecuteCore();
                    var urlRedire = string.Empty;

                    var codeMemb = TypeMembership.Trim();

                    if (codeMemb == "EXP" || codeMemb == "LHT" || codeMemb == "STD" ||
                                codeMemb == "PLUS" || codeMemb == "TOP" || codeMemb == "VIT")
                    {
                        urlRedire = "EndPayments";
                    }
                    if (codeMemb == "EVOL" || codeMemb == "MVC")
                    {
                        urlRedire = "EndPaymentQuote";
                    }
                    if (codeMemb == "SBY")
                    {
                        urlRedire = "EndPaymentSby";
                    }

                    Response.Write($"true¬{urlRedire}.aspx");
                    return;
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("error.aspx?error=" + ex.Message, true);
            }
        }


        public string GetRecibo(string tranferId,
                                string username,
                                string numReceipt,
                                string date,
                                string nAffiliate,
                                string typeMembresia,
                                string namePeson,
                                string hour,
                                string detalle,
                                string quotesPendiente)
        {
            string fechaVar = DateTime.Now.ToString("yyyyMMddHHmmss");
            string nameTicket = username + "_" + tranferId + fechaVar;
            string dni = username.Substring(2, (username.Length - 2));
            using (Document document = new Document(PageSize.A4, 10, 10, 10, 10))
            {
                string rutaImg = HttpContext.Current.Server.MapPath("~/Resources/Images/");
                string ruta = HttpContext.Current.Server.MapPath("~/Resources/RecibosRegister/") + nameTicket + ".pdf";
                FileStream stream = new FileStream(ruta, FileMode.Create);
                PdfWriter.GetInstance(document, stream);
                document.Open();


                string cadenfinal = string.Empty;
                cadenfinal += "<!DOCTYPE html ><html><head><title></title></head><body>";
                cadenfinal += "<div style='font-family: sans-serif;display: block;padding:20px;margin:10px auto;width:700px;height: 700px;background-color: white;'>";
                //cadenfinal += "<img src='" + rutaImg + "rec.png' style='position: absolute;top: 24%;left:28%;opacity: 0.1;z-index:1;width:515px;'/>";
                //cadenfinal += "<div style='display:flex;justify-content:space-between;text-align:center;' >";
                //cadenfinal += "<img src='" + rutaImg + "rec.png'/>";
                //cadenfinal += "<div><div style='font-size: 24px' ><b> RECIBO </b> Nro. 002044 </div><label> 20 de marzo del 2019 </label></div></div>";

                cadenfinal += "<div style='display:block;margin:10px auto;text-align: center;' ><h2><b> VALLE ENCANTADO S.A.C </b></h2>";
                cadenfinal += "<h4><b> RUC 20601460271 </b></h4></div><div style='display: flex;justify-content: space-between;'>";
                //cadenfinal += "<div style='display:block' ><div style='margin:5px 0'><b> Nro. MEMBRESIA:</b> AR00101 </div>";
                cadenfinal += "<div style='display:block' ><div style='margin:5px 0'><b> Codigo:</b> " + username + " </div>";
                cadenfinal += "<label><b> Nombre: </b> " + namePeson.ToUpper() + "</label></div><div><div><b> Codido Membresia: </b>" + typeMembresia + "</div>";
                cadenfinal += "<label><b> DNI: </b> " + dni + " </label></div></div><div style = 'margin:15px auto;'><label><B> Codigo de operacion: </B> " + tranferId + " </label>";
                cadenfinal += "</div>";
                cadenfinal += "<div style='margin: 15px auto' ><b> Fecha: </b>" + date + " HORA: " + hour + " </div>";
                cadenfinal += "<div style='margin: 15px auto' ><b> Concepto: </b> Inicial 1 </div>";
                cadenfinal += "<div style='margin: 15px auto' ><b> Monto: </b>" + detalle + " </div>";
                cadenfinal += "<div style='margin: 15px auto' ><b> Cuotas pendientes: </b>" + quotesPendiente + " </div>";
                cadenfinal += "<center><img src='" + rutaImg + "rec.png' style='position: absolute;top: 24%;left:28%;opacity: 0.1;z-index:1;width:515px;'></center>";

                //cadenfinal += "<div style='border:1px solid grey;display: flex;justify-content: space-around;' ><div style='border:2px solid grey;width: 25%;text-align: center;'>";
                //cadenfinal += "<div style='border-bottom: 2px solid grey;font-weight: bold; background-color: #d6d6d6'> CONCEPTO </div>";
                //cadenfinal += "<label> CUOTA 1°</label></div><div style = 'border:2px solid grey;width:25%;text-align: center;'>";
                //cadenfinal += "<div style='border-bottom: 2px solid grey;font-weight: bold; background-color: #d6d6d6'> MONTO </div>";
                //cadenfinal += "<label> 2437.00 </label></div><div style = 'border:2px solid grey;width: 25%;text-align: center;'>";
                //cadenfinal += "<div style='border-bottom: 2px solid grey;font-weight: bold; background-color: #d6d6d6'> INTERÉS </div>";
                //cadenfinal += "<label> 00.00 </label></div><div style = 'border:2px solid grey;width: 25%;text-align: center;' >";
                //cadenfinal += "<div style='border-bottom: 2px solid grey;font-weight: bold; background-color: #d6d6d6' > TOTAL </div>";
                //cadenfinal += "<label> 2437.00 </label></div></div><div style='display: flex;justify-content: space-between;'>";
                //cadenfinal += "<label style='margin: 20px'> CUOTAS PENDIENTES: 0 </label><div style=';text-align: center;";
                //cadenfinal += "display: flex;margin: 10px 0px;background-color: white;border: 1px solid grey;' >";
                //cadenfinal += "<div style='width: 160px;padding:7px 5px;border: 2px solid grey'><b> TOTAL PAGADO </b></div>";
                //cadenfinal += "<div style='width: 160px;padding:5px 5px;border: 2px solid grey'> S /. 2437.00 </div>";
                //cadenfinal += "</div></div><div style='font-size: 14px;margin: 30px 0'><div> VALLE ENCANTADO S.A.C - RUC 20601460271 </div>";
                //cadenfinal += "<div>AV.GUARDIA CIVIL 1321 EDIFICIO CONEXION LIMA OFICINA 602 </div>";
                //cadenfinal += "<div>FIJO: 01 - 4349481 / 01 - 4799174 </div><div> CELULAR / WHATSAPP: 938627349 / 938627411 / 938627011 </div>";
                //cadenfinal += "<div>CORREO: SOCIOS @CIENEGUILLARIBERADELRIO.COM</div></div>";
                cadenfinal += "</div></body></html>";


                var parsehtml = HTMLWorker.ParseToList(new StringReader(cadenfinal), null);

                foreach (var htmlElement in parsehtml)
                {
                    document.Add(htmlElement as IElement);
                }
                document.Close();

            }

            return nameTicket + ".pdf";
        }

        private string GetMonth(string _months)
        {
            int _month = int.Parse(_months);
            string month = "";
            if (_month == 1)
            {
                month = "Enero";
            }
            if (_month == 2)
            {
                month = "Febrero";
            }
            if (_month == 3)
            {
                month = "Marzo";
            }
            if (_month == 4)
            {
                month = "Abril";
            }
            if (_month == 5)
            {
                month = "Mayo";
            }
            if (_month == 6)
            {
                month = "Junio";
            }
            if (_month == 7)
            {
                month = "Julio";
            }
            if (_month == 8)
            {
                month = "Agosto";
            }
            if (_month == 9)
            {
                month = "Septiembre";
            }
            if (_month == 10)
            {
                month = "Octubre";
            }
            if (_month == 11)
            {
                month = "Noviembre";
            }
            if (_month == 12)
            {
                month = "Diciembre";
            }
            return month;
        }
    }
}