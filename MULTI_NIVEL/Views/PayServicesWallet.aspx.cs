using BussinesRules;
using BussinesRules.User;
using Entities;
using System;
using System.IO;
using System.Web;

namespace MULTI_NIVEL.Views
{
    public partial class PayServicesWallet : System.Web.UI.Page
    {

        string def = "profile.png";
        string extension = ".png";
        string name = "";
        string nombreu = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var randow = new Random().Next(10000).ToString();
                var arrayLogin = User.Identity.Name.Split('¬');

                lblUser.Text = "Hola " + arrayLogin[0];
                lblUserName.Text = arrayLogin[0];
                lblNumPartner.Text = "N° Asociado: " + arrayLogin[4];
                // Imagen de PErfil
                var rutaImgP = HttpContext.Current.Server.MapPath("~/Resources/imguser");
                DirectoryInfo di1 = new DirectoryInfo(rutaImgP);
                foreach (var fi2 in di1.GetFiles())
                {
                    var archivo = fi2.Name.Split('.');
                    name = archivo[archivo.Length - 2];
                    extension = "jpg";
                    if (name == nombreu) { def = nombreu + "." + extension; }
                }

                if (def != "")
                {
                    imgProfile.ImageUrl = "~/Resources/imguser/" + def + "?id=" + randow;
                    imgProfile.Style.Add("width", "40px");
                    imgProfile.Style.Add("height", "40px");
                    imgProfile.Style.Add("margin", "0 auto");
                    imgProfileFl.ImageUrl = "~/Resources/imguser/" + def + "?id=" + randow;
                    imgProfileFl.Style.Add("width", "80px");
                    imgProfileFl.Style.Add("height", "80px");
                    imgProfileFl.Style.Add("margin", "0 auto");
                }


                BrWallet brWallet = new BrWallet();
                var amountWallet = decimal.Parse(brWallet.GetAmount(arrayLogin[1]));

                Wallet.Text = $"Wallet : {amountWallet.ToString("0.00")}";

                var objServices = Session["servicio"];
                var objPrice = Session["precio"];

                string[] service;
                string description = string.Empty;
                decimal price = 0;


                if (objServices != null || objPrice != null)
                {
                    service = objServices.ToString().Split('|');
                    description = service[5];
                    price = decimal.Parse(objPrice.ToString());
                }

                MyFunctions mf = new MyFunctions();

                Description.Text = mf.ToCapitalize(description);
                AmountTotal.Text = price.ToString("0.00") + " PEN";

            }

        }

        protected void PayByWallet_Click(object sender, EventArgs e)
        {
            var arrayLogin = User.Identity.Name.Split('¬');
            BrWallet brWallet = new BrWallet();
            BrUser brUser = new BrUser();
            BrTypeChange brTypeChange = new BrTypeChange();
            var arrayTypes = brTypeChange.GetTypesChange().Split('|');
            var tcCompra = decimal.Parse(arrayTypes[1]);

            var amountWallet = decimal.Parse(brWallet.GetAmount(arrayLogin[1]));
            var objServices = Session["servicio"];
            var objPrice = Session["precio"];

            var amountWalletSoles = amountWallet * tcCompra;

            string[] service;
            string description = string.Empty;
            decimal price = 0;

            if (amountWallet == 0)
            {
                MessageError.Text = "Wallet insuficiente";
                return;
            }

            if (objServices != null || objPrice != null)
            {
                service = objServices.ToString().Split('|');
                description = service[5];
                price = decimal.Parse(objPrice.ToString());

                if (price == 0)
                {
                    MessageError.Text = "ocurrio un error";
                    return;
                }

                if (amountWalletSoles < price)
                {
                    MessageError.Text = "Wallet insuficiente";
                    return;
                }

                var referenceData = "Compra de Paquete : " + service[5];

                var data = $"{price}|{tcCompra}|{arrayLogin[4]}|{referenceData}";
                var answer = brWallet.PutPayService(data, arrayLogin[1]);

                if (answer)
                {
                    //Samir Pazo|18/01/2020|4|22/07/2019|6|Full Day Todo Incluido|35|25
                    var reg = service[0] + "|" + service[1] + "|" + "" + "|" + service[2] + "|" + service[3] + "|" + service[4] + "|" + arrayLogin[1] + "|" + "2" + "|" + "" + "|" + price;
                    var response = brUser.RegisterService(reg);
                }

                Response.Redirect("EndPaymentServices.aspx", true);
            }

        }
    }
}