using BussinesRules;
using BussinesRules.TypeMembership;
using BussinesRules.User;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MULTI_NIVEL.Views
{
    public partial class Store : System.Web.UI.Page
    {
        public string CodeMembership { get; set; }
        string data = "";
        string gender = "M";
        string dataBdd = "";
        string amountInicial = "";
        string numCuotas = "";
        string txtp1 = "";
        BrPayments brPayment;
        BrUser brUser;
        //BrConsuption brConsuption;
       // string respData = "";
        string userName = ";";
        string userLog = ";";
        int QuoteInitial = 0;
        string strDate = "";
        Double amount = 0.00;
        string Membership = "";
        string def = "profile.png";
        string extension = ".png";
        string name = "";
        string nombreu = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var arraLogin = HttpContext.Current.User.Identity.Name.Split('¬');
                if (arraLogin.Length == 1)
                {
                    Response.Redirect("Register.aspx", true);
                }


                Session["Referido"] = arraLogin[1];


                this.lblUser.Text = "Hola " + arraLogin[0];
                this.lblUserName.Text = arraLogin[0];
                this.lblNumPartner.Text = "N° Asociado: " + arraLogin[4];

                if (true)
                {
                    this.imgProfile.ImageUrl = "~/Resources/Images/profile.png";
                    this.imgProfileFl.ImageUrl = "~/Resources/Images/profile.png";
                }

                BrUser brUser = new BrUser();
                string nsocios = brUser.GetCountsAsociate();
                //lblnsocios.Text = nsocios;

                // Imagen de PErfil
                var rutaImgP = HttpContext.Current.Server.MapPath("~/Resources/imguser");
                DirectoryInfo di1 = new DirectoryInfo(rutaImgP);
                nombreu = arraLogin[1];
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

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            bool exonerarKit = false;
            string amountInicial = "";
            bool eligioMen = false;
            var resp = "";
            var memb = "";

            Session["flag"] = "1";
            Session["typeBuy"] = "store";

            //if (rbtExp.Checked)
            //{
            //    dataBdd = str("EXP");
            //    amountInicial = txtInitialEXP.Text.Trim();
            //    Session["Amount"] = amountInicial;
            //    numCuotas = txtNumCuEXP.Text.Trim();
            //    txtp1 = textPag1.Text.Trim();
            //    memb = "Experience";
            //    eligioMen = true;
            //    //Membership= str("EXP");
            //    Membership = "EXP";
            //}
            //if (rbtStd.Checked == true)
            //{
            //    dataBdd = str("STD");
            //    amountInicial = txtInitialSTA.Text.Trim();
            //    Session["Amount"] = amountInicial;
            //    numCuotas = txtNumCuSTA.Text.Trim();
            //    txtp1 = textPag2.Text.Trim();
            //    memb = "Stantard";
            //    eligioMen = true;
            //    //Membership = str("STD");
            //    Membership ="STD";
            //}

            //if (rbtPlus.Checked)
            //{
            //    dataBdd = str("PLUS");
            //    amountInicial = txtInitialPLU.Text;
            //    Session["Amount"] = amountInicial;
            //    numCuotas = txtNumCuPLU.Text;
            //    txtp1 = textPag3.Text.Trim();
            //    memb = "Plus";
            //    eligioMen = true;
            //    //Membership = str("PLUS");
            //    Membership = "PLUS";


            //}
            //if (rbtTop.Checked == true)
            //{
            //    dataBdd = str("TOP");
            //    amountInicial = txtInitialTOP.Text;
            //    Session["Amount"] = amountInicial;
            //    numCuotas = txtNumCuTOP.Text;
            //    txtp1 = txtTopCuotaInicial.Text.Trim();
            //    memb = "Top";
            //    eligioMen = true;
            //    //Membership = str("TOP");
            //    Membership = "TOP";

            //}
            //if (rbtLight.Checked)
            //{
            //    dataBdd = str("LHT");
            //    amountInicial = txtInitialLigh.Text.Trim();
            //    Session["Amount"] = amountInicial;
            //    numCuotas = txtNumCuLigh.Text.Trim();
            //    txtp1 = textPag2.Text.Trim();
            //    memb = "Light";
            //    eligioMen = true;
            //    //Membership = str("LHT");
            //    Membership = "LHT";

            //}

            //if (rdrEx.SelectedValue == "Exonerar")
            //{
            //    Session["StatusExonerar"] = 1;
            //}
            //else if (rdrEx.SelectedValue == "NoExonerar")
            //{
            //    Session["StatusExonerar"] = 0;
            //}
            //else
            //{

            //    Session["StatusExonerar"] = 0;
            //}

            Session["membresia"] = memb;

            BrTypeMembership brTypeMembership = new BrTypeMembership();
            //Register Payment si es kit  inserte unico 'montodolaresKit¬tipocambio¬fecha'
            string[] kitData = brTypeMembership.GetKitData().Split('¬');
            double amountKit = double.Parse(kitData[0]);
            double tpKit = double.Parse(kitData[1]);
            string date = kitData[2];

            //if (string.IsNullOrEmpty(this.CodeMembership) && isExonerar.Checked == false)
            //{
            //    dataBdd = str("KIT");
            //    Session["datos"] = dataBdd;

            //    double totalKit = TwoDecimas(amountKit * tpKit);
            //    string arrayKit = date + "¬" + totalKit.ToString("0.00") + "¬" + totalKit.ToString("0.00") + "¬" + totalKit.ToString("0.00");

            //    Session["QuoteAux"] = "0";
            //    Session["Amount"] = totalKit;
            //    Session["arrayKit"] = arrayKit;
            //    Session["carrito"] = amountKit.ToString("0.00") + "|" + "" + "|" + "0" + "|" + amountKit.ToString("0.00") + "|" + tpKit.ToString("0.00") + "|" + "10" + "|" + CodeMembership;
            //    Session["typeRegister"] = "1";
            //    //Response.Redirect("PoliticsKit.aspx?name=" + txtName.Text + "&lastNama=" + txtLastName.Text + "&pais=" + txtCountry.Text + "&dni=" + txtNumDoc.Text);
            //    Response.Redirect("Politics.aspx");

            //    var storeT = Session["tienda"].ToString();
            //    var plop = int.Parse(storeT.ToString());
            //}


            //solo exonerar si es el administrador
            string[] arrayLogin = HttpContext.Current.User.Identity.Name.Split('¬');
            if (arrayLogin.Length > 2)
            {
                if (int.Parse(arrayLogin[2]) == 1)
                {
                    //if (isExonerar.Checked)
                    //{
                    //    if (eligioMen == true)
                    //    {
                    //        BrInformacion brInformacion = new BrInformacion();
                    //        string textExonerarDB = brInformacion.GetTextExonerarDB();
                    //        brInformacion = null;
                    //        if (txtContaExonerar.Text.Trim() == textExonerarDB.Trim())
                    //        {
                    //            if (eligioMen == true)
                    //            {
                    //                exonerarKit = true;////////////////////////**********************
                    //            }
                    //            else
                    //            {
                    //                lblMessagge.Text = "Debe Comprar al menos una Membresia";
                    //                return;
                    //            }
                    //        }
                    //        else
                    //        {
                    //            lblMessagge.Text = "Codigo Incorrecto";
                    //            return;
                    //        }
                    //    }
                    //    else
                    //    {
                    //        lblMessagge.Text = "Debe Comprar al menos una Membresia";
                    //        return;
                    //    }
                    //}
                }
            }
            if (eligioMen == true)
            {
                if (string.IsNullOrEmpty(dataBdd))
                {
                    return;
                }
                BrPayments brPayments = new BrPayments();
                var arraydata = dataBdd.Split('|');

                //amount¬quoteInitial¬numQuotes¬descripcioon¬fecha¬tipocambio  ---se le envia el code de la membership

                //string[] arrayMontoTotal = brPayments.GetAmountTotal(this.CodeMembership).Split('¬');
                //brPayments = null;

                //double amountTotalDB = double.Parse(arrayMontoTotal[0]);
                //double amountInicialDB = double.Parse(arrayMontoTotal[1]);
                //int numCuotasDB = int.Parse(arrayMontoTotal[2]);
                //string descripcionDB = arrayMontoTotal[3];
                //string fecha = arrayMontoTotal[4];
                //double tipoCambio = double.Parse(arrayMontoTotal[5]);

                //double amountInicialU = TwoDecimas(double.Parse(amountInicial));

                ////validar que la cuota inicial debe ser mayor al valor asignado como minimo
                //if (amountInicialU < amountInicialDB)
                //{
                //    //txtMessagge.Text = "El Monto de la Inicial debe ser Mayor";
                //    return;
                //}
                ////validar que el numero de las cuotas debe ser menor a las asignadas como maximo
                //if (int.Parse(numCuotas) > numCuotasDB || int.Parse(numCuotas) <= 0)
                //{
                //    //txtMessagge.Text = "El Numero de Las Cuotas debe ser Menor";
                //    return;
                //}
                //if ((int.Parse(textPlusQuoteInitial.Text) > 2 || int.Parse(textPlusQuoteInitial.Text) < 1) && CodeMembership == "PLUS")
                //{
                //    // txtMessagge.Text = "El Numero de Las Cuotas INITIAL debe ser Menor";
                //    return;
                //}

                //if ((int.Parse(textPlusQuoteInitial.Text) > 3 || int.Parse(textPlusQuoteInitial.Text) < 1) && CodeMembership == "TOP")
                //{
                //    //txtMessagge.Text = "El Numero de Las Cuotas INITIAL debe ser Menor";
                //    return;
                //}
                //HGHG
                //string exonerarkit = Session["StatusExonerar"].ToString();

                //double cuotaInicialS = TwoDecimas(amountInicialU * tipoCambio);
                //if (!exonerarKit)
                //{
                //    //suma el monto del kit de unicio
                //    amountTotalDB += TwoDecimas(amountKit);
                //    cuotaInicialS += TwoDecimas(amountKit * tipoCambio);
                //}
                //int numCuotasU = int.Parse(numCuotas);
                //datos para mostrar en la parte de pasarela de pagos
                //string Req = "";
                //brConsuption = new BrConsuption();
                //if (consumePack1.Checked)
                //{
                //    Req = brConsuption.GetAmountConsuption("PB1");
                //}
                //else if (ConsumePack2.Checked)
                //{
                //    Req = brConsuption.GetAmountConsuption("PB2");
                //}
                //else if (ConsumePack3.Checked)
                //{
                //    Req = brConsuption.GetAmountConsuption("PB3");
                //}
                //else if (ConsumePack4.Checked)
                //{
                //    Req = brConsuption.GetAmountConsuption("PB4");
                //}
                //else if (ConsumePack5.Checked)
                //{
                //    Req = brConsuption.GetAmountConsuption("PB5");
                //}

                //Session["carrito"] = amountTotalDB.ToString("0.00") + "|" + descripcionDB + "|" + numCuotasU + "|" + amountInicialU.ToString("0.00") + "|" + tipoCambio.ToString("0.00") + "|" + amountKit.ToString() + '|' + CodeMembership;

                //monto total de la membresia debe estar en dolares 
                //la cuota inicial debe estar en soles
                //"gfdgdf|gdfgdfg|20/11/2018|M|1|77777738$navacito | |1|$EMPTY|EMPTY|CORRIENTE|EMPTY|EMPTY|EMPTY|EMPTY|1$hombrehealth@hotmail.com|960614917| |Peru|fs|sf|fs|STD|admin$1"
                string data=arrayLogin[1]+'|'+ Membership;
                brUser = new BrUser();
                string dataPerson= brUser.GetDataPerson(data);
                Session["datos"] = dataPerson;

                //william
                //if (rbtTop.Checked)
                //{
                //    QuoteInitial = Int32.Parse(txtTopCuotaInicial.Text);
                //    amount = Double.Parse(txtInitialTOP.Text) * 3.37;
                //    amount = amount / QuoteInitial;
                //    Session["Amount"] = amount;
                //}
                //else if (rbtPlus.Checked)
                //{
                //    QuoteInitial = Int32.Parse(textPlusQuoteInitial.Text);
                //    amount = Double.Parse(txtInitialPLU.Text) * 3.37;
                //    amount = amount / QuoteInitial;
                //    Session["Amount"] = amount;
                //}
                //else if (rbtStd.Checked)
                //{
                //    QuoteInitial = 1;
                //    amount = Double.Parse(txtInitialSTA.Text) * 3.37;
                //    amount = amount / QuoteInitial;
                //    Session["Amount"] = amount;
                //}
                //else if (rbtLight.Checked)
                //{
                //    QuoteInitial = 1;
                //    amount = Double.Parse(txtInitialLigh.Text) * 3.37;
                //    amount = amount / QuoteInitial;
                //    Session["Amount"] = amount;
                //}
                //else if (rbtExp.Checked)
                //{
                //    QuoteInitial = 1;
                //    amount = Double.Parse(txtInitialEXP.Text) * 3.37;
                //    amount = amount / QuoteInitial;
                //    Session["Amount"] = amount;
                //}
                //strDate = "";
                //for (var i = 0; i < QuoteInitial; i++)
                //{
                //    if (i > 0)
                //    {
                //        strDate += '|' + fecha + '|' + amount.ToString();
                //    }
                //    else
                //    {
                //        strDate += fecha + '|' + amount.ToString();
                //    }

                //    var dateAux = ((Convert.ToDateTime(fecha)).AddMonths(i)).ToString("yyyy-MM-dd");
                //    fecha = dateAux;
                //}

                ///////// CAGADA START  para analizarrr samir!!! //////////////
                //Session["cronograma"] = (amountTotalDB - 10).ToString() + "|" + tipoCambio.ToString() + "|empty|empty|" + numCuotasU + "|" + fecha + "|" + cuotaInicialS.ToString() + "|10|1|empty^" + strDate + "~" +
                //   "$" + "2018-11-01";
                ////////// CAGADA START ////////////
                ///
                Session["typeRegister"] = "2";

                ///
                var auxData = brPayment.PersonGetData(userLog);//problem
                var idPerson = auxData.Split('|')[0];
                string respData = idPerson.ToString()+'|'+memb;


                string flag = (string)Session["flag"];
               // string showReport = brPayment.GetCalculatePaymentScheduleString(respData, userName, QuoteInitial.ToString(), flag);
                //Session["cronograma"] = showReport;

               
                //Session["cronograma"] = ((amountTotalDB - 10).ToString()+ "|" + tipoCambio.ToString() + "|empty|empty|" + numCuotasU + "|" + fecha + "|" + cuotaInicialS.ToString() + "|10|1|empty^" + strDate + "~" +
                //  "nombre de prueba" + "|" + "apellido de prueba" + "|1" + "222222" + "|" + "22222" + "$" + "2018-11-01");
                //brPayment = new BrPayments();

                //Session["exchange"] = tipoCambio;
                ///
                //brPayment = new BrPayments();
                ////string respData = brPayment.PersonGetData(userName);
                //respData = respData + '^' + (string)Session["cronograma"];
                //string showReport = brPayment.GetCalculatePaymentScheduleString(respData, userName, QuoteInitial.ToString(), "0");
                //Session["cronogramaYa"] = showReport;
                //var macro = showReport.Split('^');
                //var micro = macro[1].Split('¬');
                //string quoteReference = "";
                //for (int i = 0; i <= micro.Length; i++)
                //{
                //    var listRegisters = micro[i].Split('|');
                //    if (listRegisters[0] == "Cuota nro: 1")
                //    {
                //        quoteReference = listRegisters[5];
                //        break;
                //    }
                //}
                //Session["QuoteAux"] = quoteReference;

                ///
                //var ej = "2500|3.25|VE034|VE035|23|2018-09-19|1944|10|1|obs^2018-09-19|1944~nombre|apellido|1|45345345|45345345$2018-10-19";
                Session["JustKit"] = 0;
                // Response.Redirect("Politics.aspx?name=" + txtName.Text + "&lastNama=" + txtLastName.Text + "&pais=" + txtCountry.Text + "&dni=" + txtNumDoc.Text);
                Response.Redirect("Politics.aspx");
            }
            else
            {
                //lblMessagge.Text = "Debe Comprar al menos una Membresia";
                //Session["JustKit"] = 1;
                //Response.Redirect("PoliticsKit.aspx?name=" + txtName.Text + "&lastNama=" + txtLastName.Text + "&pais=" + txtCountry.Text + "&dni=" + txtNumDoc.Text);
                //Response.Redirect("Politics.aspx");
                return;
            }
        }

        public string str(string membership)
        {
            this.CodeMembership = membership;
            var obj = HttpContext.Current.User.Identity.Name.Split('¬');
            String padre = obj[0];
            if (obj.Length > 1)
            {
                padre = obj[1];
            }

            data += membership;
            return data;

            //int resultDll = ddlSons.SelectedIndex;
            //var cell =(Int32) resultDll;
            //var indexSon = (respData.Split('¬'))[resultDll];
            //if (!string.IsNullOrEmpty(indexSon))
            //{

            //   var listParametersDll = indexSon.Split('|');
            //   string IdUpliner = listParametersDll[0];
            //    data += txtName.Text.Trim() + "|" +
            //        txtLastName.Text.Trim() + "|" +
            //        txtDateNac.Text.Trim() + "|" +
            //        gender + "|" +
            //        ddlTypeDoc.SelectedValue.Trim() + "|" +
            //        txtNumDoc.Text.Trim() + '$' +
            //        txtNameC.Text.Trim() + " |" +
            //        txtLastNameC.Text.Trim() + " |" +
            //        "1" + "|" +
            //        txtnumDocC.Text.Trim() + "$" +
            //        "EMPTY" + "|" +
            //        "EMPTY" + "|" +
            //        typeAccountBanck + "|" +
            //        "EMPTY" + "|" +
            //        "EMPTY" + "|" +
            //        "EMPTY" + "|" +
            //        "EMPTY" + "|" +
            //        ddlTypeAccount.Text.Trim() + "$" +
            //        txtEmail.Text.Trim() + "|" +
            //        txtPhone.Text.Trim() + "|" +
            //        txtPhone2.Text.Trim() + " |" +
            //        txtCountry.Text.Trim() + "|" +
            //        txtEstado.Text.Trim() + "|" +
            //        txtCiudad.Text.Trim() + "|" +
            //        txtDireccion.Text.Trim() + "|" +
            //        membership + "|" +
            //        padre + '$' + IdUpliner;

            //    return data;
            //}
            //else
            //{

            //    data += txtName.Text.Trim() + "|" +
            //        txtLastName.Text.Trim() + "|" +
            //        txtDateNac.Text.Trim() + "|" +
            //        gender + "|" +
            //        ddlTypeDoc.SelectedValue.Trim() + "|" +
            //        txtNumDoc.Text.Trim() + '$' +
            //        txtNameC.Text.Trim() + "|" +
            //        txtLastNameC.Text.Trim() + "|" +
            //        ddlTypeDocC.SelectedValue.Trim() + "|" +
            //        txtnumDocC.Text.Trim() + "$" +
            //        ddlBanck.Text.Trim() + "|" +
            //        txtNameTitularCuentaBan.Text.Trim() + "|" +
            //        typeAccountBanck + "|" +
            //        txtNumCuenta.Text.Trim() + "|" +
            //        txtNumContr.Text.Trim() + "|" +
            //        txtBusinessName.Text.Trim() + "|" +
            //        txtFiscalAddress.Text.Trim() + "|" +
            //        ddlTypeAccount.Text.Trim() + "$" +
            //        txtEmail.Text.Trim() + "|" +
            //        txtPhone.Text.Trim() + "|" +
            //        txtPhone2.Text.Trim() + "|" +
            //        txtCountry.Text.Trim() + "|" +
            //        txtEstado.Text.Trim() + "|" +
            //        txtCiudad.Text.Trim() + "|" +
            //        txtDireccion.Text.Trim() + "|" +
            //        membership + "|" +
            //        padre + '$' + '0';

            //    return data;
            //}
        }

        protected void lbkBtnSalir_Click(object sender, EventArgs e)
        {
               Session.RemoveAll();
               FormsAuthentication.SignOut();
               HttpContext.Current.Response.Redirect("Index.aspx", true);
        }



        public double TwoDecimas(double number)
        {
            int entero = 0;
            entero = int.Parse((number * 100).ToString());
            double anwser = entero;
            anwser = anwser / 100;
            return anwser;
        }
    }
}