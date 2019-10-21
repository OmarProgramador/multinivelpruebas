using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MULTI_NIVEL.Views
{
    public partial class UploadToolsC : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request["id"];
            string carpeta = Request["carpeta"];
            string action = Request["action"];
            int num = 0;
            string extension = "";
            string extTotal = "";
            string jar4 = "";
            string answer = "";
            var palote = "";
            var rutaPdf = HttpContext.Current.Server.MapPath("~/Archivos/pdf");
            var rutaImg = HttpContext.Current.Server.MapPath("~/Archivos/img");
            var rutaWord = HttpContext.Current.Server.MapPath("~/Archivos/word");
            var rutaVideos = HttpContext.Current.Server.MapPath("~/Archivos/videos");
            var dt = DateTime.Now.ToString("yyyyMMddHHmmss"); 
            DirectoryInfo di1 = new DirectoryInfo(rutaPdf);
            DirectoryInfo di2 = new DirectoryInfo(rutaImg);
            DirectoryInfo di3 = new DirectoryInfo(rutaWord);
            DirectoryInfo di4 = new DirectoryInfo(rutaVideos);


            if (action == "borrarv")
            {
                var archivo = Server.MapPath("~/Archivos/" + carpeta + "/") + id;
                var destino = Server.MapPath("~/Archivos/trash/") + id;
                if (File.Exists(archivo))
                {
                    File.SetAttributes(archivo, FileAttributes.Normal);
                    File.Delete(archivo);
                }

                Response.Write("Se elimino correctamente");
            }
            else
            {
                foreach (var fi4 in di4.GetFiles())
                {

                    var ar = fi4.Name.Split('.');
                    jar4 = fi4.Name;
                    answer = answer + jar4 + "|";
                }
                Response.Write(answer);

            }
            
        }
    }
}