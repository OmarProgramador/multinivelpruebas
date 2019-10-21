using BussinesRules;
using BussinesRules.Code;
using BussinesRules.TypeMembership;
using BussinesRules.User;
using Entities;
using System;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace MULTI_NIVEL.Views
{
    public partial class AddMembership : System.Web.UI.Page
    {
        string def = "profile.png";
        string extension = ".png";
        string name = "";
        string nombreu = "";

        int[] listNUmberDate;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                var arrayLogin = HttpContext.Current.User.Identity.Name.Split('¬');
                cbxPred.Checked = false;
                if (arrayLogin.Length == 1)
                {
                    Response.Redirect("Register.aspx", true);
                }
                if (!IsPostBack)
                {
                    Session.RemoveAll();
                    this.lblUser.Text = "Hola " + arrayLogin[0];
                    this.lblUserName.Text = arrayLogin[0];
                    this.lblNumPartner.Text = "N° Asociado: " + arrayLogin[4];
                    this.imgProfile.ImageUrl = "~/Resources/Images/profile.png";
                    this.imgProfileFl.ImageUrl = "~/Resources/Images/profile.png";

                    BrTypeMembership brTypeMembership = new BrTypeMembership();
                    string[] rowTypeMembership = brTypeMembership.GetTypeMembership().Split('¬');
                    string[] aListMyMembership = brTypeMembership.GetListAccount(arrayLogin[1]).Split('¬');

                    brTypeMembership = null;

                    //Kit de Inicio | 10.00 | 1 | 10.00 | 0.00¬
                    //Experience ¬Light ¬Standard ¬Plus ¬Top
                    string[] dataKit = rowTypeMembership[0].Split('|');
                    string[] dataexp = rowTypeMembership[1].Split('|');
                    string[] datalig = rowTypeMembership[2].Split('|');
                    string[] datasta = rowTypeMembership[3].Split('|');
                    string[] dataplus = rowTypeMembership[4].Split('|');
                    string[] datatop = rowTypeMembership[5].Split('|');
                    string[] datamd = rowTypeMembership[6].Split('|');
                    string[] dataVital = rowTypeMembership[7].Split('|');
                    string[] dataEvol = rowTypeMembership[8].Split('|');
                    string[] dataStBy = rowTypeMembership[9].Split('|');

                    //mostramos los datos
                    //nombre | initial | numquote | amountotal | points
                    txtInitialEXP.Text = double.Parse(dataexp[1]).ToString();
                    txtNumCuEXP.Text = dataexp[2];
                    montoinicialexp.Text = "$" + double.Parse(dataexp[1]).ToString();
                    montototalexp.Text = "$" + double.Parse(dataexp[3]).ToString();

                    txtInitialLigh.Text = double.Parse(datalig[1]).ToString();
                    txtNumCuLigh.Text = datalig[2];
                    montoiniciallig.Text = "$" + double.Parse(datalig[1]).ToString();
                    montototallig.Text = "$" + double.Parse(datalig[3]).ToString();

                    txtInitialSTA.Text = double.Parse(datasta[1]).ToString();
                    txtNumCuSTA.Text = datasta[2];
                    montoinicialsta.Text = "$" + double.Parse(datasta[1]).ToString();
                    montototalsta.Text = "$" + double.Parse(datasta[3]).ToString();

                    txtInitialPLU.Text = double.Parse(dataplus[1]).ToString();
                    txtNumCuPLU.Text = dataplus[2];
                    montoinicialplu.Text = "$" + double.Parse(dataplus[1]).ToString();
                    montototalplu.Text = "$" + double.Parse(dataplus[3]).ToString();

                    txtInitialTOP.Text = double.Parse(datatop[1]).ToString();
                    txtNumCuTOP.Text = datatop[2];
                    montoinicialtop.Text = "$" + double.Parse(datatop[1]).ToString();
                    montototaltop.Text = "$" + double.Parse(datatop[3]).ToString();

                    txtInitialMd.Text = double.Parse(datamd[1]).ToString();
                    txtNumCuMd.Text = datamd[2];
                    lblMontoInicialMd.Text = "$" + double.Parse(datamd[1]).ToString();
                    lblMontoTotalMd.Text = "$" + double.Parse(datamd[3]).ToString();

                    txtInitialVit.Text = double.Parse(dataVital[1]).ToString();
                    txtNumCuVit.Text = dataVital[2];
                    montoinicialVit.Text = "$" + double.Parse(dataVital[1]).ToString();
                    montototalVit.Text = "$" + double.Parse(dataVital[3]).ToString();


                    txtInitialEvol.Text = double.Parse(dataEvol[1]).ToString();
                    txtNumCuEvol.Text = dataEvol[2];
                    lblMontoInicialEvol.Text = "$" + double.Parse(dataEvol[1]).ToString();
                    lblMontoTotalEvol.Text = "$" + double.Parse(dataEvol[3]).ToString();

                    txtInitialSby.Text = double.Parse(dataStBy[1]).ToString();
                    txtNumCuSby.Text = dataStBy[2];
                    lblMontoInicialSby.Text = "$" + double.Parse(dataStBy[1]).ToString();
                    lblMontoTotalSby.Text = "$" + double.Parse(dataStBy[3]).ToString();



                    //validamos si tiene membresia
                    BrUser brUser = new BrUser();
                    int idMember = int.Parse(brUser.GetMembershipType(arrayLogin[1]));
                    brUser = null;
                    //if (idMember == 7)
                    //{
                    //    hpStore.NavigateUrl = "Store.aspx";
                    //}
                    //else
                    //{
                    //    hpStore.NavigateUrl = "AddMembership.aspx";
                    //}

                    for (int i = 0; i < aListMyMembership.Length; i++)
                    {
                        string[] row = aListMyMembership[i].Split('|');
                        if (i == 0 && row.Length == 1)
                        {
                            rbUpgrade.Enabled = false;
                        }
                        if (row.Length > 1)
                        {
                            ddlMysMembership.Items.Add(new ListItem { Value = row[0], Text = row[1] });
                        }
                    }

                    listNUmberDate = daysToChoose(arrayLogin[6]);

                    int monthC = DateTime.Now.Month;
                    string monthCurrent = GetMonth(monthC);
                    string monthNext = GetMonth(monthC + 1);
                    string stringMonth = monthCurrent;
                    //el dia de pago de cuotas
                    for (int i = 0; i < listNUmberDate.Length; i++)
                    {
                        if (listNUmberDate[i] == 0)
                        {
                            stringMonth = monthNext;
                        }
                        if (listNUmberDate[i] != 0)
                        {
                            //ListItem item = new ListItem(listNUmberDate[i].ToString(), listNUmberDate[i].ToString());
                            ListItem item = new ListItem(listNUmberDate[i].ToString(), listNUmberDate[i].ToString() + "_" + stringMonth);
                            item.Attributes["data-category"] = stringMonth;
                            ddlDateCuotas.Items.Add(item);
                            item = null;
                        }
                    }
                    cbConfig.Checked = false;

                    if (!cbConfig.Checked)
                    {
                        ddlDateCuotas.Enabled = false;
                    }


                    // Imagen de PErfil
                    var rutaImgP = HttpContext.Current.Server.MapPath("~/Resources/imguser");
                    DirectoryInfo di1 = new DirectoryInfo(rutaImgP);
                    nombreu = arrayLogin[1];
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
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("error.aspx?error=" + ex.Message, true);
            }
        }

        protected void btnBuy_Click(object sender, EventArgs e)
        {
            string option = "", codeMembers = "", descripMem = "", userName = "", fecha = "", arrayfechas = "";
            double valorMembresia = 0, initialFee = 0, tipocambio = 0, amountUpgrate = 0, initialFeeU = 0, discount = 0, intAnual = 0;
            int numQuotes = 0, numQuotesBefore = 0, numQuotesInitial = 0;
            var infoLogin = HttpContext.Current.User.Identity.Name.Split('¬');
            cbxPred.Checked = false;

            //borramos la session existenete
            Session.Remove("codeUpgrate");
            Session.Remove("TypeCurrency");
            BrAccount brAccount = new BrAccount();
            MyFunctions mf = new MyFunctions();

            var affliate = brAccount.GetAffiliateName(infoLogin[1]);

            if (!string.IsNullOrEmpty(affliate))
            {
                affliate = mf.ToCapitalize(affliate.Trim().ToLower());
            }


            tipocambio = double.Parse(User.Identity.Name.Split('¬')[5]);

            Session["patrocinador"] = affliate;

            
            Session["TypeCurrency"] = "USD";

            if (cbxPred.Checked)
            {
                Session["membPred"] = "1";
            }
            else
            {
                Session["membPred"] = "0";
            }
            userName = infoLogin[1];
            lblMessagge.Text = "";
            if (rbnNewPackage.Checked)
            {
                option = "np";
            }
            if (rbUpgrade.Checked)
            {
                option = "ug";
            }
            Session["option"] = option;

            if (option == "np")
            {
                if (Session["codeDiscount"] != null)
                {
                    string[] codeDiscount = Session["codeDiscount"].ToString().Split('|');

                    if (codeDiscount.Length > 1)
                    {
                        discount = double.Parse(codeDiscount[1]);
                    }
                }

                string[] aInfo = Membershipselected(discount).Split('|');

                if (aInfo[0] == "error")
                {
                    return;
                }

                BrUser brUser = new BrUser();
                BrPayments brPayments = new BrPayments();
                Validation val = new Validation();
                Numalet num = new Numalet();
                MyConstants myConstants = new MyConstants();

                codeMembers = aInfo[0];
                initialFeeU = num.TwoDecimas(double.Parse(aInfo[1]));
                numQuotesInitial = int.Parse(aInfo[2]);
                numQuotes = int.Parse(aInfo[3]);

                //amount¬quoteInitial¬numQuotes¬descripcioon¬fecha¬tipocambio  ---se le envia el code de la membership
                string[] aInfoMember = brPayments.GetAmountTotal(codeMembers).Split('¬');
                int minQuotes = 0;
                minQuotes = int.Parse(aInfoMember[6]);
                //idperson¬name¬lastname¬birthday¬gender¬email¬phone1¬phone2¬pais¬state¬city¬address¬typedoc¬numdoc
                string[] aInfoPerson = brUser.GetPersonalInformation(infoLogin[1]).Split('|');
                if (aInfoPerson.Length == 1)
                {
                    lblMessagge.Text = "Usted no esta apto para comprar una membresia, Por favor regularizar su situación.";
                    return;
                }

                Session["civilState"] = aInfoPerson[16];
                for (int i = 0; i <= 15; i++)
                {
                    if (i != 7)
                    {
                        if (string.IsNullOrEmpty(aInfoPerson[i]))
                        {
                            lblMessagge.Text = "Ir a 'Mi Perfil' y Actualize Todos Sus Datos.";
                            return;
                        }
                    }
                }
                valorMembresia = double.Parse(aInfoMember[0]);
                descripMem = aInfoMember[3];
                initialFee = (initialFeeU * numQuotesInitial);
                tipocambio = double.Parse(aInfoMember[5]);
                intAnual = myConstants.AmountInteresAnual;
                fecha = DateTime.Parse(aInfoMember[4]).ToString(myConstants.DateFormatBd);

                string fechaFirtsQuote = infoLogin[6];

                listNUmberDate = daysToChoose(infoLogin[6]);

                string[] arrayDate = (DateTime.Parse(infoLogin[6]).ToString(myConstants.DateFormatBd)).Split('-');

                if (cbConfig.Checked)
                {
                    string fechaConfig = "";
                    int monthPay = int.Parse(arrayDate[1]);
                    try
                    {
                        fechaConfig = int.Parse(ddlDateCuotas.SelectedItem.Value.ToString().Split('_')[0].Trim()).ToString("00");
                        monthPay = GetMonth(ddlDateCuotas.SelectedItem.Value.ToString().Split('_')[1].Trim());
                        monthPay--;
                    }
                    catch (Exception)
                    {
                        Response.Redirect("Register.aspx");
                    }

                    int value = Array.IndexOf(listNUmberDate, int.Parse(fechaConfig));
                    if (value < 0 && value > 30)
                    {
                        lblMessagge.Text = "El valor que ha elejido como dia de pago no es valido";
                        return;
                    }
                    if (!string.IsNullOrEmpty(fechaConfig) && value > -1 && value < 30)
                    {
                        string fechaFor = arrayDate[0] + '-' + monthPay.ToString("00") + '-' + fechaConfig;
                        fecha = DateTime.Parse(fechaFor).ToString(myConstants.DateFormatBd);
                    }
                }

                arrayfechas = "";
                string fechas = fecha;

                for (var i = 0; i < numQuotesInitial; i++)
                {
                    if (i > 0)
                    {
                        arrayfechas += '|' + fechas + '|' + initialFeeU.ToString();
                    }
                    else
                    {
                        arrayfechas += fechaFirtsQuote + '|' + initialFeeU.ToString();
                    }
                    fechas = ((Convert.ToDateTime(fechas)).AddMonths(1)).ToString(myConstants.DateFormatBd);
                }

                MyFunctions myFunctions = new MyFunctions();
                BrCode brCode = new BrCode();
                string responseCode = brCode.GetCodeSecreto(txtCodSecreto.Text);

                if (string.Compare(txtCodSecreto.Text, responseCode, false) == 0)
                {
                    arrayfechas = "";
                    try
                    {
                        if (numQuotesInitial >= 2)
                        {
                            double firtsQuote = double.Parse(QuoteFirts.Text);
                            firtsQuote = firtsQuote * tipocambio;
                            DateTime firtsDate = DateTime.Parse(myFunctions.DateFormatBd(DateFirts.Text));

                            var dateMax = DateTime.Now.AddDays(45);
                            if (dateMax < firtsDate)
                            {
                                lblMessagge.Text = "La Fecha de la Primera Cuota Supera un Mes despues de la fecha actual";
                                return;
                            }

                            double secondQuote = double.Parse(QuoteSecond.Text);
                            secondQuote = secondQuote * tipocambio;
                            DateTime secondDate = DateTime.Parse(myFunctions.DateFormatBd(DateSecond.Text));

                            arrayfechas += firtsDate.ToString(myConstants.DateFormatBd) + '|' + firtsQuote.ToString() + "|";
                            arrayfechas += secondDate.ToString(myConstants.DateFormatBd) + '|' + secondQuote.ToString();
                            fechas = secondDate.AddMonths(1).ToString(myConstants.DateFormatBd);
                            if (numQuotesInitial > 2)
                            {
                                double thirdQuote = double.Parse(QuoteThird.Text);
                                thirdQuote = thirdQuote * tipocambio;
                                DateTime thirdDate = DateTime.Parse(myFunctions.DateFormatBd(DateThird.Text));
                                arrayfechas += "|" + thirdDate.ToString(myConstants.DateFormatBd) + '|' + thirdQuote.ToString();
                                fechas = thirdDate.AddMonths(1).ToString(myConstants.DateFormatBd);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        string error = ex.Message;
                        lblMessagge.Text = "Fechas de Cuotas Obligatorias.";
                        return;
                    }
                }

                Session["datos"] = aInfoPerson[1] + "|" +
                aInfoPerson[2] + "|" +
                aInfoPerson[3] + "|" +
                aInfoPerson[4] + "|" +
                aInfoPerson[12] + "|" +
                aInfoPerson[13] +
                "$ | | | |$ | | | | | | | $" +
                aInfoPerson[5] + "|" +
                aInfoPerson[6] + "|" +
                aInfoPerson[7] + "|" +
                aInfoPerson[8] + "|" +
                aInfoPerson[9] + "|" +
                aInfoPerson[10] + "|" +
                aInfoPerson[11]  +"|"+
                aInfoPerson[12];

                //validamos los datos validos
                //Session["cronograma"] = num.TwoDecimas(valorMembresia).ToString() + "|" +"10";

                string dateCro = DateTime.Parse(fecha).ToString("yyyy-MM-dd");

                Session["cronograma"] = Double.Parse(valorMembresia.ToString()).ToString() + "|" +
                    tipocambio.ToString() + "|empty|empty|" +
                    numQuotes.ToString() + "|" +
                    fecha + "|" +
                    initialFee.ToString() + "|" +
                    intAnual.ToString() + "|" +
                    numQuotesInitial + "|empty^" +
                    arrayfechas + "~" +
                    aInfoPerson[1] + "|" +
                    aInfoPerson[2] + "|" +
                    aInfoPerson[14] + "|" +
                    aInfoPerson[13] + "$" +
                    fechas;

                //Session["datos"] = "Nombre|Apellidos|birthDay|M|DocumentType|NroDoc$NombreC|ApellidoC|1|313231c$bankName|nombreBankAccount|TypeAccount|nroAccount|nroTaxer|SocialReason|fiscalAdress|UserType$email|nroCell|nroCell2|country|State|City|Adress";
                //Session["carrito"] = "6000.00|descripcionDB|60|9750.00|3.25|10|TOP";
                //Session["cronograma"] = "6000|222";

                //^6300|3.38|empty|empty|60|2018-11-16|2163.2|10|1|empty^2018-11-16|2129.4~martinex|martinez|103687987|03687987$2018-11-01

                //string respData = brPayments.PersonGetData(userName);
                string respData = "";
                respData = respData + '^' + (string)Session["cronograma"];
                string showReport = "";
                if (minQuotes >= numQuotes)
                {
                    //0 interes
                    showReport = brPayments.GetCalculatePaymentScheduleString(respData, userName, numQuotesInitial.ToString(), "0", true);

                }
                else
                {
                    showReport = brPayments.GetCalculatePaymentScheduleString(respData, userName, numQuotesInitial.ToString(), "0", false);
                }
                Session["cronogramaYa"] = showReport;

                brPayments = null;
                brUser = null;
                double cuotaMensual = 0;
                string[] array1 = showReport.ToString().Split('^');
                string[] datosMem = array1[0].Split('|');
                string[] array2 = array1[1].Split('~');

                string[] cuotas = array2[0].Split('¬');
                for (int i = 0; i < cuotas.Length - 1; i++)
                {
                    var fila = cuotas[i].Split('|');
                    if (fila[0].Substring(0, 7) != "Inicial")
                    {
                        cuotaMensual = double.Parse(fila[5].Replace("S/.", ""));
                        break;
                    }
                }

                Session["carrito"] = num.TwoDecimas(valorMembresia).ToString() + "|" +
                    descripMem + "|" +
                    numQuotes.ToString() + "|" +
                    num.TwoDecimas(initialFee).ToString() + "|" +
                    //num.TwoDecimas(tipocambio).ToString() + "|" +
                    tipocambio + "|" +
                    intAnual.ToString() + "|" +
                    codeMembers + "|" +
                    cuotaMensual + "|" +
                    numQuotesInitial + "|" +
                    initialFeeU;
            }
            //si va a migrar a otra membership
            if (option == "ug")
            {
                BrTypeMembership brTypeMem = new BrTypeMembership();
                MyConstants myConstants = new MyConstants();
                double montoPagado = 0;
                int numCuotasPagadas = 0, quotesMax = 0;
                string codMUdgrate = "";

                int idN_MemberUpgrate = int.Parse(ddlMysMembership.SelectedValue.ToString());
                Session["codeUpgrate"] = idN_MemberUpgrate.ToString();

                string[] aMenber = brTypeMem.GetTypeMembership(idN_MemberUpgrate).Split('|');
                if (aMenber[0] == "")
                {
                    lblMessagge.Text = "ocurrio un error";
                    return;
                }
                montoPagado += double.Parse(aMenber[0].Trim());
                numCuotasPagadas = int.Parse(aMenber[1].Trim());
                codMUdgrate = aMenber[2].Trim();
                fecha = aMenber[3].Trim();
                var typechangecro = double.Parse(aMenber[4].Trim());

                if (DateTime.Parse(fecha).AddMonths(1) < DateTime.Now)
                {
                    fecha = DateTime.Now.ToString(myConstants.DateFormatBd);
                }

                if (codMUdgrate == "SBY")
                {
                    fecha = DateTime.Now.ToString(myConstants.DateFormatBd);
                }

                Session["fechaanterior"] = fecha;

                if (Session["codeDiscount"] != null)
                {
                    string[] codeDiscount = Session["codeDiscount"].ToString().Split('|');

                    if (codeDiscount.Length > 1)
                    {
                        discount = double.Parse(codeDiscount[1]);
                    }
                }

                //quitar cuando el monto ya viene en soles 
                montoPagado = double.Parse((montoPagado / typechangecro).ToString("0.00"));

                string[] aInfo = Membershipselected(discount, montoPagado, codMUdgrate).Split('|');

                montoPagado = double.Parse((montoPagado * tipocambio).ToString("0.00"));

                if (aInfo[0] == "error")
                {
                    return;
                }

                BrUser brUser = new BrUser();
                BrPayments brPayments = new BrPayments();
                Validation val = new Validation();
                Numalet num = new Numalet();
           
                codeMembers = aInfo[0];
                initialFeeU = num.TwoDecimas(double.Parse(aInfo[1]));
                numQuotesInitial = int.Parse(aInfo[2]);
                numQuotes = int.Parse(aInfo[3]);
                quotesMax = int.Parse(aInfo[5]);

                //maximofinanciaminto del maximo de cuotas 60                
                quotesMax = quotesMax - numCuotasPagadas;

                if (numQuotes > quotesMax)
                {
                    numQuotes = quotesMax;
                }

                //amount¬quoteInitial¬numQuotes¬descripcioon¬fecha¬tipocambio¬minQuotes  ---se le envia el code de la membership
                string[] aInfoMember = brPayments.GetAmountTotal(codeMembers).Split('¬');
                int minQuotes = 0, quotesMember = 0;
                minQuotes = int.Parse(aInfoMember[6]);
                quotesMember = int.Parse(aInfoMember[2]);

                //idperson¬name¬lastname¬birthday¬gender¬email¬phone1¬phone2¬pais¬state¬city¬address¬typedoc¬numdoc
                string[] aInfoPerson = brUser.GetPersonalInformation(infoLogin[1]).Split('|');
                if (aInfoPerson.Length == 1)
                {
                    lblMessagge.Text = "Usted no esta apto para comprar una membresia, Por favor regularizar su situación.";
                    return;
                }
                Session["civilState"] = aInfoPerson[16];

                for (int i = 0; i <= 15; i++)
                {
                    if (i != 7)
                    {
                        if (string.IsNullOrEmpty(aInfoPerson[i]))
                        {
                            lblMessagge.Text = "Ir a 'Mi Perfil' y Actualize Todos Sus Datos.";
                            return;
                        }
                    }
                }

                valorMembresia = double.Parse(aInfoMember[0]);
                descripMem = aInfoMember[3];
                initialFee = (initialFeeU * numQuotesInitial);
                tipocambio = double.Parse(aInfoMember[5]);
                intAnual = myConstants.AmountInteresAnual;
                //fecha = DateTime.Parse(aInfoMember[4]).ToString(myConstants.DateFormatBd);
                string fechaCurrent = DateTime.Parse(aInfoMember[4]).ToString(myConstants.DateFormatBd);

                //la inicial se suma al todo puede cambiar
                //valorMembresia += (initialFee / tipocambio);

                amountUpgrate = double.Parse(aInfoMember[7]);

                string upgradeStr = "";
                string dateUpgrade = brUser.GetDateUpgrade(idN_MemberUpgrate).Trim();
                //upgradeStr = " + S/ " + (amountUpgrate * tipocambio).ToString("###,###,##0.00") + "del Upgrate.";

                if (!string.IsNullOrEmpty(dateUpgrade))
                {
                    int year = int.Parse(dateUpgrade.Split('-')[0]);
                    int month = int.Parse(dateUpgrade.Split('-')[1]);
                    int day = int.Parse(dateUpgrade.Split('-')[2]);
                    DateTime ddateUpgrade = new DateTime(year, month, day);
                    DateTime ddateCurrent = DateTime.Now;
                    if (ddateUpgrade > ddateCurrent)
                    {
                        amountUpgrate = 0;
                        upgradeStr = "";
                        Session["dateup"] = ddateUpgrade.ToString(myConstants.DateFormatBd);
                    }
                    else
                    {
                        Session["dateup"] = DateTime.Now.AddDays(quotesMember).ToString(myConstants.DateFormatBd);
                        //upgradeStr = " + S/ " + (amountUpgrate * tipocambio).ToString("###,###,##0.00") + "del Upgrate.";
                    }
                }
                else
                {
                    Session["dateup"] = DateTime.Now.AddDays(quotesMember).ToString(myConstants.DateFormatBd);
                }

                if (codMUdgrate == "SBY")
                {
                    amountUpgrate = 0;
                }

                //sumamos el monto del upgrade
                //valorMembresia = valorMembresia + amountUpgrate;

                arrayfechas = "";
                string fechas = fecha;
                int numberInitial = 0;
                for (var i = 0; i <= numQuotesInitial; i++)
                {
                    if (i == 0)
                    {
                        arrayfechas += fechas + '|' + montoPagado.ToString();
                        numberInitial++;
                    }
                    if (i == 1)
                    {
                        //upgrade
                        initialFee = (amountUpgrate * tipocambio);
                        //arrayfechas += '|' + fechas + '|' + initialFeeU.ToString();
                        arrayfechas += '|' + fechaCurrent + '|' + (amountUpgrate * tipocambio).ToString("###,###,##0.00");

                        //fechas = ((Convert.ToDateTime(fechas)).AddMonths(1)).ToString(myConstants.DateFormatBd);
                        numberInitial++;

                    }
                    if (i > 1 && initialFeeU != 0)
                    {
                        arrayfechas += '|' + fechaCurrent + '|' + initialFeeU.ToString();
                        fechas = ((Convert.ToDateTime(fechaCurrent)).AddMonths(1)).ToString(myConstants.DateFormatBd);
                        numberInitial++;
                    }
                }


                //esta es la fecha en la empiezan las cuotas del cronograma
                fechas = ((Convert.ToDateTime(fecha)).AddMonths(1)).ToString(myConstants.DateFormatBd);

                MyFunctions myFunctions = new MyFunctions();
                BrCode brCode = new BrCode();
                string responseCode = brCode.GetCodeSecreto(txtCodSecreto.Text);

                if (string.Compare(txtCodSecreto.Text, responseCode, false) == 0)
                {
                    arrayfechas = "";
                    try
                    {
                        if (numQuotesInitial >= 2)
                        {
                            numberInitial = numQuotesInitial + 1;

                            arrayfechas += fechas + '|' + montoPagado.ToString() + "|";

                            double firtsQuote = double.Parse(QuoteFirts.Text);
                            firtsQuote = firtsQuote * tipocambio;
                            firtsQuote += amountUpgrate;
                            DateTime firtsDate = DateTime.Parse(myFunctions.DateFormatBd(DateFirts.Text));

                            var dateMax = DateTime.Now.AddDays(45);
                            if (dateMax < firtsDate)
                            {
                                lblMessagge.Text = "La Fecha de la Primera Cuota Supera un Mes despues de la fecha actual";
                                return;
                            }

                            double secondQuote = double.Parse(QuoteSecond.Text);
                            secondQuote = secondQuote * tipocambio;
                            DateTime secondDate = DateTime.Parse(myFunctions.DateFormatBd(DateSecond.Text));

                            arrayfechas += firtsDate.ToString(myConstants.DateFormatBd) + '|' + firtsQuote.ToString() + "|";
                            arrayfechas += secondDate.ToString(myConstants.DateFormatBd) + '|' + secondQuote.ToString();
                            fechas = secondDate.AddMonths(1).ToString(myConstants.DateFormatBd);
                            if (numQuotesInitial > 2)
                            {
                                double thirdQuote = double.Parse(QuoteThird.Text);
                                thirdQuote = thirdQuote * tipocambio;
                                DateTime thirdDate = DateTime.Parse(myFunctions.DateFormatBd(DateThird.Text));
                                arrayfechas += "|" + thirdDate.ToString(myConstants.DateFormatBd) + '|' + thirdQuote.ToString();
                                fechas = thirdDate.AddMonths(1).ToString(myConstants.DateFormatBd);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        string error = ex.Message;
                        lblMessagge.Text = "Fechas de Cuotas Obligatorias.";
                        return;
                    }
                }

                //numQuotesInitial++;
                numQuotesInitial = numberInitial;

                var datos = aInfoPerson[1] + "|" +
                aInfoPerson[2] + "|" +
                aInfoPerson[3] + "|" +
                aInfoPerson[4] + "|" +
                aInfoPerson[12] + "|" +
                aInfoPerson[13] +
                "$ | | | | $ | | | | | | | $" +
                aInfoPerson[5] + "|" +
                aInfoPerson[6] + "|" +
                aInfoPerson[7] + "|" +
                aInfoPerson[8] + "|" +
                aInfoPerson[9] + "|" +
                aInfoPerson[10] + "|" +
                aInfoPerson[11];


                Session["datos"] = datos;

                var cronograma =  Double.Parse(valorMembresia.ToString()).ToString() + "|" +
                    tipocambio.ToString() + "|empty|empty|" +
                    numQuotes.ToString() + "|" +
                    fecha + "|" +
                    initialFee.ToString() + "|" +
                    intAnual.ToString() + "|" +
                    numQuotesInitial + "|empty^" +
                    arrayfechas + "~" +
                    aInfoPerson[1] + "|" +
                    aInfoPerson[2] + "|" +
                    aInfoPerson[14] + "|" +
                    aInfoPerson[13] + "$" +
                    fechas;


                Session["cronograma"] = cronograma;

                //Session["datos"] = "Nombre|Apellidos|birthDay|M|DocumentType|NroDoc$NombreC|ApellidoC|1|313231c$bankName|nombreBankAccount|TypeAccount|nroAccount|nroTaxer|SocialReason|fiscalAdress|UserType$email|nroCell|nroCell2|country|State|City|Adress";
                //Session["carrito"] = "6000.00|descripcionDB|60|9750.00|3.25|10|TOP";
                //Session["cronograma"] = "6000|222";

                //^6300|3.38|empty|empty|60|2018-11-16|2163.2|10|1|empty^2018-11-16|2129.4~martinex|martinez|103687987|03687987$2018-11-01

                //string respData = brPayments.PersonGetData(userName);
                string respData = "";
                respData = respData + '^' + cronograma;
                string showReport = "";
                if (minQuotes >= numQuotes)
                {
                    //0 interes
                    showReport = brPayments.GetCalculatePaymentScheduleStringUpgrade(respData, userName, numQuotesInitial.ToString(), "0", true, true);

                }
                else
                {
                    showReport = brPayments.GetCalculatePaymentScheduleStringUpgrade(respData, userName, numQuotesInitial.ToString(), "0", false, true);
                }
                showReport = showReport.Replace("Inicial nro: 1", "Inicial nro: 0");
                showReport = showReport.Replace("Inicial nro: 2", "Inicial nro: 1" + upgradeStr);
                showReport = showReport.Replace("Inicial nro: 3", "Inicial nro: 2");
                showReport = showReport.Replace("Inicial nro: 4", "Inicial nro: 3");
                Session["cronogramaYa"] = showReport;

                brPayments = null;
                brUser = null;
                double cuotaMensual = 0;
                string[] array1 = showReport.ToString().Split('^');
                string[] datosMem = array1[0].Split('|');
                string[] array2 = array1[1].Split('~');

                string[] cuotas = array2[0].Split('¬');
                for (int i = 0; i < cuotas.Length - 1; i++)
                {
                    var fila = cuotas[i].Split('|');
                    var descr = fila[0].Substring(0, 7);
                    if (descr != "Inicial")
                    {
                        if (descr != "Upgrade")
                        {
                            cuotaMensual = double.Parse(fila[5].Replace("S/.", ""));
                            break;
                        }

                    }
                }

                var carrito =  num.TwoDecimas(valorMembresia).ToString() + "|" +
                    descripMem + "|" +
                    numQuotes.ToString() + "|" +
                    num.TwoDecimas(initialFee).ToString() + "|" +
                    //num.TwoDecimas(tipocambio).ToString() + "|" +
                    tipocambio + "|" +
                    intAnual.ToString() + "|" +
                    codeMembers + "|" +
                    cuotaMensual + "|" +
                    numQuotesInitial + "|" +
                    initialFeeU;


                Session["carrito"] = carrito;

            }
            //Response.Redirect("AddMembPolitics.aspx");

            if (!string.IsNullOrEmpty(option))
            {
                string redirect = "AddMembPolitics";
                if (rbtEvol.Checked || rbtMd.Checked)
                {
                    redirect = "PoliticsTravel";
                }
                if (rbtSby.Checked)
                {
                    redirect = "PoliticsStaBye";
                }
                Response.Redirect(redirect + ".aspx");
            }
        }


        #region Mehods

        /// <summary>
        /// Return Codigo de la Membresia + "|" + Monto a pagar de la inicial aplicado el descuento + "|" + Numero de Cuotas de la Inicial + "|" + Numero de Cuotas del Financiamiento
        /// </summary>
        /// <param name="discount">El descuento a aplicar(porcentaje eje:0.10)</param>
        /// <returns></returns>
        public string Membershipselected(double discount)
        {
            try
            {
                string codeMember = "";
                int numQInicial = 0, numQuotesU = 0;
                double amountInitial = 0;
                Validation val = new Validation();
                if (rbtExp.Checked)
                {
                    if (!val.IsNumber(txtNumCuEXP.Text.Trim()))
                    {
                        lblMessagge.Text = "No a ingresado un numero correcto.";
                        return "error";
                    }
                    numQuotesU = int.Parse(txtNumCuEXP.Text.Trim());
                    numQInicial = 1;
                    amountInitial = Double.Parse(txtInitialEXP.Text);
                    codeMember = "EXP";
                }
                if (rbtLight.Checked)
                {
                    if (!val.IsNumber(txtNumCuLigh.Text.Trim()))
                    {
                        lblMessagge.Text = "No a ingresado un numero correcto.";
                        return "error";
                    }
                    numQuotesU = int.Parse(txtNumCuLigh.Text.Trim());
                    numQInicial = int.Parse(txtLghQuantityInicial.Text.Trim());
                    if (numQInicial > 2 || numQInicial < 1)
                    {
                        lblMessagge.Text = "El numero para dividir la cuota inicial debe ser un numero mayor que 0 y menor igual a 2, que es lo establecido.";
                        return "error";
                    }
                    amountInitial = Double.Parse(txtInitialLigh.Text);
                    codeMember = "LHT";
                }
                if (rbtStd.Checked)
                {
                    if (!val.IsNumber(txtNumCuSTA.Text.Trim()))
                    {
                        lblMessagge.Text = "No a ingresado un numero correcto.";
                        return "error";
                    }
                    numQuotesU = int.Parse(txtNumCuSTA.Text.Trim());
                    numQInicial = int.Parse(txtStaQuantityInicial.Text.Trim());
                    amountInitial = Double.Parse(txtInitialSTA.Text);
                    codeMember = "STD";
                    if (numQInicial > 2 || numQInicial < 1)
                    {
                        lblMessagge.Text = "El numero para dividir la cuota inicial debe ser un numero mayor que 0 y menor igual a 2, que es lo establecido.";
                        return "error";
                    }
                }
                if (rbtPlus.Checked)
                {
                    if (!val.IsNumber(txtNumCuPLU.Text.Trim()) || !val.IsNumber(txtPlusQuantityInicial.Text.Trim()))
                    {
                        lblMessagge.Text = "No a ingresado un numero correcto.";
                        return "error";
                    }
                    numQuotesU = int.Parse(txtNumCuPLU.Text.Trim());
                    numQInicial = int.Parse(txtPlusQuantityInicial.Text.Trim());
                    amountInitial = Double.Parse(txtInitialPLU.Text);
                    codeMember = "PLUS";
                    if (numQInicial > 2 || numQInicial < 1)
                    {
                        lblMessagge.Text = "El numero para dividir la cuota inicial debe ser un numero mayor que 0 y menor igual a 2, que es lo establecido.";
                        return "error";
                    }
                }
                if (rbtTop.Checked)
                {
                    if (!val.IsNumber(txtNumCuTOP.Text.Trim()) || !val.IsNumber(txtTopQuantityInicial.Text.Trim()))
                    {
                        lblMessagge.Text = "No a ingresado un numero correcto.";
                        return "error";
                    }
                    numQuotesU = int.Parse(txtNumCuTOP.Text.Trim());
                    numQInicial = int.Parse(txtTopQuantityInicial.Text);
                    amountInitial = Double.Parse(txtInitialTOP.Text);
                    codeMember = "TOP";
                    if (numQInicial > 3 || numQInicial < 1)
                    {
                        lblMessagge.Text = "El numero para dividir la cuota inicial debe ser un numero mayor que 0 y menor igual a 3, que es lo establecido.";
                        return "error";
                    }
                }
                if (rbtMd.Checked)
                {
                    if (!val.IsNumber(txtNumCuMd.Text.Trim()) || !val.IsNumber(txtQuotesInitialMd.Text.Trim()))
                    {
                        lblMessagge.Text = "No a ingresado un numero correcto.";
                        return "error";
                    }
                    numQuotesU = int.Parse(txtNumCuMd.Text.Trim());
                    numQInicial = int.Parse(txtQuotesInitialMd.Text);
                    amountInitial = Double.Parse(txtInitialMd.Text);
                    codeMember = "MVC";
                    if (numQInicial > 3 || numQInicial < 1)
                    {
                        lblMessagge.Text = "El numero para dividir la cuota inicial debe ser un numero mayor que 0 y menor igual a 3, que es lo establecido.";
                        return "error";
                    }
                }
                if (rbtVit.Checked)
                {
                    if (!val.IsNumber(txtNumCuVit.Text.Trim()) || !val.IsNumber(txtVitQuantityInicial.Text.Trim()))
                    {
                        lblMessagge.Text = "No a ingresado un numero correcto.";
                        return "error";
                    }
                    numQuotesU = int.Parse(txtNumCuVit.Text.Trim());
                    numQInicial = int.Parse(txtVitQuantityInicial.Text);
                    amountInitial = Double.Parse(txtInitialVit.Text);
                    codeMember = "VIT";
                    if (numQInicial > 3 || numQInicial < 1)
                    {
                        lblMessagge.Text = "El numero para dividir la cuota inicial debe ser un numero mayor que 0 y menor igual a 3, que es lo establecido.";
                        return "error";
                    }
                }
                if (rbtSby.Checked)
                {
                    if (!val.IsNumber(txtNumCuSby.Text.Trim()))
                    {
                        lblMessagge.Text = "No a ingresado un numero correcto.";
                        return "error";
                    }
                    numQuotesU = int.Parse(txtNumCuSby.Text.Trim());
                    numQInicial = 1;
                    amountInitial = Double.Parse(txtInitialSby.Text);
                    codeMember = "SBY";
                    if (numQInicial > 3 || numQInicial < 1)
                    {
                        lblMessagge.Text = "El numero para dividir la cuota inicial debe ser un numero mayor que 0 y menor igual a 3, que es lo establecido.";
                        return "error";
                    }
                }
                if (rbtEvol.Checked)
                {
                    if (!val.IsNumber(txtNumCuEvol.Text.Trim()))
                    {
                        lblMessagge.Text = "No a ingresado un numero correcto.";
                        return "error";
                    }
                    numQuotesU = int.Parse(txtNumCuEvol.Text.Trim());
                    numQInicial = 1;
                    amountInitial = Double.Parse(txtInitialEvol.Text);
                    codeMember = "EVOL";
                    if (numQInicial > 3 || numQInicial < 1)
                    {
                        lblMessagge.Text = "El numero para dividir la cuota inicial debe ser un numero mayor que 0 y menor igual a 3, que es lo establecido.";
                        return "error";
                    }
                }

                BrPayments brPayments = new BrPayments();
                string[] aInfoMember = brPayments.GetAmountTotal(codeMember).Split('¬');
                brPayments = null;

                //validamos que el monto que digito el usuario no sea mayor al minimo establecido
                double initialFee = double.Parse(aInfoMember[1]);
                int numQuotes = int.Parse(aInfoMember[2]);
                if (initialFee > amountInitial || amountInitial < 0)
                {
                    lblMessagge.Text = "El monto de la cuota inicial debe ser igual o mayor a lo establecido.";
                    return "error";
                }
                if (numQuotes < numQuotesU || numQuotesU < 0)
                {
                    lblMessagge.Text = "El numero de las cuotas debe ser igual o mayor a lo establecido.";
                    return "error";
                }
                //calculamos el monto a pagar que estaba en dolares los tranformamos a soles 
                double typeChange = double.Parse(aInfoMember[5]);
                amountInitial = amountInitial * typeChange;

                //Session["Formule"] = (amount / QuoteInitial) * (double)Session["Discount"];
                //aplicamos el descuento
                amountInitial = (amountInitial / numQInicial) - ((amountInitial / numQInicial) * discount);
                //amountOfEachInitial = (amountInitial / numQInicial);
                //Session["Amount"] = amount;
                return codeMember + "|" + amountInitial.ToString() + "|" + numQInicial.ToString() + "|" + numQuotesU.ToString() + "|" + numQuotes.ToString();
            }
            catch (Exception ex)
            {
                lblMessagge.Text = "No a ingresado un numero correcto.";
                return "error|" + ex.Message;
            }
        }

        public string Membershipselected(double discount, double amortization, string codeMemberUpgrate)
        {
            try
            {
                string codeMember = "";
                int numQInicial = 0, numQuotesU = 0;
                double amountInitial = 0, direfencia = 0;
                Validation val = new Validation();
                if (rbtExp.Checked)
                {
                    if (!val.IsNumber(txtNumCuEXP.Text.Trim()))
                    {
                        lblMessagge.Text = "No a ingresado un numero correcto.";
                        return "error";
                    }
                    numQuotesU = int.Parse(txtNumCuEXP.Text.Trim());
                    numQInicial = 1;
                    amountInitial = Double.Parse(txtInitialEXP.Text);
                    codeMember = "EXP";
                }
                if (rbtLight.Checked)
                {
                    if (!val.IsNumber(txtNumCuLigh.Text.Trim()))
                    {
                        lblMessagge.Text = "No a ingresado un numero correcto.";
                        return "error";
                    }
                    numQuotesU = int.Parse(txtNumCuLigh.Text.Trim());
                    numQInicial = int.Parse(txtLghQuantityInicial.Text.Trim());
                    if (numQInicial > 2 || numQInicial < 1)
                    {
                        lblMessagge.Text = "El numero para dividir la cuota inicial debe ser un numero mayor que 0 y menor igual a 2, que es lo establecido.";
                        return "error";
                    }
                    amountInitial = Double.Parse(txtInitialLigh.Text);
                    codeMember = "LHT";
                }
                if (rbtStd.Checked)
                {
                    if (!val.IsNumber(txtNumCuSTA.Text.Trim()))
                    {
                        lblMessagge.Text = "No a ingresado un numero correcto.";
                        return "error";
                    }
                    numQuotesU = int.Parse(txtNumCuSTA.Text.Trim());
                    numQInicial = int.Parse(txtStaQuantityInicial.Text.Trim());
                    amountInitial = Double.Parse(txtInitialSTA.Text);
                    codeMember = "STD";
                    if (numQInicial > 2 || numQInicial < 1)
                    {
                        lblMessagge.Text = "El numero para dividir la cuota inicial debe ser un numero mayor que 0 y menor igual a 2, que es lo establecido.";
                        return "error";
                    }
                }
                if (rbtPlus.Checked)
                {
                    if (!val.IsNumber(txtNumCuPLU.Text.Trim()) || !val.IsNumber(txtPlusQuantityInicial.Text.Trim()))
                    {
                        lblMessagge.Text = "No a ingresado un numero correcto.";
                        return "error";
                    }
                    numQuotesU = int.Parse(txtNumCuPLU.Text.Trim());
                    numQInicial = int.Parse(txtPlusQuantityInicial.Text.Trim());
                    amountInitial = Double.Parse(txtInitialPLU.Text);
                    codeMember = "PLUS";
                    if (numQInicial > 2 || numQInicial < 1)
                    {
                        lblMessagge.Text = "El numero para dividir la cuota inicial debe ser un numero mayor que 0 y menor igual a 2, que es lo establecido.";
                        return "error";
                    }
                }
                if (rbtTop.Checked)
                {
                    if (!val.IsNumber(txtNumCuTOP.Text.Trim()) || !val.IsNumber(txtTopQuantityInicial.Text.Trim()))
                    {
                        lblMessagge.Text = "No a ingresado un numero correcto.";
                        return "error";
                    }
                    numQuotesU = int.Parse(txtNumCuTOP.Text.Trim());
                    numQInicial = int.Parse(txtTopQuantityInicial.Text);
                    amountInitial = Double.Parse(txtInitialTOP.Text);
                    codeMember = "TOP";
                    if (numQInicial > 3 || numQInicial < 1)
                    {
                        lblMessagge.Text = "El numero para dividir la cuota inicial debe ser un numero mayor que 0 y menor igual a 3, que es lo establecido.";
                        return "error";
                    }
                }
                if (rbtMd.Checked)
                {
                    if (!val.IsNumber(txtNumCuMd.Text.Trim()) || !val.IsNumber(txtQuotesInitialMd.Text.Trim()))
                    {
                        lblMessagge.Text = "No a ingresado un numero correcto.";
                        return "error";
                    }
                    numQuotesU = int.Parse(txtNumCuMd.Text.Trim());
                    numQInicial = int.Parse(txtQuotesInitialMd.Text);
                    amountInitial = Double.Parse(txtInitialMd.Text);
                    codeMember = "MVC";
                    if (numQInicial > 3 || numQInicial < 1)
                    {
                        lblMessagge.Text = "El numero para dividir la cuota inicial debe ser un numero mayor que 0 y menor igual a 3, que es lo establecido.";
                        return "error";
                    }
                }
                if (rbtVit.Checked)
                {
                    if (!val.IsNumber(txtNumCuVit.Text.Trim()) || !val.IsNumber(txtVitQuantityInicial.Text.Trim()))
                    {
                        lblMessagge.Text = "No a ingresado un numero correcto.";
                        return "error";
                    }
                    numQuotesU = int.Parse(txtNumCuVit.Text.Trim());
                    numQInicial = int.Parse(txtVitQuantityInicial.Text);
                    amountInitial = Double.Parse(txtInitialVit.Text);
                    codeMember = "VIT";
                    if (numQInicial > 3 || numQInicial < 1)
                    {
                        lblMessagge.Text = "El numero para dividir la cuota inicial debe ser un numero mayor que 0 y menor igual a 3, que es lo establecido.";
                        return "error";
                    }
                }
                if (rbtSby.Checked)
                {
                    if (!val.IsNumber(txtNumCuSby.Text.Trim()))
                    {
                        lblMessagge.Text = "No a ingresado un numero correcto.";
                        return "error";
                    }
                    numQuotesU = int.Parse(txtNumCuSby.Text.Trim());
                    numQInicial = 1;
                    amountInitial = Double.Parse(txtInitialSby.Text);
                    codeMember = "SBY";
                    if (numQInicial > 3 || numQInicial < 1)
                    {
                        lblMessagge.Text = "El numero para dividir la cuota inicial debe ser un numero mayor que 0 y menor igual a 3, que es lo establecido.";
                        return "error";
                    }
                }
                if (rbtEvol.Checked)
                {
                    if (!val.IsNumber(txtNumCuEvol.Text.Trim()))
                    {
                        lblMessagge.Text = "No a ingresado un numero correcto.";
                        return "error";
                    }
                    numQuotesU = int.Parse(txtNumCuEvol.Text.Trim());
                    numQInicial = 1;
                    amountInitial = Double.Parse(txtInitialEvol.Text);
                    codeMember = "EVOL";
                    if (numQInicial > 3 || numQInicial < 1)
                    {
                        lblMessagge.Text = "El numero para dividir la cuota inicial debe ser un numero mayor que 0 y menor igual a 3, que es lo establecido.";
                        return "error";
                    }
                }

                if (codeMember == "SBY")
                {
                    lblMessagge.Text = "No puede hacer Upgrate a esta Membresia.";
                    return "error";
                }

                if (codeMember == codeMemberUpgrate)
                {
                    lblMessagge.Text = "No puede hacer Upgrate a una Membresia del mismo tipo";
                    return "error";
                }

                BrPayments brPayments = new BrPayments();
                string[] aInfoMember = brPayments.GetAmountTotal(codeMember).Split('¬');
                brPayments = null;

                //validamos que el monto que digito el usuario no sea mayor al minimo establecido
                double initialFee = double.Parse(aInfoMember[1]);
                int numQuotes = int.Parse(aInfoMember[2]);
                if (initialFee > amountInitial || amountInitial < 0)
                {
                    lblMessagge.Text = "El monto de la cuota inicial debe ser igual o mayor a lo establecido.";
                    return "error";
                }
                if (numQuotes < numQuotesU || numQuotesU < 0)
                {
                    lblMessagge.Text = "El numero de las cuotas debe ser igual o mayor a lo establecido.";
                    return "error";
                }
                //calculamos el monto a pagar que estaba en dolares los tranformamos a soles 
                double typeChange = double.Parse(aInfoMember[5]);
               

                var qinit = 0;

                //reducimos el monto de la inicial con el ya pagado
                if (amortization > amountInitial)
                {
                    direfencia = (amortization - amountInitial) * -1;
                    amountInitial = 0;
                    qinit = numQInicial;
                }
                else
                {
                    amountInitial = amountInitial - amortization;
                    qinit = numQInicial + 1;
                }

                //el monto initial que esta en dolares lo tranformamos a soles
                amountInitial = amountInitial * typeChange;

                //Session["Formule"] = (amount / QuoteInitial) * (double)Session["Discount"];
                //aplicamos el descuento
                amountInitial = (amountInitial / numQInicial) - ((amountInitial / numQInicial) * discount);
                //amountOfEachInitial = (amountInitial / numQInicial);
                //Session["Amount"] = amount;
                return codeMember + "|" + amountInitial.ToString() + "|" + qinit.ToString() + "|" + numQuotesU.ToString() + "|" + direfencia.ToString() + "|" + numQuotes.ToString();
            }
            catch (Exception ex)
            {
                lblMessagge.Text = "No a ingresado un numero correcto.";
                return "error|" + ex.Message;
            }
        }

        public int[] daysToChoose(string date)
        {
            string anio = date.Split('-')[0];
            string month = date.Split('-')[1];
            int day = int.Parse(date.Split('-')[2]);

            string newDatem = DateTime.Parse(anio + "-" + month + "-01").AddMonths(1).ToString("yyyy-MM-dd");
            string newDatemc = DateTime.Now.AddMonths(1).ToString("yyyy-MM-dd");
            string newDate = DateTime.Parse(newDatem).AddDays(-1).ToString("yyyy-MM-dd");

            int endDay = int.Parse(newDate.Split('-')[2]);
            int[] arrayDay = new int[32];
            int contador = 0;

            int contadorDay = day;
            int interructor = 0;
            int untilDay = int.Parse(newDatemc.Split('-')[2]);
            for (int i = 0; i < 32; i++)
            {
                contadorDay++;
                if (contadorDay > endDay)
                {
                    contadorDay = 0;
                    interructor = 1;
                }
                else
                {
                    if (interructor == 1)
                    {
                        if (contadorDay < untilDay)
                        {
                            arrayDay[contador] = contadorDay;
                        }
                    }
                    else
                    {
                        arrayDay[contador] = contadorDay;
                    }
                }
                contador++;
            }
            return arrayDay;
        }


        #endregion

        protected void lblSalir_Click(object sender, EventArgs e)
        {
            Session.Contents.RemoveAll();
            FormsAuthentication.SignOut();
            HttpContext.Current.Response.Redirect("Index.aspx", true);
        }


        private string GetMonth(int _month)
        {
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

        private int GetMonth(string month)
        {
            int _month = 0;
            if (month == "Enero")
            {
                _month = 1;
            }
            if (month == "Febrero")
            {
                _month = 2;
            }
            if (month == "Marzo")
            {
                _month = 3;
            }
            if (month == "Abril")
            {
                _month = 4;
            }
            if (month == "Mayo")
            {
                _month = 5;
            }
            if (month == "Junio")
            {
                _month = 6;
            }
            if (month == "Julio")
            {
                _month = 7;
            }
            if (month == "Agosto")
            {
                _month = 8;
            }
            if (month == "Septiembre")
            {
                _month = 9;
            }
            if (month == "Octubre")
            {
                _month = 10;
            }
            if (month == "Noviembre")
            {
                _month = 11;
            }
            if (month == "Diciembre")
            {
                _month = 12;
            }
            return _month;
        }


    }
}