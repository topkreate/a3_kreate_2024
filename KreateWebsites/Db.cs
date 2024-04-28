using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Xml.Linq;
using System.Data.SqlClient;

public static class Db
{

    public static void AddParameters(SqlCommand cmd, string paramname, string paramvalue)
    {


        if (string.Compare(paramname, null) == 0)
        {

            cmd.Parameters.AddWithValue(paramname, DBNull.Value);

        }
        else
        {
            cmd.Parameters.AddWithValue(paramname, paramvalue);
         
        }

    }
 
}


