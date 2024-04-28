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

public partial class featured : System.Web.UI.UserControl
{
    protected string continent = Global.Continent;
    protected string country = Global.Country;
    protected string state = Global.State;
    protected string statename = Global.StateName.ToString();
    protected string city = Global.City;
    protected string category = Global.Category.ToString();
    protected string thumbnail_path = Global.thumbnailpath.ToString();
    protected string ImagePath = Global.ImagePath.ToString();
    protected string url = " ";
    protected string name = " ";

    protected int year;
    protected int count = 5;



    protected string subfolder;
    protected int pictureid = 0;

    protected string local_path;
    protected string navigate_path;
    protected string pic_path;
    protected string output_path;

    protected void Page_Load(object sender, EventArgs e)
    {
        GetVariables();
        GetData();
    }

    private void GetVariables()
    {


        DateTime moment = DateTime.Now;


        // Year gets 1999. 
       int  year = moment.Year;

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

        if (Request.QueryString["id"] != null)
        {
            pictureid = Convert.ToInt32(Request.QueryString["id"]);

        }

        if (Request.QueryString["continent"] != null)
        {
            continent = Request.QueryString["continent"];

        }

        if (Request.QueryString["country"] != null)
        {
            country = Request.QueryString["country"];

        }

        if (Request.QueryString["state"] != null)
        {
            state = Request.QueryString["state"];

        }

        if (Request.QueryString["statename"] != null)
        {
            statename = Request.QueryString["statename"];

        }

        if (Request.QueryString["city"] != null)
        {
            city = Request.QueryString["city"];

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
        if (Request.QueryString["subfolder"] != null)
        {
            subfolder = Request.QueryString["subfolder"];
        }

        if (Request.QueryString["local_path"] != null)
        {
            local_path = Request.QueryString["local_path"];
        }
        if (Request.QueryString["pic_path"] != null)
        {
            pic_path = Request.QueryString["pic_path"];
        }
        if (Request.QueryString["navigate_path"] != null)
        {
            navigate_path = Request.QueryString["navigate_path"];
        }

        if (Request.QueryString["output_path"] != null)
        {
            output_path = Request.QueryString["output_path"];
        }

    }

    private void GetData()
    {


        string sp = "cities_search_v2";



        // string connect = @"SERVER=yellpproduct.db.5284911.hostedresource.com;Database=yellpproduct;UID=yellpproduct;PWD=Dhingra732!@;Trusted_Connection=False;";
        string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;

        //   string connect = "<%$ ConnectionStrings:films %>" ;
        //     ConnectionString="<%$ ConnectionStrings:films %>"
        using (SqlConnection conn = new SqlConnection(connect))
        {

            using (SqlCommand cmd = new SqlCommand(sp, conn))
            {

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Continent", continent);
                cmd.Parameters.AddWithValue("@Country", country);
                cmd.Parameters.AddWithValue("@Region", statename);
                cmd.Parameters.AddWithValue("@n", count);
                cmd.Parameters.AddWithValue("@SortOrder", 3);

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