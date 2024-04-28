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
 //   protected string computerpath = @"C:\e\a1_sites\10\www.diwaligift.biz\input\Places to see\";
    protected string computerpath = LocalPath.ComputerPath;

    protected string sitepath = Global.Siteurl.ToString();


    protected void Page_Load(object sender, EventArgs e)
    {


        GetArticleLinks(Request.QueryString["output_path"]);

        H1.Text = "Home";
        header.Navigateurl = Global.Siteurl;


    }



    private void GetArticleLinks(string inputdir)
    {
               DataTable dt ;



            dt = KreateWebsites.Page.GetDirectoryLinks(Request.QueryString["output_path"], LocalPath.ComputerPath, Global.Siteurl,5);

            if (dt.Rows.Count > 0)
            {

                //     Response.Write("Count is " + dt.Rows.Count.ToString());

                RepLinks.DataSource = dt;
                RepLinks.DataBind();



            }






    }



}
