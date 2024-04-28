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
    protected string placetype = "cities";
    protected string filename = "no.inc";
    protected string filename2 = "articles\\no.htm";

    protected string slide = "city.jpg";
    protected string placename = "";
    protected string slidestr = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        placename = Request.QueryString["name"];
       // placename = Global.FeaturedCountry.ToString();
        Page.Title = "4 Best cities to tour in " + placename;
        // Page.Response.Write("usa");


        HtmlMeta tag = new HtmlMeta();
        tag.Name = "description";
        tag.Content = Page.Title + " " + Global.Sitename.ToString() + " has list of best attractions, cities for tour in " + placename   ;
        Header.Controls.Add(tag);

        slides();
        Getcities();
        Getplaces();
        Page.DataBind();
    }

    private void slides()
    {

        slide =  "http://pictures.uscitytrip.net/banner/" + placename + ".jpg";
   
        slidestr = "<img src='" + slide + "' width='1200' height='265' alt='image slide of " + placename + "' />";




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

                cmd.Parameters.AddWithValue("@Country", Global.Country);
                cmd.Parameters.AddWithValue("@Region", placename);
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

                cmd.Parameters.AddWithValue("@Country", Global.Country);
                cmd.Parameters.AddWithValue("@State", placename);
                cmd.Parameters.AddWithValue("@n", 10);
                cmd.Parameters.AddWithValue("@SortOrder", 1);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                da.Fill(ds);

                DataTable dt = ds.Tables[0];

                labelHeader.Text = "25 best attractions in " + placename;
                if (dt.Rows.Count > 0)
                {

                    labelPlaces.Text = dt.Rows[0]["CommaDelimitedList"].ToString();

                }

                else
                {

                    labelPlaces.Text = "No data returned";

                }

                HyperLink3.Text = "More";
                if (placename == Global.Country)
                {
                    HyperLink3.NavigateUrl = "http://www.uscitytrip.net/attractions.aspx";
                }
                else
                {
                    HyperLink3.NavigateUrl = "http://www.uscitytrip.net/attractions.aspx?name=" + placename;
                }










                Label11.Text = "10 Best cities";
                HyperLink11.Text = placename + " | Enchanting India";

                if (placename == "World")
                {
                    HyperLink11.NavigateUrl = "http://www.uscitytrip.net/cities.aspx";
                }
                else
                {
                    HyperLink11.NavigateUrl = "http://www.uscitytrip.net/cities.aspx?name=" + placename;
                }

                //  conn.Open();

                //    cmd.ExecuteNonQuery();



            }
        }
    }
}
