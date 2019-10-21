
namespace MULTI_NIVEL.Views
{
    using BussinesRules;
    using BussinesRules.TypeMembership;
    using BussinesRules.User;
    using Entities;
    using iTextSharp.text;
    using iTextSharp.text.html.simpleparser;
    using iTextSharp.text.pdf;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Threading;
    using System.Web;

    public partial class AddMembPayWallet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //hasta ahora 4 
            //nombree completo ¬ userName ¬ id person¬ status payments
            //login con usuario y contraseña

            if (!IsPostBack)
            {
                MyConstants mc = new MyConstants();
                try
                {
                    MessageError.Text = string.Empty;
                    MessageSucces.Text = string.Empty;
                    MessageWarning.Text = string.Empty;
                    BrWallet brWallet = new BrWallet();

                    var amountWallet = decimal.Parse(brWallet.GetAmount(User.Identity.Name.Split('¬')[1]));
                    Wallet.Text = $"Wallet: {amountWallet.ToString()}";
                    var obj = HttpContext.Current.User.Identity.Name.Split('¬');
                    this.lblUser.Text = "Hola " + obj[0];
                    this.lblUserName.Text = obj[0];
                    if (obj.Length > 2)
                    {
                        this.lblNumPartner.Text = "N° Asociado: " + obj[4];
                    }

                    for (int i = 0; i < 32; i++)
                    {
                        DdlQuote.Items.Add((i + 1).ToString());
                    }
                    if (true)
                    {
                        this.imgProfile.ImageUrl = "~/Resources/Images/profile.png";
                        this.imgProfileFl.ImageUrl = "~/Resources/Images/profile.png";
                    }

                    decimal tipocambio = decimal.Parse(Session["carrito"].ToString().Split('|')[4]);
                    string currencyCode = Session["TypeCurrency"].ToString();

                    string showReport = Session["cronogramaYa"].ToString();
                    string[] macro = showReport.Split('^');
                    string[] micro = macro[1].Split('¬');

                    decimal quoteReference = 0;

                    for (int i = 0; i <= micro.Length; i++)
                    {
                        string[] listRegisters = micro[i].Split('|');
                        if (listRegisters[0] == "Inicial nro: 1")
                        {
                            quoteReference += decimal.Parse(listRegisters[5].Replace("S/. ", ""));
                            break;
                        }
                        if (listRegisters[0] == "Upgrade")
                        {
                            quoteReference += decimal.Parse(listRegisters[5].Replace("S/. ", ""));
                            //break;
                        }
                    }
                    decimal amountTotal = quoteReference;
                    if (currencyCode == "USD")
                    {
                        amountTotal = amountTotal / tipocambio;
                    }
                    Monto.Text = amountTotal.ToString("###,###,##0.00") + $"";
                    Session["MontoWallet"] = amountTotal.ToString();

                    var resta = amountTotal - amountWallet;


                    BrTypeChange brTypeChange = new BrTypeChange();
                    var arrayTypes = brTypeChange.GetTypesChange().Split('|');
                    var tcCompra = decimal.Parse(arrayTypes[1]);

                    var amountSoles = resta * tcCompra;

                    LblAmountWallet.Text = $"Monto de mi Wallet {amountWallet} USD";
                    LblAmountCulqi.Text = $"Monto a pagar {resta.ToString()} USD  ( {amountSoles.ToString("0.00")} PEN )";
                    LblAmountDeposit.Text = $"Monto a pagar {resta.ToString()} USD  ( {amountSoles.ToString("0.00")} PEN )";

                    PnWallet.Style.Add("display", "none");
                    PnOthers.Style.Add("display", "none");
                    if (amountWallet > amountTotal)
                    {
                        PnWallet.Style.Add("display", "block");
                    }
                    else
                    {
                        PnOthers.Style.Add("display", "block");
                    }



                    if (Session["carrito"] != null)
                    {
                        //total|descrin|ncuotas|montoinicial|tipocambio|interes anual|code member|¬cuota mensual¬n cuota inicial¬monto cuota inicial
                        //string currencyCode = Session["TypeCurrency"].ToString();
                        string[] parameterList = Session["carrito"].ToString().Split('|');
                        decimal typeChange = decimal.Parse(parameterList[4]);

                        int numberQuotesIni = int.Parse(parameterList[8]);
                        decimal amountQuoteIniS = decimal.Parse(parameterList[7]);
                        decimal amountQuoteIniD = amountQuoteIniS / typeChange;

                        int numberQuote = int.Parse(parameterList[2]);
                        decimal amountQuoteS = decimal.Parse(parameterList[9]);
                        decimal amountQuoteD = amountQuoteS / typeChange;

                        decimal quotePayS = decimal.Parse(parameterList[3]);
                        decimal quotePayD = decimal.Parse(parameterList[3]);
                        decimal costoMembresiaSoles = decimal.Parse(parameterList[0]) * typeChange;
                        decimal costoMembresiaDolar = costoMembresiaSoles / typeChange;

                        TypeMembreship.Text = "Tipo de membresía:  " + parameterList[1].ToUpper();
                        if (currencyCode == "PEN")
                        {
                            AmountTotal.Text = "Costo de la Membresia: " + costoMembresiaSoles.ToString("0.00") + " PEN";
                            AmountInitialQuote.Text = "La cuota Inicial esta divida en " + numberQuotesIni.ToString() + " Cuota(s) de " + amountQuoteIniS.ToString("0.00") + " PEN";
                            NumQuotes.Text = "La Membresia esta Dividida en " + numberQuote + " Cuotas de " + double.Parse(parameterList[9]).ToString("0.00") + " PEN";

                        }
                        else
                        {
                            AmountTotal.Text = "Costo de la Membresia: " + costoMembresiaDolar.ToString("0.00") + " USD";
                            AmountInitialQuote.Text = "La cuota Inicial esta divida en " + numberQuotesIni.ToString() + " Cuota(s) de " + amountQuoteIniD.ToString("0.00") + " USD";
                            NumQuotes.Text = "La Membresia esta Dividida en " + numberQuote + " Cuotas de " + double.Parse(parameterList[9]).ToString("0.00") + " USD";
                        }
                    }
                }
                catch (Exception ex)
                {
                    Email email = new Email();
                    email.SendEmail(mc.ErrorEmail, "error-inresorts", ex.StackTrace + '¬' + DateTime.Now.ToLongDateString(), false);
                    PayByWallet.Style.Add("display", "none");
                }
            }

        }

        protected void PayByWallet_Click(object sender, EventArgs e)
        {
            MyConstants mc = new MyConstants();
            try
            {
                //pagar con wallet
                BrWallet brWallet = new BrWallet();
                var amountWalletc = decimal.Parse(brWallet.GetAmount(User.Identity.Name.Split('¬')[1]));

                var quota = 0m;

                if (Session["MontoWallet"] != null)
                {
                    quota = decimal.Parse(Session["MontoWallet"].ToString());
                }

                if (amountWalletc < quota)
                {
                    MessageError.Text = "No tiene el monto suficiente para realizar Pago.";
                    return;
                }


                BrPayments brPayments = new BrPayments();
                BrUser brUser = new BrUser();
                string dataKitMember = Session["cronograma"].ToString();


                string date = dataKitMember.Split('$')[1];

                var cart = Session["carrito"].ToString();

                var arrayCart = cart.Split('|');
                var codeMemb = arrayCart[6];

                string[] datos = Session["datos"].ToString().Split('$');
                var dataBdd = Session["datos"].ToString();



                if (Session["datos"] == null)
                {
                    Response.Write("false¬Ha Ocurrido Un Error, no hay datos.");
                    return;
                }
                string[] arraycontacto = datos[3].Split('|');
                string[] arrayperson = datos[0].Split('|');


                string dni = arrayperson[5];

                var newUserName = arrayperson[0].Substring(0, 1).ToUpper() + arrayperson[1].Substring(0, 1).ToUpper() + dni;
                var emailNewUser = arraycontacto[0].Trim();
                var codeCurrencyPay = Session["TypeCurrency"].ToString();



                string[] array1 = Session["cronogramaYa"].ToString().Split('^');
                string[] datosMem = array1[0].Split('|');
                string[] array2 = array1[1].Split('~');
                string[] cuotas = array2[0].Split('¬');
                string cronoActiv = "";
                var quotesPendiente = (cuotas.Length - 2).ToString();
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

                var respDataper = brPayments.PersonGetData(newUserName);

                string respData = string.Empty;
                respData = respData + '^' + dataKitMember;

                // isRegister = brPayments.GetCalculatePaymentSchedule(respData, newUserName);
                //string data2 = Session["financedAmount"].ToString();

                string data2 = "0";
                //string codeCurrency = Session["TypeCurrency"].ToString();

                Int32 ansNmembershi = brUser.RegisterNmembership(codeMemb + '|' + newUserName, data2, 1, codeCurrencyPay);

                BrTypeMembership brTypeMemb = new BrTypeMembership();
                string typeChange = arrayCart[4];

                //var isRegister = brPayments.GetCalculatePaymentSchedule(respData, newUserName, ansNmembershi, typeChange, 1);
                bool isRegister = false;
                if (Session["codeUpgrate"] != null)
                {
                    //si es upgrate

                    isRegister = brPayments.GetCalculatePaymentScheduleUpgrate(respData, newUserName, ansNmembershi, typeChange, 1);
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

                    isRegister = brPayments.GetCalculatePaymentSchedule(respData, newUserName, ansNmembershi, typeChange, 1);
                    if (!isRegister)
                    {
                        Response.Write("false¬Ha Ocurrido Un Error al Intentar Registrar el Cronograma de Pagos del Usuario");
                        return;
                    }
                    //cronograma de activacion
                    BrActivation brActivation = new BrActivation();
                    bool registerActi = brActivation.PutCronograma(cronoActiv, newUserName, ansNmembershi);
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
                    bool registerActi = brActivation.PutCronogramaUpgrade(fechaAnterior, newUserName, ansNmembershi, codeUpgrate);
                }
                //validamos si tiene consumo


                if (!isRegister)
                {
                    MessageError.Text = "Ha Ocurrido Un Error al Intentar Registrar el Cronograma de Pagos del Usuario";
                    return;
                }

                //BrActivation brActivation = new BrActivation();
                //bool registerActi = brActivation.PutCronograma(cronoActiv, newUserName, ansNmembershi);

                //obtengo el monto a pagar

                string[] username_idmen_amount_email = brUser.getAmountPay(newUserName).Split('¬');
                if (username_idmen_amount_email.Length < 4)
                {
                    MessageError.Text = "false¬Ha Ocurrido Un Error al Intentar Obtener el monto a Pagar";
                    return;
                }
                var idMemberDetails = int.Parse(username_idmen_amount_email[1]);
                var amountPay = double.Parse(username_idmen_amount_email[2]);
                emailNewUser = username_idmen_amount_email[3];
                codeCurrencyPay = username_idmen_amount_email[4];
                date = null;
                username_idmen_amount_email = null;
                dataKitMember = null;
                respData = null;


                var namePeson = arrayperson[0].Trim() + " " + arrayperson[1].Trim();

                var dateCurrent = DateTime.Now.ToString("yyyy-MM-dd").Split('-'); ;

                string tranferId = "";
                string numReceipt = "0";
                string datecomplete = dateCurrent[2] + " de " + GetMonth(dateCurrent[1]) + " del " + dateCurrent[0];
                string nAffiliate = "";

                string hour = DateTime.Now.ToString("HH:mm:ss");
                string detalle = amountPay.ToString();
                MyMessages myMessages = new MyMessages();
                namePeson = myMessages.ToCapitalize(namePeson);
                //cvbc
                var imgTicket = GetRecibo(tranferId, newUserName, numReceipt, datecomplete, nAffiliate, codeMemb, namePeson, hour, detalle, quotesPendiente, " Inicial 1");


                /*=============================================================================================================================*/

                //var currencyCode = Session["CurrencyCode"].ToString();
                BrMembershipPayDetail brMembership = new BrMembershipPayDetail();
                var response = brMembership.GetQuote(idMemberDetails, User.Identity.Name.Split('¬')[1]).Split('|');

                if (decimal.Parse(response[0]) == 0)
                {
                    MessageError.Text = "Ocurrio un error.";
                    return;
                }
                var amount = decimal.Parse(response[0]).ToString();


                if (codeCurrencyPay == "USD")
                {
                    amount = (decimal.Parse(amount) * decimal.Parse(typeChange)).ToString();
                }


                var idInfo = idMemberDetails.ToString();
                var typeInfo = "1";
                var walleOperationId = "2";

                MessageError.Text = string.Empty;
                MessageWarning.Text = string.Empty;
                MessageSucces.Text = string.Empty;

                bool IsPay = brMembership.IsPayQuote(idMemberDetails.ToString());

                if (!IsPay)
                {
                    MessageWarning.Text = "Tu Cuota ya esta Pagada.Verifica tu cronograma de pagos.";
                    return;
                }


                var amountWallet = decimal.Parse(brWallet.GetAmount(User.Identity.Name.Split('¬')[1]));

                if (amountWallet < decimal.Parse(amount))
                {
                    MessageError.Text = "No tiene el monto suficiente para realizar Pago.";
                    return;
                }


                //amount|@idInfo|@typeInfo|@walletOperationId|@currencyCode|@typeChange|idmembershipDetail|imgTicket
                string data = $"{amount}|{idInfo}|{typeInfo}|{walleOperationId}|PEN|{typeChange}|{idMemberDetails.ToString()}|{imgTicket}";
                bool answer = brWallet.Put(data, User.Identity.Name.Split('¬')[1]);



                if (!answer)
                {
                    MessageError.Text = "Ocurrio un error.";
                    return;
                }
                MessageSucces.Text = "Su Pago de Realizo Con Exito.";

                /*=============================================================================================================================*/


                //marcar como pagado en la tabla membershipdetails
                bool habiliAccount = brUser.enableAcount(idMemberDetails, imgTicket);

                int nAfiliate = int.Parse(brUser.GetNafiliate(idMemberDetails));

                BrTypeMembership brTypeMembership = new BrTypeMembership();
                var correlativo = int.Parse(brTypeMembership.GetTotalMemberships(User.Identity.Name.Split('¬')[1]));

                correlativo--;

                if (correlativo < 0)
                {
                    correlativo = 0;
                }

                Cronograma2(nAfiliate, codeCurrencyPay, correlativo.ToString());

                // enviar el email de confirmacion con la data y lo redirecciona al post register
                if (!habiliAccount)
                {
                    Response.Write("false¬Ha Ocurrido un Error al Intentar Habilitar Su Cuenta.Sin embargo su Pago fue Exitoso");
                    return;
                }


                string ruta = HttpContext.Current.Server.MapPath("~/Resources/PoliticsPdf/");
                //enviar email con los documentos

                Email oEmail = new Email();


                //bool awnserEmailDoc = oEmail.submitEmail(emailNewUser, "[RIBERA DEL RIO - BIENVENIDO]", myMessages.DocumentosRegister(newUserName), true, ruta, newUserNameFile);

                BrInformacion brInformacion = new BrInformacion();
                string[] arrayData = brInformacion.GetBYIdMembershipDetail(idMemberDetails).Split('|');

                string userName = arrayData[0];
                string emailUser = arrayData[1];
                string name = arrayData[2];
                string lastname = arrayData[3];
                string gender = arrayData[4];
                //string codeMemb = arrayData[5].Trim();

                var anwser = false;
                userName = userName + correlativo.ToString();

                if (codeMemb == "KIT")
                {
                    anwser = this.SendEmailKit(name, gender, userName, ruta, emailUser);
                }

                var urlRedirect = "EndPaymendMbs";

                if (codeMemb == "EXP" || codeMemb == "LHT" || codeMemb == "STD" ||
                            codeMemb == "PLUS" || codeMemb == "TOP" || codeMemb == "VIT")
                {
                    urlRedirect = "EndPaymendMbs";
                    anwser = this.SendEmailClub(name, gender, userName, ruta, emailUser);
                }
                if (codeMemb == "EVOL" || codeMemb == "MVC")
                {
                    urlRedirect = "EndPaymendMbs";
                    anwser = this.SendEmailVacational(name, gender, userName, ruta, emailUser);
                }
                if (codeMemb == "SBY")
                {
                    urlRedirect = "EndPaymentSby";
                    anwser = this.SendEmailFounder(name, gender, userName, ruta, emailUser);
                }



                bool awnserEmail = oEmail.SubmitEmail(emailNewUser, "[RIBERA DEL RIO - PAGO]", myMessages.EmailPago());
                MessageSucces.Text += " - y se le envio un correo con su confirmacion. ";


                Response.Redirect($"{urlRedirect}.aspx");

            }
            catch (Exception ex)
            {
                Email email = new Email();
                email.SendEmail(mc.ErrorEmail, "error-inresorts", ex.StackTrace + '¬' + DateTime.Now.ToLongDateString(), false);
            }

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


        public void Cronograma2(int _nAfiliate, string _cc, string correlativo)
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

                string ruta = HttpContext.Current.Server.MapPath("~/Resources/PoliticsPdf/") + $"CRO{username}{correlativo}.pdf";

                string datecur = DateTime.Now.ToString("yyyy;MM;dd;hh;mm;ss;fff");
                string destin = HttpContext.Current.Server.MapPath("~/Resources/trash/") + "CRO" + username + correlativo + datecur + ".pdf";

                if (File.Exists(ruta))
                {
                    File.Move(ruta, destin);
                }

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

        #endregion






        #region MethodsEmail
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
            messagge += "<center><p> Usuario: <b>" + userName + "</b></p><p> Password: <b>" + userName + "</b></p></center></div>";
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
            messagge += "<center><p> Usuario: <b>" + userName + "</b></p><p> Password: <b>" + userName + "</b></p></center></div>";
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


            ////CORREO QUE LE LLEGA A LOS UPLINER 7 LINEAS ARRIBA
            //if (Session["idpatrocinador"] != null && Session["nombreregistrado"] != null && Session["nombrepatrocinador"] != null)
            //{
            //    var idpatrocinador = Session["idpatrocinador"].ToString();
            //    var ListUpliners = brUser.GetUpliners(idpatrocinador);
            //    var filas = ListUpliners.Split('¬');
            //    for (int i = 0; i < filas.Length; i++)
            //    {
            //        var upliner = filas[i].Split('|');
            //        var nombreU = upliner[0];
            //        var correoU = upliner[1];


            //        var nombreregistrado = Session["nombreregistrado"];
            //        var nombrepatrocinador = Session["nombrepatrocinador"];

            //        for (int o = 0; o < filas.Length; o++)
            //        {
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
            //            msjupliners += "<h1 style='margin-top: 2px ;text-align: center;font-weight: bold;font-style: italic;'> Felicitaciones " + nombreU + "</h1>";
            //            msjupliners += "<h2 style='text-align: center;'>hay un nuevo socio en tu red:</h2>";
            //            msjupliners += "";

            //            msjupliners += "<center><div style='width: 100%'>";
            //            //msjupliners += "<p style='margin-left: 10%;margin-right: 10%; '> Click en el boton para validar el pago.</p>";
            //            msjupliners += "<a style='text-decoration: none;'>";
            //            msjupliners += "<center><div style='background: #0d80ea;border-radius:10px;width: 158px;height: 30px;font-size: 16px;color: white;font-weight: bold;padding: 4px;padding-top: 10px;cursor: pointer;text-align: center;margin: 23px;'>Socio: " + nombreregistrado + "<div></center>";
            //            msjupliners += "<center><div style='background: #0d80ea;border-radius:10px;width: 158px;height: 30px;font-size: 16px;color: white;font-weight: bold;padding: 4px;padding-top: 10px;cursor: pointer;text-align: center;margin: 23px;'>Upliner: " + nombrepatrocinador + "<div></center>";
            //            msjupliners += "</a></div></center>";

            //            //msjupliners += "<center><div style='width: 100%'>";
            //            // msjupliners += "<p style='margin-left: 10%;margin-right: 10%; '></p>";
            //            //msjupliners += "<center>Recuerde que el pago lo puede realizar mediante deposito en nuestra cuenta corriente atravez de Agente BCP, Agencia BCP O transferencia bancaria desde Banca por Internet.</center>";
            //            //msjupliners += "</div></center>";

            //            msjupliners += "<div style='margin-left: 9%;'>";
            //            msjupliners += "<p style='margin:5px'>Saludos Cordiales</p><p  style='margin:5px'>Equipo inResorts</p></div>";
            //            msjupliners += "<div style='margin: 5%; width: 70%;background-image: url('https://lh3.googleusercontent.com/NSDQDl8ytJrWSwMe0b3b9DlxubIal-RBEPIWI1a-15f9ynEGQ9eYjTnm-PVqst26f4KJThmjOEPK4lcVoaUw=w1016-h917-rw');'></ div > ";
            //            msjupliners += "<img style='width: 100%' src='https://preview.ibb.co/ixY7iL/fondo222.png'>";
            //            msjupliners += "</div>";

            //            msjupliners += "</body>";
            //            msjupliners += "</html>";

            //            if (string.IsNullOrEmpty(correoU))
            //            {

            //                oemail.submitEmail(correoU, subjet, messagge, true, ruta, userName);
            //            }

            //        }
            //    }
            //}

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
            messagge += "<center><p> Usuario: <b>" + userName + "</b></p><p> Password: <b>" + userName + "</b></p></center></div>";
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




            ////CORREO QUE LE LLEGA A LOS UPLINER 7 LINEAS ARRIBA
            //if (Session["idpatrocinador"] != null && Session["nombreregistrado"] != null && Session["nombrepatrocinador"] != null)
            //{
            //    var idpatrocinador = Session["idpatrocinador"].ToString();
            //    var ListUpliners = brUser.GetUpliners(idpatrocinador);
            //    var filas = ListUpliners.Split('¬');
            //    for (int i = 0; i < filas.Length; i++)
            //    {
            //        var upliner = filas[i].Split('|');
            //        var nombreU = upliner[0];
            //        var correoU = upliner[1];


            //        var nombreregistrado = Session["nombreregistrado"];
            //        var nombrepatrocinador = Session["nombrepatrocinador"];

            //        for (int o = 0; o < filas.Length; o++)
            //        {
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
            //            msjupliners += "<h1 style='margin-top: 2px ;text-align: center;font-weight: bold;font-style: italic;'> Felicitaciones " + nombreU + "</h1>";
            //            msjupliners += "<h2 style='text-align: center;'>hay un nuevo socio en tu red:</h2>";
            //            msjupliners += "";

            //            msjupliners += "<center><div style='width: 100%'>";
            //            //msjupliners += "<p style='margin-left: 10%;margin-right: 10%; '> Click en el boton para validar el pago.</p>";
            //            msjupliners += "<a style='text-decoration: none;'>";
            //            msjupliners += "<center><div style='background: #0d80ea;border-radius:10px;width: 158px;height: 30px;font-size: 16px;color: white;font-weight: bold;padding: 4px;padding-top: 10px;cursor: pointer;text-align: center;margin: 23px;'>Socio: " + nombreregistrado + "<div></center>";
            //            msjupliners += "<center><div style='background: #0d80ea;border-radius:10px;width: 158px;height: 30px;font-size: 16px;color: white;font-weight: bold;padding: 4px;padding-top: 10px;cursor: pointer;text-align: center;margin: 23px;'>Upliner: " + nombrepatrocinador + "<div></center>";
            //            msjupliners += "</a></div></center>";

            //            //msjupliners += "<center><div style='width: 100%'>";
            //            // msjupliners += "<p style='margin-left: 10%;margin-right: 10%; '></p>";
            //            //msjupliners += "<center>Recuerde que el pago lo puede realizar mediante deposito en nuestra cuenta corriente atravez de Agente BCP, Agencia BCP O transferencia bancaria desde Banca por Internet.</center>";
            //            //msjupliners += "</div></center>";

            //            msjupliners += "<div style='margin-left: 9%;'>";
            //            msjupliners += "<p style='margin:5px'>Saludos Cordiales</p><p  style='margin:5px'>Equipo inResorts</p></div>";
            //            msjupliners += "<div style='margin: 5%; width: 70%;background-image: url('https://lh3.googleusercontent.com/NSDQDl8ytJrWSwMe0b3b9DlxubIal-RBEPIWI1a-15f9ynEGQ9eYjTnm-PVqst26f4KJThmjOEPK4lcVoaUw=w1016-h917-rw');'></ div > ";
            //            msjupliners += "<img style='width: 100%' src='https://preview.ibb.co/ixY7iL/fondo222.png'>";
            //            msjupliners += "</div>";

            //            msjupliners += "</body>";
            //            msjupliners += "</html>";

            //            if (string.IsNullOrEmpty(correoU))
            //            {
            //                oemail.submitEmail(correoU, subjet, messagge, true, ruta, userName);
            //            }

            //        }
            //    }
            //}

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
            messagge += "<center><p> Usuario: <b>" + userName + "</b></p><p> Password: <b>" + userName + "</b></p></center></div>";
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

        protected void ProcesarPay_Click(object sender, EventArgs e)
        {
            MyConstants mc = new MyConstants();
            try
            {
                //pagar con wallet
                BrWallet brWallet = new BrWallet();
                var amountWalletc = decimal.Parse(brWallet.GetAmount(User.Identity.Name.Split('¬')[1]));

                var amountTotal = 0m;

                if (Session["MontoWallet"] != null)
                {
                    amountTotal = decimal.Parse(Session["MontoWallet"].ToString());
                }


                var amountRestan = amountTotal - amountWalletc;

                //if (amountWalletc < quota)
                //{
                //    MessageError.Text = "No tiene el monto suficiente para realizar Pago.";
                //    return;
                //}

                var methods2 = "AFTER";

                var recibe = string.Empty;
                if (NowReceipt.Checked)
                {
                    if (!Recibo.HasFile)
                    {
                        MessageError.Text = "No hay imagen.";
                        return;
                    }

                    string[] arraynombreArchivo2 = Recibo.FileName.Split('.');

                    int indice = (arraynombreArchivo2.Length - 1);

                    string extension = arraynombreArchivo2[indice];

                    var nameFile = Guid.NewGuid().ToString();

                    string nombreArchivo = $"{nameFile}.{extension}";
                    string filePath = "~/Resources/RecibosRegister/" + nombreArchivo;

                    Recibo.SaveAs(Server.MapPath(filePath));

                    methods2 = "NOW";
                }


                BrPayments brPayments = new BrPayments();
                BrUser brUser = new BrUser();
                string dataKitMember = Session["cronograma"].ToString();


                string date = dataKitMember.Split('$')[1];

                var cart = Session["carrito"].ToString();

                var arrayCart = cart.Split('|');
                var codeMemb = arrayCart[6];

                string[] datos = Session["datos"].ToString().Split('$');
                var dataBdd = Session["datos"].ToString();



                if (Session["datos"] == null)
                {
                    Response.Write("false¬Ha Ocurrido Un Error, no hay datos.");
                    return;
                }
                string[] arraycontacto = datos[3].Split('|');
                string[] arrayperson = datos[0].Split('|');


                string dni = arrayperson[5];

                //var newUserName = arrayperson[0].Substring(0, 1).ToUpper() + arrayperson[1].Substring(0, 1).ToUpper() + dni;

                var newUserName = User.Identity.Name.Split('¬')[1];
                var emailNewUser = arraycontacto[0].Trim();
                var codeCurrencyPay = Session["TypeCurrency"].ToString();



                string[] array1 = Session["cronogramaYa"].ToString().Split('^');
                string[] datosMem = array1[0].Split('|');
                string[] array2 = array1[1].Split('~');
                string[] cuotas = array2[0].Split('¬');
                string cronoActiv = "";
                var quotesPendiente = (cuotas.Length - 2).ToString();
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

                var respDataper = brPayments.PersonGetData(newUserName);

                string respData = string.Empty;
                respData = respData + '^' + dataKitMember;

                // isRegister = brPayments.GetCalculatePaymentSchedule(respData, newUserName);
                //string data2 = Session["financedAmount"].ToString();

                string data2 = "0";
                //string codeCurrency = Session["TypeCurrency"].ToString();

                var dataRegistern = codeMemb + '|' + newUserName;

                Int32 ansNmembershi = brUser.RegisterNmembership(dataRegistern, data2, 1, codeCurrencyPay);

                if (ansNmembershi <= 1)
                {
                    MessageError.Text = "ocurrio un error";
                    return;
                }

                BrTypeMembership brTypeMemb = new BrTypeMembership();
                string typeChange = arrayCart[4];

                //var isRegister = brPayments.GetCalculatePaymentSchedule(respData, newUserName, ansNmembershi, typeChange, 1);
                bool isRegister = false;
                if (Session["codeUpgrate"] != null)
                {
                    //si es upgrate

                    isRegister = brPayments.GetCalculatePaymentScheduleUpgrate(respData, newUserName, ansNmembershi, typeChange, 1);
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

                    isRegister = brPayments.GetCalculatePaymentSchedule(respData, newUserName, ansNmembershi, typeChange, 1);
                    if (!isRegister)
                    {
                        Response.Write("false¬Ha Ocurrido Un Error al Intentar Registrar el Cronograma de Pagos del Usuario");
                        return;
                    }
                    //cronograma de activacion
                    BrActivation brActivation = new BrActivation();
                    bool registerActi = brActivation.PutCronograma(cronoActiv, newUserName, ansNmembershi);
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
                    bool registerActi = brActivation.PutCronogramaUpgrade(fechaAnterior, newUserName, ansNmembershi, codeUpgrate);


                }
                //validamos si tiene consumo


                if (!isRegister)
                {
                    MessageError.Text = "Ha Ocurrido Un Error al Intentar Registrar el Cronograma de Pagos del Usuario";
                    return;
                }

                //BrActivation brActivation = new BrActivation();
                //bool registerActi = brActivation.PutCronograma(cronoActiv, newUserName, ansNmembershi);

                //obtengo el monto a pagar

                string[] username_idmen_amount_email = brUser.getAmountPay(newUserName).Split('¬');
                if (username_idmen_amount_email.Length < 4)
                {
                    MessageError.Text = "false¬Ha Ocurrido Un Error al Intentar Obtener el monto a Pagar";
                    return;
                }
                var idMemberDetails = int.Parse(username_idmen_amount_email[1]);
                var amountPay = double.Parse(username_idmen_amount_email[2]);
                emailNewUser = username_idmen_amount_email[3];
                codeCurrencyPay = username_idmen_amount_email[4];
                date = null;
                username_idmen_amount_email = null;
                dataKitMember = null;
                respData = null;


                var namePeson = arrayperson[0].Trim() + " " + arrayperson[1].Trim();

                var dateCurrent = DateTime.Now.ToString("yyyy-MM-dd").Split('-');

                string tranferId = "";
                string numReceipt = "0";
                string datecomplete = dateCurrent[2] + " de " + GetMonth(dateCurrent[1]) + " del " + dateCurrent[0];
                string nAffiliate = "";

                string hour = DateTime.Now.ToString("HH:mm:ss");
                string detalle = amountRestan.ToString();
                MyMessages myMessages = new MyMessages();
                namePeson = myMessages.ToCapitalize(namePeson);
                //cvbc
                //var imgTicket = GetRecibo(tranferId, newUserName, numReceipt, datecomplete, nAffiliate, codeMemb, namePeson, hour, detalle, quotesPendiente, " Inicial 1");


                /*=============================================================================================================================*/

                //var currencyCode = Session["CurrencyCode"].ToString();
                BrMembershipPayDetail brMembership = new BrMembershipPayDetail();
                var response = brMembership.GetQuote(idMemberDetails, User.Identity.Name.Split('¬')[1]).Split('|');

                if (decimal.Parse(response[0]) == 0)
                {
                    MessageError.Text = "Ocurrio un error.";
                    return;
                }
                var amount = decimal.Parse(response[0]).ToString();


                if (codeCurrencyPay == "USD")
                {
                    amount = (decimal.Parse(amount) * decimal.Parse(typeChange)).ToString();
                }


                var idInfo = idMemberDetails.ToString();
                //dos es que wallet es una parte del pago de una cuota
                var typeInfo = "2";
                var walleOperationId = "2";

                MessageError.Text = string.Empty;
                MessageWarning.Text = string.Empty;
                MessageSucces.Text = string.Empty;

                bool IsPay = brMembership.IsPayQuote(idMemberDetails.ToString());

                if (!IsPay)
                {
                    MessageWarning.Text = "Tu Cuota ya esta Pagada.Verifica tu cronograma de pagos.";
                    return;
                }


                var amountWallet = decimal.Parse(brWallet.GetAmount(User.Identity.Name.Split('¬')[1]));

                //if (amountWallet < decimal.Parse(amount))
                //{
                //    MessageError.Text = "No tiene el monto suficiente para realizar Pago.";
                //    return;
                //}

                var imgTicket = string.Empty;


                var moneyStatus = 0;

                if (amountWallet > 0)
                {
                    var imgTicketWalle = GetRecibo(tranferId, newUserName, numReceipt, datecomplete, nAffiliate, codeMemb, namePeson, hour, amountWallet.ToString(), quotesPendiente, " Inicial 1");

                    imgTicket += $"{imgTicketWalle}";
                    //amount | @idInfo | @typeInfo | @walletOperationId | @currencyCode | @typeChange | idmembershipDetail | imgTicket
                    string data = $"{amountWallet.ToString()}|{idInfo}|{typeInfo}|{walleOperationId}|PEN|{typeChange}|{idMemberDetails.ToString()}|{imgTicket}";
                    bool answer = brWallet.Put(data, User.Identity.Name.Split('¬')[1], moneyStatus);

                    //Extorno

                    if (!answer)
                    {
                        MessageError.Text = "Ocurrio un error.";
                        return;
                    }
                }
                //MessageSucces.Text = "Su Pago de Realizo Con Exito.";

                /*=============================================================================================================================*/

                var amountOthers = amount;
                //esta en estado pendienete
                var statusPay = 4;

                if (methods2 == "NOW")
                {
                    statusPay = 2;
                }

                //marcar como pagado en la tabla membershipdetails

                //TODO: Agregar los detalles del pago

                bool habiliAccount = brUser.BiPayQuote(idMemberDetails, imgTicket, amountWalletc, amountRestan, "WALLET", methods2, statusPay, decimal.Parse(typeChange));

                int nAfiliate = int.Parse(brUser.GetNafiliate(idMemberDetails));

                BrTypeMembership brTypeMembership = new BrTypeMembership();
                var correlativo = int.Parse(brTypeMembership.GetTotalMemberships(User.Identity.Name.Split('¬')[1]));

                correlativo--;

                if (correlativo < 0)
                {
                    correlativo = 0;
                }

                Cronograma2(nAfiliate, codeCurrencyPay, correlativo.ToString());

                // enviar el email de confirmacion con la data y lo redirecciona al post register
                if (!habiliAccount)
                {
                    Response.Write("false¬Ha Ocurrido un Error al Intentar Habilitar Su Cuenta.Sin embargo su Pago fue Exitoso");
                    return;
                }


                var urlRedirect = "EndPayments3";

                if (NowReceipt.Checked)
                {
                    urlRedirect = "EndPayments2";
                }


                try
                {
                    Response.Redirect($"{urlRedirect}.aspx");
                }
                catch (Exception)
                {
                    Response.Redirect($"{urlRedirect}.aspx");
                }


            }
            catch (Exception ex)
            {
                Email email = new Email();
                email.SendEmail(mc.ErrorEmail, "error-inresorts", ex.StackTrace + '¬' + DateTime.Now.ToLongDateString(), false);
            }

        }
    }
}