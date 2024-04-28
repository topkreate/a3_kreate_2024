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
  // protected string computerpath = @"C:\e\a1_sites\places-to-see.net\output\content\";
       protected string computerpath = LocalPath.ComputerPath;

 //   protected string sitepath = Global.Siteurl.ToString();

   //     protected string sitepath = LocalPath.;


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


    //  Response.Write("path1 = " + Request.QueryString["output_path"] );
        GetArticleLinks(Request.QueryString["output_path"]);// this will work when output path is passed such as pictures.html

  //      GetArticleLinks(LocalPath.ComputerPath);
      

      
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

        if (Directory.Exists(inputdir))
        {
         if (inputdir != null)
          {


            DataTable dt = LinkTable();
            // string inputdir = Directory.GetCurrentDirectory();

            string[] fileEntries = Directory.GetFiles(inputdir);
            int i = 0;

            foreach (string path in fileEntries)
            {



                //System.Web.HttpResponse.("path is ");

                string url;
                string name;
                string extension;

                if (File.Exists(path))
                {
                    // This path is a file

                    url = System.IO.Path.GetFileName(path);
                    name = System.IO.Path.GetFileNameWithoutExtension(path);
                    extension = System.IO.Path.GetExtension(path);

                    fullpath = path.Replace(computerpath,Global.Siteurl);
        //            Response.Write ("File name is =" + path + "<br/>" +  computerpath + " <br/> " +  Global.Siteurl);

                    if ((extension.ToLower() == ".html")  ||  (extension.ToLower() == ".aspx"))
                    {
                        if ((name.ToLower() != "index") && (name.ToLower() != "privacypolicy"))
                        {
                           dt.Rows.Add(i, fullpath, name);
                          //      Response.Write ("name is = ~/" + name + extension + "<br/>" );
                           // dt.Rows.Add(i, "~/" + name + extension, name);
                        }



                        i++;
                    }




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


 
}
