using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MULTI_NIVEL.Views
{
    public partial class BListPartner : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Panel panel = new Panel();
            //<sessionState timeout="# de minutos" />
            //tag.WriteBeginTag("<video>");
            //tag.WriteEndTag("</video>");

            //panel.Text = "<video src='/Resources/video/Paulo-Londra-Tal-Vez.mp4' controls></video>";
        }

        
    }

    public class Video : WebControl
    {        
        public string src { get; set; }
    }

}