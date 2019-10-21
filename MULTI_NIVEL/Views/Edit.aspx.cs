using BussinesRules;
using BussinesRules.User;
using Entities;
using System;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace MULTI_NIVEL.Views
{
    public partial class Edit : System.Web.UI.Page
    {
        string def = "profile.png";
        string extension = ".png";
        string name = "";
        string nombreu = "";


        protected void Page_Load(object sender, EventArgs e)
        {
            var randow = new Random().Next(1000).ToString();
            this.imgProfile.ImageUrl = "~/Resources/imguser/" + def + "?id=" + randow;
            this.imgProfileFl.ImageUrl = "~/Resources/imguser/" + def + "?id=" + randow;
            var obj = HttpContext.Current.User.Identity.Name.Split('¬');
            //link1.NavigateUrl = "~/Resources/PoliticsPdf/cer"+ obj[1] +".pdf";
            //link2.NavigateUrl = "~/Resources/PoliticsPdf/cro" + obj[1] + ".pdf";
            //link3.NavigateUrl = "~/Resources/PoliticsPdf/pag" + obj[1] + ".pdf";
            //link4.NavigateUrl = "~/Resources/PoliticsPdf/con" + obj[1] + ".pdf";

            try
            {

                this.lblUser.Text = "Hola " + obj[0];
                this.lblUserName.Text = obj[0];
                this.lblNumPartner.Text = "N° Asociado: " + obj[4];
                nombreu = obj[1];
                //datos 
                //'10|NUevo|Jedi|19-09-1995|M|hombrehealth@hotmail.com|phone1|phone2|country|state|city|addres|DNI|234234'

                if (!IsPostBack)
                {
                    BrUser brUser = new BrUser();
                    string[] dataPerson = brUser.GetPersonalInformation(obj[1]).Split('|');
                    string[] dataAditional = brUser.GetAditionalInformation(obj[1]).Split('|');
                    string[] dataBank = brUser.GetBankInformation(obj[1]).Split('|');
                    string[] dataCoAf = brUser.GetCoAfiliateInformation(obj[1]).Split('|');

                    txtNameCoAfi.Text = dataCoAf[0];
                    txtLastNameCoAfi.Text = dataCoAf[1];
                    txtBirthDayCoAfi.Text = dataCoAf[2];
                    txtNumberDocCoAfi.Text = dataCoAf[3];
                    ddlTypeDocCoAfi.SelectedValue = dataCoAf[4];

                    txtUserName.Text = obj[1];
                    ////7 8
                    if (dataAditional.Length > 1)
                    {
                        txtSponsor.Text = dataAditional[0];
                        txtUpline.Text = dataAditional[1];
                    }
                    //12 13
                    txtTipoDoc.Text = dataPerson[12];
                    txtNumDoc.Text = dataPerson[13];

                    //1 2 
                    txtName.Text = dataPerson[1];
                    txtLastName.Text = dataPerson[2];
                    txtBirthday.Text = dataPerson[3];
                    rbMen.Checked = true;
                    if (dataPerson[4] == "F")
                    {
                        rbWoman.Checked = true;
                    }
                    txtEmail.Text = dataPerson[5];
                    txtPhone.Text = dataPerson[6];
                    txtPhone2.Text = dataPerson[7];
                    txtCountry.Text = dataPerson[8];
                    Estadop.Text = dataPerson[9].ToString().Trim();
                    txtCiudad.Text = dataPerson[10];
                    txtAddress.Text = dataPerson[11];

                    BrBank brBank = new BrBank();
                    string[] arrayBank = brBank.GetData().Split('¬');
                    for (int i = 0; i < arrayBank.Length; i++)
                    {
                        string[] row = arrayBank[i].Split('|');
                        ListItem item = new ListItem();
                        item.Value = row[0];
                        item.Text = row[1];
                        ddlBanck.Items.Add(item);
                        item = null;
                        row = null;
                    }
                    if (dataBank.Length > 1)
                    {
                        ddlBanck.SelectedValue = dataBank[0];
                        txtNameTitularCuentaBan.Text = dataBank[1];
                        rbCuentaCo.Checked = true;
                        if (dataBank[2] == "A")
                        {
                            rbCuentaAH.Checked = true;
                        }
                        txtNumCuenta.Text = dataBank[3];
                        txtNumContr.Text = dataBank[4];
                        txtBusinessName.Text = dataBank[5];
                        txtFiscalAddress.Text = dataBank[6];
                    }
                }

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

                HyperLink itemhl = new HyperLink();
                itemhl.NavigateUrl = "../Resources/imguser/" + def + "?id=" + randow;
                itemhl.Style.Add("display", "inline-block");
                itemhl.Style.Add("margin", "0 auto");
                itemhl.Target = "_blank";

                Image img = new Image();
                img.ImageUrl = "../Resources/imguser/" + def + "?id=" + randow;
                img.Style.Add("width", "150px");
                img.Style.Add("display", "block");
                img.Style.Add("margin", "14px auto");

                Panel div = new Panel();
                div.Style.Add("display", "flex");
                itemhl.Controls.Add(img);
                div.Controls.Add(itemhl);
                panel.Controls.Add(div);


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

            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }

            Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
            Response.Cache.SetAllowResponseInBrowserHistory(false);
            Response.Cache.SetNoStore();
        }


        //IMAGENES
        //protected void Btn_imagprofile(object sender, EventArgs e)
        //{

        //    try
        //    {
        //        var obj = HttpContext.Current.User.Identity.Name.Split('¬');
        //        var archivo = upload_image.FileName.Split('.');
        //        var name = archivo[archivo.Length - 2];
        //        var ext = "jpg";
        //        var dt = DateTime.Now.ToString("yyyyMMddHHmmss");

        //        if (ext != "img" && ext != "png" && ext != "jpg")

        //        {
        //            lblinformacion.Text = "Ha ocurrido un error al intentar subir el archivo al servidor";
        //            lblinformacion.Style.Add("color", "red");
        //            //Response.Redirect("UploadTools.aspx");
        //            return;
        //        }
        //        //var nameF = dt + FlpArchivo1.FileName;
        //        upload_image.SaveAs(Server.MapPath("~/Resources/imguser/") + obj[1] + "." + ext);
        //        lblinformacion.Text = "El archivo " + Fluplo.FileName + "se ha guardado correctamente";
        //        lblinformacion.Style.Add("color", "#6be22e");


        //    }
        //    catch (Exception ex)
        //    {
        //        var qwe = ex.Message;
        //        lblinformacion.Text = "Ha ocurrido un error al intentar subir la imagen al servidor";
        //        lblinformacion.Style.Add("color", "red");

        //    }
        //    Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
        //    Response.Cache.SetAllowResponseInBrowserHistory(false);
        //    Response.Cache.SetNoStore();
        //    Response.Redirect("Edit.aspx");
        //}


        protected void lblSalir_Click(object sender, EventArgs e)
        {
            Session.Contents.RemoveAll();
            FormsAuthentication.SignOut();
            HttpContext.Current.Response.Redirect("Index.aspx", true);
        }

        protected void btnSaveDataAccount_Click(object sender, EventArgs e)
        {
            string pass = txtPass.Text.Trim();
            string pass2 = txtPass2.Text.Trim();


            if (string.IsNullOrEmpty(pass))
            {
                lblMensaje.Text = "La Contraseña No debe estar Vacia";
                return;
            }
            if (pass.Length < 6)
            {
                lblMensaje.Text = "El Minimo de Caracteres de la Contraseña es 6";
                return;
            }
            if (pass.Length > 15)
            {
                lblMensaje.Text = "El Maximo de Caracteres de la Contraseña es 15";
                return;
            }

            if (pass != pass2)
            {
                lblMensaje.Text = "Las Contraseñas no Coinciden";
                return;
            }
            var arrayLogin = HttpContext.Current.User.Identity.Name.Split('¬');
            BrUser brUser = new BrUser();
            bool anwser = brUser.UpdateUserDataAccount(pass + "¬" + arrayLogin[1]);

            if (anwser)
            {
                lblMensaje.Text = "Su Contraseña a Sido Modificada.Ingrese con su nueva Contraseña";
                FormsAuthentication.SignOut();
            }

        }

        protected void btnSaveDataPerson_Click(object sender, EventArgs e)
        {
            string userName = "", name = "", lastName = "", birthday = "", email = "", phone1 = "", phone2 = "", country = "", estado = "", city = "", adress = "";
            string[] arrayLogin = HttpContext.Current.User.Identity.Name.Split('¬');
            string data = "", sexo = "M";
            if (rbWoman.Checked)
            {
                sexo = "F";
            }

            userName = arrayLogin[1];
            name = txtName.Text.Trim();
            lastName = txtLastName.Text.Trim();
            birthday = txtBirthday.Text.Trim().Replace('/', '-');
            email = txtEmail.Text.Trim();
            phone1 = txtPhone.Text.Trim();
            phone2 = txtPhone2.Text.Trim();
            country = txtCountry.Text.Trim();

            city = txtCiudad.Text.Trim();
            adress = txtAddress.Text.Trim();
            estado = Estadop.Text.Trim();

            Validation vali = new Validation();
            if (!vali.IsString(name))
            {
                txtName.Focus();
                lblMesaggePer.Text = "El Nombre no es Valido";
                return;
            }
            if (!vali.IsString(lastName))
            {
                txtLastName.Focus();
                lblMesaggePer.Text = "El Apellido no es valido";
                return;
            }
            string[] arrayBirthDay = birthday.Split('-');
            if (arrayBirthDay.Length < 3)
            {
                txtBirthday.Focus();
                lblMesaggePer.Text = "La Fecha No tiene Formato Completo";

                return;
            }
            if (arrayBirthDay[0].Length != 2 || arrayBirthDay[1].Length != 2 || arrayBirthDay[2].Length != 4)
            {
                txtBirthday.Focus();
                lblMesaggePer.Text = "La Fecha No tiene Formato Completo";
                return;
            }
            if (!vali.IsEmail(email))
            {
                txtEmail.Focus();
                lblMesaggePer.Text = "No es una Email Valido";
                return;
            }
            //if (!vali.IsPhone(phone1))
            //{
            //    txtPhone.Focus();
            //    lblMesaggePer.Text = "Telefono 1 No es Valido";
            //    return;
            //}
            //if (!string.IsNullOrEmpty(phone2))
            //{
            //    if (!vali.IsPhone(phone2))
            //    {
            //        txtPhone2.Focus();
            //        lblMesaggePer.Text = "Telefono 2 No es Valido";
            //        return;
            //    }
            //}
            if (!vali.IsString(country))
            {
                txtCountry.Focus();
                lblMesaggePer.Text = "No es Una Pais Valido";
                return;
            }
            if (!vali.IsString(estado))
            {
                Estadop.Focus();
                lblMesaggePer.Text = "No es Una Estado Valido";
                return;
            }
            if (!vali.IsString(city))
            {
                txtCiudad.Focus();
                lblMesaggePer.Text = "No es Una Ciudad Valida";
                return;
            }
            data = userName + "|" +
            name + "|" +
            lastName + "|" +
            birthday + "|" +
            sexo + "|" +
            email + "|" +
            phone1 + "|" +
            phone2 + "|" +
            country + "|" +
            estado + "|" +
            city + "|" +
            adress;
            BrUser brUser = new BrUser();
            bool anwser = brUser.PutPersonalInformation(data);
            if (anwser)
            {
                string nameLogin = brUser.getName(arrayLogin[1]);
                FormsAuthentication.RedirectFromLoginPage(nameLogin, true);
                Response.Redirect("Edit.aspx", true);
            }
            lblMesaggePer.Text = "Ha Ocurrido un Error";
        }

        protected void btnSaveDataBank_Click(object sender, EventArgs e)
        {
            int bank = 0;
            string nameTc = "", typeAcc = "C", numberAcc = "", numberCon = "", razonSocial = "", direccFisc = "", data = "", userName = "";
            string[] arrayLogin = HttpContext.Current.User.Identity.Name.Split('¬');

            userName = arrayLogin[1];

            if (string.IsNullOrEmpty(ddlBanck.SelectedValue))
            {
                lblMessaggeBank.Text = "Campo nombre del banco es obligatorio.";
                return;
            }
            bank = int.Parse(ddlBanck.SelectedValue);
            nameTc = txtNameTitularCuentaBan.Text.Trim();
            if (rbCuentaAH.Checked)
            {
                typeAcc = "A";
            }
            numberAcc = txtNumCuenta.Text.Trim();
            numberCon = txtNumContr.Text.Trim();
            razonSocial = txtBusinessName.Text.Trim();
            direccFisc = txtFiscalAddress.Text.Trim();

            if (string.IsNullOrEmpty(nameTc))
            {
                lblMessaggeBank.Text = "Campo nombre del titular de cuenta bancaria es obligatorio.";
                return;
            }
            if (string.IsNullOrEmpty(numberAcc))
            {
                lblMessaggeBank.Text = "Campo numero de cuenta es obligatorio.";
                return;
            }
            if (string.IsNullOrEmpty(numberCon))
            {
                lblMessaggeBank.Text = "Campo numero del contribuyente es obligatorio.";
                return;
            }
            if (string.IsNullOrEmpty(razonSocial))
            {
                lblMessaggeBank.Text = "Campo razon social es obligatorio.";
                return;
            }
            if (string.IsNullOrEmpty(direccFisc))
            {
                lblMessaggeBank.Text = "Campo direccion fiscal es obligatorio.";
                return;
            }

            data = userName + "|" +
                nameTc + "|" +
                typeAcc + "|" +
                numberCon + "|" +
                numberAcc + "|" +
                razonSocial + "|" +
                direccFisc + "|" +
                bank;

            BrUser brUser = new BrUser();
            bool answer = brUser.PutBankInformation(data);

            if (answer)
            {
                Response.Redirect("Edit.aspx", true);
            }
            lblMessaggeBank.Text = "Ha Ocurrido Un Error";
        }

        protected void btnSaveChangesCoAfi_Click(object sender, EventArgs e)
        {
            string lastNameCa = "", nameCo, birthDayCo = "", numberDocCo = "", userName = "";
            int typeDoc = 0;

            userName = User.Identity.Name.Split('¬')[1];
            if (string.IsNullOrEmpty(userName))
            {
                return;
            }
            if (string.IsNullOrEmpty(ddlTypeDocCoAfi.SelectedValue.ToString()))
            {
                return;
            }
            typeDoc = int.Parse(ddlTypeDocCoAfi.SelectedValue.ToString());
            if (typeDoc == 0)
            {
                return;
            }
            if (IsEmpty(txtLastNameCoAfi)) return;
            if (IsEmpty(txtNameCoAfi)) return;
            if (IsEmpty(txtBirthDayCoAfi)) return;
            if (IsEmpty(txtNumberDocCoAfi)) return;

            BrPerson brPerson = new BrPerson();

            bool response = brPerson.CoAfiliadoModiefied(
                txtNameCoAfi.Text + "|" +
                txtLastNameCoAfi.Text + "|" +
                txtBirthDayCoAfi.Text + "|" +
                txtNumberDocCoAfi.Text + "|" +
                typeDoc.ToString() + "|" +
                userName);
            //save changes
        }

        private bool IsEmpty(TextBox textBox)
        {
            string texto = textBox.Text;
            if (string.IsNullOrEmpty(texto))
            {
                lblMessageErrorCo.Text = "Complete todos los campos";
                return true;
            }
            return false;
        }
    }
}