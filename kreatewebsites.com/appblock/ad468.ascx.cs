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
                adscript = System.IO.File.ReadAllText(@"c:\e\a1_sites\100\Kreatewebsites.com\appblock\inc0\ad468.ad");
                break;
            case 1:
                adscript = System.IO.File.ReadAllText(@"c:\e\a1_sites\100\Kreatewebsites.com\appblock\inc\ad468.ad");
                break;
            case 2:
                adscript = System.IO.File.ReadAllText(@"c:\e\a1_sites\100\Kreatewebsites.com\appblock\inc2\ad468.ad");
                break;

            case 3:
                adscript = System.IO.File.ReadAllText(@"c:\e\a1_sites\100\Kreatewebsites.com\appblock\inc3\ad468.ad");
                break;


                break;
            case 4:
                adscript = System.IO.File.ReadAllText(@"c:\e\a1_sites\100\Kreatewebsites.com\appblock\inc4\ad468.ad");
                break;
            case 5:
                adscript = System.IO.File.ReadAllText(@"c:\e\a1_sites\100\Kreatewebsites.com\appblock\inc5\ad468.ad");
                break;

            case 6:
                adscript = System.IO.File.ReadAllText(@"c:\e\a1_sites\100\Kreatewebsites.com\appblock\inc6\ad468.ad");
                break;


                break;
            case 7:
                adscript = System.IO.File.ReadAllText(@"c:\e\a1_sites\100\Kreatewebsites.com\appblock\inc7\ad468.ad");
                break;
            case 8:
                adscript = System.IO.File.ReadAllText(@"c:\e\a1_sites\100\Kreatewebsites.com\appblock\inc8\ad468.ad");
                break;

            case 9:
                adscript = System.IO.File.ReadAllText(@"c:\e\a1_sites\100\Kreatewebsites.com\appblock\inc9\ad468.ad");
                break;


            default:
                adscript = System.IO.File.ReadAllText(@"c:\e\a1_sites\100\Kreatewebsites.com\appblock\inc\ad468.ad");
                break;
        }

        ad.Text = adscript;
    }
}