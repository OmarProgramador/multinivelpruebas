using BussinesRules.Code;
using BussinesRules.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MULTI_NIVEL.Views
{
    public partial class Code : System.Web.UI.Page
    {
        BrCode brCode;
        BrPayments brPayment;
        BrUser brUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string[] array = {
                "10%",
                "20%",
                "30%",
                "40%",
                "50%",
                "60%",
                "70%",
                "80%",
                 "90%",
                "100%"};
                ddlDiscount.DataSource = array;
                ddlDiscount.DataBind();

                string[] arrayPromotion = {
                "Kit",
                "Total"};
                ddlPromotion.DataSource = arrayPromotion;
                ddlPromotion.DataBind();

                //var listParameters = data.Split('|');
                //lblName.Text = listParameters[0] + ' ' + listParameters[1];
                //lblU.Text = dataUserFather;
                brUser = new BrUser();
                string respData = brUser.getSons(Session["userBack"].ToString());
                var listParametersData = respData.Split('¬');
                //string[] socios = { "pc.png", "mic.png", "ipod.png" };
                var listParametersDataBehind = listParametersData;

                for (int i = 0; i <= listParametersDataBehind.Length - 1; i++)
                {
                    var _array = listParametersDataBehind[i].Split('|');
                    _array[0] = "";
                    //ddlSons.DataSource= listParametersDataBehind[i];
                    //ddlSons.Va
                    // ddlSons.Items.Add(new ListItem(listParametersDataBehind[i], i.ToString())); 
                    ddlPersons.Items.Add(new ListItem(" " + _array[1] + " " + _array[2] + " / " + _array[3], i.ToString()));
                    // ddlSons.Items.Add(item);
                }

                ddlPersons.DataBind();
            }
        }

        protected void lblSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuBackend.aspx");
            FormsAuthentication.SignOut();
        }

        protected void CodeGenerator_Click(object sender, EventArgs e)
        {
            // Response.Redirect("MenuBackend.aspx");
            brCode = new BrCode();
            string code = brCode.sha256_hash(txtDni.Text + DateTime.Now.ToString("h:mm:ss tt"));
            txtCodeView.Text = code;

        }

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            // Response.Redirect("MenuBackend.aspx");
            string data = txtCodeView.Text + '|' + ddlPersons.SelectedItem.ToString() + '|' + ddlDiscount.SelectedValue + '|' + txtUsability.Text+'|'+ddlPromotion.SelectedValue;
            brCode = new BrCode();
            string req = brCode.RegisterCode(data);
            if (!string.IsNullOrEmpty(req))
            {
                SmtpClient server = new SmtpClient("cieneguillariberadelrio.com", 587);
                // Crea el mensaje estableciendo quién lo manda y quién lo recibe
                //Envía el mensaje.
                server.Credentials = new System.Net.NetworkCredential("knava@cieneguillariberadelrio.com", "Sistemas1");
                server.EnableSsl = true;
                //Añade credenciales si el servidor lo requiere.
                MailMessage mnsj = new MailMessage();
                mnsj.Subject = "[InResorts_CODE]";
                mnsj.IsBodyHtml = true;
                mnsj.To.Add(new MailAddress(txtCorreo.Text));
                mnsj.From = new MailAddress("knava@cieneguillariberadelrio.com", "Kevin Nava");
                /* Si deseamos Adjuntar algún archivo*/
                mnsj.Body = "Tu Codigo es:" + txtCodeView.Text;
                server.Send(mnsj);
                txtCodeView.Text = "";
                txtCorreo.Text = "";
                txtDni.Text = "";
                txtUsability.Text = "";
            }
            else
            {
               //alert negativo
            }

            


        }
    }
}
