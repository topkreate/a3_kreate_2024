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
    protected string placename = Global.Country.ToString();
    protected string slidestr = null;

    protected void Page_Load(object sender, EventArgs e)
    {
      
      
        Page.Title = "List of regions in " + placename;
        // Page.Response.Write("usa");


        HtmlMeta tag = new HtmlMeta();
        tag.Name = "description";
        tag.Content = Page.Title + " " + Global.Sitename.ToString() + " has list of regions. Click on region to see detail trip informatio about each region in " + placename + ". Use this city guide on " + placename + " tour";
        Header.Controls.Add(tag);

        slides();
       // Getcities();
        //Getplaces();
        GetStatesRepeater();
        Page.DataBind();
    }

    private void slides()
    {

        slide =  "http://pictures.uscitytrip.net/banner/" + placename + ".jpg";
       
        slidestr = "<img src='" + slide + "' width='1200' height='265' alt='image slide of " + placename + "' />";

        Label1.Text = Page.Title;


    }

   

    

   



    private void GetStatesRepeater()
    {

        labeltitle.Text = Page.Title;
        string sp = "regions_in_country";



        // string connect = @"SERVER=yellpproduct.db.5284911.hostedresource.com;Database=yellpproduct;UID=yellpproduct;PWD=Dhingra732!@;Trusted_Connection=False;";
        string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;

        //   string connect = "<%$ ConnectionStrings:films %>" ;
        //     ConnectionString="<%$ ConnectionStrings:films %>"
        using (SqlConnection conn = new SqlConnection(connect))
        {

            using (SqlCommand cmd = new SqlCommand(sp, conn))
            {

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Country", Global.Country.ToString());
               
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
