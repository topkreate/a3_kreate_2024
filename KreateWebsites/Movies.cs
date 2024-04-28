using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Data.SqlClient;

namespace KreateWebsites
{
    public class Movies
    {
        public static DataTable GetData(string name,string language, string category, string subcategory, string actor, string director, string producer, int n, int sortOrder, int direction, int spin)
        {


            string sp = "movies_search2";


            string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;


            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@language", language);
                    cmd.Parameters.AddWithValue("@category", subcategory);
                    cmd.Parameters.AddWithValue("@subcategory", subcategory);
                    cmd.Parameters.AddWithValue("@actor", actor);
                    cmd.Parameters.AddWithValue("@director", director);
                    cmd.Parameters.AddWithValue("@producer", producer);
            
               
                    cmd.Parameters.AddWithValue("@n", n);
                    cmd.Parameters.AddWithValue("@SortOrder", sortOrder);
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
         public static DataTable GetUpcomingMovies()
        {


            string sp = "movies_upcoming";


            string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;


            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    



                    SqlDataAdapter da = new SqlDataAdapter(cmd);






                    DataSet ds = new DataSet();

                    da.Fill(ds);


                    DataTable dt = ds.Tables[0];

                    return dt;





                }




            }
        }
         public static DataTable GetUpcomingMoviesLanguage(string language)
         {


             string sp = "movies_upcoming_language";


             string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;


             using (SqlConnection conn = new SqlConnection(connect))
             {

                 using (SqlCommand cmd = new SqlCommand(sp, conn))
                 {

                     cmd.CommandType = CommandType.StoredProcedure;

                     cmd.Parameters.AddWithValue("@language", language);



                     SqlDataAdapter da = new SqlDataAdapter(cmd);






                     DataSet ds = new DataSet();

                     da.Fill(ds);


                     DataTable dt = ds.Tables[0];

                     return dt;





                 }




             }
         }

         public static DataTable GetMoviesReleasedOnDate(string language, DateTime date)
         {


             string sp = "movies_released_on_date_language";


             string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;


             using (SqlConnection conn = new SqlConnection(connect))
             {

                 using (SqlCommand cmd = new SqlCommand(sp, conn))
                 {

                     cmd.CommandType = CommandType.StoredProcedure;

                     cmd.Parameters.AddWithValue("@language", language);
                     cmd.Parameters.AddWithValue("@date", @date);


                     SqlDataAdapter da = new SqlDataAdapter(cmd);






                     DataSet ds = new DataSet();

                     da.Fill(ds);


                     DataTable dt = ds.Tables[0];

                     return dt;





                 }




             }
         }
         public static DataTable GetMoviesReleasedOnDateAllLanaguages( DateTime date)
         {


             string sp = "movies_released_on_date";


             string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;


             using (SqlConnection conn = new SqlConnection(connect))
             {

                 using (SqlCommand cmd = new SqlCommand(sp, conn))
                 {

                     cmd.CommandType = CommandType.StoredProcedure;

                   
                     cmd.Parameters.AddWithValue("@date", @date);


                     SqlDataAdapter da = new SqlDataAdapter(cmd);






                     DataSet ds = new DataSet();

                     da.Fill(ds);


                     DataTable dt = ds.Tables[0];

                     return dt;





                 }




             }
         }

         public static DataTable GetBestMovies()
         {


             string sp = "movies_best";


             string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;


             using (SqlConnection conn = new SqlConnection(connect))
             {

                 using (SqlCommand cmd = new SqlCommand(sp, conn))
                 {

                     cmd.CommandType = CommandType.StoredProcedure;


   


                     SqlDataAdapter da = new SqlDataAdapter(cmd);






                     DataSet ds = new DataSet();

                     da.Fill(ds);


                     DataTable dt = ds.Tables[0];

                     return dt;





                 }




             }
         }
         public static DataTable GetMovieDetails(string name)
         {


             string sp = "movies_get_detail";


             string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;


             using (SqlConnection conn = new SqlConnection(connect))
             {

                 using (SqlCommand cmd = new SqlCommand(sp, conn))
                 {

                     cmd.CommandType = CommandType.StoredProcedure;
                     cmd.Parameters.AddWithValue("@name", @name);




                     SqlDataAdapter da = new SqlDataAdapter(cmd);






                     DataSet ds = new DataSet();

                     da.Fill(ds);


                     DataTable dt = ds.Tables[0];

                     return dt;





                 }




             }
         }

