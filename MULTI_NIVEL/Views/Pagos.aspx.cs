
namespace MULTI_NIVEL
{
    using BussinesRules;
    using BussinesRules.User;
    using System;
    using System.Web;

    public partial class Pagos : System.Web.UI.Page
    {
        BrUser brUser;
        string newUserName = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                btnProcess.Style["Visibility"] = "visible";
                btnContinue.Style["Visibility"] = "hidden";
                btnProcessPay.Style["Visibility"] = "hidden";
                Button1.Style["Visibility"] = "hidden";

                if (!IsPostBack)
                {
                    BrMembershipPayDetail brMembership = new BrMembershipPayDetail();
                    string[] listParameters;
                    listParameters = new string[300];
                    string req = "";
                    double tipocambio = 0.00;
                    double subtotalkit = 0.00;
                    string quote = "";
                    req = (string)Session["carrito"];

                    if (!string.IsNullOrEmpty(req))
                    {
                        if (Session["Discount"] == null)
                            Session["Discount"] = 0;
                        //cambie esto samir pazo
                        if (Convert.ToDouble(Session["Discount"]) <= 1)
                        {
                            lblDiscount.Text = Convert.ToDouble(Session["Discount"]).ToString();
                        }

                        req = Session["carrito"].ToString();
                        listParameters = req.Split('|');
                        tipocambio = double.Parse(Session["carrito"].ToString().Split('|')[4]);
                        decimal typeChange = decimal.Parse(Session["carrito"].ToString().Split('|')[4]);
                        subtotalkit = double.Parse(listParameters[3]) * tipocambio;

                        string cuurencyCode = Session["TypeCurrency"].ToString();

                        if (Session["Amount"] == null)
                            Session["Amount"] = 0;

                        decimal amountSoles = decimal.Parse(Session["Amount"].ToString());
                        decimal amountDolar = amountSoles / typeChange;
                        ccc.Text = "";
                        if (cuurencyCode == "PEN")
                        {
                            lblPriceUnit.Text = amountSoles.ToString() + " PEN";
                            lblSubTotal.Text = subtotalkit.ToString();
                            double total = 0.00;

                            if (Session["JustKit"] != null)
                            {
                                if ((int)Session["JustKit"] != 1)
                                {
                                    total = double.Parse(lblSubTotal.Text) - 10;
                                }
                            }
                            else
                            {
                                total = double.Parse(lblSubTotal.Text);
                            }

                            lblSubTotal.Text = amountSoles.ToString() + " PEN";
                            lblExchange.Text = tipocambio.ToString();

                            lblCostQuote.Text = amountSoles.ToString() + " PEN";

                            lblTot.Text = amountSoles.ToString() + " PEN";
                        }
                        else
                        {
                            lblPriceUnit.Text = amountDolar.ToString() + " " + " USD";
                            lblSubTotal.Text = subtotalkit.ToString();
                            double total = 0.00;

                            if (Session["JustKit"] != null)
                            {
                                total = double.Parse(lblSubTotal.Text) - 10;
                            }
                            else
                            {
                                total = double.Parse(lblSubTotal.Text);
                            }

                            lblSubTotal.Text = amountDolar.ToString() + " USD";
                            lblExchange.Text = tipocambio.ToString();

                            lblCostQuote.Text = amountDolar.ToString() + " USD";

                            lblTot.Text = amountDolar.ToString() + " USD";
                        }





                        //lblCostQuote.Text = lblTot.Text;
                        //Session["Amount"] = lblCostQuote.Text;
                        lblDescription.Text = listParameters[1];
                        if (Session["JustKit"] != null)
                        {
                            panel1.Visible = false;
                            lblDescription.Text = "KIT DE INICIO";
                            lblDescription.Visible = true;
                        }
                    }
                    else
                    {

                        //pago de cuotaa
                        //almacenamientoValorCuota
                        //quote = Request["quota"].ToString();
                        int id = int.Parse(Request["id"].ToString());
                        string numCuota = Request["numCuota"].ToString();
                        //samir seguridad del valor de su cuota
                        string[] arrayLogin = User.Identity.Name.Split('¬');

                        lblDescription.Text = numCuota;

                        var response = brMembership.GetQuote(id, arrayLogin[1]).Split('|');
                        quote = response[0];
                        DateTime payDate = DateTime.Parse(response[1] + " 23:59:59");
                        //DateTime payDate = DateTime.Parse("2019-04-04 23:59:59");
                        if (decimal.Parse(quote) == decimal.Parse("0"))
                        {
                            Response.Redirect("Index.aspx", true);
                            return;
                        }
                        BrDaysFree daysFree = new BrDaysFree();

                        bool success = daysFree.Qualify(arrayLogin[1], id);

                        if (payDate < DateTime.Now && success)
                        {
                            // im nq
                            Response.Redirect("ChangingSchedule.aspx?im=" + id.ToString() + "&nq=1", true);
                            return;
                        }

                        Session["CurrencyCode"] = response[2];
                        Session["IdImg"] = id.ToString();
                        Session["StatusCalendar"] = id.ToString();
                        lblPriceUnit.Text = quote + "" + response[2];


                        lblSubTotal.Text = quote + " " + response[2];
                        lblExchange.Text = tipocambio.ToString();
                        lblTot.Text = quote;
                        ccc.Text = response[2];
                        lblCostQuote.Text = quote;

                        panel1.Visible = false;
                        //lblDescription.Text = "KIT DE INICIO";
                        //lblDescription.Visible = true;
                        Session["quotePay"] = quote;
                        Session["numCuota"] = numCuota;

                    }
                    if (lblSubTotal.Text == "0 PEN" || lblSubTotal.Text == "0 USD")
                    {
                        btnProcess.Style["Visibility"] = "hidden";
                        btnContinue.Style["Visibility"] = "visible";
                        btnProcessPay.Style["Visibility"] = "hidden";

                        Response.Redirect("PayRegisterExoneration.aspx");
                        return;
                    }
                    else
                    {
                        btnProcessPay.Style["Visibility"] = "visible";
                        btnContinue.Style["Visibility"] = "hidden";
                    }
                }

            }
            catch (Exception ex)
            {
                Response.Redirect("Index.aspx?error=" + ex.StackTrace, true);
            }
        }

        protected void btnProcessPay_Click(object sender, EventArgs e)
        {
            if (Session["dummy"] == null)
            {
                // Session["dummy"] = "dummy";

                if (lblSubTotal.Text == "0 USD" || lblSubTotal.Text == "0 USD")
                {
                    Response.Redirect("PayRegisterExoneration.aspx");
                    return;


                }
                else
                {
                    Response.Redirect("Pagos.aspx");
                    return;
                }
            }
        }

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            if (Session["dummy"] == null)
            {
                //Session["dummy"] = "dummy";

                if (rdrCulqi.Checked)
                {
                    Session["formPay"] = "1";
                    Response.Redirect("PayOnLine.aspx");

                }
                else if (rdrTransfer.Checked)
                {
                    Session["formPayd"] = "2";
                    Response.Redirect("PayDeposito.aspx");

                }
                else if (rdrTransfer2.Checked)
                {
                    Session["formPayd"] = "3";
                    Response.Redirect("PayDeposito.aspx");

                }
                else if (rdrStor.Checked)
                {
                    Session["formPayd"] = "4";
                    Response.Redirect("PayDeposito.aspx");

                }
                else
                {
                    if (lblSubTotal.Text == "S/0")
                    {
                        Response.Redirect("PayRegisterExoneration.aspx");
                        return;
                    }
                    else
                    {
                        Response.Redirect("Pagos.aspx");
                        return;
                    }
                }
            }
        }

        public void registerTodo(int metodo)
        {
            brUser = new BrUser();
            int typeRegister = 0;
            typeRegister = int.Parse(Session["typeRegister"].ToString());
            //REGISTER
            string[] dataLogin = HttpContext.Current.User.Identity.Name.Split('¬');
            string userCurrent = dataLogin[0];
            if (dataLogin.Length > 1)
            {
                userCurrent = dataLogin[1];
            }
            string dataBdd = Session["datos"].ToString();
            string TypeMembership = (dataBdd.Split('$')[3]).Split('|')[7];
            string data2 = (string)Session["civilState"];
            string[] oIdMembreship_amount = brUser.RegisterUser(dataBdd, data2).Split('¬');

            if (oIdMembreship_amount.Length < 2)
            {
                //  Response.Write("false¬Ha Ocurrido Un Error al Intentar Registrar al Usuario");
                Response.Redirect("Pagos.aspx");
                return;
            }

            string[] parameterPerson = dataBdd.Split('$');
            string[] arraydata = parameterPerson[0].Split('|');
            string[] arrayTypeaccount = parameterPerson[2].Split('|');
            string[] arrayaccount = parameterPerson[3].Split('|');

            string parameterAccount = arraydata[5].Trim() + "|" + arrayTypeaccount[7].Trim() + '|' + userCurrent + '|' + oIdMembreship_amount[0];
            //'999999999999|1|sa|1'
            newUserName = brUser.GenerateAccount(parameterAccount);
            bool ans = brUser.ActivateAccount(newUserName);
            // bool notAvilable = brUser.NotAvailableUser(newUserName);
            if (string.IsNullOrEmpty(newUserName))
            {
                //Response.Write("false¬Ha Ocurrido Un Error al Intentar Registrar al Usuario");
                Response.Redirect("Pagos.aspx");
                return;
            }

            //END REGISTER
            if (typeRegister == 1)
            {
                string arrayKit = Session["arrayKit"].ToString() + "¬" + newUserName;
                //'2018-10-19¬31¬31¬31¬userName'
                string data3 = Session["financedAmount"].ToString();
                string codeCurrency = Session["TypeCurrency"].ToString();

                Int32 ansNmembershi = brUser.RegisterNmembership(TypeMembership + '|' + newUserName, data3, 1, codeCurrency);
                bool isRegister = brUser.PutRegisterkIT(arrayKit, ansNmembershi);
                if (lblSubTotal.Text == "S/0")
                {
                    bool payInitial = brUser.PayInitial(newUserName);


                }
                //monto a pagar
                string[] username_idmen_amount_email = brUser.getAmountPay(newUserName).Split('¬');
                if (username_idmen_amount_email.Length < 4)
                {
                    Response.Write("false¬Ha Ocurrido Un Error al Intentar Obtener el monto a Pagar");
                    return;
                }
                /*subidaDeRecibo con newUserName*/
                BrPayments brPayments = new BrPayments();
                // bool upload = brPayments.UploadReceipt(newUserName + '|' + nombreArchivo);

                int idMemberDetails = int.Parse(username_idmen_amount_email[1]);
                double amountPay = double.Parse(username_idmen_amount_email[2]);
                string emailNewUser = username_idmen_amount_email[3];
                username_idmen_amount_email = null;
            }

            if (typeRegister == 2)
            {
                string dataKitMember = Session["cronograma"].ToString();

                string date = dataKitMember.Split('$')[1];
                BrPayments brPayments = new BrPayments();
                string respData = brPayments.PersonGetData(newUserName);
                respData = respData + '^' + dataKitMember;
                brUser = new BrUser()
;             //  bool ansNmembershi = brUser.RegisterNmembership(respData+'|'+ newUserName);
                string data3 = Session["financedAmount"].ToString();
                string codeCurrency = Session["TypeCurrency"].ToString();

                Int32 ansNmembershi = brUser.RegisterNmembership(TypeMembership + '|' + newUserName, data3, 1, codeCurrency);
                string exchange = Session["carrito"].ToString().Split('|')[4];
                bool isRegister = brPayments.GetCalculatePaymentSchedule(respData, newUserName, ansNmembershi, exchange, 0);
                if (lblSubTotal.Text == "S/0")
                {
                    bool payInitial = brUser.PayInitial(newUserName);


                }
                /*subidaDeRecibo con newUserName*/
                //  bool upload = brPayments.UploadReceipt(newUserName + '|' + nombreArchivo);

                //validamos si tiene consumo


                if (!isRegister)
                {
                    // Response.Write("false¬Ha Ocurrido Un Error al Intentar Registrar el Cronograma de Pagos del Usuario");
                    Response.Redirect("Pagos.aspx");
                    return;
                }
                //obtengo el monto a pagar
                string[] username_idmen_amount_email = brUser.getAmountPay(newUserName).Split('¬');
                if (username_idmen_amount_email.Length < 4)
                {
                    //  Response.Write("false¬Ha Ocurrido Un Error al Intentar Obtener el monto a Pagar");
                    Response.Redirect("Pagos.aspx");
                    return;
                }
                //idMemberDetails = int.Parse(username_idmen_amount_email[1]);
                //amountPay = double.Parse(username_idmen_amount_email[2]);
                //emailNewUser = username_idmen_amount_email[3];
                date = null;
                username_idmen_amount_email = null;
                dataKitMember = null;
                respData = null;
            }
            //si se efectuo el envio
            //Response.Redirect("EndPayments3.aspx",true);
            return;
            /*TRY MERGE*/
        }

        protected void btnContinue_Click(object sender, EventArgs e)
        {

        }
    }

}