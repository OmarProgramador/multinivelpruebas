using BussinesRules.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MULTI_NIVEL.Views
{
    public partial class Referred : System.Web.UI.Page
    {
        string userName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                string returnUrl = Request["ReturnUrl"];
                if (!string.IsNullOrEmpty(returnUrl))
                {
                    if (returnUrl == "/Views/Referred.aspx")
                    {
                        FormsAuthentication.RedirectFromLoginPage("", false);
                        Response.Redirect("Referred.aspx");
                    }
                }


                Session.Contents.RemoveAll();
                FormsAuthentication.SignOut();
                Session.Clear();
                Session["StatusExonerar"] = 0;
                Session["link"] = "";
                string afiliate = Request["afiliate"];
                string upliner = Request["upliner"];
                if (!string.IsNullOrEmpty(afiliate) && !string.IsNullOrEmpty(upliner))
                {
                    string data = afiliate + "|" + upliner;
                    BrUser brUser = new BrUser();
                    int idUpliner = brUser.ExistAccountLink(data);
                    if (idUpliner > 0)
                    {
                        Session["Referido"] = afiliate;
                        Session["auxRef"] = "1";
                        Session["link"] = data + "|" + idUpliner;
                        FormsAuthentication.RedirectFromLoginPage(afiliate, chkPersistCookie.Checked);
                        Response.Redirect("Register.aspx");
                    }
                }


            }
        }


        private bool ValidateUser2(string userName)
        {
            string[] lookUser = null;
            try
            {
                BrUser brUser = new BrUser();

                lookUser = brUser.getName(userName).Split('¬');

                // Si no se encuentra la contraseña, devuelve false.
                if (null == lookUser)
                {
                    // Para más seguridad, puede escribir aquí los intentos de inicio de sesión con error para el registro de eventos.
                    return false;
                }

                // Comparar lookupPassword e introduzca passWord, usando una comparación que distinga mayúsculas y minúsculas.
                return (0 == string.Compare(lookUser[1], userName, false));
            }
            catch (Exception ex)
            {
                // Agregar aquí un control de errores para la depuración.
                // Este mensaje de error no debería reenviarse al que realiza la llamada.
                System.Diagnostics.Trace.WriteLine("[ValidateUser] Exception " + ex.Message);
                return false;
            }
        }
        protected void btnReferido_Click(object sender, EventArgs e)
        {
            bool respuesta2 = false;

            respuesta2 = this.ValidateUser2(txtReferido.Text.Trim());

            if (respuesta2)
            {
                BrUser obrUser = new BrUser();
                if (txtReferido.Text != "")
                {
                    Session["Referido"] = txtReferido.Text;
                    Session["auxRef"] = "1";
                }
                FormsAuthentication.RedirectFromLoginPage(txtReferido.Text.Trim(), chkPersistCookie.Checked);

            }
            else
            {
                Response.Redirect("Index.aspx?Key=" + userName, true);
            }
        }
    }
}