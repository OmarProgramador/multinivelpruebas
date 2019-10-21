using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace MULTI_NIVEL.Views
{
    public partial class EditPthotoC : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string userName = User.Identity.Name.Split('¬')[1];
            string datecur = DateTime.Now.ToString("yyyyMMddhhmmssfff");

            string path = Server.MapPath("~/Resources/imguser/" + userName + ".jpg");
            string destin = HttpContext.Current.Server.MapPath("~/Resources/trash/profile" + userName + datecur + ".jpg");
            if (File.Exists(path))
            {
                File.Move(path, destin);
            }

            string imagenre = Request["image"];

            var uno = imagenre.Split(';')[1];

            var imagenstr = uno.Split(',')[1];
            var imagen = Base64ToImage(imagenstr);
            Response.Write(SaveImagePerfil(imagen, userName));
        }

        public Image Base64ToImage(string base64String)
        {
            // Convert base 64 string to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            // Convert byte[] to Image
            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                Image image = Image.FromStream(ms, true);
                return image;
            }
        }

        public string SaveImagePerfil(Image image, string userName)
        {
            //create new image
            Bitmap bitmap = new Bitmap(1, 1);
            //Properties string to draw
            Font font = new Font("sans-serif", 30, FontStyle.Bold, GraphicsUnit.Pixel);
            Graphics graphics = Graphics.FromImage(bitmap);

            int width = image.Width;
            int height = image.Height;
            bitmap = new Bitmap(bitmap, new Size(width, height));
            //add text to image
            graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.White);

            /*begin*/
            //string rutafond = HttpContext.Current.Server.MapPath("~/Views/img/fondo" + rango + ".png");
            //Image fondo = Image.FromFile(rutafond);
            graphics.DrawImage(image, 0, 0);
            /*end*/

            //execute pending graphics
            graphics.Flush();
            //release resources used by graphics
            graphics.Dispose();
            //save the image 
            string rutaImg = HttpContext.Current.Server.MapPath("~/Resources/imguser/" + userName + ".jpg");
            bitmap.Save(rutaImg, System.Drawing.Imaging.ImageFormat.Png);

            //do something with image
            return rutaImg;
        }
    }
}