         public static DataTable GetMoviesLastWeek(string language)
         {


             string sp = "movies_last_week_language";


             string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;


             using (SqlConnection conn = new SqlConnection(connect))
             {

                 using (SqlCommand cmd = new SqlCommand(sp, conn))
                 {

                     cmd.CommandType = CommandType.StoredProcedure;
                     cmd.Parameters.AddWithValue("@language", @language);




                     SqlDataAdapter da = new SqlDataAdapter(cmd);






                     DataSet ds = new DataSet();

                     da.Fill(ds);


                     DataTable dt = ds.Tables[0];

                     return dt;





                 }




             }
         }

         public static DataTable GetMoviesOfActor(string actor)
         {


             string sp = "movies_list_actor";


             string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;


             using (SqlConnection conn = new SqlConnection(connect))
             {

                 using (SqlCommand cmd = new SqlCommand(sp, conn))
                 {

                     cmd.CommandType = CommandType.StoredProcedure;
                     cmd.Parameters.AddWithValue("@actor", @actor);




                     SqlDataAdapter da = new SqlDataAdapter(cmd);






                     DataSet ds = new DataSet();

                     da.Fill(ds);


                     DataTable dt = ds.Tables[0];

                     return dt;





                 }




             }
         }

         public static DataTable GetNewIndianMovies()
         {


             string sp = "movies_new_indian";


             string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;


             using (SqlConnection conn = new SqlConnection(connect))
             {

                 using (SqlCommand cmd = new SqlCommand(sp, conn))
                 {

                     cmd.CommandType = CommandType.StoredProcedure;
         




                     SqlDataAdapter da = new SqlDataAdapter(cmd);






                     DataSet ds = new DataSet();

                     da.Fill(ds);


                     DataTable dt = ds.Tables[0];

                     return dt;





                 }




             }
         }
         public static DataTable GetNewMovies(string language)
         {


             string sp = "movies_new_language";


             string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;


             using (SqlConnection conn = new SqlConnection(connect))
             {

                 using (SqlCommand cmd = new SqlCommand(sp, conn))
                 {

                     cmd.CommandType = CommandType.StoredProcedure;

                     cmd.Parameters.AddWithValue("@language", @language);



                     SqlDataAdapter da = new SqlDataAdapter(cmd);






                     DataSet ds = new DataSet();

                     da.Fill(ds);


                     DataTable dt = ds.Tables[0];

                     return dt;





                 }




             }
         }
         public static DataTable GetNextWeekIndianMovies()
         {


             string sp = "movies_new_nextweek_indian";


             string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;


             using (SqlConnection conn = new SqlConnection(connect))
             {

                 using (SqlCommand cmd = new SqlCommand(sp, conn))
                 {

                     cmd.CommandType = CommandType.StoredProcedure;



                     SqlDataAdapter da = new SqlDataAdapter(cmd);






                     DataSet ds = new DataSet();

                     da.Fill(ds);


                     DataTable dt = ds.Tables[0];

                     return dt;





                 }




             }
         }

         public static DataTable GetNextWeekMovies(string language)
         {


             string sp = "movies_nextweek_language";


             string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;


             using (SqlConnection conn = new SqlConnection(connect))
             {

                 using (SqlCommand cmd = new SqlCommand(sp, conn))
                 {

                     cmd.CommandType = CommandType.StoredProcedure;

                     cmd.Parameters.AddWithValue("@language", @language);


                     SqlDataAdapter da = new SqlDataAdapter(cmd);






                     DataSet ds = new DataSet();

                     da.Fill(ds);


                     DataTable dt = ds.Tables[0];

                     return dt;





                 }




             }
         }


         public static DataTable GetNextMoviesInDuration(string language, int duration)
         {


             string sp = "movies_next_language_duration";


             string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;


             using (SqlConnection conn = new SqlConnection(connect))
             {

                 using (SqlCommand cmd = new SqlCommand(sp, conn))
                 {

                     cmd.CommandType = CommandType.StoredProcedure;

                     cmd.Parameters.AddWithValue("@language", @language);

                      cmd.Parameters.AddWithValue("@duration", @duration);

                     SqlDataAdapter da = new SqlDataAdapter(cmd);






                     DataSet ds = new DataSet();

                     da.Fill(ds);


                     DataTable dt = ds.Tables[0];

                     return dt;





                 }




             }
         }

