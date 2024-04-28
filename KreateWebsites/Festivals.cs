using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Data.SqlClient;

namespace KreateWebsites
{
    public class Festivals
    {
        public static DataTable GetData(int year, string festival, string category, string country, int n, int sortOrder)
        {
         
            // Pass 0 for all years
            string sp = "festival_search_year";



            string connect = System.Configuration.ConfigurationManager.ConnectionStrings["films"].ConnectionString;


            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@year", year);
                    cmd.Parameters.AddWithValue("@festival", festival);
                    cmd.Parameters.AddWithValue("@category", category);
                    cmd.Parameters.AddWithValue("@country", country);
                  


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

        public static DataTable GetUpcoming(int year, string festival, string category, string country, int n, int sortOrder)
        {

            // Pass 0 for all years.  Same as above.  But it will return festival details for upcoming year too.
            string sp = "festival_search";



            string connect = System.Configuration.ConfigurationManager.ConnectionStrings["films"].ConnectionString;


            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@year", year);
                    cmd.Parameters.AddWithValue("@festival", festival);
                    cmd.Parameters.AddWithValue("@category", category);
                    cmd.Parameters.AddWithValue("@country", country);



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

        public static DataTable GetData(DateTime  startdate, DateTime enddate,  string festival, string category, string country, int n, int sortOrder)
        {
     

            string sp = "festival_search_period";



            string connect = System.Configuration.ConfigurationManager.ConnectionStrings["films"].ConnectionString;


            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@startdate", startdate);
                    cmd.Parameters.AddWithValue("@enddate", enddate);
                    cmd.Parameters.AddWithValue("@festival", festival);
                    cmd.Parameters.AddWithValue("@category", category);
                    cmd.Parameters.AddWithValue("@country", country);



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

        public static DataTable GetHolidays(string country, int year, string festival, char holiday, string category, int n, int sortOrder)
        {

            string sp = "festival_holiday_usa_search_year";

            if (string.Compare(country, "USA", true) == 0)
            {

                sp = "festival_holiday_usa_search_year";


            }

            if (string.Compare(country, "UK", true) == 0)
            {

                sp = "festival_holiday_uk_search_year";


            }
            if (string.Compare(country, "India", true) == 0)
            {

                sp = "festival_holiday_india_search_year";


            }

            if (string.Compare(country, "China", true) == 0)
            {

                sp = "festival_holiday_china_search_year";


            }
            string connect = System.Configuration.ConfigurationManager.ConnectionStrings["films"].ConnectionString;


            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@year", year);
                    cmd.Parameters.AddWithValue("@festival", festival);
                    cmd.Parameters.AddWithValue("@holiday", holiday);
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


        public static DataTable GetFestivalDetails(int articleid, string festival,string category,string subcategory, string title, int n, int sortOrder,  int spin)

           
        {

            string sp = "festival_details_search";

            string connect = System.Configuration.ConfigurationManager.ConnectionStrings["films"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@articleid", articleid);
                    cmd.Parameters.AddWithValue("@festival", festival);
                    cmd.Parameters.AddWithValue("@category", category);
                    cmd.Parameters.AddWithValue("@category2", subcategory);
                    cmd.Parameters.AddWithValue("@title", subcategory);


                    cmd.Parameters.AddWithValue("@n", n);
                    cmd.Parameters.AddWithValue("@SortOrder", sortOrder);
                    cmd.Parameters.AddWithValue("@SortOrder", spin);
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
