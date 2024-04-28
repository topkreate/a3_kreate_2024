using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Data.SqlClient;

namespace KreateWebsites
{
    public class YellowPages
    {


        public static DataTable GetShops(string continent, string country, string state, string statename, string city, string category, string subcategory, string category3, string name, int n, int sortOrder,  int direction, int spin)
        {


            string sp = "shops_search";


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

                    if (string.Compare(continent, null) == 0)
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


                    if (string.Compare(state, null) == 0)
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

                        cmd.Parameters.AddWithValue("@category3", category3);
                    }


                    if (string.Compare(name, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@name", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@name", name);
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

        public static DataTable GetShops( string city, string category, string subcategory, string category3, string name, int n, int sortOrder, int direction, int spin)
        {


            string sp = "shops_search";


            string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;


            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;


                   
                        cmd.Parameters.AddWithValue("@continent", DBNull.Value);
                    

                   
                        cmd.Parameters.AddWithValue("@country", DBNull.Value);
                   

                   
                        cmd.Parameters.AddWithValue("@state", DBNull.Value);
                   


                    
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

                        cmd.Parameters.AddWithValue("@category3", category3);
                    }


                    if (string.Compare(name, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@name", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@name", name);
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


        public static DataTable GetShops(string city, string category, string subcategory, string category3, string name, int n)
        {


            string sp = "shops_search";


            string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;


            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;



                    cmd.Parameters.AddWithValue("@continent", DBNull.Value);



                    cmd.Parameters.AddWithValue("@country", DBNull.Value);



                    cmd.Parameters.AddWithValue("@state", DBNull.Value);




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

                        cmd.Parameters.AddWithValue("@category3", category3);
                    }


                    if (string.Compare(name, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@name", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                    }





                    cmd.Parameters.AddWithValue("@n", n);
                    cmd.Parameters.AddWithValue("@SortOrder", DBNull.Value);
                    cmd.Parameters.AddWithValue("@direction", DBNull.Value);
                    cmd.Parameters.AddWithValue("@spin", DBNull.Value);



                    SqlDataAdapter da = new SqlDataAdapter(cmd);






                    DataSet ds = new DataSet();

                    da.Fill(ds);


                    DataTable dt = ds.Tables[0];

                    return dt;





                }




            }
        }

        public static DataTable GetShops(string city,  int n)
        {


            string sp = "shops_search";


            string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;


            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;



                    cmd.Parameters.AddWithValue("@continent", DBNull.Value);



                    cmd.Parameters.AddWithValue("@country", DBNull.Value);



                    cmd.Parameters.AddWithValue("@state", DBNull.Value);




                    cmd.Parameters.AddWithValue("@statename", DBNull.Value);


                    if (string.Compare(city, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@city", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@city", city);
                    }


                   
                        cmd.Parameters.AddWithValue("@category", DBNull.Value);
                   

                        cmd.Parameters.AddWithValue("@subcategory", DBNull.Value);
                   



                        cmd.Parameters.AddWithValue("@category3", DBNull.Value);
                    

                    
                        cmd.Parameters.AddWithValue("@name", DBNull.Value);
                   




                    cmd.Parameters.AddWithValue("@n", n);
                    cmd.Parameters.AddWithValue("@SortOrder", DBNull.Value);
                    cmd.Parameters.AddWithValue("@direction", DBNull.Value);
                    cmd.Parameters.AddWithValue("@spin", DBNull.Value);



                    SqlDataAdapter da = new SqlDataAdapter(cmd);






                    DataSet ds = new DataSet();

                    da.Fill(ds);


                    DataTable dt = ds.Tables[0];

                    return dt;





                }




            }
        }


