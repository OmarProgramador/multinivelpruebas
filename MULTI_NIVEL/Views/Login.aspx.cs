
namespace MULTI_NIVEL.Views
{
    using BussinesRules;
    using BussinesRules.User;
    using Entities;
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Linq;
    using System.Web.Security;

    public partial class Login : System.Web.UI.Page
    {
        BrUser brUser = new BrUser();
        string userName = "";
        public int StatusPayments { get; set; }
        public string ReturnUrl { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BrUser brUser = new BrUser();
                string returnUrl = Request["ReturnUrl"];

                if (!string.IsNullOrEmpty(returnUrl))
                {
                    this.ReturnUrl = returnUrl;
                }

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

                if (string.IsNullOrEmpty(upliner))
                {
                    upliner = "0";
                }

                if (!string.IsNullOrEmpty(afiliate) && !string.IsNullOrEmpty(upliner))
                {
                    string data = afiliate + "|" + upliner;

                    int idUpliner = brUser.ExistAccountLink(data);
                    if (idUpliner >= 0)
                    {
                        Session["Referido"] = afiliate;
                        Session["auxRef"] = "1";
                        Session["link"] = data + "|" + idUpliner;
                        FormsAuthentication.RedirectFromLoginPage(afiliate, chkPersistCookie.Checked);
                        Response.Redirect("Register.aspx");
                    }
                }


                //contador
                BrFundation brFundation = new BrFundation();
                int contador = int.Parse(brFundation.GetCount());

                foundingPartners.Text = contador.ToString();
                //foundingPartners2.Text = contador.ToString();





                BrAccount brAccount = new BrAccount();

                bool isRealize = brAccount.DeleteAccountUnconfirmed();
                if (isRealize)
                {
                    Email email = new Email();
                }
            }
        }
        protected void btnLogin_Click(object sender, EventArgs e)/*MERGE*/
        {
            bool respuesta = false;
            //string respuesta2 = "";
            string user = "", pass = "";
            user = txtUsuario.Text.Trim();
            pass = txtPassword.Text.Trim();
            Session["Discount"] = 0;
            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                return;
            }
            respuesta = this.ValidateUser(user, pass);
            BrUser obrUser = new BrUser();
            if (respuesta)
            {
                //    /*4 idasociado*/
                string name = obrUser.getName(txtUsuario.Text);
                Response.Cookies["Key"].Value = name;
                FormsAuthentication.RedirectFromLoginPage(name, chkPersistCookie.Checked);
            }
        }


        private bool ValidateUser(string userName, string passWord)
        {
            string lookupPassword = null;
            try
            {
                // el nombre de usuario no debe ser un valor nulo y debe tener entre 1 y 15 caracteres.
                if ((null == userName) || (0 == userName.Length) || (userName.Length > 20))
                {
                    System.Diagnostics.Trace.WriteLine("[ValidateUser] Input validation of userName failed.");
                    return false;
                }

                // Buscar contraseña no válida.
                // La contraseña no debe ser un valor nulo y debe tener entre 1 y 25 caracteres.
                if ((null == passWord) || (0 == passWord.Length) || (passWord.Length > 25))
                {
                    System.Diagnostics.Trace.WriteLine("[ValidateUser] Input validation of passWord failed.");
                    return false;
                }

                BrUser brUser = new BrUser();

                var anwser = brUser.LoginUser(userName, passWord).Split('¬');

                lookupPassword = anwser[0];
                if (anwser.Length > 1)
                {
                    StatusPayments = int.Parse(anwser[1]);
                }


                // Si no se encuentra la contraseña, devuelve false.
                if (null == lookupPassword)
                {
                    // Para más seguridad, puede escribir aquí los intentos de inicio de sesión con error para el registro de eventos.
                    return false;
                }
                // Comparar lookupPassword e introduzca passWord, usando una comparación que distinga mayúsculas y minúsculas.
                return (0 == string.Compare(lookupPassword, passWord, false));
            }
            catch (Exception ex)
            {
                // Agregar aquí un control de errores para la depuración.
                // Este mensaje de error no debería reenviarse al que realiza la llamada.
                System.Diagnostics.Trace.WriteLine("[ValidateUser] Exception " + ex.Message);
                return false;
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

        protected void btnRecuperar_Click(object sender, EventArgs e)
        {
            /*metodo para traer el email el usuario*/
            Email email = new Email();
            Validation val = new Validation();
            BrUser brUser = new BrUser();
            string userName = txtUserRec.Text.Trim(); ;

            if (string.IsNullOrEmpty(userName))
            {
                lblanswer.Text = "El Campo Usuario es Obligatorio";
                return;
            }

            string[] aInfo = brUser.GetPersonalInformation(userName).Split('|');

            if (aInfo.Length < 3)
            {
                lblanswer.Text = "El Usuario No es Correcto";
                return;
            }

            if (email.SubmitEmail(aInfo[5], "[InResorts - RECUPERACION DE CONTRASEÑA]", "Su contraseña Es :" + aInfo[15]))
            {
                string hex = "#2981c5";
                Color _color = ColorTranslator.FromHtml(hex);
                lblanswer.Text = "Se envió su contraseña a su Correo";
                lblanswer.ForeColor = _color;

            }
            else
            {
                lblanswer.Text = "Ocurrio un Error";
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
                    string names = obrUser.getName(txtReferido.Text);
                    Session["Referido"] = txtReferido.Text;
                    Session["auxRef"] = "1";
                    if (names != "ERROR")
                    {
                        FormsAuthentication.RedirectFromLoginPage(names + "¬referido", chkPersistCookie.Checked);
                    }
                }
                
            }
            else
            {

                Response.Redirect("Index.aspx?Key=" + userName, true);
            }
        }

        protected void Backend_Click(object sender, EventArgs e)
        {
            FormsAuthentication.RedirectFromLoginPage("", chkPersistCookie.Checked);
            Response.Redirect("Backend.aspx", true);
            /*MERGE*/
        }

        protected void btnEnviarImagen_Click(object sender, EventArgs e)
        {
            string numdoc = "";
            userName = "";
            numdoc = txtNumeroDoc.Text.Trim();
            if (string.IsNullOrEmpty(numdoc))
            {
                lblErrorSi.Text = "El Numero de Documento es Obligatorio.";
                lblErrorSi2.Text = "El Numero de Documento es Obligatorio.";
                txtNumeroDoc.Focus();
                return;
            }
            if (!file_upload.HasFile)
            {
                lblErrorSi.Text = "No hay una Imagen Seleccionada.";
                lblErrorSi2.Text = "No hay una Imagen Seleccionada.";/*TRY MERGE WILL*/
                return;
            }
            Validation val = new Validation();
            bool isDoc = val.IsDocument(numdoc);
            if (!isDoc)
            {
                lblErrorSi.Text = "El Dato Ingresado No es un Documento Valido.";
                lblErrorSi2.Text = "El Dato Ingresado No es un Documento Valido.";
                return;
            }

            BrInformacion brInformacion = new BrInformacion();
            string[] anwser = brInformacion.GetBYNunDoc(numdoc).Split('|');

            if (anwser.Length < 2)
            {
                lblErrorSi.Text = "Aun no eres Socio.";
                lblErrorSi2.Text = "Aun no eres Socio.";
                return;
            }
            userName = anwser[0];
            string idMPayMdetail = anwser[1];

            if (!val.IsEntero(idMPayMdetail))
            {
                lblErrorSi.Text = "Ocurrio un error de sistema.";
                lblErrorSi2.Text = "Ocurrio un error de sistema.";
                return;
            }
            if (!file_upload.HasFile)
            {
                lblErrorSi.Text = "No hay una Imagen Seleccionada.";
                lblErrorSi2.Text = "No hay una Imagen Seleccionada.";
                return;
            }
            //si hay una archivo.

            string[] arraynombreArchivo2 = file_upload.FileName.Split('.');

            int indice = (arraynombreArchivo2.Length - 1);

            string extension = arraynombreArchivo2[indice];

            if (extension.ToLower() == "png" || extension.ToLower() == "jpg" || extension.ToLower() == "jpeg")
            {

                var idmem = LblIdMembership.Text.Trim();

                if (idmem != "")
                {
                    idMPayMdetail = idmem;
                }

                var key = DateTime.Now.ToString("yyyyMMddHHmmss");
                string nombreArchivo = $"login{key}__{idMPayMdetail}" + userName + "." + extension;

                if (val.IsEntero(idMPayMdetail))
                {
                    //var llave = Guid.NewGuid().ToString();

                    string ruta = "~/Resources/RecibosRegister/" + nombreArchivo;

                    //ComprimirImagen(file_upload.FileContent, ruta, "Jpeg", 40);
                    //GuardarImage(file_upload.FileContent, ruta, "compresionImagen.Jpeg", "jpg");

                    file_upload.SaveAs(Server.MapPath(ruta));
                }
                BrUser brUser = new BrUser();
                bool updateIdMent = false;


                if (idmem != "")
                {
                    if (val.IsEntero(idmem))
                    {
                        BrMembershipPayDetail brMembership = new BrMembershipPayDetail();
                        var response = brMembership.GetQuote(int.Parse(idmem), userName).Split('|');
                        var quote = response[0];

                        //DateTime payDate = DateTime.Parse("2019-04-04 23:59:59");
                        //if (decimal.Parse(quote) == decimal.Parse("0"))
                        //{
                        //    lblErrorSi.Text = "Ocurrio un error.";
                        //    lblErrorSi2.Text = "Ocurrio un error.";
                        //    return;
                        //}
                        updateIdMent = brMembership.PutReceiptQuote(idmem, nombreArchivo);
                    }
                }
                else
                {
                    updateIdMent = brUser.PorVerificar(idMPayMdetail + "¬" + userName + "¬" + nombreArchivo);
                }

                if (!updateIdMent)
                {
                    lblErrorSi.Text = "Usted ya no puede subir recibos.";
                    lblErrorSi2.Text = "Usted ya no puede subir recibos.";
                    return;
                }


                lblErrorSi.Text = "El Recibo Fue Enviado Con exito, espere la confirmación que se le estará enviando a su correo, dentro de las proximas 24 horas";
                lblErrorSi2.Text = "El Recibo Fue Enviado Con exito, espere la confirmación que se le estará enviando a su correo, dentro de las proximas 24 horas";
                txtNumeroDoc.Text = "";

                Email oEmail = new Email();
                MyMessages mm = new MyMessages();
                var emailUser = anwser[2].Trim();
                string fname = mm.ToCapitalize(anwser[3].Trim()).Trim();
                string gender = anwser[4].Trim();

                bool answer = oEmail.SendEmail(emailUser, "[Ribera del Rio - Inresorts, Registro en Proceso]", mm.MessageComprobandoImagen(fname, gender), true);
                answer = oEmail.SendEmail("omarurteaga@gmail.com", "[Ribera del Rio - Inresorts, Registro en Proceso]", mm.MessageComprobandoImagen(fname, gender), true);

                string hex = "#2981c5";
                Color _color = ColorTranslator.FromHtml(hex);
                lblErrorSi2.ForeColor = _color;
                lblErrorSi.ForeColor = _color;
                return;
            }
            lblErrorSi.Text = "La Imagen No tiene el Formato Correcto.";
            lblErrorSi2.Text = "La Imagen No tiene el Formato Correcto.";
        }

        protected void btnValidar_Click(object sender, EventArgs e)
        {
            var dni = txtFName.Text;
            var name = brUser.GetName(dni);
        }

        #region Compresion
        private bool GuardarImage(Stream file, string path, string fileName, string fileExt)
        {
            try
            {
                Image imagen = System.Drawing.Image.FromStream(file);
                Bitmap bmp1 = new Bitmap(imagen);
                ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);
                // Create an Encoder object based on the GUID
                // for the Quality parameter category.
                System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;

                // Create an EncoderParameters object.
                // An EncoderParameters object has an array of EncoderParameter
                // objects. In this case, there is only one
                // EncoderParameter object in the array.
                EncoderParameters myEncoderParameters = new EncoderParameters(1);
                EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 100); //0 el máximo de compresión y 100 el mínimo

                myEncoderParameters.Param[0] = myEncoderParameter;
                //, 
                bmp1.Save(path + fileName, jpgEncoder, myEncoderParameters);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private ImageCodecInfo GetEncoder(ImageFormat format)
        {

            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();

            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }
        #endregion


        #region Compre2
        private void ComprimirImagen(Stream inputFile, string ouputfile, string extension, long compression)
        {
            try
            {
                Image image = Image.FromStream(inputFile);
                EncoderParameters eps = new EncoderParameters(1);

                eps.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, compression);
                string mimetype = GetMimeType("." + extension);
                ImageCodecInfo ici = GetEncoderInfo(mimetype);

                image.Save(ouputfile, ici, eps);
            }
            catch (Exception ex)
            {
                string mesa = ex.Message;
            }
        }

        private string GetMimeType(string ext)
        {
            //    CodecName FilenameExtension FormatDescription MimeType 
            //    .BMP;*.DIB;*.RLE BMP ==> image/bmp 
            //    .JPG;*.JPEG;*.JPE;*.JFIF JPEG ==> image/jpeg 
            //    *.GIF GIF ==> image/gif 
            //    *.TIF;*.TIFF TIFF ==> image/tiff 
            //    *.PNG PNG ==> image/png 
            switch (ext.ToLower())
            {
                case ".bmp":
                case ".dib":
                case ".rle":
                    return "image/bmp";

                case ".jpg":
                case ".jpeg":
                case ".jpe":
                case ".fif":
                    return "image/jpeg";

                case "gif":
                    return "image/gif";
                case ".tif":
                case ".tiff":
                    return "image/tiff";
                case "png":
                    return "image/png";
                default:
                    return "image/jpeg";
            }
        }

        private ImageCodecInfo GetEncoderInfo(string mimeType)
        {

            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();

            ImageCodecInfo encoder = (from enc in encoders
                                      where enc.MimeType == mimeType
                                      select enc).First();
            return encoder;

        }
        #endregion

        protected void BtnPayFastVerif_Click(object sender, EventArgs e)
        {
            string pin = string.Empty;
            string codeUserna = string.Empty;
            string descripcion = string.Empty;
            string datepay = string.Empty;
            string currencycode = string.Empty;
            decimal amount = 0;

            try
            {
                pin = Pin.Text.Trim();
                codeUserna = CodeUserName.Text.Trim();

                if (string.IsNullOrEmpty(pin) || string.IsNullOrEmpty(codeUserna))
                {
                    return;
                }

                BrMembershipPayDetail brMembership = new BrMembershipPayDetail();
                var response = brMembership.GetQuote(int.Parse(pin), codeUserna).Split('|');

                amount = decimal.Parse(response[0]);

                if (amount == 0)
                {
                    PayFastInfo.Text = "No hay Datos que coincidan con el pin.";
                    PayFastInfo.Style.Add("color", "red");
                    return;
                }
                MyFunctions mf = new MyFunctions();

                datepay = response[1];
                currencycode = response[2];
                descripcion = response[3];

                PayFastInfo.Style.Add("color", "black");
                PayFastInfo.Text = $"<b>Descripción:</b> {descripcion} <br><b>Monto:</b> {amount.ToString()} {currencycode} <br><b>Fecha de Pago:</b> {mf.DateFormatClient(datepay)}";
                BtnPayFastVerif.Style.Add("display", "none");
                PayFastDiv.Style.Add("display", "block");
            }
            catch (Exception ex)
            {
                PayFastInfo.Style.Add("color", "red");
                PayFastInfo.Text = "Ocurrio un error.";
            }
        }

        protected void BtnPayFastSend_Click(object sender, EventArgs e)
        {
            string pin = string.Empty;
            string codeUserna = string.Empty;
            string descripcion = string.Empty;
            string datepay = string.Empty;
            string currencycode = string.Empty;

            try
            {
                if (!file_upload2.HasFile)
                {
                    PayFastInfo.Style.Add("color", "red");
                    PayFastInfo.Text = "No hay una Imagen Seleccionada.";
                    return;
                }

                pin = Pin.Text.Trim();
                codeUserna = CodeUserName.Text.Trim();

                if (string.IsNullOrEmpty(pin) || string.IsNullOrEmpty(codeUserna))
                {
                    PayFastInfo.Style.Add("color", "red");
                    PayFastInfo.Text = "Ocurrio un error.";
                    return;
                }

                if (0 == decimal.Parse(pin))
                {
                    PayFastInfo.Style.Add("color", "red");
                    PayFastInfo.Text = "Ocurrio un error.";
                    return;
                }

                MyFunctions mf = new MyFunctions();

                string[] arraynombreArchivo2 = file_upload2.FileName.Split('.');

                int indice = (arraynombreArchivo2.Length - 1);

                string extension = arraynombreArchivo2[indice];

                if (extension.ToLower() != "png" && extension.ToLower() != "jpg" && extension.ToLower() != "jpeg")
                {
                    PayFastInfo.Style.Add("color", "red");
                    PayFastInfo.Text = "Extensiones aceptadas: png, jpg, jpeg";
                }

                var key = DateTime.Now.ToString("yyyyMMddHHmmss");
                string nombreArchivo = $"payfast{key}__{pin}" + codeUserna + "." + extension;

                string ruta = Server.MapPath("~/Resources/RecibosRegister/" + nombreArchivo);

                ComprimirImagen(file_upload2.FileContent, ruta, "Jpeg", 40);

                BrMembershipPayDetail brMembership = new BrMembershipPayDetail();

                bool issucess = brMembership.PutReceiptQuote(pin, nombreArchivo);
                if (issucess)
                {
                    PayFastInfo.Style.Add("color", "green");
                    PayFastInfo.Text = "La operacion se realizo con exito. Dentro de las 24 horas se confirmara su pago.";
                }
            }
            catch (Exception ex)
            {
                PayFastInfo.Style.Add("color", "red");
                PayFastInfo.Text = "Ocurrio un error.";
            }
        }
    }
}