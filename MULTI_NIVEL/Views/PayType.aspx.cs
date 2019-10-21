using BussinesRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MULTI_NIVEL.Views
{
    using BussinesRules;
    using BussinesRules.User;

    public partial class PayType : System.Web.UI.Page
    {
        BrUser brUser;
        string newUserName = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            btnProcess.Style["Visibility"] = "visible";
            //btnContinue.Style["Visibility"] = "hidden";
            //btnProcessPay.Style["Visibility"] = "hidden";
            //Button1.Style["Visibility"] = "hidden";

            if (!IsPostBack)
            {
                BrMembershipPayDetail brMembership = new BrMembershipPayDetail();
                string[] listParameters;
                listParameters = new string[300];
                string req = "";
                double tipocambio = 0.00;
                double subtotalkit = 0.00;
                string quote = "";
                req = (string)Session["servicio"];

                if (!string.IsNullOrEmpty(req))
                {
                   
                    //if ((Double)Session["Discount"] <= 1)
                    //{
                    //    lblDiscount.Text = (((Double)Session["Discount"]).ToString());
                    //}

                    req = Session["servicio"].ToString();
                    listParameters = req.Split('|');
                    //tipocambio = double.Parse(Session["carrito"].ToString().Split('|')[4]);
                    //subtotalkit = double.Parse(listParameters[3]) * tipocambio;

                    lblPriceUnit.Text = "S/." + "" + Session["precio"].ToString();
                    lblSubTotal.Text = subtotalkit.ToString();
                    double total = 0.00;

                    //total = Session["precio"].ToString();


                    lblSubTotal.Text = "S/" + Session["precio"].ToString();
                    lblExchange.Text = tipocambio.ToString();
                    //tipocambio = Double.Parse(Session["precio"].ToString());
                    lblCostQuote.Text = Session["precio"].ToString();

                    lblTot.Text = Session["precio"].ToString();
                    //lblCostQuote.Text = lblTot.Text;
                    //Session["Amount"] = lblCostQuote.Text;
                    lblDescription.Text = listParameters[5];
                    lblDescription.Visible = true;
                   
                }
               
                if (lblSubTotal.Text == "S/0")
                {
                    btnProcess.Style["Visibility"] = "hidden";
                    //btnContinue.Style["Visibility"] = "visible";
                    //btnProcessPay.Style["Visibility"] = "hidden";

                    Response.Redirect("PayRegisterExoneration.aspx");
                    return;
                }
                else
                {
                    //btnProcessPay.Style["Visibility"] = "visible";
                    //btnContinue.Style["Visibility"] = "hidden";
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
                    Response.Redirect("PayServices.aspx");

                }
                else if (rdrTransfer.Checked)
                {
                    Session["formPayd"] = "2";
                    Response.Redirect("PayServices2.aspx");

                }
                else if (rdrTransfer2.Checked)
                {
                    Session["formPayd"] = "3";
                    Response.Redirect("PayServices2.aspx");

                }
                else if (rdrStor.Checked)
                {
                    Session["formPayd"] = "4";
                    Response.Redirect("PayServices2.aspx");

                }
                else if (rbtWallet.Checked)
                {
                    Session["formPayd"] = "5";
                    Response.Redirect("PayServicesWallet.aspx");
                }
 
            }
        }

    }
}