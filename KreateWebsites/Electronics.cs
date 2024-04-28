using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Data.SqlClient;

namespace KreateWebsites
{
    public class Electronics
    {


        public static DataTable GetMobiles(string company, string os, string osversion, string model, string category,  int n, int sortOrder, int direction, int spin)
        {
  

            string sp = "model_search";


            string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@company", company);
                    cmd.Parameters.AddWithValue("@os", os);
                    cmd.Parameters.AddWithValue("@osversion", osversion);
                    cmd.Parameters.AddWithValue("@model", model);
                    cmd.Parameters.AddWithValue("@category", category);
                 

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

        public static DataTable GetMobiles(DateTime startdate, DateTime enddate, string company, string os, string osversion, string model, string category, int n, int sortOrder, int direction, int spin)
        {


            string sp = "model_search_period";


            string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@startdate", startdate);
                    cmd.Parameters.AddWithValue("@enddate", enddate);
                    cmd.Parameters.AddWithValue("@company", company);
                    cmd.Parameters.AddWithValue("@os", os);
                    cmd.Parameters.AddWithValue("@osversion", osversion);
                    cmd.Parameters.AddWithValue("@model", model);
                    cmd.Parameters.AddWithValue("@category", category);


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

        public static DataTable GetMobiles(string company, string os, string osversion, string model, string category, string subcategory, int n, int sortOrder, int direction, int spin)
        {


            string sp = "model_search_v6";


            string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    if (string.Compare(company, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@company", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@company", company);
                    }
                    if (string.Compare(os, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@os", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@os", os);
                    }
                    if (string.Compare(osversion, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@osversion", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@osversion", osversion);
                    }

                    if (string.Compare(model, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@model", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@model", model);
                    }

                    if (string.Compare(category, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@category", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@category", category);
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

        public static DataTable GetLaptops(string company, string os, string osversion, string model, string category, int n, int sortOrder, int direction, int spin)
        {
           

            string sp = "model_laptop_search";


            string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@company", company);
                    cmd.Parameters.AddWithValue("@os", os);
                    cmd.Parameters.AddWithValue("@osversion", osversion);
                    cmd.Parameters.AddWithValue("@model", model);
                    cmd.Parameters.AddWithValue("@category", category);


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
        public static DataTable GetLaptops(string company, string os, string osversion, string model, string category, string subcategory, int n, int sortOrder, int direction, int spin)
        {


            string sp = "model_laptop_search_v6";


            string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    if (string.Compare(company, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@company", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@company", company);
                    }
                    if (string.Compare(os, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@os", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@os", os);
                    }
                    if (string.Compare(osversion, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@osversion", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@osversion", osversion);
                    }

                    if (string.Compare(model, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@model", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@model", model);
                    }

                    if (string.Compare(category, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@category", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@category", category);
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

        public static DataTable GetData(string company, string os, string osversion, string model, string category, int n, int sortOrder, int direction, int spin)
        {


            string sp = "model_search_like";


            string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@company", company);
                    cmd.Parameters.AddWithValue("@os", os);
                    cmd.Parameters.AddWithValue("@osversion", osversion);
                    cmd.Parameters.AddWithValue("@model", model);
                    cmd.Parameters.AddWithValue("@category", category);


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
        public static DataTable GetData(string company , string os , string osversion , string model , string category , string subcategory , int n , int sortOrder , int direction, int spin)
        {


            string sp = "model_search_v6";


            string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;


            
            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    if (string.Compare(company, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@company", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@company", company);
                    }
                    if (string.Compare(os, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@os", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@os", os);
                    }
                    if (string.Compare(osversion, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@osversion", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@osversion", osversion);
                    }

                    if (string.Compare(model, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@model", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@model", model);
                    }

                    if (string.Compare(category, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@category", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@category", category);
                    }


                    
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

        public static DataTable GetMobileCompanyList()
        {


            string sp = "model_company_list";


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

        public static DataTable GetMobileCompanyList(string os)
        {


            string sp = "model_company_list";


            string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    if (string.Compare(os, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@os", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@os", os);
                    }

                    SqlDataAdapter da = new SqlDataAdapter(cmd);


                     DataSet ds = new DataSet();

                    da.Fill(ds);


                    DataTable dt = ds.Tables[0];

                    return dt;




                }

            }





        }
        public static DataTable GetMobileOSList()
        {


            string sp = "model_os_list";


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

        public static DataTable GetModelCategoryList()
        {


            string sp = "model_category_list";


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
    }
}
