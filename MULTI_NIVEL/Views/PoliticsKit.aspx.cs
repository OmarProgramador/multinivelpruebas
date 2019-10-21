using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MULTI_NIVEL.Views
{
    public partial class PoliticsKit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnPoliticsKit_Click(object sender, EventArgs e)
        {
            if (cbagree.Checked && cbagree2.Checked && cbagree3.Checked )
            {
                Session["terminos"] = "true";
                //Response.Redirect("PayOnLine.aspx");
                Session["JustKit"] = 1;
                if ((Int32.Parse(Session["StatusExonerar"].ToString())) == 1)
                {
                    Session["Amount"] = 0.00;
                }
                Response.Redirect("Pagos.aspx");
            }
            else
            {
                lblmarca.Style["Display"] = "block";

            }/*Quisiera ser como un backend*/
        }
    }
}