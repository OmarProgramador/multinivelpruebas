
namespace MULTI_NIVEL.Views
{
    using BussinesRules;
    using BussinesRules.Code;
    using BussinesRules.Consuption;
    using BussinesRules.TypeMembership;
    using BussinesRules.User;
    using Entities;
    using System;
    using System.IO;
    using System.Web;
    using System.Web.UI.WebControls;

    public partial class Register : System.Web.UI.Page
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
        BrConsuption brConsuption;
        string respData = "";
        string userName = ";";
        int QuoteInitial = 0;
        string strDate = "";
        Double amount = 0.00;
        BrCode brCode;
        string[] arrayCode;
        double Discount = 0.00;
        int flag = 0;
        int exonaraKit = 0;
        int[] listNUmberDate;
        string def = "profile.png";
        string extension = ".png";
        string name = "";
        string nombreu = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                packafiliaKit.Checked = true;
                Session["financedAmount"] = 0.00;
                Session["nQuotes"] = 0;
                string[] arrayLogin = HttpContext.Current.User.Identity.Name.Split('¬');
                BrInformacion brInformacion = new BrInformacion();
                string info = brInformacion.GetInformation();

                if (!IsPostBack)
                {

                    Session.Remove("sinUpliner");


                    if (!string.IsNullOrEmpty((string)Session["auxRef"]) && (string)Session["auxRef"] == "1")
                    {
                        Session["StatusExonerar"] = "1";
                        exonaraKit = 1;
                        Session["Amount"] = "0.00";
                        lblInt.Text = "1";
                        Session["Discount"] = "1.00";
                        lblAlert.Text = "VALIDO";
                        lblAlert.ForeColor = System.Drawing.Color.Green;
                    }

                    /*PUSH*/
                    brCode = new BrCode();
                    var codes = brCode.GetCode();
                    Session["strCodes"] = codes;
                    Session["Discount"] = 0.00;
                    brPayment = new BrPayments();
                    /* string dataUserFather = (string)Session["Referido"];
                     string data = brPayment.getFatherData(dataUserFather);
                     var listParameters = data.Split('|');
                     nameFather.Text = listParameters[0]+'/'+listParameters[1]+'/'+listParameters[2];*/

                    //ddlSons.Visible = false;

                    userName = arrayLogin[0];

                    if (arrayLogin.Length == 1)
                    {
                        Session["patrocinador"] = arrayLogin[0].ToString();
                        Session["idpatrocinador"] = arrayLogin[2].ToString();
                        Session["nombrepatrocinador"] = arrayLogin[1].ToString();
                    }
                    else
                    {
                        Session["patrocinador"] = arrayLogin[0].ToString();
                        Session["idpatrocinador"] = arrayLogin[0].ToString();
                        Session["nombrepatrocinador"] = arrayLogin[0].ToString();
                    }
                   


                    if (arrayLogin.Length >= 2)
                    {
                        if (arrayLogin[1] != "admin")
                        {
                            rdrEx.Visible = false;
                        }
                    }
                    else
                    {
                        rdrEx.Visible = false;
                    }

                    //lblU.Text = dataUserFather;

                    //if (Session["Referido"] == null)
                    //{
                    //    Response.Redirect("Index.aspx", true);
                    //}

                    bool resp = !string.IsNullOrEmpty((string)Session["Referido"]);
                    if (resp)
                    {
                        string dataUserFather = (string)Session["Referido"].ToString();
                        string data = brPayment.getFatherData(dataUserFather);
                        if (!string.IsNullOrEmpty(data))
                        {
                            var listParameters = data.Split('|');
                            lblName.Text = listParameters[0] + ' ' + listParameters[1];
                            lblU.Text = dataUserFather;
                            brUser = new BrUser();
                            respData = brUser.getSons(lblU.Text);
                            var listParametersData = respData.Split('¬');
                            //string[] socios = { "pc.png", "mic.png", "ipod.png" };
                            var listParametersDataBehind = listParametersData;

                            for (int i = 0; i <= listParametersDataBehind.Length - 1; i++)
                            {
                                var _array = listParametersDataBehind[i].Split('|');
                                _array[0] = "";
                                //ddlSons.DataSource= listParametersDataBehind[i];
                                //ddlSons.Va
                                // ddlSons.Items.Add(new ListItem(listParametersDataBehind[i], i.ToString())); 
                                ddlSons.Items.Add(new ListItem(" " + _array[1] + " " + _array[2] + " / " + _array[3], listParametersData[i].Split('|')[0]));
                                // ddlSons.Items.Add(item);
                            }
                            ddlSons.DataBind();
                        }
                    }
                    if (arrayLogin.Length == 1)
                    {
                        this.lblUser.Text = "Bienvenido";
                        this.lblUserName.Text = "Bienvenido";
                        this.lblNumPartner.Text = "";
                    }
                    else
                    {
                        this.lblUser.Text = "Hola " + arrayLogin[0];
                        this.lblUserName.Text = arrayLogin[0];
                        userName = arrayLogin[0];
                        //this.lblNumPartner.Text = "N° Asociado" + obj[4];
                    }
                    if (true)
                    {
                        this.imgProfile.ImageUrl = "~/Resources/Images/profile.png";
                        this.imgProfileFl.ImageUrl = "~/Resources/Images/profile.png";
                    }


                    //mostrar div para exonerar si es el administrador

                    if (arrayLogin.Length > 2)
                    {
                        //if (int.Parse(arrayLogin[2]) == 1)
                        //{
                        pnlExonerar.Style.Add("Display", "inline");
                        //}
                    }
                    BrTypeMembership brTypeMembership = new BrTypeMembership();
                    string[] rowTypeMembership = brTypeMembership.GetTypeMembership().Split('¬');
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

                    string[] information = brInformacion.GetInformation().Split('¬');

                    listNUmberDate = DaysToChoose(information[0]);
                    brInformacion = null;

                    int monthC = DateTime.Now.Month;
                    string monthCurrent = GetMonth(monthC + 1);
                    string monthNext = GetMonth(monthC + 2);
                    string monthNextDos = GetMonth(monthC + 3);
                    //el dia de pago de cuotas
                    string stringMonth = monthCurrent;
                    int interr = 0;
                    for (int i = 0; i < listNUmberDate.Length; i++)
                    {
                        if (listNUmberDate[i] == 0)
                        {
                            stringMonth = monthNext;
                            interr++;

                            //if (interr > 1)
                            //{
                            //    stringMonth = monthNextDos;
                            //}
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
                    //la validacion por link

                    string[] arrayLink = Session["link"].ToString().Split('|');
                    if (arrayLink.Length > 1)
                    {
                        if (int.Parse(arrayLink[2]) != 0)
                        {
                            ddlSons.SelectedValue = arrayLink[2];
                            ddlSons.Enabled = false;
                        }
                        else
                        {
                            divUpliner.Style.Add("display", "none");
                            Session["sinUpliner"] = "0";
                        }

                    }
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
                imgProfileFl.Style.Add("width", "40px");
                imgProfileFl.Style.Add("height", "40px");
                imgProfileFl.Style.Add("margin", "0 auto");


            }
            catch (Exception ex)
            {
                 
            }
        }

        public string str(string membership)
        {
            this.CodeMembership = membership;
            var arraLogin = HttpContext.Current.User.Identity.Name.Split('¬');
            String padre = arraLogin[0];
            if (arraLogin.Length > 1)
            {
                padre = arraLogin[1];
            }

            Session["MyAffiliate"] = padre;

            string typeAccountBanck = "AHORROS";
            if (rbCuentaCo.Checked)
            {
                typeAccountBanck = "CORRIENTE";
            }

            string nationality = string.Empty;

            nationality = ddlNationality.SelectedValue.ToString();


            //'Nombre|Apellidos|birthDay|M|DocumentType|NroDoc$NombreC|ApellidoC|1|313231c$bankName|nombreBankAccount|TypeAccount|nroAccount|nroTaxer|SocialReason|fiscalAdress|UserType$email|nroCell|nroCell2|country|State|City|Adress'
            //njombre | apellido | 15 - 04 - 2018 | M | 1 | 20202020786$nombrec | apellidosc | 1 | 736800661$3 | namecuen | CORRIENTE | 000 | nc | rz | df | 1$hombrehealth @hotmail.com | 111112122455 | 963258741 | peru | lima | lima | san direccion
            //var nro = ddlSons.SelectedIndex.i;


            var estado = EstadoOthers.Text.Trim();

            var country = ddlCountry.SelectedValue.Trim();
            if (country == "Peru")
            {
                estado = EstadoPeru.SelectedValue.Trim();
            }


            MyConstants myConstants = new MyConstants();
            //string resultDll = ddlSons.SelectedValue.ToString();

            //if (Session["sinUpliner"] != null)
            //{
            var resultDll = "0";
            //}

            if (!string.IsNullOrEmpty(resultDll))  //CONCATENAMIENTO   
            {
                //var listParametersDll = indexSon.Split('|');
                // string IdUpliner = listParametersDll[0];
                data += txtName.Text.Trim() + "|" +
                    txtLastName.Text.Trim() + "|" +
                    ((txtDateNac.Text.Trim())) + "|" +
                    gender + "|" +
                    ddlTypeDoc.SelectedValue.Trim() + "|" +
                    txtNumDoc.Text.Trim() + '$' +
                    txtNameC.Text.Trim() + " |" +
                    txtLastNameC.Text.Trim() + " |" +
                    "1" + "|" +
                    txtnumDocC.Text.Trim() + "|" +
                    BirthdayDateCa.Text + "$" +
                    "EMPTY" + "|" +
                    "EMPTY" + "|" +
                    typeAccountBanck + "|" +
                    "EMPTY" + "|" +
                    "EMPTY" + "|" +
                    "EMPTY" + "|" +
                    "EMPTY" + "|" +
                    ddlTypeAccount.Text.Trim() + "$" +
                    txtEmail.Text.Trim() + "|" +
                    codPais.Text + txtPhone.Text.Trim() + "|" +
                    // txtPhone2.Text.Trim() + " |" +
                    "" + " |" +
                    ddlCountry.Text.Trim() + "|" +
                    estado + "|" +
                    txtCiudad2.Text.Trim() + "|" +
                    txtDireccion.Text.Trim() + "|" +
                    //"" + "|" +
                    membership + "|" +
                    padre + '$' + resultDll
                    + "|" + nationality;

                Session["civilState"] = ddlEstadoCivil.SelectedItem.ToString();
                Session["TypeCurrency"] = ddlTypeCurrency.SelectedValue.ToString();
                return data;
            }
            else
            {

                data += txtName.Text.Trim() + "|" +
                    txtLastName.Text.Trim() + "|" +
                    ((txtDateNac.Text.Trim())) + "|" +
                    gender + "|" +
                    ddlTypeDoc.SelectedValue.Trim() + "|" +
                    txtNumDoc.Text.Trim() + '$' +
                    txtNameC.Text.Trim() + "|" +
                    txtLastNameC.Text.Trim() + "|" +
                    ddlTypeDocC.SelectedValue.Trim() + "|" +
                    txtnumDocC.Text.Trim() + "|" +
                    BirthdayDateCa.Text + "$" +
                    ddlBanck.Text.Trim() + "|" +
                    txtNameTitularCuentaBan.Text.Trim() + "|" +
                    typeAccountBanck + "|" +
                    txtNumCuenta.Text.Trim() + "|" +
                    txtNumContr.Text.Trim() + "|" +
                    txtBusinessName.Text.Trim() + "|" +
                    txtFiscalAddress.Text.Trim() + "|" +
                    ddlTypeAccount.Text.Trim() + "$" +
                    txtEmail.Text.Trim() + "|" +
                    codPais.Text + txtPhone.Text.Trim() + "|" +
                    //txtPhone2.Text.Trim() + "|" +
                    "" + "|" +
                    ddlCountry.Text.Trim() + "|" +
                    estado + "|" +
                    txtCiudad2.Text.Trim() + "|" +
                    txtDireccion.Text.Trim() + "|" +
                    //"" + "|" +
                    membership + "|" +
                    padre + '$' + '0'
                    + "|" + nationality;

                Session["civilState"] = ddlEstadoCivil.SelectedItem.ToString();
                Session["TypeCurrency"] = ddlTypeCurrency.SelectedValue.ToString();
                return data;
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            int interuGende = 0;
            MyConstants myConstants = new MyConstants();
            MyFunctions myFunctions = new MyFunctions();
            brUser = new BrUser();
            Session["nombreregistrado"] = txtName.Text;
            //removermos la sesion de que si la fehca de pago es despues del dia actual
            Session.Remove("IsValidInitial");
            //Session.Remove("Formule");
            //Session.Remove("Amount");
            //Session.Remove("cronogramaYa");
            //Session.Remove("datos");


            //Session.Remove("Discount");
            //Session.Remove("Formule");

            if (Session["Discount"] == null)
            {
                Session["Discount"] = "0";
            }

            bool exonerarKit = false;
            bool eligioMen = false;
            Session["typeBuy"] = "register";

            if (ValidationFields() == false)
            {
                return;
            }

            if (rbMan.Checked)
            {
                gender = "M";
                interuGende++;
            }

            if (rbWoman.Checked)
            {
                gender = "F";
                interuGende++;
            }

            if (interuGende == 0)
            {
                lblMessagge.Text = "El Campo Sexo es Obligatorio.";
                return;
            }

            string currencyCode = ddlTypeCurrency.SelectedValue.ToString();

            if (currencyCode != "PEN" && currencyCode != "USD")
            {
                return;
            }

            //validar si ya tiene el limite de partner que se le pueda otorgar
            string[] arrayLogin = User.Identity.Name.Split('¬');
            string userCurrent = arrayLogin[0];
            if (arrayLogin.Length > 2)
            {
                userCurrent = arrayLogin[1];
            }

            int idPersonCurrent = int.Parse(brUser.GetIdPerson(userCurrent));

            string affiliates = ddlSons.SelectedValue.ToString();
            if (string.IsNullOrEmpty(affiliates))
            {
                return;
            }

            int idAffliate = int.Parse(affiliates);
            //bool anwser = false;
            //bool anwser1 = true;
            //int caseReturn = 0;

            //validar si viene del upliner
            //if (Session["sinUpliner"] == null)
            //{

            //    if (idPersonCurrent == idAffliate)
            //    {
            //        //validar si tiene ya sus cuatros
            //        //verdadero por que pasa el limite
            //        anwser = brUser.IsTeamCompleted(idAffliate);
            //        caseReturn = 1;
            //        anwser1 = false;
            //    }
            //    else
            //    {

            //        //validar si al affliate la se le pueden establecer mas hijos
            //        anwser = brUser.IsHelpTeam(idAffliate);


            //        if (idPersonCurrent == 1)
            //        {
            //            anwser = false;
            //        }


            //        //validamos si tiene sus cuatros
            //        anwser1 = brUser.IsTeamCompleted(idAffliate);

            //        caseReturn = 2;
            //    }



            //    if (anwser || anwser1)
            //    {
            //        if (caseReturn == 1)
            //        {
            //            //true por que no pasa 
            //            lblMessagge.Text = "Tu Equipo ya esta completo!!";
            //            return;
            //        }
            //        if (caseReturn == 2)
            //        {
            //            //true por que no pasa ya le pusieron sus dos 
            //            lblMessagge.Text = "Este Socio ya no puede recibir mas ayuda!!";
            //            return;
            //        }
            //    }

            //}

            if (rbtExp.Checked)
            {
                dataBdd = str("EXP");
                amountInicial = txtInitialEXP.Text.Trim();
                numCuotas = txtNumCuEXP.Text.Trim();
                txtp1 = ExpInitialQuote.Text.Trim();
                eligioMen = true;
            }
            if (rbtStd.Checked == true)
            {
                dataBdd = str("STD");
                amountInicial = txtInitialSTA.Text.Trim();
                numCuotas = txtNumCuSTA.Text.Trim();
                txtp1 = txtStainitialQuote.Text.Trim();
                eligioMen = true;
            }

            if (rbtPlus.Checked)
            {
                dataBdd = str("PLUS");
                amountInicial = txtInitialPLU.Text;
                numCuotas = txtNumCuPLU.Text;
                txtp1 = textPlusQuoteInitial.Text.Trim();
                eligioMen = true;
            }
            if (rbtTop.Checked == true)
            {
                dataBdd = str("TOP");
                amountInicial = txtInitialTOP.Text;
                numCuotas = txtNumCuTOP.Text;
                txtp1 = txtTopCuotaInicial.Text.Trim();
                eligioMen = true;
            }
            if (rbtLight.Checked)
            {
                dataBdd = str("LHT");
                amountInicial = txtInitialLigh.Text.Trim();
                numCuotas = txtNumCuLigh.Text.Trim();
                txtp1 = txtLgtInitialQuote.Text.Trim();
                eligioMen = true;
            }
            if (rbtMd.Checked)
            {
                dataBdd = str("MVC");
                amountInicial = txtInitialMd.Text.Trim();
                numCuotas = txtNumCuMd.Text.Trim();
                txtp1 = txtQuotesInitialMd.Text.Trim();
                eligioMen = true;
            }
            if (rbtVit.Checked)
            {
                dataBdd = str("VIT");
                amountInicial = txtInitialVit.Text.Trim();
                numCuotas = txtNumCuVit.Text.Trim();
                txtp1 = txtVitQuantityInicial.Text.Trim();
                eligioMen = true;
            }
            if (rbtEvol.Checked)
            {
                dataBdd = str("EVOL");
                amountInicial = txtInitialVit.Text.Trim();
                numCuotas = txtNumCuVit.Text.Trim();
                txtp1 = txtQuotesInitialEvol.Text.Trim();
                eligioMen = true;
            }
            if (rbtSby.Checked)
            {
                dataBdd = str("SBY");
                amountInicial = txtInitialSby.Text.Trim();
                numCuotas = txtNumCuSby.Text.Trim();
                txtp1 = txtQuotesInitialSby.Text.Trim();
                eligioMen = true;
            }


            if (rdrEx.SelectedValue == "Exonerar")
            {
                Session["StatusExonerar"] = 1;
            }
            else if (rdrEx.SelectedValue == "NoExonerar")
            {
                Session["StatusExonerar"] = 0;
            }
            else
            {
                Session["StatusExonerar"] = 0;
            }

            BrTypeMembership brTypeMembership = new BrTypeMembership();
            //Register Payment si es kit  inserte unico 'montodolaresKit¬tipocambio¬fecha'
            string[] kitData = brTypeMembership.GetKitData().Split('¬');
            double amountKit = (double.Parse(kitData[0]));
            double tpKit = double.Parse(kitData[1]);
            tpKit = double.Parse(tpKit.ToString("0.00"));

            string date = kitData[2];

            if (string.IsNullOrEmpty(this.CodeMembership) && isExonerar.Checked == false)
            {
                dataBdd = str("KIT");
                Session["datos"] = dataBdd;   //variableDeDatos

                double totalKit = TwoDecimas(amountKit * tpKit);
                string arrayKit = date + "¬" + totalKit.ToString("0.00") + "¬" + totalKit.ToString("0.00") + "¬" + totalKit.ToString("0.00");

                Session["QuoteAux"] = "0";
                Session["Amount"] = (totalKit) - ((Double)Session["Discount"] * totalKit);

                BrPromoter brPromoter = new BrPromoter();
                var llave = brPromoter.IsCodeValid(txtContaExonerar.Text.Trim(), User.Identity.Name.Split('¬')[1]);

                if (llave)
                {
                    Session["Amount"] = 0.00;
                    // el registro es con exoneracion

                    string typeMembership = "KIT";
                    string newUserName = "";

                    string currentUser = "";
                    if (arrayLogin.Length > 1)
                    {
                        currentUser = arrayLogin[1];
                    }

                    string dataBdd = Session["datos"].ToString();
                    typeMembership = (dataBdd.Split('$')[3]).Split('|')[7];
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

                    string[] arrayLink = Session["link"].ToString().Split('|');
                    if (arrayLink.Length > 1)
                    {
                        currentUser = arrayLink[0];
                    }

                    string parameterAccount = arraydata[5].Trim() + "|" + arrayTypeaccount[7].Trim() + '|' + currentUser + '|' + oIdMembreship_amount[0];
                    //'999999999999|1|sa|1'
                    newUserName = brUser.GenerateAccount(parameterAccount);
                    //
                    bool isRegister = false;
                    string memberKit = arrayKit + "¬" + newUserName;
                    //'2018-10-19¬31¬31¬31¬userName'
                    //  isRegister = brUser.PutRegisterkIT(arrayKit);
                    string financedAmount = "0";
                    if (data2 == "0")
                    {
                        data2 = Session["Amount"].ToString();
                    }
                    string codeCurrency = Session["TypeCurrency"].ToString();
                    Int32 ansNmembershi = brUser.RegisterNmembership(typeMembership + '|' + newUserName, financedAmount, 1, codeCurrency);

                    if (ansNmembershi != 0)
                    {
                        isRegister = brUser.PutRegisterkIT(memberKit, ansNmembershi);
                    }
                    //monto a pagar
                    string[] username_idmen_amount_email = brUser.getAmountPay(newUserName).Split('¬');
                    if (username_idmen_amount_email.Length < 4)
                    {
                        Response.Write("false¬Ha Ocurrido Un Error al Intentar Obtener el monto a Pagar");
                        return;
                    }
                    int idMemberDetails = int.Parse(username_idmen_amount_email[1]);
                    double amountPay = double.Parse(username_idmen_amount_email[2]);
                    string emailNewUser = username_idmen_amount_email[3];
                    username_idmen_amount_email = null;
                    bool habiliAccount = brUser.enableAcount(idMemberDetails, "");

                    Response.Redirect("EndPaymentskitExo.aspx");
                }
                else
                {
                    lblMessagge.Text = "Usted no puede registar a un promotor.";
                    return;
                }
            }

            if (eligioMen == true)
            {
                if (string.IsNullOrEmpty(dataBdd))
                {
                    return;
                }
                int minQuotes = 0;
                BrPayments brPayments = new BrPayments();
                var arraydata = dataBdd.Split('|');

                //amount¬quoteInitial¬numQuotes¬descripcioon¬fecha¬tipocambio  ---se le envia el code de la membership

                string[] arrayMontoTotal = brPayments.GetAmountTotal(this.CodeMembership).Split('¬');
                brPayments = null;

                minQuotes = int.Parse(arrayMontoTotal[6]);
                //puedo modificar el valor de membresia solamente a >= asu valor inicial 
                double amountTotalDB = double.Parse(arrayMontoTotal[0]);

                BrCode brCode1 = new BrCode();
                string anwserCode = brCode1.GetCodeSecreto(txtCodSecreto.Text);
                brCode1 = null;

                if (string.Compare(txtCodSecreto.Text, anwserCode, false) == 0)
                {
                    double _valueMembresiaUpdate = double.Parse(ValueMembresiaUpdate.Text);
                    if (_valueMembresiaUpdate > amountTotalDB)
                    {
                        amountTotalDB = _valueMembresiaUpdate;
                    }
                }

                double amountInicialDB = double.Parse(arrayMontoTotal[1]);
                int numCuotasDB = int.Parse(arrayMontoTotal[2]);
                string descripcionDB = arrayMontoTotal[3];
                string fecha = arrayMontoTotal[4];
                string fechaFirtsQuote = arrayMontoTotal[4];


                listNUmberDate = DaysToChoose(arrayMontoTotal[4]);

                string[] arrayDate = (DateTime.Parse(arrayMontoTotal[4]).ToString(myConstants.DateFormatBd)).Split('-');

                if (cbConfig.Checked)
                {
                    string fechaFor = "";
                    string fechaConfig = "";
                    int monthPay = int.Parse(arrayDate[1]);
                    try
                    {
                        var fechacbo = DateCbo.Text.Trim();
                        if (fechacbo == "--Seleccionar--")
                        {
                            lblMessagge.Text = "La Configuracion de fecha de pago se su cuota es incorrecta.";
                            return;
                        }
                        fechaConfig = int.Parse(fechacbo.Split('_')[0].Trim()).ToString("00");
                        monthPay = GetMonth(fechacbo.Split('_')[1].Trim());

                    }
                    catch (Exception)
                    {
                        Response.Redirect("Register.aspx");
                    }
                    if (string.IsNullOrEmpty(fechaConfig))
                    {
                        Response.Redirect("Register.aspx");
                    }
                    int value = Array.IndexOf(listNUmberDate, int.Parse(fechaConfig));
                    if (value < 0 && value > 31)
                    {
                        lblMessagge.Text = "El valor que ha elejido como dia de pago no es valido";
                        return;
                    }
                    if (!string.IsNullOrEmpty(fechaConfig) && value > -1 && value < 30)
                    {
                        fechaFor = arrayDate[0] + '-' + monthPay.ToString("00") + '-' + fechaConfig;
                        fecha = DateTime.Parse(fechaFor).ToString(myConstants.DateFormatBd);
                    }
                    if (IsValidInitial.Checked)
                    {
                        fechaFirtsQuote = DateTime.Parse(fechaFor).ToString(myConstants.DateFormatBd);
                        fecha = DateTime.Parse(fechaFirtsQuote).ToString(myConstants.DateFormatBd);
                        Session["IsValidInitial"] = "true";
                    }
                }

                double tipoCambio = double.Parse(arrayMontoTotal[5]);

                tipoCambio = double.Parse(tipoCambio.ToString("0.00"));

                double amountInicialU = TwoDecimas(double.Parse(amountInicial));

                //validar que la cuota inicial debe ser mayor al valor asignado como minimo
                if (amountInicialU < amountInicialDB)
                {
                    //txtMessagge.Text = "El Monto de la Inicial debe ser Mayor";
                    return;
                }
                //validar que el numero de las cuotas debe ser menor a las asignadas como maximo
                if (int.Parse(numCuotas) > numCuotasDB || int.Parse(numCuotas) <= 0)
                {
                    //txtMessagge.Text = "El Numero de Las Cuotas debe ser Menor";
                    return;
                }
                if ((int.Parse(textPlusQuoteInitial.Text) > 2 || int.Parse(textPlusQuoteInitial.Text) < 1) && CodeMembership == "PLUS")
                {
                    // txtMessagge.Text = "El Numero de Las Cuotas INITIAL debe ser Menor";
                    return;
                }

                if ((int.Parse(textPlusQuoteInitial.Text) > 3 || int.Parse(textPlusQuoteInitial.Text) < 1) && CodeMembership == "TOP")
                {
                    //txtMessagge.Text = "El Numero de Las Cuotas INITIAL debe ser Menor";
                    return;
                }
                //HGHG
                string exonerarkit = Session["StatusExonerar"].ToString();

                double cuotaInicialS = TwoDecimas(amountInicialU * tipoCambio);
                if (!exonerarKit)
                {
                    //suma el monto del kit de unicio
                    //amountTotalDB += TwoDecimas(amountKit);
                    //cuotaInicialS += TwoDecimas(amountKit * tipoCambio);
                }
                int numCuotasU = int.Parse(numCuotas);


                var carDetail = amountTotalDB.ToString("0.00") + "|" + descripcionDB + "|" + numCuotasU + "|" + amountInicialU.ToString("0.00") + "|" + tipoCambio.ToString("0.00") + "|" + amountKit.ToString() + '|' + CodeMembership;

                Session["carrito"] = carDetail;

                //monto total de la membresia debe estar en dolares 
                //la cuota inicial debe estar en soles
                Session["datos"] = dataBdd;  ////variableDeDatos

                //william
                if (rbtTop.Checked)
                {
                    QuoteInitial = Int32.Parse(txtTopCuotaInicial.Text);
                    amount = Double.Parse(txtInitialTOP.Text) * tpKit;
                    if (QuoteInitial > 3 || QuoteInitial < 1)
                    {
                        lblMessagge.Text = "El Numero de cuotas para la Inicial es mayor a la establecida (3)  ";
                        return;
                    }
                    Session["Formule"] = (amount / QuoteInitial) * (double)Session["Discount"];
                    amount = (amount / QuoteInitial) - (amount / QuoteInitial) * (double)Session["Discount"];
                    Session["Amount"] = amount;
                }
                else if (rbtPlus.Checked)
                {
                    QuoteInitial = Int32.Parse(textPlusQuoteInitial.Text);
                    amount = Double.Parse(txtInitialPLU.Text) * tpKit;

                    Session["Formule"] = (amount / QuoteInitial) * (double)Session["Discount"];
                    amount = (amount / QuoteInitial) - (amount / QuoteInitial) * (double)Session["Discount"];
                    Session["Amount"] = amount;
                }
                else if (rbtStd.Checked)
                {
                    //puede cambiar el numero de cuotas de la inicial
                    QuoteInitial = int.Parse(txtStainitialQuote.Text);
                    if (QuoteInitial > 2 || QuoteInitial < 1)
                    {
                        lblMessagge.Text = "El Numero de cuotas para la Inicial es mayor a la establecida (2)  ";
                        return;
                    }

                    amount = Double.Parse(txtInitialSTA.Text) * tpKit;
                    Session["Formule"] = (amount / QuoteInitial) * (double)Session["Discount"];
                    amount = (amount / QuoteInitial) - (amount / QuoteInitial) * (double)Session["Discount"];
                    Session["Amount"] = amount;
                }
                else if (rbtLight.Checked)
                {
                    QuoteInitial = int.Parse(txtLgtInitialQuote.Text.Trim());
                    if (QuoteInitial > 2 || QuoteInitial < 1)
                    {
                        lblMessagge.Text = "El Numero de cuotas para la Inicial es mayor a la establecida (2)  ";
                        return;
                    }
                    amount = Double.Parse(txtInitialLigh.Text) * tpKit;
                    Session["Formule"] = (amount / QuoteInitial) * (double)Session["Discount"];
                    amount = (amount / QuoteInitial) - (amount / QuoteInitial) * (double)Session["Discount"];

                    Session["Amount"] = amount;
                }
                else if (rbtExp.Checked)
                {
                    QuoteInitial = int.Parse(ExpInitialQuote.Text.Trim());
                    if (QuoteInitial > 2 || QuoteInitial < 1)
                    {
                        lblMessagge.Text = "El Numero de cuotas para la Inicial es mayor a la establecida (2)  ";
                        return;
                    }
                    amount = Double.Parse(txtInitialEXP.Text) * tpKit;
                    Session["Formule"] = (amount / QuoteInitial) * (double)Session["Discount"];
                    amount = (amount / QuoteInitial) - (amount / QuoteInitial) * (double)Session["Discount"];
                    Session["Amount"] = amount;
                }
                else if (rbtMd.Checked)
                {
                    QuoteInitial = int.Parse(txtQuotesInitialMd.Text.Trim());
                    if (QuoteInitial > 2 || QuoteInitial < 1)
                    {
                        lblMessagge.Text = "El Numero de cuotas para la Inicial es mayor a la establecida (2)  ";
                        return;
                    }
                    amount = Double.Parse(txtInitialMd.Text) * tpKit;
                    Session["Formule"] = (amount / QuoteInitial) * (double)Session["Discount"];
                    amount = (amount / QuoteInitial) - (amount / QuoteInitial) * (double)Session["Discount"];
                    Session["Amount"] = amount;
                }
                else if (rbtVit.Checked)
                {
                    QuoteInitial = int.Parse(txtVitQuantityInicial.Text.Trim());
                    if (QuoteInitial > 2 || QuoteInitial < 1)
                    {
                        lblMessagge.Text = "El Numero de cuotas para la Inicial es mayor a la establecida (2)  ";
                        return;
                    }
                    amount = Double.Parse(txtInitialVit.Text) * tpKit;
                    Session["Formule"] = (amount / QuoteInitial) * (double)Session["Discount"];
                    amount = (amount / QuoteInitial) - (amount / QuoteInitial) * (double)Session["Discount"];
                    Session["Amount"] = amount;
                }
                else if (rbtEvol.Checked)
                {
                    QuoteInitial = 1;
                    if (QuoteInitial > 2 || QuoteInitial < 1)
                    {
                        lblMessagge.Text = "El Numero de cuotas para la Inicial es mayor a la establecida (2)  ";
                        return;
                    }
                    amount = Double.Parse(txtInitialEvol.Text) * tpKit;
                    Session["Formule"] = (amount / QuoteInitial) * (double)Session["Discount"];
                    amount = (amount / QuoteInitial) - (amount / QuoteInitial) * (double)Session["Discount"];
                    Session["Amount"] = amount;
                }
                else if (rbtSby.Checked)
                {
                    QuoteInitial = 1;
                    if (QuoteInitial > 2 || QuoteInitial < 1)
                    {
                        lblMessagge.Text = "El Numero de cuotas para la Inicial es mayor a la establecida (2)  ";
                        return;
                    }
                    amount = Double.Parse(txtInitialSby.Text) * tpKit;
                    Session["Formule"] = (amount / QuoteInitial) * (double)Session["Discount"];
                    amount = (amount / QuoteInitial) - (amount / QuoteInitial) * (double)Session["Discount"];
                    Session["Amount"] = amount;
                }
                strDate = "";
                string fechaDentro = fecha;

                for (var i = 0; i < QuoteInitial; i++)
                {
                    if (i > 0)
                    {
                        strDate += '|' + fechaDentro + '|' + amount.ToString();
                    }
                    else
                    {
                        strDate += fechaFirtsQuote + '|' + amount.ToString();
                    }

                    var dateAux = ((Convert.ToDateTime(fechaDentro)).AddMonths(1)).ToString("yyyy-MM-dd");
                    fechaDentro = dateAux;

                    if (cbConfig.Checked && IsValidInitial.Checked == false)
                    {
                        dateAux = ((Convert.ToDateTime(fechaDentro)).AddMonths(-1)).ToString("yyyy-MM-dd");
                        fechaDentro = dateAux;
                    }
                }

                BrCode brCode = new BrCode();
                string responseCode = brCode.GetCodeSecreto(txtCodSecreto.Text);

                brCode = null;
                if (string.Compare(txtCodSecreto.Text, responseCode, false) == 0)
                {
                    try
                    {
                        double firtsQuote = double.Parse(QuoteFirts.Text);
                        Session["IsValidInitial"] = "true";
                        if (QuoteInitial >= 1 && firtsQuote > 0)
                        {
                            strDate = "";
                            firtsQuote = firtsQuote * tipoCambio;
                            DateTime firtsDate = DateTime.Parse(myFunctions.DateFormatBd(DateFirts.Text));

                            var dateMax = DateTime.Now.AddDays(45);
                            if (dateMax < firtsDate)
                            {
                                lblMessagge.Text = "La Fecha de la Primera Cuota Supera un Mes despues de la fecha actual";
                                return;
                            }


                            double secondQuote = double.Parse(QuoteSecond.Text);
                            secondQuote = secondQuote * tipoCambio;
                            DateTime secondDate = DateTime.Parse(myFunctions.DateFormatBd(DateSecond.Text));

                            strDate += firtsDate.ToString(myConstants.DateFormatBd) + '|' + firtsQuote.ToString() + "|";
                            strDate += secondDate.ToString(myConstants.DateFormatBd) + '|' + secondQuote.ToString();
                            fechaDentro = secondDate.AddMonths(1).ToString(myConstants.DateFormatBd);
                            double thirdQuote = double.Parse(QuoteThird.Text);
                            if (thirdQuote > 0)
                            {
                                QuoteInitial = 3;
                                thirdQuote = thirdQuote * tipoCambio;
                                DateTime thirdDate = DateTime.Parse(myFunctions.DateFormatBd(DateThird.Text));
                                strDate += "|" + thirdDate.ToString(myConstants.DateFormatBd) + '|' + thirdQuote.ToString();
                                fechaDentro = thirdDate.AddMonths(1).ToString(myConstants.DateFormatBd);
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

                Session["cronograma"] = (Double.Parse((amountTotalDB).ToString()) - (((double)Session["Formule"]) / (tipoCambio))).ToString() + "|" +
                    tipoCambio.ToString("0.00") + "|empty|empty|" + numCuotasU + "|" + fecha + "|" + cuotaInicialS.ToString() + "|" +
                    myConstants.AmountInteresAnual.ToString() + "|" + QuoteInitial.ToString() +
                    "|empty^" + strDate + "~" + txtName.Text.Trim() + "|" + txtLastName.Text.Trim() + "|1" +
                    txtNumDoc.Text.Trim() + "|" + txtNumDoc.Text.Trim() + "$" + fechaDentro;

                Session["typeRegister"] = "2";
                Session["exchange"] = tipoCambio;
                if (string.IsNullOrEmpty(tipoCambio.ToString()))
                {
                    tipoCambio = 0;
                }
                ///
                brPayment = new BrPayments();
                string respData = brPayment.PersonGetData(userName);
                respData = respData + '^' + (string)Session["cronograma"];

                string showReport = "";
                if (minQuotes >= numCuotasU)
                {
                    /*0 interes*/
                    showReport = brPayment.GetCalculatePaymentScheduleString(respData, userName, QuoteInitial.ToString(), "0", true);
                }
                else
                {
                    showReport = brPayment.GetCalculatePaymentScheduleString(respData, userName, QuoteInitial.ToString(), "0", false);
                }
                decimal firtsPay = 0;
                Session["cronogramaYa"] = showReport;
                var macro = showReport.Split('^');
                var micro = macro[1].Split('¬');
                string quoteReference = "";
                for (int i = 0; i <= micro.Length; i++)
                {
                    var listRegisters = micro[i].Split('|');
                    if (listRegisters[0] == "Inicial nro: 1")
                    {
                        firtsPay = decimal.Parse(listRegisters[5].Replace("S/.", ""));
                    }
                    if (listRegisters[0] == "Cuota nro: 1")
                    {
                        quoteReference = listRegisters[5];
                        break;
                    }
                }
                Session["QuoteAux"] = quoteReference;

                Session["FirtsPay"] = firtsPay.ToString();

                ///
                //var ej = "2500|3.25|VE034|VE035|23|2018-09-19|1944|10|1|obs^2018-09-19|1944~nombre|apellido|1|45345345|45345345$2018-10-19";
                Session["JustKit"] = 0;
                string redirect = "Politics";
                if (rbtEvol.Checked || rbtMd.Checked)
                {
                    redirect = "PoliticsTravel";
                }
                if (rbtSby.Checked)
                {
                    redirect = "PoliticsStaBye";
                }
                Response.Redirect(redirect + ".aspx?name=" + txtName.Text + "&lastNama=" + txtLastName.Text + "&pais=" + "pp" + "&dni=" + txtNumDoc.Text);
            }
        }

        public double TwoDecimas(double number)
        {
            int entero = 0;
            entero = int.Parse((number * 100).ToString());
            double anwser = entero;
            anwser = anwser / 100;
            return anwser;
        }

        protected void btnVal_Click(object sender, EventArgs e)
        {
            var arrayLogin = User.Identity.Name.Split('¬');
            BrTypeMembership brTypeMembership = new BrTypeMembership();
            //Register Payment si es kit  inserte unico 'montodolaresKit¬tipocambio¬fecha'
            string[] kitData = brTypeMembership.GetKitData().Split('¬');
            double amountKit = (double.Parse(kitData[0]));
            double tpKit = double.Parse(kitData[1]);
            string date = kitData[2];

            dataBdd = str("KIT");
            Session["datos"] = dataBdd;   //variableDeDatos

            double totalKit = TwoDecimas(amountKit * tpKit);
            string arrayKit = date + "¬" + totalKit.ToString("0.00") + "¬" + totalKit.ToString("0.00") + "¬" + totalKit.ToString("0.00");

            Session["QuoteAux"] = "0";
            Session["Amount"] = "0";

            BrPromoter brPromoter = new BrPromoter();
            var llave = brPromoter.IsCodeValid(txtContaExonerar.Text.Trim(), User.Identity.Name.Split('¬')[1]);

            if (llave)
            {
                Session["Amount"] = 0.00;
                // el registro es con exoneracion

                string typeMembership = "KIT";
                string newUserName = "";

                string currentUser = "";
                if (arrayLogin.Length > 1)
                {
                    currentUser = arrayLogin[1];
                }

                string dataBdd = Session["datos"].ToString();
                typeMembership = (dataBdd.Split('$')[3]).Split('|')[7];
                // string data2 = (string)Session["civilStatus"];
                string data2 = (string)Session["civilState"];

                brUser = new BrUser();
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

                string[] arrayLink = Session["link"].ToString().Split('|');
                if (arrayLink.Length > 1)
                {
                    currentUser = arrayLink[0];
                }

                string parameterAccount = arraydata[5].Trim() + "|" + arrayTypeaccount[7].Trim() + '|' + currentUser + '|' + oIdMembreship_amount[0];
                //'999999999999|1|sa|1'
                newUserName = brUser.GenerateAccount(parameterAccount);
                //
                bool isRegister = false;
                string memberKit = arrayKit + "¬" + newUserName;
                //'2018-10-19¬31¬31¬31¬userName'
                //  isRegister = brUser.PutRegisterkIT(arrayKit);
                string financedAmount = "0";
                if (data2 == "0")
                {
                    data2 = Session["Amount"].ToString();
                }
                string codeCurrency = Session["TypeCurrency"].ToString();
                Int32 ansNmembershi = brUser.RegisterNmembership(typeMembership + '|' + newUserName, financedAmount, 1, codeCurrency);

                if (ansNmembershi != 0)
                {
                    isRegister = brUser.PutRegisterkIT(memberKit, ansNmembershi);
                }
                //monto a pagar
                string[] username_idmen_amount_email = brUser.getAmountPay(newUserName).Split('¬');
                if (username_idmen_amount_email.Length < 4)
                {
                    Response.Write("false¬Ha Ocurrido Un Error al Intentar Obtener el monto a Pagar");
                    return;
                }
                int idMemberDetails = int.Parse(username_idmen_amount_email[1]);
                double amountPay = double.Parse(username_idmen_amount_email[2]);
                string emailNewUser = username_idmen_amount_email[3];
                username_idmen_amount_email = null;
                bool habiliAccount = brUser.EnableAcountPromoter(idMemberDetails, "");

                Response.Redirect("EndPaymentskitExo.aspx");
            }
            else
            {
                lblAlert.Text = "";
                lblAlert.ForeColor = System.Drawing.Color.Red;
                lblAlert.Text = "Codigo Invalido";
            }
        }

        #region Methods
        public bool ValidationFields()
        {
            string nameVa = txtName.Text.Trim();
            string lastNameVa = txtLastName.Text.Trim();

            string birthdayVa = ((txtDateNac.Text.Trim()));
            string typeDocumentVa = ddlTypeDoc.SelectedValue.Trim();
            string numberDocumentVa = txtNumDoc.Text.Trim();

            string emailVa = txtEmail.Text.Trim();
            string phoneVa = txtPhone.Text.Trim();
            string countryVa = ddlCountry.Text.Trim();

            string cityVa = txtCiudad2.Text.Trim();
            //string addressVa = txtDireccion.Text.Trim();
            string addressVa = "";


            var estadoVa = EstadoOthers.Text.Trim();

            var country = ddlCountry.SelectedValue.Trim();
            if (country == "peru")
            {
                estadoVa = EstadoPeru.SelectedValue.Trim();
            }
            //validar si el numero de documento ya existe

            BrUser brUser = new BrUser();
            string[] validarDoc = brUser.VerificarExiste(numberDocumentVa).Split('¬');
            if (validarDoc.Length > 1)
            {
                lblMessagge.Text = "El Numero de Documento ya Existe, Por Favor Ingrese Un Nuevo N° de Documento";
                //divProgressBar.Style.Add("display", "none");
                return false;
            }

            if (string.IsNullOrEmpty(nameVa))
            {
                lblMessagge.Text = "El Nombre No es Correcto";
                divProgressBar.Style.Add("display", "none");
                return false;
            }

            if (string.IsNullOrEmpty(lastNameVa))
            {
                lblMessagge.Text = "El Apellido no es Correcto";
                divProgressBar.Style.Add("display", "none");
                return false;
            }
            Validation ovali = new Validation();
            if (!ovali.IsString(nameVa))
            {
                lblMessagge.Text = "El Nombre No es Correcto";
                divProgressBar.Style.Add("display", "none");
                return false;
            }
            if (!ovali.IsString(lastNameVa))
            {
                lblMessagge.Text = "El Apellido no es Correcto";
                divProgressBar.Style.Add("display", "none");
                return false;
            }
            string[] arrayBirthDay = birthdayVa.Split('/');
            if (arrayBirthDay.Length < 3)
            {
                lblMessagge.Text = "the birthday enter not is valid";
                divProgressBar.Style.Add("display", "none");
                return false;
            }
            if (arrayBirthDay[0].Length != 2 || arrayBirthDay[1].Length != 2 || arrayBirthDay[2].Length != 4)
            {
                lblMessagge.Text = "the birthday enter not is valid -- does not comply with the format";
                divProgressBar.Style.Add("display", "none");
                return false;
            }

            if (!ovali.IsNumber(typeDocumentVa))
            {
                lblMessagge.Text = "el tipo de documento no es una opcion valida";
                divProgressBar.Style.Add("display", "none");
                return false;
            }
            if (int.Parse(typeDocumentVa) == 1)
            {
                if (!ovali.ValidateDni(numberDocumentVa))
                {
                    lblMessagge.Text = "no es un DNI valido";
                    divProgressBar.Style.Add("display", "none");
                    return false;
                }
            }

            if (!ovali.IsEmail(emailVa))
            {
                lblMessagge.Text = "no es un Correo Electronico valido";
                divProgressBar.Style.Add("display", "none");
                return false;
            }

            if (!ovali.IsPhone(phoneVa))
            {
                lblMessagge.Text = "no es un Telefono valido";
                divProgressBar.Style.Add("display", "none");
                return false;
            }

            if (!ovali.IsString(countryVa))
            {
                lblMessagge.Text = "no es un Pais valido";
                divProgressBar.Style.Add("display", "none");
                return false;
            }

            if (!ovali.IsString(estadoVa))
            {
                lblMessagge.Text = "no es una Provincia valido";
                divProgressBar.Style.Add("display", "none");
                return false;
            }

            if (!ovali.IsString(cityVa))
            {
                lblMessagge.Text = "no es un Distrito valido";
                divProgressBar.Style.Add("display", "none");
                return false;
            }

            return true;
        }

        public int[] DaysToChoose(string date)
        {
            string anio = date.Split('-')[0];
            string month = date.Split('-')[1];
            int day = int.Parse(date.Split('-')[2]);

            string newDatem = DateTime.Parse(anio + "-" + month + "-01").AddMonths(1).ToString("yyyy-MM-dd");
            string newDatemc = DateTime.Now.AddMonths(1).ToString("yyyy-MM-dd");
            string newDate = DateTime.Parse(newDatem).AddDays(-1).ToString("yyyy-MM-dd");

            int endDay = int.Parse(newDate.Split('-')[2]);
            int[] arrayDay = new int[32];
            int contador = -1;
            //for (int i = (day - 7); i < (day); i++)
            //{
            //    arrayDay[contador] = i;
            //    contador++;
            //}

            int contadorDay = day;
            int contadorMen = day - 7;

            for (int i = 0; i < 7; i++)
            {

                try
                {
                    contador++;
                    contadorMen = contadorMen + 1;
                    var fecha = DateTime.Parse(anio + "-" + month + "-" + (contadorMen).ToString());

                    arrayDay[contador] = contadorMen;

                }
                catch (Exception ex)
                {
                    string error = ex.Message;
                    i -= 1;
                }

            }

            int contadorMas = day;
            //contador++;
            //arrayDay[contador] = 0;

            int interructor = 0;
            int untilDay = int.Parse(newDatemc.Split('-')[2]);
            for (int i = 0; i < 16; i++)
            {
                try
                {
                    if (interructor == 0)
                    {
                        contador++;
                        contadorMas = contadorMas + 1;
                        var fecha = DateTime.Parse(anio + "-" + month + "-" + (contadorMas).ToString());

                        arrayDay[contador] = contadorMas;
                    }
                    interructor = 0;
                }
                catch (Exception ex)
                {
                    interructor = 1;
                    string error = ex.Message;
                    i -= 1;
                    contadorMas = 0;
                    contador++;
                    arrayDay[contador] = contadorMas;
                }

            }

            //Array.Sort(arrayDay);

            return arrayDay;
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

        #endregion
    }
}