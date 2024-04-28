
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

    // Change this code to accept anny file with  *.pictures  instead of pictures.list
    // pictures.list is handled by photos
    public class Pictures
    {



       protected static string thumbnail_path = Common.thumbnailpath.ToString();
       protected static string ImagePath = Common.ImagePath.ToString();
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
            ImagePath = Common.ImagePath.ToString();
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
            thumbnail_path = Common.thumbnailpath.ToString();
            KreateWebsites.Generate.kreatelog("check thumbnail  " + inputdir + " " + thumbnail_path);
            if (File.Exists(inputdir + @"\pictures_thumbnails.path"))
            {
                string str = System.IO.File.ReadAllText(inputdir + @"\pictures_thumbnails.path");

                thumbnail_path= str.TrimEnd('\r', '\n');  // This will remove any combination of carriage returns and newlines from 
                Generate.AppendSlash(ref thumbnail_path);

                KreateWebsites.Generate.kreatelog("local thumbnail found in " + inputdir + " " + thumbnail_path );
            }
        }


        public static DataTable GetData(string inputdir)
        {


            string displayname;


            DataTable dt = GetTable(inputdir);
            GetImagePath(inputdir);
            GetThumbnailPath(inputdir);

            /* Dec 2021 */
            KreateWebsites.Generate.kreatelog("pictures.cs data table " + inputdir );

            string[] fileEntries = Directory.GetFiles(inputdir);
            int i = 0;
            string url, imagefullurl, thumbnailurl;
            string navigateurl = null;

              bool pictures_individualpage = Common.Pictures.individualpage;
            if (File.Exists(inputdir + @"\pictures.individualpage"))
            {
                string individualpage = System.IO.File.ReadAllText(inputdir + @"\pictures.individualpage");
                individualpage.Trim();

                if (individualpage[0] == '1')
                    pictures_individualpage = true;
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

                        if ((extension.ToLower() == ".jpg") || (extension.ToLower() == ".jpeg") || (extension.ToLower() == ".png"))
                        {
                            thumbnailurl = ImagePath + thumbnail_path + url;
                            imagefullurl = ImagePath + url;

                            displayname = name;
                         // Sep17   GetPictureAttributes(inputdir, name, ref text, ref displayname);
                            Photos.GetPictureAttributes(inputdir, name, url, ref text, ref displayname);
                            displayname = displayname.Replace("-", " ");
                            displayname = displayname.Replace("_", " ");
                            displayname = displayname.ToUpper();
                            
                            if (pictures_individualpage == true)
                                navigateurl = name + ".html";

                            dt.Rows.Add(i, thumbnailurl, name, displayname, imagefullurl, title, text, continent, country, state, statename, city, category, subcategory, navigateurl);
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


                    thumbnailurl = ImagePath + thumbnail_path + url;
                    imagefullurl = ImagePath + url;

                    //   GetSlideAttributes(inputdir, name, ref text);
                    displayname = name;
                    // Sep 17 GetPictureAttributes(inputdir, name, ref text, ref displayname);
                    Photos.GetPictureAttributes(inputdir, name, url, ref text, ref displayname);

                    displayname = displayname.Replace("-", " ");
                    displayname = displayname.Replace("_", " ");
                    displayname = displayname.ToUpper();



                    if (pictures_individualpage == true)
                        navigateurl = name + ".html";


                    dt.Rows.Add(i, thumbnailurl, name, displayname, imagefullurl, title, text, continent, country, state, statename, city, category, subcategory,navigateurl);

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

            if (File.Exists(inputdir + @"\pictures.comments"))
            {

            //    labeltext.Text = labeltext.Text + System.IO.File.ReadAllText(inputdir + @"\pictures.comments");
            }
            return dt;

        }

        public static DataTable GetPictures(string inputdir)
        {
            // this function is not tested. intention is not make file like Shimla.pictures and it should generate output Shimla.html

            string displayname;


            DataTable dt = GetTable(inputdir);
            GetImagePath(inputdir);
            GetThumbnailPath(inputdir);

            string[] fileEntries = Directory.GetFiles(inputdir);
            int i = 0;
            string url, imagefullurl, thumbnailurl;
            string navigateurl = null;

            bool pictures_individualpage = Common.Pictures.individualpage;
            if (File.Exists(inputdir + @"\pictures.individualpage"))
            {
                string individualpage = System.IO.File.ReadAllText(inputdir + @"\pictures.individualpage");
                individualpage.Trim();

                if (individualpage[0] == '1')
                    pictures_individualpage = true;
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

                        if ((extension.ToLower() == ".pictures") )
                        {

                            System.IO.StreamReader file =
                         new System.IO.StreamReader(path);
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


                                thumbnailurl = ImagePath + thumbnail_path + url;
                                imagefullurl = ImagePath + url;

                                //   GetSlideAttributes(inputdir, name, ref text);
                                displayname = name;
                                // Sep 17 GetPictureAttributes(inputdir, name, ref text, ref displayname);
                                Photos.GetPictureAttributes(inputdir, name, url, ref text, ref displayname);

                                displayname = displayname.Replace("-", " ");
                                displayname = displayname.Replace("_", " ");
                                displayname = displayname.ToUpper();



                                if (pictures_individualpage == true)
                                    navigateurl = name + ".html";
                                else
                                    navigateurl = imagefullurl;

                                dt.Rows.Add(i, thumbnailurl, name, displayname, imagefullurl, title, text, continent, country, state, statename, city, category, subcategory, navigateurl);

                                text = "";  // reset column for next slide.
                            }




                          
                        }


                        i++;

                     



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


                    thumbnailurl = ImagePath + thumbnail_path + url;
                    imagefullurl = ImagePath + url;

                    //   GetSlideAttributes(inputdir, name, ref text);
                    displayname = name;
                  // Sep 17  GetPictureAttributes(inputdir, name, ref text, ref displayname);
                    Photos.GetPictureAttributes(inputdir, name, url, ref text, ref displayname);

                    displayname = displayname.Replace("-", " ");
                    displayname = displayname.Replace("_", " ");
                    displayname = displayname.ToUpper();



                    if (pictures_individualpage == true)
                        navigateurl = name + ".html";


                    dt.Rows.Add(i, thumbnailurl, name, displayname, imagefullurl, title, text, continent, country, state, statename, city, category, subcategory, navigateurl);

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

            if (File.Exists(inputdir + @"\pictures.comments"))
            {

                //    labeltext.Text = labeltext.Text + System.IO.File.ReadAllText(inputdir + @"\pictures.comments");
            }
            return dt;

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
// it may be delted. use photos.GetPictureAttributes
        public static void GetPictureAttributes(string inputdir, string name, ref string text, ref string picname)
        {

            if (File.Exists(inputdir + @"\" + name + @".comments"))
            {
                text = System.IO.File.ReadAllText(inputdir + @"\" + name + @".comments");
                if (text.Length > 300)
                {
                    text = text.Substring(0, 300);
                }
               //    Response.Write("<br/> Picture Attribute : " + inputdir + " " + name + "," + text + "<br/>");
                KreateWebsites.Generate.kreatelog(".comments file for " + inputdir + @"\" + name + @".comments");

            }

            if (File.Exists(inputdir + @"\" + name + @".name"))
            {
                picname = System.IO.File.ReadAllText(inputdir + @"\" + name + @".name");
                if (picname.Length > 30)
                {
                    picname = picname.Substring(0, 30);
                }
                // Response.Write("<br/> Picture Attribute : " + inputdir + " " + name + "," + picname + "<br/>");
                KreateWebsites.Generate.kreatelog(".name file for " + inputdir + @"\" + name + @".name");
            }

        }




    }
}