         public static DataTable GetPastMovies(string language)
         {


             string sp = "movies_past_language";


             string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;


             using (SqlConnection conn = new SqlConnection(connect))
             {

                 using (SqlCommand cmd = new SqlCommand(sp, conn))
                 {

                     cmd.CommandType = CommandType.StoredProcedure;

                     cmd.Parameters.AddWithValue("@language", @language);

                  

                     SqlDataAdapter da = new SqlDataAdapter(cmd);






                     DataSet ds = new DataSet();

                     da.Fill(ds);


                     DataTable dt = ds.Tables[0];

                     return dt;





                 }




             }
         }

         public static DataTable GetRecentMovies(string language, int n, int sortOrder)
         {


             string sp = "movies_recent";


             string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;


             using (SqlConnection conn = new SqlConnection(connect))
             {

                 using (SqlCommand cmd = new SqlCommand(sp, conn))
                 {

                     cmd.CommandType = CommandType.StoredProcedure;

                     cmd.Parameters.AddWithValue("@language", language);
                     cmd.Parameters.AddWithValue("@n", n);
                     cmd.Parameters.AddWithValue("@sortOrder", sortOrder);


                     SqlDataAdapter da = new SqlDataAdapter(cmd);






                     DataSet ds = new DataSet();

                     da.Fill(ds);


                     DataTable dt = ds.Tables[0];

                     return dt;





                 }




             }
         }

         public static DataTable GetRecent(string language)
         {


             string sp = "movies_recent";


             string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;


             using (SqlConnection conn = new SqlConnection(connect))
             {

                 using (SqlCommand cmd = new SqlCommand(sp, conn))
                 {

                     cmd.CommandType = CommandType.StoredProcedure;

                     cmd.Parameters.AddWithValue("@language", @language);



                     SqlDataAdapter da = new SqlDataAdapter(cmd);






                     DataSet ds = new DataSet();

                     da.Fill(ds);


                     DataTable dt = ds.Tables[0];

                     return dt;





                 }




             }
         }
         public static DataTable GetRecentIndianMovies()
         {


             string sp = "movies_recent_indian";


             string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;


             using (SqlConnection conn = new SqlConnection(connect))
             {

                 using (SqlCommand cmd = new SqlCommand(sp, conn))
                 {

                     cmd.CommandType = CommandType.StoredProcedure;

                 



                     SqlDataAdapter da = new SqlDataAdapter(cmd);






                     DataSet ds = new DataSet();

                     da.Fill(ds);


                     DataTable dt = ds.Tables[0];

                     return dt;





                 }




             }
         }

         public static DataTable GetMoviesReleased(string language)
         {


             string sp = "movies_past_language";


             string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;


             using (SqlConnection conn = new SqlConnection(connect))
             {

                 using (SqlCommand cmd = new SqlCommand(sp, conn))
                 {

                     cmd.CommandType = CommandType.StoredProcedure;

                     cmd.Parameters.AddWithValue("@language", @language);



                     SqlDataAdapter da = new SqlDataAdapter(cmd);






                     DataSet ds = new DataSet();

                     da.Fill(ds);


                     DataTable dt = ds.Tables[0];

                     return dt;





                 }




             }
         }
         public static DataTable GetMoviesReleasedOnDate(DateTime date)
         {


             string sp = "movies_released_on_date";


             string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;


             using (SqlConnection conn = new SqlConnection(connect))
             {

                 using (SqlCommand cmd = new SqlCommand(sp, conn))
                 {

                     cmd.CommandType = CommandType.StoredProcedure;

                     cmd.Parameters.AddWithValue("@date", @date);



                     SqlDataAdapter da = new SqlDataAdapter(cmd);






                     DataSet ds = new DataSet();

                     da.Fill(ds);


                     DataTable dt = ds.Tables[0];

                     return dt;





                 }




             }
         }

         public static DataTable GetMoviesInPeriod(DateTime startdate, DateTime enddate, string name,string language, string category, string subcategory, string actor, string director, string producer, int n, int sortOrder, int direction, int spin)
        {


            string sp = "movies_search_period";


            string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;


            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@startdate", startdate);
                    cmd.Parameters.AddWithValue("@enddate", enddate);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@language", language);
                    cmd.Parameters.AddWithValue("@category", subcategory);
                    cmd.Parameters.AddWithValue("@subcategory", subcategory);
                    cmd.Parameters.AddWithValue("@actor", actor);
                    cmd.Parameters.AddWithValue("@director", director);
                    cmd.Parameters.AddWithValue("@producer", producer);
            
               
                    cmd.Parameters.AddWithValue("@n", n);
                    cmd.Parameters.AddWithValue("@SortOrder", sortOrder);
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
