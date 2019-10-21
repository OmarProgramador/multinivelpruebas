using BussinesRules.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MULTI_NIVEL.Views
{
    public partial class NewsC : System.Web.UI.Page
    {
        string role = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            int action = 0;
            action = int.Parse(Request["action"]);

            if (action == 1)
            {
                //string[] arraylogin = HttpContext.Current.User.Identity.Name.Split('¬');
                //string userName = arraylogin[1];
                var obj = HttpContext.Current.User.Identity.Name.Split('¬');

                if (Session["backendLogin"] == null)
                {
                    role = "0";
                }
                else
                {
                    role = Session["backendLogin"].ToString();
                }
                BrUser brUser = new BrUser();

                Response.Write(role + "$" + brUser.GetNews());
            }

            //metodo de eliminar
            if (action ==2)
            {
                int id = 0;
                id = int.Parse(Request["id"]);
                BrUser brUser = new BrUser();
                
                

                brUser.DeleteNews(id.ToString());
                Response.Write("true");
                return;
            }
        }
    }
}