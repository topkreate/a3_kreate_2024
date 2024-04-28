
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
    public class Generate
    {




        protected static string competition_name = "all";
        protected static string competition_country = "all";
        protected static string competition_city = "all";
        protected static string winner = "all";
        protected static string winner_country = "all";
        protected static string MatchFormat = "all";
        protected static string category = "all";
        protected static int count = 2000;
        protected static int year = 0;
        protected static int sortOrder = 1;

        protected static string outputpath = null;

        protected static string outputdir;
        public static bool overwrite = false;





        //protected static string local_path;
        protected static string navigate_path;
        protected static string pic_path;
        protected static string PicturePath = Common.Pictures.defaultpath;
        protected static string SlidePath = Common.Slides.defaultpath;
        protected static string GalleryPath = Common.Gallery.defaultpath;
        protected static string picpage = Common.picpage;
        protected static string sitepath;
        protected static string computerpath;
        protected static StreamWriter swlog, swlog2, swsitemap;
        public static bool writelog = true;
        protected static bool swlogopen = false;
        protected static bool swsiteopen = false;

        public static void kreatelog(string line)
        {
            if (writelog == true)
            {
                if (swlogopen == true)
                {

                    try
                    {
                        swlog.WriteLine(line);
                    }
                    catch (Exception)
                    {

                    }
                }
            }

        }
        public static void kreatelog2(string line)
        {
            if (writelog == true)
            {
                if (swlogopen == true)
                {

                    try
                    {
                        swlog2.WriteLine(line);
                    }
                    catch (Exception)
                    {

                    }
                }
            }

        }
        /* 2023 May sitemap */
        public static void kreatesitemap(string line)
        {


            if (swsiteopen == true)
            {

                try
                {
                    swsitemap.WriteLine(line);
                }
                catch (Exception)
                {

                }
            }

            /*
            if (writelog == true)
            {
               if (swsiteopen == true)
                {

                    try
                    {
                        swsitemap.WriteLine(line);
                    }
                    catch (Exception)
                    {

                    }
                }
            }
            
            */
        }
        /*
        public static void kreatelog(string line, bool logflag)
        {
            if (logflag == true)
            {
                swlog.WriteLine(line);
            }

        }
         * */
        public static void Generatesubdirs(string local_path, string OutputFolder, string SiteFolder)
        {

            string[] fileEntries = Directory.GetFiles(local_path);


            // Response.Write("input folder is " + ParentDir);
            string[] subdirectoryEntries = Directory.GetDirectories(local_path);


            DirectoryInfo dInfo = new DirectoryInfo(local_path);


            // writes in log
            if (writelog == true)
            {
                // 2023 log path


                // work  swlog = File.CreateText(local_path + "generate.log");  // if generate subdir is not called it will fail ;
                // Sep 2023
                //Sep 2023 work swlog = File.CreateText( Common.Local_Log_Path +  "generate.log") ;  // Sep 2023 try sending full path outsite of input


                // 2023 May swlog = File.CreateText(Common.Local_Log_Path +   "generate.log");  // if generate subdir is not called it will fail ;
                swlogopen = true;
            }

            kreatelog("Generate Started " + local_path + " ," + OutputFolder + "," + SiteFolder);

            InitailizeSite(local_path);
            foreach (DirectoryInfo di in dInfo.GetDirectories())
            {

                ProcessFolder(di, local_path, OutputFolder, SiteFolder);
            }
            foreach (FileInfo fi in dInfo.GetFiles())
            {
                //Do something with the file here
                //or create a method like:
                ProcessFile(fi);
            }


            swlog.Close();

        }
        public static void Generatesubdirs(string local_path, string OutputFolder, string SiteFolder, bool logflag, string filename)
        {

            writelog = logflag;
            string[] fileEntries = Directory.GetFiles(local_path);


            // Response.Write("input folder is " + ParentDir);
            string[] subdirectoryEntries = Directory.GetDirectories(local_path);


            DirectoryInfo dInfo = new DirectoryInfo(local_path);



            // writes in log
            if (writelog == true)
            {
                // swlog = File.CreateText(local_path + "generate.log");
                // 2023 May log path change
                // work swlog = File.CreateText(local_path + filename);
                swlog = File.CreateText(Common.Local_Log_Path + filename); // May did not work, Sep2023 try again
                swlogopen = true;
            }

            /* May 22 2023 */
            // swsitemap = File.CreateText(local_path + "sitemap.txt");

            swsiteopen = true;

            kreatelog("Generate Started " + local_path + " ," + OutputFolder + "," + SiteFolder);

            InitailizeSite(local_path);

            foreach (DirectoryInfo di in dInfo.GetDirectories())
            {

                ProcessFolder(di, local_path, OutputFolder, SiteFolder);
            }
            foreach (FileInfo fi in dInfo.GetFiles())
            {
                //Do something with the file here
                //or create a method like:
                ProcessFile(fi);
            }

            swlog.Close();

            /* 2023 May 22 */
            swsitemap.Close();

        }


        public static void Generatesubdirs(string local_path, string OutputFolder, string SiteFolder, bool logflag, string filename, string filename2)
        {

            writelog = logflag;
            string[] fileEntries = Directory.GetFiles(local_path);


            // Response.Write("input folder is " + ParentDir);
            string[] subdirectoryEntries = Directory.GetDirectories(local_path);


            DirectoryInfo dInfo = new DirectoryInfo(local_path);



            // writes in log
            if (writelog == true)
            {
                // swlog = File.CreateText(local_path + "generate.log");


                /* 2023 May uncomment work */
                // swlog = File.CreateText(local_path + filename);
                // swlog2 = File.CreateText(local_path + filename2);

                /*   */
                // 2023 May test, Sep2023 

                // swlog = File.CreateText(local_path + "generate.log");
                //May2023, Sep 2023
                swlog = File.CreateText(Common.Local_Log_Path +  filename);
                swlog2 = File.CreateText(Common.Local_Log_Path +  filename2);
              

                /* 2023 May sitename*/
                // error  swsitemap = File.CreateText(local_path + "sitemap.txt");
                swlogopen = true;
            }

            /* 2023 May sitename*/
            swsitemap = File.CreateText(local_path + "sitemap.txt");
            swsiteopen = true;

            kreatelog("Generate Started " + local_path + " ," + OutputFolder + "," + SiteFolder);
            kreatelog2("Generate Started in log 2" + local_path + " ," + OutputFolder + "," + SiteFolder);
            InitailizeSite(local_path);

           // Directories in C:\e\a2_generated_sites\ + url + @"\input\"

            foreach (DirectoryInfo di in dInfo.GetDirectories())
            {

                ProcessFolder(di, local_path, OutputFolder, SiteFolder);
                kreatelog("Process folder " + di +  local_path + " ," + OutputFolder + "," + SiteFolder);

            }
            foreach (FileInfo fi in dInfo.GetFiles())
            {
                //Do something with the file here
                //or create a method like:
                ProcessFile(fi);
            }

            swlog.Close();
            swlog2.Close();

            /* 2023  May 22 */
            swsitemap.Close();


        }





        public static void InitailizeSite(string sitepath)
        {
            kreatelog("Initializesite " + sitepath);
            if (File.Exists(sitepath + @"\site.siteurl"))
            {
                string str = System.IO.File.ReadAllText(sitepath + @"\site.siteurl");

                Common.Siteurl = str.TrimEnd('\r', '\n');  // This will remove any combination of carriage returns and newlines from 
            }
            /* 2023 */
            if (File.Exists(sitepath + @"\email.address"))
            {
                string str = System.IO.File.ReadAllText(sitepath + @"\email.address");

                Common.EmailAddress = str.TrimEnd('\r', '\n');  // This will remove any combination of carriage returns and newlines from 
            }

            if (File.Exists(sitepath + @"\pictures.siteurl"))
            {
                string str = System.IO.File.ReadAllText(sitepath + @"\pictures.siteurl");

                Common.ImagePath = str.TrimEnd('\r', '\n');  // This will remove any combination of carriage returns and newlines from 
            }

            if (File.Exists(sitepath + @"\gallery_thumbnails.path"))
            {
                string str = System.IO.File.ReadAllText(sitepath + @"\gallery_thumbnails.path");

                Common.Gallery.thumbnailpath = str.TrimEnd('\r', '\n');  // This will remove any combination of carriage returns and newlines from 
            }
            if (File.Exists(sitepath + @"\pictures_thumbnails.path"))
            {
                string str = System.IO.File.ReadAllText(sitepath + @"\pictures_thumbnails.path");

                Common.Pictures.thumbnailpath = str.TrimEnd('\r', '\n');  // This will remove any combination of carriage returns and newlines from 
                kreatelog("thumbnail path = " + Common.Pictures.thumbnailpath);

            }
            if (File.Exists(sitepath + @"\slides_thumbnails.path"))
            {
                string str = System.IO.File.ReadAllText(sitepath + @"\slides_thumbnails.path");

                Common.Slides.thumbnailpath = str.TrimEnd('\r', '\n');  // This will remove any combination of carriage returns and newlines from 

            }
            if (File.Exists(sitepath + @"\pictures.page"))
            {
                string str = System.IO.File.ReadAllText(sitepath + @"\pictures.page");

                Common.Pictures.pages = str.TrimEnd('\r', '\n');  // This will remove any combination of carriage returns and newlines from 

            }
            if (File.Exists(sitepath + @"\picture.page"))
            {
                string str = System.IO.File.ReadAllText(sitepath + @"\picture.page");

                Common.Pictures.page = str.TrimEnd('\r', '\n');  // This will remove any combination of carriage returns and newlines from 

            }
            if (File.Exists(sitepath + @"\gallery.page"))
            {
                string str = System.IO.File.ReadAllText(sitepath + @"\gallery.page");

                Common.Gallery.pages = str.TrimEnd('\r', '\n');  // This will remove any combination of carriage returns and newlines from 

            }
            if (File.Exists(sitepath + @"\images.page"))
            {
                string str = System.IO.File.ReadAllText(sitepath + @"\images.page");

                Common.Images.pages = str.TrimEnd('\r', '\n');  // This will remove any combination of carriage returns and newlines from 
                Common.Pictures.Articlelist = Common.Images.pages;

                 // Above two are redunded only 1 is needed

            }
            if (File.Exists(sitepath + @"\article.page"))
            {
                string str = System.IO.File.ReadAllText(sitepath + @"\article.page");

                Common.Articles.page = str.TrimEnd('\r', '\n');  // This will remove any combination of carriage returns and newlines from 
                kreatelog("Article url is = " + Common.Articles.page);

            }
            if (File.Exists(sitepath + @"\ad.ID"))
            {
                string str = System.IO.File.ReadAllText(sitepath + @"\ad.ID");
                kreatelog("ADID = " + str);
                string adID = str.TrimEnd('\r', '\n');
                Common.adID = Convert.ToInt32(adID);
                kreatelog("Common AdID = " + Common.adID.ToString());

            }

            if (File.Exists(sitepath + @"\gallery.path"))
            {
                string str = System.IO.File.ReadAllText(sitepath + @"\gallery.path");
                kreatelog("gallery path = " + str);
                string galleryPath = str.TrimEnd('\r', '\n');
                Common.Gallery.defaultpath = galleryPath;
               // Common.ImagePath = galleryPath;   // use it where theme is stored
               // Common.adID = Convert.ToInt32(adID);
               // kreatelog("Common AdID = " + Common.adID.ToString());

            }

            /* 2023 Check delete, only log needed */
            if (File.Exists(sitepath + @"\site.siteurl"))
            {
                string str = System.IO.File.ReadAllText(sitepath + @"\site.siteurl");

                Common.Siteurl = str.TrimEnd('\r', '\n');  // This will remove any combination of carriage returns and newlines from 
                kreatelog("siteurl is = " + Common.Siteurl);

            }

            //Dec 24 Set computerpath
          //  computerpath = 

        }
        public static void ProcessFolder(DirectoryInfo di, string local_path, string OutputFolder, string SiteFolder)
        {
            //  Response.Write("dir is " +  di.Name.ToString());

            string InputUrl, OutputUrl;
            string subfolder = di.Name.ToString();
            string localfolder = local_path;

            GetImagePath(localfolder + subfolder);  // setting the image path

            //  OutputFolder = OutputFolder + subfolder + @"\"; // this does not work, pass sub folder to pass article so that it can create sidelink

            //   LocalPath.ComputerPath = OutputFolder + subfolder;  // so that article control can read it
            //   LocalPath.SitePath = LocalPath.SitePath + "subfolder";

         //   LocalPath2.ComputerPath = OutputFolder + subfolder;  // Dec 24 2015  , now pass it back as localpath.computerpath to generate.  Can't pass it back
            if (File.Exists(local_path + subfolder + @"\pictures.list"))
            {
                InputUrl = SiteFolder + Common.Pictures.pages + @"?local_path=" + localfolder + "&subfolder=" + subfolder + "&pic_path=" + pic_path + "&navigate_path=" + navigate_path + "&output_path=" + OutputFolder + subfolder + @"\";
                //  InputUrl = SiteFolder + "photos-dir.aspx?local_path=" + localfolder + "&subfolder=" + subfolder + "&pic_path=" + pic_path + "&navigate_path=" + navigate_path + "&output_path=" + OutputFolder + subfolder + @"\";

                string picturesurl = Common.Pictures.url;
                if (File.Exists(local_path + subfolder + @"\pictures.picturesurl"))
                {

                    picturesurl = System.IO.File.ReadAllText(local_path + subfolder + @"\pictures.picturesurl");  // if a folder does not need to use global class file name, it can be overridden here.
                    picturesurl = picturesurl.Trim();
                    kreatelog(" found pictures.picturesurl " + picturesurl);

                }

                OutputUrl = OutputFolder + subfolder + @"\" + picturesurl + ".html";


                //   Response.Write("url = " + InputUrl + "<br/> " + OutputUrl);
                GenerateHTML(InputUrl, OutputUrl); // Write gallery page
            }
            if (File.Exists(local_path + subfolder + @"\articles.articleslist"))
            {
                
                InputUrl = SiteFolder + Common.Articles.pages + @"?local_path=" + localfolder + "&subfolder=" + subfolder + "&pic_path=" + pic_path + "&navigate_path=" + navigate_path + "&output_path=" + OutputFolder + subfolder + @"\";
                //  InputUrl = SiteFolder + "photos-dir.aspx?local_path=" + localfolder + "&subfolder=" + subfolder + "&pic_path=" + pic_path + "&navigate_path=" + navigate_path + "&output_path=" + OutputFolder + subfolder + @"\";

                string articlesurl = Common.Articles.url;
                if (File.Exists(local_path + subfolder + @"\articles.articleurl"))
                {

                    articlesurl = System.IO.File.ReadAllText(local_path + subfolder + @"\articles.articleurl");  // if a folder does not need to use global class file name, it can be overridden here.
                    articlesurl = articlesurl.Trim();
                    kreatelog(" found articless.articleurl " + articlesurl);
                    kreatelog(" inputurl " + InputUrl);

                }

                OutputUrl = OutputFolder + subfolder + @"\" + articlesurl + ".html";
                kreatelog(" Outputurl for articles " + OutputUrl);

                 // Response.Write("url = " + InputUrl + "<br/> " + OutputUrl);
                GenerateHTML(InputUrl, OutputUrl); // Write gallery page
            }
            if (File.Exists(local_path + subfolder + @"\gallery.list"))
            {
                //InputUrl = SiteFolder + "gallery.aspx?local_path=" + localfolder + "&subfolder=" + subfolder + "&pic_path=" + pic_path + "&navigate_path=" + navigate_path + "&output_path=" + OutputFolder + subfolder + @"\";
                InputUrl = SiteFolder + Common.Gallery.pages + @"?local_path=" + localfolder + "&subfolder=" + subfolder + "&pic_path=" + pic_path + "&navigate_path=" + navigate_path + "&output_path=" + OutputFolder + subfolder + @"\";
                string galleryurl = Common.Gallery.url;

                if (File.Exists(local_path + subfolder + @"\gallery.galleryurl"))
                {
                    galleryurl = System.IO.File.ReadAllText(local_path + subfolder + @"\gallery.galleryurl");  // if a folder does not need to use global class file name, it can be overridden here.
                    galleryurl = galleryurl.Trim();

                }

                // OutputUrl = OutputFolder + subfolder + @"\" + "gallery" + ".html";
                OutputUrl = OutputFolder + subfolder + @"\" + galleryurl + ".html";

                //   Response.Write("url = " + InputUrl + "<br/> " + OutputUrl);
                GenerateHTML(InputUrl, OutputUrl); // Write gallery page
            }

            if (File.Exists(local_path + subfolder + @"\slides.list"))  // if slides.list does not exist, system will not generate slides.html
            {
                InputUrl = SiteFolder + "slides.aspx?local_path=" + localfolder + "&subfolder=" + subfolder + "&pic_path=" + pic_path + "&navigate_path=" + navigate_path + "&output_path=" + OutputFolder + subfolder + @"\";

                string slideurl = Common.Slides.url; // use slides name from global class
                if (File.Exists(local_path + subfolder + @"\slides.slidesurl"))
                {
                    slideurl = System.IO.File.ReadAllText(local_path + subfolder + @"\slides.slidesurl");  // if a folder does not need to use global class file name, it can be overridden here.
                    slideurl = slideurl.Trim();
                }
                //  OutputUrl = OutputFolder + subfolder + @"\" + "slides" + ".html";
                OutputUrl = OutputFolder + subfolder + @"\" + slideurl + ".html";

                //    Response.Write("slide url = " + InputUrl + "<br/> " + OutputUrl);
                GenerateHTML(InputUrl, OutputUrl); // Write gallery page
            }

            bool pictures_individualpage = Common.Pictures.individualpage;
            if (File.Exists(local_path + subfolder + @"\pictures.individualpage"))
            {
                string individualpage = System.IO.File.ReadAllText(local_path + subfolder + @"\pictures.individualpage");
                individualpage.Trim();

                if (individualpage[0] == '1')
                    pictures_individualpage = true;
                else
                    pictures_individualpage = false;
                // pictures_individualpage = individualpage.Equals("1", StringComparison.Ordinal);
                Generate.kreatelog("pictures individual page = " + pictures_individualpage.ToString());


            }
            if (pictures_individualpage == true)
            {
                Generate.kreatelog("in geneate phot dir scan = " );

               GeneratePhotos_dirscan(local_path, OutputFolder, subfolder, SiteFolder, pictures_individualpage); // Write sub pages.  each page show 1 photo
               
            }





            bool slides_individualpage = Common.Slides.individualpage;
            if (File.Exists(local_path + subfolder + @"\slides.individualpage"))
            {
                string individualpage = System.IO.File.ReadAllText(local_path + subfolder + @"\slides.individualpage");
                individualpage.Trim();

                if (individualpage[0] == '1')
                    slides_individualpage = true;
                else
                    slides_individualpage = false;

                // not working - slides_individualpage = individualpage.Equals("1", StringComparison.Ordinal);
                //    Response.Write("in slide generation:" + individualpage + ":" + subfolder + "<br/> ");


            }

            if (slides_individualpage == true)
            {
                // Response.Write("in slide generation 2" + subfolder + "<br/>");
                GenerateSlides_dirscan(local_path, OutputFolder, subfolder, SiteFolder); // Write sub pages.  each page show 1 photo

            }
            else
            {
                // Response.Write("NO slide generation " + subfolder + "<br/>");
            }



            if (Common.Gallery.individualpage == true)
            {
                GenerateGallery_dirscan(local_path, OutputFolder, subfolder, SiteFolder); // Write sub pages.  each page show 1 photo
            }


            InputUrl = SiteFolder + Common.Sitemap.foldernamepage + "?local_path=" + localfolder + "&subfolder=" + subfolder + "&pic_path=" + pic_path + "&navigate_path=" + navigate_path + "&output_path=" + OutputFolder + subfolder + @"\";
            OutputUrl = OutputFolder + subfolder + @"\" + Common.Sitemap.foldernameOutputpage;
            //    InputUrl = SiteFolder + "folder-names-generate.aspx?local_path=" + localfolder + "&subfolder=" + subfolder + "&pic_path=" + pic_path + "&navigate_path=" + navigate_path + "&output_path=" + OutputFolder + subfolder + @"\";

            //    OutputUrl = OutputFolder + subfolder + @"\" + "foldermap" + ".htm";


            GenerateHTML(InputUrl, OutputUrl); // Write gallery page


            //  InputUrl = SiteFolder + "folder-link-generate.aspx?local_path=" + localfolder + "&subfolder=" + subfolder + "&pic_path=" + pic_path + "&navigate_path=" + navigate_path + "&output_path=" + OutputFolder + subfolder + @"\";

            //   OutputUrl = OutputFolder + subfolder + @"\" + "linkmap" + ".htm";

            InputUrl = SiteFolder + Common.Sitemap.folderlinkpage + "?local_path=" + localfolder + "&subfolder=" + subfolder + "&pic_path=" + pic_path + "&navigate_path=" + navigate_path + "&output_path=" + OutputFolder + subfolder + @"\";
            OutputUrl = OutputFolder + subfolder + @"\" + Common.Sitemap.folderlinkOutputpage;
            //   OutputUrl = OutputFolder + subfolder + @"\" + "linkmap" + ".htm";

            GenerateHTML(InputUrl, OutputUrl); // Write gallery page




            GenerateArticle(local_path, OutputFolder, subfolder, SiteFolder); // Write sub pages.  each page show 1 photo


            local_path = local_path + subfolder + "\\";  // for recurssion.  Not tested
            OutputFolder = OutputFolder + subfolder + "\\"; // not tested
            string[] subdirectoryEntries = Directory.GetDirectories(localfolder);


            DirectoryInfo dInfo = new DirectoryInfo(local_path);


            foreach (DirectoryInfo subdi in dInfo.GetDirectories())
            {

                if (subdi.Name.ToString() != "thumbnails")
                {
                    // local_path = local_path  + subfolder + "\\"  ;
                    // OutputFolder =  OutputFolder + subfolder + "\\" ;
                    ProcessFolder(subdi, local_path, OutputFolder, SiteFolder);


                }
            }



        }




        public static void ProcessFile(FileInfo fi)
        {

            //    Response.Write("file is " + fi.Name.ToString() );
        }
        /* orignal
                public static void GenerateHTML(string inputurl, string outputurl)
                {

                    kreatelog("input output " + inputurl + "," + outputurl);
                    try
                    {

                        if ((!File.Exists(outputurl)) || (overwrite))
                        {
                  


                            WebRequest req = WebRequest.Create(inputurl);
                            WebResponse res = req.GetResponse();
                            StreamReader sr = new StreamReader(res.GetResponseStream());
                            string html = sr.ReadToEnd();

                            writefile(html, outputurl);
                        }
                    }
                    catch (Exception e)
                    {
             

                    }


                }
        */

        public static void GenerateHTML(string inputurl, string outputurl)
        {

            kreatelog("input output " + inputurl + "," + outputurl);
            /* 2023 May 22, earlier sitemap error creation */ 
            kreatesitemap(outputurl);
            try
            {

                if ((!File.Exists(outputurl)) || (overwrite))
                {



                    WebRequest req = WebRequest.Create(inputurl);
                    WebResponse res = req.GetResponse();
                    StreamReader sr = new StreamReader(res.GetResponseStream());
                    string html = sr.ReadToEnd();

                    /* Below block is temporary kreate.blob  */
                    /*  Oct 2017 
                    html = html.Replace(@"http://pictures.kreatewebsites.com/India", @"http://album.kreatewebsites.com/India"); // Added on Sep 13 2016
                    html = html.Replace(@"http://pictures.kreatewebsites.com/Festival", Common.ImagePath+ "Festival"); // Added on Sep 13 2016
                    html = html.Replace(Common.Local_Image_Path + @"India", @"http://album.kreatewebsites.com/India"); // Added on Sep 13 2016
                    html = html.Replace(Common.Local_Image_Path + @"india", @"http://album.kreatewebsites.com/India"); // Added on Sep 13 2016
                    html = html.Replace(@"http://pictures.kreatewebsites.com/site", Common.CSSPath); // Added on Sep 13 2016
                    html = html.Replace(@"http://pictures.kreatewebsites.com/imagegallery.php", @"http://photoviewer.kreatewebsites.com/"); // Added on Sep 13 2016
                    html = html.Replace(@"http://pictures.kreatewebsites.com/", Common.BlobPath); // Added on Sep 13 2016
                    html = html.Replace(Common.Local_Image_Path, Common.BlobPath); // Added on Sep 13 2016.  change slash.  C:\e\a1_sites\pictures.1000\India\andhra-pradesh   
                    html = html.Replace(Common.Local_Image_Path.ToLower(), Common.BlobPath); // Added on Sep 13 2016.  change slash.  C:\e\a1_sites\pictures.1000\India\andhra-pradesh
                    */
                    /* above Block is temporary */

                    /* enabled  again 2022 */
                    html = html.Replace(Common.Local_Image_Path, Common.BlobPath);   
                    html = html.Replace(Common.Local_Image_Path.ToLower(), Common.BlobPath); 
                    
                    /*  enabled */
                    html = html.Replace(@"\", @"/");  //  India\Delhi to India/Delhi

                    if (Common.SiteurlOrg != null)
                    {

                        html = html.Replace(Common.SiteurlOrg, Common.Siteurl);
                    }
                    /* 2023 May email */
                    /*
                    if (Common.EmailAddressOrg != null)
                    {

                        html = html.Replace(Common.EmailAddressOrg, Common.EmailAddress);
                    }
                    */

                    if (Common.ImageurlOrg != null)
                    {

                        html = html.Replace(Common.ImageurlOrg, Common.ImagePath);

                     

                        //  kreatelog("full html = " + html);
                    }
                    /* 2023 */
                    /*
                    if (Common.EmailAddress != null)
                    {

                        html = html.Replace(Common.EmailAddressOrg, Common.EmailAddress);

                    }
                    */
                    //    Common.Local_Image_Path = @"C:\e\a1_sites\pictures.1000\";

                    html = html.Replace(Common.Local_Image_Path, Common.ImagePath);   // Replace c:\e\ path
                    html = html.Replace(Common.Local_Image_Path.ToLower(), Common.ImagePath);
                   // html = html.Replace(@"C:\e\a1_sites\pictures.1000\", Common.ImagePath);
                    string sitename = Common.Siteurl;
                    sitename = sitename.Replace( @"http://", "");
                    /* May 2023 email  */
                    sitename = sitename.Replace(@"https://", "");
                    sitename = sitename.Replace( @"www.", "");
                    
                    string email = @"info@" + sitename;
                    html = html.Replace("http://www.kreatewebsites.com/", Common.Siteurl);
                    
                    html = html.Replace("http://pictures.kreatewebsites.com/", Common.ImagePath); // Added on Sep 17

                    /* 2023 */
                    html = html.Replace("https://www.kreatewebsites.com/", Common.Siteurl);
                    html = html.Replace("https://pictures.kreatewebsites.com/", Common.ImagePath); 

                    /* 2023 May email */
                    // html = html.Replace(@"info@kreatewebsites.com", email);
                    html = html.Replace(@"info@kreatewebsites.com",Common.EmailAddress);
                    writefile(html, outputurl);
                }
            }
            catch (Exception e)
            {
                // Response.Write("Exception" +  e.Message);

            }


        }
        public static void writefile(string html, string localpath)
        {
            // string localpath ;
            // localpath = "f:\\" + siteurl + "\\" + path7 + "\\" + param + ".html";
            //   localpath = "f:\\test\\" + param + ".html";
            //  StreamWriter _testData = new StreamWriter("f:\\" + siteurl + "\\" + path7 + "\\" + param) ;
            //   StreamWriter _testData = new StreamWriter("f:\\test\\data3.html", true);

            //      Response.Write("<br/> Directory created : " + localpath);
            Directory.CreateDirectory(Path.GetDirectoryName(localpath));

            //     StreamWriter _testData = new StreamWriter(localpath, true);  // to append to existing file
            StreamWriter _testData = new StreamWriter(localpath, false);  // to overwrite existing file
            _testData.WriteLine(html); // Write the file.
            _testData.Close(); // Close the instance of StreamWriter.
            _testData.Dispose(); // Dispose from memory.       

            //    Response.Write("<br/> File created : " + localpath   );

        }

        public static void GetImagePath(string inputdir)
        {



            // Default value of pictures path is t\aken from Common. The value can be overriden by providing a value in file pictures.path 
            PicturePath = Common.Pictures.defaultpath;
            if (File.Exists(inputdir + @"\pictures.path"))
            {
                string str = System.IO.File.ReadAllText(inputdir + @"\pictures.path");

                PicturePath = str.TrimEnd('\r', '\n');  // This will remove any combination of carriage returns and newlines from 

            }
        }




        public static void GetSlidePath(string inputdir)
        {



            // Default value of pictures path is taken from Common. The value can be overriden by providing a value in file pictures.path 
            SlidePath = Common.Slides.defaultpath;
            //  Response.Write("slide path 1 = " + SlidePath + " <br/>");
            if (File.Exists(inputdir + @"\slides.path"))
            {
                string str = System.IO.File.ReadAllText(inputdir + @"\slides.path");

                SlidePath = str.TrimEnd('\r', '\n');  // This will remove any combination of carriage returns and newlines from 


            }
        }
        public static void GetGalleryPath(string inputdir)
        {



            // Default value of pictures path is taken from Common. The value can be overriden by providing a value in file pictures.path 
            GalleryPath = Common.Gallery.defaultpath;
            kreatelog("Gallerypath for " + inputdir + " is" + GalleryPath);
            //  Response.Write("slide path 1 = " + SlidePath + " <br/>");
            if (File.Exists(inputdir + @"\gallery.path"))
            {
                string str = System.IO.File.ReadAllText(inputdir + @"\gallery.path");

                GalleryPath = str.TrimEnd('\r', '\n');  // This will remove any combination of carriage returns and newlines from 


            }
        }
        public static void GeneratePhotos_dirscan(string inputdir, string outputdir, string picsubfolder, string SiteFolder, bool individualpage)
        {


            string InputUrl, OutputUrl;
            string imageurl;
            string imagename;
            string extension;
            string imagefullurl;
            string text = null, displayname = null;
            string imagepath, original_imagename;
            // test to remove double slash     string picdir = outputdir + "\\" + picsubfolder;
          //  string picdir = outputdir + picsubfolder + @"/";
            string picdir = outputdir + picsubfolder ;  // removed additional slash  on Oct 11 2015
            //   LocalPath.ComputerPath = picdir;  // so that article control can read it
            //    LocalPath.SitePath = LocalPath.SitePath + @"/" + picsubfolder;

            try
            {
                string[] fileEntries = Directory.GetFiles(picdir);
                int i = 0;

                imagepath = inputdir + @"\" + picsubfolder;
                GetImagePath(inputdir + @"\" + picsubfolder);   // public function.  use pictures.path file if given, otherwise use Global path

                // individualpage is added on Sep 29 2015 as picture image page was not generated
                if ((Common.Pictures.includepictures == true) || (individualpage == true))
                if (Common.Pictures.includepictures == true) 
                {

                    foreach (string path in fileEntries)
                    {





                        if (File.Exists(path))
                        {
                            // This path is a file

                            imageurl = System.IO.Path.GetFileName(path);
                            imagename = System.IO.Path.GetFileNameWithoutExtension(path);
                            original_imagename = imagename;


                            /*
                            if (pictures_individualpage == true)
                                navigateurl = name + ".html";  
                            else
                                navigateurl = imagefullurl;

                            */
                            imagefullurl = PicturePath + Common.Pictures.sizepath + imageurl;
                            extension = System.IO.Path.GetExtension(path);

                            if ((extension.ToLower() == ".jpg") || (extension.ToLower() == ".jpeg") || (extension.ToLower() == ".png"))
                            {


                                // GetPictureAttributes(string inputdir, string name, ref string text, ref string picname)
                                Generate.kreatelog("get picture attribute : " + inputdir + " '" + imageurl);
                             // Sep 17   Photos.GetPictureAttributes(inputdir + @"\" + picsubfolder, imagename, ref text, ref imagename);
                                Photos.GetPictureAttributes(inputdir + @"\" + picsubfolder, imagename, imageurl, ref text, ref imagename);

                                OutputUrl = outputdir + picsubfolder + "/" + imagename + ".html";

                                InputUrl = SiteFolder + Common.Pictures.page + @"?imageurl=" + imagefullurl + "&name=" + imagename + "&output_path=" + picdir + @"\" + "&output_url=" + OutputUrl + "&localurl=" + imagepath + @"/" + original_imagename + "&url=" + imagepath + @"/" + imagename;  //output path for article  control to generate links
                                //                       InputUrl = SiteFolder + "photo.aspx?imageurl=" + imagefullurl + "&name=" + imagename + "&output_path=" + picdir + @"\" + "&output_url=" + OutputUrl;  //output path for article  control to generate links

                                i++;




                                GenerateHTML(InputUrl, OutputUrl);


                            }

                        }
                        else
                        {
                            Console.WriteLine("No rows found.");
                        }




                    }  // for
                }   // if include pictures == true



                //  This read pictures.list. You can specify picture filename in this file.
                if (File.Exists(inputdir + @"\" + picsubfolder + @"\pictures.list"))
                {


                    System.IO.StreamReader file =
                       new System.IO.StreamReader(inputdir + @"\" + picsubfolder + @"\pictures.list");
                    while ((imageurl = file.ReadLine()) != null)
                    {
                        //name = url; // remove .jpg


                        imagename = imageurl.Replace(".jpg", "");
                        imagename = imagename.Replace(".jpeg", "");
                        imagename = imagename.Replace(".png", "");
                        imagename = imagename.Replace(".JPG", "");
                        imagename = imagename.Replace(".JPEG", "");
                        imagename = imagename.Replace(".PNG", "");
                        /* works for 3 character extension
                                            imagename = imageurl.Remove(imageurl.Length - 4, 4); */

                        original_imagename = imagename;
                        // Dec 2020
                        Generate.kreatelog("urls before merge = " + PicturePath + "," + Common.Pictures.sizepath + " , " + imageurl);
                        string imagedirpath = PicturePath + Common.Pictures.sizepath;
                        if (imagedirpath.EndsWith("/"))
                        {
                            imagefullurl = PicturePath + Common.Pictures.sizepath + imageurl;
                        }
                        else
                        {
                            imagefullurl = PicturePath + Common.Pictures.sizepath + @"/" + imageurl;
                        }
                        Generate.kreatelog("urls after merge = " +  imagefullurl);

                        // GetPictureAttributes(string inputdir, string name, ref string text, ref string picname)
                        Generate.kreatelog("get picture attribute : " + inputdir + @"\" + picsubfolder + " '" + imageurl);
                    //Sep 17    Photos.GetPictureAttributes(inputdir + @"\" + picsubfolder, imagename, ref text, ref imagename);
                        Photos.GetPictureAttributes(inputdir + @"\" + picsubfolder, imagename,imageurl, ref text, ref imagename);

                        Generate.kreatelog("get imagename : " + imagename);
                        OutputUrl = outputdir + picsubfolder + "/" + imagename + ".html";
                        InputUrl = SiteFolder + Common.Pictures.page + @"?imageurl=" + imagefullurl + "&name=" + imagename + "&output_path=" + picdir + @"\" + "&output_url=" + OutputUrl + "&localurl=" + imagepath + @"/" + original_imagename + "&url=" + imagepath + @"/" + imagename; // url is passed so that photo.aspx can read comments.  image1.comments will give comments on origina imagename,  image2.comments will give comments on name specified in image.name
                        //       InputUrl = SiteFolder + "photo.aspx?imageurl=" + imagefullurl + "&name=" + imagename + "&output_path=" + picdir + @"\" + "&output_url=" + OutputUrl;


                        Generate.kreatelog("generate HTML : " +InputUrl + OutputUrl);

                        GenerateHTML(InputUrl, OutputUrl);

                    }

                    file.Close();


                }

            }
            catch (Exception e)
            {
                // Response.Write("Exception is : " + e.Message);
            }


        }

        public static void GenerateSlides_dirscan(string inputdir, string outputdir, string picsubfolder, string SiteFolder)
        {


            string InputUrl, OutputUrl;
            string imageurl;
            string imagename;
            string extension;
            string imagefullurl;
            string text = null, displayname = null;
            string imagepath, original_imagename;


            // string picdir = outputdir + "\\" + picsubfolder;
            string picdir = inputdir + "\\" + picsubfolder;  // if there is bug chnage it to input

            Generate.kreatelog(" In GenerateSlides_dirscan <br/>");

            try
            {
                string[] fileEntries = Directory.GetFiles(picdir);
                int i = 0;


                imagepath = inputdir + @"\" + picsubfolder; //Oct2
                GetSlidePath(inputdir + @"\" + picsubfolder);   // public function.  use pictures.path file if given, otherwise use Global path
                if (Common.Slides.includepictures == true)
                {
                    foreach (string path in fileEntries)
                    {



                        //   Response.Write("<br/>In path  = " + path);

                        if (File.Exists(path))
                        {
                            // This path is a file

                            imageurl = System.IO.Path.GetFileName(path);
                            imagename = System.IO.Path.GetFileNameWithoutExtension(path);
                            original_imagename = imagename; //Oct2



                            imagefullurl = SlidePath + Common.Slides.sizepath + imageurl;
                            extension = System.IO.Path.GetExtension(path);

                            if ((extension.ToLower() == ".jpg") || (extension.ToLower() == ".jpeg") || (extension.ToLower() == ".png"))
                            {
                                



                                OutputUrl = outputdir + picsubfolder + "/" + imagename + ".html";
                                InputUrl = SiteFolder + "slide.aspx?imageurl=" + imagefullurl + "&name=" + imagename + "&output_path=" + outputdir + @"/" + "&output_url=" + OutputUrl;  //output path for article  control to generate links

                                i++;

                                //      Response.Write("Inputurl slide = " + InputUrl + "<br/>");






                                GenerateHTML(InputUrl, OutputUrl);


                            }

                        }
                        else
                        {
                            Console.WriteLine("No rows found.");
                        }




                    }  // for

                } // includepictures == true


                //  This read pictures.list. You can specify picture filename in this file.
                // Use backslash as this is for computer and not for web server
                if (File.Exists(inputdir + @"\" + picsubfolder + @"\slides.list"))
                {


                    System.IO.StreamReader file =
                       new System.IO.StreamReader(inputdir + @"\" + picsubfolder + @"\slides.list");
                    while ((imageurl = file.ReadLine()) != null)
                    {
                        //name = url; // remove .jpg


                        imagename = imageurl.Replace(".jpg", "");
                        imagename = imagename.Replace(".jpeg", "");
                        imagename = imagename.Replace(".png", "");
                        imagename = imagename.Replace(".JPG", "");
                        imagename = imagename.Replace(".JPEG", "");
                        imagename = imagename.Replace(".PNG", "");
                        /* works for 3 character extension
                                            imagename = imageurl.Remove(imageurl.Length - 4, 4); */

                        original_imagename = imagename;
                        imagefullurl = SlidePath + Common.Slides.sizepath + imageurl;

                      
                        Photos.GetPictureAttributes(inputdir + @"\" + picsubfolder, imagename, imageurl, ref text, ref imagename); //Oct2

                        OutputUrl = outputdir + picsubfolder + "/" + imagename + ".html";
                        InputUrl = SiteFolder + "slide.aspx?imageurl=" + imagefullurl + "&name=" + imagename + "&output_path=" + picdir + @"\" + "&local_path=" + inputdir + @"\" + "&subfolder=" + picsubfolder + "&output_url=" + OutputUrl;

                        GenerateHTML(InputUrl, OutputUrl);

                    }

                    file.Close();


                }

            }
            catch (Exception e)
            {
                //    Response.Write("Exception is : " + e.Message);
            }


        }

        public static void GenerateGallery_dirscan(string inputdir, string outputdir, string picsubfolder, string SiteFolder)
        {


            string InputUrl, OutputUrl;
            string imageurl;
            string imagename;
            string extension;
            string imagefullurl;

            // string picdir = outputdir + "\\" + picsubfolder;
            string picdir = inputdir + "\\" + picsubfolder;  // if there is bug chnage it to input


            //  Response.Write("<br/>In Gen Photo  = " + inputdir + " " + picsubfolder);
            try
            {
                string[] fileEntries = Directory.GetFiles(picdir);
                int i = 0;

                GetGalleryPath(inputdir + @"\" + picsubfolder);   // public function.  use pictures.path file if given, otherwise use Global path

                if (Common.Gallery.includepictures == true)
                {
                    foreach (string path in fileEntries)
                    {



                        //   Response.Write("<br/>In path  = " + path);

                        if (File.Exists(path))
                        {
                            // This path is a file

                            imageurl = System.IO.Path.GetFileName(path);
                            imagename = System.IO.Path.GetFileNameWithoutExtension(path);




                            imagefullurl = GalleryPath + Common.Gallery.sizepath + imageurl;
                            extension = System.IO.Path.GetExtension(path);

                            if ((extension.ToLower() == ".jpg") || (extension.ToLower() == ".jpeg") || (extension.ToLower() == ".png"))
                            {





                                InputUrl = SiteFolder + "Image.aspx?imageurl=" + imagefullurl + "&name=" + imagename + "&output_path=" + outputdir + @"\";  //output path for article  control to generate links
                                OutputUrl = outputdir + picsubfolder + "/" + imagename + ".html";
                                i++;

                                //       Response.Write("Inputurl Image = " + InputUrl + "<br/>");






                                GenerateHTML(InputUrl, OutputUrl);


                            }

                        }
                        else
                        {
                            Console.WriteLine("No rows found.");
                        }




                    }  // for

                }  // include pictures == true
                //      Response.Write("input dir = " + inputdir + @"\" + picsubfolder + @"\pictures.list");

                //  This read pictures.list. You can specify picture filename in this file.
                if (File.Exists(inputdir + @"\" + picsubfolder + @"\gallery.list"))
                {


                    System.IO.StreamReader file =
                       new System.IO.StreamReader(inputdir + @"\" + picsubfolder + @"\gallery.list");
                    while ((imageurl = file.ReadLine()) != null)
                    {
                        //name = url; // remove .jpg


                        imagename = imageurl.Replace(".jpg", "");
                        imagename = imagename.Replace(".jpeg", "");
                        imagename = imagename.Replace(".png", "");
                        imagename = imagename.Replace(".JPG", "");
                        imagename = imagename.Replace(".JPEG", "");
                        imagename = imagename.Replace(".PNG", "");
                        /* works for 3 character extension
                                            imagename = imageurl.Remove(imageurl.Length - 4, 4); */

                        // Make this is function to determine full path of thumbnail
                        imagefullurl = GalleryPath + Common.Gallery.sizepath + imageurl;
                        kreatelog("gallery path in generate gallery is " + GalleryPath);


                        //      InputUrl = SiteFolder + "photo.aspx?imageurl=" + imagefullurl + "&name=" + imagename + "&output_path=" + picdir + @"\";

                        //    OutputUrl = outputdir + picsubfolder + "/" + imagename + ".html";


                        InputUrl = SiteFolder + "image.aspx?imageurl=" + imagefullurl + "&name=" + imagename + "&output_path=" + picdir + @"\";

                        OutputUrl = outputdir + picsubfolder + "/" + imagename + ".html";
                        //            Response.Write("slide = " + InputUrl);

                        GenerateHTML(InputUrl, OutputUrl);

                    }

                    file.Close();


                }

            }
            catch (Exception e)
            {
                //    Response.Write("Exception is : " + e.Message);
            }


        }
        public static void GenerateArticle(string inputdir, string outputdir, string subfolder, string SiteFolder)
        {


            string InputUrl, OutputUrl;

            //  string localfolder = local_path;

            string dir = inputdir + subfolder;
            string OutputFolder = outputdir + subfolder + @"\"; // to pass article so that it can create sidelink


            kreatelog(" Generate Article 1 : " + inputdir + outputdir + subfolder + SiteFolder);

            try
            {
                string[] fileEntries = Directory.GetFiles(dir);
                int i = 0;

                kreatelog(" Generate Article 2 : " + inputdir + "," + outputdir + "," + subfolder + "," + SiteFolder);
                kreatelog(" Generate Article 2a : " + dir);
                kreatelog(" Generate Article 2aa : " + fileEntries[0].ToString());
                foreach (string path in fileEntries)
                {


                    string url;
                    string name;
                    string extension;
                    string fullurl;
                    string articleurl;

                    kreatelog(" Generate Article 2b : " + path);
                    if (File.Exists(path))
                    {
                        // This path is a file
                        kreatelog(" Generate Article 2c : " + "in if");

                        url = System.IO.Path.GetFileName(path);

                        kreatelog(" Generate Article 2d : " + url);

                        name = System.IO.Path.GetFileNameWithoutExtension(path);

                        kreatelog(" Generate Article 2e : " + name);

                        fullurl = inputdir + subfolder + "\\" + url;

                        kreatelog(" Generate Article 2f : " + url);

                        extension = System.IO.Path.GetExtension(path);

                        kreatelog(" Generate Article 2g : " + extension);

                        //   Response.Write("<br/> Path = " + path);
                        kreatelog(" Generate Article 3 : " + path);
                        if ((extension.ToLower() == ".txt") || (extension.ToLower() == ".htm") || (extension.ToLower() == ".article"))
                        {

                            kreatelog(" Generate Article 3a : " + extension);
                            InputUrl = SiteFolder + Common.Articles.page + @"?url=" + path + "&name=" + name + "&output_path=" + OutputFolder;

                            articleurl = name;
                            //   Response.Write("<br/> Generate Article : " + inputdir + subfolder + name);
                            kreatelog(" Generate Article 5 : " + inputdir + subfolder + @"\" + name + @".articleurl");
                            if (File.Exists(inputdir + subfolder + @"\" + name + @".articleurl"))
                            {
                                kreatelog(" Generate Article 6 : " + inputdir + subfolder + @"\" + name + @".articleurl");
                                articleurl = System.IO.File.ReadAllText(inputdir + subfolder + @"\" + name + @".articleurl");  // if a folder does not need to use global class file name, it can be overridden here.
                                articleurl = articleurl.Trim();
                                kreatelog(" Generate Article 7 : " + articleurl);
                            }

                            /* below should be done 1 for each folder.  Optimize */
                            /*
                         else
                         {
                               
                             if (File.Exists(inputdir + subfolder + @"\gen.articleurl"))
                             {
                                 string gen_article;
                                 gen_article = System.IO.File.ReadAllText(inputdir + subfolder + @"\gen.articleurl");

                                 if (string.Compare(gen_article, "1") == 0)
                                 {
                                     string filename = inputdir + subfolder + @"\" + name + @".articleurl";
                                     // File.Create(filename);

                                     using (StreamWriter sw = File.CreateText(filename))
                                     {
                                         sw.WriteLine(articleurl);

                                     }
                                 }
                             }

                        
                      
                                
                         }
                         */
                            // check if gen.title is there. then generate title   
                            /* Nov 15
                            Generate.ConfigFileCheckAndGenerate(inputdir + subfolder + @"\", @"gen.articleurl", @".articleurl", 1, name );
                            Generate.ConfigFileCheckAndGenerate(inputdir + subfolder + @"\", @"gen.title", @".title", 1, name);
                            Generate.ConfigFileCheckAndGenerate(inputdir + subfolder + @"\", @"gen.articleslist", @".articleslist", 1, name);
                             * */
                            /* 15 apr 2024 */
                            kreatelog(" Generate Article ABC : " + name);
                            name = GetNameFromUrl(name);
                            kreatelog(" Generate Article XYZ : " + name);
                            /* 15 Nov 2024  - it was failing when htps full path is given in .list .imagelist and with gen.title, gen.name */


                            Generate.ConfigFileCheckAndGenerate(inputdir + subfolder + @"\", @"gen.articleurl", @".articleurl", 1, name, Common.genArticleurl);
                            Generate.ConfigFileCheckAndGenerate(inputdir + subfolder + @"\", @"gen.title", @".title", 1, name, Common.genTitle);
                            Generate.ConfigFileCheckAndGenerate(inputdir + subfolder + @"\", @"gen.articleslist", @".articleslist", 1, name);

                            /* 2023 */
                            Generate.ConfigFileCheckAndGenerate(inputdir + subfolder + @"\", @"gen.desc", @".desc", 1, name, Common.genDesc);
                            Generate.ConfigFileCheckAndGenerate(inputdir + subfolder + @"\", @"gen.keywords", @".keywords", 1, name, Common.genKeywords);
                            // DEc 28 try, not needed    Generate.ConfigFileCheckAndGenerate(inputdir + subfolder + @"\", @"gen.articleslist", @".articleslist", 1, name, Common.genArticleslist); 
                            // OutputUrl = outputdir + subfolder + "/" + name + ".html";
                            OutputUrl = outputdir + subfolder + @"/" + articleurl + ".html";

                            i++;

                            //   Response.Write("<br/>");
                            //  Response.Write(OutputUrl);

                            //            Response.Write("<br/> InputUrl : " + InputUrl + " AND " + OutputUrl);
                            GenerateHTML(InputUrl, OutputUrl);


                        }
                        // This is new code to genere from list of files
                        if ((extension.ToLower() == ".articlelist"))
                        {

                            kreatelog(" Generate Articlelist : " + extension);
                            InputUrl = SiteFolder + Common.Articles.Articlelist + @"?url=" + path + "&name=" + name + "&output_path=" + OutputFolder;

                            articleurl = name;
                            //   Response.Write("<br/> Generate Article : " + inputdir + subfolder + name);
                            kreatelog(" Generate Articlelist : " + inputdir + subfolder + @"\" + name + @".articleurl");
                            kreatelog(" Generate Articlelist Inputurl: " + InputUrl);
                            if (File.Exists(inputdir + subfolder + @"\" + name + @".articleurl"))
                            {
                                kreatelog(" Generate Article 6 : " + inputdir + subfolder + @"\" + name + @".articleurl");
                                articleurl = System.IO.File.ReadAllText(inputdir + subfolder + @"\" + name + @".articleurl");  // if a folder does not need to use global class file name, it can be overridden here.
                                articleurl = articleurl.Trim();
                                kreatelog(" Generate Article 7 : " + articleurl);
                            }
                            /*Nov 15
                            Generate.ConfigFileCheckAndGenerate(inputdir + subfolder + @"\", @"gen.articleurl", @".articleurl", 1, name);
                            Generate.ConfigFileCheckAndGenerate(inputdir + subfolder + @"\", @"gen.title", @".title", 1, name);
                            Generate.ConfigFileCheckAndGenerate(inputdir + subfolder + @"\", @"gen.comments", @".comments", 0, name);
                             * */

                            Generate.ConfigFileCheckAndGenerate(inputdir + subfolder + @"\", @"gen.articleurl", @".articleurl", 1, name, Common.genArticleurl);
                            Generate.ConfigFileCheckAndGenerate(inputdir + subfolder + @"\", @"gen.title", @".title", 1, name, Common.genTitle);
                            Generate.ConfigFileCheckAndGenerate(inputdir + subfolder + @"\", @"gen.comments", @".comments", 0, name);

                            /* 2023 */
                            Generate.ConfigFileCheckAndGenerate(inputdir + subfolder + @"\", @"gen.desc", @".desc", 1, name, Common.genDesc);
                            Generate.ConfigFileCheckAndGenerate(inputdir + subfolder + @"\", @"gen.keywords", @".keywords", 0, name, Common.genKeywords);

                            OutputUrl = outputdir + subfolder + @"/" + articleurl + ".html";

                            i++;

                           
                            GenerateHTML(InputUrl, OutputUrl);
                        }
                        if ((extension.ToLower() == ".imagelist"))
                        {

                            kreatelog2(" Generate imagelist : " + extension);
                            InputUrl = SiteFolder + Common.Pictures.Articlelist + @"?url=" + path + "&name=" + name + "&output_path=" + OutputFolder + "&local_path=" + inputdir +  "&subfolder=" + subfolder;
                            kreatelog2("Inputurl = " + InputUrl);
                            articleurl = name;
                            //   Response.Write("<br/> Generate Article : " + inputdir + subfolder + name);
                            kreatelog(" Generate imagelist : " + inputdir + subfolder + @"\" + name + @".articleurl");
                            if (File.Exists(inputdir + subfolder + @"\" + name + @".articleurl"))
                            {
                                kreatelog(" Generate imagelist 6 : " + inputdir + subfolder + @"\" + name + @".articleurl");
                                articleurl = System.IO.File.ReadAllText(inputdir + subfolder + @"\" + name + @".articleurl");  // if a folder does not need to use global class file name, it can be overridden here.
                                articleurl = articleurl.Trim();
                                kreatelog(" Generate imagelist 7 : " + articleurl);
                            }
                            /* Nov 15
                            Generate.ConfigFileCheckAndGenerate(inputdir + subfolder + @"\", @"gen.articleurl", @".articleurl", 1, name);
                            Generate.ConfigFileCheckAndGenerate(inputdir + subfolder + @"\", @"gen.title", @".title", 1, name);
                            Generate.ConfigFileCheckAndGenerate(inputdir + subfolder + @"\", @"gen.comments", @".comments", 0, name);
                             * */

                            Generate.ConfigFileCheckAndGenerate(inputdir + subfolder + @"\", @"gen.articleurl", @".articleurl", 1, name, Common.genArticleurl);
                            Generate.ConfigFileCheckAndGenerate(inputdir + subfolder + @"\", @"gen.title", @".title", 1, name, Common.genName);
                            Generate.ConfigFileCheckAndGenerate(inputdir + subfolder + @"\", @"gen.comments", @".comments", 0, name);


                            /* 2023 */
                            Generate.ConfigFileCheckAndGenerate(inputdir + subfolder + @"\", @"gen.desc", @".desc", 1, name, Common.genDesc);
                            Generate.ConfigFileCheckAndGenerate(inputdir + subfolder + @"\", @"gen.keywords", @".keywords", 0, name, Common.genKeywords );

                            OutputUrl = outputdir + subfolder + @"/" + articleurl + ".html";

                            i++;


                            GenerateHTML(InputUrl, OutputUrl);
                        }

                    }
                    else
                    {
                        Console.WriteLine("No rows found.");
                    }




                }  // for

                // 15 Apr 2024
                kreatelog(" Generate Article for loop finish : " );

            }
            catch (Exception e)
            {
                //        Response.Write("Exception is : " + e.Message);
            }


        }
        /* 2024 call
         *  Generate.ConfigFileCheckAndGenerate(inputdir + subfolder + @"\", @"gen.title", @".title", 0, name); // 0 to write blank
         * */
        public static void ConfigFileCheckAndGenerate(string dir, string gen_config_file, string ext, int action, string name)
        {
            // BUG  : double slash everywhere
            // config_file example = gen.title
            if (File.Exists(dir + @"\" + name + ext))
            {
                ; // do nothing if file already exist
            }
            else
            {
                Generate.filegenerate(dir + @"\", gen_config_file, ext, 1, name);
                kreatelog("in config check + " + dir + @"\" + gen_config_file + ext +  name);
            }
        }
        public static void ConfigFileCheckAndGenerate(string dir, string gen_config_file, string ext, int action, string name, int genFlag)
        {
            // config_file example = gen.title
            if (File.Exists(dir + @"\" + name + ext))
            {
                ; // do nothing if file already exist
            }
            else
            {
                Generate.filegenerate(dir + @"\", gen_config_file, ext, 1, name, genFlag);  //Nov 15 function
                kreatelog("in new config check + " + dir + @"\" + " configl file " + gen_config_file + ext + name + " flag " + genFlag);
            }
        }

        // this function is not tested
        public static void filegenerate(string dir, string fname, string ext, int action, string name)
        {
            // example dir\gen.name 
            if (File.Exists(dir + fname))
            {
                string gen;
                gen = System.IO.File.ReadAllText(dir + fname);

                kreatelog("gen name text  " + gen);
                gen = gen.TrimEnd('\r', '\n');

                // if content of file is 1
                if (string.Compare(gen, "1") == 0)
                {
                    //15 Apr 2024
                    name = GetNameFromUrl(name);

                    string filename = dir + name + ext;
                    // File.Create(filename);
                    kreatelog("gen name filename  " + filename);
                    using (StreamWriter sw = File.CreateText(filename))
                    {

                        switch (action)
                        {
                            case 0:
                                sw.WriteLine(" ");
                                break;
                            case 1:
                                sw.WriteLine(name);
                                break;
                            case 2:
                                name = name.Replace(' ', '-');
                                sw.WriteLine(name);
                                break;
                            case 21:
                                name = name.Replace('-', ' ');
                                sw.WriteLine(name);
                                break;
                            case 3:
                                name = name.Replace(' ', '_');
                                sw.WriteLine(name);
                                break;

                            case 31:
                                name = name.Replace('_', ' ');
                                sw.WriteLine(name);
                                break;
                            case 4:
                                name = name.Replace('_', '-');
                                sw.WriteLine(name);
                                break;
                            case 42:
                                name = name.Replace('-', '_');
                                sw.WriteLine(name);
                                break;
                            case 51:
                                sw.WriteLine(name + @"/");
                                break;
                            case 52:
                                sw.WriteLine(name + @".html");
                                break;
                            default:
                                sw.WriteLine(name);
                                break;





                        }
                        sw.Close();

                    }
                }
            }
        }



        public static void filegenerate(string dir, string fname, string ext, int action, string name, int genFlag)
        {
           
            int newgenFlag = genFlag ;
            if (genFlag == 0)
            {
               if (File.Exists(dir + fname) )
                {
                  string gen;
                  gen = System.IO.File.ReadAllText(dir + fname);

                  kreatelog("in new gen name text  " + gen);
                   gen = gen.TrimEnd('\r', '\n');

                // if content of file is 1
                   if (string.Compare(gen, "1") == 0)
                  {
                   
                    // File.Create(filename);
                    kreatelog("1 found  " );
                    newgenFlag = 1 ;

                  }
               } //file exist

            } // genFlag

               if (newgenFlag == 1)
                {
                    //15 Apr 2024
                    name = GetNameFromUrl(name);

                    string filename = dir + name + ext;
                    kreatelog("new gen name filename  " + filename);
                    using (StreamWriter sw = File.CreateText(filename))
                    {

                        switch (action)
                        {
                            case 0:
                                sw.WriteLine(" ");
                                break;
                            case 1:
                                sw.WriteLine(name);
                                break;
                            case 2:
                                name = name.Replace(' ', '-');
                                sw.WriteLine(name);
                                break;
                            case 21:
                                name = name.Replace('-', ' ');
                                sw.WriteLine(name);
                                break;
                            case 3:
                                name = name.Replace(' ', '_');
                                sw.WriteLine(name);
                                break;

                            case 31:
                                name = name.Replace('_', ' ');
                                sw.WriteLine(name);
                                break;
                            case 4:
                                name = name.Replace('_', '-');
                                sw.WriteLine(name);
                                break;
                            case 42:
                                name = name.Replace('-', '_');
                                sw.WriteLine(name);
                                break;
                            case 51:
                                sw.WriteLine(name + @"/");
                                break;
                            case 52:
                                sw.WriteLine(name + @".html");
                                break;
                            default:
                                sw.WriteLine(name);
                                break;





                        }
                        sw.Close();

                } //using


                } //if
          
        }
     
        public static void filegenerateImage(string dir, string fname, string ext, int action, string name, string picname, string picalt, string url)
        {
            // this function is not tested yet - Sep 15 2015
            kreatelog("gen image text called " + dir + fname);
            string imagefullpath = @"http://pictures.kreatewebsites.com/photos100/" + url;

            string imageline = @"<img src=" + '"' + imagefullpath + '"' + @"/>";

            if (File.Exists(dir + fname))
            {
                string gen;
                gen = System.IO.File.ReadAllText(dir + fname);

                kreatelog("gen image text  " + gen);
                gen = gen.TrimEnd('\r', '\n');

                // if content of file is 1
                if (string.Compare(gen, "1") == 0)
                {
                    string filename = dir + name + ext;
                    // File.Create(filename);
                    kreatelog("gen name filename last " + filename);

                    if (File.Exists(filename))
                    {
                        ; // do nothing if file already exist
                    }
                    else
                    {
                        using (StreamWriter sw = File.CreateText(filename))
                        {
                            kreatelog("gen image variables dir = " + dir + ",fname=" + fname + ",name=" + name + ",picname=" + picname + ", url" + url);



                            switch (action)
                            {
                                case 0:
                                    sw.WriteLine(" ");
                                    break;
                                case 1:
                                    imagefullpath = @"http://pictures.kreatewebsites.com/photos100/" + url;

                                    imageline = @"<img src=" + '"' + imagefullpath + '"' + @"/>";
                                    sw.WriteLine(imageline);
                                    break;

                                case 2:
                                    imagefullpath = @"http://pictures.kreatewebsites.com/photos200/" + url;

                                    imageline = @"<img src=" + '"' + imagefullpath + '"' + @"/>";
                                    sw.WriteLine(imageline);
                                    break;
                                case 3:
                                    imagefullpath = @"http://pictures.kreatewebsites.com/photos300/" + url;

                                    imageline = @"<img src=" + '"' + imagefullpath + '"' + @"/>";
                                    sw.WriteLine(imageline);
                                    break;
                                case 4:
                                    imagefullpath = @"http://pictures.kreatewebsites.com/photos400/" + url;

                                    imageline = @"<img src=" + '"' + imagefullpath + '"' + @"/>";
                                    sw.WriteLine(imageline);
                                    break;
                                case 5:
                                    imagefullpath = @"http://pictures.kreatewebsites.com/photos500/" + url;

                                    imageline = @"<img src=" + '"' + imagefullpath + '"' + @"/>";
                                    sw.WriteLine(imageline);
                                    break;

                                case 6:
                                    imagefullpath = @"http://pictures.kreatewebsites.com/photos600/" + url;

                                    imageline = @"<img src=" + '"' + imagefullpath + '"' + @"/>";
                                    sw.WriteLine(imageline);
                                    break;
                                case 7:
                                    imagefullpath = @"http://pictures.kreatewebsites.com/photos700/" + url;

                                    imageline = @"<img src=" + '"' + imagefullpath + '"' + @"/>";
                                    sw.WriteLine(imageline);
                                    break;
                                case 8:
                                    imagefullpath = @"http://pictures.kreatewebsites.com/photos800/" + url;

                                    imageline = @"<img src=" + '"' + imagefullpath + '"' + @"/>";
                                    sw.WriteLine(imageline);
                                    break;
                                default:
                                    sw.WriteLine(name);
                                    break;





                            }
                            sw.Close();

                        }
                    }
                }
            }
        }

        public static void GenerateContinent(string InputFolder, string OutputFolder)
        {
            string InputUrl, OutputUrl;
            // string InputFolder = SiteFolder;

            try
            {

                // string sp = "regions_search";
                string sp = "continent_search";


                string connect = ConfigurationManager.ConnectionStrings["filmslocal"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(connect))
                {

                    using (SqlCommand cmd = new SqlCommand(sp, conn))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Continent", "all");
                        cmd.Parameters.AddWithValue("@geo", "all");
                        cmd.Parameters.AddWithValue("@Country", "all");

                        cmd.Parameters.AddWithValue("@n", 30);
                        cmd.Parameters.AddWithValue("@SortOrder", 3);

                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();



                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                outputpath = OutputFolder + @"content/" + reader["continent"].ToString() + @"\";
                                InputUrl = InputFolder + "best.aspx?continent=" + reader["continent"].ToString() + "&output_path=" + outputpath; // output path is used for article generation;
                                OutputUrl = outputpath + "best.html";
                                //     OutputUrl = OutputFolder + reader["country"].ToString() + "\\" + "cities-in-" + reader["Region"].ToString() + ".html";

                                //   InputUrl = InputFolder + reader.["statename"].tostring();
                                //     Console.WriteLine("{0}\t{1}", reader.GetInt32(0), reader.GetString(1));
                                GenerateHTML(InputUrl, OutputUrl);




                            }
                        }
                        else
                        {
                            Console.WriteLine("No rows found.");
                        }
                        conn.Close();
                    }

                }



            }
            catch (Exception ex)
            {
                //     Response.Write("Exception : " + ex.Message.ToString());

            }

        }

        public static void GenerateCountries(string InputFolder, string OutputFolder)
        {
            string InputUrl, OutputUrl;

            try
            {

                // string sp = "regions_search";
                string sp = "countries_search";


                string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(connect))
                {

                    using (SqlCommand cmd = new SqlCommand(sp, conn))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Continent", "all");
                        cmd.Parameters.AddWithValue("@geo", "all");
                        cmd.Parameters.AddWithValue("@Country", "all");

                        cmd.Parameters.AddWithValue("@n", 100);
                        cmd.Parameters.AddWithValue("@SortOrder", 2);

                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();



                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {

                                //   InputUrl = InputFolder + reader.["statename"].tostring();
                                //     Console.WriteLine("{0}\t{1}", reader.GetInt32(0), reader.GetString(1));


                                outputpath = OutputFolder + @"content\" + @"\" + reader["country"].ToString() + @"\";
                                //   InputUrl = InputFolder + "default.aspx?continent=" + reader["continent"].ToString() + "&country=" + reader["country"].ToString() ;
                                InputUrl = InputFolder + "best.aspx?country=" + reader["country"].ToString() + "&output_path=" + outputpath; // output path is used for article generation;
                                OutputUrl = OutputFolder + @"content\" + @"\" + reader["country"].ToString() + @"\best.html";




                                GenerateHTML(InputUrl, OutputUrl);


                                outputpath = OutputFolder + @"content\" + @"\" + reader["country"].ToString() + @"\";
                                InputUrl = InputFolder + "capital.aspx?country=" + reader["country"].ToString() + "&output_path=" + outputpath; // output path is used for article generation;
                                OutputUrl = OutputFolder + @"content\" + @"\" + reader["country"].ToString() + @"\capital.html";




                                GenerateHTML(InputUrl, OutputUrl);


                            }
                        }
                        else
                        {
                            Console.WriteLine("No rows found.");
                        }
                        conn.Close();
                    }

                }



            }
            catch (Exception ex)
            {
                //   Response.Write("Exception : " + ex.Message.ToString());

            }

        }
        public static void GenerateStates(string InputFolder, string OutputFolder)
        {

            string InputUrl, OutputUrl;
            try
            {

                // string sp = "regions_search";
                string sp = "regions_v2";


                string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(connect))
                {

                    using (SqlCommand cmd = new SqlCommand(sp, conn))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Country", Common.Country.ToString());

                        cmd.Parameters.AddWithValue("@n", 100);
                        cmd.Parameters.AddWithValue("@SortOrder", 3);

                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();



                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                outputpath = OutputFolder + reader["continent"].ToString() + "\\" + reader["country"].ToString() + "\\" + reader["Region"].ToString() + @"\";
                                InputUrl = InputFolder + "default.aspx?continent=" + reader["continent"].ToString() + "&country=" + reader["country"].ToString() + "&statename=" + reader["Region"].ToString() + "&output_path=" + outputpath; // output path is used for article generation;
                                OutputUrl = outputpath + "index.html";
                                GenerateHTML(InputUrl, OutputUrl);



                                //     OutputUrl = OutputFolder + reader["country"].ToString() + "\\" + "cities-in-" + reader["Region"].ToString() + ".html";

                                //   InputUrl = InputFolder + reader.["statename"].tostring();
                                //     Console.WriteLine("{0}\t{1}", reader.GetInt32(0), reader.GetString(1));

                            }
                        }
                        else
                        {
                            Console.WriteLine("No rows found.");
                        }
                        conn.Close();
                    }

                }



            }
            catch (Exception ex)
            {
                //   Response.Write("Exception : " + ex.Message.ToString());

            }

        }
        public static void GenerateCities(string InputFolder, string OutputFolder)
        {
            string InputUrl, OutputUrl;
            try
            {
                string sp = "cities_search";


                string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;


                using (SqlConnection conn = new SqlConnection(connect))
                {

                    using (SqlCommand cmd = new SqlCommand(sp, conn))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Country", Common.Country.ToString());
                        cmd.Parameters.AddWithValue("@Region", "all");
                        cmd.Parameters.AddWithValue("@n", 5000);
                        cmd.Parameters.AddWithValue("@SortOrder", 3);

                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();



                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                outputpath = OutputFolder + reader["region"].ToString() + "\\" + reader["city"].ToString() + @"\";
                                InputUrl = InputFolder + "?city=" + reader["city"].ToString() + "&output_path=" + outputpath; // output path is used for article generation;
                                OutputUrl = outputpath + @"index.html";
                                // Console.WriteLine("{0}\t{1}", reader.GetInt32(0), reader.GetString(1));

                                GenerateHTML(InputUrl, OutputUrl);

                                outputpath = OutputFolder + reader["region"].ToString() + "\\" + reader["city"].ToString() + @"\";
                                InputUrl = InputFolder + "about.aspx?city=" + reader["city"].ToString() + "&output_path=" + outputpath; // output path is used for article generation;
                                OutputUrl = outputpath + @"about.html";
                                GenerateHTML(InputUrl, OutputUrl);

                                outputpath = OutputFolder + reader["region"].ToString() + "\\" + reader["city"].ToString() + @"\";
                                InputUrl = InputFolder + "list.aspx?city=" + reader["city"].ToString() + "&output_path=" + outputpath; // output path is used for article generation;
                                OutputUrl = outputpath + @"attractions.html";
                                GenerateHTML(InputUrl, OutputUrl);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No rows found.");
                        }

                        conn.Close();
                    }

                }

            }
            catch (Exception ex)
            {
                //  Response.Write("Exception : " + ex.Message.ToString());

            }



        }

        public static void GeneratePlaces(string InputFolder, string OutputFolder)
        {
            string InputUrl, OutputUrl;
            try
            {
                string sp = "best_tourist_places_search";


                string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;


                using (SqlConnection conn = new SqlConnection(connect))
                {

                    using (SqlCommand cmd = new SqlCommand(sp, conn))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Country", Common.Country.ToString());

                        cmd.Parameters.AddWithValue("@State", "all");
                        cmd.Parameters.AddWithValue("@city", "all");
                        cmd.Parameters.AddWithValue("@Category", "all");
                        cmd.Parameters.AddWithValue("@SubCategory", "all");
                        cmd.Parameters.AddWithValue("@n", 2000);
                        cmd.Parameters.AddWithValue("@SortOrder", 1);



                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();



                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                outputpath = OutputFolder + reader["region"].ToString() + "\\" + reader["city"].ToString() + @"\";
                                InputUrl = InputFolder + "?name=" + reader["biz_name"].ToString() + "&output_path=" + outputpath; // output path is used for article generation;
                                OutputUrl = outputpath + reader["biz_name"].ToString() + ".html";
                                // Console.WriteLine("{0}\t{1}", reader.GetInt32(0), reader.GetString(1));

                                GenerateHTML(InputUrl, OutputUrl);



                            }
                        }
                        else
                        {
                            Console.WriteLine("No rows found.");
                        }

                        conn.Close();
                    }

                }

            }
            catch (Exception ex)
            {
                //     Response.Write("Exception : " + ex.Message.ToString());

            }



        }


        public static void GenerateContinent(string InputFolder, string OutputFolder, string inputpage, string pageurl, int spin)
        {

            string InputUrl, OutputUrl;

            try
            {

                // string sp = "regions_search";
                string sp = "continent_search";


                string connect = ConfigurationManager.ConnectionStrings["filmslocal"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(connect))
                {

                    using (SqlCommand cmd = new SqlCommand(sp, conn))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Continent", "all");
                        cmd.Parameters.AddWithValue("@geo", "all");
                        cmd.Parameters.AddWithValue("@Country", "all");

                        cmd.Parameters.AddWithValue("@n", 30);
                        cmd.Parameters.AddWithValue("@SortOrder", 3);

                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();



                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                //   OutputUrl = OutputFolder + reader["continent"].ToString() + @"\" + pageurl;
                                outputpath = OutputFolder + reader["continent"].ToString() + @"\";
                                OutputUrl = outputpath + pageurl;
                                InputUrl = InputFolder + inputpage + "?continent=" + reader["continent"].ToString() + "&output_path=" + outputpath; // output path is used for article generation;

                                //     OutputUrl = OutputFolder + reader["country"].ToString() + "\\" + "cities-in-" + reader["Region"].ToString() + ".html";

                                //   InputUrl = InputFolder + reader.["statename"].tostring();
                                //     Console.WriteLine("{0}\t{1}", reader.GetInt32(0), reader.GetString(1));
                                GenerateHTML(InputUrl, OutputUrl);




                            }
                        }
                        else
                        {
                            Console.WriteLine("No rows found.");
                        }
                        conn.Close();
                    }

                }



            }
            catch (Exception ex)
            {
                //    Response.Write("Exception : " + ex.Message.ToString());

            }

        }
        public static void GenerateCountriestosee(string InputFolder, string OutputFolder, string inputpage, string pageurl, int spin)
        {

            string InputUrl, OutputUrl;

            try
            {

                // string sp = "regions_search";
                string sp = "continent_search";


                string connect = ConfigurationManager.ConnectionStrings["filmslocal"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(connect))
                {

                    using (SqlCommand cmd = new SqlCommand(sp, conn))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Continent", "all");
                        cmd.Parameters.AddWithValue("@geo", "all");
                        cmd.Parameters.AddWithValue("@Country", "all");

                        cmd.Parameters.AddWithValue("@n", 30);
                        cmd.Parameters.AddWithValue("@SortOrder", 3);

                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();



                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {


                                outputpath = OutputFolder + reader["continent"].ToString() + @"\";
                                InputUrl = InputFolder + inputpage + "?continent=" + reader["continent"].ToString() + "&output_path=" + outputpath; // output path is used for article generation;;
                                OutputUrl = outputpath + pageurl;

                                GenerateHTML(InputUrl, OutputUrl);

                            }
                        }
                        else
                        {
                            Console.WriteLine("No rows found.");
                        }
                        conn.Close();
                    }

                }



            }
            catch (Exception ex)
            {
                //     Response.Write("Exception : " + ex.Message.ToString());

            }

        }

        public static void GenerateCountries(string InputFolder, string OutputFolder, string inputpage, string pageurl, int spin)
        {
            string InputUrl, OutputUrl;
            //  InputFolder = SiteFolder;

            try
            {

                // string sp = "regions_search";
                string sp = "countries_search";


                string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(connect))
                {

                    using (SqlCommand cmd = new SqlCommand(sp, conn))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Continent", "all");
                        cmd.Parameters.AddWithValue("@geo", "all");
                        cmd.Parameters.AddWithValue("@Country", "all");

                        cmd.Parameters.AddWithValue("@n", 300);
                        cmd.Parameters.AddWithValue("@SortOrder", 2);

                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();



                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {

                                //   InputUrl = InputFolder + reader.["statename"].tostring();
                                //     Console.WriteLine("{0}\t{1}", reader.GetInt32(0), reader.GetString(1));



                                //   InputUrl = InputFolder + "default.aspx?continent=" + reader["continent"].ToString() + "&country=" + reader["country"].ToString() ;
                                outputpath = OutputFolder + @"\" + reader["country"].ToString().Trim() + @"\";
                                InputUrl = InputFolder + inputpage + "?country=" + reader["country"].ToString() + "&output_path=" + outputpath; // output path is used for article generation;;
                                OutputUrl = outputpath + pageurl;




                                GenerateHTML(InputUrl, OutputUrl);



                            }
                        }
                        else
                        {
                            Console.WriteLine("No rows found.");
                        }
                        conn.Close();
                    }

                }



            }
            catch (Exception ex)
            {
                //   Response.Write("Exception : " + ex.Message.ToString());

            }

        }

        public static void GenerateCountries(string InputFolder, string OutputFolder, string inputpage, string pageurl, int spin, string continent)
        {
            string InputUrl, OutputUrl;
            //  InputFolder = SiteFolder;

            try
            {

                // string sp = "regions_search";
                string sp = "countries_search_v6";


                string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(connect))
                {

                    using (SqlCommand cmd = new SqlCommand(sp, conn))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Continent", continent);
                        cmd.Parameters.AddWithValue("@geo", DBNull.Value);
                        cmd.Parameters.AddWithValue("@Country", DBNull.Value);

                        cmd.Parameters.AddWithValue("@n", 300);
                        cmd.Parameters.AddWithValue("@SortOrder", 2);

                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();



                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {

                                //   InputUrl = InputFolder + reader.["statename"].tostring();
                                //     Console.WriteLine("{0}\t{1}", reader.GetInt32(0), reader.GetString(1));



                                //   InputUrl = InputFolder + "default.aspx?continent=" + reader["continent"].ToString() + "&country=" + reader["country"].ToString() ;
                                outputpath = OutputFolder + @"\" + reader["country"].ToString().Trim() + @"\";
                                InputUrl = InputFolder + inputpage + "?country=" + reader["country"].ToString() + "&output_path=" + outputpath; // output path is used for article generation ;
                                OutputUrl = outputpath + pageurl;




                                GenerateHTML(InputUrl, OutputUrl);



                            }
                        }
                        else
                        {
                            Console.WriteLine("No rows found.");
                        }
                        conn.Close();
                    }

                }



            }
            catch (Exception ex)
            {
                //   Response.Write("Exception : " + ex.Message.ToString());

            }

        }

        public static void GenerateCapitalCity(string InputFolder, string OutputFolder, string inputpage, string pageurl, int spin)
        {
            //  InputFolder = SiteFolder;
            string InputUrl, OutputUrl;
            try
            {

                // string sp = "regions_search";
                string sp = "countries_search";


                string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(connect))
                {

                    using (SqlCommand cmd = new SqlCommand(sp, conn))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Continent", "all");
                        cmd.Parameters.AddWithValue("@geo", "all");
                        cmd.Parameters.AddWithValue("@Country", "all");

                        cmd.Parameters.AddWithValue("@n", 300);
                        cmd.Parameters.AddWithValue("@SortOrder", 2);

                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();



                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {





                                outputpath = OutputFolder + @"\" + reader["country"].ToString().Trim() + @"\";
                                InputUrl = InputFolder + inputpage + "?country=" + reader["country"].ToString().Trim() + @"&city=" + reader["capital"].ToString().Trim() + "&output_path=" + outputpath; // output path is used for article generation;
                                OutputUrl = outputpath + reader["capital"].ToString().Trim() + @".html";  // generate places to see in capital city.  generate city might over right in some cases.
                                GenerateHTML(InputUrl, OutputUrl);


                            }
                        }
                        else
                        {
                            Console.WriteLine("No rows found.");
                        }
                        conn.Close();
                    }

                }



            }
            catch (Exception ex)
            {
                //       Response.Write("Exception : " + ex.Message.ToString());

            }

        }

        public static void GenerateCapitalCity(string InputFolder, string OutputFolder, string inputpage, string pageurl, int spin, string continent, string country)
        {
            //  InputFolder = SiteFolder;
            string InputUrl, OutputUrl;
            try
            {

                // string sp = "regions_search";
                string sp = "countries_search_v6";


                string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(connect))
                {

                    using (SqlCommand cmd = new SqlCommand(sp, conn))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Continent", continent);
                        cmd.Parameters.AddWithValue("@geo", DBNull.Value);
                        cmd.Parameters.AddWithValue("@Country", country);

                        cmd.Parameters.AddWithValue("@n", 300);
                        cmd.Parameters.AddWithValue("@SortOrder", 2);

                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();



                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {





                                outputpath = OutputFolder + @"\" + reader["country"].ToString().Trim() + @"\";
                                InputUrl = InputFolder + inputpage + "?country=" + reader["country"].ToString().Trim() + @"&city=" + reader["capital"].ToString().Trim() + "&output_path=" + outputpath; // output path is used for article generation;
                                OutputUrl = outputpath + reader["capital"].ToString().Trim() + @".html";  // generate places to see in capital city.  generate city might over right in some cases.
                                GenerateHTML(InputUrl, OutputUrl);


                            }
                        }
                        else
                        {
                            Console.WriteLine("No rows found.");
                        }
                        conn.Close();
                    }

                }



            }
            catch (Exception ex)
            {
                //       Response.Write("Exception : " + ex.Message.ToString());

            }

        }

        public static void GenerateStates(string InputFolder, string OutputFolder, string inputpage, string pageurl, int spin)
        {

            string InputUrl, OutputUrl;

            try
            {

                // string sp = "regions_search";
                string sp = "regions_v6";


                string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(connect))
                {

                    using (SqlCommand cmd = new SqlCommand(sp, conn))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Country", null);

                        cmd.Parameters.AddWithValue("@n", 5000);
                        cmd.Parameters.AddWithValue("@SortOrder", 3);

                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();



                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                outputpath = OutputFolder + @"/" + reader["country"].ToString().Trim() + @"/" + reader["Region"].ToString().Trim() + @"/";
                                InputUrl = InputFolder + inputpage + @"?continent=" + reader["continent"].ToString() + "&country=" + reader["country"].ToString() + "&statename=" + reader["Region"].ToString() + "&output_path=" + outputpath; // output path is used for article generation;
                                OutputUrl = outputpath + pageurl;
                                GenerateHTML(InputUrl, OutputUrl);



                                //     OutputUrl = OutputFolder + reader["country"].ToString() + "\\" + "cities-in-" + reader["Region"].ToString() + ".html";

                                //   InputUrl = InputFolder + reader.["statename"].tostring();
                                //     Console.WriteLine("{0}\t{1}", reader.GetInt32(0), reader.GetString(1));

                            }
                        }
                        else
                        {
                            Console.WriteLine("No rows found.");
                        }
                        conn.Close();
                    }

                }



            }
            catch (Exception ex)
            {
                //   Response.Write("Exception : " + ex.Message.ToString());

            }

        }


        public static void GenerateStates(string InputFolder, string OutputFolder, string inputpage, string pageurl, string country, int urltype, int seperator_type, int spin)
        {

            string InputUrl, OutputUrl;
            string regionurl, continenturl, countryurl, stateurl;

            try
            {

                // string sp = "regions_search";
                string sp = "regions_v6";


                string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(connect))
                {

                    using (SqlCommand cmd = new SqlCommand(sp, conn))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Country", country);

                        cmd.Parameters.AddWithValue("@n", 5000);
                        cmd.Parameters.AddWithValue("@SortOrder", 3);

                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();



                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                InputUrl = InputFolder + inputpage + @"?continent=" + reader["continent"].ToString() + "&country=" + reader["country"].ToString() + "&statename=" + reader["Region"].ToString() + "&output_path=" + outputpath; // output path is used for article generation;
                                continenturl = reader["continent"].ToString();
                                countryurl = reader["country"].ToString();
                                stateurl = reader["Region"].ToString();
                                switch (seperator_type)
                                {
                                    case 1:
                                        break;
                                    case 2:
                                        KreateWebsites.Generate.ReplaceStr(ref countryurl, ' ', '-');
                                        KreateWebsites.Generate.ReplaceStr(ref stateurl, ' ', '-');
                                        KreateWebsites.Generate.ReplaceStr(ref continenturl, ' ', '-');
                                        break;
                                    case 3:
                                        KreateWebsites.Generate.ReplaceStr(ref countryurl, ' ', '_');
                                        KreateWebsites.Generate.ReplaceStr(ref stateurl, ' ', '_');
                                        KreateWebsites.Generate.ReplaceStr(ref continenturl, ' ', '_');
                                        break;

                                    default:
                                        break;
                                }

                                switch (urltype)
                                {
                                    case 1:
                                        outputpath = OutputFolder + @"/" + countryurl + @"/" + stateurl + @"/";
                                        OutputUrl = OutputFolder + @"/" + countryurl + @"/" + stateurl + @"/" + pageurl;
                                        break;

                                    case 2:
                                        outputpath = OutputFolder + @"/" + stateurl + @"/";
                                        OutputUrl = OutputFolder + @"/" + stateurl + @"/" + pageurl;
                                        break;

                                    case 3:
                                        outputpath = OutputFolder + @"/";
                                        OutputUrl = OutputFolder + @"/" + stateurl + @".html";
                                        break;

                                    default:
                                        outputpath = OutputFolder + @"/" + reader["country"].ToString().Trim() + @"/" + reader["Region"].ToString().Trim() + @"/";
                                        OutputUrl = OutputFolder + @"/" + reader["country"].ToString().Trim() + @"/" + reader["Region"].ToString().Trim() + @"/" + pageurl;
                                        break;

                                }

                                GenerateHTML(InputUrl, OutputUrl);



                                //     OutputUrl = OutputFolder + reader["country"].ToString() + "\\" + "cities-in-" + reader["Region"].ToString() + ".html";

                                //   InputUrl = InputFolder + reader.["statename"].tostring();
                                //     Console.WriteLine("{0}\t{1}", reader.GetInt32(0), reader.GetString(1));

                            }
                        }
                        else
                        {
                            Console.WriteLine("No rows found.");
                        }
                        conn.Close();
                    }

                }



            }
            catch (Exception ex)
            {
                //   Response.Write("Exception : " + ex.Message.ToString());

            }

        }
        public static void GenerateRegions(string InputFolder, string OutputFolder, string inputpage, string pageurl, int spin)
        {


            DataTable dt;
            string InputUrl, OutputUrl;


            //    KreateWebsites.Generate.overwrite = overwrite;

            InputUrl = InputFolder;
            //     OutputUrl = OutputFolder + pageurl + @".html";




            //    dt = KreateWebsites.Places.GetRegions(null, null, null, 500, 3, 100);


            dt = KreateWebsites.Places.GetRegionsfromPlaces(null, 500, 1);



            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string countryurl = dt.Rows[i]["country"].ToString().Trim();
                //     KreateWebsites.Generate.ReplaceStr(ref countryurl, ' ', '-');

                string stateurl = dt.Rows[i]["statename"].ToString().Trim();
                //      KreateWebsites.Generate.ReplaceStr(ref stateurl, ' ', '-');
                outputpath = OutputFolder + countryurl + @"/" + stateurl + @"/";
                InputUrl = InputFolder + inputpage + "?country=" + dt.Rows[i]["country"].ToString().Trim() + "&statename=" + dt.Rows[i]["statename"].ToString().Trim() + "&output_path=" + outputpath; // output path is used for article generation;


                OutputUrl = OutputFolder + countryurl + @"/" + stateurl + @"/" + pageurl;
                //  OutputUrl = OutputFolder + dt.Rows[i]["city"].ToString().Trim() + @"/" + dt.Rows[i]["subcategory"].ToString().Trim() + @"index.html";


                //      KreateWebsites.Generate.overwrite = overwrite;
                //   Response.Write("File = " + InputUrl + " " + OutputUrl + "<br/>");
                KreateWebsites.Generate.GenerateHTML(InputUrl, OutputUrl);







            }


        }

        public static void GenerateRegions(string InputFolder, string OutputFolder, string inputpage, string pageurl, int spin, string country)
        {


            DataTable dt;
            string InputUrl, OutputUrl;


            //    KreateWebsites.Generate.overwrite = overwrite;

            InputUrl = InputFolder;
            //     OutputUrl = OutputFolder + pageurl + @".html";




            //    dt = KreateWebsites.Places.GetRegions(null, null, null, 500, 3, 100);


            dt = KreateWebsites.Places.GetRegionsfromPlaces(country, 500, 1);



            for (int i = 0; i < dt.Rows.Count; i++)
            {

                string countryurl = dt.Rows[i]["country"].ToString().Trim();
                //     KreateWebsites.Generate.ReplaceStr(ref countryurl, ' ', '-');

                string stateurl = dt.Rows[i]["statename"].ToString().Trim();
                //      KreateWebsites.Generate.ReplaceStr(ref stateurl, ' ', '-');
                outputpath = OutputFolder + countryurl + @"/" + stateurl + @"/";
                InputUrl = InputFolder + inputpage + "?country=" + dt.Rows[i]["country"].ToString().Trim() + "&statename=" + dt.Rows[i]["statename"].ToString().Trim() + "&output_path=" + outputpath; // output path is used for article generation;


                OutputUrl = OutputFolder + countryurl + @"/" + stateurl + @"/" + pageurl;
                //  OutputUrl = OutputFolder + dt.Rows[i]["city"].ToString().Trim() + @"/" + dt.Rows[i]["subcategory"].ToString().Trim() + @"index.html";


                //      KreateWebsites.Generate.overwrite = overwrite;
                //   Response.Write("File = " + InputUrl + " " + OutputUrl + "<br/>");
                KreateWebsites.Generate.GenerateHTML(InputUrl, OutputUrl);







            }


        }

        public static void GenerateCities(string InputFolder, string OutputFolder, string inputpage, string pageurl, int spin)
        {


            DataTable dt;
            string InputUrl, OutputUrl;


            //    KreateWebsites.Generate.overwrite = overwrite;

            InputUrl = InputFolder;
            //     OutputUrl = OutputFolder + pageurl + @".html";



            dt = KreateWebsites.Places.GetCitiesfromPlaces(null, null, null, 5000, 1);






            for (int i = 0; i < dt.Rows.Count; i++)
            {

                string countryurl = dt.Rows[i]["country"].ToString().Trim();
                //       KreateWebsites.Generate.ReplaceStr(ref countryurl, ' ', '-');

                string stateurl = dt.Rows[i]["statename"].ToString().Trim();
                //      KreateWebsites.Generate.ReplaceStr(ref stateurl, ' ', '-');

                string cityurl = dt.Rows[i]["city"].ToString().Trim();
                //     KreateWebsites.Generate.ReplaceStr(ref cityurl, ' ', '-');
                outputpath = OutputFolder + countryurl + @"\" + stateurl + @"\" + cityurl + @"\";

                InputUrl = InputFolder + inputpage + "?country=" + dt.Rows[i]["country"].ToString().Trim() + "&statename=" + dt.Rows[i]["statename"].ToString().Trim() + "&city=" + dt.Rows[i]["city"].ToString().Trim() + "&output_path=" + outputpath; // output path is used for article generation;


                OutputUrl = OutputFolder + countryurl + @"\" + stateurl + @"\" + cityurl + @"\" + pageurl;
                //   Response.Write("File test = " + InputUrl + " " + OutputUrl + "<br/>");
                if ((countryurl.ToString().Length > 3) && (stateurl.Length > 3) && (cityurl.Length > 3))
                {
                    OutputUrl = OutputFolder + countryurl + @"\" + stateurl + @"\" + cityurl + @"\" + pageurl;
                    //  OutputUrl = OutputFolder + dt.Rows[i]["city"].ToString().Trim() + @"/" + dt.Rows[i]["subcategory"].ToString().Trim() + @"index.html";


                    //      KreateWebsites.Generate.overwrite = overwrite;
                    //      Response.Write("File created = " + InputUrl + " " + OutputUrl + "<br/>");
                    KreateWebsites.Generate.GenerateHTML(InputUrl, OutputUrl);

                    //   GenerateHTML(InputUrl, OutputUrl);

                }





            }


        }

        public static void GenerateCities(string InputFolder, string OutputFolder, string inputpage, string pageurl, int count, int spin)
        {


            DataTable dt;
            string InputUrl, OutputUrl;


            //    KreateWebsites.Generate.overwrite = overwrite;

            InputUrl = InputFolder;
            //     OutputUrl = OutputFolder + pageurl + @".html";



            dt = KreateWebsites.Places.GetCitiesfromPlaces(null, null, null, count, 1);


            kreatelog("getcitiesfromplaces=" + dt.Rows.Count.ToString());



            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string countryurl = dt.Rows[i]["country"].ToString().Trim();
                //       KreateWebsites.Generate.ReplaceStr(ref countryurl, ' ', '-');

                string stateurl = dt.Rows[i]["statename"].ToString().Trim();
                //      KreateWebsites.Generate.ReplaceStr(ref stateurl, ' ', '-');

                string cityurl = dt.Rows[i]["city"].ToString().Trim();
                //     KreateWebsites.Generate.ReplaceStr(ref cityurl, ' ', '-');
                outputpath = OutputFolder + countryurl + @"\" + stateurl + @"\" + cityurl + @"\";

                InputUrl = InputFolder + inputpage + "?country=" + dt.Rows[i]["country"].ToString().Trim() + "&statename=" + dt.Rows[i]["statename"].ToString().Trim() + "&city=" + dt.Rows[i]["city"].ToString().Trim() + "&output_path=" + outputpath; // output path is used for article generation;


                OutputUrl = outputpath + pageurl;
                //   Response.Write("File test = " + InputUrl + " " + OutputUrl + "<br/>");
                kreatelog("getcitiesfromplaces url=" + InputUrl + " " + OutputUrl);
                //usa is 3 character
                if ((countryurl.ToString().Length > 2) && (stateurl.Length > 3) && (cityurl.Length > 3))
                {
                    OutputUrl = OutputFolder + countryurl + @"\" + stateurl + @"\" + cityurl + @"\" + pageurl;
                    //  OutputUrl = OutputFolder + dt.Rows[i]["city"].ToString().Trim() + @"/" + dt.Rows[i]["subcategory"].ToString().Trim() + @"index.html";


                    //      KreateWebsites.Generate.overwrite = overwrite;
                    //      Response.Write("File created = " + InputUrl + " " + OutputUrl + "<br/>");
                    KreateWebsites.Generate.GenerateHTML(InputUrl, OutputUrl);

                    //   GenerateHTML(InputUrl, OutputUrl);

                }





            }


        }


        public static void GenerateCities(string InputFolder, string OutputFolder, string inputpage, string pageurl, int count, string country, string state, string statename, int inputurltype, int outputurltype, int seperator_type, int spin)
        {


            DataTable dt;
            string InputUrl, OutputUrl;
            string stateurl, cityurl, countryurl;


            //    KreateWebsites.Generate.overwrite = overwrite;

            InputUrl = InputFolder;
            //     OutputUrl = OutputFolder + pageurl + @".html";



            dt = KreateWebsites.Places.GetCitiesfromPlaces(country, state, statename, count, 1);






            for (int i = 0; i < dt.Rows.Count; i++)
            {
                countryurl = dt.Rows[i]["country"].ToString().Trim();
                //       KreateWebsites.Generate.ReplaceStr(ref countryurl, ' ', '-');

                stateurl = dt.Rows[i]["statename"].ToString().Trim();
                //      KreateWebsites.Generate.ReplaceStr(ref stateurl, ' ', '-');

                cityurl = dt.Rows[i]["city"].ToString().Trim();
                //     KreateWebsites.Generate.ReplaceStr(ref cityurl, ' ', '-');

                switch (seperator_type)
                {
                    case 1:
                        break;
                    case 2:
                        KreateWebsites.Generate.ReplaceStr(ref countryurl, ' ', '-');
                        KreateWebsites.Generate.ReplaceStr(ref stateurl, ' ', '-');
                        KreateWebsites.Generate.ReplaceStr(ref cityurl, ' ', '-');
                        break;
                    case 3:
                        KreateWebsites.Generate.ReplaceStr(ref countryurl, ' ', '_');
                        KreateWebsites.Generate.ReplaceStr(ref stateurl, ' ', '_');
                        KreateWebsites.Generate.ReplaceStr(ref cityurl, ' ', '_');
                        break;

                    default:
                        break;
                }

                switch (outputurltype)
                {
                    case 1:



                        if ((countryurl.ToString().Length > 3) && (stateurl.Length > 3) && (cityurl.Length > 3))
                        {
                            OutputUrl = OutputFolder + countryurl + @"/" + stateurl + @"/" + cityurl + @"/" + pageurl;
                            // generate html only in this if

                        }
                        outputpath = OutputFolder + @"/" + countryurl + @"/" + stateurl + @"/" + cityurl + @"/";
                        OutputUrl = OutputFolder + @"/" + countryurl + @"/" + stateurl + @"/" + cityurl + @"/" + pageurl;
                        break;

                    case 2:
                        outputpath = OutputFolder + @"/" + cityurl + @"/";
                        OutputUrl = OutputFolder + @"/" + cityurl + @"/" + pageurl;
                        break;

                    case 3:
                        outputpath = OutputFolder + @"/" + stateurl + @"/" + cityurl + @"/";
                        OutputUrl = OutputFolder + @"/" + stateurl + @"/" + cityurl + @"/" + pageurl;
                        break;

                    default:
                        outputpath = OutputFolder + @"/" + countryurl + @"/" + stateurl + @"/" + cityurl + @"/";
                        OutputUrl = OutputFolder + @"/" + countryurl + @"/" + stateurl + @"/" + cityurl + @"/" + pageurl;
                        break;

                }

                switch (inputurltype)
                {
                    case 1:
                        InputUrl = InputFolder + inputpage + "?country=" + dt.Rows[i]["country"].ToString().Trim() + "&state=" + dt.Rows[i]["statename"].ToString().Trim() + "&city=" + dt.Rows[i]["city"].ToString().Trim() + "&output_path=" + outputpath; // output path is used for article generation;
                        break;
                    case 2:
                        InputUrl = InputFolder + inputpage + "?country=" + dt.Rows[i]["country"].ToString().Trim() + "&city=" + dt.Rows[i]["city"].ToString().Trim() + "&output_path=" + outputpath; // output path is used for article generation;
                        break;


                    default:
                        InputUrl = InputFolder + inputpage + "?country=" + dt.Rows[i]["country"].ToString().Trim() + "&state=" + dt.Rows[i]["statename"].ToString().Trim() + "&city=" + dt.Rows[i]["city"].ToString().Trim() + "&output_path=" + outputpath; // output path is used for article generation;
                        break;
                }







                KreateWebsites.Generate.GenerateHTML(InputUrl, OutputUrl);







            }


        }

        public static void GeneratePlaces(string InputFolder, string OutputFolder, string inputpage, string pageurl, int spin)
        {


            DataTable dt;
            string InputUrl, OutputUrl;


            //    KreateWebsites.Generate.overwrite = overwrite;

            InputUrl = InputFolder;
            //     OutputUrl = OutputFolder + pageurl + @".html";



            dt = KreateWebsites.Places.GetData(null, null, null, null, null, null, null, null, 50000, 1, 10);






            for (int i = 0; i < dt.Rows.Count; i++)
            {

                string countryurl = dt.Rows[i]["country"].ToString().Trim();
                //       KreateWebsites.Generate.ReplaceStr(ref countryurl, ' ', '-');

                string stateurl = dt.Rows[i]["statename"].ToString().Trim();
                //      KreateWebsites.Generate.ReplaceStr(ref stateurl, ' ', '-');

                string cityurl = dt.Rows[i]["city"].ToString().Trim();
                //     KreateWebsites.Generate.ReplaceStr(ref cityurl, ' ', '-');

                string nameurl = dt.Rows[i]["biz_name"].ToString().Trim();
                //     KreateWebsites.Generate.ReplaceStr(ref cityurl, ' ', '-');

                outputpath = OutputFolder + countryurl + @"\" + stateurl + @"\" + cityurl + @"\" + nameurl + @"\";

                InputUrl = InputFolder + inputpage + "?country=" + dt.Rows[i]["country"].ToString().Trim() + "&statename=" + dt.Rows[i]["statename"].ToString().Trim() + "&city=" + dt.Rows[i]["city"].ToString().Trim() + "&name=" + dt.Rows[i]["biz_name"].ToString().Trim() + "&output_path=" + outputpath; // output path is used for article generation;


                OutputUrl = OutputFolder + countryurl + @"\" + stateurl + @"\" + cityurl + @"\" + nameurl + @"\" + pageurl;
                //   Response.Write("File test = " + InputUrl + " " + OutputUrl + "<br/>");
                //USA length is 2
                if ((countryurl.ToString().Length > 1) && (stateurl.Length > 3) && (cityurl.Length > 3) && (nameurl.Length > 3))
                {
                    OutputUrl = OutputFolder + countryurl + @"\" + stateurl + @"\" + cityurl + @"\" + nameurl + @"\" + pageurl;
                    //  OutputUrl = OutputFolder + dt.Rows[i]["city"].ToString().Trim() + @"/" + dt.Rows[i]["subcategory"].ToString().Trim() + @"index.html";


                    //      KreateWebsites.Generate.overwrite = overwrite;
                    //      Response.Write("File created = " + InputUrl + " " + OutputUrl + "<br/>");
                    KreateWebsites.Generate.GenerateHTML(InputUrl, OutputUrl);

                    //   GenerateHTML(InputUrl, OutputUrl);

                }





            }


        }


        public static void GeneratePlaces(string InputFolder, string OutputFolder, string inputpage, string pageurl, string continent, string country, string state, string statename, string city, int inputurltype, int outputurltype, int seperator_type, int spin)
        {


            DataTable dt;
            string InputUrl, OutputUrl;


            //    KreateWebsites.Generate.overwrite = overwrite;

            InputUrl = InputFolder;
            //     OutputUrl = OutputFolder + pageurl + @".html";



            dt = KreateWebsites.Places.GetData(continent, country, state, statename, city, null, null, null, 5000, 1, 10);






            for (int i = 0; i < dt.Rows.Count; i++)
            {

                InputUrl = InputFolder + inputpage + "?country=" + dt.Rows[i]["country"].ToString().Trim() + "&statename=" + dt.Rows[i]["statename"].ToString().Trim() + "&city=" + dt.Rows[i]["city"].ToString().Trim() + "&name=" + dt.Rows[i]["biz_name"].ToString().Trim() + "&output_path=" + outputpath; // output path is used for article generation;
                string countryurl = dt.Rows[i]["country"].ToString().Trim();
                //       KreateWebsites.Generate.ReplaceStr(ref countryurl, ' ', '-');

                string stateurl = dt.Rows[i]["statename"].ToString().Trim();
                //      KreateWebsites.Generate.ReplaceStr(ref stateurl, ' ', '-');

                string cityurl = dt.Rows[i]["city"].ToString().Trim();
                //     KreateWebsites.Generate.ReplaceStr(ref cityurl, ' ', '-');

                string nameurl = dt.Rows[i]["biz_name"].ToString().Trim();
                //     KreateWebsites.Generate.ReplaceStr(ref cityurl, ' ', '-');




                switch (seperator_type)
                {
                    case 1:
                        break;
                    case 2:
                        KreateWebsites.Generate.ReplaceStr(ref countryurl, ' ', '-');
                        KreateWebsites.Generate.ReplaceStr(ref stateurl, ' ', '-');
                        KreateWebsites.Generate.ReplaceStr(ref cityurl, ' ', '-');
                        KreateWebsites.Generate.ReplaceStr(ref nameurl, ' ', '-');
                        break;
                    case 3:
                        KreateWebsites.Generate.ReplaceStr(ref countryurl, ' ', '_');
                        KreateWebsites.Generate.ReplaceStr(ref stateurl, ' ', '_');
                        KreateWebsites.Generate.ReplaceStr(ref cityurl, ' ', '_');
                        KreateWebsites.Generate.ReplaceStr(ref nameurl, ' ', '-');
                        break;

                    default:
                        break;
                }

                OutputUrl = OutputFolder + countryurl + @"\" + stateurl + @"\" + cityurl + @"\" + nameurl + @"\" + pageurl;

                switch (outputurltype)
                {
                    case 1:



                        if ((countryurl.ToString().Length > 3) && (stateurl.Length > 3) && (cityurl.Length > 3))
                        {
                            OutputUrl = OutputFolder + countryurl + @"/" + stateurl + @"/" + cityurl + @"/" + nameurl + @"/" + pageurl;
                            // generate html only in this if

                        }
                        OutputUrl = OutputFolder + @"/" + countryurl + @"/" + stateurl + @"/" + cityurl + @"/" + nameurl + @"/" + pageurl;
                        break;
                    case 11:



                        outputpath = OutputFolder + @"/" + countryurl + @"/" + stateurl + @"/" + cityurl + @"/";
                        OutputUrl = OutputFolder + @"/" + countryurl + @"/" + stateurl + @"/" + cityurl + @"/" + nameurl + @".html";
                        break;

                    case 2:
                        outputpath = OutputFolder + @"/" + cityurl + @"/" + nameurl + @"/";
                        OutputUrl = OutputFolder + @"/" + cityurl + @"/" + nameurl + @"/" + pageurl;
                        break;

                    case 21:
                        outputpath = OutputFolder + @"/" + cityurl + @"/";
                        OutputUrl = OutputFolder + @"/" + cityurl + @"/" + nameurl + @".html";
                        break;
                    case 3:
                        outputpath = OutputFolder + @"/" + stateurl + @"/" + nameurl + @"/";
                        OutputUrl = OutputFolder + @"/" + stateurl + @"/" + nameurl + @"/" + pageurl;
                        break;

                    case 31:
                        outputpath = OutputFolder + @"/" + stateurl + @"/";
                        OutputUrl = OutputFolder + @"/" + stateurl + @"/" + nameurl + @".html";
                        break;
                    case 4:
                        outputpath = OutputFolder + @"/" + countryurl + @"/" + nameurl + @"/";
                        OutputUrl = OutputFolder + @"/" + countryurl + @"/" + nameurl + @"/" + pageurl;
                        break;
                    case 41:
                        outputpath = OutputFolder + @"/" + countryurl + @"/";
                        OutputUrl = OutputFolder + @"/" + countryurl + @"/" + nameurl + @".html";
                        break;
                    case 5:
                        outputpath = OutputFolder + @"/" + nameurl + @"/";
                        OutputUrl = OutputFolder + @"/" + nameurl + @"/" + pageurl;
                        break;
                    case 51:
                        outputpath = OutputFolder + @"/";
                        OutputUrl = OutputFolder + @"/" + nameurl + @".html";
                        break;

                    case 6:
                        outputpath = OutputFolder + @"/" + stateurl + @"/" + cityurl + @"/" + nameurl + @"/";
                        OutputUrl = OutputFolder + @"/" + stateurl + @"/" + cityurl + @"/" + nameurl + @"/" + pageurl;
                        break;
                    case 61:
                        outputpath = OutputFolder + @"/" + stateurl + @"/" + cityurl + @"/";
                        OutputUrl = OutputFolder + @"/" + stateurl + @"/" + cityurl + @"/" + nameurl + @".html";
                        break;
                    default:
                        outputpath = OutputFolder + @"/" + countryurl + @"/" + stateurl + @"/" + cityurl + @"/";
                        OutputUrl = OutputFolder + @"/" + countryurl + @"/" + stateurl + @"/" + cityurl + @"/" + pageurl;
                        break;

                }


                /*
                  if ((countryurl.ToString().Length > 3) && (stateurl.Length > 3) && (cityurl.Length > 3) && (nameurl.Length > 3))
                  {
                      OutputUrl = OutputFolder + countryurl + @"\" + stateurl + @"\" + cityurl + @"\" + nameurl + @"\" + pageurl;
                
              

              

                  }
                 * */


                switch (inputurltype)
                {
                    case 1:
                        InputUrl = InputFolder + inputpage + "?country=" + dt.Rows[i]["country"].ToString().Trim() + "&state=" + dt.Rows[i]["statename"].ToString().Trim() + "&city=" + dt.Rows[i]["city"].ToString().Trim() + "&name=" + dt.Rows[i]["biz_name"].ToString().Trim() + "&output_path=" + outputpath; // output path is used for article generation;
                        break;


                    case 2:
                        InputUrl = InputFolder + inputpage + "?country=" + dt.Rows[i]["country"].ToString().Trim() + "&city=" + dt.Rows[i]["city"].ToString().Trim() + "&name=" + dt.Rows[i]["biz_name"].ToString().Trim() + "&output_path=" + outputpath; // output path is used for article generation;
                        break;
                    case 3:
                        InputUrl = InputFolder + inputpage + "?country=" + dt.Rows[i]["country"].ToString().Trim() + "&state=" + dt.Rows[i]["statename"].ToString().Trim() + "&name=" + dt.Rows[i]["biz_name"].ToString().Trim() + "&output_path=" + outputpath; // output path is used for article generation;
                        break;

                    case 4:
                        InputUrl = InputFolder + inputpage + "?country=" + dt.Rows[i]["country"].ToString().Trim() + "&name=" + dt.Rows[i]["biz_name"].ToString().Trim() + "&output_path=" + outputpath; // output path is used for article generation;
                        break;
                    case 5:
                        InputUrl = InputFolder + inputpage + "?name=" + dt.Rows[i]["biz_name"].ToString().Trim() + "&output_path=" + outputpath; // output path is used for article generation;
                        break;
                    default:
                        InputUrl = InputFolder + inputpage + "?country=" + dt.Rows[i]["country"].ToString().Trim() + "&state=" + dt.Rows[i]["statename"].ToString().Trim() + "&city=" + dt.Rows[i]["city"].ToString().Trim() + "&name=" + dt.Rows[i]["biz_name"].ToString().Trim() + "&output_path=" + outputpath; // output path is used for article generation;
                        break;
                }
                KreateWebsites.Generate.GenerateHTML(InputUrl, OutputUrl);




            }


        }



        public static void PageMetaData(string articlefile, string name, ref string pageTitle, ref string pageKeywords, ref string pageDescription)
        {



            if (File.Exists(articlefile + ".title"))
            {

                pageTitle = System.IO.File.ReadAllText(articlefile + ".title");

            }
            else
            {

                pageTitle = name;
            }

            if (File.Exists(articlefile + ".desc"))
            {

                pageDescription = System.IO.File.ReadAllText(articlefile + ".desc");



            }

            if (File.Exists(articlefile + ".keywords"))
            {

                pageKeywords = System.IO.File.ReadAllText(articlefile + ".keywords");



            }

        }



        public static void PageComments(string url, ref string Comments)
        {
            string articlefile;

            articlefile = url;
            articlefile = articlefile.Replace(".jpg", ".comments");
            articlefile = articlefile.Replace(".jpeg", ".comments");
            articlefile = articlefile.Replace(".htm", ".comments");
            articlefile = articlefile.Replace(".txt", ".comments");


            if (File.Exists(articlefile))
            {
                Comments = System.IO.File.ReadAllText(articlefile);

            }



        }

        public static void PageInc(string url, ref string Comments)
        {
            string articlefile;

            articlefile = url;
            articlefile = articlefile.Replace(".jpg", ".inc");
            articlefile = articlefile.Replace(".jpeg", ".inc");
            articlefile = articlefile.Replace(".htm", ".inc");
            articlefile = articlefile.Replace(".txt", ".inc");


            if (File.Exists(articlefile))
            {
                Comments = System.IO.File.ReadAllText(articlefile);

            }



        }

        public static void PageLink(string url, ref string Comments)
        {
            string articlefile;

            articlefile = url;
            articlefile = articlefile.Replace(".jpg", ".link");
            articlefile = articlefile.Replace(".jpeg", ".link");
            articlefile = articlefile.Replace(".htm", ".link");
            articlefile = articlefile.Replace(".txt", ".link");


            if (File.Exists(articlefile))
            {
                Comments = System.IO.File.ReadAllText(articlefile);

            }



        }

        public static void CleanStr(ref string myString)
        {

            myString = myString.Replace("-", " ");
            myString = myString.Replace("_", " ");
        }
        public static void ReplaceStr(ref string myString)
        {

            myString = myString.Replace(" ", "-");

        }
        public static void ReplaceStr(ref string myString, char find, char replace)
        {
            if (!String.IsNullOrEmpty(myString))
            {
                myString = myString.Replace(find, replace);
            }

        }
        public static void ReplaceStr(ref string myString, string find, string replace)
        {

            // myString = myString.Replace(find, replace);

            /// testing
            if (myString != null)
            {
                myString = myString.Replace(find, replace);
            }

        }

        public static void ReplaceStr(ref string myString, int seperator_type)
        {


            switch (seperator_type)
            {
                case 1:
                    break;
                case 2:
                    //  replace -, _ with blank
                    myString.Replace("-", " ");
                    myString.Replace("_", " ");


                    break;
                case 3:
                    //  replace -, _ with null
                    myString.Replace("-", "");
                    myString.Replace("_", "");

                    break;
                case 4:
                    //  replace _, with -
                    myString.Replace("_", "-");
                    break;
                case 5:
                    //  replace -, with _
                    myString.Replace("-", "_");
                    break;
                case 6:
                    myString.Replace(" ", "_");
                    break;
                case 7:
                    myString.Replace(" ", "-");
                    break;
                default:
                    break;
            }

        }



        protected void GenerateParlors(string InputFolder, string OutputFolder)
        {


            DataTable dt;
            string InputUrl, OutputUrl;


            KreateWebsites.Generate.overwrite = overwrite;





            dt = KreateWebsites.BeautyParlors.GetData("all", "all", "all", "all", "all", "all", "all", 10000, 1, 1, 1);



            for (int i = 0; i < dt.Rows.Count; i++)
            {

                InputUrl = InputFolder + "details.aspx?name=" + dt.Rows[i]["name"] + "&city=" + dt.Rows[i]["city"];

                string url = dt.Rows[i]["name"].ToString().Trim();
                KreateWebsites.Generate.ReplaceStr(ref url, ' ', '-');


                OutputUrl = OutputFolder + @"content\list-of\" + dt.Rows[i]["city"].ToString().Trim() + @"\phone-address-of-" + url + ".html";

                KreateWebsites.Generate.overwrite = overwrite;
                //  Response.Write("File = " + InputUrl + " " + OutputUrl + "<br/>");
                KreateWebsites.Generate.GenerateHTML(InputUrl, OutputUrl);







            }


        }

        public static void GenerateBeautyCompetition(string InputFolder, string OutputFolder, string competition, string pageurl)
        {
            //   InputFolder = SiteFolder;

            string InputUrl, OutputUrl;

            int startyear = 2001;
            int endyear = DateTime.Now.Year;
            int currentyear = DateTime.Now.Year - 1;
            int year;
            //   string MatchFormat = {    }
            for (year = startyear; year <= endyear; year++)
            {



                string linkpath;
                linkpath = OutputFolder + @"\" + year.ToString() + @"\";  // this is to generate links

                InputUrl = InputFolder + "competition.aspx?year=" + year.ToString() + "&competition_name=" + competition + "&output_path=" + outputpath; // output path is used for article generation;
                OutputUrl = OutputFolder + @"content\" + year + @"\" + pageurl + @".html";
                //     OutputUrl = OutputFolder + reader["country"].ToString() + "\\" + "cities-in-" + reader["Region"].ToString() + ".html";
                //           Response.Write(InputUrl);
                //           Response.Write("<br/>");
                //           Response.Write(OutputUrl);
                //           Response.Write("<br/>");
                //   InputUrl = InputFolder + reader.["statename"].tostring();
                //     Console.WriteLine("{0}\t{1}", reader.GetInt32(0), reader.GetString(1));
                // Response.Write("<br/>in Cricket Match " + year.ToString() + " " + category + "<br/>");
                // Response.Write("url : " + InputUrl + OutputUrl + "<br/>");
                KreateWebsites.Generate.GenerateHTML(InputUrl, OutputUrl);



                InputUrl = InputFolder + "competition.aspx?year=" + currentyear.ToString() + "&competition_name=" + competition + "&output_path=" + outputpath; // output path is used for article generation;
                OutputUrl = OutputFolder + @"content\" + pageurl + @".html";
                KreateWebsites.Generate.GenerateHTML(InputUrl, OutputUrl);

            }





        }

        public void GenerateBeautyCompetitionDetails(string InputFolder, string OutputFolder, string competition_name, string pageurl)
        {
            //   InputFolder = SiteFolder;

            string InputUrl, OutputUrl;

            int startyear = 2001;
            int endyear = DateTime.Now.Year;
            int currentyear = DateTime.Now.Year - 1;

            //   string MatchFormat = {    }

            DataTable dt;

            dt = KreateWebsites.BeautyCompetition.GetBeautyCompetition(competition_name, competition_city, competition_country, year, winner, winner_country, category, count, sortOrder);
            for (int i = 0; i < dt.Rows.Count; i++)
            {



                string linkpath;
                linkpath = OutputFolder + @"\" + year.ToString() + @"\";  // this is to generate links
                InputUrl = " "; OutputUrl = " ";

                string winner_name = dt.Rows[i]["winner"].ToString().Trim();
                KreateWebsites.Generate.ReplaceStr(ref winner_name, ' ', '-');
                InputUrl = InputFolder + "candidate_details.aspx?year=" + dt.Rows[i]["year"].ToString() + "&competition_name=" + dt.Rows[i]["competition_name"].ToString() + "&winner=" + dt.Rows[i]["winner"].ToString() + "&output_path=" + outputpath; // output path is used for article generation;
                OutputUrl = OutputFolder + @"content\" + dt.Rows[i]["year"].ToString() + @"\" + winner_name + @".html";
                //     OutputUrl = OutputFolder + reader["country"].ToString() + "\\" + "cities-in-" + reader["Region"].ToString() + ".html";
                //           Response.Write(InputUrl);
                //           Response.Write("<br/>");
                //           Response.Write(OutputUrl);
                //           Response.Write("<br/>");
                //   InputUrl = InputFolder + reader.["statename"].tostring();
                //     Console.WriteLine("{0}\t{1}", reader.GetInt32(0), reader.GetString(1));
                // Response.Write("<br/>in Cricket Match " + year.ToString() + " " + category + "<br/>");
                //  Response.Write("url : " + InputUrl + OutputUrl + "<br/>");
                KreateWebsites.Generate.GenerateHTML(InputUrl, OutputUrl);


                /*
                             InputUrl = InputFolder + "competition.aspx?year=" + currentyear.ToString() + "&competition_name=" + competition;
                             OutputUrl = OutputFolder + @"content\" + pageurl + @".html";
                             KreateWebsites.Generate.GenerateHTML(InputUrl, OutputUrl);
                 *              */

            }





        }


        public static void GenerateBestInCountry(string InputFolder, string OutputFolder, string inputpage, string pageurl, string pageurl2)
        {


            DataTable dt;
            string InputUrl, OutputUrl;


            //   KreateWebsites.Generate.overwrite = overwrite;

            InputUrl = InputFolder;




            dt = KreateWebsites.Places.GetCountries(null, null, null, 300, 1);






            for (int i = 0; i < dt.Rows.Count; i++)
            {

                InputUrl = InputFolder + inputpage + "?country=" + dt.Rows[i]["country"].ToString().Trim() + "&output_path=" + outputpath; // output path is used for article generation;
                string url = dt.Rows[i]["country"].ToString().Trim();
                KreateWebsites.Generate.ReplaceStr(ref url, ' ', '-');

                OutputUrl = OutputFolder + url + @"/" + pageurl;
                //  OutputUrl = OutputFolder + dt.Rows[i]["city"].ToString().Trim() + @"/" + dt.Rows[i]["subcategory"].ToString().Trim() + @"index.html";


                //  KreateWebsites.Generate.overwrite = overwrite;
                //  Response.Write("File = " + InputUrl + " " + OutputUrl + "<br/>");
                KreateWebsites.Generate.GenerateHTML(InputUrl, OutputUrl);







            }


        }

        public static void AppendSlash(ref string strPath)
        {
            strPath = strPath.TrimEnd('\r', '\n', ' ', '\t');
            
            int length = strPath.Length ;
            //Dec 2020  added check for length 0
            if (length > 0)
            {
                if (strPath[length - 1] != '/')
                {
                    strPath = strPath + @"/";

                }
                kreatelog("strPath=" + strPath);
            }
            else
            {
                kreatelog("strPath is null");
            }
                
        }

        public static void GenerateOneSite(string SiteFolder, string SiteSubFolder, string path)
        {
             string url;
             string name;
             string extension;


             if (File.Exists(path))
             {
                 // This path is a file
                       url = System.IO.Path.GetFileName(path);



                         name = System.IO.Path.GetFileNameWithoutExtension(path);
                         extension = System.IO.Path.GetExtension(path);

                         LocalPath2.InputPath = @"C:\e\a2_generated_sites\" + url + @"\input\";
                         LocalPath2.OutPutPath = @"C:\e\a2_generated_sites\" + url + @"\output\";
                         LocalPath2.ComputerPath = LocalPath2.OutPutPath + @"content\";
                         
                /* 2023 */
                         // Common.Siteurl = @"http://www." + url + @"/";

                          Common.Siteurl = @"https://www." + url + @"/";

                string OutputFolder = LocalPath2.OutPutPath;
                         KreateWebsites.Generate.overwrite = true;
                         string local_path = LocalPath2.InputPath;

                         if (File.Exists(LocalPath2.InputPath + @"\site.siteurl"))
                         {
                             string str = System.IO.File.ReadAllText(LocalPath2.InputPath + @"\site.siteurl");

                             Common.Siteurl = str.TrimEnd('\r', '\n');


                         }
                         /* 2023 May Email address */
                       
                        if (File.Exists(LocalPath2.InputPath + @"\email.address"))
                        {
                            string str = System.IO.File.ReadAllText(LocalPath2.InputPath + @"\email.address");

                             Common.EmailAddress = str.TrimEnd('\r', '\n');


                        }
                       

                InitailizeSite(@"C:\e\a2_generated_sites\" + url + @"\input\");

                      // SiteFolder = @"http://localhost:100/kreatewebsites.com/";
                      //SiteSubFolder = @"generate/site1/" ;
                         KreateWebsites.Generate.Generatesubdirs(local_path, OutputFolder, SiteFolder + SiteSubFolder, true, "myfile30.log");


                     }


                     else
                     {
                         Console.WriteLine("No rows found.");
                     }


           }

        public static void CopyFile(string srcpath, string destpath)
        {
            try
            {
                if (!File.Exists(destpath))
                {
                    System.IO.File.Copy(srcpath, destpath);
                }
            }
            catch (Exception e)
            {
                ;
            }

           
        }

        public static void ComputeThumbnail(string imagepath, string thumbnail_path, string url, ref string imagefullurl)
        {
            if (thumbnail_path.Contains("http://") || thumbnail_path.Contains("https://") ) /* 2023 added https */
            {
                imagefullurl = thumbnail_path + url;   // full path is given as http://pictures.kreatewebsites.com/photos400
            }
            else
            {
                imagefullurl = imagepath + thumbnail_path + url;
            }
        }

        public static string GetNameFromUrl(string imageurl)
        {
            // int lastSlashIndex = -1;
            string url = imageurl;

            if (imageurl.StartsWith("https://") || imageurl.StartsWith("http://"))
            {
                string[] urlParts = imageurl.Split('/');
                url = urlParts.Last();
            }
            else
            {
                url = imageurl;

            }
            return url;
        }
    }
}






