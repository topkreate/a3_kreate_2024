
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Xml.Linq;
using System.Data.SqlClient;

using System.Collections.Generic;


using System.Net;
using System.IO;


namespace KreateWebsites
{
    public class Images
    {



   protected static string thumbnail_path = Common.Pictures.thumbnailpath;

       protected static string ImagePath = Common.ImagePath;
       protected static string url = " ";
       protected static string name = " ";

       protected static int year;
       protected static int count = 3;



       protected static string subfolder;
       protected static int pictureid = 0;

       protected static string local_path;
       protected static string navigate_path;
       protected static string pic_path;
       protected static string output_path;

       protected static string articlefile;

       protected static String itemstovisit = "World";
       protected static string continent = Common.Continent;
       protected static string country = Common.Country;
       protected static string state = Common.State;
       protected static string statename = Common.StateName;
       protected static string city = Common.City;
       protected static string category = Common.Category;
       protected static string subcategory = Common.SubCategory;
       protected static string title;
       protected static string text;

 


        static DataTable GetTable()
        {


            DataTable table = new DataTable();
            try
            {







                table.Columns.Add("id", typeof(int));
                table.Columns.Add("thumbnailurl", typeof(string));
                table.Columns.Add("name", typeof(string));
                table.Columns.Add("displayname", typeof(string));

                table.Columns.Add("alt", typeof(string));
                table.Columns.Add("imagefullurl", typeof(string));

                table.Columns.Add("title", typeof(string));
                table.Columns.Add("text", typeof(string));
                table.Columns.Add("continent", typeof(string));
                table.Columns.Add("country", typeof(string));
                table.Columns.Add("state", typeof(string));
                table.Columns.Add("statename", typeof(string));
                table.Columns.Add("city", typeof(string));
                table.Columns.Add("category", typeof(string));
                table.Columns.Add("subcategory", typeof(string));
                table.Columns.Add("navigateurl", typeof(string));
                table.Columns.Add("navigateurl2", typeof(string));



            }
            catch (Exception e)
            {
                // Response.Write("Exception is : " + e.Message);
            }


            return table;



        }

        public static void GetImagePath(string inputdir,  string name)
        {

            Generate.kreatelog("Getimagepath in image = " + inputdir + @"\" + name + @".path");

            // Default value of pictures path is t\aken from Common. The value can be overriden by providing a value in file pictures.path 
            ImagePath = Common.ImagePath.ToString();
            if (File.Exists(inputdir + @"\" + name + @".path"))
            {
                string str = System.IO.File.ReadAllText(inputdir + @"\" + name + @".path");

                ImagePath = str.TrimEnd('\r', '\n');  // This will remove any combination of carriage returns and newlines from 
                
                Generate.AppendSlash(ref ImagePath);
                Generate.kreatelog("imagepath = " + ImagePath);

            }
        }



    

  

 

          public static  DataTable GetData(string articlefile, string inputdir,  string name)
          {


              string displayname;
              string alt = "photos";


              DataTable dt = GetTable();
           GetImagePath(inputdir,name);
           GetThumbnailPath(inputdir);//Jan 2016

            /* Dec 2021 */
            KreateWebsites.Generate.kreatelog("images.cs data table " + inputdir);

            //   string[] fileEntries = Directory.GetFiles(inputdir);
            int i = 0;
              string url, imagefullurl = null, thumbnailurl = null;
              string navigateurl,navigateurl2 = null;

              bool pictures_individualpage = Common.Pictures.individualpage;



              Generate.kreatelog("in GetImageData articlefile =" + articlefile);
              //  This read pictures.list. You can specify picture filename in this file.
              if (File.Exists(articlefile))
              {

                  System.IO.StreamReader file =
                     new System.IO.StreamReader(articlefile);
                  while ((url = file.ReadLine()) != null)
                  {
                      name = url; // remove .jpg

                      name = name.Replace(".jpg", "");
                      name = name.Replace(".jpeg", "");
                      name = name.Replace(".png", "");
                      name = name.Replace(".JPG", "");
                      name = name.Replace(".JPEG", "");
                      name = name.Replace(".PNG", "");


                 
                   Photos.GetImageFullUrl(ImagePath, url, thumbnail_path, ref imagefullurl, ref thumbnailurl); // later enable this test

                   Generate.kreatelog("Imagefullurl " + imagefullurl);
                  
                      displayname = name;
                      Photos.GetPictureAttributes(inputdir, name, ref text, ref displayname);
                      string navigatename = displayname;
                      /* individal page generation is not working with this */
                      displayname = displayname.Replace("-", " ");
                      displayname = displayname.Replace("_", " ");
                      displayname = displayname.ToUpper();




                      if (pictures_individualpage == true)
                      {
                          // navigateurl = name + ".html";
                          navigateurl = navigatename + ".html";
                      }
                      else
                      {
                          navigateurl = imagefullurl;
                      }
                      // Added in Jan 2016
                      navigateurl2 = Common.Pictures.defaultpath + Common.Gallery.photoviewer + @"?imageurl=" + imagefullurl; // Jan 2016

                      Photos.GetAltTag(inputdir, @"pictures.keyword", imagefullurl, name, displayname, title, continent, country, state, statename, city, category, subcategory, ref alt);
                      Photos.GetPictureNavigateurl(inputdir, name, url, ref  navigateurl); //Jan 29 2016

                      navigateurl2 = navigateurl; // dec 2021.  uncomment this. it will use photoviewer.php etc

                      dt.Rows.Add(i, thumbnailurl, name, displayname, alt, imagefullurl, title, text, continent, country, state, statename, city, category, subcategory, navigateurl,navigateurl2);
                      //  dt.Rows.Add(i, thumbnailurl, name, displayname, imagefullurl, title, text, continent, country, state, statename, city, category, subcategory,navigateurl);

                      text = "";  // reset column for next slide.
                  }

                  file.Close();


              }



              if (dt.Rows.Count > 0)
              {

                  //     Response.Write("Count is " + dt.Rows.Count.ToString());

                  //         RepDetails.DataSource = dt;
                  //       RepDetails.DataBind();



              }



              //   GetPhotoLinks(inputdir); This add jpg url
              Photos.setslide(subfolder);


              return dt;

          }

        

          public static void GetThumbnailPath(string inputdir)
          {
              thumbnail_path = Common.Gallery.thumbnailpath;
              Generate.kreatelog("In GetThumbnail path");
              if (File.Exists(inputdir + @"\gallery_thumbnails.path"))
              {
                  string str = System.IO.File.ReadAllText(inputdir + @"\gallery_thumbnails.path");

                  thumbnail_path = str.TrimEnd('\r', '\n', ' ', '\t');  // This will remove any combination of carriage returns and newlines from 
                  Generate.kreatelog("In GetThumbnail path" + thumbnail_path);
                  Generate.AppendSlash(ref thumbnail_path); // add slaah is missing at end
              }



          }
    }
}






