using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Data.SqlClient;

namespace KreateWebsites
{
    public class Names
    {
        public static DataTable GetFirstNames(string sex, string first_letter, string category, string sunsign, string name,  int n, int sortOrder, int direction, int spin)
        {


            string sp = "firstname_search";


            string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;


            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;

/*
                    Db.AddParameters(cmd, "@sex", sex);
                    Db.AddParameters(cmd, "@first_letter", first_letter);
                    Db.AddParameters(cmd, "@category", category);
                    Db.AddParameters(cmd, "@sunsign", sunsign);
                    Db.AddParameters(cmd, "@name", name);
                    Db.AddParameters(cmd, "@first_letter", first_letter);

            
                    cmd.Parameters.AddWithValue("@n", n);
                    cmd.Parameters.AddWithValue("@SortOrder", sortOrder);
                    cmd.Parameters.AddWithValue("@direction", direction);
                    cmd.Parameters.AddWithValue("@spin", spin);
 * */

                    if (string.Compare(sex, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@sex", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@sex", sex);
                    }

                    if (string.Compare(first_letter, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@first_letter", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@first_letter", first_letter);
                    }

                    if (string.Compare(category, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@category", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@category", category);
                    }

                    if (string.Compare(sunsign, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@sunsign", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@sunsign", sunsign);
                    }

                    if (string.Compare (name, null) == 0)
                    {
                        cmd.Parameters.AddWithValue("@name", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                    }
                 //   cmd.Parameters.AddWithValue("@category", category);
                 //   cmd.Parameters.AddWithValue("@sunsign", sunsign);
                 //   cmd.Parameters.AddWithValue("@name", name);
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


        public static DataTable GetFirstNames()
        {


            string sp = "firstname_search";


            string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;


            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;


                
                        cmd.Parameters.AddWithValue("@sex", DBNull.Value);
                 

                        cmd.Parameters.AddWithValue("@first_letter", DBNull.Value);
                   
                     
                 
                        cmd.Parameters.AddWithValue("@category", DBNull.Value);
                   
                       
                        cmd.Parameters.AddWithValue("@sunsign", DBNull.Value);
                    
                   
                        cmd.Parameters.AddWithValue("@name", DBNull.Value);
               
                    cmd.Parameters.AddWithValue("@n", 5000);
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
