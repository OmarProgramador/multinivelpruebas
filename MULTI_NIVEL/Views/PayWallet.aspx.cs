using BussinesRules;
using BussinesRules.User;
using Entities;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Security;

namespace MULTI_NIVEL.Views
{
    public partial class PayWallet : System.Web.UI.Page
    {
        string def = "profile.png";
        string extension = ".png";
        string name = "";
        string nombreu = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            //hasta ahora 4 
            //nombree completo ¬ userName ¬ id person¬ status payments
            if (!IsPostBack)
            {
                MyConstants mc = new MyConstants();
                try
                {
                    //login con usuario y contraseña
                    MessageError.Text = string.Empty;
                    MessageSucces.Text = string.Empty;
                    MessageWarning.Text = string.Empty;

                    BrTypeChange brTypeChange = new BrTypeChange();
                    var arraytypes = brTypeChange.GetTypesChange().Split('|');
                    var typechangeVenta = decimal.Parse(arraytypes[0]);
                    var typechangeCompra = decimal.Parse(arraytypes[1]);

                    BrWallet brWallet = new BrWallet();
                    var amountWallet = decimal.Parse(brWallet.GetAmount(User.Identity.Name.Split('¬')[1]));

                    //borrar cuando cambias el monto a dolares el wallet
                    //amountWallet = amountWallet / typechangeCompra;

                    Wallet.Text = $"Wallet: {amountWallet.ToString(mc.NumberFormat)}";

                    var obj = HttpContext.Current.User.Identity.Name.Split('¬');
                    this.lblUser.Text = "Hola " + obj[0];
                    this.lblUserName.Text = obj[0];
                    if (obj.Length > 2)
                    {
                        this.lblNumPartner.Text = "N° Asociado: " + obj[4];
                    }

                    this.imgProfile.ImageUrl = "~/Resources/Images/profile.png";
                    this.imgProfileFl.ImageUrl = "~/Resources/Images/profile.png";

                    var description = string.Empty;
                    var amountPay = string.Empty;
                    var currencyCodecro = string.Empty;


                    if (Session["numCuota"] != null)
                    {
                        description = Session["numCuota"].ToString();
                    }
                    if (Session["quotePay"] != null)
                    {
                        amountPay = Session["quotePay"].ToString();
                    }
                    if (Session["CurrencyCode"] != null)
                    {
                        currencyCodecro = Session["CurrencyCode"].ToString();
                    }

                    Description.Text = description;
                    Monto.Text = $"{amountPay} {currencyCodecro}";

                    var amountTotal = decimal.Parse(amountPay);

                    Session["amountpaywallet"] = amountTotal.ToString();

                    if (Session["StatusCalendar"] == null || Session["CurrencyCode"] == null)
                    {
                        MessageError.Text = "Ocurrio un error.";
                        return;
                    }

                    //monto del wallet viene en dolares

                    decimal resta = 0;

                    CurrencyCode.Text = currencyCodecro;
                    CurrencyCode1.Text = currencyCodecro;
                    CurrencyCode2.Text = currencyCodecro;

                    ddlcurrencyCode.SelectedValue = currencyCodecro;

                    var tcCro = decimal.Parse(Session["tcCro"].ToString());

                    if (currencyCodecro == "PEN")
                    {
                        amountWallet = (amountWallet * typechangeCompra);
                        resta = amountTotal - amountWallet;
                        PayIn.Style.Add("display", "none");
                        TypeChange.Text = tcCro.ToString();
                    }

                    //AmountSolesRes.Style.Add("display","none");
                    //AmountSolesRes2.Style.Add("display","none");
                    decimal surcharge = (1 + mc.Surcharge);

                    if (currencyCodecro == "USD")
                    {
                        resta = amountTotal - amountWallet;
                        TypeChange.Text = typechangeVenta.ToString();

                        //AmountSolesRes.Style.Add("display", "inline-block");
                        //AmountSolesRes2.Style.Add("display", "inline-block");

                        AmountSolesRes.Text = (resta * typechangeVenta).ToString("0.00");
                        AmountSolesRes2.Text = ((resta * surcharge) * typechangeVenta).ToString("0.00");
                    }

                    LblAmountWallet.Text = $"{amountWallet.ToString("0.00")}";
                    LblAmountCulqi.Text = $"{(resta * surcharge).ToString("0.00")}";
                    LblAmountDeposit.Text = $"{resta.ToString("0.00")}";

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

                    // Imagen de PErfil
                    var rutaImgP = HttpContext.Current.Server.MapPath("~/Resources/imguser");
                    DirectoryInfo di1 = new DirectoryInfo(rutaImgP);
                    nombreu = obj[1];
                    foreach (var fi2 in di1.GetFiles())
                    {
                        var archivo = fi2.Name.Split('.');
                        name = archivo[archivo.Length - 2];
                        extension = archivo[archivo.Length - 1];
                        if (name == nombreu) { def = nombreu + "." + extension; }
                    }
                    imgProfile.ImageUrl = "~/Resources/imguser/" + def;
                    imgProfile.Style.Add("width", "40px");
                    imgProfile.Style.Add("height", "40px");
                    imgProfile.Style.Add("margin", "0 auto");
                    imgProfileFl.ImageUrl = "~/Resources/imguser/" + def;
                    imgProfileFl.Style.Add("width", "80px");
                    imgProfileFl.Style.Add("height", "80px");
                    imgProfileFl.Style.Add("margin", "0 auto");


                    for (int i = 0; i < 32; i++)
                    {
                        DdlQuote.Items.Add((i + 1).ToString());
                    }


                }
                catch (Exception ex)
                {
                    Email email = new Email();
                    //email.SendEmail(mc.ErrorEmail, "error-inresorts", ex.Message + '¬' + DateTime.Now.ToLongDateString(), false);
                }
            }
        }
        protected void lblSalir_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            HttpContext.Current.Response.Redirect("Index.aspx", true);
        }

        protected void PayByWallet_Click(object sender, EventArgs e)
        {
            decimal amount = 0, typeChangeVentaCurrent = 0, typechangecompraCurrent = 0;
            string numcuota = string.Empty;
            string idInfo = string.Empty, typeInfo = string.Empty, walleOperationId = string.Empty;
            string currencyCode = string.Empty;
            string imgTicket = string.Empty;
            decimal amountWallet = 0;
            string idMembershipDetail = string.Empty;

            decimal typechangesend = 0;


            currencyCode = ddlcurrencyCode.SelectedValue.Trim();

            if (currencyCode != "USD" && currencyCode != "PEN")
            {
                MessageError.Text = "ocurrio un error.";
                return;
            }



            if (Session["StatusCalendar"] == null || Session["CurrencyCode"] == null)
            {
                MessageError.Text = "Ocurrio un error.";
                return;
            }
            idMembershipDetail = int.Parse(Session["StatusCalendar"].ToString()).ToString();
            imgTicket = $"{idMembershipDetail}{DateTime.Now.ToString("yyyyMMdd")}";

            //

            BrTypeChange tc = new BrTypeChange();

            var arraytypechan = tc.GetTypesChange().Split('|');
            typeChangeVentaCurrent = decimal.Parse(arraytypechan[0]);
            typechangecompraCurrent = decimal.Parse(arraytypechan[1]);



            BrMembershipPayDetail brMembership = new BrMembershipPayDetail();
            var response = brMembership.GetQuote(int.Parse(idMembershipDetail), User.Identity.Name.Split('¬')[1]).Split('|');

            if (decimal.Parse(response[0]) == 0)
            {
                MessageError.Text = "Ocurrio un error.";
                return;
            }
            //el monto llega deacuerdo al currency code del cronograma 
            amount = decimal.Parse(response[0]);
            var currencyCodeCro = response[2];
            var typechangeCro = decimal.Parse(response[4]);

            idInfo = "1";
            typeInfo = "1";
            walleOperationId = "2";


            MessageError.Text = string.Empty;
            MessageWarning.Text = string.Empty;
            MessageSucces.Text = string.Empty;

            bool IsPay = brMembership.IsPayQuote(idMembershipDetail);

            if (!IsPay)
            {
                MessageWarning.Text = "Tu Cuota ya esta Pagada.Verifica tu cronograma de pagos.";
                return;
            }

            BrWallet brWallet = new BrWallet();
            MyMessages myMessages = new MyMessages();
            MyFunctions mf = new MyFunctions();


            var namePeson = mf.ToCapitalize(User.Identity.Name.Split('¬')[0].ToLower());

            var dateCurrent = DateTime.Now.ToString("yyyy-MM-dd").Split('-'); ;

            string tranferId = "";
            string numReceipt = "0";
            string datecomplete = dateCurrent[2] + " de " + mf.GetMonth(dateCurrent[1]) + " del " + dateCurrent[0];
            string nAffiliate = "";

            string hour = DateTime.Now.ToString("HH:mm:ss");
            string detalle = amount.ToString() + $" {currencyCode}";
            string quotesPendiente = "";
            string codeMemb = "";

            string descripcion = string.Empty;

            if (Session["numCuota"] != null)
            {
                descripcion = Session["numCuota"].ToString();
            }

            namePeson = myMessages.ToCapitalize(namePeson);
            //cvbc

            amountWallet = decimal.Parse(brWallet.GetAmount(User.Identity.Name.Split('¬')[1]));
            //el monto de wallet viene en dolares.

            if (currencyCodeCro == "PEN")
            {
                if ((amountWallet * typechangeCro) < amount)
                {
                    MessageError.Text = "No tiene el monto suficiente para realizar Pago.";
                    return;
                }

                detalle = amount.ToString() + $" {currencyCode}";
                //tipo de moneda en soles
                imgTicket = GetRecibo(tranferId, User.Identity.Name.Split('¬')[1], numReceipt, datecomplete, nAffiliate, codeMemb, namePeson, hour, detalle, quotesPendiente, $" {descripcion}");

                //en este caso el amount esta en soles y le aplicamos elm tipo de cambioo
                typechangesend = typechangeCro;
            }

            if (currencyCodeCro == "USD")
            {

                if (amountWallet < amount)
                {
                    MessageError.Text = "No tiene el monto suficiente para realizar Pago.";
                    return;
                }

                //tipo de moneda en dolares

                if (currencyCode == "USD")
                {
                    detalle = amount.ToString() + $" {currencyCode}";
                    imgTicket = GetRecibo(tranferId, User.Identity.Name.Split('¬')[1], numReceipt, datecomplete, nAffiliate, codeMemb, namePeson, hour, detalle, quotesPendiente, $" {descripcion}");
                }

                amount = amount * typechangecompraCurrent;
                typechangesend = typechangecompraCurrent;

                if (currencyCode == "PEN")
                {
                    detalle = amount.ToString() + $" {currencyCode}";
                    imgTicket = GetRecibo(tranferId, User.Identity.Name.Split('¬')[1], numReceipt, datecomplete, nAffiliate, codeMemb, namePeson, hour, detalle, quotesPendiente, $" {descripcion}");
                }
            }


            //amount|@idInfo|@typeInfo|@walletOperationId|@currencyCode|@typeChange|idmembershipDetail|imgTicket
            string data = $"{amount}|{idInfo}|{typeInfo}|{walleOperationId}|{currencyCode}|{typechangesend}|{idMembershipDetail}|{imgTicket}";
            bool answer = brWallet.Put(data, User.Identity.Name.Split('¬')[1]);


            if (!answer)
            {
                MessageError.Text = "Ocurrio un error.";
                return;
            }

            MessageSucces.Text = "Su Pago de Realizo Con Exito.";

            var urlRedirect = "EndPaymentQuote";

            //Email oEmail = new Email();
            //bool awnserEmail = oEmail.submitEmail(emailNewUser, "[RIBERA DEL RIO - PAGO]", myMessages.EmailPago());
            //MessageSucces.Text += " - y se le envio un correo con su confirmacion. ";


            Response.Redirect($"{urlRedirect}.aspx");

        }

        #region Methods
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

        #endregion

        protected void ProcesarPay_Click(object sender, EventArgs e)
        {

            var idMemberDetails = 0;
            var typeChangeSend = 0m;
            var typeChangecurrent = 0m;

            typeChangecurrent = decimal.Parse(User.Identity.Name.Split('¬')[4]);

            BrWallet brWallet = new BrWallet();
            var amountWallet = decimal.Parse(brWallet.GetAmount(User.Identity.Name.Split('¬')[1]));

            if (!(amountWallet > 0))
            {
                MessageError.Text = "ocurrio un error";
                return;
            }

            string currencyCode = ddlcurrencyCode.SelectedValue;

            if (Session["quotePay"] == null || Session["numCuota"] == null)
            {
                MessageError.Text = "Ocurrio un error.";
                return;
            }
            var totalPay = decimal.Parse(Session["quotePay"].ToString());

            var description = Session["numCuota"].ToString();

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

                recibe = $"{nameFile}.{extension}";
                string filePath = "~/Resources/RecibosRegister/" + recibe;

                Recibo.SaveAs(Server.MapPath(filePath));

                methods2 = "NOW";
            }


            if (Session["StatusCalendar"] == null || Session["CurrencyCode"] == null)
            {
                MessageError.Text = "Ocurrio un error.";
                return;
            }

            idMemberDetails = int.Parse(Session["StatusCalendar"].ToString());

            BrMembershipPayDetail brMembership = new BrMembershipPayDetail();
            var response = brMembership.GetQuote(idMemberDetails, User.Identity.Name.Split('¬')[1]).Split('|');

            if (decimal.Parse(response[0]) == 0)
            {
                MessageError.Text = "Ocurrio un error.";
                return;
            }
            var amount = decimal.Parse(response[0]);
            var currencycodecro = response[2];

            var typechangecro = decimal.Parse(response[4]);



            BrTypeChange tc = new BrTypeChange();
            MyMessages mm = new MyMessages();
            MyFunctions mf = new MyFunctions();

            var arraytypechan = tc.GetTypesChange().Split('|');
            var typeChangeVentaCurrent = decimal.Parse(arraytypechan[0]);
            var typechangecompraCurrent = decimal.Parse(arraytypechan[1]);

            decimal amountRestan = 0;
            decimal amountWalletSoles = 0;


            var idInfo = idMemberDetails.ToString();
            var imgTicketWalle = "";
            var namePeson = User.Identity.Name.Split('¬')[0];
            var dateCurrent = DateTime.Now.ToString("yyyy-MM-dd").Split('-');
            string tranferId = "";
            string numReceipt = "0";
            string datecomplete = dateCurrent[2] + " de " + mf.GetMonth(dateCurrent[1]) + " del " + dateCurrent[0];
            string nAffiliate = "";
            string hour = DateTime.Now.ToString("HH:mm:ss");
            namePeson = mm.ToCapitalize(namePeson);
            var moneyStatus = 1;

            if (currencycodecro == "PEN")
            {
                if (currencyCode == "PEN")
                {
                    typeChangeSend = typechangecompraCurrent;
                    amountWalletSoles = amountWallet * typechangecompraCurrent;

                    amountRestan = amount - amountWalletSoles;

                    imgTicketWalle = GetRecibo(tranferId, User.Identity.Name.Split('¬')[1], numReceipt, datecomplete, nAffiliate, "", namePeson, hour, amountWalletSoles.ToString(), "", $" {description}");

                    SendEmailAmountRestante(amountRestan.ToString("0.00"), amountWalletSoles.ToString("0.00"), amount.ToString("0.00"), idInfo, description, currencyCode);

                }

                if (currencyCode == "USD")
                {
                    typeChangeSend = typechangecro;

                    amountRestan = (amount / typechangecro) - amountWallet;

                    imgTicketWalle = GetRecibo(tranferId, User.Identity.Name.Split('¬')[1], numReceipt, datecomplete, nAffiliate, "", namePeson, hour, amountWallet.ToString(), "", $" {description}");

                    SendEmailAmountRestante(amountRestan.ToString("0.00"), amountWallet.ToString("0.00"), (amount / typechangecro).ToString("0.00"), idInfo, description, currencyCode);
                }
            }

            if (currencycodecro == "USD")
            {
                if (currencyCode == "USD")
                {
                    amountRestan = amount - amountWallet;

                    imgTicketWalle = GetRecibo(tranferId, User.Identity.Name.Split('¬')[1], numReceipt, datecomplete, nAffiliate, "", namePeson, hour, amountWallet.ToString(), "", $" {description}");

                    SendEmailAmountRestante(amountRestan.ToString("0.00"), amountWallet.ToString("0.00"), amount.ToString("0.00"), idInfo, description, currencyCode);
                }

                amount = amount * typechangecompraCurrent;
                typeChangeSend = typechangecompraCurrent;

                if (currencyCode == "PEN")
                {
                    amountWalletSoles = amountWallet * typechangecompraCurrent;
                    amountRestan = amount - amountWalletSoles;

                    imgTicketWalle = GetRecibo(tranferId, User.Identity.Name.Split('¬')[1], numReceipt, datecomplete, nAffiliate, "", namePeson, hour, amountWalletSoles.ToString(), "", $" {description}");

                    SendEmailAmountRestante(amountRestan.ToString("0.00"), amountWalletSoles.ToString("0.00"), amount.ToString("0.00"), idInfo, description, currencyCode);
                }
            }


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


            if (amountWallet > 0)
            {

                if (string.IsNullOrEmpty(recibe))
                {
                    recibe += $"{imgTicketWalle}";
                }
                else
                {
                    recibe += $"~{imgTicketWalle}";
                }
                //amount | @idInfo | @typeInfo | @walletOperationId | @currencyCode | @typeChange | idmembershipDetail | imgTicket
                string data = $"{(amountWallet * typeChangeSend).ToString()}|{idInfo}|{typeInfo}|{walleOperationId}|PEN|{typeChangeSend}|{idMemberDetails.ToString()}|{recibe}";
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
            BrUser brUser = new BrUser();

            bool habiliAccount = brUser.BiPayQuote(idMemberDetails, recibe, amountWallet * typeChangeSend, amountRestan, "WALLET", methods2, statusPay, typeChangeSend);

            var amountTot = amountWallet + amountRestan;



            if (habiliAccount)
            {
                Response.Redirect("EndPaymentQuote.aspx");
            }
        }



        public void SendEmailAmountRestante(string amountRestn, string amountWalllet, string amountTotal, string idMembershipDetail, string description, string currencyCode)
        {
            var symbol = "S/";
            var moneleter = "en Soles";

            MyConstants mc = new MyConstants();
            MyFunctions mf = new MyFunctions();
            var bankAccount = mc.BankAccount;

            if (currencyCode == "USD")
            {
                symbol = "$";
                bankAccount = mc.BankAccountDolar;
                moneleter = "en Dolares";
            }



            //1|Omar Fernando|Urteaga Cabrera|14/01/1983|M|omarurteaga@gmail.com|938627011||Peru|Lima|Lima|addres|DNI|41958311|1|admin987|Solter(a)
            BrUser brPerson = new BrUser();
            var arrayperson = brPerson.GetPersonalInformation(User.Identity.Name.Split('¬')[1]).Split('|');

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
            cuerpo += $"<center><p style='margin-left: 10%;margin-right: 10%;'>Monto Wallet : {symbol} " + amountWalllet + "</p></center> ";
            cuerpo += $"<center><p style='margin-left: 10%;margin-right: 10%;'>Monto Deposito : {symbol} " + amountRestn + "</p></center> ";
            cuerpo += "<center><p style='margin-left: 10%;margin-right: 10%;'>========================================</p></center> ";
            cuerpo += $"<center><p style='margin-left: 10%;margin-right: 10%;'>Monto Total : {symbol} " + amountTotal + "</p></center> ";
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
            cuerpo += $"<p style='margin-left: 10%;margin-right: 10%; '>Cuenta Bancaria {moneleter}</p>";
            cuerpo += $"<center>BCP: N° {bankAccount} - Valle Encantado S.A.C</center>";
            cuerpo += "</div></center>";

            cuerpo += "<center><div style='width: 50%;display: flex;border-radius: 10px;margin: 11px;'>";
            cuerpo += "<p style='margin-left: 10%;margin-right: 10%;'>Monto a depositar</p>";

            cuerpo += $"<center style=' margin: 12px;'> {symbol} {amountRestn} ( {currencyCode} )</center>";
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

    }
}