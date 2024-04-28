using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Data.SqlClient;

namespace KreateWebsites
{
    public class Cricket
    {
        public static DataTable GetTodayMatches()
        {


            string sp = "todaymatchches";


            string connect = ConfigurationManager.ConnectionStrings["astrology"].ConnectionString;

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

        public static DataTable GetSeries()
        {


            string sp = "cricket_get_series";


            string connect = ConfigurationManager.ConnectionStrings["astrology"].ConnectionString;

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


        public static DataTable GetMatchDetails(int id)
        {


            string sp = "cricket_get_match_details";


            string connect = ConfigurationManager.ConnectionStrings["astrology"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);




                    SqlDataAdapter da = new SqlDataAdapter(cmd);






                    DataSet ds = new DataSet();

                    da.Fill(ds);


                    DataTable dt = ds.Tables[0];

                    return dt;




                }

            }





        }

        public static DataTable GetPlayersName(string team)
        {


            string sp = "cricket_get_match_details";


            string connect = ConfigurationManager.ConnectionStrings["astrology"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@team", team);




                    SqlDataAdapter da = new SqlDataAdapter(cmd);






                    DataSet ds = new DataSet();

                    da.Fill(ds);


                    DataTable dt = ds.Tables[0];

                    return dt;




                }

            }





        }

        public static DataTable GetData(string series_name, string country1, string country2, string MatchType, string Venue, string MatchFormat, int n, int sortOrder)
        {




            string sp = "cricket-match_search";


            string connect = ConfigurationManager.ConnectionStrings["astrology"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@series_name", series_name);
                    cmd.Parameters.AddWithValue("@country1", country1);
                    cmd.Parameters.AddWithValue("@country2", country2);
                    cmd.Parameters.AddWithValue("@MatchType", MatchType);
                    cmd.Parameters.AddWithValue("@Venue", Venue);
                    cmd.Parameters.AddWithValue("@MatchFormat", MatchFormat);
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
        public static DataTable GetDataInPeriod(DateTime startdate, DateTime enddate, string series_name, string country1, string country2, string MatchType, string Venue, string MatchFormat, int n, int sortOrder)
        {




            string sp = "cricket_match_search_period";


            string connect = ConfigurationManager.ConnectionStrings["astrology"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@startdate", startdate);
                    cmd.Parameters.AddWithValue("@enddate", enddate);
                    cmd.Parameters.AddWithValue("@series_name", series_name);
                    cmd.Parameters.AddWithValue("@country1", country1);
                    cmd.Parameters.AddWithValue("@country2", country2);
                    cmd.Parameters.AddWithValue("@MatchType", MatchType);
                    cmd.Parameters.AddWithValue("@Venue", Venue);
                    cmd.Parameters.AddWithValue("@MatchFormat", MatchFormat);
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
        public static DataTable GetRecentMatchesFormat(string MatchFormat)
        {

            // Returns top 7 recent matches


            string sp = "recentmatches_format";


            string connect = ConfigurationManager.ConnectionStrings["astrology"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    cmd.Parameters.AddWithValue("@format", MatchFormat);
        



                    SqlDataAdapter da = new SqlDataAdapter(cmd);






                    DataSet ds = new DataSet();

                    da.Fill(ds);


                    DataTable dt = ds.Tables[0];

                    return dt;




                }

            }





        }

        public static DataTable GetRecentMatchesFormat(string series, int n)
        {

            // Returns top 7 recent matches


            string sp = "recentmatches_series";


            string connect = ConfigurationManager.ConnectionStrings["astrology"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@series", series);
                    cmd.Parameters.AddWithValue("@n", n);



                    SqlDataAdapter da = new SqlDataAdapter(cmd);






                    DataSet ds = new DataSet();

                    da.Fill(ds);


                    DataTable dt = ds.Tables[0];

                    return dt;




                }

            }





        }

        public static DataTable GetRecentMatches_Series_team(string name, int n, string series)
        {




            string sp = "recentmatches_series_team";


            string connect = ConfigurationManager.ConnectionStrings["astrology"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@n", n);
                    cmd.Parameters.AddWithValue("@series", series);


                    SqlDataAdapter da = new SqlDataAdapter(cmd);






                    DataSet ds = new DataSet();

                    da.Fill(ds);


                    DataTable dt = ds.Tables[0];

                    return dt;




                }

            }





        }

        public static DataTable GetRecentMatches_team(string name, int n)
        {




            string sp = "recentmatches_team";


            string connect = ConfigurationManager.ConnectionStrings["astrology"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@country", name);
                    cmd.Parameters.AddWithValue("@n", n);
                 


                    SqlDataAdapter da = new SqlDataAdapter(cmd);






                    DataSet ds = new DataSet();

                    da.Fill(ds);


                    DataTable dt = ds.Tables[0];

                    return dt;




                }

            }





        }

