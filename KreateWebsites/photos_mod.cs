
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
    public class Photos
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

 


        static DataTable GetTable(string inputdir)
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

        public static void GetImagePath(string inputdir)
        {



            // Default value of pictures path is t\aken from Common. The value can be overriden by providing a value in file pictures.path 
            ImagePath = Common.ImagePath;
            if (File.Exists(inputdir + @"\pictures.path"))
            {
                string str = System.IO.File.ReadAllText(inputdir + @"\pictures.path");

                ImagePath = str.TrimEnd('\r', '\n');  // This will remove any combination of carriage returns and newlines from 
                Generate.AppendSlash(ref ImagePath);

            }
        }
        public static void GetThumbnailPath(string inputdir)
        {



            // Default value of pictures path is t\aken from Common. The value can be overriden by providing a value in file pictures.path 
            thumbnail_path = Common.Pictures.thumbnailpath;
            KreateWebsites.Generate.kreatelog("check thumbnail 2  " + inputdir + " " + thumbnail_path);
           
            
            if (File.Exists(inputdir + @"\pictures_thumbnails.path"))
            {
                string str = System.IO.File.ReadAllText(inputdir + @"\pictures_thumbnails.path");

                thumbnail_path = str.TrimEnd('\r', '\n');  // This will remove any combination of carriage returns and newlines from 
                Generate.AppendSlash(ref thumbnail_path);

                KreateWebsites.Generate.kreatelog("photos thumbnail found in " + inputdir + " " + thumbnail_path);
            }
            
        }

   public static int GetImageFullUrl(string imagepath, string imageurl, string thumbnail_path, ref string imagefullurl, ref string thumbnailurl)
 {

     Generate.kreatelog("paramters : " + imagepath + "," + imageurl + "," + thumbnail_path + "," + imagefullurl + "," + thumbnailurl);
    
            /* 2023 added https */
     if (imageurl.Contains("http://") || imageurl.Contains("https://") )
     {
         

         /* Apr 2024 If condition may not be needed */
         Uri uri = new Uri(imageurl);
         if (uri.IsFile)
         {
             string filename = System.IO.Path.GetFileName(uri.LocalPath);
             string path = System.IO.Path.GetDirectoryName(uri.LocalPath);
             thumbnailurl = path + thumbnail_path + imageurl;
         }

         //Apr 2024
         //thumbnailurl = imageurl;
         
         imagefullurl = imageurl;

         Generate.kreatelog("in if imageurl: " + imagepath + "," + imageurl + "," + thumbnail_path + "," + imagefullurl + "," + thumbnailurl);
    
         
        // thumbnailurl = imagefullurl;  // later improve this to build thumbailpath
         return 1;
     }
     else
     {

         /* Jan 2016 */

         if (thumbnail_path.Contains("http://") || thumbnail_path.Contains("https://")) /* 2023 added https */
         {
             thumbnailurl = thumbnail_path + imageurl;
         }
         else
         {
             thumbnailurl = imagepath + thumbnail_path + imageurl;
         }
         /* Jan 2016 end */



     //Jan 2016    thumbnailurl = imagepath + thumbnail_path + imageurl;
         imagefullurl = imagepath + imageurl;
         Generate.kreatelog("in imageurl else : " + imagepath + "," + imageurl + "," + thumbnail_path + "," + imagefullurl + "," + thumbnailurl);
    

         return 0;
     }

     
 }

        public static DataTable GetData(string inputdir)
        {


            string displayname;
            string alt = "photos";


            DataTable dt = GetTable(inputdir);
            GetImagePath(inputdir);
            GetThumbnailPath(inputdir); //added to ensure each folder has different thumbnailpath

            /* Dec 2021 */
            KreateWebsites.Generate.kreatelog("photo.cs data table " + inputdir);

            string[] fileEntries = Directory.GetFiles(inputdir);
            int i = 0;
            string url, imagefullurl=null, thumbnailurl=null;
            string navigateurl = null;
            string navigateurl2 = null;   //Jan 2016
              bool pictures_individualpage = Common.Pictures.individualpage;
            if (File.Exists(inputdir + @"\pictures.individualpage"))
            {
                string individualpage = System.IO.File.ReadAllText(inputdir + @"\pictures.individualpage");
                individualpage.Trim();

                KreateWebsites.Generate.kreatelog("pictures individualpage found");
                if (individualpage[0] == '1')
                {
                    pictures_individualpage = true;
                    KreateWebsites.Generate.kreatelog("pictures individualpage flag set");
                }
                else
                    pictures_individualpage = false;
                // pictures_individualpage = individualpage.Equals("1", StringComparison.Ordinal);


            }
           

            if (Common.Pictures.includepictures == true)
            {
                //  This read image files from directory. 
                foreach (string path in fileEntries)
                {
                    i++;





                    string name;
                    string extension;

                    if (File.Exists(path))
                    {
                        // This path is a file

                      



                        url = System.IO.Path.GetFileName(path);
                        name = System.IO.Path.GetFileNameWithoutExtension(path);
                        extension = System.IO.Path.GetExtension(path);

                        //apr 2024
                        /*
                        string name_without_https = "";
                        name_without_https = GetImageName(name);
                        name = name_without_https;

                        */

                        /* Apr 14 2024 */
                        /*
                        int lastSlashIndex = -1;
                        if (name.StartsWith("https://"))
                        {
                            lastSlashIndex = name.LastIndexOf('/');
                            if (lastSlashIndex != -1)
                            { 
                            
                            }
                        }
                        */

                        if ((extension.ToLower() == ".jpg") || (extension.ToLower() == ".jpeg") || (extension.ToLower() == ".png"))
                        {
                          //  thumbnailurl = ImagePath + thumbnail_path + url;
                           // imagefullurl = ImagePath + url;
                             GetImageFullUrl(ImagePath, url, thumbnail_path,   ref imagefullurl, ref thumbnailurl ); // test

                            displayname = name;
                            // Sep17 GetPictureAttributes(inputdir, name, ref text, ref displayname);
                            GetPictureAttributes(inputdir,name, url, ref text, ref displayname);
                            string navigatename = displayname;
                            /*  individual page generation is not working with this, store displayname without cleaning into navigate name */
                            displayname = displayname.Replace("-", " ");
                            displayname = displayname.Replace("_", " ");
                            displayname = displayname.ToUpper();
                             

                            if (pictures_individualpage == true)
                            {
                               // navigateurl = name + ".html";  // change it to displayname .html once able to generate displayname.html
                                navigateurl = displayname + ".html";
                            }
                            else
                            {
                               // Jan 2016 navigateurl = imagefullurl;
                                // Added in Jan 2016
                                navigateurl = Common.Pictures.defaultpath + Common.Gallery.photoviewer + @"?imageurl=" + imagefullurl; // Jan 2016
                            }
                          //Nov 18  Photos.GetAltTag(inputdir, @"pictures.keyword", imagefullurl, name, displayname, title, continent, country, state, statename, city, category, subcategory, ref alt);
                            string altfile = name + ".keyword";
                            Photos.GetAltTag(inputdir, altfile, imagefullurl, name, displayname, title, continent, country, state, statename, city, category, subcategory, ref alt);
                             Photos.GetPictureNavigateurl( inputdir, name,  url, ref  navigateurl) ;

                            navigateurl2 = navigateurl; // dec 2021.  uncomment this. it will use photoviewer.php etc
                            dt.Rows.Add(i, thumbnailurl, name, displayname, alt, imagefullurl, title, text, continent, country, state, statename, city, category, subcategory, navigateurl,navigateurl2); // Jan 2016 added navigate url2
                       //     dt.Rows.Add(i, thumbnailurl, name, displayname, imagefullurl, title, text, continent, country, state, statename, city, category, subcategory, navigateurl);
                            text = "";  // reset column for next slide.
                        }


                        i++;

                        if (extension.ToLower() == ".inc")
                        {
                          //  labeltext.Text = labeltext.Text + System.IO.File.ReadAllText(path);
                        }



                    }
                    else
                    {
                        Console.WriteLine("No rows found.");
                    }




                }  // for

            }  // if includepictures == true

            //  This read pictures.list. You can specify picture filename in this file.
            if (File.Exists(inputdir + @"\pictures.list"))
            {

                System.IO.StreamReader file =
                   new System.IO.StreamReader(inputdir + @"\pictures.list");
                while ((url = file.ReadLine()) != null)
                {
                    name = url; // remove .jpg

                    name = name.Replace(".jpg", "");
                    name = name.Replace(".jpeg", "");
                    name = name.Replace(".png", "");
                    name = name.Replace(".JPG", "");
                    name = name.Replace(".JPEG", "");
                    name = name.Replace(".PNG", "");


                  

                        //     dt.Rows.Add(i, imagefullurl, name);

                        /* test 
                        thumbnailurl = ImagePath + thumbnail_path + url;
                        imagefullurl = ImagePath + url;
                        */
                        GetImageFullUrl(ImagePath, url, thumbnail_path, ref imagefullurl, ref thumbnailurl); // test
                                                                                                             //   GetSlideAttributes(inputdir, name, ref text);
                        displayname = name;
                        // Sep 17 GetPictureAttributes(inputdir, name, ref text, ref displayname);
                        GetPictureAttributes(inputdir, name, url, ref text, ref displayname);
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
                            //Jan 2016   navigateurl = imagefullurl;
                            // Added in Jan 2016
                            navigateurl = Common.Pictures.defaultpath + Common.Gallery.photoviewer + @"?imageurl=" + imagefullurl; // Jan 2016
                        }
                        //Nov 18  Photos.GetAltTag(inputdir, @"pictures.keyword", imagefullurl, name, displayname, title, continent, country, state, statename, city, category, subcategory, ref alt);

                        string altfile = name + ".keyword";
                        Photos.GetAltTag(inputdir, altfile, imagefullurl, name, displayname, title, continent, country, state, statename, city, category, subcategory, ref alt);

                        Photos.GetPictureNavigateurl(inputdir, name, url, ref navigateurl);
                        // Added in Jan 2016, in this case navigate url2 is not used as navigateurl has values
                        navigateurl2 = Common.Pictures.defaultpath + Common.Gallery.photoviewer + @"?imageurl=" + imagefullurl; // Jan 2016

                        navigateurl2 = navigateurl; // dec 2021.  uncomment this. it will use photoviewer.php etc
                        dt.Rows.Add(i, thumbnailurl, name, displayname, alt, imagefullurl, title, text, continent, country, state, statename, city, category, subcategory, navigateurl, navigateurl2);  //Jan 2016
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
            setslide(subfolder);

           
            return dt;

        }

        public static void GetPictureComments(string inputdir, ref string comments)
        {
            if (File.Exists(inputdir + @"\pictures.comments"))
            {

                comments = System.IO.File.ReadAllText(inputdir + @"\pictures.comments");
       
            }
        }

        public static void setslide(string subfolder)
        {
            /*
            string slideurl = "http://pictures.indiacitytrip.com/slide1/" + subfolder + ".jpg";

            if (File.Exists(slideurl))
            {

                slide.ImageUrl = slideurl;
            }
            else
            {
                slide.ImageUrl = "http://pictures.indiacitytrip.com/slide1/" + "USA.jpg";
            }
            */
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


        public static DataTable GetArticleLinks(string inputdir)
        {

            //   hyperlinkMore.Text = "Articles";



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

                    if ((extension.ToLower() == ".html") || (extension.ToLower() == ".htm"))
                    {
                        if (name.ToLower() != "index")
                        {
                            dt.Rows.Add(i, url, name);
                        }


                        i++;

                    }


                }




            }  // for



            string[] subdirectoryEntries = Directory.GetDirectories(inputdir);


            DirectoryInfo dInfo = new DirectoryInfo(inputdir);


            foreach (DirectoryInfo di in dInfo.GetDirectories())
            {

                // this ensure only those directory links are added that have index file
                string linkpath = inputdir + @"/" + di.Name.ToString() + @"/" + "index.html";


                if (File.Exists(linkpath))
                {
                    dt.Rows.Add(i, di.Name.ToString(), di.Name.ToString());
                    i++;
                }

            }


            if (dt.Rows.Count > 0)
            {



                //     RepLinks.DataSource = dt;
                //    RepLinks.DataBind();



            }


            return dt;



        }

        public static void GetPictureAttributes(string inputdir, string name, ref string text, ref string picname)
        {
            string picalt=null;
            if (File.Exists(inputdir + @"\" + name + @".comments"))
            {
                text = System.IO.File.ReadAllText(inputdir + @"\" + name + @".comments");
                if (text.Length > 300)
                {
                    text = text.Substring(0, 300);
                }
               //    Response.Write("<br/> Picture Attribute : " + inputdir + " " + name + "," + text + "<br/>");

            }
            Generate.kreatelog("Get Picture attribute of file " + inputdir + @"\" + name + @".name");

            if (File.Exists(inputdir + @"\" + name + @".name"))
            {
                picname = System.IO.File.ReadAllText(inputdir + @"\" + name + @".name");
                picname = picname.TrimEnd('\r', '\n');  // remove new line
                if (picname.Length > 30)
                {
                    picname = picname.Substring(0, 30);
                }
                // Response.Write("<br/> Picture Attribute : " + inputdir + " " + name + "," + picname + "<br/>");

            }
            else
            {

                GetDefaultPictureAttribute(name, ref picname, ref picalt);  //   Aug 2 , 2016

                picalt = picname; // picture alt attribute
             //Nov 14   Generate.filegenerate(inputdir+ @"\", @"gen.name", @".name", 1, name);
                 Generate.filegenerate(inputdir + @"\", @"gen.name", @".name", 1, name, Common.genName);
                
            }
            Generate.filegenerateImage(inputdir + @"\", @"gen.image", @".image", 1, name, picname, picalt, "blankurl");  // null is passed to picalt, name if .name exist. IMPROVE
            Generate.ConfigFileCheckAndGenerate(inputdir + subfolder + @"\", @"gen.comments", @".comments", 0, name); // 0 to write blank
            Generate.ConfigFileCheckAndGenerate(inputdir + subfolder + @"\", @"gen.articleslist", @".articleslist", 0, name); // 0 to write blank  Dec 28 2015
            Generate.ConfigFileCheckAndGenerate(inputdir + subfolder + @"\", @"gen.title", @".title", 0, name); // 2024 

        }

        public static void GetPictureAttributes(string inputdir, string name, string url, ref string text, ref string picname)
        {
            string picalt=null;
            if (File.Exists(inputdir + @"\" + name + @".comments"))
            {
                text = System.IO.File.ReadAllText(inputdir + @"\" + name + @".comments");
                if (text.Length > 300)
                {
                    text = text.Substring(0, 300);
                }
                //    Response.Write("<br/> Picture Attribute : " + inputdir + " " + name + "," + text + "<br/>");

            }
            Generate.kreatelog("Get Picture attribute of file " + inputdir + @"\" + name + @".name");

            if (File.Exists(inputdir + @"\" + name + @".name"))
            {
                picname = System.IO.File.ReadAllText(inputdir + @"\" + name + @".name");
                picname = picname.TrimEnd('\r', '\n');  // remove new line
                picalt = picname;
                if (picname.Length > 30)
                {
                    picname = picname.Substring(0, 30);
                }
                // Response.Write("<br/> Picture Attribute : " + inputdir + " " + name + "," + picname + "<br/>");

            }
            else
            {
                GetDefaultPictureAttribute(name, ref picname, ref picalt);  //   Aug 2 , 2016
               picalt = picname; // picture alt attribute
             //Nov 14   Generate.filegenerate(inputdir + @"\", @"gen.name", @".name", 1, name);
               Generate.filegenerate(inputdir + @"\", @"gen.name", @".name", 1, name, Common.genName);
               
            }
            Generate.filegenerateImage(inputdir + @"\", @"gen.image", @".image", 1, name, picname, picalt, url);  //url is full path including extensio
            Generate.ConfigFileCheckAndGenerate(inputdir + subfolder + @"\", @"gen.comments", @".comments", 0, name); // 0 to write blank
            Generate.ConfigFileCheckAndGenerate(inputdir + subfolder + @"\", @"gen.articleslist", @".articleslist", 0, name); // 0 to write blank  Dec 28 2015
            Generate.ConfigFileCheckAndGenerate(inputdir + subfolder + @"\", @"gen.title", @".title", 0, name); // 2024 


        }


        public static void GetDefaultPictureAttribute (string name, ref string picname, ref string picalt)
        {

            if (File.Exists(Common.Image_Name_Path + @"\" + name + @".name"))
            {
                picname = System.IO.File.ReadAllText(Common.Image_Name_Path + @"\" + name + @".name");
                picname = picname.TrimEnd('\r', '\n');  // remove new line
                picalt = picname;
                if (picname.Length > 30)
                {
                    picname = picname.Substring(0, 30);
                }
            }
        }

        public static void GetPictureNavigateurl(string inputdir, string name, string url,  ref string navigateurl)
        {

            KreateWebsites.Generate.kreatelog("in navigaeurl 4 =" +inputdir + name);
            if (File.Exists(inputdir + @"\" + name + @".navigateurl"))
            {
                KreateWebsites.Generate.kreatelog2("in navigaeurl =" + inputdir + name);
                navigateurl = System.IO.File.ReadAllText(inputdir + @"\" + name + @".navigateurl");
                navigateurl = navigateurl.TrimEnd('\r', '\n');  // remove new line

                KreateWebsites.Generate.kreatelog2("in navigaeurl value =" + navigateurl);


            }

          //  Generate.filegenerateImage(inputdir + @"\", @"gen.navigateurl", @".image", 1, name, picname, picalt, url);  //url is full path including extensio

            // do nothing if name.navigateurl exist.
            // generate if gen.navigateurl exist and have 1 - name, 51 name + /,  52 name + .html
            Generate.ConfigFileCheckAndGenerate(inputdir +  @"\", @"gen.navigateurl", @".navigateurl", 51, name); // 0 to write blank
        }

        public static void GetPictureNavigateurl(string inputdir, string name, string url, ref string navigateurl, ref bool navigateflag)  //Apr 2016 added so that navigate url works
        {
            

            KreateWebsites.Generate.kreatelog("in navigaeurl 5 parameter =" + inputdir + name);
            if (File.Exists(inputdir + @"\" + name + @".navigateurl"))
            {
                KreateWebsites.Generate.kreatelog2("in navigaeurl =" + inputdir + name);
                navigateurl = System.IO.File.ReadAllText(inputdir + @"\" + name + @".navigateurl");
                navigateurl = navigateurl.TrimEnd('\r', '\n');  // remove new line

                KreateWebsites.Generate.kreatelog2("in navigaeurl value =" + navigateurl);

                navigateflag = true;

            }

            //  Generate.filegenerateImage(inputdir + @"\", @"gen.navigateurl", @".image", 1, name, picname, picalt, url);  //url is full path including extensio

            // do nothing if name.navigateurl exist.
            // generate if gen.navigateurl exist and have 1 - name, 51 name + /,  52 name + .html
            Generate.ConfigFileCheckAndGenerate(inputdir + @"\", @"gen.navigateurl", @".navigateurl", 51, name); // 0 to write blank

            }
          public static void GetAltTag(string inputdir, string file, string imagefullurl, string name, string displayname, string title, string continent,string country, string state, string statename, string city, string category, string subcategory, ref string alt)
          {

              if (displayname.Length > 8)
              {
                  alt = displayname;
              }
              else
              {
                  alt = name;
              }

              if (alt.Length < 10)
              {
                  alt = displayname;

                   string keywordfile = inputdir + @"\" + file;
                  if (File.Exists(keywordfile))
                  {
                      string text = System.IO.File.ReadAllText(keywordfile);
                      if (text.Length > 100)
                      {
                          text = text.Substring(0, 100);
                      }

                      alt = text;
                      //    Response.Write("<br/> Picture Attribute : " + inputdir + " " + name + "," + text + "<br/>");

                  }
              }
          }

          public static  DataTable GetImageData(string articlefile, string inputdir)
          {


              string displayname;
              string alt = "photos";


              DataTable dt = GetTable();
          //    GetImagePath(inputdir);


           //   string[] fileEntries = Directory.GetFiles(inputdir);
              int i = 0;
              string url, imagefullurl = null, thumbnailurl = null;
              string navigateurl = null;
              string navigateurl2 = null;
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


                 
                    GetImageFullUrl(ImagePath, url, thumbnail_path, ref imagefullurl, ref thumbnailurl); // later enable this test
                  
                      displayname = name;
                 //     GetPictureAttributes(inputdir, name, ref text, ref displayname);
                      GetPictureAttributes(inputdir, name, url, ref text, ref displayname);
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

                  //Nov 18    Photos.GetAltTag(inputdir, @"pictures.keyword", imagefullurl, name, displayname, title, continent, country, state, statename, city, category, subcategory, ref alt);
                      string altfile = name + ".keyword";
                      Photos.GetAltTag(inputdir, altfile, imagefullurl, name, displayname, title, continent, country, state, statename, city, category, subcategory, ref alt);

                    navigateurl2 = navigateurl; // dec 2021.  uncomment this. it will use photoviewer.php etc
                    dt.Rows.Add(i, thumbnailurl, name, displayname, alt, imagefullurl, title, text, continent, country, state, statename, city, category, subcategory, navigateurl,navigateurl2);  //Jan  2016
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
              setslide(subfolder);


              return dt;

          }
        // Change - can comment read path and embed other files. with this gallery, pictures, image can use comments to add articles.
          public static void GetImageComments(string articlefile, ref string comments)
          {

             string  commentsfile = articlefile ; 
            commentsfile = commentsfile.Replace(".imagelist", ".comments");
             commentsfile = commentsfile.Replace(".list", ".comments");

             KreateWebsites.Generate.kreatelog("commentsfile = " + commentsfile);
              if (File.Exists(commentsfile))
              {

                  comments = System.IO.File.ReadAllText(commentsfile);
              }
              
          }

        /* Apr 2024 */
        public static string GetImageName(string imageurl)
        {
            // int lastSlashIndex = -1;
            if (imageurl.StartsWith("https://"))
            {

                string[] urlParts = imageurl.Split('/');
                string url = urlParts.Last();
             

            }
            else
            {
                url = imageurl;

            }


            /*

            lastSlashIndex = name.LastIndexOf('/');
            if (lastSlashIndex != -1)
            {

            }
            */

            return url;
            }
       
    }
}






