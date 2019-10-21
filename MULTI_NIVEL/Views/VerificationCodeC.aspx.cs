
namespace MULTI_NIVEL.Views
{
    using System;    
    using BussinesRules.Code;

    public partial class VerificationCodeC : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BrCode bcode = new BrCode();

            string code = Request["code"].ToString().Trim();
            if (string.IsNullOrEmpty(code))
            {
                Response.Write("false¬false");
                return;
            }
            string anwser = bcode.GetCodeExist(code);

            if (anwser == "error")
            {
                Response.Write("false¬false");
                return;
            }
            Session["codeDiscount"] = anwser;

          
            Response.Write("true¬" + anwser);
            return;
        }
    }
}