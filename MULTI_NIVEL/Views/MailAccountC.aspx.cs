using BussinesRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MULTI_NIVEL.Views
{
    public partial class MailAccountC : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string answer = "";

            try
            {
                string action = Request["action"];

                BrPartner brPartner = new BrPartner();
                if (action == "list")
                {
                    answer = brPartner.GetNotEmailBussines(1);
                }

                if (action == "filter")
                {
                    string value = Request["value"];
                    answer = brPartner.Filter(value);
                }

            }
            catch (Exception)
            {
                answer = "";
            }

            Response.Write(answer);
        }
    }
}