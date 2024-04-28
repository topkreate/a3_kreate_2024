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

    protected string continent = Global.Continent;
    protected string country = Global.Country;
    protected string state = Global.State;
    protected string statename = Global.StateName.ToString();
    protected string city = Global.City;

    protected string category = Global.Category;
    protected string subcategory = Global.SubCategory;
    string name = null;
    protected Int16 count = 100;
  

  
    protected string placename = Global.Country;
    protected string placetype = "Best Parlors";
    protected string slidename = null;
    protected string slidestr = null;



    protected string filename = "no.inc";
    protected string filename2 = "articles\\no.htm";

    protected string slide = "city.jpg";

    protected DataTable dt;
    

    protected void Page_Load(object sender, EventArgs e)
    {

        topheader.Text = Global.Sitename.ToString().Trim();
        topheader.NavigateUrl = Global.Siteurl.ToString().Trim();

        GetVariables();
        GetSlide();
        GetData();
        GetMetaData();
      

    
        lblTitle.Text = Page.Title;
       
       
    }


    protected void GetVariables()
    {





        if (Request.QueryString["continent"] != null)
        {
            continent = Request.QueryString["continent"];
            name = continent;

            count = 25;
        }

        if (Request.QueryString["country"] != null)
        {
            country = Request.QueryString["country"];
            name = country;

            count = 1;
        }


        if (Request.QueryString["state"] != null)
        {
            state = Request.QueryString["state"];
            name = state;
            count = 1;
        }

        if (Request.QueryString["statename"] != null)
        {
            statename = Request.QueryString["statename"];
            name = statename;
            count = 1;

        }

        if (Request.QueryString["city"] != null)
        {

            city = Request.QueryString["city"];
            name = city;
            count = 1;
        }


        if (Request.QueryString["count"] != null)
        {

            count = Convert.ToInt16(Request.QueryString["count"]);

        }


        if (Request.QueryString["name"] != null)
        {

           placename = Request.QueryString["name"];
           name = placename;
            count = 1;
        }


        //   if (placename == null)
        //     placename = Global.Country;




        if (Request.QueryString["category"] != null)
        {
            category = Request.QueryString["category"];
        }


        if (Request.QueryString["subcategory"] != null)
        {
            subcategory = Request.QueryString["subcategory"];
        }
    }

    private void GetData()
    {
        
       // Response.Write("name = " + placename + "<br/>");
        dt = KreateWebsites.BeautyParlors.GetData(country, state, statename, city, category, subcategory, placename, count, 1, 1, 1);


        if (dt.Rows.Count > 0)
        {
          //  Response.Write("count = " + dt.Rows.Count.ToString() + "<br/>");
           
            heading2.Text = dt.Rows[0]["name"].ToString() + "<br/>";
            heading3.Text = "Address " + dt.Rows[0]["Address"].ToString() + "<br/>";
            lblDescription.Text = dt.Rows[0]["city"].ToString()  + " "  + dt.Rows[0]["Phone Number"].ToString()  + "<br/>" ;
            
        }

       
    }

    private void GetMetaData()
    {
        if (name != null)
            Page.Title = "What is address of " +  placename + " beauty parlor in " + dt.Rows[0]["city"]     ;
        else
            Page.Title = "Beauty Parlor";
    }

    private void GetSlide()
    {

        string imageurl ;

        imageurl = Global.SlidePath + "Beauty-Parlors.jpg" ;
         imgMainImage.ImageUrl = imageurl;
       

    }
}
