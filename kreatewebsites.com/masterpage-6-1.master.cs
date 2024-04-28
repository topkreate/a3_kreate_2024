using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class Master : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

        /*  topheader.Text = Global.Sitename.ToString();
         topheader.NavigateUrl = Global.Siteurl.ToString(); */

        if (topheader != null)
        {
            topheader.Text = Page.Title;
        }
        //  topheader.NavigateUrl = Global.Siteurl.ToString(); 

        if (hyperlinkHome != null)
        {
            hyperlinkHome.Text = "Home";
            hyperlinkHome.NavigateUrl = Global.Siteurl.ToString();
        }

        //footerhead.Text = Global.Sitename;
        //footerhead.NavigateUrl = Global.Siteurl;
        //footerhead.ToolTip = Global.Sitename;
        footerfooter.Text = Global.Sitename;
        footerfooter.NavigateUrl = Global.Siteurl;

        cright.Text = Global.Sitename;
        privacypolicy.Text = "Privacy Policy";
        privacypolicy.NavigateUrl = Global.Siteurl + "privacypolicy.html";

    }
}
