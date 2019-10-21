using BussinesRules;
using Entities;
using System;

namespace MULTI_NIVEL.Views
{
    public partial class AddMembPagos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    decimal tipoCambio = 0, totalPagar = 0;
                    string descripcion = "";

                    string currencyCode = Session["TypeCurrency"].ToString();
                    string[] dataCarrito = Session["carrito"].ToString().Split('|');
                    totalPagar = decimal.Parse(dataCarrito[0]);
                    descripcion = "Membresia " + dataCarrito[1].ToUpper();
                    tipoCambio = decimal.Parse(dataCarrito[4]);

                    lblPrecio.Text = totalPagar.ToString("0.00");
                    lblSubTotal.Text = totalPagar.ToString("0.00");
                    lblTotal.Text = totalPagar.ToString("0.00");

                    lblDescripcion.Text = descripcion;
                    lblTipoCambio.Text = tipoCambio.ToString("0.00");

                    BrWallet brWallet = new BrWallet();
                    var amountWallet = decimal.Parse(brWallet.GetAmount(User.Identity.Name.Split('¬')[1]));
                    if (amountWallet == 0)
                    {
                        rbWallet.Enabled = false;
                    }

                    string showReport = Session["cronogramaYa"].ToString();
                    string[] macro = showReport.Split('^');
                    string[] micro2 = macro[1].Split('~');
                    string[] micro = micro2[0].Split('¬');

                    decimal quoteReference = 0;
                    for (int i = 0; i < micro.Length; i++)
                    {
                        string[] listRegisters = micro[i].Split('|');
                        //if (listRegisters[0] == "Inicial nro: 0")
                        //{
                        //    var quoteReferenced = decimal.Parse(listRegisters[5].Replace("S/. ", ""));
                        //    if (quoteReferenced > 0)
                        //    {
                        //        quoteReference = quoteReferenced.ToString();
                        //        break;
                        //    }
                        //}
                        
                        if (listRegisters[0] == "Inicial nro: 1")
                        {
                            quoteReference += decimal.Parse(listRegisters[5].Replace("S/. ", ""));
                            break;
                        }
                        if (listRegisters[0] == "Upgrade")
                        {
                            quoteReference += decimal.Parse(listRegisters[5].Replace("S/. ", ""));
                            //break;
                        }
                    }
                    CC.Text = currencyCode;
                    decimal amountTotal = quoteReference;
                    if (currencyCode == "USD")
                    {
                        amountTotal = amountTotal / tipoCambio;
                    }
                    lblTotalPagar.Text = Math.Floor(amountTotal).ToString("###,###,##0.00");

                }
            }
            catch (Exception ex)
            {
                MyConstants mc = new MyConstants();
                Email email = new Email();
                email.SendEmail(mc.ErrorEmail, "error-inresorts", ex.StackTrace + '¬' + DateTime.Now.ToLongDateString(), false);
            }
        }

        protected void btnProcesar_Click(object sender, EventArgs e)
        {
            string forma = "1";
            if (rbAgentes.Checked)
            {
                forma = "2";
            }

            if (rbBanca.Checked)
            {
                forma = "3";
            }
            if (rbOficina.Checked)
            {
                forma = "4";
            }
            if (rbWallet.Checked)
            {
                BrWallet brWallet = new BrWallet();
                var amountWallet = decimal.Parse(brWallet.GetAmount(User.Identity.Name.Split('¬')[1]));
                if (amountWallet == 0)
                {
                    return;
                }
                forma = "5";
            }

            Session["formPayd"] = forma;

            if (forma == "1")
            {
                Response.Redirect("AddMembCulqui.aspx");
            }
            if (forma == "5")
            {
                Response.Redirect("AddMembPayWallet.aspx");
            }
            Response.Redirect("AddMembPayDeposito.aspx");
        }
    }
}