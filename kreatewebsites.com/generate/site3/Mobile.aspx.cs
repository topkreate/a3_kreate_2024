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
using System.Data;
using System.Data.SqlClient; 

public partial class Article : BasePage
{
    protected string continent = "Europe";
    protected string country = Global.Country;
    protected string state = "all";
    protected string statename = "all";
    protected string city = "all";
    protected string category = "tourist";
    protected string subcategory = "all";
    protected Int16 count = 10;
    protected string filename = "no.inc";
    protected string filename2 = "articles\\no.htm";


    protected string placename = "Asia";
    protected string placetype = "";
    protected string slidename = "city.jpg";
    protected string slidestr = null;
    protected string slide = null;

    protected string list = null;
    

    protected void Page_Load(object sender, EventArgs e)
    {
        
        GetData();
        slides();
        GetPageMetaData();

       
        // Page.Response.Write("usa");
      //  labeltitle.Text = Page.Title;

        HtmlMeta tag = new HtmlMeta();
        tag.Name = "description";
        tag.Content = Page.Title + " . Find listing of local business - " + list + " Click to see complete list ";
        Header.Controls.Add(tag);
    }

    private void slides()
    {



        slide = "http://pictures.yellp.mobi/banner/" + slidename + ".jpg";
        slide = slide.ToLower();
        slidestr = "<img src='" + slide + "' class='top blog-post-image' width='590'  height='240'  alt='medium size slide of " + slidename + "' />";

   //     Label1.Text = Page.Title;


    }


    private void GetData()
    {

       


    }

    private void GetPageMetaData()
    {

        Page.Title = "Mobiles";
     //   lblTitle.Text = Page.Title;

    }
}
