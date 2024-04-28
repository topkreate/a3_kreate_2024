using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Connect
/// </summary>
public class Connect
{
    //public SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["CONNECT"]);
    public SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["CONNECT"]);
    public SqlConnection con1 = new SqlConnection(ConfigurationManager.AppSettings["cm"]);
    public SqlCommand cmd;
	public Connect()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public void ExecuteNonQueryMethod(string MySQL)
    {
        con.Open();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        con.Close();
        //con.Dispose();

    }
}
