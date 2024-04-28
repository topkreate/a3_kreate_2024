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

using System.IO;

public partial class Article : BasePage
{



    //  protected string festival = Global.Festival.ToString();
    protected string country = Global.Country.ToString();
    protected string state = Global.State.ToString();
    protected string category = Global.Category.ToString();
    protected string imageurl = "http://pictures.placetosee.net/places/defaultimg.jpg";
    protected string defaultimage = "http://pictures.beautifulsite.or/places/defaultimg.jpg";
    protected string ImagePath = Global.ImagePath.ToString();
    protected string thumbnail_path = Global.thumbnailpath.ToString();
    protected string imagename = " ";

    protected int year;
    protected int count = 3;

    protected string subfolder;
    protected int pictureid = 0;

    protected string local_path;
    protected string navigate_path;
    protected string pic_path;
    protected string output_path;

    protected string articlefile;



    string name;

    protected string slide = "city.jpg";
    protected string slidename = "";
    protected string slidestr = null;


    protected void Page_Load(object sender, EventArgs e)
    {
        
    }






}
