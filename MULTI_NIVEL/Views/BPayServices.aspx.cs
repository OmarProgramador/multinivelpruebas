using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MULTI_NIVEL.Views
{
    public partial class BPayServices : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["backendLogin"] == null)
                {
                    Response.Redirect("Backend.aspx", true);
                }

                if (Session["backendLogin"].ToString() != "1")
                {
                    Response.Redirect("Backend.aspx", true);
                }
            }
        }
    }
}