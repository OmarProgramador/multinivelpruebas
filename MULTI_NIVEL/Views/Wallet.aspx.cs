using BussinesRules;
using Entities;
using System;
using System.IO;
using System.Web;
using System.Web.Security;

namespace MULTI_NIVEL.Views
{
    public partial class Wallet : System.Web.UI.Page
    {
        public bool Send { get; set; }
        string def = "profile.png";
        string extension = ".png";
        string name = "";
        string nombreu = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            var login = HttpContext.Current.User.Identity.Name.Split('¬'); ;

            if (!IsPostBack)
            {
                //Movimi.CssClass = "nav-link cabecera active show";
                //Transf.CssClass = "nav-link";

                var refer = login[login.Length - 1];
                if (refer == "referido")
                {
                    Response.Redirect("SignOutC.aspx");
                }

                this.lblUser.Text = "Hola " + login[0];
                this.lblUserName.Text = login[0];
                this.lblNumPartner.Text = "N° Asociado: " + login[4];

                this.imgProfile.ImageUrl = "~/Resources/Images/profile.png";
                this.imgProfileFl.ImageUrl = "~/Resources/Images/profile.png";


                //BrAccount brAccount = new BrAccount();

                //var status = int.Parse(brAccount.GetStatus(login[1]));

                //if (status == 1)
                //{
                //    bool refresh = brAccount.RefreshStatusBonusWallet(login[1]);
                //}
                //brAccount = null;

                // Imagen de PErfil
                var rutaImgP = HttpContext.Current.Server.MapPath("~/Resources/imguser");
                DirectoryInfo di1 = new DirectoryInfo(rutaImgP);
                nombreu = login[1];
                foreach (var fi2 in di1.GetFiles())
                {
                    var archivo = fi2.Name.Split('.');
                    name = archivo[archivo.Length - 2];
                    extension = archivo[archivo.Length - 1];
                    if (name == nombreu) { def = nombreu + "." + extension; }
                }
                imgProfile.ImageUrl = "~/Resources/imguser/" + def;
                imgProfile.Style.Add("width", "40px");
                imgProfile.Style.Add("height", "40px");
                imgProfile.Style.Add("margin", "0 auto");
                imgProfileFl.ImageUrl = "~/Resources/imguser/" + def;
                imgProfileFl.Style.Add("width", "80px");
                imgProfileFl.Style.Add("height", "80px");
                imgProfileFl.Style.Add("margin", "0 auto");

            }
            BrWallet brWallet = new BrWallet();

            var balance = brWallet.GetBalance(User.Identity.Name.Split('¬')[1]);

            var available = "00.00";
            var countable = "00.00";

            if (balance.Split('|').Length > 1)
            {
                available = balance.Split('|')[0];
                countable = balance.Split('|')[1];
            }
            Savailable.Text = available;
            Scontaible.Text = countable;
            brWallet = null;

        }
        protected void lblSalir_Click(object sender, EventArgs e)
        {
            Session.Contents.RemoveAll();
            FormsAuthentication.SignOut();
            HttpContext.Current.Response.Redirect("Index.aspx", true);
        }

        protected void SendDocument_Click(object sender, EventArgs e)
        {
            OpcionDisplay.Text = "2";

            var userKey = User.Identity.Name.Split('¬')[1];

            var arraynombreArchivo2 = "foto.png".Split('.');
            if (!Document.HasFile)
            {
                //no hay imagen en el control
                LblMessage.Text = "No hay documento seleccionado.";
                return;

                //si hay una archivo.          
                //
            }
            arraynombreArchivo2 = Document.FileName.Split('.');

            int indice = (arraynombreArchivo2.Length - 1);

            string extension = arraynombreArchivo2[indice];

            if (extension != "pdf")
            {
                LblMessage.Text = "No tiene el fomato correcto.";
                return;
            }

            Validation fv = new Validation();
            var amountTry = 0m;

            var isDecimal = decimal.TryParse(MontoSolitud.Text, out amountTry);

            if (!isDecimal)
            {
                LblMessage.Text = "El Monto a Solicitar No tiene el fomato correcto.";
                return;
            }


            //el monto debe estar en dolares
            var amount = decimal.Parse(MontoSolitud.Text);

            if (amount <= 0)
            {
                LblMessage.Text = "El Monto a Solicitar debe ser mayor a 0.";
                return;
            }

            BrWallet brWallet = new BrWallet();

            var amountWallet = decimal.Parse(brWallet.GetAmount(userKey));

            if (amount > amountWallet)
            {
                LblMessage.Text = "El Monto a Solicitar es mayor al monto de su Wallet.";
                return;
            }

            var llave = Guid.NewGuid().ToString();

            var nombreArchivo = $"{llave}{userKey}.{extension}";

            string ruta = "~/Resources/wallet/" + nombreArchivo;
            if (Document.HasFile)
            {
                Document.SaveAs(Server.MapPath(ruta));
            }

            var register = brWallet.PutDoc(userKey, nombreArchivo, amount);

            if (register)
            {
                LblMessage.Style.Add("color", "green");
                LblMessage.Text = "Su Solicitud se ha enviado con exito.";
            }

            MontoSolitud.Text = "";
            Response.Redirect("Wallet.aspx");
        }
    }
}