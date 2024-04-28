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

public partial class mycontrol : System.Web.UI.UserControl
{

    protected string continent = Global.Continent;
    protected string country = Global.Country;
    protected string state = Global.State;
    protected string statename = Global.StateName.ToString();

    protected string city = Global.City;
    protected string category = "all";
    protected string subcategory = "all";
    protected Int16 count = 12;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["state"] != null)
        {
            state = Request.QueryString["state"];
        }


      if (Request.QueryString["city"] != null)
      {
          city = Request.QueryString["city"];
      }

      if (Request.QueryString["category"] != null)
      {
          category = Request.QueryString["category"];
      }


      if (Request.QueryString["subcategory"] != null)
      {
          subcategory = Request.QueryString["subcategory"];
      }

        GetPlacesRepeater();

    }



    private void GetPlacesRepeater()
    {


        string sp = "best_tourist_places_search_v4";



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
                cmd.Parameters.AddWithValue("@State", state);
                cmd.Parameters.AddWithValue("@Statename", statename);
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