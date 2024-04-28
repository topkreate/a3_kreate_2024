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
     
      string theme = "site1" ; //default theme
        string site ;

      KreateWebsites.Common.SiteurlOrg = @"https://www.kreatewebsites.com/";
      KreateWebsites.Common.ImageurlOrg = @"https://pictures.kreatewebsites.com/";

     local_path = LocalPath.InputPath;

     KreateWebsites.Common.Gallery.thumbnailpath = Global.Gallery.thumbnailpath;
     KreateWebsites.Common.Pictures.thumbnailpath = Global.Pictures.thumbnailpath;

 //    Response.Write("started ");

   
   

 //    KreateWebsites.Generate.GenerateHTML(@"http://www.happydiwali.org/", @"c:\e\a3_gen\happydiwali.html");
      

       
    }
    //this is already defined in kreatewebsites dll




  





     protected void button1_Click(object sender, EventArgs e)
     {
         string input_path = textbox_inputpath.Text;
         string output_path = textbox_outputpath.Text;
         string orgString = textboxOrg.Text;
         string repString = textboxRep.Text;

       //  overwrite = Convert.ToBoolean(check_overwrite.Text.ToString());
         KreateWebsites.Generate.GenerateHTML(input_path, output_path);

     }

     public void GenerateHTML(string inputurl, string outputurl)
     {

    //     kreatelog("input output " + inputurl + "," + outputurl);
      //   bool overwrite = false;
         try
         {
             Response.Write("value =" + overwrite.ToString() + "," + File.Exists(outputurl).ToString());
             if ((!File.Exists(outputurl)) || (overwrite))
             {


                 Response.Write("In GenerateHTML if");

                 WebRequest req = WebRequest.Create(inputurl);
                 WebResponse res = req.GetResponse();
                 StreamReader sr = new StreamReader(res.GetResponseStream());
                 string html = sr.ReadToEnd();

                 string orgString = textboxOrg.Text;
                 string repString = textboxRep.Text;
                 /* this is causing issue
                 if (orgString != null)
                 {

                     html = html.Replace(orgString,repString);
                 }
                  * */
             //    Response.Write("In GenerateHTML");
// Response.Write ("html = " + html.ToString() );
         
            /*
                 string sitename = Common.Siteurl;
                 sitename = sitename.Replace(@"http://", "");
                 sitename = sitename.Replace(@"www.", "");
                 string email = @"info@" + sitename;
                 html = html.Replace("https://www.kreatewebsites.com/", Common.Siteurl);
                 html = html.Replace("https://pictures.kreatewebsites.com/", Common.ImagePath); // Added on Sep 17
                 html = html.Replace(@"info@kreatewebsites.com", email);
             * */
                 writefile(html, outputurl);
             }
         }
         catch (Exception e)
         {
             // Response.Write("Exception" +  e.Message);

         }


     }
     public void writefile(string html, string localpath)
     {
         // string localpath ;
         // localpath = "f:\\" + siteurl + "\\" + path7 + "\\" + param + ".html";
         //   localpath = "f:\\test\\" + param + ".html";
         //  StreamWriter _testData = new StreamWriter("f:\\" + siteurl + "\\" + path7 + "\\" + param) ;
         //   StreamWriter _testData = new StreamWriter("f:\\test\\data3.html", true);

         //      Response.Write("<br/> Directory created : " + localpath);
    //     Response.Write("local path 1= " + localpath);
         Directory.CreateDirectory(Path.GetDirectoryName(localpath));

         //     StreamWriter _testData = new StreamWriter(localpath, true);  // to append to existing file
 //        Response.Write("local path = " + localpath);
         StreamWriter _testData = new StreamWriter(localpath, false);  // to overwrite existing file
         _testData.WriteLine(html); // Write the file.
         _testData.Close(); // Close the instance of StreamWriter.
         _testData.Dispose(); // Dispose from memory.       

         //    Response.Write("<br/> File created : " + localpath   );

     }
}