using BussinesRules;
using System;
using System.Collections.Generic;

namespace MULTI_NIVEL.Views
{
    public partial class ChangingSchedule : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                BrMembershipPayDetail brMemDetail = new BrMembershipPayDetail();
                string _idMembership = "0";
                string userName = "";
                decimal numQuote = 0, valueTotal = 0;
                int idMembership = 0;

                _idMembership = Request["im"] == null ? "0" : Request["im"];
                numQuote = Request["nq"] == null ? 0 : decimal.Parse(Request["nq"]);
                userName = User.Identity.Name.Split('¬')[1];
                idMembership = int.Parse(_idMembership);

                if (idMembership <= 0)
                {
                    Response.Redirect("Index.aspx");
                }

                BrDaysFree brDaysFree = new BrDaysFree();

                var isqualifi = brDaysFree.Qualify(userName, idMembership);

                if (!isqualifi)
                {
                    Response.Redirect("Payments.aspx");
                }

                var response = brMemDetail.GetValueQuoteMaxQuoteChangeSchedule(idMembership, userName).Split('|');

                decimal valueQuote = decimal.Parse(response[0]);
                int maxQuote = int.Parse(response[1]);

                if (valueQuote == 0 || maxQuote == 0 || numQuote > maxQuote || numQuote <= 0)
                {
                    Response.Redirect("Index.aspx");
                }

                DateTime payDate = DateTime.Parse(response[2]);
                //DateTime payDate = DateTime.Parse("2019-04-04 23:59:59");

                valueTotal = numQuote * valueQuote;
                lblValueTotal.Text = valueTotal.ToString();

                Dictionary<string, object> data = new Dictionary<string, object>
                {
                    { "Action","changeschedule" },
                    { "ValueQuote",valueQuote },
                    { "NumQuote",numQuote },
                    { "IdMembership", idMembership},
                    { "PayDate", payDate }
                };

                BrWallet brWallet = new BrWallet();

                var amountWallet = decimal.Parse(brWallet.GetAmount(User.Identity.Name.Split('¬')[1]));
                if (amountWallet <= 0)
                {
                    rbtWallet.Enabled = false;
                }

                Session["changingschedule"] = data;
            }
        }

        protected void btnContinue_Click(object sender, EventArgs e)
        {
            string redirect = "", fp = "";


            if (rdrCulqi.Checked)
            {
                redirect = "ChangingScheduleCulqi.aspx";
            }
            else if (rbtWallet.Checked)
            {
                redirect = "ChangingScheduleWallett.aspx";
            }
            else
            {
                redirect = "ChangingScheduleDeposito.aspx";
            }
            if (rdrTransfer.Checked)
            {
                fp = "?fp=2";
            }
            if (rdrTransfer2.Checked)
            {
                fp = "?fp=3";
            }
            if (rdrStor.Checked)
            {
                fp = "?fp=4";
            }
            if (!string.IsNullOrWhiteSpace(redirect))
            {
                Response.Redirect(redirect + fp);
            }
        }
    }
}