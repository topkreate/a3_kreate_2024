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
    protected string input_dir = @"C:\e\a3_input\"    ;
    protected string output_dir = @"C:\e\a3_output\"    ;

    protected void Page_Load(object sender, EventArgs e)
    {

 
        sitepath = Global.Siteurl;
        string listdir = @"C:\e\a1_sites\100\kreatewebsites.com\generate\site1\generate_list\" ;
        // VS2012  SiteFolder = @"http://localhost:51000/kreatewebsites.com/";
        SiteFolder = @"http://localhost:51000/";
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
     InitailizeSite(input_dir + site + @"\input\");
     if (Request.QueryString["theme"] != null)
     {
         theme = Request.QueryString["theme"];
     }
     else
     {
         InitailizeTheme(input_dir + site + @"\input\", ref theme);
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
            Util.SetPhotoViewer(Global.adID);
            SetPhotoViewer(Global.adID); // Aug 2023
            KreateWebsites.Common.Gallery.photoviewer = Global.Gallery.photoviewer;
            Response.Write("site variable =" + sitepath + " ," + str + "," + adID + "," + Global.adID.ToString() + "," + Global.Gallery.photoviewer.ToString());
       
        }

        string strName, genName ;
        if (File.Exists(sitepath + @"\gen.name"))
        {

            strName = System.IO.File.ReadAllText(sitepath + @"\gen.name");
            genName = strName.TrimEnd('\r', '\n');

            Response.Write("gen.name found =" + sitepath);
            Global.genName = Convert.ToInt32(genName);
            KreateWebsites.Common.genName = Global.genName;

        }
        else
        {
            Global.genName = 0;
            KreateWebsites.Common.genName = Global.genName;
        }

        string strTitle, genTitle;
        if (File.Exists(sitepath + @"\gen.title"))
        {

            strTitle = System.IO.File.ReadAllText(sitepath + @"\gen.title");
            genTitle = strTitle.TrimEnd('\r', '\n');

            Response.Write("gen.title found =" + sitepath);
            Global.genTitle = Convert.ToInt32(genTitle);
            KreateWebsites.Common.genTitle = Global.genTitle;

        }
        else
        {
            Global.genTitle = 0;
            KreateWebsites.Common.genTitle = Global.genTitle;
        }

        string strArticleurl, genArticleurl;
        if (File.Exists(sitepath + @"\gen.articleurl"))
        {

            strArticleurl = System.IO.File.ReadAllText(sitepath + @"\gen.articleurl");
            genArticleurl = strArticleurl.TrimEnd('\r', '\n');

            Response.Write("gen.Articleurl found =" + sitepath);
            Global.genArticleurl = Convert.ToInt32(genArticleurl);
            KreateWebsites.Common.genArticleurl = Global.genArticleurl;

        }
        else
        {
            Global.genArticleurl = 0;
            KreateWebsites.Common.genArticleurl = Global.genArticleurl;
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
                

                     string path =  input_dir + site + @"\input\";
                     Response.Write("path = " + path);
                 if (Directory.Exists(path) )
                   
                     {
                         // This path is a file


                       //  url = System.IO.Path.GetFileName(path);
                         url = site;


                         //name = System.IO.Path.GetFileNameWithoutExtension(path);
                       //  extension = System.IO.Path.GetExtension(path);

                         LocalPath.InputPath = input_dir + url + @"\input\";
                         LocalPath.OutPutPath = output_dir + url + @"\output\";
                         LocalPath.ComputerPath = LocalPath.OutPutPath + @"content\";  //Dec 24 this need to be modified for content2 packet2 etc but that will happen inside GenerateSubdirs
                         Global.Siteurl = @"http://www." + url + @"/";

                         string OutputFolder = LocalPath.OutPutPath;
                         KreateWebsites.Generate.overwrite = true;
                         string local_path = LocalPath.InputPath;

                         if (File.Exists(LocalPath.InputPath + @"\site.siteurl"))
                         {
                             string str = System.IO.File.ReadAllText(LocalPath.InputPath + @"\site.siteurl");

                             Global.Siteurl = str.TrimEnd('\r', '\n');


                         }

                        /* Aug 2024 */
                        if (File.Exists(LocalPath.InputPath + @"\sitename.txt"))
                        {
                            string str = System.IO.File.ReadAllText(LocalPath.InputPath + @"\sitename.txt");

                            Global.Sitename = str.TrimEnd('\r', '\n');


                        }
                        /* Addition end */

                         Response.Write("variables : " + url + "," +  LocalPath.InputPath);
                  
                         string themepath = @"generate/" + theme + @"/"; ;

                //  local_path = LocalPath.InputPath;  = @"C:\e\a2_generated_sites\" + url + @"\input\"
                //outputFolder is LocalPath.OutPutPath - @"C:\e\a2_generated_sites\" + url + @"\output\"
                //  SiteFolder = @"http://localhost:51000/kreatewebsites.com/"; themepath is  @"generate/" + theme + @"/"


                //           KreateWebsites.Generate.Generatesubdirs(local_path, OutputFolder, SiteFolder + themepath, true, "myfile30.log" ,"mydebug.log");


                //   KreateWebsites.Generate.Generatesubdirs(local_path, OutputFolder, SiteFolder + themepath, false, "myfile30.log", "mydebug.log");

                //create 2 logs, enable ,disable log
                //KreateWebsites.Generate.Generatesubdirs(local_path, OutputFolder, SiteFolder + themepath, true, "myfile30.log", "mydebug.log");
                /* 2023 May 22 */

                string my_parameters = "Generate sub: " + local_path + " ," + OutputFolder + " ," + " , " + SiteFolder + " ," + themepath;
                Response.Write(my_parameters);

                /* 2023 disable enable log */
                bool log_flag = true;
                /* some time this line give problem */
                // KreateWebsites.Generate.Generatesubdirs(local_path, OutputFolder, SiteFolder + themepath, log_flag , "myfile30.log", "mydebug.log");

                KreateWebsites.Generate.Generatesubdirs(local_path, OutputFolder, SiteFolder + themepath, log_flag, "myfile30.log");
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



     public  void SetPhotoViewer(int id)
     {

         Response.Write("id =" + id.ToString());       
        
         switch (id)
         {
             case 0:

                // Global.Gallery.photoviewer = "photoviewer.php";
                Global.Gallery.photoviewer = "image.html";
                Response.Write("in 0 " );  
                break;
             case 1:
                 Response.Write("in 1 "); 
                 Global.Gallery.photoviewer = "picturesalbum.php";
                 Global.Gallery.photoviewer = "image.html";

                 Response.Write("1 assigned " + Global.Gallery.photoviewer); 
                 break;
             case 2:
                 Response.Write("in 2 "); 
                 Global.Gallery.photoviewer = "imagegallery.php";
                 Global.Gallery.photoviewer = "image.html";
                 break;

             case 3:
                 Response.Write("in 3 "); 
                 Global.Gallery.photoviewer = "photoviewer.php";
                 Global.Gallery.photoviewer = "image.html";
                break;
             default:
                 Response.Write("in default "); 
                 Global.Gallery.photoviewer = "photoviewer.php";
                 Global.Gallery.photoviewer = "image.html";
                break;

                 
         }
         Response.Write("in end " + Global.Gallery.photoviewer); 

     }

}