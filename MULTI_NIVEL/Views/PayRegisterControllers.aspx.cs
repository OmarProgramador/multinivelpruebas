using BussinesRules;
using BussinesRules.Consuption;
using BussinesRules.TypeMembership;
using BussinesRules.User;
using Entities;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;

namespace MULTI_NIVEL.Views
{
    public partial class PayRegisterControllers : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            string TypeMembership = "";

            #region Declaracion de variables
            string quotesPendiente = "";
            string codeCurrencyPay = "";
            string namePeson = "";
            string[] dataLogin = null;
            int typeRegister = 0, numberQuotes = 0, formPay = 0, idMemberDetails = 0;
            string dataKit = null, dataKitMember = null, dataMemberSinKit;
            string token = null, userCurrent = null, newUserName = null, emailNewUser = null;
            double amountPay = 0;
            bool isRegister = false;
            BrUser brUser = null;
            BrTypeMembership brTypeMembership = null;
            Email oEmail = null;
            BrPayments brPayments = null;
            BrConsuption brConsuption;

            #endregion

            #region Entradas de valores

            var _var = (string)Session["typeRegister"];
            if (!string.IsNullOrEmpty(_var))
            {
                typeRegister = int.Parse(Session["typeRegister"].ToString());
            }
            formPay = int.Parse("1");
            token = Request["token"].ToString();
            numberQuotes = int.Parse(Request["numcuotes"].ToString());
            brUser = new BrUser();
            brTypeMembership = new BrTypeMembership();
            dataLogin = HttpContext.Current.User.Identity.Name.Split('¬');
            oEmail = new Email();
            brPayments = new BrPayments();
            brConsuption = new BrConsuption();
            #endregion

            #region Procesos

            userCurrent = dataLogin[0];
            if (dataLogin.Length > 1)
            {
                userCurrent = dataLogin[1];
            }

            #endregion

            #region Registrar Usuario Y Generar Cuenta

