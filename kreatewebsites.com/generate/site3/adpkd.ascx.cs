using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Xml;
using System.Xml.Xsl;
using System.Data.Sql;
using System.Data.SqlClient;

using System.IO;



public partial class Default : System.Web.UI.UserControl
{
 //   protected string computerpath = @"C:\e\a1_sites\10\www.kreatewebsites.com\input\Places to see\";
    protected string computerpath = LocalPath.ComputerPath;

    protected string sitepath = Global.Siteurl.ToString();


    protected void Page_Load(object sender, EventArgs e)
    {
        string adscript;
        switch (Global.adID)
        {
            case 0:
                adscript = System.IO.File.ReadAllText(@"c:\e\a3_kreate\Kreatewebsites.com\appblock\inc0\ad728.ad");
                break;
            case 1:
                adscript = System.IO.File.ReadAllText(@"c:\e\a3_kreate\Kreatewebsites.com\appblock\inc\ad728.ad");
                break;
            case 2:
                adscript = System.IO.File.ReadAllText(@"c:\e\a3_kreate\Kreatewebsites.com\appblock\inc2\ad728.ad");
                break;

            case 3:
                adscript = System.IO.File.ReadAllText(@"c:\e\a3_kreate\Kreatewebsites.com\appblock\inc3\ad728.ad");
                break;
            case 102:
                adscript = System.IO.File.ReadAllText(@"c:\e\a3_kreate\Kreatewebsites.com\ad\102\adgooglemanage.ad");
                break;
            default:
                adscript = System.IO.File.ReadAllText(@"c:\e\a3_kreate\Kreatewebsites.com\appblock\inc\ad728.ad");
                break;
        }

        ad.Text = adscript;

    }



    


 
}
