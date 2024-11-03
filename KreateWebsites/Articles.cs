
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Globalization;

using System.Collections.Generic;


using System.Net;
using System.IO;


namespace KreateWebsites
{
    public class Articles
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

        protected static int dt_tableindex = 0;


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

        public static void GetPath(string inputdir)
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

        public static int GetImageFullUrl(string imagepath, string imageurl, string thumbnail_path, ref string imagefullurl, ref string thumbnailurl)
        {

            if (imageurl.Contains("http://") || imageurl.Contains("https://")) /*2023 */
            {


                Uri uri = new Uri(imageurl);
                if (uri.IsFile)
                {
                    string filename = System.IO.Path.GetFileName(uri.LocalPath);
                    string path = System.IO.Path.GetDirectoryName(uri.LocalPath);
                    thumbnailurl = path + thumbnail_path + imageurl;
                }

                imagefullurl = imageurl;

                // thumbnailurl = imagefullurl;  // later improve this to build thumbailpath
                return 1;
            }
            else
            {
                thumbnailurl = imagepath + thumbnail_path + imageurl;
                imagefullurl = imagepath + imageurl;
                return 0;
            }


        }

        public static DataTable GetData(string inputdir)
        {


            string displayname;


            DataTable dt = GetTable(inputdir);
            GetPath(inputdir);


            string[] fileEntries = Directory.GetFiles(inputdir);
            int i = 0;
            string url, imagefullurl = null, thumbnailurl = null;
            string navigateurl = null;

            bool articles_individualpage = Common.Articles.individualpage;
            /* Jun 2024 - potential error check this . do we need articles.individualpage. is it for pictures */
            if (File.Exists(inputdir + @"\articles.individualpage"))
            {
                string individualpage = System.IO.File.ReadAllText(inputdir + @"\articles.individualpage");
                individualpage.Trim();

                if (individualpage[0] == '1')
                    articles_individualpage = true;
                else
                    articles_individualpage = false;
                // pictures_individualpage = individualpage.Equals("1", StringComparison.Ordinal);


            }

            Generate.kreatelog("Common.Articles.includepictures is = " + Common.Articles.includepictures.ToString()); 

            if (Common.Articles.includepictures == true)
            {
                //  This read image files from directory. 
                Generate.kreatelog("In if 1"); 
                foreach (string path in fileEntries)
                {
                    i++;


                    Generate.kreatelog("In for loop " + i.ToString() ); 


                    string name;
                    string extension;

                    if (File.Exists(path))
                    {
                        // This path is a file

                        url = System.IO.Path.GetFileName(path);
                        name = System.IO.Path.GetFileNameWithoutExtension(path);
                        extension = System.IO.Path.GetExtension(path);

                        if ((extension.ToLower() == ".htm") || (extension.ToLower() == ".txt") || (extension.ToLower() == ".comments") || (extension.ToLower() == ".title") 
                            || (extension.ToLower() == ".keywords") || (extension.ToLower() == ".description") ||  (extension.ToLower() == ".link"))
                        {
                           
                            displayname = name;
                            Generate.kreatelog("In displayname = "+ displayname); 
                            ReadText(path, ref text, 3);   //July 2 2016 added level
                            string navigatename = displayname;
                            /*  individual page generation is not working with this, store displayname without cleaning into navigate name */
                            displayname = displayname.Replace("-", " ");
                            displayname = displayname.Replace("_", " ");
                            displayname = displayname.ToUpper();


                            if (articles_individualpage == true)
                            {
                                // navigateurl = name + ".html";  // change it to displayname .html once able to generate displayname.html
                                navigateurl = displayname + ".html";
                            }
                            else
                            {
                                navigateurl = imagefullurl;
                            }

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

            /* Jun 2024 potential error - articles.articleslist */
            Generate.kreatelog("Before articleslist"); 
            if (File.Exists(inputdir + @"\articles.articleslist"))
            {

                Generate.kreatelog("In  articleslist"); 
                System.IO.StreamReader file =
                   new System.IO.StreamReader(inputdir + @"\articles.articleslist");
                while ((url = file.ReadLine()) != null)
                {
                    name = url; // remove .jpg

                    name = name.Replace(".txt", "");
                    name = name.Replace(".htm", "");
                    name = name.Replace(".comments", "");
                    name = name.Replace(".TXT", "");



                    //     dt.Rows.Add(i, imagefullurl, name);

                    /* test 
                    thumbnailurl = ImagePath + thumbnail_path + url;
                    imagefullurl = ImagePath + url;
                    */
            //     GetImageFullUrl(ImagePath, url, thumbnail_path, ref imagefullurl, ref thumbnailurl); // test
            //   GetSlideAttributes(inputdir, name, ref text);
            displayname = name;
                    // not needed GetPictureAttributes(inputdir, name, ref text, ref displayname);
                    ReadText(url, ref text, 3);  //July 2, 2016
                //    Generate.kreatelog("ReadTXT " + url + " text " + text );
                    string navigatename = displayname;
                    /* individal page generation is not working with this */
                    displayname = displayname.Replace("-", " ");
                    displayname = displayname.Replace("_", " ");
                    displayname = displayname.ToUpper();




                    if (articles_individualpage == true)
                    {
                        // navigateurl = name + ".html";
                        navigateurl = navigatename + ".html";
                    }
                    else
                    {
                        navigateurl = imagefullurl;
                    }

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


            return dt;

        }
        


        public static DataTable GetListData(string inputdir, string listfile)
        {


            string displayname;


            DataTable dt = GetTable(inputdir);
            GetPath(inputdir);


            string[] fileEntries = Directory.GetFiles(inputdir);
            int i = 0;
            string url, imagefullurl = null, thumbnailurl = null;
            string navigateurl = null;

            bool articles_individualpage = Common.Articles.individualpage;

            bool is_text = false;

            KreateWebsites.Generate.kreatelog("GetList Data 1 input dir, listfile" + inputdir + listfile);
            if (File.Exists(inputdir + @"\" + listfile))
            {

               System.IO.StreamReader file =
                   new System.IO.StreamReader(inputdir + @"\" + listfile);


               try
               {

                   using (file)
                   {


                       while ((url = file.ReadLine()) != null)
                       {

                           Generate.kreatelog("GetListData 2  line is " + url);
                           is_text = CheckText(url);
                           if (is_text)
                           {
                               Generate.kreatelog("GetListData 3 line txt is " + text);
                               text = url;  // it was not url but a line in .articlelist
                               displayname = " "; // future retrieve it by removing html tag.
                           }
                           else
                           {


                                Generate.kreatelog("GetListData 4 line txt is " + text);

                                name = url; // remove .jpg

                               name = name.Replace(".txt", "");
                               name = name.Replace(".htm", "");
                               name = name.Replace(".comments", "");
                               name = name.Replace(".TXT", "");



                               displayname = name;

                               ReadText(url, ref text, 3);  //July 2, 2016
                               //    Generate.kreatelog("ReadTXT " + url + " text " + text );
                               string navigatename = displayname;
                               /* individal page generation is not working with this */
                               displayname = displayname.Replace("-", " ");
                               displayname = displayname.Replace("_", " ");
                               displayname = displayname.ToUpper();



                               /* Not needed now.  Will be usefl when we add More functionality 
                               if (articles_individualpage == true)
                               {
                        
                                   navigateurl = navigatename + ".html";
                               }
                               else
                               {
                                   navigateurl = imagefullurl;
                               }
                               */
                           } //else
                           Generate.kreatelog("adding text " + text);
                           if (text != null)
                           {
                               dt.Rows.Add(i, thumbnailurl, name, displayname, imagefullurl, title, text, continent, country, state, statename, city, category, subcategory, navigateurl);
                           }

                           text = "";  // reset column for next slide.
                           is_text = false; // set false again for next line
                           i++;
                       } //while
                   }  //using
               } // try
               catch (Exception e)
               {
                   // Let the user know what went wrong.
                   /* Jun 2024 */
                   // Generate.kreatelog("The file could not be read:");
                   string error_msg = "The file could not be read 1:" + listfile;
                   Generate.kreatelog(error_msg);
                    Generate.kreatelog(e.Message);
               }  //catch
               finally
               {
                   file.Close();
               }

                
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
        public static DataTable GetListData(string filename)
        {


            string displayname;


            DataTable dt = GetTable(" ");
         

          
            int i = 0;
            string url, imagefullurl = null, thumbnailurl = null;
            string navigateurl = null;

            bool articles_individualpage = Common.Articles.individualpage;

            bool is_text = false;
           
            Generate.kreatelog("Get List Data 2 filename is " + filename);
            if (File.Exists(filename))
            {

                System.IO.StreamReader file =
                   new System.IO.StreamReader(filename);

                
               try
               {

                   using (file)
                   {

                while ((url = file.ReadLine()) != null)
                {
                    Generate.kreatelog("GetListData 2 - 1 url line is " + url);
                    is_text = CheckText(url);
                    if (is_text)
                    {
                        Generate.kreatelog("Get List Data 2-1 url line txt is " + text);
                        text = url;  // it was not url but a line in .articlelist
                        displayname = " "; // future retrieve it by removing html tag.
                    }
                    else
                    {

                        Generate.kreatelog("Get List Data 2-1 url line txt is " + text);
                        name = url; 

                        name = name.Replace(".txt", "");
                        name = name.Replace(".htm", "");
                        name = name.Replace(".comments", "");
                        name = name.Replace(".TXT", "");



                        displayname = name;

                        ReadText(url, ref text, 3);  //July 2 , 2016. added level
                        //    Generate.kreatelog("ReadTXT " + url + " text " + text );
                        string navigatename = displayname;
                        /* individal page generation is not working with this */
                        displayname = displayname.Replace("-", " ");
                        displayname = displayname.Replace("_", " ");
                        displayname = displayname.ToUpper();



                        /* Not needed now.  Will be usefl when we add More functionality 
                        if (articles_individualpage == true)
                        {
                        
                            navigateurl = navigatename + ".html";
                        }
                        else
                        {
                            navigateurl = imagefullurl;
                        }
                        */
                    }
                    Generate.kreatelog("Get List Data i name text is " + i.ToString() + "," + name + "," + text);
                    if (text != null)
                    {
                       
                        dt.Rows.Add(i, thumbnailurl, name, displayname, imagefullurl, title, text, continent, country, state, statename, city, category, subcategory, navigateurl);
                    }

                    text = "";  // reset column for next slide.
                    is_text = false; // set false again for next line
                    i++;
                }
              }  //using
            } // try
               catch (Exception e)
               {
                   // Let the user know what went wrong.
                   /* Jun 2024 */
                   // Generate.kreatelog("The file could not be read:");
                   string error_msg = "The file could not be read 2:" + filename;
                   Generate.kreatelog(error_msg);
                    Generate.kreatelog(e.Message);
               }  //catch
               finally
               {
                   file.Close();
               }

          


            }



            if (dt.Rows.Count > 0)
            {

                //     Response.Write("Count is " + dt.Rows.Count.ToString());

                //         RepDetails.DataSource = dt;
                //       RepDetails.DataBind();



            }



         


            return dt;

        }
        public static DataTable GetListData(string filename, int level)  // July 3,2016
        {

            
            // This function is tested.  test other variation
            string displayname = "dummy";


            DataTable dt = GetTable(" ");
            dt_tableindex = 0;   // at start set to 0


            int i = 0;
            string url, imagefullurl = null, thumbnailurl = null;
            string navigateurl = null;

            bool articles_individualpage = Common.Articles.individualpage;

            bool is_text = false;

            Generate.kreatelog2("Get List Data 3 filename is " + filename);
            if (File.Exists(filename))
            {

                System.IO.StreamReader file =
                   new System.IO.StreamReader(filename);


                try
                {

                    using (file)
                    {

                        while ((url = file.ReadLine()) != null)
                        {

                            /* July 3 2016 */
                            // int is_articlelist = CheckArticleList(url);  // give error is text is found.  

                            if (is_text = CheckText(url))
                            {

                                text = url;
                                displayname = " "; // future retrieve it by removing html tag.
                                KreateWebsites.Generate.kreatelog2("found text in  articlelist " + text);
                                /*July 18 */
                                dt.Rows.Add(dt_tableindex, thumbnailurl, name, displayname, imagefullurl, title, text, continent, country, state, statename, city, category, subcategory, navigateurl);
                                dt_tableindex++;
                            }
                            //  else if (is_articlelist == 2)
                            else if (CheckArticleList(url) == 2)
                            {
                                Generate.kreatelog2("article list inside article list " + url);
                                string articlefilename = url;
                                GetListData2(articlefilename, ref dt);  // it will append in datatable. each file will be appended.
                                Generate.kreatelog2("returned from GetListData2 =  " + dt_tableindex.ToString());
                            }

                            else
                            {
                                name = url;

                                KreateWebsites.Generate.kreatelog("found url in  articlelist " + url);
                                name = name.Replace(".txt", "");
                                name = name.Replace(".htm", "");
                                name = name.Replace(".comments", "");
                                name = name.Replace(".TXT", "");



                                displayname = name;

                                //   ReadText(url, ref text); working
                                  //Jun 2024 potential error here - if file is not found - read ext will fail.
                                ReadText(url, ref text, 3);  //July 2 , 2016. added level
                            //    ReadText(url, ref text);  // July 25  // this write path c:\e\
                                string navigatename = displayname;
                                /* individal page generation is not working with this */
                                displayname = displayname.Replace("-", " ");
                                displayname = displayname.Replace("_", " ");
                                displayname = displayname.ToUpper();





                                if (text != null)
                                {
                                    Generate.kreatelog2("added rows in datatable 1 - Get List Data i name text is " + dt_tableindex.ToString() + "," + name + "," + text);
                                    // July 15 dt.Rows.Add(i, thumbnailurl, name, displayname, imagefullurl, title, text, continent, country, state, statename, city, category, subcategory, navigateurl);
                                    dt.Rows.Add(dt_tableindex, thumbnailurl, name, displayname, imagefullurl, title, text, continent, country, state, statename, city, category, subcategory, navigateurl);
                                    dt_tableindex++;
                                }
                                else
                                {
                                    Generate.kreatelog2("in else Get List Data i name text is " + dt_tableindex.ToString() + "," + name + "," + "null");
                                }

                            }  
                            text = "";  // reset column for next slide.
                            is_text = false; // set false again for next line
                                             // i++;
                          
                        }
                    }  //using
                } // try
                catch (Exception e)
                {
                    // Let the user know what went wrong.
                    /* Jun 2024 */
                    //  Generate.kreatelog("The file could not be read:");
                    string error_msg = "The file could not be read 3x:" + filename;
                    Generate.kreatelog(error_msg);
                    Generate.kreatelog(e.Message);
                    //2024 
                    
                }  //catch
                // Jun 2024 commenting it to continue
                /*
                finally
                {
                    file.Close();
                }
                */



            }



            if (dt.Rows.Count > 0)
            {

                //     Response.Write("Count is " + dt.Rows.Count.ToString());

                //         RepDetails.DataSource = dt;
                //       RepDetails.DataBind();



            }




            Generate.kreatelog2("returning databale from main function = " + dt_tableindex.ToString() +  " " +  dt.Rows.Count.ToString()); 
            
            return dt;

        }
        // July 3, 2016
        public static DataTable GetListData(string inputdir, string listfile, int level)
        {


            DataTable dt = GetTable(inputdir);
            GetPath(inputdir);


            string[] fileEntries = Directory.GetFiles(inputdir);
            int i = 0;
           
            bool articles_individualpage = Common.Articles.individualpage;

            KreateWebsites.Generate.kreatelog2("GetList Data 4");

            if (File.Exists(inputdir + @"\" + listfile))
            {

                System.IO.StreamReader file =
                    new System.IO.StreamReader(inputdir + @"\" + listfile);

                GetListData3(file, dt, 3);
                
             } // try
               
            return dt;

        }

        // ListData2 is same as ListData.  Only difference is - it is not creating new data table. it is using one passed by parent
        private static DataTable GetListData2(string filename, ref DataTable dt)
        {


            string displayname;


           



           
            string url, imagefullurl = null, thumbnailurl = null;
            string navigateurl = null;

            bool articles_individualpage = Common.Articles.individualpage;

            bool is_text = false;

            Generate.kreatelog2("Get List Data 2 filename is " + filename);
            if (File.Exists(filename))
            {

                System.IO.StreamReader file =
                   new System.IO.StreamReader(filename);


                try
                {

                    using (file)
                    {

                        while ((url = file.ReadLine()) != null)
                        {
                            Generate.kreatelog2("-->Get List Data 2 " + url);
                            
                            is_text = CheckText(url);
                            if (is_text)
                            {
                                Generate.kreatelog2("Get List Data 2 url line txt is " + text);
                                text = url;  // it was not url but a line in .articlelist
                                displayname = " "; // future retrieve it by removing html tag.


                                if (text != null)
                                {
                                    Generate.kreatelog2("Added in datatable position  = " + dt_tableindex.ToString());
                                    Generate.kreatelog2("Added in datatable  = " + text);
                                    dt.Rows.Add(dt_tableindex, thumbnailurl, name, displayname, imagefullurl, title, text, continent, country, state, statename, city, category, subcategory, navigateurl);
                                    dt_tableindex++;
                                }


                            }
                            
                            else if (CheckArticleList(url) == 2)
                            {
                                Generate.kreatelog2("article list inside article list " + url);
                                string articlefilename = url;
                                Generate.kreatelog2("calling in recursion  = " + dt_tableindex.ToString());

                                GetListData2(articlefilename, ref dt);  // it will append in datatable. each file will be appended.

                                Generate.kreatelog2("after calling in recursion  = " + dt_tableindex.ToString());
                                
                            }


                            else
                            {
                                name = url;

                                name = name.Replace(".txt", "");
                                name = name.Replace(".htm", "");
                                name = name.Replace(".comments", "");
                                name = name.Replace(".TXT", "");



                                displayname = name;
                                ReadText(url, ref text );
                              //July 16 comment  ReadText(url, ref text, 3);  //July 2 , 2016. added level
                                                             //    Generate.kreatelog("ReadTXT " + url + " text " + text );
                                string navigatename = displayname;
                                /* individal page generation is not working with this */
                                displayname = displayname.Replace("-", " ");
                                displayname = displayname.Replace("_", " ");
                                displayname = displayname.ToUpper();



                                /* Not needed now.  Will be usefl when we add More functionality 
                                if (articles_individualpage == true)
                                {

                                    navigateurl = navigatename + ".html";
                                }
                                else
                                {
                                    navigateurl = imagefullurl;
                                }
                                */

                                Generate.kreatelog2("added rows in datatable  2, Get List Data i name text is " + dt_tableindex.ToString() + "," + name + "," + text);
                                if (text != null)
                                {
                                    Generate.kreatelog2("2 Added in datatable position  = " + dt_tableindex.ToString());
                                    Generate.kreatelog2("2 Added in datatable  = " + text);
                                    dt.Rows.Add(dt_tableindex, thumbnailurl, name, displayname, imagefullurl, title, text, continent, country, state, statename, city, category, subcategory, navigateurl);
                                    dt_tableindex++;
                                }
                            }
                            text = "";  // reset column for next slide.
                            is_text = false; // set false again for next line
                           
                            // i++;
                        }
                    }  //using
                } // try
                catch (Exception e)
                {
                    // Let the user know what went wrong.
                    // Generate.kreatelog("The file could not be read :");
                    // Jun 2024
                    string error_msg = "The file could not be read 4:" + filename;
                    Generate.kreatelog(error_msg);
                    Generate.kreatelog(e.Message);
                }  //catch
                finally
                {
                    file.Close();
                }




            }



            if (dt.Rows.Count > 0)
            {

                //     Response.Write("Count is " + dt.Rows.Count.ToString());

                //         RepDetails.DataSource = dt;
                //       RepDetails.DataBind();



            }






            return dt;

        }
        private static DataTable GetListData3(StreamReader file,  DataTable dt, int level)  // July 3,2016
        {


            string displayname = "dummy";
                   
            int i = 0;
            string url, imagefullurl = null, thumbnailurl = null;
            string navigateurl = null;

            bool articles_individualpage = Common.Articles.individualpage;

            bool is_text = false;


            try
            {

                   using (file)
                    {

                        while ((url = file.ReadLine()) != null)
                        {

                        /* July 3 2016 */
                        //  error. call after text check int is_articlelist = CheckArticleList(url);

                        if (CheckArticleList(url) == 2)
                            {
                                Generate.kreatelog("article list inside article list");
                                string articlefilename = url;
                                GetListData2(articlefilename, ref dt);

                            }
                           else if ((CheckArticleList(url) == 1) || (CheckArticleList (url) == 4))
                            {
                                /* July 3 2016 */
                                // Generate.kreatelog("Get List Data 1 url line is " + url);
                                /* is_text = CheckText(url);
                                if (is_text)
                                {
                                    Generate.kreatelog("Get List Data 1 url line txt is " + text);
                                    text = url;  // it was not url but a line in .articlelist
                                    displayname = " "; // future retrieve it by removing html tag.
                                } */
                            }
                            else
                            {
                                name = url;

                                name = name.Replace(".txt", "");
                                name = name.Replace(".htm", "");
                                name = name.Replace(".comments", "");
                                name = name.Replace(".TXT", "");



                                displayname = name;

                                ReadText(url, ref text, 3);  //uly 2 , 2016. added level
                                                             //    Generate.kreatelog("ReadTXT " + url + " text " + text );
                                string navigatename = displayname;
                                /* individal page generation is not working with this */
                                displayname = displayname.Replace("-", " ");
                                displayname = displayname.Replace("_", " ");
                                displayname = displayname.ToUpper();



                              
                            }
                            Generate.kreatelog2("added rows in datatable 3 Get List Data i name text is " + i.ToString() + "," + name + "," + text);
                            if (text != null)
                            {
                            // change i to dt_tableindex   Jul 25
                                dt.Rows.Add(dt_tableindex, thumbnailurl, name, displayname, imagefullurl, title, text, continent, country, state, statename, city, category, subcategory, navigateurl);
                                dt_tableindex++;
                           }

                            text = "";  // reset column for next slide.
                            is_text = false; // set false again for next line
                            i++;
                        }
                    }  //using
                } // try
                catch (Exception e)
                {
                // Let the user know what went wrong.
                /* Jun 2024 */
                // Generate.kreatelog("The file could not be read:");
                string error_msg = "The file could not be read 5:" + file;
                Generate.kreatelog(error_msg);
                Generate.kreatelog(e.Message);
                }  //catch
                finally
                {
                    file.Close();
                }




            if (dt.Rows.Count > 0)
            {

                //     Response.Write("Count is " + dt.Rows.Count.ToString());

                //         RepDetails.DataSource = dt;
                //       RepDetails.DataBind();



            }






            return dt;

        }   // process Articlelist file
        public static void GetPictureComments(string inputdir, ref string comments)
        {
            if (File.Exists(inputdir + @"\articles.comments"))
            {

                comments = System.IO.File.ReadAllText(inputdir + @"\articles.comments");

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
            string picalt = null;
            if (File.Exists(inputdir + @"\" + name + @".comments"))
            {
                text = System.IO.File.ReadAllText(inputdir + @"\" + name + @".comments");
                if (text.Length > 300)
                {
                    text = text.Substring(0, 300);
                }
                //    Response.Write("<br/> Picture Attribute : " + inputdir + " " + name + "," + text + "<br/>");

            }
            Generate.kreatelog("Get article attribute of file " + inputdir + @"\" + name + @".name");

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
                //Nov 14 Generate.filegenerate(inputdir + @"\", @"gen.name", @".name", 1, name); //Nov 14
                Photos.GetDefaultPictureAttribute(name, ref picname, ref picalt);  //   Aug 2 , 2016

                Generate.filegenerate(inputdir + @"\", @"gen.name", @".name", 1, name, Common.genName);

            }
           
            
            Generate.ConfigFileCheckAndGenerate(inputdir + subfolder + @"\", @"gen.comments", @".comments", 0, name); // 0 to write blank

            /* 2024 to generate title files of slide picture individual page */
            // Generate.ConfigFileCheckAndGenerate(inputdir + subfolder + @"\", @"gen.title", @".title", 0, name); // 0 to write blank
            Generate.kreatelog2("2024 generating title " + inputdir + subfolder + @"\" );
            Generate.ConfigFileCheckAndGenerate(inputdir + subfolder + @"\", @"gen.title", @".title", 1, name, Common.genTitle);
        }

        public static void ReadText(string path, ref string text, int level)
        {
           
            string articlesRoot = @"C:\e\";
            /* Jun 2024 , Potential error  Added if condition */ 
            if (File.Exists(path))
            { 
                System.IO.StreamReader file =
                  new System.IO.StreamReader(path);

                Generate.kreatelog("3x inf if" + path);
                try
                    {
                             /* jun 2024 potential error - is file defined */
                            while ((url = file.ReadLine()) != null)  // July 14b
                            {
                                // url = file.ReadLine();
                                KreateWebsites.Generate.kreatelog2("url in ReadText = " + url);
                                // KreateWebsites.Generate.kreatelog("url in ReadText = " + url);
                                if (String.Compare(url, 0, articlesRoot, 0, 5, new CultureInfo("en-US"), CompareOptions.IgnoreCase) == 0)
                                {
                                    KreateWebsites.Generate.kreatelog2("3x url is = " + url);
                                    //  ReadText(url, ref text);  
                                    ReadText(url, ref text, 3); // July 14-15
                                }
                                else
                                {
                                    ReadText(path, ref text);  // Read from path passed above
                                    text = System.IO.File.ReadAllText(path);


                                }
                            }  // july 14 b - created while loop. earlier only first line was read.
                
                    }
                    catch
                    {
                        KreateWebsites.Generate.kreatelog("ReadText 3 catch " + path);
                        text = null;
                    }
                    finally
                    {
                        file.Close();  // July 14 , file is locked by iisexpress. release it
                    }
            } // Jun 2024 if condition
            else
            {
                text = null;
                Generate.kreatelog("3x returning null" + path); 
            }
            /*  Later do for multi line  
            while ((url = file.ReadLine()) != null)
            {

                if (String.Compare(url, 0,articlesRoot , 0, 5,new CultureInfo("en-US"), CompareOptions.IgnoreCase) == 0)
                {


                }
                else
                {
                    text = System.IO.File.ReadAllText(path);


                }


            }

            */
            //  ReadText(path, ref text); // fix above and remove this line
        }
        public static void ReadText(string path, ref string text)
        {
            KreateWebsites.Generate.kreatelog("old ReadText = "  +  path);
            if (File.Exists(path))
            {
                try
                {
                    text = System.IO.File.ReadAllText(path);
                }
                catch
                {
                    KreateWebsites.Generate.kreatelog("ReadText catch  " + path);
                    text = null;
                }
                finally
                {
                   // text = null;
                }


            }
            /* Jun 2024  , added else condition potential error */
            else
            {
                text = null;

            }


        }

        
        public static bool CheckText(string path)
        {
            Generate.kreatelog("In CheckTest 1 " + path ) ;
            if ((path != null)  )
            {
                if (path[0] == '<')
                {
                    Generate.kreatelog("In CheckTest 2  returning true");
                    return true;
                }
                /* Working but blank line at end cause failure 
                 else if (path[0] == ' ')
                 {
                   return true;
                  } 
                 * */
                else
               {
                    Generate.kreatelog("In CheckTest 3  returning false");
                    return false;
                }
            }
            else
            {
                return false;
            }

        }

        public static int CheckArticleList(string path)
        {
            string extension, extension2;
            Generate.kreatelog("In CheckArticleTest " + path);
            extension2 = Path.GetExtension(path);
            extension = extension2.Trim();
            string test2 = @".articlelist";

            int test = string.Compare(extension, @".articlelist", true);
            KreateWebsites.Generate.kreatelog2("String comparision = " + test.ToString());
            KreateWebsites.Generate.kreatelog2("extension is "  + extension);
            KreateWebsites.Generate.kreatelog2("length is " + extension.Length.ToString() + "," + test2.Length.ToString() );

            if (extension.Equals(@".artcilelist"))
            {
                KreateWebsites.Generate.kreatelog2("articlelist is equal");
            }

            if (string.Compare(extension, ".txt") == 0)
            {
                KreateWebsites.Generate.kreatelog("returning 1 ");
                return 1;
            }

            else if (string.Compare(extension, ".articlelist")==0)
            {
                KreateWebsites.Generate.kreatelog("returning 2 " );
                return 2;
            }
            else if (string.Compare(extension, ".articleslist") == 0)
            {
                KreateWebsites.Generate.kreatelog("returning 3 ");
                return 3;
            }
            else if (string.Compare(extension, ".htm") == 0)
            {
                KreateWebsites.Generate.kreatelog("returning 4 ");
                return 4;
            }
            else if (string.Compare(extension, ".html") == 0)
            {
                KreateWebsites.Generate.kreatelog("returning 5 ");
                return 5;
            }
            else
            {
                KreateWebsites.Generate.kreatelog("returning 0 ");
                return 0;
            }

            
          

        }
    }
}