            if (formPay == 1)
            {

                if (!string.IsNullOrEmpty((string)Session["SwitchAmort"]))
                {
                    var values = (string)Session["dataAmort"];
                    var arrayValues = values.Split('|');
                    if (!string.IsNullOrEmpty(values))
                    {
                        brPayments = new BrPayments();
                        PayCulqi payCulqi = new PayCulqi();
                        MyMessages myMessages = new MyMessages();
                        // (int TypePay, string IdMembershipDetail, int nQuotes, decimal NewAmort, int Rate)
                        //Get the Email
                        string photo = "culqi.jpeg";
                        string emailUser = brPayments.PayQuoteMembership(arrayValues[0], "10", photo);

                        bool ans = brPayments.Amortization(1, arrayValues[0], Int32.Parse(arrayValues[1]), decimal.Parse(arrayValues[2]), Int32.Parse(arrayValues[3]), photo);
                        string currencyCode = "PEN";
                        string[] culqiAnwser = payCulqi.newPayment(emailUser, emailUser, double.Parse(arrayValues[2]), token, numberQuotes, currencyCode).Split('¬');

                        if (culqiAnwser[0] == "true")
                        {
                            bool awnserEmail = oEmail.SubmitEmail(emailUser, "[RIBERA DEL RIO - PAGO]", myMessages.EmailPago());
                            Response.Write("true¬" + culqiAnwser[1]);
                            Session.Remove("SwitchAmort");
                            return;
                        }
                        Response.Redirect("Payments.aspx");
                        return;
                    }
                }
                else if (Session["StatusCalendar"] == null)
                {
                    string dataBdd = Session["datos"].ToString();
                    TypeMembership = (dataBdd.Split('$')[3]).Split('|')[7];
                    // string data2 = (string)Session["civilStatus"];
                    string data2 = (string)Session["civilState"];
                    string[] oIdMembreship_amount = brUser.RegisterUser(dataBdd, data2).Split('¬');

                    if (oIdMembreship_amount.Length < 2)
                    {
                        Response.Write("false¬Ha Ocurrido Un Error al Intentar Registrar al Usuario");
                        return;
                    }

                    string[] parameterPerson = dataBdd.Split('$');
                    string[] arraydata = parameterPerson[0].Split('|');
                    string[] arrayTypeaccount = parameterPerson[2].Split('|');
                    string[] arrayaccount = parameterPerson[3].Split('|');

                    string parameterAccount = arraydata[5].Trim() + "|" + arrayTypeaccount[7].Trim() + '|' + userCurrent + '|' + oIdMembreship_amount[0];
                    //'999999999999|1|sa|1'
                    newUserName = brUser.GenerateAccount(parameterAccount);



                    if (string.IsNullOrEmpty(newUserName))
                    {
                        Response.Write("false¬Ha Ocurrido Un Error al Intentar Registrar al Usuario");
                        return;
                    }
                }
                else
                {
                    var calendar = (string)Session["StatusCalendar"];
                    var data = (string)Session["StatusCalendar"];
                    string numCuota = Session["numCuota"].ToString();
                    var listParameters = data.Split('|');
                    var data2 = listParameters[0];
                    string quotePay = (string)Session["quotePay"];
                    string userName = User.Identity.Name.Split('¬')[1];
                    TypeMembership = User.Identity.Name.Split('¬')[7];
                    string emailUser = brUser.GetPersonalInformation(userName).Split('|')[5];
                    PayCulqi payCulqi = new PayCulqi();
                    string currencyCode = "PEN";
                    if (Session["CurrencyCode"] != null)
                    {
                        currencyCode = Session["CurrencyCode"].ToString();
                    }
                    string[] culqiAnwser = payCulqi.newPayment(userCurrent, emailUser, Double.Parse(quotePay), token, numberQuotes, currencyCode).Split('¬');

                    bool awnserEmail = oEmail.SubmitEmail(emailUser, "[RIBERA DEL RIO - PAGO]", "Ud. Ha efectuado su pago en Ribera del Rio con Exito.");
                    if (culqiAnwser[0] == "true")
                    {
                        //enviar recibo
                        var dateCurrent = DateTime.Now.ToString("yyyy-MM-dd").Split('-'); ;

                        string tranferId = culqiAnwser[2];
                        string numReceipt = "0";
                        string date = dateCurrent[2] + " de " + GetMonth(dateCurrent[1]) + " del " + dateCurrent[0];
                        string nAffiliate = "";

                        string hour = DateTime.Now.ToString("HH:mm:ss");
                        string detalle = Double.Parse(quotePay).ToString();

                        namePeson = User.Identity.Name.Split('¬')[0].ToUpper();

                        //cvbc
                        string nameTicket = GetRecibo(tranferId, userName, numReceipt, date,
                            nAffiliate, TypeMembership, namePeson, hour, detalle,
                            quotesPendiente, " " + numCuota);

                        string EmailUserA = brPayments.PayQuoteMembership(data2, "1", nameTicket);
                        Response.Write("true¬" + culqiAnwser[1]);
                    }
                    else
                    {
                        Response.Write("false¬" + culqiAnwser[1]);
                    }
                    return;
                }
            }
            #endregion

            #region Solo elegio el kit

            if (typeRegister == 1 && formPay == 1)
            {
                string arrayKit = Session["arrayKit"].ToString() + "¬" + newUserName;
                //'2018-10-19¬31¬31¬31¬userName'
                //  isRegister = brUser.PutRegisterkIT(arrayKit);
                string data2 = Session["financedAmount"].ToString();
                if (data2 == "0")
                {
                    data2 = Session["Amount"].ToString();
                }

                string codeCurrency = Session["TypeCurrency"].ToString();

                Int32 ansNmembershi = brUser.RegisterNmembership(TypeMembership + '|' + newUserName, data2, 1, codeCurrency);

                if (ansNmembershi != 0)
                {
                    isRegister = brUser.PutRegisterkIT(arrayKit, ansNmembershi);
                }
                else
                {
                    Response.Write("false¬Ha Ocurrido Un Error al Intentar Obtener el monto a Pagar");
                    return;
                }
                //monto a pagar
                string[] username_idmen_amount_email = brUser.getAmountPay(newUserName).Split('¬');
                if (username_idmen_amount_email.Length < 4)
                {
                    Response.Write("false¬Ha Ocurrido Un Error al Intentar Obtener el monto a Pagar");
                    return;
                }
                idMemberDetails = int.Parse(username_idmen_amount_email[1]);
                amountPay = double.Parse(username_idmen_amount_email[2]);
                emailNewUser = username_idmen_amount_email[3];
                username_idmen_amount_email = null;
            }
            #endregion

            #region Elegio kit mas membresia