        public static DataTable GetShopSubcategory(string city, string category, int n)
        {


            string sp = "shops_subcategory";


            string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;


            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;



                    cmd.Parameters.AddWithValue("@continent", DBNull.Value);



                    cmd.Parameters.AddWithValue("@country", DBNull.Value);



                    cmd.Parameters.AddWithValue("@state", DBNull.Value);




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

                   // cmd.Parameters.AddWithValue("@subcategory", DBNull.Value);




                //    cmd.Parameters.AddWithValue("@category3", DBNull.Value);



                  //  cmd.Parameters.AddWithValue("@name", DBNull.Value);





                    cmd.Parameters.AddWithValue("@n", n);
                    cmd.Parameters.AddWithValue("@SortOrder", DBNull.Value);
                    cmd.Parameters.AddWithValue("@direction", DBNull.Value);
                    cmd.Parameters.AddWithValue("@spin", DBNull.Value);



                    SqlDataAdapter da = new SqlDataAdapter(cmd);






                    DataSet ds = new DataSet();

                    da.Fill(ds);


                    DataTable dt = ds.Tables[0];

                    return dt;





                }




            }
        }

        public static DataTable GetShopCategory(string city, int n)
        {


            string sp = "shops_category";


            string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;


            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;



                    cmd.Parameters.AddWithValue("@continent", DBNull.Value);



                    cmd.Parameters.AddWithValue("@country", DBNull.Value);



                    cmd.Parameters.AddWithValue("@state", DBNull.Value);




                    cmd.Parameters.AddWithValue("@statename", DBNull.Value);


                    if (string.Compare(city, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@city", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@city", city);
                    }


                
                   //     cmd.Parameters.AddWithValue("@category", DBNull.Value);
                   

                   // cmd.Parameters.AddWithValue("@subcategory", DBNull.Value);




                //    cmd.Parameters.AddWithValue("@category3", DBNull.Value);



               //     cmd.Parameters.AddWithValue("@name", DBNull.Value);





                    cmd.Parameters.AddWithValue("@n", n);
                    cmd.Parameters.AddWithValue("@SortOrder", DBNull.Value);
                    cmd.Parameters.AddWithValue("@direction", DBNull.Value);
                    cmd.Parameters.AddWithValue("@spin", DBNull.Value);



                    SqlDataAdapter da = new SqlDataAdapter(cmd);






                    DataSet ds = new DataSet();

                    da.Fill(ds);


                    DataTable dt = ds.Tables[0];

                    return dt;





                }




            }
        }

        public static DataTable GetShopCity()
        {


            string sp = "shops_city";


            string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;


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
                    



                    //     cmd.Parameters.AddWithValue("@category", DBNull.Value);


                    // cmd.Parameters.AddWithValue("@subcategory", DBNull.Value);




                    //    cmd.Parameters.AddWithValue("@category3", DBNull.Value);



                    //     cmd.Parameters.AddWithValue("@name", DBNull.Value);





                    cmd.Parameters.AddWithValue("@n", 200);
                    cmd.Parameters.AddWithValue("@SortOrder", DBNull.Value);
                    cmd.Parameters.AddWithValue("@direction", DBNull.Value);
                    cmd.Parameters.AddWithValue("@spin", DBNull.Value);



                    SqlDataAdapter da = new SqlDataAdapter(cmd);






                    DataSet ds = new DataSet();

                    da.Fill(ds);


                    DataTable dt = ds.Tables[0];

                    return dt;





                }




            }
        }


        public static DataTable GetYellowPages(string city, int n)
        {


            string sp = "yellowpages_search";


            string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;


            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;



                    cmd.Parameters.AddWithValue("@continent", DBNull.Value);



                    cmd.Parameters.AddWithValue("@country", DBNull.Value);



                    cmd.Parameters.AddWithValue("@state", DBNull.Value);




                    cmd.Parameters.AddWithValue("@statename", DBNull.Value);


                    if (string.Compare(city, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@city", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@city", city);
                    }



                    cmd.Parameters.AddWithValue("@category", DBNull.Value);


                    cmd.Parameters.AddWithValue("@subcategory", DBNull.Value);




                    cmd.Parameters.AddWithValue("@category3", DBNull.Value);



                    cmd.Parameters.AddWithValue("@name", DBNull.Value);





                    cmd.Parameters.AddWithValue("@n", n);
                    cmd.Parameters.AddWithValue("@SortOrder", DBNull.Value);
                    cmd.Parameters.AddWithValue("@direction", DBNull.Value);
                    cmd.Parameters.AddWithValue("@spin", DBNull.Value);



                    SqlDataAdapter da = new SqlDataAdapter(cmd);






                    DataSet ds = new DataSet();

                    da.Fill(ds);


                    DataTable dt = ds.Tables[0];

                    return dt;





                }




            }
        }

        public static DataTable GetYellowPages(string country, string city, string category, string subcategory, int n)
        {


            string sp = "yellowpages_search";


            string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;


            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;



                    cmd.Parameters.AddWithValue("@continent", DBNull.Value);


                    if (string.Compare(country, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@country", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@country", country);
                    }

                    cmd.Parameters.AddWithValue("@state", DBNull.Value);




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
                    


                    cmd.Parameters.AddWithValue("@category3", DBNull.Value);



                    cmd.Parameters.AddWithValue("@name", DBNull.Value);





                    cmd.Parameters.AddWithValue("@n", n);

                 
                        cmd.Parameters.AddWithValue("@SortOrder", DBNull.Value);
                    
                        cmd.Parameters.AddWithValue("@direction", DBNull.Value);
                    
                        cmd.Parameters.AddWithValue("@spin", DBNull.Value);
                    



                    SqlDataAdapter da = new SqlDataAdapter(cmd);






                    DataSet ds = new DataSet();

                    da.Fill(ds);


                    DataTable dt = ds.Tables[0];

                    return dt;





                }




            }
        }

        public static DataTable GetYellowPages(string country, string city, string category, string subcategory, int n, int sortOrder, int direction, int spin)
        {


            string sp = "yellowpages_search";


            string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;


            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;



                    cmd.Parameters.AddWithValue("@continent", DBNull.Value);


                    if (string.Compare(city, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@country", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@country", country);
                    }

                    cmd.Parameters.AddWithValue("@state", DBNull.Value);




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



                    cmd.Parameters.AddWithValue("@category3", DBNull.Value);



                    cmd.Parameters.AddWithValue("@name", DBNull.Value);





                    cmd.Parameters.AddWithValue("@n", n);

                    if (sortOrder == null)
                    {
                        cmd.Parameters.AddWithValue("@SortOrder", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@SortOrder", sortOrder);
                    }

                    if (direction == null)
                    {
                        cmd.Parameters.AddWithValue("@direction", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@direction", direction);

                    }

                    if (spin == null)
                    {
                        cmd.Parameters.AddWithValue("@spin", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@spin", spin);
                    }



                    SqlDataAdapter da = new SqlDataAdapter(cmd);






                    DataSet ds = new DataSet();

                    da.Fill(ds);


                    DataTable dt = ds.Tables[0];

                    return dt;





                }




            }
        }

        public static DataTable GetBusinessDetails(string country, string city, string category, string subcategory, string name, int n )
        {


            string sp = "yellowpages_search";


            string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;


            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;



                    cmd.Parameters.AddWithValue("@continent", DBNull.Value);


                    if (string.Compare(country, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@country", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@country", country);
                    }

                    cmd.Parameters.AddWithValue("@state", DBNull.Value);




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



                    cmd.Parameters.AddWithValue("@category3", DBNull.Value);



                    cmd.Parameters.AddWithValue("@name", name);



              
                        cmd.Parameters.AddWithValue("@n", n);
              
                    
                    
                 
                        cmd.Parameters.AddWithValue("@SortOrder", DBNull.Value);
                   
                        cmd.Parameters.AddWithValue("@direction", DBNull.Value);
                   
                     

                   

                   
                        cmd.Parameters.AddWithValue("@spin", DBNull.Value);
                   
            
                   



                    SqlDataAdapter da = new SqlDataAdapter(cmd);






                    DataSet ds = new DataSet();

                    da.Fill(ds);


                    DataTable dt = ds.Tables[0];

                    return dt;





                }




            }
        }


        public static DataTable GetYellowPagesSubcategory(string city, string category, int n)
        {


            string sp = "yellowpages_subcategory";


            string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;


            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;



                    cmd.Parameters.AddWithValue("@continent", DBNull.Value);



                    cmd.Parameters.AddWithValue("@country", DBNull.Value);



                    cmd.Parameters.AddWithValue("@state", DBNull.Value);




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

                    // cmd.Parameters.AddWithValue("@subcategory", DBNull.Value);




                    //    cmd.Parameters.AddWithValue("@category3", DBNull.Value);



                    //  cmd.Parameters.AddWithValue("@name", DBNull.Value);





                    cmd.Parameters.AddWithValue("@n", n);
                    cmd.Parameters.AddWithValue("@SortOrder", DBNull.Value);
                    cmd.Parameters.AddWithValue("@direction", DBNull.Value);
                    cmd.Parameters.AddWithValue("@spin", DBNull.Value);



                    SqlDataAdapter da = new SqlDataAdapter(cmd);






                    DataSet ds = new DataSet();

                    da.Fill(ds);


                    DataTable dt = ds.Tables[0];

                    return dt;





                }




            }
        }

        public static DataTable GetYellowPagesCategory(string city, int n)
        {


            string sp = "yellowpages_category";


            string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;


            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;



                    cmd.Parameters.AddWithValue("@continent", DBNull.Value);



                    cmd.Parameters.AddWithValue("@country", DBNull.Value);



                    cmd.Parameters.AddWithValue("@state", DBNull.Value);




                    cmd.Parameters.AddWithValue("@statename", DBNull.Value);


                    if (string.Compare(city, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@city", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@city", city);
                    }



                    //     cmd.Parameters.AddWithValue("@category", DBNull.Value);


                    // cmd.Parameters.AddWithValue("@subcategory", DBNull.Value);




                    //    cmd.Parameters.AddWithValue("@category3", DBNull.Value);



                    //     cmd.Parameters.AddWithValue("@name", DBNull.Value);





                    cmd.Parameters.AddWithValue("@n", n);
                    cmd.Parameters.AddWithValue("@SortOrder", DBNull.Value);
                    cmd.Parameters.AddWithValue("@direction", DBNull.Value);
                    cmd.Parameters.AddWithValue("@spin", DBNull.Value);



                    SqlDataAdapter da = new SqlDataAdapter(cmd);






                    DataSet ds = new DataSet();

                    da.Fill(ds);


                    DataTable dt = ds.Tables[0];

                    return dt;





                }




            }
        }

        public static DataTable GetYellowPagesCategory( int n)
        {


            string sp = "yellowpages_only_category";


            string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;


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

        public static DataTable GetYellowPagesCity()
        {


            string sp = "yellowpages_city";


            string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;


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




                    //     cmd.Parameters.AddWithValue("@category", DBNull.Value);


                    // cmd.Parameters.AddWithValue("@subcategory", DBNull.Value);




                    //    cmd.Parameters.AddWithValue("@category3", DBNull.Value);



                    //     cmd.Parameters.AddWithValue("@name", DBNull.Value);





                    cmd.Parameters.AddWithValue("@n", 200);
                    cmd.Parameters.AddWithValue("@SortOrder", DBNull.Value);
                    cmd.Parameters.AddWithValue("@direction", DBNull.Value);
                    cmd.Parameters.AddWithValue("@spin", DBNull.Value);



                    SqlDataAdapter da = new SqlDataAdapter(cmd);






                    DataSet ds = new DataSet();

                    da.Fill(ds);


                    DataTable dt = ds.Tables[0];

                    return dt;





                }




            }
        }

        public static DataTable GetYellowPagesCity(string country)
        {


            string sp = "yellowpages_city";


            string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;


            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;



                    cmd.Parameters.AddWithValue("@continent", DBNull.Value);

                    if (string.Compare(country, null) == 0)
                    {

                        cmd.Parameters.AddWithValue("@country", DBNull.Value);

                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@country", country);
                    }

                    cmd.Parameters.AddWithValue("@state", DBNull.Value);




                    cmd.Parameters.AddWithValue("@statename", DBNull.Value);



                    cmd.Parameters.AddWithValue("@city", DBNull.Value);




                    //     cmd.Parameters.AddWithValue("@category", DBNull.Value);


                    // cmd.Parameters.AddWithValue("@subcategory", DBNull.Value);




                    //    cmd.Parameters.AddWithValue("@category3", DBNull.Value);



                    //     cmd.Parameters.AddWithValue("@name", DBNull.Value);





                    cmd.Parameters.AddWithValue("@n", 200);
                    cmd.Parameters.AddWithValue("@SortOrder", DBNull.Value);
                    cmd.Parameters.AddWithValue("@direction", DBNull.Value);
                    cmd.Parameters.AddWithValue("@spin", DBNull.Value);



                    SqlDataAdapter da = new SqlDataAdapter(cmd);






                    DataSet ds = new DataSet();

                    da.Fill(ds);


                    DataTable dt = ds.Tables[0];

                    return dt;





                }




            }
        }

        public static DataTable GetYellowPagesCountry()
        {


            string sp = "yellowpages_country";


            string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;


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




                    //     cmd.Parameters.AddWithValue("@category", DBNull.Value);


                    // cmd.Parameters.AddWithValue("@subcategory", DBNull.Value);




                    //    cmd.Parameters.AddWithValue("@category3", DBNull.Value);



                    //     cmd.Parameters.AddWithValue("@name", DBNull.Value);





                    cmd.Parameters.AddWithValue("@n", 200);
                    cmd.Parameters.AddWithValue("@SortOrder", DBNull.Value);
                    cmd.Parameters.AddWithValue("@direction", DBNull.Value);
                    cmd.Parameters.AddWithValue("@spin", DBNull.Value);



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

