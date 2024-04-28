using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Data.SqlClient;

namespace KreateWebsites
{
    public class Technology
    {
        public static DataTable GetData(string topic, int n, int sortOrder)
        {

            string sp = "get_questions_topic";


            string connect = ConfigurationManager.ConnectionStrings["astrology"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@brand", topic);
                 
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
