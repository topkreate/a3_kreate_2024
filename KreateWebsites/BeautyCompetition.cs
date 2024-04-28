using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Data.SqlClient;

namespace KreateWebsites
{
    public static class BeautyCompetition
    {

        public static DataTable GetBeautyCompetition(string competition_name, string competition_city, string competiton_country, int year, string winner, string winner_Country, string category, int n, int sortOrder)
        {
            string sp = "beauty_competition_search";



            string connect = System.Configuration.ConfigurationManager.ConnectionStrings["films"].ConnectionString;


            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.AddWithValue("@competition_name", competition_name);
                    cmd.Parameters.AddWithValue("@competition_city", competition_city);
                    cmd.Parameters.AddWithValue("@competition_country", competiton_country);
                    cmd.Parameters.AddWithValue("@year", year);
                    cmd.Parameters.AddWithValue("@winner", winner);
                    cmd.Parameters.AddWithValue("@winner_country", winner_Country);

                    cmd.Parameters.AddWithValue("@category", category);


                    cmd.Parameters.AddWithValue("@n", n);
                    cmd.Parameters.AddWithValue("@SortOrder", sortOrder);





                    SqlDataAdapter da = new SqlDataAdapter(cmd);



                    DataSet ds = new DataSet();

                    da.Fill(ds);


                    DataTable dt = ds.Tables[0];

                    return dt;



                }
            }
        }

    }
}
