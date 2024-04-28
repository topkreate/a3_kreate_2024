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
using System.Data.Sql;
using System.Data.SqlClient;


public partial class masterControl : System.Web.UI.UserControl
{

    protected string country = Global.Country;
    protected string state = "all";
    protected string city = "all";
    protected string category = "all";
    protected string subcategory = "all";
    protected Int16 count = 15;
    protected string placename = "";

    protected string placetype = "cities";
    protected string filename = "no.inc";
    protected string filename2 = "articles\\no.htm";

    protected string slidename = "city";
    protected string slide = "city.jpg";

    protected string slidestr = null;


    protected void Page_Load(object sender, EventArgs e)
    {
        country = Global.Country;
        state = Global.State;
        city = Global.City;
        slidename = country;
        placename = country;


        slides();
        GetFeatured();
        Getcities();
        // Getplaces();
        Page.DataBind();

        // placename = Global.FeaturedCountry.ToString();
        Page.Title = Global.Sitename.ToString() + " | Best city trips in " + placename;
        // Page.Response.Write("usa");


        HtmlMeta tag = new HtmlMeta();
        tag.Name = "description";
        tag.Content = Page.Title + " " + Global.Sitename.ToString() + " has list of best cities, attractions for tour in " + placename;
        Header.Controls.Add(tag);


    }

    private void slides()
    {

        slidename = slidename.ToLower();
        slide = "http://pictures.USACityTrip.info/banner/" + slidename + ".jpg";
        slidestr = "<img src='" + slide + "' width='568' height='191' alt='image slide of " + slidename + "' />";


    }

    private void featuredCountry()
    {


    }

    private void Getcities()
    {

        string sp = "cities_search";


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
                cmd.Parameters.AddWithValue("@Region", state);
                cmd.Parameters.AddWithValue("@n", 4);
                cmd.Parameters.AddWithValue("@SortOrder", 3);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                da.Fill(ds);

                DataTable dt = ds.Tables[0];
                RepDetails.DataSource = dt;
                RepDetails.DataBind();





                //  conn.Open();

                //    cmd.ExecuteNonQuery();



            }
        }
    }

    private void Getplaces()
    {

        string sp = "tourist_places_Comma_list";


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
                cmd.Parameters.AddWithValue("@n", 10);
                cmd.Parameters.AddWithValue("@SortOrder", 1);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                da.Fill(ds);

                DataTable dt = ds.Tables[0];

                /*         labelHeader.Text = "25 best attractions in " + placename;
                         if (dt.Rows.Count > 0)
                         {

                             labelPlaces.Text = dt.Rows[0]["CommaDelimitedList"].ToString();

                         }

                         else
                         {

                             labelPlaces.Text = "No data returned";

                         }

                         HyperLinkMore.Text = "More Attractions to see";
                         if (placename == Global.Country)
                         {
                             HyperLinkMore.NavigateUrl = "http://www.vancouver-bc.biz/attractions.aspx";
                         }
                         else
                         {
                             HyperLinkMore.NavigateUrl = "http://www.vancouver-bc.biz/attractions.aspx?name=" + placename;
                         }


                         Label11.Text = "10 Best cities of ";
                         HyperLink11.Text = placename;

                         if (placename == "World")
                         {
                             HyperLink11.NavigateUrl = "http://www.vancouver-bc.biz/city.aspx";
                         }
                         else
                         {
                             HyperLink11.NavigateUrl = "http://www.vancouver-bc.biz/city.aspx?name=" + placename;
                         }
                         */
                //  conn.Open();

                //    cmd.ExecuteNonQuery();



            }
        }
    }

    private void GetFeatured()
    {


        Labeltitle.Text = Page.Title;
        /*     HyperLink1.Text = "Featured : " + Global.Featured.ToString();

             if (placename == "World")
             {
                 HyperLink1.NavigateUrl = "http://www.vancouver-bc.biz/cities.aspx";
             }
             else
             {
                 HyperLink1.NavigateUrl = "http://www.vancouver-bc.biz/cities.aspx?name=" + Global.Featured.ToString();
             }

          */


    }



    private void GetplacesRepeater()
    {


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
