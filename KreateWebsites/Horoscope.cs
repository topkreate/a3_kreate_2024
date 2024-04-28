using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Data.SqlClient;

namespace KreateWebsites
{
    public class Horoscope
    {
        public static DataTable GetMonthlyHoroscope(string sunsign, string month, string year, string sortOrder)
        {
           

            string sp = "monthly_horoscope_search";


            string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@sunsign", sunsign);
                    cmd.Parameters.AddWithValue("@month", month);
                    cmd.Parameters.AddWithValue("@year", year);
                    
                    cmd.Parameters.AddWithValue("@SortOrder", sortOrder);
             


                    SqlDataAdapter da = new SqlDataAdapter(cmd);






                    DataSet ds = new DataSet();

                    da.Fill(ds);


                    DataTable dt = ds.Tables[0];

                    return dt;




                }

            }





        }
        public static DataTable GetMonthlyHoroscope(string sunsign, int month, string year)
        {
         

            string sp = "monthly_horoscope_search_parent";  // calls monthly_horoscope_search internally


            string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@sunsign", sunsign);
                    cmd.Parameters.AddWithValue("@month", month);
                    cmd.Parameters.AddWithValue("@year", year);

                  



                    SqlDataAdapter da = new SqlDataAdapter(cmd);






                    DataSet ds = new DataSet();

                    da.Fill(ds);


                    DataTable dt = ds.Tables[0];

                    return dt;




                }

            }





        }
        public static DataTable GetMonthlyHoroscope(string sunsign)
        {


            string sp = "monthly_horoscope_get";


            string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@sunsign", sunsign);
                    



                    SqlDataAdapter da = new SqlDataAdapter(cmd);






                    DataSet ds = new DataSet();

                    da.Fill(ds);


                    DataTable dt = ds.Tables[0];

                    return dt;




                }

            }





        }
        public static DataTable GetYearlyHoroscope(string sunsign,  string year, string sortOrder, int direction)
        {
        


            string sp = "yearly_horoscope_search";


            string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@sunsign", sunsign);
                 
                    cmd.Parameters.AddWithValue("@year", year);

                    cmd.Parameters.AddWithValue("@SortOrder", sortOrder);

                    cmd.Parameters.AddWithValue("@direction", direction);



                    SqlDataAdapter da = new SqlDataAdapter(cmd);






                    DataSet ds = new DataSet();

                    da.Fill(ds);


                    DataTable dt = ds.Tables[0];

                    return dt;




                }

            }





        }
        public static DataTable GetSunSignCompatibility(string sunsign1, string sunsign2, string sortorder)
        {

       
            string sp = "sunsign_compatibility_search";


            string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@sunsign1", sunsign1);
                    cmd.Parameters.AddWithValue("@sunsign2", sunsign2);
                    cmd.Parameters.AddWithValue("@SortOrder", sortorder);



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
