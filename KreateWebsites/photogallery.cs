using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Data.SqlClient;


/// <summary>
/// Summary description for Connect
/// </summary>
/// 
namespace KreateWebsites
{
    public static class Places
    {


        public static int year;
        public static int count = 5;



        public static void GetVariables()
        {


            DateTime moment = DateTime.Now;


            // Year gets 1999. 
            year = moment.Year;

            // Month gets 1 (January). 
            int month = moment.Month;

            // Day gets 13. 
            int day = moment.Day;

            // Hour gets 3. 
            int hour = moment.Hour;

            // Minute gets 57. 
            int minute = moment.Minute;

            // Second gets 32. 
            int second = moment.Second;

            // Millisecond gets 11. 
            int millisecond = moment.Millisecond;







        }
        public static DataTable GetData(string continent, string country, string state, string statename, string city, string category, string subcategory, int n, int sortOrder)
        {


            string sp = "best_tourist_places_search_v4";



            string connect = System.Configuration.ConfigurationManager.ConnectionStrings["films"].ConnectionString;


            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@continent", continent);
                    cmd.Parameters.AddWithValue("@country", country);
                    cmd.Parameters.AddWithValue("@state", state);
                    cmd.Parameters.AddWithValue("@statename", statename);
                    cmd.Parameters.AddWithValue("@city", city);
                    cmd.Parameters.AddWithValue("@category", category);

                    cmd.Parameters.AddWithValue("@subcategory", subcategory);


                    cmd.Parameters.AddWithValue("@n", n);
                    cmd.Parameters.AddWithValue("@SortOrder", sortOrder);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);






                    DataSet ds = new DataSet();

                    da.Fill(ds);


                    DataTable dt = ds.Tables[0];