        public static DataTable GetRecentMatches(int n)
        {




            string sp = "recentmatches7";


            string connect = ConfigurationManager.ConnectionStrings["astrology"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    
                    cmd.Parameters.AddWithValue("@n", n);



                    SqlDataAdapter da = new SqlDataAdapter(cmd);






                    DataSet ds = new DataSet();

                    da.Fill(ds);


                    DataTable dt = ds.Tables[0];

                    return dt;




                }

            }





        }

        public static DataTable UpcomingMatchesFormat(string MatchFormat, int n)
        {

            // Returns top 7 recent matches


            string sp = "upcomingmatches_format";


            string connect = ConfigurationManager.ConnectionStrings["astrology"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@format", MatchFormat);
                    cmd.Parameters.AddWithValue("@n", n);



                    SqlDataAdapter da = new SqlDataAdapter(cmd);






                    DataSet ds = new DataSet();

                    da.Fill(ds);


                    DataTable dt = ds.Tables[0];

                    return dt;




                }

            }





        }

        public static DataTable UpcomingMatchesSeries(string series, int n)
        {

            // Returns top 7 recent matches


            string sp = "upcomingmatches_series";


            string connect = ConfigurationManager.ConnectionStrings["astrology"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@series", series);
                    cmd.Parameters.AddWithValue("@n", n);



                    SqlDataAdapter da = new SqlDataAdapter(cmd);






                    DataSet ds = new DataSet();

                    da.Fill(ds);


                    DataTable dt = ds.Tables[0];

                    return dt;




                }

            }





        }

        public static DataTable UpcomingMatches(string series, string name, int n)
        {

            // Returns top 7 recent matches


            string sp = "upcomingmatches_series_team";


            string connect = ConfigurationManager.ConnectionStrings["astrology"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@series", series);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@n", n);



                    SqlDataAdapter da = new SqlDataAdapter(cmd);






                    DataSet ds = new DataSet();

                    da.Fill(ds);


                    DataTable dt = ds.Tables[0];

                    return dt;




                }

            }





        }

        public static DataTable UpcomingMatches( string name, int n)
        {

            // Returns top 7 recent matches


            string sp = "upcomingmatches_team";


            string connect = ConfigurationManager.ConnectionStrings["astrology"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@country", name);
                    cmd.Parameters.AddWithValue("@n", n);



                    SqlDataAdapter da = new SqlDataAdapter(cmd);






                    DataSet ds = new DataSet();

                    da.Fill(ds);


                    DataTable dt = ds.Tables[0];

                    return dt;




                }

            }





        }

        public static DataTable UpcomingMatches( int n)
        {

            // Returns top 7 recent matches


            string sp = "upcomingmatches";


            string connect = ConfigurationManager.ConnectionStrings["astrology"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;

               
                    cmd.Parameters.AddWithValue("@n", n);



                    SqlDataAdapter da = new SqlDataAdapter(cmd);






                    DataSet ds = new DataSet();

                    da.Fill(ds);


                    DataTable dt = ds.Tables[0];

                    return dt;




                }

            }





        }

        public static DataTable GetPlayers(string full_name, string batting_style, string bowling_style, string country, int n, int sortOrder)
        {


            string sp = "players_search";


            string connect = ConfigurationManager.ConnectionStrings["astrology"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@full_name", full_name);
                    cmd.Parameters.AddWithValue("@batting_style", batting_style);
                    cmd.Parameters.AddWithValue("@bowling_style", bowling_style);
                    cmd.Parameters.AddWithValue("@country", country);
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


    }
}
