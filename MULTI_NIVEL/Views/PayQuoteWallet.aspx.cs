using BussinesRules;
using System;

namespace MULTI_NIVEL.Views
{
    public partial class PayQuoteWallet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string typeChange = string.Empty;
                BrMembershipPayDetail brMembership = new BrMembershipPayDetail();
                //pago de cuotaa
                //almacenamientoValorCuota
                //quote = Request["quota"].ToString();

                //int id = 0;
                //string numCuota = "";

                int id = int.Parse(Request["id"].ToString());
                string numCuota = Request["numCuota"].ToString();

                //samir seguridad del valor de su cuota
                string[] arrayLogin = User.Identity.Name.Split('¬');
                typeChange = arrayLogin[5];
                if (arrayLogin.Length < 5)
                {
                    return;
                }
                lblDescription.Text = numCuota;

                var response = brMembership.GetQuote(id, arrayLogin[1]).Split('|');

                if (response.Length < 2)
                {
                    Response.Redirect("Payments.aspx", true);
                    return;
                }

                var quote = response[0];
                DateTime payDate = DateTime.Parse(response[1] + " 23:59:59").AddDays(15);
                //DateTime payDate = DateTime.Parse("2019-07-01 23:59:59");
                if (decimal.Parse(quote) == decimal.Parse("0"))
                {
                    Response.Redirect("Index.aspx", true);
                    return;
                }
                BrDaysFree daysFree = new BrDaysFree();

                bool success = daysFree.Qualify(arrayLogin[1], id);

                BrWallet brWallet = new BrWallet();

                var amountWallet = decimal.Parse(brWallet.GetAmount(User.Identity.Name.Split('¬')[1]));
                if (amountWallet <= 0)
                {
                    rbtWallet.Enabled = false;
                }

                Session["CurrencyCode"] = response[2];
                Session["tcCro"] = response[4];
                Session["IdImg"] = id.ToString();
                Session["StatusCalendar"] = id.ToString();
                lblPriceUnit.Text = quote + "" + response[2];


                lblSubTotal.Text = quote + " " + response[2];
                lblExchange.Text = typeChange;
                lblTot.Text = quote;
                ccc.Text = response[2];
                lblCostQuote.Text = quote;

                panel1.Visible = false;
                //lblDescription.Text = "KIT DE INICIO";
                //lblDescription.Visible = true;
                Session["dataQuote"] = id.ToString();
                Session["Amount"] = quote;
                Session["quotePay"] = quote;
                Session["numCuota"] = numCuota;


                if (payDate < DateTime.Now && success)
                {
                    // im nq
                    //TODO: comente para 
                    Response.Redirect("ChangingSchedule.aspx?im=" + id.ToString() + "&nq=1");
                    return;
                }

            }
        }

        protected void btnContinue_Click(object sender, EventArgs e)
        {
            if (rdrCulqi.Checked)
            {
                Session["formPay"] = "1";
                Response.Redirect("PayOnLineQuote.aspx");

            }
            else if (rdrTransfer.Checked)
            {
                Session["formPayd"] = "2";
                Response.Redirect("PayDepositoQuote.aspx");

            }
            else if (rdrTransfer2.Checked)
            {
                Session["formPayd"] = "3";
                Response.Redirect("PayDepositoQuote.aspx");

            }
            else if (rdrStor.Checked)
            {
                Session["formPayd"] = "4";
                Response.Redirect("PayDepositoQuote.aspx");

            }
            else if (rbtWallet.Checked)
            {
                Response.Redirect("PayWallet.aspx");
            }
        }
    }
}