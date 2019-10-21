using BussinesRules.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MULTI_NIVEL.Views
{
    public partial class EditNews : System.Web.UI.Page
    {
        string fActual = "";
        DateTime now = DateTime.Now;
        string datos = "";
        string id = "";
        string extension = "png";
        string nombreArc = "novologo";

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request["id"];

            if (!IsPostBack)
            {
                var title = Request["title"];
                var content = Request["content"];
                var img = Request["img"];
                var date = Request["date"];
                nombreArc = img;
                //fVig = now.AddDays(+30).ToShortDateString();
                fActual = new DateTime(now.Year, now.Month, now.Day).ToShortDateString();
                //if (code.Equals("e0"))
                //{

                //    txtTitu.Text = "";
                //    txtCont.Text = "";
                //    file_upload.ImageUrl = "~/Views/img/collage5.png";

                //}

                txtTitu.Text = title;
                txtCont.Text = content;
                file_upload.ImageUrl = "/Resources/ImgNews/" + img;
                txtFecha.Text = date;
            }

        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
             
            BrUser brUser = new BrUser();
            string[] arraynombreArchivo2 = FileUpload1.FileName.Split('.');
            if (arraynombreArchivo2.Length > 1)
            {
                int indice = (arraynombreArchivo2.Length - 1);
                extension = arraynombreArchivo2[indice];
                nombreArc = arraynombreArchivo2[indice - 1];
            }


            string ruta = "";

            if (extension.ToLower() == "png" || extension.ToLower() == "jpg" || extension.ToLower() == "jpeg")
            {
                string nombreArchivo = nombreArc + "." + extension;
                ruta = "~/Resources/ImgNews/" + nombreArchivo;
                FileUpload1.SaveAs(Server.MapPath(ruta));
                lblErrorSi.Text = "La Noticia Fue Modificada con exito";
                string hex = "#2981c5";
                datos = id + "¬" + txtTitu.Text + "¬" + txtCont.Text + "¬" + nombreArchivo;
                bool anwser = brUser.UpdateNews(datos);
                if (anwser)
                {
                    lblErrorSi.Text = "Noticia Modificada.";
                    //Thread.Sleep(5000);
                    Response.Redirect("RegisterNews.aspx", true);
                }
            }


           
        }
    }
}