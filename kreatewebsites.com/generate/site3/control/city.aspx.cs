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
        Page.Title = "Best attractions in city " + placename;
        // Page.Response.Write("usa");


        HtmlMeta tag = new HtmlMeta();
        tag.Name = "description";
        tag.Content = Page.Title + " " + Global.Sitename.ToString() + " has list of best attractions to see in" + placename + ". Use this city guide on " + placename + " tour";
        Header.Controls.Add(tag);

        slides();
       // Getcities();
        //Getplaces();
        GetplacesRepeater();
        Page.DataBind();
    }

    private void slides()
    {

        slide =  "http://pictures.enchantingindia.org/banner/" + placename + ".jpg";
       
        slidestr = "<img src='" + slide + "' width='1200' height='265' alt='image slide of " + placename + "' />";

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

                cmd.Parameters.AddWithValue("@Country", Global.Country);
                cmd.Parameters.AddWithValue("@State", "all");
                cmd.Parameters.AddWithValue("@city", placename);
                cmd.Parameters.AddWithValue("@Category", "all");
                cmd.Parameters.AddWithValue("@SubCategory", "all");
                cmd.Parameters.AddWithValue("@n", 12);
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
