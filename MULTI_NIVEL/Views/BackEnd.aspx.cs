

namespace MULTI_NIVEL.Views
{
    using BussinesRules.User;
    using System;
    public partial class BackEnd : System.Web.UI.Page
    {
        BrUser brUser;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            brUser = new BrUser();
            string data = txtUserBackend.Text + '|' + txtUserPassword.Text;
            string req = brUser.LoginUserBackend(data);
            if (req != "1")
            {
                Response.Redirect("BackEnd.aspx");
            }
            Session["backendLogin"] = "1";
            Session["userBack"] = txtUserBackend.Text.Trim(); ;
            Response.Redirect("MenuBackend.aspx");
        }
    }
}