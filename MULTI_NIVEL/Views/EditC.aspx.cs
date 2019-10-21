using BussinesRules.TypeMembership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MULTI_NIVEL.Views
{
    public partial class EditC : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string userName = User.Identity.Name.Split('¬')[1];
                     
            BrTypeMembership brTypeMembership = new BrTypeMembership();
            
            var codes = brTypeMembership.GetListCodeMemberships(userName);
            Response.Write(codes + "¬" + userName);
        }
    }
}