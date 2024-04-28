
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
    public class Gallery
    {
        
      
        protected static string thumbnail_path = Common.Gallery.thumbnailpath;
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
                table.Columns.Add("url", typeof(string));
                table.Columns.Add("name", typeof(string));
                table.Columns.Add("linkurl", typeof(string));

                           
        
                table.Columns.Add("displayname", typeof(string));
                table.Columns.Add("alt", typeof(string));
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
            ImagePath = Common.Gallery.defaultpath ;
     //       ImagePath = Common.ImagePath.ToString();
            Generate.kreatelog("GetImagePath called " + ImagePath);
            if (File.Exists(inputdir + @"\gallery.path"))
            {
                string str = System.IO.File.ReadAllText(inputdir + @"\gallery.path");

                ImagePath = str.TrimEnd('\r', '\n', ' ', '\t');  // This will remove any combination of carriage returns and newlines from 
                Generate.AppendSlash(ref ImagePath); // add slaah is missing at end
               // ImagePath = str.TrimEnd('\r', '\n');  // This will remove any combination of carriage returns and newlines from 
              
            }
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
        public static void GetLinkUrl(string inputdir, string url, ref string linkurl)
        {
           
            if (File.Exists(inputdir + url + ".link" ))
            {
                string str = System.IO.File.ReadAllText(inputdir + url + ".link");

                linkurl = str.TrimEnd('\r', '\n', ' ', '\t');  // This will remove any combination of carriage returns and newlines from 
            }



        }
        public static DataTable GetData(string inputdir)
        {

            string displayname;
            string alt = "gallery";
            string navigateurl = null;
            string navigateurl2 = null;  // Jan 2016
            bool navigateflag = false; // Apr 2016
            DataTable dt = GetTable(inputdir);
           GetImagePath(inputdir);
       
            GetThumbnailPath(inputdir);


            int i = 0;
            string url, imagefullurl=null; // added null Jan 2016
            string linkurl=null;

            //    Response.Write("inputdir = " + inputdir + "<br/>" );

            string[] fileEntries = Directory.GetFiles(inputdir);

            //  This read image files from directory. 
            Generate.kreatelog("In Gallery Get Data ");
            foreach (string path in fileEntries)
            {
                i++;

                Generate.kreatelog("In for loop "  + path);

                string name;
                string extension;

                if (Common.Gallery.includepictures == true)
                {
                    //      Response.Write("path = " + path + "<br/>");

                    Generate.kreatelog("In if " + path);

                    if (File.Exists(path))
                    {
                        // This path is a file

                        url = System.IO.Path.GetFileName(path);
                        name = System.IO.Path.GetFileNameWithoutExtension(path);
                        extension = System.IO.Path.GetExtension(path);

                        Generate.kreatelog("In file exist " + path);
                        if ((extension.ToLower() == ".jpg") || (extension.ToLower() == ".jpeg") || (extension.ToLower() == ".png"))
                        {
                          //Jan 2016  imagefullurl = ImagePath + thumbnail_path + url;
                            ComputeThumbnail(ImagePath, url, ref imagefullurl);

                            displayname = name;
                         // Sep17   Photos.GetPictureAttributes(inputdir, name, ref text, ref displayname);
                            Photos.GetPictureAttributes(inputdir, name, url, ref text, ref displayname);
                            string navigatename = displayname;
                            /*  individual page generation is not working with this, store displayname without cleaning into navigate name */
                            displayname = displayname.Replace("-", " ");
                            displayname = displayname.Replace("_", " ");
                            displayname = displayname.ToUpper();
                             


                            linkurl = ImagePath + url;
                            // dt.Rows.Add(i, imagefullurl, name, linkurl); // Apr 7
                            Photos.GetAltTag(inputdir, @"gallery.keyword", imagefullurl, name, displayname, title, continent, country, state, statename, city, category, subcategory, ref alt);
                            navigateflag = false;

                            Generate.kreatelog("In picture navigate url " + path);
                            Photos.GetPictureNavigateurl(inputdir, name, url, ref  linkurl, ref navigateflag);

                            navigateurl = linkurl;

                            if (navigateflag == true)
                            {

                                Generate.kreatelog("In navigateurl true " +  linkurl  + " " + navigateurl);
                                navigateurl2 = linkurl;
                            }
                            else
                            {
                                navigateurl2 = Common.Pictures.defaultpath + Common.Gallery.photoviewer + @"?imageurl=" + linkurl; // Jan 2016

                                Generate.kreatelog("In navigateurl false " + linkurl + " " + navigateurl + " " + navigateurl2);
                            }

                            navigateurl2 = navigateurl; // dec 2021.  uncomment this. it will use photoviewer.php etc

                            Generate.kreatelog("In navigateurl return at end " + linkurl + " " + navigateurl + " " + navigateurl2);

                            dt.Rows.Add(i, imagefullurl, name, linkurl, displayname, alt, title, text, continent, country, state, statename, city, category, subcategory, navigateurl, navigateurl2);  // Jan 2016. added url2
                            text = "";  // reset column for next slide.
                            i++;
                        }


                       

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

            } // includepictures == true

            //  This read pictures.list. You can specify picture filename in this file.
            if (File.Exists(inputdir + @"\gallery.list"))
            {

                System.IO.StreamReader file =
                   new System.IO.StreamReader(inputdir + @"\gallery.list");
                while ((url = file.ReadLine()) != null)
                {
                    name = url; // remove .jpg

                    name = name.Replace(".jpg", "");
                    name = name.Replace(".jpeg", "");
                    name = name.Replace(".png", "");
                    name = name.Replace(".JPG", "");
                    name = name.Replace(".JPEG", "");
                    name = name.Replace(".PNG", "");



                    


                 // Jan 2016   imagefullurl = ImagePath + thumbnail_path + url;
                    ComputeThumbnail(ImagePath, url, ref imagefullurl);
                    if (Common.Gallery.individualpage == false)
                    {
                        Generate.kreatelog("In navigateurl true 1 " + linkurl + " " + navigateurl);
                        linkurl = ImagePath + url;// this display direct image
                    }
                    else
                    {
                        linkurl = name + ".html"; // this display individual page 
                        Generate.kreatelog("In navigateurl false " + linkurl + " " + navigateurl + " " + navigateurl2);
                    }
                    GetLinkUrl(inputdir, url, ref linkurl);

                    // APR 7
                    displayname = name;
                 // Sep 17   Photos.GetPictureAttributes(inputdir, name, ref text, ref displayname);
                    Photos.GetPictureAttributes(inputdir, name,url,  ref text, ref displayname);
                    string navigatename = displayname;
                    /*  individual page generation is not working with this, store displayname without cleaning into navigate name */
                    displayname = displayname.Replace("-", " ");
                    displayname = displayname.Replace("_", " ");
                    displayname = displayname.ToUpper();

                    Generate.kreatelog("gallary display name =" + name + " " + displayname);

                    Photos.GetAltTag(inputdir, @"gallery.keyword", imagefullurl, name, displayname, title, continent, country, state, statename, city, category, subcategory, ref alt);
                    navigateflag = false;
                    Photos.GetPictureNavigateurl(inputdir, name, url, ref  linkurl, ref navigateflag);

                    navigateurl = linkurl;

                    if (navigateflag == true)
                    {

                        Generate.kreatelog("In navigateurl true 3 " + linkurl + " " + navigateurl);
                        navigateurl2 = linkurl;
                    }
                    else
                    {
                        navigateurl2 = Common.Pictures.defaultpath + Common.Gallery.photoviewer + @"?imageurl=" + linkurl; // Jan 2016
                        Generate.kreatelog("In navigateurl false 3 " + linkurl + " " + navigateurl + " " + navigateurl2);
                    }


    

                    navigateurl = linkurl;
                    Generate.kreatelog("gallary display name = " + linkurl + " " + navigateurl + "  " + navigateurl2);

                    // navigateurl2 = navigateurl; // dec 2021.  comment this. it will use photoviewer.php etc

                    dt.Rows.Add(i, imagefullurl, name, linkurl, displayname, alt, title, text, continent, country, state, statename, city, category, subcategory, navigateurl, navigateurl2); // Jan 2016. added url2
                    text = "";  // reset column for next slide.

                 // Apr 7   dt.Rows.Add(i, imagefullurl, name, linkurl);  // id, url,name, linkurl
                    KreateWebsites.Generate.kreatelog(" imagefullurl in gallery is " + imagefullurl);
                    i++;
                }

                file.Close();


            }



            if (dt.Rows.Count > 0)
            {

                //     Response.Write("Count is " + dt.Rows.Count.ToString());

           //     RepDetails.DataSource = dt;
            //    RepDetails.DataBind();



            }



            //   GetPhotoLinks(inputdir); This add jpg url
            setslide(subfolder);

            if (File.Exists(inputdir + @"\gallery.comments"))
            {

              //  labeltext.Text = labeltext.Text + System.IO.File.ReadAllText(inputdir + @"\gallery.comments");
            }
            return dt;

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

        public static void ComputeThumbnail (string imagepath,string url,  ref string imagefullurl)
        {
            if (thumbnail_path.Contains("http://") || thumbnail_path.Contains("https://"))   /* 2023 */
            {
                imagefullurl = thumbnail_path + url;   // full path is given as http://pictures.kreatewebsites.com/photos400
            }
            else
            {
                imagefullurl = imagepath + thumbnail_path + url;
            }
        }
    }
}






