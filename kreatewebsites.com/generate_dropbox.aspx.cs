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
using System.Data;
using System.Data.SqlClient;


using System.Collections.Generic;


using System.Net;
using System.IO;


public partial class Generate : BasePage
{
  
  

    protected string outputdir;
    bool overwrite = true;


  
   
 



    protected string navigate_path;
    protected string pic_path;
    protected string PicturePath = Global.Pictures.defaultpath;
    protected string SlidePath = Global.Slides.defaultpath;
    protected string GalleryPath = Global.Gallery.defaultpath;
    protected string picpage = Global.picpage;
    protected string sitepath;
    protected string computerpath;
    protected string SiteFolder;

    protected void Page_Load(object sender, EventArgs e)
    {

 
        sitepath = Global.Siteurl;
        string listdir = @"C:\e\a1_sites\100\kreatewebsites.com\generate\site1\generate_list\" ;
      SiteFolder = @"http://localhost:51000/kreatewebsites.com/";

     computerpath = LocalPath.ComputerPath;

        


       


     string local_path;
      string OutputFolder;
      string theme = "site1" ; //default theme

      KreateWebsites.Common.SiteurlOrg = @"https://www.kreatewebsites.com/";
      KreateWebsites.Common.ImageurlOrg = @"https://pictures.kreatewebsites.com/";

     local_path = LocalPath.InputPath;

     KreateWebsites.Common.Gallery.thumbnailpath = Global.Gallery.thumbnailpath;
     KreateWebsites.Common.Pictures.thumbnailpath = Global.Pictures.thumbnailpath;

     Response.Write("started ");

     string site = Request.QueryString["site"];
     InitailizeSite(@"C:\e\a2_generated_sites\" + site + @"\input\");
     if (Request.QueryString["theme"] != null)
     {
         theme = Request.QueryString["theme"];
     }
     else
     {
         InitailizeTheme(@"C:\e\a2_generated_sites\" + site + @"\input\", ref theme);
     }

              
     ProcessSite(listdir, SiteFolder, site, theme );
   
   
      

       
    }
    //this is already defined in kreatewebsites dll
    public void InitailizeSite(string sitepath)
    {
        string str, adID;
        if (File.Exists(sitepath + @"\ad.ID"))
        {
            str = System.IO.File.ReadAllText(sitepath + @"\ad.ID");

            adID = str.TrimEnd('\r', '\n');
            textbox_Ad.Text = adID;
            //     Response.Write("adid = " + adID);
            Global.adID = Convert.ToInt32(adID);
            Response.Write("site variable =" + sitepath + " ," + str + "," + adID);
        }

             
    }
    public void InitailizeTheme(string sitepath, ref string theme)
    {
        string str;
        if (File.Exists(sitepath + @"\theme.txt"))
        {
            str = System.IO.File.ReadAllText(sitepath + @"\theme.txt");

            theme = str.TrimEnd('\r', '\n');

            Response.Write("theme =" + theme);
        }

    }
    public  void ProcessSite(string listdir, string SiteFolder, string site, string theme)
    {


                 

             try
             {
                
                 int i = 0;


         

                     string url;
                

                     string path = @"C:\e\a2_generated_sites\" + site + @"\input\";
                     Response.Write("path = " + path);
                 if (Directory.Exists(path) )
                   
                     {
                         // This path is a file


                       //  url = System.IO.Path.GetFileName(path);
                         url = site;


                         //name = System.IO.Path.GetFileNameWithoutExtension(path);
                       //  extension = System.IO.Path.GetExtension(path);

                         LocalPath.InputPath = @"C:\e\a2_generated_sites\" + url + @"\input\";
                 //        LocalPath.OutPutPath = @"C:\e\a2_generated_sites\" + url + @"\output\";
               //          LocalPath.ComputerPath = LocalPath.OutPutPath + @"content\";
                         LocalPath.OutPutPath = @"C:\users\mamta\dropbox\apps\azure\" ;
                         LocalPath.ComputerPath = LocalPath.OutPutPath ;
                       
                         Global.Siteurl = @"http://www." + url + @"/";

                         string OutputFolder = LocalPath.OutPutPath;
                         KreateWebsites.Generate.overwrite = true;
                         string local_path = LocalPath.InputPath;

                         if (File.Exists(LocalPath.InputPath + @"\site.siteurl"))
                         {
                             string str = System.IO.File.ReadAllText(LocalPath.InputPath + @"\site.siteurl");

                             Global.Siteurl = str.TrimEnd('\r', '\n');


                         }

                         Response.Write("variables : " + url + "," +  LocalPath.InputPath);
                  
                         string themepath = @"generate/" + theme + @"/"; ;
                         KreateWebsites.Generate.Generatesubdirs(local_path, OutputFolder, SiteFolder + themepath, true, "myfile30.log");


                     }


                     else
                     {
                         Response.Write("Directory do not exist : " + path);
                       //  Console.WriteLine("No rows found.");
                     }









             }  // try
             catch
             {

             }




        }


  
     void StartGenerate_Click(Object sender,                             EventArgs e)

    {
         Button clickedButton = (Button)sender;
        clickedButton.Text = "...button clicked...";
        clickedButton.Enabled = false;

        sitepath = textbox_sitepath.Text.ToString() ;
         computerpath = textbox_computerpath.Text.ToString() ;
        SiteFolder = textbox_sitefolder.Text.ToString() ;
      //  local_path = textbox_inputpath.Text.ToString()  ;
        // OutputFolder = textbox_outputpath.Text.ToString()  ;

        overwrite = Convert.ToBoolean(check_overwrite.Text.ToString());


    }




}