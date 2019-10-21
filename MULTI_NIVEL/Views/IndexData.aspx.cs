
namespace MULTI_NIVEL.Views
{
    using BussinesRules.User;
    using Entities;
    using System;
    using System.Web;

    public partial class IndexData : System.Web.UI.Page
    {
        public string NewUserName { get; set; }
        public string[] username_idmen_amount_email { get; set; }
        public int IdMembreship { get; set; }
        public int NumberQuotes { get; set; }

        public int CodeIgnore { get; set; }
        public int Exonerar { get; set; }
        public int IsCronograma { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            //declaracion de variables
            int opcionRegister = 0;
            BrUser brUser;
            BrPayments brPayments;

            string parameterToken = null;
            string oNumberQuotes = null;
            this.NumberQuotes = int.Parse(Request["numcuotes"]);

            parameterToken = Request["token"];
            oNumberQuotes = Request["numcuotes"];
            this.NumberQuotes = int.Parse(Request["numcuotes"]);
            this.CodeIgnore = 0;

            //string parameterToken = "";
            if (string.IsNullOrEmpty(parameterToken))
            {
                Response.Write("false¬Ha Ocurrido un Error Al Intentar Token");
                return;
            }
            if (string.IsNullOrEmpty(oNumberQuotes))
            {
                Response.Write("false¬Ha Ocurrido un Error,el numero de Cuotas es Invalido");
                return;
            }


            if (this.NumberQuotes < 1)
            {
                Response.Write("false¬Ha Ocurrido un Error,el numero de Cuotas es Invalido");
                return;
            }
            if (this.NumberQuotes > 32)
            {
                Response.Write("false¬Ha Ocurrido un Error,el numero de Cuotas es Invalido");
                return;
            }

            //Session["datos"] = "samir|torres|cuarto|15-04-2018|M|programador.pazo@gmail.com|111112122212|ubigeo|1|20202020845454|EXP|knava|1|50|24";
            /*registes user and general account*/
            if (Session["datos"] != null)
            {
                //cuando va a registrar
                string dataBdd = Session["datos"].ToString();
                string TypeMembership = (dataBdd.Split('$')[3]).Split('|')[7];
                BrUser obrUser = new BrUser();
                string data2 = (string)Session["civilState"];
                string idMembreship_amount = obrUser.RegisterUser(dataBdd, data2);
                var oIdMembreship_amount = idMembreship_amount.Split('¬');

                if (oIdMembreship_amount.Length < 2)
                {
                    Response.Write("false¬Ha Ocurrido Un Error al Intentar Registrar al Usuario");
                    return;
                }

                var parameterPerson = dataBdd.Split('$');

                var arraydata = parameterPerson[0].Split('|');
                var arrayTypeaccount = parameterPerson[2].Split('|');
                var arrayaccount = parameterPerson[3].Split('|');

                var arrayInfo = HttpContext.Current.User.Identity.Name.Split('¬');

                string padre = arrayInfo[0];
                if (arrayInfo.Length > 1)
                {
                    padre = arrayInfo[1];
                }/*merge*/

                string parameterAccount = arraydata[5].Trim() + "|" + arrayTypeaccount[7].Trim() + '|' + padre + '|' + oIdMembreship_amount[0];
                //'999999999999|1|sa|1'
                this.NewUserName = obrUser.GenerateAccount(parameterAccount);

                if (string.IsNullOrEmpty(this.NewUserName))
                {
                    Response.Write("false¬Ha Ocurrido Un Error al Intentar Generar la Cuenta de Usuario");
                    return;
                }

                brPayments = new BrPayments();

                //IdPerson | empty ^ amountDollars | changeTo | empty | empty | nQuote | InititalDate | InitalAmount | PercentInterest | default:1 | Empty ^ QuoteDate | InitalAmountQuote ~vvhvbnvbnvb|nvbnvbnvbnvb|1|6756575|67567567$2018-09-19
                var listParameters = HttpContext.Current.User.Identity.Name.Split('¬'); //fullName,userName

                var userName = listParameters[0];

                if (listParameters.Length > 1)
                {
                    userName = listParameters[1];
                }
                //sacar monto

                if (!string.IsNullOrEmpty((string)Session["SwitchAmort"]))
                {
                    var values = (string)Session["dataAmort"];
                    var arrayValues = values.Split('|');
                    if (!string.IsNullOrEmpty(values))
                    {
                        brPayments = new BrPayments();
                        // (int TypePay, string IdMembershipDetail, int nQuotes, decimal NewAmort, int Rate)
                        bool ans = brPayments.Amortization(2, arrayValues[0], Int32.Parse(arrayValues[1]), decimal.Parse(arrayValues[2]), Int32.Parse(arrayValues[3]), "culqi");

                        Response.Redirect("Payments.aspx");
                        return;
                    }
                }
                else if (Session["cronograma"] != null)
                {
                    var ej = Session["cronograma"].ToString();
                    bool registerCronograma = false;
                    //si es kit  inserte unico '2018-10-19¬31¬31¬31¬HOLA'

                    string fecha = ej.Split('$')[1];

                    //double amountKit = double.Parse("10");
                    //double tpKit = double.Parse(ej.Split('|')[1]);

                    //double totalKit = (amountKit * tpKit);
                    //string arrayKit = fecha + "¬" + totalKit.ToString() + "¬" + totalKit.ToString() + "¬" + totalKit.ToString() + "¬" + this.UserName;

                    //registerCronograma = brPayments.PutRegisterkIT(arrayKit);

                    //if (!registerCronograma)
                    //{
                    //    Response.Write("false¬Ha Ocurrido Un Error al Intentar Registrar el Kit de Inicio");
                    //    return;
                    //}
                    //var ej = "2500|3.25|VE034|VE035|23|2018-09-19|1944|10|1|obs^2018-09-19|1944~nombre|apellido|1|45345345|45345345$2018-10-19";
                    //1|EXP  ^6300.00|3.25|empty|empty|60|2018-10-17|2047.5|10|1|empty^2018-10-17|2047.5~Jose|dcvsdf|1966660000|966660000$2018-11-01
                    string respData = brPayments.PersonGetData(userName);  //1|EXP|knava vs|CLB^3000|3.2|VE034|VE035|24|2018-10-10|soles1000|10|1|obs^2018-10-11|1000~nombres|apellidos|1|73680066|963258741$2018-10-12
                    respData = respData + '^' + ej;
                    brUser = new BrUser();
                    string data3 = Session["financedAmount"].ToString();
                    //  Int32 ansNmembershi = brUser.RegisterNmembership(TypeMembership + '|' + userName, data3);
                    // registerCronograma = brPayments.GetCalculatePaymentSchedule(respData, this.NewUserName, ansNmembershi);


                    if (!registerCronograma)
                    {
                        Response.Write("false¬Ha Ocurrido Un Error al Intentar Registrar el Cronograma de Pagos del Usuario");
                        return;
                    }

                    this.IsCronograma = 1;
                    // en el caso que tenga cronograma de pagos
                    BrUser brUser2 = new BrUser();
                    //this.UserName = "knava";
                    //monto a pagar en el registro
                    this.username_idmen_amount_email = brUser2.getAmountPay(this.NewUserName).Split('¬');
                    //username¬amount¬email
                    brUser2 = null;

                    if (this.username_idmen_amount_email.Length < 4)
                    {
                        Response.Write("false¬Ha Ocurrido un Error al Intentar Verificar el Monto a Pagar");
                        return;
                    }

                    if (Session["exonerar"] != null)
                    {
                        if (Session["exonerar"].ToString() == "true")
                        {
                            this.Exonerar = 1;
                        }

                    }


                    var change = HttpContext.Current.User.Identity.Name.Split('¬')[5];
                    //le agrego el monto del kit
                    //username_idmen_amount_email[2] = (double.Parse(username_idmen_amount_email[2]) + (double.Parse("10") * double.Parse(change))).ToString(); 
                }
                else
                {
                    this.CodeIgnore = 1;
                }
                Email email2 = new Email();
                if (!email2.SubmitEmail(arrayaccount[0].Trim(), "[USUARIO_REGISTRADO]", "Tu usuario Es :" + this.NewUserName.ToUpper() + "\n" + "Tu contraseña es:" + this.NewUserName.ToUpper()))
                {
                    Response.Write("false¬Ha Ocurrido un Error al Intentar Enviarle un Email Con Sus Datos de su Cuenta");
                    return;
                }
                email2 = null;
            }
            else
            {

                if (Session["kit"] != null)
                {
                    this.CodeIgnore = 1;
                }
                else
                {
                    var login = HttpContext.Current.User.Identity.Name.Split('¬');
                    if (login.Length > 1)
                    {


                        this.IdMembreship = int.Parse(Session["numMembershipDet"].ToString());
                        BrUser brUser1 = new BrUser();
                        this.NewUserName = login[1];
                        this.username_idmen_amount_email = brUser1.getAmountPay(this.IdMembreship, this.NewUserName).Split('¬');
                        brUser1 = null;
                        if (this.username_idmen_amount_email.Length < 4)
                        {
                            Response.Write("false¬Ha Ocurrido un Error al Intentar Verificar el Monto a Pagar");
                            return;
                        }

                    }
                    else
                    {
                        Response.Write("false¬Intentelo mas Tarde");
                        return;
                    }
                }

            }
            /*end register user and general account*/


            /*page on line*/

            if (this.CodeIgnore == 0)
            {
                if (username_idmen_amount_email.Length < 4)
                {
                    Response.Write("false¬Ha Ocurrido un Error al Intentar Verificar el Monto a Pagar");
                    return;
                }
            }


            double monto = 0;

            //solo el kit
            if (this.CodeIgnore == 1)
            {
                monto = double.Parse("10") * double.Parse(Session["tipocambio"].ToString());
            }

            if (this.CodeIgnore == 0)
            {

                if (this.Exonerar != 1)
                {
                    monto = double.Parse(username_idmen_amount_email[2]) + (double.Parse("10") * double.Parse(Session["tipocambio"].ToString()));

                }

                else
                {
                    monto = double.Parse(username_idmen_amount_email[2]);
                }
            }


            PayCulqi payCulqi = new PayCulqi();
            string currencyCode = "PEN";
            string[] culqiAnwser = payCulqi.newPayment(this.NewUserName, "samirpazo08@gmail.com", monto, parameterToken, this.NumberQuotes, currencyCode).Split('¬');


            string miemail = "";

            if (this.CodeIgnore == 1)
            {
                miemail = Session["email"].ToString();
            }
            else
            {
                miemail = username_idmen_amount_email[3];
                brUser = new BrUser();
                bool habiliAccount = brUser.enableAcount(int.Parse(username_idmen_amount_email[1]), "");
                brUser = null;
                //enviar el email de confirmacion con la data y lo redirecciona al post register
                if (!habiliAccount)
                {
                    Response.Write("false¬Ha Ocurrido un Error al Intentar Habilitar Su Cuenta.");
                    return;
                }

            }

            Email email = new Email();
            if (email.SubmitEmail(miemail, "[RIBERA DEL RIO - PAGO]", "Ud. Ha efectuado su pago en Ribera del Rio con Exito."))
            {
                email = null;
                Response.Clear();
                Response.Write("true¬" + culqiAnwser[1]);
                Session["datos"] = null;
                return;
            }
            Response.Write("false");
            return;
        }
    }
}