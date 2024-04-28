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

public partial class Default : BasePage
{
    protected string country = Global.Country;
    protected string state = "all";
    protected string city = "all";
    protected string category = "all";
    protected string subcategory = "all";
    protected Int16 count = 100;
    protected string filename = "no.inc";
    protected string filename2 = "articles\\no.htm";

    protected string slide = "city.jpg";
    protected string placename = Global.Country;
    protected string placetype = "Best Attractions";
    protected string slidename = Global.Country;
    protected string slidestr = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        country = Global.Country;
        state = Global.State;
        placename = country;
        slidename = country;

        if (Request.QueryString["state"] != null)
        {
            state = Request.QueryString["state"];   
            placename = state + " " + placename;     
            slidename = state;                     
            count = 50;
        }
        if (Request.QueryString["city"] != null)
        {
            city = Request.QueryString["city"];   // to pass in store proc
            placename = city + " " + placename;  // to use in title, description
            slidename = city;   //to show slide
            count = 15;
        }

       

        if (Request.QueryString["category"] != null)
        {
            category = Request.QueryString["category"];
            placetype = category;
            count = 10;
           
        }

        if (Request.QueryString["subcategory"] != null)
        {
            subcategory = Request.QueryString["subcategory"];
            placetype = placetype + " & ";

        }
        

        
       // placename = Global.FeaturedCountry.ToString();
        Page.Title = placetype + " to see in " +  placename;
        // Page.Response.Write("usa");


        HtmlMeta tag = new HtmlMeta();
        tag.Name = "description";
        tag.Content = Page.Title + " " + Global.Sitename.ToString() + " has list of " + placetype  + " to see in"  + placename   ;
        Header.Controls.Add(tag);

        slides();
       // Getcities();
        //Getplaces();
        GetplacesRepeater();
        Page.DataBind();
    }

    private void slides()
    {

        slide =  "http://pictures.uscitytrip.net/banner/" + slidename + ".jpg";
      
        slidestr = "<img src='" + slide + "' width='1200' height='265' alt='image slide of " + slidename + "' />";

        Label1.Text = Page.Title;


    }

    private void featuredCountry()
    {

        
    }

    

   

    private void GetplacesRepeater()
    {

        labeltitle.Text = Page.Title;
        string sp = "best_tourist_places_search";



        // string connect = @"SERVER=yellpproduct.db.5284911.hostedresource.com;Database=yellpproduct;UID=yellpproduct;PWD=Dhingra732!@;Trusted_Connection=False;";
        string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;

        //   string connect = "<%$ ConnectionStrings:films %>" ;
        //     ConnectionString="<%$ ConnectionStrings:films %>"
        using (SqlConnection conn = new SqlConnection(connect))
        {

            using (SqlCommand cmd = new SqlCommand(sp, conn))
            {

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Country", country);
                cmd.Parameters.AddWithValue("@State", state);
                cmd.Parameters.AddWithValue("@city", city);
                cmd.Parameters.AddWithValue("@Category", category);
                cmd.Parameters.AddWithValue("@SubCategory", subcategory);
                cmd.Parameters.AddWithValue("@n", count);
                cmd.Parameters.AddWithValue("@SortOrder", 1);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                da.Fill(ds);


                DataTable dt = ds.Tables[0];

                if (dt.Rows.Count > 0)
                {

                    RepDetails.DataSource = dt;
                    RepDetails.DataBind();
                }



                

                //  conn.Open();

                //    cmd.ExecuteNonQuery();



            }
        }
    }
}
