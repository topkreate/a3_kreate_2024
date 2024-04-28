using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Data.SqlClient;

namespace KreateWebsites
{
    public static class BeautyParlors
    {
        public static DataTable GetData(string country, string state, string statename, string city, string category, string subcategory, string name , int n, int sortOrder, int direction, int spin)
        {

            string sp = "beautyparlors_search";


            string connect = System.Configuration.ConfigurationManager.ConnectionStrings["astrology"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@country", country);
                    cmd.Parameters.AddWithValue("@state", state);
                    cmd.Parameters.AddWithValue("@statename", statename);
                    cmd.Parameters.AddWithValue("@city", city);
                    cmd.Parameters.AddWithValue("@category", category);
                    cmd.Parameters.AddWithValue("@subcategory", subcategory);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@n", n);
                    cmd.Parameters.AddWithValue("@sortOrder", sortOrder);
                    cmd.Parameters.AddWithValue("@direction", direction);
                    cmd.Parameters.AddWithValue("@spin", spin);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);






                    DataSet ds = new DataSet();

                    da.Fill(ds);


                    DataTable dt = ds.Tables[0];

                    return dt;




                }

            }





        }

        public static DataTable GetUniqueCity(string country, string state, string statename, string city, string category, string subcategory, string name, int n, int sortOrder, int direction, int spin)
        {

            string sp = "beautyparlors_uniquecity";


            string connect = System.Configuration.ConfigurationManager.ConnectionStrings["astrology"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@country", country);
                    cmd.Parameters.AddWithValue("@state", state);
                    cmd.Parameters.AddWithValue("@statename", statename);
                    cmd.Parameters.AddWithValue("@city", city);
                    cmd.Parameters.AddWithValue("@category", category);
                    cmd.Parameters.AddWithValue("@subcategory", subcategory);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@n", n);
                    cmd.Parameters.AddWithValue("@sortOrder", sortOrder);
                    cmd.Parameters.AddWithValue("@direction", direction);
                    cmd.Parameters.AddWithValue("@spin", spin);

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
