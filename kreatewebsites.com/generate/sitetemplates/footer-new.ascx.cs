



using System;
using System.Web;
using System.Web.UI;

namespace YourNamespace
{
    public partial class UserControl : System.Web.UI.UserControl
    {
        public string HtmlContent { get; set; }

        protected override void Render(HtmlTextWriter writer)
        {

            HtmlContent = "  <a class=\"btn btn-link\" href=\"\">Services</a>";
            writer.Write(HtmlContent);
        }
    }
}



