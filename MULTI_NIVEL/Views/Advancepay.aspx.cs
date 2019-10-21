using BussinesRules;
using System;
using System.Collections.Generic;

namespace MULTI_NIVEL.Views
{
    public partial class Advancepay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session.RemoveAll();
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

                var response = brMemDetail.GetValueQuoteMaxQuote(idMembership, userName).Split('|');

                decimal valueQuote = decimal.Parse(response[0]);
                int maxQuote = int.Parse(response[1]);
                var currencyCode = response[2];
                var typeChange = decimal.Parse(response[3]);

                if (valueQuote == 0 || maxQuote == 0 || numQuote > maxQuote || numQuote <= 0)
                {
                    Response.Redirect("Index.aspx");
                }

                if (currencyCode == "USD")
                {
                    valueQuote = valueQuote / typeChange;
                }

                valueTotal = numQuote * valueQuote;

                LblValueTotal.Text = valueTotal.ToString("0.00");
                CurrencyCode.Text = currencyCode;

                Dictionary<string, object> data = new Dictionary<string, object>
                {
                    { "Action", "advancequote" },
                    { "ValueQuote", valueQuote },
                    { "NumQuote", numQuote },
                    { "IdMembership", idMembership },
                    { "CurrencyCode", currencyCode },
                    { "TypeChangeCro", typeChange }
                };

                Session["advancePay"] = data;

                BrWallet brWallet = new BrWallet();
                var amountWallet = decimal.Parse(brWallet.GetAmount(userName));

                if (amountWallet <= 0)
                {
                    rbtWallet.Enabled = false;
                }
            }
        }

        protected void btnContinue_Click(object sender, EventArgs e)
        {
            string redirect = "";
            string fp = "";
            if (rdrCulqi.Checked)
            {
                redirect = "AdvancepayCulqi.aspx";
            }
            else if (rbtWallet.Checked)
            {
                redirect = "AdvancepayWallet.aspx";
            }
            else
            {
                redirect = "AdvancepayDeposito.aspx";
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
            if (!string.IsNullOrEmpty(redirect))
            {
                Response.Redirect(redirect + fp);
            }
        }
    }
}