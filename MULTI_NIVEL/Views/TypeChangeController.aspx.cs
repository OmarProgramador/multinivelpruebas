using BussinesRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MULTI_NIVEL.Views
{
    public partial class TypeChangeController : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            decimal venta = 0;
            decimal compra = 0;
            bool anwser = false;

            venta = decimal.Parse(Request["value"].ToString());
            compra = decimal.Parse(Request["compra"]);

            if (venta < 2 || compra < 2)
            {
                Response.Write("Se Produjo un Error");
                return;
            }

            venta = venta + 0.044m;
            compra = compra - 0.022m;

            BrTypeChange oTypeChange = new BrTypeChange();
            anwser = oTypeChange.PutTypeChange(venta,compra);

            if (!anwser)
            {
                Response.Write("Se Produjo un Error");
                return;
            }

            if (string.IsNullOrEmpty((string)Session["auxRef"])){
                Response.Write("false¬no esta la variballe aux");
                return;
            }
            Response.Write("true¬si esta la variballe aux");
            Response.Write("Se Inserto Con Exito");
            return;
        }
    }
}