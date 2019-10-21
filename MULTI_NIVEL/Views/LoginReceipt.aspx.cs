
namespace MULTI_NIVEL.Views
{
    using BussinesRules;
    using System;

    public partial class LoginReceipt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string document = "";

            document = Request["documentsoc"];

            BrPerson brPerson = new BrPerson();
            var _fullName = brPerson.GetFullName(document);
            Response.Write(_fullName);
        }
    }
}