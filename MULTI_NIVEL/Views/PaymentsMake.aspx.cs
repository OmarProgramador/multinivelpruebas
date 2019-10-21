using BussinesRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MULTI_NIVEL.Views
{
    public partial class PaymentsMake : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SendVoucher_Click(object sender, EventArgs e)
        {
            //DepositId.Text = "2";
            var id = int.Parse(DepositId.Text.Trim());
            var obs = DepositObs.Text.Trim();
           

            if (!DepositVoucher.HasFile)
            {

                return;
            }

            var voucher = DepositVoucher.FileName;
            var llave = DateTime.Now.ToString("yyyy;MM;dd;hh;mm;ss;fff");

            BrWallet brWallet = new BrWallet();

            voucher = llave + voucher;

            string ruta = "~/Resources/Make/" + voucher;
              
            DepositVoucher.SaveAs(Server.MapPath(ruta));

            var data = brWallet.PutVoucher(id, obs, voucher);

            Response.Redirect("PaymentsMake.aspx");

        }
    }
}