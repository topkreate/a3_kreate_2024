using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Control_Homeright : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string adscript;
        switch (Global.adID)
        {
            case 0:
                //adscript = System.IO.File.ReadAllText(@"c:\e\a1_sites\100\Kreatewebsites.com\appblock\inc0\ad728.ad");
                adscript = System.IO.File.ReadAllText(@"c:\e\a3_kreate\Kreatewebsites.com\ad\inc0\ad728.ad");
                break;
            case 1:
                // adscript = System.IO.File.ReadAllText(@"c:\e\a1_sites\100\Kreatewebsites.com\appblock\inc\ad728.ad");
                adscript = System.IO.File.ReadAllText(@"c:\e\a3_kreate\Kreatewebsites.com\ad\inc\ad728.ad");
                break;
            case 2:
                // adscript = System.IO.File.ReadAllText(@"c:\e\a1_sites\100\Kreatewebsites.com\appblock\inc2\ad728.ad");
                adscript = System.IO.File.ReadAllText(@"c:\e\a3_kreate\Kreatewebsites.com\ad\inc2\ad728.ad");
                break;

            case 3:
                adscript = System.IO.File.ReadAllText(@"c:\e\a1_sites\100\Kreatewebsites.com\appblock\inc3\ad728.ad");
                adscript = System.IO.File.ReadAllText(@"c:\e\a3_kreate\Kreatewebsites.com\ad\inc3\ad728.ad");
                break;

            case 4:
                //adscript = System.IO.File.ReadAllText(@"c:\e\a1_sites\100\Kreatewebsites.com\appblock\inc4\ad728.ad");
                adscript = System.IO.File.ReadAllText(@"c:\e\a3_kreate\Kreatewebsites.com\ad\inc4\ad728.ad");
                break;
            case 5:
                // adscript = System.IO.File.ReadAllText(@"c:\e\a1_sites\100\Kreatewebsites.com\appblock\inc5\ad728.ad");
                adscript = System.IO.File.ReadAllText(@"c:\e\a3_kreate\Kreatewebsites.com\ad\inc5\ad728.ad");
                break;

            case 6:
                // adscript = System.IO.File.ReadAllText(@"c:\e\a1_sites\100\Kreatewebsites.com\appblock\inc6\ad728.ad");
                adscript = System.IO.File.ReadAllText(@"c:\e\a3_kreate\Kreatewebsites.com\ad\inc6\ad728.ad");
                break;
            case 7:
                // adscript = System.IO.File.ReadAllText(@"c:\e\a1_sites\100\Kreatewebsites.com\appblock\inc7\ad728.ad");
                adscript = System.IO.File.ReadAllText(@"c:\e\a3_kreate\Kreatewebsites.com\ad\inc7\ad728.ad");
                break;
            case 8:
                // adscript = System.IO.File.ReadAllText(@"c:\e\a1_sites\100\Kreatewebsites.com\appblock\inc8\ad728.ad");
                adscript = System.IO.File.ReadAllText(@"c:\e\a3_kreate\Kreatewebsites.com\ad\inc8\ad728.ad");
                break;

            case 9:
                // adscript = System.IO.File.ReadAllText(@"c:\e\a1_sites\100\Kreatewebsites.com\appblock\inc9\ad728.ad");
                adscript = System.IO.File.ReadAllText(@"c:\e\a3_kreate\Kreatewebsites.com\ad\inc9\ad728.ad");
                break;

            default:
                // adscript = System.IO.File.ReadAllText(@"c:\e\a1_sites\100\Kreatewebsites.com\appblock\inc\ad728.ad");
                adscript = System.IO.File.ReadAllText(@"c:\e\a3_kreate\Kreatewebsites.com\ad\inc\ad728.ad");
                break;
        }

        ad.Text = adscript;
    }
}