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
    protected string statename = Global.StateName;
    protected string city = Global.City;

    protected string category = Global.Category;
    protected string subcategory = Global.SubCategory;
    string name = null;
    protected Int16 count = 100;
    protected string list;
  

  
    protected string placename = Global.Country;
    protected string placetype = "Best Parlors";
    protected string slidename = null;
    protected string slidestr = null;



    protected string filename = "no.inc";
    protected string filename2 = "articles\\no.htm";

    protected string slide = "city.jpg";

    

    protected void Page_Load(object sender, EventArgs e)
    {

    //    topheader.Text = Global.Sitename.ToString().Trim();
     //   topheader.NavigateUrl = Global.Siteurl.ToString().Trim();

        GetVariables();
        GetSlide();
        GetData();
        GetMetaData();
      

    
        lblTitle.Text = Page.Title;
        topheader.Text = Page.Title;
       
       
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


        if (Request.QueryString["placename"] != null)
        {

           placename = Request.QueryString["placename"];
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
        DataTable dt;
        
      
      //  dt = KreateWebsites.Places.GetCities(continent, null, country, state, city, 4, 3);  //3 for rank
       dt = KreateWebsites.Places.GetCities(continent, null, country, state, city, count, 3);
       

       
        
        if (dt.Rows.Count > 0)
        {

            dt.Columns.Add("placeurl", typeof(String));
            dt.Columns.Add("cityurl", typeof(String));
            dt.Columns.Add("stateurl", typeof(String));
            dt.Columns.Add("countryurl", typeof(String));

            for (int i = 0; i < dt.Rows.Count; i++)
            {
            //    string url = dt.Rows[i]["biz_name"].ToString().Trim();
                //   KreateWebsites.Generate.ReplaceStr(ref url, ' ', '-');


            /*    dt.Rows[i]["countryurl"] = Global.Siteurl.ToString() + dt.Rows[i]["country"].ToString().Trim() + @"/";
                dt.Rows[i]["stateurl"] = dt.Rows[i]["countryurl"] + dt.Rows[i]["region"].ToString().Trim() + @"/";
                dt.Rows[i]["cityurl"] = dt.Rows[i]["stateurl"] + dt.Rows[i]["city"].ToString().Trim() + @"/"; 
             */
                dt.Rows[i]["stateurl"] = Global.Siteurl.ToString().Trim() + dt.Rows[i]["region"].ToString().Trim() + @"/";
           //       dt.Rows[i]["cityurl"] = Global.Siteurl.ToString().Trim()  + dt.Rows[i]["city"].ToString().Trim() + @"/" ;
                dt.Rows[i]["cityurl"] = Global.Siteurl.ToString().Trim() + "tourist-attractions.aspx?city=" + dt.Rows[i]["city"].ToString().Trim() + "&state=" + dt.Rows[i]["region"].ToString().Trim() ;
               
            }

            if (dt.Rows.Count > 0)
            {
                RepDetails.DataSource = dt;
                RepDetails.DataBind();

            
            }
       

        }












       

       
    }

    private void GetMetaData()
    {
        if (name != null)
            Page.Title = "Top Cities of " + name + " | " + list;
        else
            Page.Title = "Top Cities of " + Global.Country;
    }

    private void GetSlide()
    {

        string imageurl ;

    //    imageurl = Global.SlidePath + "Beauty-Parlors.jpg" ;
    //     imgMainImage.ImageUrl = imageurl;
       

    }
}
