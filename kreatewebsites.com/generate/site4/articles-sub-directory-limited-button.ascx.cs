using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Xml;
using System.Xml.Xsl;
using System.Data.Sql;
using System.Data.SqlClient;

using System.IO;



public partial class Default : System.Web.UI.UserControl
{
 //   protected string computerpath = @"C:\e\a1_sites\10\www.kreatewebsites.com\input\Places to see\";
    protected string computerpath = LocalPath.ComputerPath;

    protected string sitepath = Global.Siteurl.ToString();
  

    protected void Page_Load(object sender, EventArgs e)
    {

        string path = Request.QueryString["output_path"];


        GetArticleLinks(path);


      

      
    }

    private void GetArticleLinks(string inputdir)
    {


        DataTable dt;

        //  dt = KreateWebsites.Page.GetArticleLinks(inputdir, LocalPath.ComputerPath, Global.Siteurl);
        dt = KreateWebsites.Page.GetDirectoryLinks(inputdir, LocalPath.ComputerPath, Global.Siteurl,1);

        if (dt.Rows.Count > 0)
        {

            //     Response.Write("Count is " + dt.Rows.Count.ToString());

            RepLinks.DataSource = dt;
            RepLinks.DataBind();



        }






    }




 
}