            if (typeRegister == 2 && formPay == 1)
            {

                dataKitMember = Session["cronograma"].ToString();

                string[] datos = Session["datos"].ToString().Split('$');

                if (Session["datos"] == null)
                {
                    Response.Write("false¬Ha Ocurrido Un Error, no hay datos.");
                    return;
                }
                string[] arraycontacto = datos[3].Split('|');
                string[] arrayperson = datos[0].Split('|');

                amountPay = double.Parse(Session["FirtsPay"].ToString());


                if (idMemberDetails <= 0 || amountPay <= 0)
                {
                    Response.Write("false¬Ha Ocurrido Un Error id idMemberDetails vacio,amountPay vacio");
                    return;
                }

                string dni = arrayperson[5];

                newUserName = arrayperson[0].Substring(0, 1).ToUpper() + arrayperson[1].Substring(0, 1).ToUpper() + dni;
                emailNewUser = arraycontacto[0].Trim();
                codeCurrencyPay = Session["TypeCurrency"].ToString();


                PayCulqi payCulqi = new PayCulqi();
                MyMessages myMessages = new MyMessages();
                //string currencyCode = "PEN";
                string[] culqiAnwser = payCulqi.newPayment(newUserName, emailNewUser, amountPay, token, numberQuotes, codeCurrencyPay).Split('¬');
                if (culqiAnwser[0] == "false")
                {
                    Response.Write("false¬" + culqiAnwser[1]);
                    return;
                }




                /*=====================================================================================================================================================================*/

                //correo = arraycontacto[0];
                namePeson = arrayperson[0] + " " + arrayperson[1];


                string date = dataKitMember.Split('$')[1];

                string[] array1 = Session["cronogramaYa"].ToString().Split('^');
                string[] datosMem = array1[0].Split('|');
                string[] array2 = array1[1].Split('~');
                string[] cuotas = array2[0].Split('¬');
                string cronoActiv = "";
                quotesPendiente = (cuotas.Length - 2).ToString();
                for (int i = 0; i < cuotas.Length - 1; i++)
                {
                    var fila = cuotas[i].Split('|');
                    if (fila[0].Substring(0, 7) != "Inicial")
                    {
                        cronoActiv += DateTime.Parse(fila[1]).ToString("yyyy-MM-dd");
                        //amountFinanciade = double.Parse(fila[2].Replace("S/.", ""));
                        break;
                    }
                    else
                    {
                        cronoActiv += DateTime.Parse(fila[1]).ToString("yyyy-MM-dd") + "¬";
                    }
                }

                string respData = brPayments.PersonGetData(newUserName);
                respData = respData + '^' + dataKitMember;
                // isRegister = brPayments.GetCalculatePaymentSchedule(respData, newUserName);
                string data2 = Session["financedAmount"].ToString();
                string codeCurrency = Session["TypeCurrency"].ToString();

                Int32 ansNmembershi = brUser.RegisterNmembership(TypeMembership + '|' + newUserName, data2, 1, codeCurrency);
                string exchange = Session["carrito"].ToString().Split('|')[4];
                isRegister = brPayments.GetCalculatePaymentSchedule(respData, newUserName, ansNmembershi, exchange, 1);

                //validamos si tiene consumo


                if (!isRegister)
                {
                    Response.Write("false¬Ha Ocurrido Un Error al Intentar Registrar el Cronograma de Pagos del Usuario");
                    return;
                }

                BrActivation brActivation = new BrActivation();
                bool registerActi = brActivation.PutCronograma(cronoActiv, newUserName, ansNmembershi);

                //obtengo el monto a pagar

                string[] username_idmen_amount_email = brUser.getAmountPay(newUserName).Split('¬');
                if (username_idmen_amount_email.Length < 4)
                {
                    Response.Write("false¬Ha Ocurrido Un Error al Intentar Obtener el monto a Pagar");
                    return;
                }
                idMemberDetails = int.Parse(username_idmen_amount_email[1]);
                amountPay = double.Parse(username_idmen_amount_email[2]);
                emailNewUser = username_idmen_amount_email[3];
                codeCurrencyPay = username_idmen_amount_email[4];
                date = null;
                username_idmen_amount_email = null;
                dataKitMember = null;
                respData = null;


                /*=============================================================================================================================*/

                var dateCurrent = DateTime.Now.ToString("yyyy-MM-dd").Split('-'); ;

                string tranferId = culqiAnwser[2] == null ? "" : culqiAnwser[2];
                string numReceipt = "0";
                string datecomplete = dateCurrent[2] + " de " + GetMonth(dateCurrent[1]) + " del " + dateCurrent[0];
                string nAffiliate = "";

                string hour = DateTime.Now.ToString("HH:mm:ss");
                string detalle = amountPay.ToString();


                //cvbc
                string nameTicket = GetRecibo(tranferId, newUserName, numReceipt, datecomplete, nAffiliate, TypeMembership, namePeson, hour, detalle, quotesPendiente, " Inicial 1");


                //marcar como pagado en la tabla membershipdetails
                bool habiliAccount = brUser.enableAcount(idMemberDetails, nameTicket);

                int nAfiliate = int.Parse(brUser.GetNafiliate(idMemberDetails));

                Cronograma2(nAfiliate, codeCurrencyPay);

                // enviar el email de confirmacion con la data y lo redirecciona al post register
                if (!habiliAccount)
                {
                    Response.Write("false¬Ha Ocurrido un Error al Intentar Habilitar Su Cuenta.Sin embargo su Pago fue Exitoso");
                    return;
                }


                string ruta = HttpContext.Current.Server.MapPath("~/Resources/PoliticsPdf/");
                //enviar email con los documentos
                if (typeRegister == 2 && formPay == 1)
                {
                    bool awnserEmailDoc = oEmail.SubmitEmail(emailNewUser, "[RIBERA DEL RIO - BIENVENIDO]", myMessages.DocumentosRegister(newUserName), true, ruta, newUserName);
                }
                else
                {
                    bool awnserEmailDoc = oEmail.SubmitEmailKit(emailNewUser, "[RIBERA DEL RIO - BIENVENIDO]", myMessages.DocumentosRegister(newUserName), true, ruta);
                }


                bool awnserEmail = oEmail.SubmitEmail(emailNewUser, "[RIBERA DEL RIO - PAGO]", myMessages.EmailPago());

                //ejecutamos el core para los puntos de equipo
                // BrCore_Automation brCore_Automation = new BrCore_Automation();
                //bool isCoreRegister = brCore_Automation.ExecuteCore();

                Response.Write("true¬" + culqiAnwser[1]);
                return;

            }
            #endregion

          
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
                                string quotesPendiente,
                                string concepto)
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
                cadenfinal += "<div><img src='" + rutaImg + "rec.png' style='position: absolute;top: 24%;left:28%;opacity: 0.1;z-index:1;width:515px;'></div>";

                cadenfinal += "<div style='display:block;margin:10px auto;text-align: center;' ><h2><b> VALLE ENCANTADO S.A.C </b></h2>";
                cadenfinal += "<h4><b> RUC 20601460271 </b></h4></div><div style='display: flex;justify-content: space-between;'>";
                //cadenfinal += "<div style='display:block' ><div style='margin:5px 0'><b> Nro. MEMBRESIA:</b> AR00101 </div>";
                cadenfinal += "<div style='display:block' ><div style='margin:5px 0'><b> Codigo:</b> " + username + " </div>";
                cadenfinal += "<label><b> Nombre: </b> " + namePeson.ToUpper() + "</label></div><div><div><b> Codido Membresia: </b>" + typeMembresia + "</div>";
                cadenfinal += "<label><b> DNI: </b> " + dni + " </label></div></div><div style = 'margin:15px auto;'><label><B> Codigo de operacion: </B> " + tranferId + " </label>";
                cadenfinal += "</div>";
                cadenfinal += "<div style='margin: 15px auto' ><b> Fecha: </b>" + date + " HORA: " + hour + " </div>";
                cadenfinal += "<div style='margin: 15px auto' ><b> Concepto: </b> " + concepto + " </div>";
                cadenfinal += "<div style='margin: 15px auto' ><b> Monto: </b>" + detalle + " </div>";
                cadenfinal += "<div style='margin: 15px auto' ><b> Cuotas pendientes: </b>" + quotesPendiente + " </div>";

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

                var styles = new StyleSheet();
                Dictionary<string, string> cuadro = new Dictionary<string, string>();
                cuadro.Add("font-family", "sans-serif");
                cuadro.Add("display", "block");
                cuadro.Add("padding", "20px");
                cuadro.Add("margin", "10px auto");
                cuadro.Add("width", "700px");
                cuadro.Add("height", "700px");
                cuadro.Add("background-color", "green");

                styles.LoadStyle("cuadro", cuadro);

                var parsehtml = HTMLWorker.ParseToList(new StringReader(cadenfinal), null);

                foreach (var htmlElement in parsehtml)
                {
                    document.Add(htmlElement as IElement);
                }
                document.Close();

            }

            return nameTicket + ".pdf";
        }


        #region Methods
        public double TwoDecimas(double number)
        {
            int entero = 0;
            entero = int.Parse((number * 100).ToString());
            double anwser = entero;
            anwser = anwser / 100;
            return anwser;
        }


        public void Cronograma2(int _nAfiliate, string _cc)
        {
            string[] arrayLogin = HttpContext.Current.User.Identity.Name.Split('¬');
            string tipocambio = "", numerodecuotas = "", nombre = "", dni = "", domicilio = "", distrito = "", correo = "", telefono = "", codemem = "";

            string username = "", fecha = "";


            //Session["cronogramaya"] = "6857.5|6142.5|0|11/2/2018¬89.57|24|10|Mensual^Inicial nro: 1|11/2/2018|S/. 6857.5|S/. 715|S/. 0|S/. 715¬Inicial nro: 2|12/2/2018|S/. 6142.5|S/. 800|S/. 0|S/. 800¬Inicial nro: 3|1/2/2018|S/. 5342.5|S/. 1000|S/. 0|S/. 1000¬Cuota nro: 1|11/1/2018|S/. 4342.5|S/. 164.89|S/. 34.63|S/. 199.52¬Cuota nro: 2|12/1/2018|S/. 4177.61|S/. 166.21|S/. 33.31|S/. 199.52¬Cuota nro: 3|1/1/2019|S/. 4011.4|S/. 167.53|S/. 31.99|S/. 199.52¬Cuota nro: 4|2/1/2019|S/. 3843.87|S/. 168.87|S/. 30.65|S/. 199.52¬Cuota nro: 5|3/1/2019|S/. 3675|S/. 170.22|S/. 29.3|S/. 199.52¬Cuota nro: 6|4/1/2019|S/. 3504.78|S/. 171.57|S/. 27.95|S/. 199.52¬Cuota nro: 7|5/1/2019|S/. 3333.21|S/. 172.94|S/. 26.58|S/. 199.52¬Cuota nro: 8|6/1/2019|S/. 3160.27|S/. 174.32|S/. 25.2|S/. 199.52¬Cuota nro: 9|7/1/2019|S/. 2985.95|S/. 175.71|S/. 23.81|S/. 199.52¬Cuota nro: 10|8/1/2019|S/. 2810.24|S/. 177.11|S/. 22.41|S/. 199.52¬Cuota nro: 11|9/1/2019|S/. 2633.13|S/. 178.52|S/. 21|S/. 199.52¬Cuota nro: 12|10/1/2019|S/. 2454.61|S/. 179.95|S/. 19.57|S/. 199.52¬Cuota nro: 13|11/1/2019|S/. 2274.66|S/. 181.38|S/. 18.14|S/. 199.52¬Cuota nro: 14|12/1/2019|S/. 2093.28|S/. 182.83|S/. 16.69|S/. 199.52¬Cuota nro: 15|1/1/2020|S/. 1910.45|S/. 184.29|S/. 15.23|S/. 199.52¬Cuota nro: 16|2/1/2020|S/. 1726.16|S/. 185.76|S/. 13.76|S/. 199.52¬Cuota nro: 17|3/1/2020|S/. 1540.4|S/. 187.24|S/. 12.28|S/. 199.52¬Cuota nro: 18|4/1/2020|S/. 1353.16|S/. 188.73|S/. 10.79|S/. 199.52¬Cuota nro: 19|5/1/2020|S/. 1164.43|S/. 190.24|S/. 9.29|S/. 199.52¬Cuota nro: 20|6/1/2020|S/. 974.19|S/. 191.75|S/. 7.77|S/. 199.52¬Cuota nro: 21|7/1/2020|S/. 782.44|S/. 193.28|S/. 6.24|S/. 199.52¬Cuota nro: 22|8/1/2020|S/. 589.16|S/. 194.82|S/. 4.7|S/. 199.52¬Cuota nro: 23|9/1/2020|S/. 394.34|S/. 196.38|S/. 3.14|S/. 199.52¬Cuota nro: 24|10/1/2020|S/. 197.96|S/. 197.94|S/. 1.58|S/. 199.52¬~446.01~4788.5";
            //Session["datos"] = "Nombre|Apellidos|birthDay|M|DocumentType|NroDoc$NombreC|ApellidoC|1|313231c$bankName|nombreBankAccount|TypeAccount|nroAccount|nroTaxer|SocialReason|fiscalAdress|UserType$email|nroCell|nroCell2|country|State|City|Adress";
            //Session["carrito"] = "6000.00|descripcionDB|60|9750.00|3.25|10|TOP";


            string[] datos = Session["datos"].ToString().Split('$');
            string[] carrito = Session["carrito"].ToString().Split('|');
            string[] cronograma = Session["cronogramaYa"].ToString().Split('|');

            string[] arrayperson = datos[0].Split('|');
            string[] arraycontacto = datos[3].Split('|');
            string totaldolares = cronograma[0];
            string primeracuota = carrito[3];
            tipocambio = carrito[4];
            decimal typeChange = decimal.Parse(tipocambio);
            numerodecuotas = carrito[2];
            codemem = carrito[1];

            nombre = arrayperson[0].ToUpper() + " " + arrayperson[1].ToUpper();
            dni = arrayperson[5];
            username = (arrayperson[0].Substring(0, 1) + arrayperson[1].Substring(0, 1) + dni).ToUpper();

            domicilio = arraycontacto[6];
            distrito = arraycontacto[5];
            correo = arraycontacto[0];
            telefono = arraycontacto[1];

            fecha = DateTime.Now.ToString("dd-MM-yyyy");

            MyFunctions mf = new MyFunctions();
            MyConstants mc = new MyConstants();

            string[] array1 = Session["cronogramaYa"].ToString().Split('^');
            string[] datosMem = array1[0].Split('|');
            string[] array2 = array1[1].Split('~');

            string[] cuotas = array2[0].Split('¬');

            decimal totalpagar = 0, interestotal = 0, importefinanciado = 0, porcefinanciado = 0;
            int ncuotas = 0, interruptor = 0;

            for (int i = 0; i < cuotas.Length - 1; i++)
            {
                var fila = cuotas[i].Split('|');
                if (fila[0].Substring(0, 7) != "Inicial")
                {
                    totalpagar += decimal.Parse(fila[5].Replace("S/.", ""));
                    interestotal += decimal.Parse(fila[4].Replace("S/.", ""));
                    ncuotas++;
                    if (interruptor != 1)
                    {
                        interruptor = 1;
                        importefinanciado = decimal.Parse(fila[2].Replace("S/.", ""));
                        Session["financedAmount"] = importefinanciado;
                    }
                }
            }
            porcefinanciado = (importefinanciado * 100) / decimal.Parse(datosMem[0]);


            using (Document document = new Document(PageSize.A4, 10, 10, 10, 10))
            {

                string ruta = HttpContext.Current.Server.MapPath("~/Resources/PoliticsPdf/") + "CRO" + username + ".pdf";

                FileStream stream = new FileStream(ruta, FileMode.Create);
                PdfWriter.GetInstance(document, stream);


                document.Open();

                string cadenfinal = string.Empty;
                cadenfinal += "<div style='text-align: center;font-family:cambria;font-size: 12pt;font-weight: bold;'>CRONOGRAMA DE PAGOS</div>";
                cadenfinal += "<p style='font-family:cambria;font-size: 10pt;line-height: 8px;'>Número de Membresia: AR" + _nAfiliate.ToString("00000") + " </p>";
                cadenfinal += "<p style='font-family:cambria;font-size: 10pt;line-height: 13px;'>Código: " + username + " </p>";
                //cadenfinal += "<p style='font-family:cambria;font-size: 10pt;line-height: 13px;'><b>Nombre:</b>" + datosMem[0] + "</p>";
                //cadenfinal += "<p style='text-align: justify;font-family:cambria;font-size: 10pt;line-height: 13px;'>Importe Membresia: S/. " + datosMem[0] + "</p>";
                cadenfinal += "<p style='text-align: justify;font-family:cambria;font-size: 10pt;line-height: 13px;'>Nombre del Cliente: " + nombre + " </p>";
                cadenfinal += "<p style='text-align: justify;font-family:cambria;font-size: 10pt;line-height: 13px;'>Documento de Identidad: " + dni + "</p>";
                cadenfinal += "<p style='text-align: justify;font-family:cambria;font-size: 10pt;line-height: 13px;'>Correo Electronico: " + correo + " </p>";
                cadenfinal += "<p style='text-align: justify;font-family:cambria;font-size: 10pt;line-height: 13px;'>Telefono de Contacto: " + telefono + " </p>";
                cadenfinal += "<p style='text-align: justify;font-family:cambria;font-size: 10pt;line-height: 13px;'>Producto: Membresia " + codemem + "</p>";
                cadenfinal += "<p style='text-align: justify;font-family:cambria;font-size: 10pt;line-height: 13px;'> </p>";


                //
                cadenfinal += "<br/> <table ><tr>";
                cadenfinal += "<td height='100' style='font-family:cambria;font-size: 10pt;line-height: 8px;'>Importe de la Membresia </td>";
                cadenfinal += "<td height='100' style='font-family:cambria;font-size: 10pt;line-height: 8px;'> " + mf.GetAmountCurrency(datosMem[0], _cc, typeChange) + " " + _cc + "</td>";
                cadenfinal += "<td height='100' style='font-family:cambria;font-size: 10pt;line-height: 8px;'>% Financiamiento </td>";
                cadenfinal += "<td height='100' style='font-family:cambria;font-size: 10pt;line-height: 8px;'> " + porcefinanciado.ToString("0.00") + "% </td></tr>";

                cadenfinal += "<tr><td height='100' style='font-family:cambria;font-size: 10pt;line-height: 8px;'>Importe Financiado </td>";
                cadenfinal += "<td height='100' style='font-family:cambria;font-size: 10pt;line-height: 8px;'> " + mf.GetAmountCurrency(importefinanciado.ToString(), _cc, typeChange) + " " + _cc + " </td>";
                cadenfinal += "<td height='100' style='font-family:cambria;font-size: 10pt;line-height: 8px;'>Cuotas a Pagar </td>";
                cadenfinal += "<td height='100' style='font-family:cambria;font-size: 10pt;line-height: 8px;'>" + ncuotas + " </td></tr>";

                cadenfinal += "<tr><td height='100' style='font-family:cambria;font-size: 10pt;line-height: 8px;'>Cantidad Total a Pagar </td>";
                cadenfinal += "<td height='100' style='font-family:cambria;font-size: 10pt;line-height: 8px;'> " + mf.GetAmountCurrency(totalpagar.ToString(), _cc, typeChange) + " " + _cc + " </td>";
                cadenfinal += "<td height='100' style='font-family:cambria;font-size: 10pt;line-height: 8px;'>Tasa Efectiva Anual </td>";
                cadenfinal += "<td height='100' style='font-family:cambria;font-size: 10pt;line-height: 8px;'> " + mc.AmountInteresAnual.ToString() + " %</td></tr>";

                cadenfinal += "<tr><td height='100' style='font-family:cambria;font-size: 10pt;line-height: 8px;'>Monto total de Interes </td>";
                cadenfinal += "<td height='100' style='font-family:cambria;font-size: 10pt;line-height: 8px;'> " + mf.GetAmountCurrency(interestotal.ToString(), _cc, typeChange) + " " + _cc + " </td>";
                cadenfinal += "<td height='100' style='font-family:cambria;font-size: 10pt;line-height: 8px;'>Periodicidad </td>";
                cadenfinal += "<td height='100' style='font-family:cambria;font-size: 10pt;line-height: 8px;'> Mensual </td></tr>";

                cadenfinal += "<tr><td height='100' style='font-family:cambria;font-size: 10pt;line-height: 8px;'>Fecha Emision Cronograma</td>";
                cadenfinal += "<td height='100' style='font-family:cambria;font-size: 10pt;line-height: 8px;'> " + fecha + " </td>";
                cadenfinal += "<td height='100' style='font-family:cambria;font-size: 10pt;line-height: 8px;'> </td>";
                cadenfinal += "<td height='100' style='font-family:cambria;font-size: 10pt;line-height: 8px;'> </td></tr>";
                cadenfinal += "</tr></table>";


                cadenfinal += "<table border='1' height='100' style='font-family:cambria;font-size: 10pt;line-height: 8px;'>";
                cadenfinal += "<tr height='100' style='font-family:cambria;font-size: 10pt;line-height: 8px;'>";
                cadenfinal += "<th height='100' bgcolor='#858282' style='font-family:cambria;font-size: 10pt;line-height: 8px;'>N°</th>";
                cadenfinal += "<th height='100' bgcolor='#858282' style='font-family:cambria;font-size: 10pt;line-height: 8px;'>Vencimiento</th>";
                cadenfinal += "<th height='100' bgcolor='#858282' style='font-family:cambria;font-size: 10pt;line-height: 8px;'>Capital</th>";
                cadenfinal += "<th height='100' bgcolor='#858282' style='font-family:cambria;font-size: 10pt;line-height: 8px;'>Amortizacion</th>";
                cadenfinal += "<th height='100' bgcolor='#858282' style='font-family:cambria;font-size: 10pt;line-height: 8px;'>Interes</th>";
                cadenfinal += "<th height='100' bgcolor='#858282' style='font-family:cambria;font-size: 10pt;line-height: 8px;'>Cuota</th>";
                cadenfinal += "</tr>";

                for (int i = 0; i < cuotas.Length - 1; i++)
                {
                    var fila = cuotas[i].Split('|');
                    cadenfinal += "<tr height='100' style='font-family:cambria;font-size: 10pt;line-height: 8px;'>";
                    cadenfinal += "<td height='100' style='font-family:cambria;font-size: 10pt;line-height: 8px;'> " + fila[0] + "</td>";
                    cadenfinal += "<td height='100' style='font-family:cambria;font-size: 10pt;line-height: 8px;'>" + DateTime.Parse(fila[1]).ToString("dd-MM-yyyy") + " </td>";
                    cadenfinal += "<td height='100' style='font-family:cambria;font-size: 10pt;line-height: 8px;'>" + mf.GetAmountCurrency(fila[2].Replace("S/.", ""), _cc, typeChange) + " " + _cc + "</td>";
                    cadenfinal += "<td height='100' style='font-family:cambria;font-size: 10pt;line-height: 8px;'>" + mf.GetAmountCurrency(fila[3].Replace("S/.", ""), _cc, typeChange) + " " + _cc + "</td>";
                    cadenfinal += "<td height='100' style='font-family:cambria;font-size: 10pt;line-height: 8px;'>" + mf.GetAmountCurrency(fila[4].Replace("S/.", ""), _cc, typeChange) + " " + _cc + "</td>";
                    cadenfinal += "<td height='100' style='font-family:cambria;font-size: 10pt;line-height: 8px;'>" + mf.GetAmountCurrency(fila[5].Replace("S/.", ""), _cc, typeChange) + " " + _cc + "</td>";

                    cadenfinal += "</tr>";
                }

                cadenfinal += "</table>";
                cadenfinal += "<p style='text-align: justify;font-family:cambria;font-size: 10pt;line-height: 13px;'>Este Cronograma se elabora bajo el supuesto cumpliento de pagos de las cuotas en las fechas indicadas.Cualquier alteracion en los pagos o en las condiciones del financiamiento,deja sin efecto este documento.</p>";
                cadenfinal += "<p style='text-align: justify;font-family:cambria;font-size: 10pt;line-height: 13px;'>El atraso de una cuota mensual por mas de 8 días generará una penalidad de S/.30 soles.</p>";
                cadenfinal += "<p style='text-align: justify;font-family:cambria;font-size: 10pt;line-height: 13px;'>Si tuviera alguna consulta sirvase comunicarse con su asesor de membresías o a la línea de atención al cliente (01)-434-9481.</p>";

                cadenfinal += "<br />";
                cadenfinal += "<br />";
                cadenfinal += "<br />";

                cadenfinal += "<div style='text-align: right;'>";

                cadenfinal += "<div style='text-align: left;width: 200px;margin-left:100px' >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_____________________________</div>";
                cadenfinal += "<div style='text-align: left;width: 200px;margin-left:100px'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Omar Urteaga Cabrera</div>";
                cadenfinal += "<div style='text-align: left;width: 200px;margin-left:100px'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Gerente General</div>";
                cadenfinal += "<div style='text-align: left;width: 200px;margin-left:100px'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Ribera del Rio Club Resort</div>";
                cadenfinal += "</div>";


                var parsehtml = HTMLWorker.ParseToList(new StringReader(cadenfinal), null);

                foreach (var htmlElement in parsehtml)
                {
                    document.Add(htmlElement as IElement);

                }
                document.Close();

            }
        }


        #endregion



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