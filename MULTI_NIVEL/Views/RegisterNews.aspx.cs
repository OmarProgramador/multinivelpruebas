using BussinesRules.User;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MULTI_NIVEL.Views
{
    public partial class RegisterNews : System.Web.UI.Page
    {
        string userName = "";
        string titulo = "";
        string subtitulo = "";
        string contenido = "";
        string img = "";
        string fecha = "";
        string extension ="png";
        BrUser brUser = new BrUser();
        DateTime now = DateTime.Now;
        string fechaCreacion = "";
        string nombreArc ="novologo";
        System.Drawing.Image iiitt;
        
        int quantity = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            fechaCreacion = new DateTime(now.Year, now.Month, now.Day).ToShortDateString();
            txtFecha.Text = fechaCreacion;

        }
        protected void lblSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuBackend.aspx");
            FormsAuthentication.SignOut();
        }

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            titulo = txtTitu.Text;
            //subtitulo = txtSub.Text;
            contenido = txtCont.Text;

            if (string.IsNullOrEmpty(titulo))
            {
                lblErrorSi.Text = "Campo titulo obligatorio";
                return;
            }
            if (string.IsNullOrEmpty(contenido))
            {
                lblErrorSi.Text = "Campo contenido obligatorio";
                return;
            }


            string[] arraynombreArchivo2 = file_upload.FileName.Split('.');
            if (arraynombreArchivo2.Length > 1)
            {
                int indice = (arraynombreArchivo2.Length - 1);
                extension = arraynombreArchivo2[indice];
                nombreArc = arraynombreArchivo2[indice - 1];
            }

            string nombreArchivo = nombreArc + "." + extension;
            
           
            string ruta = "";

            if (extension.ToLower() == "png" || extension.ToLower() == "jpg" || extension.ToLower() == "jpeg")
            {
                if (nombreArchivo == "novologo.png")
                {
                    nombreArchivo = "novologo.png";
                    ruta = "~/Resources/ImgNews/novologo.png";
                    var reg = titulo + "|" + subtitulo + "|" + contenido + "|" + nombreArchivo + "|" + fechaCreacion;
                    if (string.IsNullOrEmpty(titulo))
                    {
                        lblErrorSi.Text = "Campo titulo obligatorio";
                        return;
                    }
                    if (string.IsNullOrEmpty(contenido))
                    {
                        lblErrorSi.Text = "Campo contenido obligatorio";
                        return;
                    }
                    brUser.RegisterNews(reg);
                    txtTitu.Text = "";
                    txtCont.Text = "";
                }
                else
                {
                    ruta = "~/Resources/ImgNews/" + nombreArchivo;
                    file_upload.SaveAs(Server.MapPath(ruta));
                    lblErrorSi.Text = "La Noticia Fue Registrada con exito";
                
                    string hex = "#2981c5";
                    var reg = titulo + "|" + subtitulo + "|" + contenido + "|" + nombreArchivo + "|" + fechaCreacion;
                    brUser.RegisterNews(reg);
                    txtTitu.Text = "";
                    txtCont.Text = "";
                }
                
                return;
            }

            lblErrorSi.Text = "La Imagen No tiene el Formato Correcto.";

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            //string id  = Request["id"].ToString();
            //BrUser bruser = new BrUser();
            //bruser.DeleteNews(id);
        }

      
    }
}