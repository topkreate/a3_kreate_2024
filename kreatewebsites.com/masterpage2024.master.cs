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
using System.Web.Services.Protocols;

public partial class Master : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

        /*  topheader.Text = Global.Sitename.ToString();
         topheader.NavigateUrl = Global.Siteurl.ToString(); */
        /*
        if (topheader != null)
        {
            topheader.Text = Page.Title;
        }
        */
        //  topheader.NavigateUrl = Global.Siteurl.ToString(); 

        /*Check that sitename.txt file is placed */
        
        if (topheader != null)
        {
          topheader.Text = Global.Sitename ;
        }
        topheader.NavigateUrl = Global.Siteurl.ToString();

        //Response.Write("Sitename = ", Global.Sitename );
        KreateWebsites.Generate.kreatelog("XXXXXXXX = " + Global.Sitename + "," +  Global.Siteurl);
        KreateWebsites.Generate.kreatelog2("AXXXXXXXX = " + Global.Sitename + "," + Global.Siteurl);
        if (hyperlinkHome != null)
        {
            hyperlinkHome.Text = "Home";
            hyperlinkHome.NavigateUrl = Global.Siteurl.ToString();
        }



    }
}
