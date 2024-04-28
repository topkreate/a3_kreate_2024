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


public partial class Default : BasePage
{

    protected string country = Global.Country;
    protected string state = "all";
    protected string city = "all";
    protected string category = "all";
    protected string subcategory = "all";
    protected Int16 count = 100;
  

  
    protected string placename = Global.Country;
    protected string placetype = "Best Attractions";
    protected string slidename = null;
    protected string slidestr = null;



    protected string filename = "no.inc";
    protected string filename2 = "articles\\no.htm";

    protected string slide = "city.jpg";

    

    protected void Page_Load(object sender, EventArgs e)
    {
       
       
        /*
        slides();
        GetFeatured();
        Getcities();
        Getplaces();
        Page.DataBind();
         * */
    }

    private void slides()
    {
        
        if (File.Exists(LocalPath.ImagePath + slidename + ".jpg"))
        {
            //      slidename = name;
        }
        else
            slidename = Global.Country;

        slide = Global.SlidePath + slidename + ".jpg";

     //   slide =  "http://pictures.uscitytrip.net/banner/" + slidename + ".jpg";
        slidestr = "<img src='" + slide + "' width='1200' height='265' alt='image slide of " + slidename +  "' />";




    }

    private void featuredCountry()
    {

        
    }

    private void Getcities()
    {

       

              

    }

    private void Getplaces()
    {

      


    }

    private void GetFeatured()
    {





     }
        
    

}
