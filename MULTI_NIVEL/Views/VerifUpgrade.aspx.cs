using BussinesRules.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MULTI_NIVEL.Views
{
    public partial class VerifUpgrade : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            double amountUpgrate = 100;
            BrUser brUser = new BrUser();
            string userName = User.Identity.Name.Split('¬')[1];
            int id = int.Parse(Request["id"]);
            string dateUpgrade = brUser.GetDateUpgrade(id);
            if (!string.IsNullOrEmpty(dateUpgrade))
            {
                int year = int.Parse(dateUpgrade.Split('-')[0]);
                int month = int.Parse(dateUpgrade.Split('-')[1]);
                int day = int.Parse(dateUpgrade.Split('-')[2]);
                DateTime ddateUpgrade = new DateTime(year, month, day);
                DateTime ddateCurrent = DateTime.Now;
                if (ddateUpgrade > ddateCurrent)
                {
                    amountUpgrate = 0;
                }               
            }
            Response.Write(amountUpgrate.ToString());
        }
    }
}