                    return dt;
                    /*

                    if (dt.Rows.Count > 0)
                    {

                        RepDetails.DataSource = dt;
                        RepDetails.DataBind();

                 






                    }
                   */



                }




            }
        }

        public static DataTable GetData( int n, int sortOrder ,int minscore)
        {


            string sp = "best_tourist_places_search_v6";



            string connect = System.Configuration.ConfigurationManager.ConnectionStrings["films"].ConnectionString;


            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    


                    cmd.Parameters.AddWithValue("@n", n);
                    cmd.Parameters.AddWithValue("@SortOrder", sortOrder);
                    cmd.Parameters.AddWithValue("@minscore", minscore);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);






                    DataSet ds = new DataSet();

                    da.Fill(ds);


                    DataTable dt = ds.Tables[0];

                    return dt;
                    /*

                    if (dt.Rows.Count > 0)
                    {

                        RepDetails.DataSource = dt;
                        RepDetails.DataBind();

                 






                    }
                   */



                }




            }
        }

        public static DataTable GetData(string country, string name)
        {


            string sp = "best_tourist_places_search_v6";



            string connect = System.Configuration.ConfigurationManager.ConnectionStrings["films"].ConnectionString;


            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    if (string.Compare(country, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@country", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@country", country);
                    }

                    
                    cmd.Parameters.AddWithValue("@biz_name", name);
                   
                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                                        
                    DataSet ds = new DataSet();

                    da.Fill(ds);


                    DataTable dt = ds.Tables[0];

                    return dt;
                    /*

                    if (dt.Rows.Count > 0)
                    {

                        RepDetails.DataSource = dt;
                        RepDetails.DataBind();

                 






                    }
                   */



                }




            }
        }

        public static DataTable GetData(string continent, string country, string state,  string city, string category, string subcategory, int n, int sortOrder)
        {


            string sp = "best_tourist_places_search_v6";



            string connect = System.Configuration.ConfigurationManager.ConnectionStrings["films"].ConnectionString;


            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;


                    if (string.Compare(country, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@continent", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@continent", continent);
                    }

                    if (string.Compare(country, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@country", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@country", country);
                    }

                    if (string.Compare(state, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@state", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@state", state);
                    }
                    cmd.Parameters.AddWithValue("@statename", DBNull.Value);

                    if (string.Compare(city, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@city", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@city", city);
                    }

                    if (string.Compare(category, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@category", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@category", category);
                    }

                    if (string.Compare(subcategory, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@subcategory", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@subcategory", subcategory);
                    }

                    


                    cmd.Parameters.AddWithValue("@n", n);
                    cmd.Parameters.AddWithValue("@SortOrder", sortOrder);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);






                    DataSet ds = new DataSet();

                    da.Fill(ds);


                    DataTable dt = ds.Tables[0];

                    return dt;
                    /*

                    if (dt.Rows.Count > 0)
                    {

                        RepDetails.DataSource = dt;
                        RepDetails.DataBind();

                 






                    }
                   */



                }




            }
        }
        public static DataTable GetData(string continent, string country, string state, string statename, string city, string category, string subcategory, string biz_name, int n, int sortOrder, int minscore)
        {


            string sp = "best_tourist_places_search_v6";



            string connect = System.Configuration.ConfigurationManager.ConnectionStrings["films"].ConnectionString;


            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;


                    if (string.Compare(country, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@continent", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@continent", continent);
                    }

                    if (string.Compare(country, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@country", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@country", country);
                    }

                    if (string.Compare(state, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@state", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@state", state);
                    }

                    if (string.Compare(statename, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@statename", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@statename", statename);
                    }

                    

                    if (string.Compare(city, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@city", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@city", city);
                    }

                    if (string.Compare(category, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@category", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@category", category);
                    }

                    if (string.Compare(subcategory, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@subcategory", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@subcategory", subcategory);
                    }

                    if (string.Compare(biz_name, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@biz_name", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@biz_name", biz_name);
                    }


                    cmd.Parameters.AddWithValue("@n", n);
                    cmd.Parameters.AddWithValue("@SortOrder", sortOrder);
                    cmd.Parameters.AddWithValue("@minscore", minscore);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);






                    DataSet ds = new DataSet();

                    da.Fill(ds);


                    DataTable dt = ds.Tables[0];

                    return dt;
                    /*

                    if (dt.Rows.Count > 0)
                    {

                        RepDetails.DataSource = dt;
                        RepDetails.DataBind();

                 






                    }
                   */



                }




            }
        }

        public static DataTable GetCountries(string continent, string geo, string country, string state, string statename, string city, string category, string subcategory, int n, int sortOrder)
        {


            string sp = "countries_search";


            string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent", continent);
                    cmd.Parameters.AddWithValue("@geo", geo);
                    cmd.Parameters.AddWithValue("@Country", country);

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

        public static DataTable GetCountries(string continent, string geo, string country,  int n, int sortOrder)
        {


            string sp = "countries_search_v6";


            string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;


                  

                    if (string.Compare(continent, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@continent", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@continent", continent);
                    }

                    if (string.Compare(geo, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@geo", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@geo", geo);
                    }

                    if (string.Compare(country, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@country", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@country", country);
                    }

                   

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
        public static DataTable GetCountries( int n, int sortOrder)
        {


            string sp = "countries_search_v6";


            string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;




          
                        cmd.Parameters.AddWithValue("@continent", DBNull.Value);
                  
                    
                        cmd.Parameters.AddWithValue("@geo", DBNull.Value);
                    

                    
                        cmd.Parameters.AddWithValue("@country", DBNull.Value);
                   



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

        public static DataTable GetRegions(string continent, string geo, string country, string state, string statename, string city, string category, string subcategory, int n, int sortOrder)
        {


            string sp = "regions_v3";


            string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {



                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Continent", continent);
                    cmd.Parameters.AddWithValue("@Country", country);
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

        public static DataTable GetRegions(string continent, string geo, string country,   int n, int sortOrder, int minscore)
        {


            string sp = "regions_v6";


            string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {



                    cmd.CommandType = CommandType.StoredProcedure;




                    if (string.Compare(continent, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@continent", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@continent", continent);
                    }


                    if (string.Compare(geo, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@geo", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@geo", geo);
                    }

                    if (string.Compare(country, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@country", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@country", country);
                    }

                    

                    cmd.Parameters.AddWithValue("@n", n);
                    cmd.Parameters.AddWithValue("@SortOrder", sortOrder);
                    cmd.Parameters.AddWithValue("@minscore", minscore);


             


                    SqlDataAdapter da = new SqlDataAdapter(cmd);






                    DataSet ds = new DataSet();

                    da.Fill(ds);


                    DataTable dt = ds.Tables[0];

                    return dt;




                }

            }





        }

        public static DataTable GetRegionsfromPlaces( string country, int n, int sortOrder)
        {


            string sp = "regions_from_places";


            string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {



                    cmd.CommandType = CommandType.StoredProcedure;




                  
                    if (string.Compare(country, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@country", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@country", country);
                    }

                    if (n == null)
                    {
                        cmd.Parameters.AddWithValue("@n", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@n", n);
                    }

                    if (sortOrder == null)
                    {
                        cmd.Parameters.AddWithValue("@sortOrder", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@SortOrder", sortOrder);
                    }


                  





                    SqlDataAdapter da = new SqlDataAdapter(cmd);






                    DataSet ds = new DataSet();

                    da.Fill(ds);


                    DataTable dt = ds.Tables[0];

                    return dt;




                }

            }





        }
        public static DataTable GetCitiesfromPlaces(string country, string state, string statename, int n, int sortOrder)
        {


            string sp = "cities_from_places";


            string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {



                    cmd.CommandType = CommandType.StoredProcedure;





                    if (string.Compare(country, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@country", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@country", country);
                    }
                    if (string.Compare(state, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@state", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@state", state);
                    }

                    if (string.Compare(statename, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@statename", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@statename", statename);
                    }

                    if (n == null)
                    {
                        cmd.Parameters.AddWithValue("@n", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@n", n);
                    }

                    if (sortOrder == null)
                    {
                        cmd.Parameters.AddWithValue("@sortOrder", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@SortOrder", sortOrder);
                    }








                    SqlDataAdapter da = new SqlDataAdapter(cmd);






                    DataSet ds = new DataSet();

                    da.Fill(ds);


                    DataTable dt = ds.Tables[0];

                    return dt;




                }

            }





        }

        public static DataTable GetCities(string continent, string geo, string country, string state, string statename, string city, string category, string subcategory, int n, int sortOrder)
        {

            /* SortOrder 3 for rank1
           
WHEN 1 THEN  ct.cityid
WHEN  2 THEN ct.cityid
WHEN 3 THEN ct.rank1
WHEN 4 THEN ct.rank2
WHEN 5 THEN ct.rank3  */


            string sp = "cities_search_v2";


            string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {



                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Continent", continent);
                    cmd.Parameters.AddWithValue("@Country", country);
                    cmd.Parameters.AddWithValue("@Region", "all");
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

        public static DataTable GetCities( string continent, string geo, string country, string state,  string city, int n, int sortOrder)
        {

            /* SortOrder 3 for rank1
           
WHEN 1 THEN  ct.cityid
WHEN  2 THEN ct.cityid
WHEN 3 THEN ct.rank1
WHEN 4 THEN ct.rank2
WHEN 5 THEN ct.rank3  */


            string sp = "cities_search_v6";


            string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {



                    cmd.CommandType = CommandType.StoredProcedure;



                    if (string.Compare(continent, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@continent", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@continent", continent);
                    }

                    if (string.Compare(geo, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@geo", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@geo", geo);
                    }

                    if (string.Compare(country, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@country", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@country", country);
                    }

                    if (string.Compare(country, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@region", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@region", state);
                    }

                    
                  
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
        public static DataTable GetPlaces(string continent, string country, string state, string statename, string city, string category, string subcategory, int n, int sortOrder)
        {


            string sp = "best_tourist_places_search_v4";



            string connect = System.Configuration.ConfigurationManager.ConnectionStrings["films"].ConnectionString;


            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@continent", continent);
                    cmd.Parameters.AddWithValue("@country", country);
                    cmd.Parameters.AddWithValue("@state", state);
                    cmd.Parameters.AddWithValue("@statename", statename);
                    cmd.Parameters.AddWithValue("@city", city);
                    cmd.Parameters.AddWithValue("@category", category);

                    cmd.Parameters.AddWithValue("@subcategory", subcategory);


                    cmd.Parameters.AddWithValue("@n", n);
                    cmd.Parameters.AddWithValue("@SortOrder", sortOrder);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);






                    DataSet ds = new DataSet();

                    da.Fill(ds);


                    DataTable dt = ds.Tables[0];

                    return dt;
                    /*

                    if (dt.Rows.Count > 0)
                    {

                        RepDetails.DataSource = dt;
                        RepDetails.DataBind();

                 






                    }
                   */



                }




            }
        }

        public static DataTable GetTouristPackages(string continent, string country, string state, string statename, string city, string category, string subcategory, int n, int sortOrder)
        {


            string sp = "tourist_package_search";


            string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;


            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@country", country);
                    cmd.Parameters.AddWithValue("@region", state);


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


        public static DataTable GetStateType(string continent, string country, string state, string statename, string city, string category, string subcategory, int n, int sortOrder, string type)
        {


            string sp = "tourist_places_state_type";


            string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;


            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@country", country);
                    cmd.Parameters.AddWithValue("@region", state);
                    cmd.Parameters.AddWithValue("@type", type);


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


        public static DataTable GetCommaSeperatedTouristPlacesDetails(string continent, string country, string state, string statename, string city, string category, string subcategory, int n, int sortOrder, string keyword)
        {


            string sp = "tourist_places_Comma_list_detail";


            string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;


            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@country", country);
                    cmd.Parameters.AddWithValue("@region", state);



                    cmd.Parameters.AddWithValue("@n", n);
                    cmd.Parameters.AddWithValue("@SortOrder", sortOrder);
                    cmd.Parameters.AddWithValue("@Keyword", keyword);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);






                    DataSet ds = new DataSet();

                    da.Fill(ds);


                    DataTable dt = ds.Tables[0];

                    return dt;





                }




            }
        }


        public static DataTable GetCommaSeperatedTouristPlacesList(string continent, string country, string state, string statename, string city, string category, string subcategory, int n, int sortOrder)
        {


            string sp = "tourist_places_Comma_list";


            string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;


            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@country", country);
                    cmd.Parameters.AddWithValue("@region", state);



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

        public static DataTable GetWildLife(string continent, string country, string state, string statename, string city, string category, string subcategory, int n, int sortOrder, int direction, int spin)
        {


            string sp = "wildlife_search";


            string connect = ConfigurationManager.ConnectionStrings["astrology"].ConnectionString;


            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@country", country);
                    cmd.Parameters.AddWithValue("@region", state);
                    cmd.Parameters.AddWithValue("@city", city);


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


        public static DataTable GetTopics(string continent, string country, string state, string statename, string city, string name, string category, string subcategory, int n, int sortOrder, int direction, int spin)
        {


            string sp = "topics_search";


            string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;


            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;



                    cmd.Parameters.AddWithValue("@continent", continent);
                    cmd.Parameters.AddWithValue("@country", country);
                    cmd.Parameters.AddWithValue("@state", state);
                    cmd.Parameters.AddWithValue("@statename", statename);
                    cmd.Parameters.AddWithValue("@city", city);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@category", category);

                    cmd.Parameters.AddWithValue("@subcategory", subcategory);


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

        public static DataTable GetTouristPlaceDetails(string name, string country)
        {


            string sp = "tourist_detail";



            string connect = System.Configuration.ConfigurationManager.ConnectionStrings["films"].ConnectionString;


            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@country", country);
                 

                    SqlDataAdapter da = new SqlDataAdapter(cmd);






                    DataSet ds = new DataSet();

                    da.Fill(ds);


                    DataTable dt = ds.Tables[0];

                    return dt;
                    /*

                    if (dt.Rows.Count > 0)
                    {

                        RepDetails.DataSource = dt;
                        RepDetails.DataBind();

                 






                    }
                   */



                }




            }
        }
        public static DataTable GetTouristPlaceDetails(string name)
        {


            string sp = "tourist_detail_v2";



            string connect = System.Configuration.ConfigurationManager.ConnectionStrings["films"].ConnectionString;


            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@name", name);
                


                    SqlDataAdapter da = new SqlDataAdapter(cmd);






                    DataSet ds = new DataSet();

                    da.Fill(ds);


                    DataTable dt = ds.Tables[0];

                    return dt;
                    /*

                    if (dt.Rows.Count > 0)
                    {

                        RepDetails.DataSource = dt;
                        RepDetails.DataBind();

                 






                    }
                   */



                }




            }
        }
        public static DataTable GetTouristPlaceDetails(string name, string category, int n, int sortOrder)
        {


            string sp = "tourist_detail_search";



            string connect = System.Configuration.ConfigurationManager.ConnectionStrings["films"].ConnectionString;


            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@biz_name", name);
                     cmd.Parameters.AddWithValue("@category", category);
                     cmd.Parameters.AddWithValue("@n", n);
                     cmd.Parameters.AddWithValue("@sortOrder", sortOrder);


                    SqlDataAdapter da = new SqlDataAdapter(cmd);






                    DataSet ds = new DataSet();

                    da.Fill(ds);


                    DataTable dt = ds.Tables[0];

                    return dt;
                    /*

                    if (dt.Rows.Count > 0)
                    {

                        RepDetails.DataSource = dt;
                        RepDetails.DataBind();

                 






                    }
                   */



                }




            }
        }


        public static DataTable GetBusinessTypes()
        {


            string sp = "business_types";



            string connect = System.Configuration.ConfigurationManager.ConnectionStrings["films"].ConnectionString;


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
    }

}
