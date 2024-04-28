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



        public partial class Article : BasePage
{
 //   protected string computerpath = @"C:\e\a1_sites\10\kreatewebsites.com\input\Places to see\";
    protected string computerpath = LocalPath.ComputerPath;

    protected string sitepath = Global.Siteurl.ToString();
    static DataTable GetTable(string inputdir)
    {


        DataTable table = new DataTable();
        try
        {





            table.Columns.Add("id", typeof(int));
            table.Columns.Add("url", typeof(string));
            table.Columns.Add("name", typeof(string));





        }
        catch (Exception e)
        {
            // Response.Write("Exception is : " + e.Message);
        }


        return table;



    }

    protected void Page_Load(object sender, EventArgs e)
    {
      //  GetVariables();
       
   //     string path = Request.QueryString["output_path"];
        GetArticleLinks(computerpath);
 
    //    GetArticleLinks(path);

    //    GetArticleLinks(@"D:\a1_sites\10\ta\output\content\");
    //    hyperlinkMore.Text = Request.QueryString["output_path"];

      

      
    }



    static DataTable LinkTable()
    {


        DataTable table = new DataTable();
        try
        {





            table.Columns.Add("id", typeof(int));
            table.Columns.Add("url", typeof(string));
            table.Columns.Add("name", typeof(string));





        }
        catch (Exception e)
        {
            // Response.Write("Exception is : " + e.Message);
        }


        return table;



    }
    private void GetArticleLinks(string inputdir)
    {
        string fullpath ;
        if (inputdir != null)
        {


            DataTable dt = LinkTable();
           


            DirectoryInfo dInfo = new DirectoryInfo(inputdir);
            int i = 0;
            foreach (DirectoryInfo subdi in dInfo.GetDirectories())
            {
                string path ;
                path = inputdir + subdi.Name.ToString() + @"\" + "index.html";

             

                string url;
                string name;
             

                if (File.Exists(path))
                {
                   

                    url = System.IO.Path.GetFileName(path);
                   // name = System.IO.Path.GetFileNameWithoutExtension(path);
                    name = subdi.Name.ToString();
                   // extension = System.IO.Path.GetExtension(path);
                    string locpath = inputdir + subdi.Name.ToString() + @"\";
              //      Response.Write("Path = " + locpath + "," + sitepath + "<br/>");
                    fullpath = locpath.Replace(computerpath,sitepath);
                 //   Response.Write ("Full path is =" + fullpath + "<br/>");

                   
                            dt.Rows.Add(i, fullpath, name);
                        



                        i++;
                    




                }




            }  // for




            if (dt.Rows.Count > 0)
            {

                //     Response.Write("Count is " + dt.Rows.Count.ToString());

                RepLinks.DataSource = dt;
                RepLinks.DataBind();



            }


        }  // if



    }


 
}
