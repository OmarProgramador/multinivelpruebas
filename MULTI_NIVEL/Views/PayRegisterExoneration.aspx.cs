using BussinesRules.Consuption;
using BussinesRules.TypeMembership;
using BussinesRules.User;
using Entities;
using System;
using System.Web;

namespace MULTI_NIVEL.Views
{
    public partial class PayRegisterExoneration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


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

            if (Session["typeRegister"] == null)
                Session["typeRegister"] = 0;

            typeRegister = int.Parse(Session["typeRegister"].ToString());
            //formPay = int.Parse(Session["formPay"].ToString());
            formPay = int.Parse("1");
            // token = Request["token"].ToString();
            numberQuotes = 1;
            brUser = new BrUser();
            brTypeMembership = new BrTypeMembership();
            dataLogin = HttpContext.Current.User.Identity.Name.Split('¬');
            oEmail = new Email();
            brPayments = new BrPayments();
            brConsuption = new BrConsuption();
            string TypeMembership = "";



            userCurrent = dataLogin[0];
            if (dataLogin.Length > 1)
            {
                userCurrent = dataLogin[1];
            }



            if (formPay == 1)
            {
                string dataBdd = Session["datos"].ToString();
                TypeMembership = (dataBdd.Split('$')[3]).Split('|')[7];
                string data2 = (string)Session["civilState"];
                string[] oIdMembreship_amount = brUser.RegisterUser(dataBdd, data2).Split('¬');

                if (oIdMembreship_amount.Length < 2)
                {
                    //Response.Write("false¬Ha Ocurrido Un Error al Intentar Registrar al Usuario1");
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

                if (string.IsNullOrEmpty(newUserName))
                {
                    //Response.Write("false¬Ha Ocurrido Un Error al Intentar Registrar al Usuario2");
                    //Response.Redirect("Pagos.aspx");
                    return;
                }
            }


            if (typeRegister == 1)
            {
                // string arrayKit = Session["arrayKit"].ToString() + "¬" + newUserName;
                //'2018-10-19¬31¬31¬31¬userName'
                //isRegister = brUser.PutRegisterkIT(arrayKit);
                string arrayKit = Session["arrayKit"].ToString() + "¬" + newUserName;
                //'2018-10-19¬31¬31¬31¬userName'
                string data2 = Session["financedAmount"].ToString();
                string codeCurrency = Session["TypeCurrency"].ToString();

                Int32 ansNmembershi = brUser.RegisterNmembership(TypeMembership + '|' + newUserName, data2, 1, codeCurrency);
                isRegister = brUser.PutRegisterkIT(arrayKit, ansNmembershi);
                //monto a pagar
                string[] username_idmen_amount_email = brUser.getAmountPay(newUserName).Split('¬');
                /*UPDATE*/
                bool resp = brPayments.InitialExoneration(newUserName);
                // bool notAvilable = brUser.NotAvailableUser(newUserName);
                Response.Redirect("EndPayments.aspx");
            }

            if (typeRegister == 2)
            {
                dataKitMember = Session["cronograma"].ToString();

                string date = dataKitMember.Split('$')[1];

                string respData = brPayments.PersonGetData(newUserName);


                respData = respData + '^' + dataKitMember;
                // isRegister = brPayments.GetCalculatePaymentSchedule(respData, newUserName);
                string data2 = Session["financedAmount"].ToString();
                string codeCurrency = Session["TypeCurrency"].ToString();

                Int32 ansNmembershi = brUser.RegisterNmembership(TypeMembership + '|' + newUserName, data2, 1, codeCurrency);
                var exchange = Session["exchange"];
                if (string.IsNullOrEmpty(exchange.ToString()))
                {
                    exchange = "0.00";
                }
                isRegister = brPayments.GetCalculatePaymentSchedule(respData, newUserName, ansNmembershi, exchange.ToString(), 1);

                //validamos si tiene consumo
                if (!isRegister)
                {
                    // Response.Write("false¬Ha Ocurrido Un Error al Intentar Registrar el Cronograma de Pagos del Usuario");
                    //Response.Redirect("Pagos.aspx");
                    return;
                }
                //obtengo el monto a pagar
                string[] username_idmen_amount_email = brUser.getAmountPay(newUserName).Split('¬');
                if (username_idmen_amount_email.Length < 4)
                {
                    //Response.Write("false¬Ha Ocurrido Un Error al Intentar Obtener el monto a Pagar");
                    //Response.Redirect("Pagos.aspx");
                    return;
                }
                idMemberDetails = int.Parse(username_idmen_amount_email[1]);
                amountPay = double.Parse(username_idmen_amount_email[2]);
                emailNewUser = username_idmen_amount_email[3];
                date = null;
                username_idmen_amount_email = null;
                dataKitMember = null;
                respData = null;
                /*UPDATE*/
                bool resp = brPayments.InitialExoneration(newUserName);
                //  bool notAvilable = brUser.NotAvailableUser(newUserName);
                Response.Redirect("EndPayments.aspx");
            }
        }
    }
}