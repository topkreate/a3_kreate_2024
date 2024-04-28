using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Data.SqlClient;

namespace KreateWebsites
{
    public class Websites
    {
        public static DataTable GetWebsites(string continent, string country, string state, string statename, string city, string category, string subcategory, string category3, int n, int sortOrder, string name, string server, int direction, int spin)
        {


            string sp = "my_search";


            string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;


            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;


                    if (string.Compare(category, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@category1", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@category1", category);
                    }


                    if (string.Compare(subcategory, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@category2", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@category2", subcategory);
                    }
                 /*   cmd.Parameters.AddWithValue("@category3", category3);
                    
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@server", server);
                  * */






                    if (string.Compare(category3, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@category3", DBNull.Value);
                    }
                    else
                    {

                        cmd.Parameters.AddWithValue("@category3", DBNull.Value);
                    }


                    if (string.Compare(name, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@name", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                    }

                    if (string.Compare(server, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@server", DBNull.Value);

                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@server", server);
                    }

                  


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

        public static DataTable GetFeaturedPage(string pagepath,  int n, int sortOrder, int direction, int spin)
        {


            string sp = "featured_search_v2";


            string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pagepath", pagepath);
                    


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

        public static DataTable GetFeaturedPage(string category, string subcategory, string country,  int n, int sortOrder, int direction, int spin)

         
        {


            string sp = "featured_search";


            string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@category", category);
                    cmd.Parameters.AddWithValue("@category2", subcategory);
                    cmd.Parameters.AddWithValue("@country", country);

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

        public static DataTable GetLinks(string category, string subcategory, string category3, string name, string server,  int n, int sortOrder, int direction, int spin)
        {

            string sp = "links_search";


            string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@category1", category);
                    cmd.Parameters.AddWithValue("@category2", subcategory);
                    cmd.Parameters.AddWithValue("@category3", category3);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@name", server);
              

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

        public static DataTable GetOurWebSites(string category, string subcategory, string category3, string name, string server, int n, int sortOrder, int direction, int spin)
        {
         
            string sp = "my_search";


            string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@category1", category);
                    cmd.Parameters.AddWithValue("@category2", subcategory);
                    cmd.Parameters.AddWithValue("@category3", category3);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@name", server);


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
        public static DataTable GetWallpapers(int id, string category, string subcategory, string topic, string size, string name, int n, int sortOrder)
        {


            string sp = "wallpapers_search";


            string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;


            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", id);


                    cmd.Parameters.AddWithValue("@category", category);
                    cmd.Parameters.AddWithValue("@category2", subcategory);
                    cmd.Parameters.AddWithValue("@topic", topic);
                    cmd.Parameters.AddWithValue("@size", size);
                    cmd.Parameters.AddWithValue("@name", name);
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

        public static DataTable GetWebDetailSearch( string title, string category,  int n, int sortOrder, int spin)
        {
           

            string sp = "web_details_search";


            string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;


            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;

    


                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@category", category);
                    cmd.Parameters.AddWithValue("@n", n);
                    cmd.Parameters.AddWithValue("@SortOrder", sortOrder);
                    cmd.Parameters.AddWithValue("@spin", spin);


                    SqlDataAdapter da = new SqlDataAdapter(cmd);






                    DataSet ds = new DataSet();

                    da.Fill(ds);


                    DataTable dt = ds.Tables[0];

                    return dt;





                }




            }
        }

        public static DataTable GetTopics(string category1, string category2, string category3, string category4, int n, int sortOrder, int direction, int spin)
        {


  

            string sp = "topics_search";


            string connect = ConfigurationManager.ConnectionStrings["astrology"].ConnectionString;


            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;




           
                    cmd.Parameters.AddWithValue("@category1", category1);
                    cmd.Parameters.AddWithValue("@category2", category2);
                    cmd.Parameters.AddWithValue("@category3", category3);
                    cmd.Parameters.AddWithValue("@category4", category4);
                    cmd.Parameters.AddWithValue("@category", category1);
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

        public static DataTable GetWebsitesCategory()
        {




            string sp = "my_search_category";


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

        public static DataTable GetSubdomains(string domain,   int n)
        {




            string sp = "get_subdomains";


            string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;


            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;





                    cmd.Parameters.AddWithValue("@domain", domain);
                
                    cmd.Parameters.AddWithValue("@n", n);
                    


                    SqlDataAdapter da = new SqlDataAdapter(cmd);






                    DataSet ds = new DataSet();

                    da.Fill(ds);


                    DataTable dt = ds.Tables[0];

                    return dt;





                }




            }
        }


        public static DataTable GetSubname(string domain, int n)
        {




            string sp = "get_subname";


            string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;


            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;





                    cmd.Parameters.AddWithValue("@domain", domain);

                    cmd.Parameters.AddWithValue("@n", n);



                    SqlDataAdapter da = new SqlDataAdapter(cmd);






                    DataSet ds = new DataSet();

                    da.Fill(ds);


                    DataTable dt = ds.Tables[0];

                    return dt;





                }




            }
        }


        public static DataTable GetImages(string category, int n)
        {




            string sp = "image_search";


            string connect = ConfigurationManager.ConnectionStrings["astrology"].ConnectionString;


            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.AddWithValue("@continent", DBNull.Value);
                    cmd.Parameters.AddWithValue("@country", DBNull.Value);
                    cmd.Parameters.AddWithValue("@state", DBNull.Value);
                    cmd.Parameters.AddWithValue("@statename", DBNull.Value);
                    cmd.Parameters.AddWithValue("@city", DBNull.Value);
                    cmd.Parameters.AddWithValue("@category", category);
                
                    cmd.Parameters.AddWithValue("@biz_name", DBNull.Value);
                    cmd.Parameters.AddWithValue("@subcategory", DBNull.Value);
                    cmd.Parameters.AddWithValue("@type", DBNull.Value);
                    cmd.Parameters.AddWithValue("@height", DBNull.Value);
                    cmd.Parameters.AddWithValue("@width", DBNull.Value);

                    cmd.Parameters.AddWithValue("@n", n);

                    cmd.Parameters.AddWithValue("@SortOrder", 1);
                    cmd.Parameters.AddWithValue("@direction", 1);
                    cmd.Parameters.AddWithValue("@spin", 1);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);






                    DataSet ds = new DataSet();

                    da.Fill(ds);


                    DataTable dt = ds.Tables[0];

                    return dt;





                }




            }
        }

        public static DataTable GetImages(string country, string name, int n)
        {




            string sp = "image_search";


            string connect = ConfigurationManager.ConnectionStrings["astrology"].ConnectionString;


            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.AddWithValue("@continent", DBNull.Value);
                    cmd.Parameters.AddWithValue("@country", country);
                    cmd.Parameters.AddWithValue("@state", DBNull.Value);
                    cmd.Parameters.AddWithValue("@statename", DBNull.Value);
                    cmd.Parameters.AddWithValue("@city", DBNull.Value);
                    cmd.Parameters.AddWithValue("@category", DBNull.Value);

                    cmd.Parameters.AddWithValue("@biz_name", name);
                    cmd.Parameters.AddWithValue("@subcategory", DBNull.Value);
                    cmd.Parameters.AddWithValue("@type", DBNull.Value);
                    cmd.Parameters.AddWithValue("@height", DBNull.Value);
                    cmd.Parameters.AddWithValue("@width", DBNull.Value);

                    cmd.Parameters.AddWithValue("@n", n);

                    cmd.Parameters.AddWithValue("@SortOrder", 1);
                    cmd.Parameters.AddWithValue("@direction", 1);
                    cmd.Parameters.AddWithValue("@spin", 1);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);






                    DataSet ds = new DataSet();

                    da.Fill(ds);


                    DataTable dt = ds.Tables[0];

                    return dt;





                }




            }
        }

