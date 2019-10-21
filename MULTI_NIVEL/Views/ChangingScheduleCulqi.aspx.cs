using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MULTI_NIVEL.Views
{
    public partial class ChangingScheduleCulqi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string redirect = string.Empty;
                if (Session["changingschedule"] == null)
                {
                    redirect = "Payments.aspx";
                }
                if (string.IsNullOrEmpty(redirect))
                {
                    var data = (Dictionary<string, object>)Session["changingschedule"];
                    var action = data["Action"];
                    var valueQuote = Convert.ToDecimal(data["ValueQuote"]);
                    var numQuote = Convert.ToDecimal(data["NumQuote"]);
                    var idMembership = Convert.ToInt32(data["IdMembership"]);
                    var valueTotal = valueQuote * numQuote;

                    numQuotes.Text = numQuote.ToString();
                    amountQuote.Text = valueQuote.ToString();
                    amountTotal.Text = valueTotal.ToString();

                    for (int i = 0; i < 10; i++)
                    {
                        ddlQuote.Items.Add(new ListItem
                        {
                            Value = (i + 1).ToString(),
                            Text = (i + 1).ToString(),
                        });
                    }
                }
                else
                {
                    Response.Redirect(redirect);
                }
            }
        }
    }
}