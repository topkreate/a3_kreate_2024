﻿using System;
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