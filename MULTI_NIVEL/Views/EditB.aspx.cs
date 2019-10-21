using BussinesRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MULTI_NIVEL.Views
{
    public partial class EditB : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string action = "", name = "", doc = "", parent = "", messagge = "Ocurrio un error", userName = "",type="";
            bool answer = false;
            action = Request["action"];
            
            userName = User.Identity.Name.Split('¬')[1];

            BrBeneficiary brBeneficiary = new BrBeneficiary();
            if (action == "insert")
            {
                name = Request["name"];
                doc = Request["numdoc"];
                parent = Request["parent"];
                type = Request["type"];

                answer = brBeneficiary.Put(name,doc,parent,userName,type);
            }
            if (action == "get")
            {
                messagge = brBeneficiary.Get(userName);
            }
            if (answer)
            {
                messagge = "La operación se realizo con exito";
            }
            Response.Write(messagge);
        }
    }
}