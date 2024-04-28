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


public partial class Generate : System.Web.UI.Page
{
  
  

    protected string outputdir;
    bool overwrite = true;


  
   
 



    protected void Page_Load(object sender, EventArgs e)
    {

 
      

       
    }
    //this is already defined in kreatewebsites dll




  





     protected void button1_Click(object sender, EventArgs e)
     {
         string input_path = textbox_inputpath.Text;
         string output_path = textbox_outputpath.Text;
       

       //  overwrite = Convert.ToBoolean(check_overwrite.Text.ToString());
         GenerateHTML(input_path, output_path);

     }

     public void GenerateHTML(string inputurl, string outputurl)
     {

  
         try
         {
             
             if ((!File.Exists(outputurl)) || (overwrite))
             {


             

                 WebRequest req = WebRequest.Create(inputurl);
                 WebResponse res = req.GetResponse();
                 StreamReader sr = new StreamReader(res.GetResponseStream());
                 string html = sr.ReadToEnd();

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