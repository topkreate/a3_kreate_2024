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
    public static class Finance
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
        public static DataTable GetIFSCCode(string bank =null, string branch=null, string city=null, string district=null, string state=null, string ifsc_code=null, string micr_code=null,  int n=1, int sortOrder=1)
        {


            string sp = "IFSCCode_Search";



            string connect = System.Configuration.ConfigurationManager.ConnectionStrings["astrology"].ConnectionString;


            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;


                    if (string.Compare(bank, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@bank", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@bank", bank);
                    }


                    if (string.Compare(branch, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@branch_name", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@branch_name", branch);
                    }

                    if (string.Compare(city, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@city", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@city", city);
                    }

                    if (string.Compare(district, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@district", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@district", district);
                    }


                    if (string.Compare(state, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@state", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@state", state);
                    }

                    if (string.Compare(ifsc_code, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@IFSCCode", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@IFSCCode", ifsc_code);
                    }


                    if (string.Compare(micr_code, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@MICRCode", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@MICRCode", micr_code);
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

        public static DataTable GetIFSCCodeOfBranch(string bank = null, string branch = null, string city = null, string district = null, string state = null,  int n = 1, int sortOrder = 1)
        {


            string sp = "IFSCCode_Find";



            string connect = System.Configuration.ConfigurationManager.ConnectionStrings["astrology"].ConnectionString;


            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;


                    if (string.Compare(bank, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@bank", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@bank", bank);
                    }


                    if (string.Compare(branch, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@branch_name", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@branch_name", branch);
                    }

                    if (string.Compare(city, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@city", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@city", city);
                    }

                    if (string.Compare(district, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@district", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@district", district);
                    }


                    if (string.Compare(state, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@state", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@state", state);
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

        public static DataTable GetIFSCCode_bank(string bank = null, string branch = null, string city = null, string district = null, string state = null, string ifsc_code = null, string micr_code = null, int n = 1, int sortOrder = 1)
        {


            string sp = "IFSCCode_Search_bank";



            string connect = System.Configuration.ConfigurationManager.ConnectionStrings["astrology"].ConnectionString;


            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;


                    if (string.Compare(bank, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@bank", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@bank", bank);
                    }


                    if (string.Compare(branch, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@branch_name", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@branch_name", branch);
                    }

                    if (string.Compare(city, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@city", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@city", city);
                    }

                    if (string.Compare(district, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@district", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@district", district);
                    }


                    if (string.Compare(state, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@state", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@state", state);
                    }

                    if (string.Compare(ifsc_code, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@IFSCCode", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@IFSCCode", ifsc_code);
                    }


                    if (string.Compare(micr_code, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@MICRCode", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@MICRCode", micr_code);
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
        public static DataTable GetIFSCCode_city(string bank = null, string branch = null, string city = null, string district = null, string state = null, string ifsc_code = null, string micr_code = null, int n = 1, int sortOrder = 1)
        {


            string sp = "IFSCCode_Search_city";



            string connect = System.Configuration.ConfigurationManager.ConnectionStrings["astrology"].ConnectionString;


            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;


                    if (string.Compare(bank, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@bank", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@bank", bank);
                    }


                    if (string.Compare(branch, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@branch_name", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@branch_name", branch);
                    }

                    if (string.Compare(city, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@city", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@city", city);
                    }

                    if (string.Compare(district, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@district", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@district", district);
                    }


                    if (string.Compare(state, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@state", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@state", state);
                    }

                    if (string.Compare(ifsc_code, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@IFSCCode", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@IFSCCode", ifsc_code);
                    }


                    if (string.Compare(micr_code, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@MICRCode", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@MICRCode", micr_code);
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


        public static DataTable GetIFSCCode_state(string bank = null, string branch = null, string city = null, string district = null, string state = null, string ifsc_code = null, string micr_code = null, int n = 1, int sortOrder = 1)
        {


            string sp = "IFSCCode_Search_state";



            string connect = System.Configuration.ConfigurationManager.ConnectionStrings["astrology"].ConnectionString;


            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;


                    if (string.Compare(bank, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@bank", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@bank", bank);
                    }


                    if (string.Compare(branch, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@branch_name", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@branch_name", branch);
                    }

                    if (string.Compare(city, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@city", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@city", city);
                    }

                    if (string.Compare(district, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@district", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@district", district);
                    }


                    if (string.Compare(state, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@state", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@state", state);
                    }

                    if (string.Compare(ifsc_code, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@IFSCCode", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@IFSCCode", ifsc_code);
                    }


                    if (string.Compare(micr_code, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@MICRCode", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@MICRCode", micr_code);
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

        public static DataTable GetIFSCCode_bank_branches(string bank = null, string branch = null, string city = null, string district = null, string state = null, string ifsc_code = null, string micr_code = null, int n = 1, int sortOrder = 1)
        {


            string sp = "IFSCCode_Search_bank_branches";



            string connect = System.Configuration.ConfigurationManager.ConnectionStrings["astrology"].ConnectionString;


            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;


                    if (string.Compare(bank, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@bank", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@bank", bank);
                    }


                    if (string.Compare(branch, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@branch_name", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@branch_name", branch);
                    }

                    if (string.Compare(city, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@city", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@city", city);
                    }

                    if (string.Compare(district, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@district", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@district", district);
                    }


                    if (string.Compare(state, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@state", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@state", state);
                    }

                    if (string.Compare(ifsc_code, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@IFSCCode", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@IFSCCode", ifsc_code);
                    }


                    if (string.Compare(micr_code, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@MICRCode", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@MICRCode", micr_code);
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

        public static DataTable GetIFSCCode_bank_banks_in_city(string bank = null, string branch = null, string city = null, string district = null, string state = null, string ifsc_code = null, string micr_code = null, int n = 1, int sortOrder = 1)
        {


            string sp = "IFSCCode_Search_banks_in_city";



            string connect = System.Configuration.ConfigurationManager.ConnectionStrings["astrology"].ConnectionString;


            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;


                    if (string.Compare(bank, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@bank", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@bank", bank);
                    }


                    if (string.Compare(branch, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@branch_name", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@branch_name", branch);
                    }

                    if (string.Compare(city, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@city", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@city", city);
                    }

                    if (string.Compare(district, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@district", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@district", district);
                    }


                    if (string.Compare(state, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@state", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@state", state);
                    }

                    if (string.Compare(ifsc_code, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@IFSCCode", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@IFSCCode", ifsc_code);
                    }


                    if (string.Compare(micr_code, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@MICRCode", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@MICRCode", micr_code);
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
       
    }

}