        public static DataTable GetImages(string continent, string country, string state, string statename, string city, string category, string name,  string subcategory, string type, int height, int width, int n, int sortOrder, int direction, int spin)
        {

   


            string sp = "image_search";


            string connect = ConfigurationManager.ConnectionStrings["astrology"].ConnectionString;


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

                    if (string.Compare(name, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@biz_name", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@biz_name", name);
                    }

                    if (string.Compare(type, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@type", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@type", type);
                    }


                  

                    cmd.Parameters.AddWithValue("@height", DBNull.Value);
                    cmd.Parameters.AddWithValue("@width", DBNull.Value);

                    cmd.Parameters.AddWithValue("@n", n);

                    cmd.Parameters.AddWithValue("@SortOrder", 1);
                    cmd.Parameters.AddWithValue("@direction", 1);
                    cmd.Parameters.AddWithValue("@spin", 1);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);






                    DataSet ds = new DataSet();

                    da.Fill(ds);


                    DataTable dt = ds.Tables[0];

                    return dt;





                }




            }
        }


        public static DataTable GetImages(string continent, string country, string state, string statename, string city, string category, string name, string subcategory, string type,  int n, int sortOrder, int direction, int spin)
        {




            string sp = "image_search";


            string connect = ConfigurationManager.ConnectionStrings["astrology"].ConnectionString;


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

                    if (string.Compare(name, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@biz_name", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@biz_name", name);
                    }

                    if (string.Compare(type, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@type", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@type", type);
                    }




                    cmd.Parameters.AddWithValue("@height", DBNull.Value);
                    cmd.Parameters.AddWithValue("@width", DBNull.Value);

                    cmd.Parameters.AddWithValue("@n", n);

                    cmd.Parameters.AddWithValue("@SortOrder", 1);
                    cmd.Parameters.AddWithValue("@direction", 1);
                    cmd.Parameters.AddWithValue("@spin", 1);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);






                    DataSet ds = new DataSet();

                    da.Fill(ds);


                    DataTable dt = ds.Tables[0];

                    return dt;





                }




            }
        }

        public static DataTable GetAlbums(string continent, string country, string state, string statename, string city, string category, string name, string subcategory, string type, int n, int sortOrder, int direction, int spin)
        {




            string sp = "album_search";


            string connect = ConfigurationManager.ConnectionStrings["astrology"].ConnectionString;


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

                    if (string.Compare(name, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@biz_name", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@biz_name", name);
                    }

                    if (string.Compare(type, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@type", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@type", type);
                    }




                    cmd.Parameters.AddWithValue("@height", DBNull.Value);
                    cmd.Parameters.AddWithValue("@width", DBNull.Value);

                    cmd.Parameters.AddWithValue("@n", n);

                    cmd.Parameters.AddWithValue("@SortOrder", 1);
                    cmd.Parameters.AddWithValue("@direction", 1);
                    cmd.Parameters.AddWithValue("@spin", 1);

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
