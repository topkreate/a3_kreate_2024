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
 //   protected string computerpath = @"C:\e\a1_sites\10\places-to-see.net\input\Places to see\";
    protected string computerpath = LocalPath.ComputerPath;

    protected string sitepath = Global.Siteurl.ToString();

    protected void Page_Load(object sender, EventArgs e)
    {
      //  GetVariables();

        
    //    Response.Write("path1 = " + Request.QueryString["output_path"]);
        GetArticleLinks(computerpath);
    //    hyperlinkMore.Text = Request.QueryString["output_path"];

      

      
    }


    private void GetArticleLinks(string inputdir)
    {


        DataTable dt;

        //  dt = KreateWebsites.Page.GetArticleLinks(inputdir, LocalPath.ComputerPath, Global.Siteurl);
       KreateWebsites.Generate.kreatelog("before Directory links = " +  inputdir + "," +  LocalPath.ComputerPath + "," +  Global.Siteurl) ;

        dt = KreateWebsites.Page.GetDirectoryLinks(inputdir, LocalPath.ComputerPath, Global.Siteurl);

        if (dt.Rows.Count > 0)
        {

            //     Response.Write("Count is " + dt.Rows.Count.ToString());

            RepLinks.DataSource = dt;
            RepLinks.DataBind();



        }






    }

  


 
}
