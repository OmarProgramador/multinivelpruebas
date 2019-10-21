using BussinesRules.User;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MULTI_NIVEL.Views
{
    public partial class Tools : System.Web.UI.Page
    {
        string[] obj = HttpContext.Current.User.Identity.Name.Split('¬');
        BrUser brUser = new BrUser();
        string def = "profile.png";
        string extu = ".png";
        string name = "";
        string nombreu = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                //var arraLogin = HttpContext.Current.User.Identity.Name.Split('¬');
                //if (arraLogin.Length == 1)
                //{
                //    Response.Redirect("Register.aspx", true);
                //}


                //Session["Referido"] = arraLogin[1];

                var arraLogin = HttpContext.Current.User.Identity.Name.Split('¬');
                if (arraLogin.Length == 1)
                {
                    Response.Redirect("Register.aspx", true);
                }


                Session["Referido"] = arraLogin[1];


                this.lblUser.Text = "Hola " + arraLogin[0];
                this.lblUserName.Text = arraLogin[0];
                this.lblNumPartner.Text = "N° Asociado: " + arraLogin[4];

                if (true)
                {
                    this.imgProfile.ImageUrl = "~/Resources/Images/profile.png";
                    this.imgProfileFl.ImageUrl = "~/Resources/Images/profile.png";
                }

                BrUser brUser = new BrUser();
                string nsocios = brUser.GetCountsAsociate();


                if (true)
                {
                    this.imgProfile.ImageUrl = "~/Resources/Images/profile.png";
                    this.imgProfileFl.ImageUrl = "~/Resources/Images/profile.png";
                }

                
                //lblnsocios.Text = nsocios;
                var rutaPdf = HttpContext.Current.Server.MapPath("~/Archivos/pdf");
                var rutaImg = HttpContext.Current.Server.MapPath("~/Archivos/img");
                var rutaWord = HttpContext.Current.Server.MapPath("~/Archivos/word");
                var rutaVideos = HttpContext.Current.Server.MapPath("~/Archivos/Videos");

                DirectoryInfo di1 = new DirectoryInfo(rutaPdf);
                DirectoryInfo di2 = new DirectoryInfo(rutaImg);
                DirectoryInfo di3 = new DirectoryInfo(rutaWord);
                DirectoryInfo di4 = new DirectoryInfo(rutaVideos);
                var jar1 = "";
                var jar2 = "";
                var jar3 = "";
                var jar4 = "";
                var extension = "";
                var extTotal="";
                var num = 0;
               
                //PDF
                foreach (var fi1 in di1.GetFiles())
                {
                    num = num + 1;
                    Console.WriteLine(fi1.Name);
                    var ar = fi1.Name.Split('.');
                    extension = ar[ar.Length - 1];
                  
                    extTotal = extTotal + "." + extension;
                    var todaslasextensiones = extTotal.Split('.');
                    jar1 = fi1.Name;

                    HyperLink itemhl = new HyperLink();
                    itemhl.NavigateUrl = "~/Archivos/pdf/" + jar1;
                    itemhl.Text = "" + jar1;
                    itemhl.Style.Add("width", "100%");
                    itemhl.Style.Add("display", "block");
                    itemhl.Target = "_blank";
                    itemhl.Style.Add("text-align", "start");
                    itemhl.Target = "_blank";

                    Image imgW = new Image();
                    if (extension == "pdf")
                    {
                        imgW.ImageUrl = "~/Archivos/pdf2.png";
                    }
                    if (extension == "doc" || extension == "docx")
                    {
                        imgW.ImageUrl = "~/Archivos/word.png";
                    }
                    if (extension == "ppt" || extension == "pptx")
                    {
                        imgW.ImageUrl = "~/Archivos/ppt.png";
                    }
                    imgW.Style.Add("width", "34px");
                    imgW.Style.Add("margin", "7px");

                    
                    Label lb = new Label();
                    lb.Text = "" + jar1;

                    itemhl.Controls.Add(imgW);
                    itemhl.Controls.Add(lb);
                    paneW.Controls.Add(itemhl);

                    panePdf.Controls.Add(itemhl);
                }

                //img
                foreach (var fi2 in di2.GetFiles())
                {
                    num = num + 1;
                    Console.WriteLine(fi2.Name);
                    var ar = fi2.Name.Split('.');
                    extension = ar[ar.Length - 1];

                    extTotal = extTotal + "." + extension;
                    var todaslasextensiones = extTotal.Split('.');
                    jar2 = fi2.Name;

                    HyperLink itemhl = new HyperLink();
                    //imgTools.ImageUrl = "~/Archivos/img/" + fi2.Name;
                    //itemhl.ImageUrl = "~/Archivos/img/" + fi2.Name;
                    itemhl.NavigateUrl = "~/Archivos/img/" + fi2.Name;
                    itemhl.Target = "_blank";

                    Image img = new Image();
                    img.ImageUrl = "~/Archivos/img/" + fi2.Name;
                    img.Style.Add("width","150px");
                    img.Style.Add("display", "block");
                    img.Style.Add("margin", "14px auto");

                    //itemhl.Style.Add("display","");
                    itemhl.Controls.Add(img);
                    panel.Controls.Add(itemhl);
                    
                }

                //WORD
                foreach (var fi3 in di3.GetFiles())
                {
                    num = num + 1;
                    Console.WriteLine(fi3.Name);
                    var ar = fi3.Name.Split('.');
                    extension = ar[ar.Length - 1];

                    extTotal = extTotal + "." + extension;
                    var todaslasextensiones = extTotal.Split('.');
                    jar3 = fi3.Name;

                    //Label lab = new Label();
                    //lab.Text = "" + jar3;
                    //lab.Style.Add("width","100%");
                    //lab.Style.Add("display", "block");
                    //HyperLink hpl3 = new HyperLink();
                    //hpl3.NavigateUrl = "~/Archivos/word/" + jar3;
                    //paneW.Controls.Add(lab);
                    //paneW.Controls.Add(hpl3);

                    Image imgW = new Image();
                    if (extension == "pdf")
                    {
                        imgW.ImageUrl = "~/Archivos/pdf2.png";
                    }
                    if (extension == "doc" || extension == "docx")
                    {
                        imgW.ImageUrl = "~/Archivos/word.png";
                    }
                    if (extension == "ppt" || extension == "pptx")
                    {
                        imgW.ImageUrl = "~/Archivos/ppt.png";
                    }
                    imgW.Style.Add("width", "34px");
                    imgW.Style.Add("margin", "7px");

                    HyperLink itemhl = new HyperLink();
                    //itemhl.ImageUrl = "~/Archivos/word/" + jar3;
                    itemhl.NavigateUrl = "~/Archivos/word/" + jar3;
                    itemhl.Style.Add("display", "block");
                    itemhl.Style.Add("text-align", "start");
                    itemhl.Target = "_blank";

                    Label lb = new Label();
                    lb.Text = "" + jar3;

                    itemhl.Controls.Add(imgW);
                    itemhl.Controls.Add(lb);
                    paneW.Controls.Add(itemhl);

                }

                // Imagen de PErfil
                var rutaImgP = HttpContext.Current.Server.MapPath("~/Resources/imguser");
                DirectoryInfo niwi1 = new DirectoryInfo(rutaImgP);
                nombreu = obj[1];
                foreach (var fi2 in niwi1.GetFiles())
                {
                    var archivo = fi2.Name.Split('.');
                    name = archivo[archivo.Length - 2];
                    extu = archivo[archivo.Length - 1];
                    if (name == nombreu) { def = nombreu + "." + extu; }
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
        }

        protected void lbkBtnSalir_Click(object sender, EventArgs e)
        {   
            Session.RemoveAll();
            FormsAuthentication.SignOut();
            HttpContext.Current.Response.Redirect("Index.aspx", true);
        }

    }
}