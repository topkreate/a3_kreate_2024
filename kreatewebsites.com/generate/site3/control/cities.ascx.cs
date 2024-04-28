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

public partial class cities : System.Web.UI.UserControl
{
    protected string continent;
    protected string country;
    protected string state;
    protected string city;

    protected void Page_Load(object sender, EventArgs e)
    {
        Getcities();

    }


    private void Getcities()
    {
          continent = Global.Continent;
        country = Global.Country;
        state = Global.State;
        city = Global.City;
        
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
                cmd.Parameters.AddWithValue("@Region", state);
                cmd.Parameters.AddWithValue("@n", 6);
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
  


}