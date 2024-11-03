using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Connect
/// </summary>
public class Util
{

    public static void SetPhotoViewer(int id)
    {
       // Response.Write("ID receive is " + id.ToString());
        switch (id)
        {
            case 0:

                Global.Gallery.photoviewer = "photoviewer.php";
                // Jun 2024
                Global.Gallery.photoviewer = "image.html";
                break;
            case 1:
                Global.Gallery.photoviewer = "picturesalbum.php";
                // Jun 2024
                Global.Gallery.photoviewer = "image.html";
                break;
            case 2:

                Global.Gallery.photoviewer = "imagegallery.php";
                // Jun 2024
                Global.Gallery.photoviewer = "image.html";
                break;

            case 3:

                Global.Gallery.photoviewer = "photoviewer.php";
                // Jun 2024
                Global.Gallery.photoviewer = "image.html";
                break;
            default:

                Global.Gallery.photoviewer = "photoviewer.php";
                // Jun 2024
                Global.Gallery.photoviewer = "image.html";
                break;
        }


    }
}
