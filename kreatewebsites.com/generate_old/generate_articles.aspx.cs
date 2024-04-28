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


  
   
    protected string SiteFolder;
  



    protected string navigate_path;
    protected string pic_path;
    protected string PicturePath = Global.Pictures.defaultpath;
    protected string SlidePath = Global.Slides.defaultpath;
    protected string GalleryPath = Global.Gallery.defaultpath;
    protected string picpage = Global.picpage;
    protected string sitepath;
    protected string computerpath;

    protected void Page_Load(object sender, EventArgs e)
    {

 
        sitepath = Global.Siteurl;
        

     computerpath = LocalPath.ComputerPath;

        SiteFolder = @"http://localhost:54730/kreatewebsites.com/";


       


     string local_path;
      string OutputFolder;


     local_path = LocalPath.InputPath;

     KreateWebsites.Common.Gallery.thumbnailpath = Global.Gallery.thumbnailpath;
     KreateWebsites.Common.Pictures.thumbnailpath = Global.Pictures.thumbnailpath;
     KreateWebsites.Common.SiteurlOrg = @"https://www.kreatewebsites.com/";
        KreateWebsites.Common.ImageurlOrg = @"https://pictures.kreatewebsites.com/" ;
        LocalPath.InputPath = @"C:\e\a2_generated_sites\happy-diwali.info\input\";
        LocalPath.OutPutPath = @"C:\e\a2_generated_sites\happy-diwali.info\output\";
        LocalPath.ComputerPath = LocalPath.OutPutPath + @"content\"; 
      
        OutputFolder = LocalPath.OutPutPath;
        KreateWebsites.Generate.overwrite = true;
     //  KreateWebsites.Generate.Generatesubdirs(local_path, OutputFolder, SiteFolder);
       KreateWebsites.Generate.Generatesubdirs(local_path, OutputFolder, SiteFolder + @"generate/", true, "myfile24.log");
       // Generatesubdirs(local_path, OutputFolder);


        textbox_sitepath.Text = sitepath;
        textbox_computerpath.Text = computerpath;
        textbox_sitefolder.Text = SiteFolder;
        textbox_inputpath.Text = local_path;
        textbox_outputpath.Text = OutputFolder;
        textbox_Photopath.Text = Global.photopath;
        check_overwrite.Text = overwrite.ToString(); ;


        button1.Click += new EventHandler(this.StartGenerate_Click);

      

       
    }
   

     void StartGenerate_Click(Object sender,
                           EventArgs e)

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