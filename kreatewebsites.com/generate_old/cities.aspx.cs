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
    protected string placetype = "country";
    protected string filename = "no.inc";
    protected string filename2 = "articles\\no.htm";

    protected string slide = "city.jpg";
    protected string placename = Global.Country;
    protected string slidestr = null;
    protected string state = "all";

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.QueryString["region"] != null)
        {
            state = Request.QueryString["region"];
            placename = state; 
        }
      
        Page.Title = "List of cities in " + placename;
        // Page.Response.Write("usa");


        HtmlMeta tag = new HtmlMeta();
        tag.Name = "description";
        tag.Content = Page.Title + " " + Global.Sitename.ToString() + " has list of cities in " + placename + ". Click on city name to know what to see during city trip "  ;
        Header.Controls.Add(tag);

        slides();
       // Getcities();
        //Getplaces();
        GetCitiesRepeater();
        Page.DataBind();
    }

    private void slides()
    {

        slide =  "http://pictures.uscitytrip.net/banner/" + placename + ".jpg";
       
        slidestr = "<img src='" + slide + "' width='1200' height='265' alt='image slide of " + placename + "' />";

        Label1.Text = Page.Title;


    }



    

   




   

    private void GetCitiesRepeater()
    {

        labeltitle.Text = Page.Title;
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
                cmd.Parameters.AddWithValue("@region", state);

                cmd.Parameters.AddWithValue("@n", 100);
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
