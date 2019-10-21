using BussinesRules.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace MULTI_NIVEL.Views
{
    public partial class RegisterData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string option = Request["option"];

            if (!string.IsNullOrEmpty(option))
            {
                if (option == "codSecreto")
                {
                    string valueCod = Request["valueCod"];
                    if (!string.IsNullOrEmpty(valueCod))
                    {

                        BrCode brCode = new BrCode();
                        string responseCode = brCode.GetCodeSecreto(valueCod);

                        if (string.Compare(valueCod, responseCode, false) == 0)
                        {
                            Response.Write("true");
                        }
                        else
                        {
                            Response.Write("false");
                        }
                    }
                    else
                    {
                        Response.Write("false");
                    }
                }
            }
        }
    }
}