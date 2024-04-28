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

public partial class whenis : BasePage
{


    protected string festival = Global.Festival.ToString();
    protected string country = Global.Country.ToString();
    protected string state = Global.State.ToString();
    protected string category = Global.Category.ToString();
    protected int year;
    protected int count = 1;

    protected void Page_Load(object sender, EventArgs e)
    {
        GetVariables();
        GetData();
       GetLinks();

    //   image1.AlternateText = "slide of " + festival.ToString();
    //   image1.ImageUrl = "https://pictures.happy-new-year.org/slide31/" + festival.ToString() + ".jpg";

       // GetFestivalList();
        lbltitle.Text = "Date of " + festival.ToString();
        hyperlink2.Text = "On what day is " + festival.ToString();
        hyperlink2.NavigateUrl = Global.Siteurl + LocalPath.Datefolder + @"\" + festival + @"\" + year + ".html";

        lblLinks.Text = festival + " dates in " + year ;
        Page.Title = "Date of " + festival + " in Year " +  year.ToString() + " -" +  Global.list.ToString();
        HtmlMeta tag = new HtmlMeta();
        tag.Name = "description";
        tag.Content = Page.Title + " . " +  Global.list.ToString() + " is date of "  + festival + " in year" + year +  " .See full calendar, festival, holidays of each year. ";
        Header.Controls.Add(tag);
    }

    private void GetVariables()
    {


        DateTime moment = DateTime.Now;


        // Year gets 1999. 
        year = moment.Year;

        // Month gets 1 (January). 
        int month = moment.Month;

        // Day gets 13. 
        int day = moment.Day;

        // Hour gets 3. 
        int hour = moment.Hour;

        // Minute gets 57. 
        int minute = moment.Minute;

        // Second gets 32. 
        int second = moment.Second;

        // Millisecond gets 11. 
        int millisecond = moment.Millisecond;

        if (Request.QueryString["festival"] != null)
        {
            festival = Request.QueryString["festival"];

        }

        if (Request.QueryString["country"] != null)
        {
            country = Request.QueryString["country"];

        }

        if (Request.QueryString["state"] != null)
        {
            festival = Request.QueryString["state"];

        }

        if (Request.QueryString["year"] != null)
        {
            year = Convert.ToInt16(Request.QueryString["year"]);

        }

        if (Request.QueryString["category"] != null)
        {
            category = Request.QueryString["category"];

        }

        if (Request.QueryString["count"] != null)
        {
            count = Convert.ToInt16(Request.QueryString["count"]);
        }

        if (Request.QueryString["country"] != null)
        {
            country = Request.QueryString["country"];
        }

    }
    private void GetData()
    {


        string sp = "festival_search";


        string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;


        using (SqlConnection conn = new SqlConnection(connect))
        {

            using (SqlCommand cmd = new SqlCommand(sp, conn))
            {

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@year", year);
                cmd.Parameters.AddWithValue("@festival", festival);
                cmd.Parameters.AddWithValue("@category", category);
                cmd.Parameters.AddWithValue("@country", country);


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

                    /*string val;
                    val = DateTime.Now.ToShortTimeString();*/

                 
                       
              

                        Global.list = dt.Rows[0]["event_date"].ToString();
                        Global.list = Global.list.Substring(0, 10);

                    }
                   


                }
                 



            }
        }

    private void GetLinks()
    {


        string sp = "festival_search";


        string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;


        using (SqlConnection conn = new SqlConnection(connect))
        {

            using (SqlCommand cmd = new SqlCommand(sp, conn))
            {

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@year", year);
                cmd.Parameters.AddWithValue("@festival", festival);
                cmd.Parameters.AddWithValue("@category", category);
                cmd.Parameters.AddWithValue("@country", country);


                cmd.Parameters.AddWithValue("@n", 5);
                cmd.Parameters.AddWithValue("@SortOrder", 1);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                da.Fill(ds);


                DataTable dt = ds.Tables[0];



                if (dt.Rows.Count > 0)
                {

                    RepLinks.DataSource = dt;
                    RepLinks.DataBind();

                    /*string val;
                    val = DateTime.Now.ToShortTimeString();*/




                }



            }




        }
    }

    public void GetFestivalList()
    {

        //  DateTime startdate = DateTime.Today;
        DateTime startdate = new DateTime(year, 1, 1);
        //   Response.Write("start date is " + Convert.ToString(startdate));
        DateTime enddate = startdate.AddDays(365);

        string sp = "festival_search_period";


        string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;


        using (SqlConnection conn = new SqlConnection(connect))
        {

            using (SqlCommand cmd = new SqlCommand(sp, conn))
            {

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@startdate", startdate);
                cmd.Parameters.AddWithValue("@enddate", enddate);
                cmd.Parameters.AddWithValue("@festival", "all");
                cmd.Parameters.AddWithValue("@category", "all");
                cmd.Parameters.AddWithValue("@country", "India");


                cmd.Parameters.AddWithValue("@n", 10);
                cmd.Parameters.AddWithValue("@SortOrder", 4);  // sort by date in asc

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                da.Fill(ds);


                DataTable dt = ds.Tables[0];
                RepLinks.DataSource = dt;
                RepLinks.DataBind();
                /*

                if (dt.Rows.Count > 0)
                {

                    RepDetails.DataSource = dt;
                    RepDetails.DataBind();

                    int i = 0;
                    for (i = 0; i < dt.Rows.Count - 1; i++)
                    {

                        Global.list = Global.list + dt.Rows[i]["festival"].ToString() + ",";

                    }
                    Global.list = Global.list + dt.Rows[i]["festival"].ToString() + ".";


                }
                 */



            }
        }
    }
    
}
