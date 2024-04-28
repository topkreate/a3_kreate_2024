
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
    public class Slides
    {
        protected static string thumbnail_path = Common.Slides.thumbnailpath + @"/";
  // Oct1      protected static string ImagePath = Common.ImagePath.ToString();
 //  Oc1     protected static string SlidePath = Common.SlidePath;
        protected static string ImagePath = Common.SlidePath;
        protected static string PicturesPath = Common.Pictures.defaultpath;
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
        protected static string continent = "all";
        protected static string country = "all";
        protected static string state = "all";
        protected static string statename = "all";
        protected static string city = "all";
        protected static string category = "all";
        protected static string subcategory = "all";
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
                table.Columns.Add("displayname", typeof(string)); //Oct1
                table.Columns.Add("alt", typeof(string)); //Oct1

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
                table.Columns.Add("navigateurl", typeof(string));  //Oct1



            }
            catch (Exception e)
            {
                // Response.Write("Exception is : " + e.Message);
            }


            return table;



        }

        static DataTable GetPhotoTable(string inputdir)
        {


            DataTable table = new DataTable();
            try
            {





                table.Columns.Add("id", typeof(int));
                table.Columns.Add("thumbnailurl", typeof(string));
                table.Columns.Add("name", typeof(string));


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




            }
            catch (Exception e)
            {
                // Response.Write("Exception is : " + e.Message);
            }


            return table;



        }
        /*Oct1
        public static void GetSlidePath(string inputdir)
        {



           
            SlidePath = Common.Slides.defaultpath;
            if (File.Exists(inputdir + @"\slides.path"))
            {
                string str = System.IO.File.ReadAllText(inputdir + @"\slides.path");

                SlidePath = str.TrimEnd('\r', '\n');  

            }
        }
        */
        public static void GetPicturesPath(string inputdir)
        {



            // Default value of pictures path is t\aken from global. The value can be overriden by providing a value in file pictures.path 
            PicturesPath = Common.Pictures.defaultpath;
            if (File.Exists(inputdir + @"\slidespictures.path"))
            {
                string str = System.IO.File.ReadAllText(inputdir + @"\slidespictures.path");

                PicturesPath = str.TrimEnd('\r', '\n');  // This will remove any combination of carriage returns and newlines from 

            }
        }

        public static DataTable GetData(string inputdir)
        {
            string displayname;
            string alt = "slides";

            DataTable dt = GetTable(inputdir);
          //  GetSlidePath(inputdir);

          
            GetImagePath(inputdir);
            GetThumbnailPath(inputdir); //added to ensure each folder has different thumbnailpath



            int i = 0;
            

            //    Response.Write("inputdir = " + inputdir + "<br/>" );

            string[] fileEntries = Directory.GetFiles(inputdir);
          
            string url, imagefullurl = null, thumbnailurl = null;
            string navigateurl = null;

            bool pictures_individualpage = Common.Slides.individualpage;
            if (File.Exists(inputdir + @"\slides.individualpage"))
            {
                string individualpage = System.IO.File.ReadAllText(inputdir + @"\slides.individualpage");
                individualpage.Trim();

                if (individualpage[0] == '1')
                    pictures_individualpage = true;
                else
                    pictures_individualpage = false;
                // pictures_individualpage = individualpage.Equals("1", StringComparison.Ordinal);


            }


            //  This read image files from directory. 

            if (Common.Slides.includepictures == true)
            {
                foreach (string path in fileEntries)
                {
                    i++;



                    string name;
                    string extension;

                    //      Response.Write("path = " + path + "<br/>");

                    if (File.Exists(path))
                    {
                        // This path is a file

                        url = System.IO.Path.GetFileName(path);
                        name = System.IO.Path.GetFileNameWithoutExtension(path);
                        extension = System.IO.Path.GetExtension(path);

                        if ((extension.ToLower() == ".jpg") || (extension.ToLower() == ".jpeg") || (extension.ToLower() == ".png"))
                        {
                          //Oct1  thumbnailurl = SlidePath + thumbnail_path + url;
                           //Oct1  imagefullurl = SlidePath + url;
                            Photos.GetImageFullUrl(ImagePath, url, thumbnail_path, ref imagefullurl, ref thumbnailurl); // test
                            displayname = name;
                            // Sep17 GetPictureAttributes(inputdir, name, ref text, ref displayname);
                            Photos.GetPictureAttributes(inputdir, name, url, ref text, ref displayname);
                            
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
                                navigateurl = imagefullurl;
                            }
                            Photos.GetAltTag(inputdir, @"slides.keyword", imagefullurl, name, displayname, title, continent, country, state, statename, city, category, subcategory, ref alt);
                            dt.Rows.Add(i, thumbnailurl, name, displayname, alt, imagefullurl, title, text, continent, country, state, statename, city, category, subcategory, navigateurl); // Oct1
                          //  Photos.GetImageFullUrl(ImagePath, url, thumbnail_path, ref imagefullurl, ref thumbnailurl); //Oct1

                         //   GetSlideAttributes(inputdir, name, ref text); Oct1
             
                      
                          //Oct1  dt.Rows.Add(i, thumbnailurl, name, imagefullurl, title, text, continent, country, state, statename, city, category, subcategory);

                            text = "";  // reset column for next slide.
                        }


                        i++;

                        if (extension.ToLower() == ".inc")
                        {
                         //   labeltext.Text = labeltext.Text + System.IO.File.ReadAllText(path);
                        }



                    }
                    else
                    {
                        Console.WriteLine("No rows found.");
                    }




                }  // for

            }// if includepictures == true

            //  This read pictures.list. You can specify picture filename in this file.
            if (File.Exists(inputdir + @"\slides.list"))
            {

                System.IO.StreamReader file =
                   new System.IO.StreamReader(inputdir + @"\slides.list");
                while ((url = file.ReadLine()) != null)
                {
                    name = url; // remove .jpg

                    name = name.Replace(".jpg", "");
                    name = name.Replace(".jpeg", "");
                    name = name.Replace(".png", "");
                    name = name.Replace(".JPG", "");
                    name = name.Replace(".JPEG", "");
                    name = name.Replace(".PNG", "");

                    Photos.GetImageFullUrl(ImagePath, url, thumbnail_path, ref imagefullurl, ref thumbnailurl); // test
                    displayname = name;
                    // Sep 17 GetPictureAttributes(inputdir, name, ref text, ref displayname);
                    Photos.GetPictureAttributes(inputdir, name, url, ref text, ref displayname);
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
                    Photos.GetAltTag(inputdir, @"slides.keyword", imagefullurl, name, displayname, title, continent, country, state, statename, city, category, subcategory, ref alt);
                    dt.Rows.Add(i, thumbnailurl, name, displayname, alt, imagefullurl, title, text, continent, country, state, statename, city, category, subcategory, navigateurl);
                   //Oct1 thumbnailurl = SlidePath + thumbnail_path + url;
                    //Oct 1 imagefullurl = SlidePath + url;
                 
                    //Oct1 GetSlideAttributes(inputdir, name, ref text);
               
               //Oct1     dt.Rows.Add(i, thumbnailurl, name, imagefullurl, title, text, continent, country, state, statename, city, category, subcategory);
                    text = "";  // reset column for next slide.
                }

                file.Close();
                GetPictures(inputdir);  // what does this do


            }



            if (dt.Rows.Count > 0)
            {

            

                if (Common.Slides.slidegenerate == true)
                {

             //       RepeaterSlide.DataSource = dt;
               //     RepeaterSlide.DataBind();
                }


            }



            //   GetPhotoLinks(inputdir); This add jpg url
            setslide(subfolder);
            return dt;

        }


        public static void GetSlideAttributes(string inputdir, string name, ref string text)
        {

            if (File.Exists(inputdir + @"\" + name + @".comments"))
            {
                text = System.IO.File.ReadAllText(inputdir + @"\" + name + @".comments");
                if (text.Length > 50)
                {
                    text = text.Substring(0, 50);
                }

            }

        }

        public static void GetPicturesAttributes(string inputdir, string name, ref string text)
        {

            if (File.Exists(inputdir + @"\" + name + @".comments"))
            {
                text = System.IO.File.ReadAllText(inputdir + @"\" + name + @".comments");
                if (text.Length > 300)
                {
                    text = text.Substring(0, 300);
                }

            }

        }

        public static void setslide(string subfolder)
        {
            /*
            string slideurl = "http://pictures.indiacitytrip.com/slide3/" + subfolder + ".jpg";

            if (File.Exists(slideurl))
            {

                slide.ImageUrl = slideurl;
            }
            else
            {
                slide.ImageUrl = "http://pictures.indiacitytrip.com/slide3/" + "USA.jpg";
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


        public static void GetArticleLinks(string inputdir)
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






        }


        public static void GetPictures(string inputdir)
        {


            string thumbnailurl;


            DataTable dt = GetPhotoTable(inputdir);
            GetPicturesPath(inputdir);


            string[] fileEntries = Directory.GetFiles(inputdir);
            int i = 0;
            string url, imagefullurl;


            //  This read image files from directory. 



            //  This read pictures.list. You can specify picture filename in this file.
            if (File.Exists(inputdir + @"\slidespictures.list"))
            {

                System.IO.StreamReader file =
                   new System.IO.StreamReader(inputdir + @"\slidespictures.list");
                while ((url = file.ReadLine()) != null)
                {
                    name = url; // remove .jpg

                    name = name.Replace(".jpg", "");
                    name = name.Replace(".jpeg", "");
                    name = name.Replace(".png", "");
                    name = name.Replace(".JPG", "");
                    name = name.Replace(".JPEG", "");
                    name = name.Replace(".PNG", "");
                    thumbnailurl = PicturesPath + thumbnail_path + url;
                    imagefullurl = PicturesPath + url;

                    GetPicturesAttributes(inputdir, name, ref text);

                    //       Response.Write("name = " + name + "<br/>" + url);
                    name = name.Replace("-", " ");
                    name = name.Replace("_", " ");
                    name = name.ToUpper();

                    // dt.Rows.Add(i, imagefullurl, name);
                    dt.Rows.Add(i, thumbnailurl, name, imagefullurl, title, text, continent, country, state, statename, city, category, subcategory);
                    text = "";  // reset column for next slide.
                }

                file.Close();


            }



            if (dt.Rows.Count > 0)
            {

                //     Response.Write("Count is " + dt.Rows.Count.ToString());

                if (Common.Slides.picturegenerate == true)
                {
              //      RepDetails.DataSource = dt;
                //    RepDetails.DataBind();
                }




            }



            //   GetPhotoLinks(inputdir); This add jpg url
            setslide(subfolder);

        }

        public static void GetImagePath(string inputdir)
        {



            // Default value of pictures path is t\aken from Common. The value can be overriden by providing a value in file pictures.path 
            ImagePath = Common.SlidePath;
            if (File.Exists(inputdir + @"\slides.path"))
            {
                string str = System.IO.File.ReadAllText(inputdir + @"\slides.path");

                ImagePath = str.TrimEnd('\r', '\n');  // This will remove any combination of carriage returns and newlines from 
                Generate.AppendSlash(ref ImagePath);

            }
        }
        public static void GetThumbnailPath(string inputdir)
        {



            // Default value of pictures path is t\aken from Common. The value can be overriden by providing a value in file pictures.path 
            thumbnail_path = Common.Slides.thumbnailpath;
            KreateWebsites.Generate.kreatelog("check thumbnail 2  " + inputdir + " " + thumbnail_path);


            if (File.Exists(inputdir + @"\slides_thumbnails.path"))
            {
                string str = System.IO.File.ReadAllText(inputdir + @"\slides_thumbnails.path");

                thumbnail_path = str.TrimEnd('\r', '\n');  // This will remove any combination of carriage returns and newlines from 
                Generate.AppendSlash(ref thumbnail_path);

                KreateWebsites.Generate.kreatelog("slides thumbnail found in " + inputdir + " " + thumbnail_path);
            }

        }

    }
}






