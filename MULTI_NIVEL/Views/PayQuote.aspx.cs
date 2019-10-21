using System;

namespace MULTI_NIVEL.Views
{
    public partial class PayQuote : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request["varible1"]))
                {
                    string data = Request["varible1"].ToString();
                    Session["dataQuote"] = data;
                    var listData = data.Split('|');

                    lblSubTotal.Text = "S/" + listData[1];
                    lblTot.Text = listData[1];
                    lblCostQuote.Text = listData[1];
                    Session["Amount"] = listData[1];
                }
                else
                {
                    var objAmortiz = Session["dataAmort"];
                    if (objAmortiz != null)
                    {
                        var amotizaData = objAmortiz.ToString().Split('|');

                        lblSubTotal.Text = $"{amotizaData[2]} {amotizaData[5]}";  /*TRY MERGE*/
                        lblTot.Text = $"{amotizaData[2]}";
                        lblCostQuote.Text = $"{amotizaData[2]} {amotizaData[5]}";
                    }
                }
            }
        }

        protected void btnProcessPay_Click(object sender, EventArgs e)
        {
            if (rdrCulqi.Checked)
            {
                Session["formPay"] = "1";
                Response.Redirect("PayOnLine.aspx");

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
                Session["formPayd"] = "4";
                Response.Redirect("WalletAmortization.aspx");
            }

        }
    }
}