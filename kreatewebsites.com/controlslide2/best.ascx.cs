using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Control_Homeright : System.Web.UI.UserControl
{
    protected String itemstovisit = Global.Country;
    protected string continent = Global.Continent;
    protected string country = Global.Country;
    protected string state = Global.State;
    protected string statename = Global.StateName;
    protected string city = Global.City;
    protected string category = Global.Category;
    protected string subcategory = Global.SubCategory;
    protected string placename = Global.Placename;
    protected int count = 1000;
    protected int sortOrder;

    static DataTable GetTable()
    {


        DataTable table = new DataTable();
        try
        {





            table.Columns.Add("id", typeof(int));
            table.Columns.Add("imageurl", typeof(string));
            table.Columns.Add("link", typeof(string));
            table.Columns.Add("name", typeof(string));
            table.Columns.Add("title", typeof(string));
            table.Columns.Add("text", typeof(string));
            table.Columns.Add("continent", typeof(string));
            table.Columns.Add("country", typeof(string));
            table.Columns.Add("state", typeof(string));
            table.Columns.Add("statename", typeof(string));
            table.Columns.Add("city", typeof(string));
            table.Columns.Add("category", typeof(string));
            table.Columns.Add("subcategory", typeof(string));
          




        }
        catch (Exception e)
        {
            // Response.Write("Exception is : " + e.Message);
        }


        return table;



    }
    protected void Page_Load(object sender, EventArgs e)
    {
        

        int id;
        string imageurl, name, title;
        string text = " " ;
        string link = Global.Siteurl;
        id = 1;





        

      


        DataTable dt = getslide();


      if (Request.QueryString["count"] != null)
      {
          count = Convert.ToInt32(Request.QueryString["count"]);
      }


      



        if (dt.Rows.Count > 0)
        {
            RepeaterSlide.DataSource = dt;
            RepeaterSlide.DataBind();
        }

    }


    protected DataTable getslide()
    {
        DataTable dt = GetTable();

        int id;
        string imageurl, name, title;
        string text = " ";
        string link = Global.Siteurl;
        id = 1;
  

        
        if (!string.IsNullOrEmpty(placename) )
        {
            
            itemstovisit = placename;

            imageurl = Global.Slides.defaultpath + itemstovisit + ".jpg";
            name = itemstovisit;

            title =  itemstovisit;

            dt.Rows.Add(id, imageurl, link, name, title, text, continent, country, state, statename, city, category, subcategory);
            return dt;
        }

        if (!string.IsNullOrEmpty(city) )
        {

            itemstovisit = city;
            imageurl = Global.Slides.defaultpath + itemstovisit + ".jpg";
            name = itemstovisit;

            title = itemstovisit;

            dt.Rows.Add(id, imageurl, link, name, title, text, continent, country, state, statename, city, category, subcategory);
            return dt;

           
        }
        if (!string.IsNullOrEmpty(state) )
        {

            itemstovisit = state;
            imageurl = Global.Slides.defaultpath + itemstovisit + ".jpg";
            name = itemstovisit;

            title = itemstovisit;

            dt.Rows.Add(id, imageurl, link, name, title, text, continent, country, state, statename, city, category, subcategory);
            return dt;


        }

        if (!string.IsNullOrEmpty(statename) )
        {

            itemstovisit = statename;
            imageurl = Global.Slides.defaultpath + itemstovisit + ".jpg";
            name = itemstovisit;

            title = itemstovisit;

            dt.Rows.Add(id, imageurl, link, name, title, text, continent, country, state, statename, city, category, subcategory);
            return dt;


        }


        if (!string.IsNullOrEmpty(country) )
        {

            itemstovisit = country;
            imageurl = Global.Slides.defaultpath + itemstovisit + ".jpg";
            name = itemstovisit;

            title = itemstovisit;

            dt.Rows.Add(id, imageurl, link, name, title, text, continent, country, state, statename, city, category, subcategory);
            return dt;


        }

        if (!string.IsNullOrEmpty(continent) )
        {

            itemstovisit = continent;
            imageurl = Global.Slides.defaultpath + itemstovisit + ".jpg";
            name = itemstovisit;

            title = itemstovisit;

            dt.Rows.Add(id, imageurl, link, name, title, text, continent, country, state, statename, city, category, subcategory);
            return dt;


        }

        if (Request.QueryString["name"] != null)
        {
            placename = Request.QueryString["name"];
            itemstovisit = placename;

            imageurl = Global.Slides.defaultpath + Request.QueryString["name"].ToString().Trim() + ".jpg";
            name = Request.QueryString["name"];

            title = "About " + name;

            dt.Rows.Add(id, imageurl, link, name, title, text, continent, country, state, statename, city, category, subcategory);
            return dt;
        }


        if (Request.QueryString["city"] != null)
        {
            city = Request.QueryString["city"];
            itemstovisit = statename;

            imageurl = Global.Slides.defaultpath + Request.QueryString["City"] + ".jpg";
            name = Request.QueryString["City"];
            //    link = Global.Siteurl + Request.QueryString["Country"].ToString().Trim() + @"/" + Request.QueryString["state"].ToString().Trim() + @"/" + Request.QueryString["city"].ToString().Trim() + @"/"; 
            link = Global.Siteurl + Request.QueryString["Country"] + @"/" + Request.QueryString["state"] + @"/" + Request.QueryString["city"] + @"/";
            title = "What to see in  " + name;

            dt.Rows.Add(id, imageurl, link, name, title, text, continent, country, state, statename, city, category, subcategory);
            return dt;
        }
        if (Request.QueryString["state"] != null)
        {
            state = Request.QueryString["state"];
            itemstovisit = state;


            imageurl = Global.Slides.defaultpath + Request.QueryString["State"] + ".jpg";
            name = Request.QueryString["State"];
            link = Global.Siteurl + Request.QueryString["Country"].ToString().Trim() + @"/" + Request.QueryString["state"].ToString().Trim() + @"/";

            title = "Places to see in " + name;

            dt.Rows.Add(id, imageurl, link, name, title, text, continent, country, state, statename, city, category, subcategory);
            return dt;
        }
        if (Request.QueryString["statename"] != null)
        {
            statename = Request.QueryString["statename"];
            itemstovisit = statename;

            imageurl = Global.Slides.defaultpath + Request.QueryString["statename"] + ".jpg";
            name = Request.QueryString["statename"];

            title = "Places & atractions to see in " + name;
            link = Global.Siteurl + Request.QueryString["Country"].ToString().Trim() + @"/" + Request.QueryString["statename"].ToString().Trim() + @"/";

            dt.Rows.Add(id, imageurl, link, name, title, text, continent, country, state, statename, city, category, subcategory);
            return dt;
        }


        if  (Request.QueryString["country"] != null) 
        {
            country = Request.QueryString["country"];
            itemstovisit = country;

            imageurl = Global.Slides.defaultpath + Request.QueryString["Country"] + ".jpg";
            name = Request.QueryString["country"];

            title = "Best Places to see in " + name;
            link = Global.Siteurl + Request.QueryString["Country"].ToString().Trim() + @"/";

            dt.Rows.Add(id, imageurl, link, name, title, text, continent, country, state, statename, city, category, subcategory);
            return dt;
        }

        if (Request.QueryString["continent"] != null)
        {
            continent = Request.QueryString["continent"];
            itemstovisit = continent;

            imageurl = Global.Slides.defaultpath + Request.QueryString["Continent"] + ".jpg";
            name = Request.QueryString["continent"];

            title = "1000 Places to see in " + name;
            link = Global.Siteurl + Request.QueryString["Continent"].ToString().Trim() + @"/";

            dt.Rows.Add(id, imageurl, link, name, title, text, continent, country, state, statename, city, category, subcategory);
            return dt;
        }






        imageurl = Global.Slides.defaultpath + "World" + ".jpg";
        link = Global.Siteurl + "1000.aspx";
        dt.Rows.Add(id, imageurl, link, "1000 Places to see in World", "1000 Places to see in world", text, null, null, null, null, null, null, null);

        return dt;
     






    }

    
}