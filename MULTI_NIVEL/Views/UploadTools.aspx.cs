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
    public partial class UploadTools : System.Web.UI.Page
    {
        string jar1 = "";
        string jar2 = "";
        string jar3 = "";
        string jar4 = "";
        string extension = "";
        string extTotal = "";
        int num = 0;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                var rutaPdf = HttpContext.Current.Server.MapPath("~/Archivos/pdf");
                var rutaImg = HttpContext.Current.Server.MapPath("~/Archivos/img");
                var rutaWord = HttpContext.Current.Server.MapPath("~/Archivos/word");
                var rutaVideos = HttpContext.Current.Server.MapPath("~/Archivos/videos");

                DirectoryInfo di1 = new DirectoryInfo(rutaPdf);
                DirectoryInfo di2 = new DirectoryInfo(rutaImg);
                DirectoryInfo di3 = new DirectoryInfo(rutaWord);
                DirectoryInfo di4 = new DirectoryInfo(rutaVideos);

                

                //PDF//PRESENTACION
                foreach (var fi1 in di1.GetFiles())
                {
                    num = num + 1;
                    Console.WriteLine(fi1.Name);
                    var ar = fi1.Name.Split('.');
                    extension = ar[ar.Length - 1];

                    extTotal = extTotal + "." + extension;
                    var todaslasextensiones = extTotal.Split('.');
                    jar1 = fi1.Name;
                    var carp = "pdf";

                    HyperLink itemhl = new HyperLink();
                    itemhl.NavigateUrl = "~/Archivos/pdf/" + jar1;
                    itemhl.Text = "" + jar1;
                    itemhl.Style.Add("width", "100%");
                    itemhl.Style.Add("display", "block");
                    itemhl.Target = "_blank";
                    itemhl.Style.Add("text-align", "start");

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

                    Label btnEli = new Label();
                    btnEli.Text = "X";
                    btnEli.Style.Add("width", "10%");
                    btnEli.Style.Add("height", "30px");
                    btnEli.Style.Add("border-radius", "8px");
                    btnEli.Style.Add("background", "white");
                    btnEli.Style.Add("color", "black");
                    btnEli.Style.Add("display", "block");
                    btnEli.Style.Add("margin", "0 auto");
                    btnEli.Style.Add("cursor", "pointer");
                    btnEli.Attributes.Add("onClick", "deleteDoc('" + jar1 + "," + carp + "')");

                    Panel div = new Panel();
                    div.Style.Add("display", "flex");

                    itemhl.Controls.Add(imgW);
                    itemhl.Controls.Add(lb);

                    div.Controls.Add(itemhl);
                    div.Controls.Add(btnEli);
                    panePdf.Controls.Add(div);
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
                    var carp = "img";
                    HyperLink itemhl = new HyperLink();
                    //imgTools.ImageUrl = "~/Archivos/img/" + fi2.Name;
                    //itemhl.ImageUrl = "~/Archivos/img/" + fi2.Name;
                    itemhl.NavigateUrl = "~/Archivos/img/" + fi2.Name;
                    itemhl.Style.Add("display", "inline-block");
                    itemhl.Target = "_blank";

                    Image img = new Image();
                    img.ImageUrl = "~/Archivos/img/" + fi2.Name;
                    img.Style.Add("width", "150px");
                    img.Style.Add("display", "block");
                    img.Style.Add("margin", "14px auto");

                    Label btnEli = new Label();
                    btnEli.Text = "X";
                    btnEli.Style.Add("width", "10%");
                    btnEli.Style.Add("height", "30px");
                    btnEli.Style.Add("border-radius", "8px");
                    btnEli.Style.Add("background", "white");
                    btnEli.Style.Add("color", "black");
                    btnEli.Style.Add("display", "inline-block");
                    btnEli.Style.Add("cursor", "pointer");
                    btnEli.Attributes.Add("onClick", "deleteDoc('" + jar2 + "," + carp + "')");

                    Panel div = new Panel();
                    div.Style.Add("display","flex");


                    itemhl.Controls.Add(img);

                    
                    div.Controls.Add(itemhl);
                    div.Controls.Add(btnEli);
                    panel.Controls.Add(div);

                }

                //WORD // DOCUMENTOS
                foreach (var fi3 in di3.GetFiles())
                {
                    num = num + 1;
                    Console.WriteLine(fi3.Name);
                    var ar = fi3.Name.Split('.');
                    extension = ar[ar.Length - 1];

                    extTotal = extTotal + "." + extension;
                    var todaslasextensiones = extTotal.Split('.');
                    jar3 = fi3.Name;
                    var carp = "word";


                    Image imgW = new Image();
                    imgW.ID = "img" + num;
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
                    itemhl.Style.Add("display", "inline-block");
                    itemhl.Style.Add("text-align", "start");
                    itemhl.Target = "_blank";

                    Label lb = new Label();
                    lb.Text = "" + jar3;
                    
                    Label btnEli = new Label();
                    btnEli.Text = "X";
                    btnEli.Style.Add("width", "10%");
                    btnEli.Style.Add("height", "30px");
                    btnEli.Style.Add("border-radius", "8px");
                    btnEli.Style.Add("background", "white");
                    btnEli.Style.Add("color", "black");
                    btnEli.Style.Add("display", "inline-block");
                    btnEli.Style.Add("margin", "0 auto");
                    btnEli.Style.Add("cursor", "pointer");
                    btnEli.Attributes.Add("onClick", "deleteDoc('"+ jar3 + ","+ carp + "')");

                    Panel div = new Panel();
                    div.Style.Add("display", "flex");

                    itemhl.Controls.Add(imgW);
                    itemhl.Controls.Add(lb);

                    div.Controls.Add(itemhl);
                    div.Controls.Add(btnEli);

                    paneW.Controls.Add(div);

                }

                //video
                //foreach (var fi4 in di4.GetFiles())
                //{
                //    num = num + 1;
                //    Console.WriteLine(fi4.Name);
                //    var ar = fi4.Name.Split('.');
                //    extension = ar[ar.Length - 1];

                //    extTotal = extTotal + "." + extension;
                //    var todaslasextensiones = extTotal.Split('.');
                //    jar4 = fi4.Name;
                //    var carp = "videos";

                //    HyperLink itemhl = new HyperLink();
                //    itemhl.NavigateUrl = "~/Archivos/videos/" + jar4;
                //    itemhl.Text = "" + jar4;
                //    itemhl.Style.Add("width", "100%");
                //    itemhl.Style.Add("display", "block");
                //    itemhl.Style.Add("text-align", "start");
                //    itemhl.Target = "_blank";

                //    //Video videoW = new Video();
                //    //videoW.src = "~/Archivos/videos/" + jar4;
                //    Image imgpre = new Image();
                //    imgpre.ImageUrl = "~/Archivos/imgprew.png";
                   
                //    imgpre.Style.Add("margin", "7px");
                   
                //    //Label lb = new Label();
                //    //lb.Text = "" + jar4;

                //    Label btnEli = new Label();
                //    btnEli.Text = "X";
                //    btnEli.Style.Add("width", "10%");
                //    btnEli.Style.Add("height", "30px");
                //    btnEli.Style.Add("border-radius", "8px");
                //    btnEli.Style.Add("background", "white");
                //    btnEli.Style.Add("color", "black");
                //    btnEli.Style.Add("display", "block");
                //    btnEli.Style.Add("margin", "0 auto");
                //    btnEli.Style.Add("cursor", "pointer");
                //    btnEli.Attributes.Add("onClick", "deleteDoc('" + jar4 + "," + carp + "')");

                //    Panel div = new Panel();
                //    div.Style.Add("display", "flex");


                //    //itemhl.Controls.Add(videoW);
                //    //itemhl.Controls.Add(lb);

                //    //player.HRef = videoW.src;
                //    itemhl.Controls.Add(imgpre);
                //    div.Controls.Add(itemhl);
                //    div.Controls.Add(btnEli);
                    
                //    //paneVideo.Controls.Add(CrearControlVideo());
                //    paneVideo.Controls.Add(div);
                //}
            }
        }
        
        protected void Button_Click(object sender, EventArgs e)
        {
            ((Label)Page.FindControl("Label1")).Text = "Panel refreshed at " +
                DateTime.Now.ToString();
        }

        private Control CrearControlVideo()
        {
            return new LiteralControl(@" <VIDEO align=middle src='~/Archivos/videos/" + jar4 + "' width=320 height=234 wmode='transparent'></VIDEO>");
        }
        public void btnDelete(object sender, EventArgs e)
        {
            lblinformacion.Text = "Ha ocurrido un error al intentar subir el archivo al servidor";

        }

        protected void MiBoton_Click(object sender, EventArgs e)
        {
            lblinformacion.Text = "Ha ocurrido un error al intentar subir el archivo al servidor";

            //var strin = DateTime.Now.ToString("yyyyMMddHHmmss");
            //var archivo = Server.MapPath("~/Archivos/img/") + FlpArchivo1.FileName;
            //var destino = Server.MapPath("~/Archivos/trash/") + FlpArchivo1.FileName;
            //if (File.Exists(archivo))
            //{
            //    File.SetAttributes(archivo, FileAttributes.Normal);
            //    File.Delete(archivo);
            //}
            //FlpArchivo1.Dispose();
            //System.IO.File.Delete(file);
        }
        //IMAGENES
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                var qwe = FlpArchivo1.FileName.Split('.');
                var ext = qwe[qwe.Length - 1];
                var dt = DateTime.Now.ToString("yyyyMMddHHmmss");

                if (ext != "img" && ext != "png" && ext != "jpg")

                { 
                    lblinformacion.Text = "Ha ocurrido un error al intentar subir el archivo al servidor";
                    lblinformacion.Style.Add("color", "red");
                    Response.Redirect("UploadTools.aspx");
                    return;
                }
                //var nameF = dt + FlpArchivo1.FileName;
                FlpArchivo1.SaveAs(Server.MapPath("~/Archivos/img/") + FlpArchivo1.FileName);
                lblinformacion.Text = "El archivo " + FlpArchivo1.FileName + " ha sido subido correctamente";
                lblinformacion.Style.Add("color", "#6be22e");
                Response.Redirect("UploadTools.aspx"); 
            }
            catch
            {
                lblinformacion.Text = "Ha ocurrido un error al intentar subir la imagen al servidor";
                lblinformacion.Style.Add("color", "red");
                Response.Redirect("UploadTools.aspx");
            }
        }
        //PRESENTACIONES
        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                var qwe = FlpArchivo2.FileName.Split('.');
                var ext = qwe[qwe.Length - 1];
                var dt = DateTime.Now.ToString("yyyyMMddHHmmss");

                if (ext != "pdf" && ext != "doc" && ext != "docx" && ext != "ppt" && ext != "pptx")
                {
                    lblinformacion.Text = "Ha ocurrido un error al intentar subir la iamgen";
                    lblinformacion.Style.Add("color", "red");
                    Response.Redirect("UploadTools.aspx");
                    return;
                }
                //var nameF = dt + FlpArchivo2.FileName;
                FlpArchivo2.SaveAs(Server.MapPath("~/Archivos/pdf/") + FlpArchivo2.FileName);
                lblinformacion.Text = "El archivo " + FlpArchivo2.FileName + " ha sido subido correctamente";
                lblinformacion.Style.Add("color", "#6be22e");
                Response.Redirect("UploadTools.aspx");
            }
            catch
            {
                lblinformacion.Text = "Ha ocurrido un error al intentar subir el archivo al servidor";
                lblinformacion.Style.Add("color", "red");
                Response.Redirect("UploadTools.aspx");
            }
        }
        //documentos 
        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                var qwe = FlpArchivo3.FileName.Split('.');
                var ext = qwe[qwe.Length - 1];
                var dt = DateTime.Now.ToString("yyyyMMddHHmmss");

                //if (ext != "doc" && ext != "docx" && ext != "pdf")
                if (ext != "pdf" && ext != "doc" && ext != "docx" && ext != "ppt" && ext != "pptx")
                {
                    lblinformacion.Text = "Ha ocurrido un error al intentar subir el archivo al servidor";
                    lblinformacion.Style.Add("color", "red");
                    Response.Redirect("UploadTools.aspx");
                    return;
                }
                //var nameF = dt + FlpArchivo3.FileName;
                FlpArchivo3.SaveAs(Server.MapPath("~/Archivos/word/") + FlpArchivo3.FileName);
                lblinformacion.Text = "El archivo " + FlpArchivo3.FileName + " ha sido subido correctamente";
                lblinformacion.Style.Add("color", "#6be22e");
                Response.Redirect("UploadTools.aspx");
            }
            catch
            {
                lblinformacion.Text = "Ha ocurrido un error al intentar subir el archivo al servidor";
                lblinformacion.Style.Add("color", "red");
                Response.Redirect("UploadTools.aspx");
            }
        }

        //video
        protected void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                
                var qwe = FlpArchivo4.FileName.Split('.');
                var ext = qwe[qwe.Length - 1];
                var nombre = qwe[qwe.Length - 2];
                var nomext = nombre + "." + ext;
                //var nomsinesp  = nomext.Trim();
                var nomsinesp  = nomext.Replace(" ", "");

                var dt = DateTime.Now.ToString("yyyyMMddHHmmss");

                if (ext != "mp4")
                {
                    lblinformacion.Text = "Ha ocurrido un error al intentar subir el archivo al servidor";
                    lblinformacion.Style.Add("color", "red");
                    Response.Redirect("UploadTools.aspx");
                    return;
                }
                var descubriendo = Server.MapPath("~/Archivos/videos/");
                FlpArchivo4.SaveAs(Server.MapPath("~/Archivos/videos/") + nomsinesp);
                lblinformacion.Text = "El archivo " + FlpArchivo4.FileName + " ha sido subido correctamente";
                lblinformacion.Style.Add("color", "#6be22e");
                Response.Redirect("UploadTools.aspx");
            }
            catch (Exception ex)
            {
                var q = ex.Message;
                lblinformacion.Text = "Ha ocurrido un error al intentar subir el archivo al servidor";
                lblinformacion.Style.Add("color", "red");
                Response.Redirect("UploadTools.aspx");
            }
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            Session.Contents.RemoveAll();
            FormsAuthentication.SignOut();
            Response.Redirect("Index.aspx", true); /*try merge*/
        }
    }
}