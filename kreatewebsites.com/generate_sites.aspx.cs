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
    protected string input_dir = @"C:\e\a3_input\";
    protected string output_dir = @"C:\e\a3_output\";
    protected string list_dir = @"C:\e\a3_listdir\";

    protected void Page_Load(object sender, EventArgs e)
    {

 
        sitepath = Global.Siteurl;
        string listdir = @"C:\e\a1_sites\100\kreatewebsites.com\generate\site1\generate_list\" ;
        //   SiteFolder = @"http://localhost:51000/kreatewebsites.com/";
        SiteFolder = @"http://localhost:51000/";
        computerpath = LocalPath.ComputerPath;

        


       


     string local_path;
     
      string theme = "site1" ; //default theme
        string site ;

      KreateWebsites.Common.SiteurlOrg = @"https://www.kreatewebsites.com/";
      KreateWebsites.Common.ImageurlOrg = @"https://pictures.kreatewebsites.com/";

     local_path = LocalPath.InputPath;

     KreateWebsites.Common.Gallery.thumbnailpath = Global.Gallery.thumbnailpath;
     KreateWebsites.Common.Pictures.thumbnailpath = Global.Pictures.thumbnailpath;

     Response.Write("started ");

     string sites = Request.QueryString["sites"];

         System.IO.StreamReader file =
                   new System.IO.StreamReader(list_dir + sites);
          while ((site = file.ReadLine()) != null)
           {
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
              theme = "site1"; //default theme

          }

          file.Close();
      

       
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
            KreateWebsites.Common.Gallery.photoviewer = Global.Gallery.photoviewer;
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
                

                     string path = input_dir + site + @"\input\";
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
                         LocalPath.ComputerPath = LocalPath.OutPutPath + @"content\";
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
                  
                         string themepath = @"generate/" + theme + @"/";
                        /* 2023 disable enable log */
                        bool log_flag = false;
                         KreateWebsites.Generate.Generatesubdirs(local_path, OutputFolder, SiteFolder + themepath, log_flag, "myfile30.log");
                         // KreateWebsites.Generate.Generatesubdirs(local_path, OutputFolder, SiteFolder + themepath, false, "myfile30.log");


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