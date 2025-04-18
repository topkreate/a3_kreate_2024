﻿
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
using System.Data.Linq;


namespace KreateWebsites
{
    public class Page
    {





        static DataTable LinkTable()
        {


            DataTable table = new DataTable();
            try
            {





                table.Columns.Add("id", typeof(int));
                table.Columns.Add("url", typeof(string));
                table.Columns.Add("name", typeof(string));
                table.Columns.Add("level", typeof(int));
                table.Columns.Add("title", typeof(string));
                table.Columns.Add("keywords", typeof(string));
                table.Columns.Add("description", typeof(string));




            }
            catch (Exception e)
            {
                // Response.Write("Exception is : " + e.Message);
            }


            return table;



        }

        static DataTable LinkTable2()
        {


            DataTable table = new DataTable();
            try
            {





                table.Columns.Add("id", typeof(int));
                table.Columns.Add("url", typeof(string));
                table.Columns.Add("name", typeof(string));
                table.Columns.Add("level", typeof(int));




            }
            catch (Exception e)
            {
                // Response.Write("Exception is : " + e.Message);
            }


            return table;



        }



/*
        public static void PageMetaData(string articlefile, string name, ref string pageTitle, ref string pageKeywords, ref string pageDescription)
        {
            string ename, fname, fpath;
            ename = System.IO.Path.GetFileNameWithoutExtension(articlefile);

            fpath = System.IO.Path.GetDirectoryName(articlefile);
            fname = fpath + @"\" + ename;

           // Response.Write("fname = " + fname);
            if (File.Exists(fname + ".title"))
            {

                pageTitle = System.IO.File.ReadAllText(fname + ".title");

            }
            else
            {

                pageTitle = name;
            }

            if (File.Exists(fname + ".desc"))
            {

                pageDescription = System.IO.File.ReadAllText(fname + ".desc");



            }

            if (File.Exists(fname + ".keywords"))
            {

                pageKeywords = System.IO.File.ReadAllText(fname + ".keywords");



            }
        }
 * */

        public static void PageMetaData(string articlefile, string name, ref string pageTitle, ref string pageKeywords, ref string pageDescription , int seperator_type=1)
        {
            string ename, fname, fpath;
            ename = System.IO.Path.GetFileNameWithoutExtension(articlefile);

            fpath = System.IO.Path.GetDirectoryName(articlefile);
            fname = fpath + @"\" + ename;

            // Response.Write("fname = " + fname);
            if (File.Exists(fname + ".title"))
            {

                pageTitle = System.IO.File.ReadAllText(fname + ".title");

            }
            else
            {

                pageTitle = name;

                KreateWebsites.Generate.ReplaceStr(ref pageTitle, seperator_type);
               

            }

            if (File.Exists(fname + ".desc"))
            {

                pageDescription = System.IO.File.ReadAllText(fname + ".desc");



            }

            if (File.Exists(fname + ".keywords"))
            {

                pageKeywords = System.IO.File.ReadAllText(fname + ".keywords");



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
            articlefile = articlefile.Replace(".JPG", ".comments");
            articlefile = articlefile.Replace(".JPEG", ".comments");
            articlefile = articlefile.Replace(".png", ".comments");
            articlefile = articlefile.Replace(".PNG", ".comments");

            if (File.Exists(articlefile))
            {
                Comments = System.IO.File.ReadAllText(articlefile);

            }



        }

        public static void PageInc(string url, ref string  Comments)
        {
            string articlefile;

            articlefile = url;
            articlefile = articlefile.Replace(".jpg", ".inc");
            articlefile = articlefile.Replace(".jpeg", ".inc");
            articlefile = articlefile.Replace(".htm", ".inc");
            articlefile = articlefile.Replace(".txt", ".inc");
            articlefile = articlefile.Replace(".JPG", ".inc");
            articlefile = articlefile.Replace(".JPEG", ".inc");
            articlefile = articlefile.Replace(".png", ".inc");
            articlefile = articlefile.Replace(".PNG", ".inc");

            if (File.Exists(articlefile))
            {
                Comments = System.IO.File.ReadAllText(articlefile);

            }



        }

        public static void PageLink(string url, ref string Comments)
        {
            string articlefile;

            articlefile = url;
            /* Jul 2024 added if condition*/
            if (articlefile != null)
            {
                articlefile = articlefile.Replace(".jpg", ".link");
                articlefile = articlefile.Replace(".jpeg", ".link");
                articlefile = articlefile.Replace(".png", ".link");
                articlefile = articlefile.Replace(".htm", ".link");
                articlefile = articlefile.Replace(".txt", ".link");
                articlefile = articlefile.Replace(".aspx", ".link");
                articlefile = articlefile.Replace(".JPG", ".link");
                articlefile = articlefile.Replace(".JPEG", ".link");
                articlefile = articlefile.Replace(".PNG", ".link");
                articlefile = articlefile.Replace(".HTM", ".link");
                articlefile = articlefile.Replace(".TXT", ".link");
                articlefile = articlefile.Replace(".ASPX", ".link");
                articlefile = articlefile.Replace(".imagelist", ".link");
                articlefile = articlefile.Replace(".list", ".link");
                articlefile = articlefile.Replace(".title", ".link");
                articlefile = articlefile.Replace(".comments", ".link");
                articlefile = articlefile.Replace(".articlelist", ".link");
                articlefile = articlefile.Replace(".articleslist", ".link");

            }



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
        /* 2023 May 20 Uppercase */
        public static string Capitalize(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }
            // error return $"{char.ToUpper(input[0])}{input[1..]}";
            return $"{input[0].ToString().ToUpper()}{input.Substring(1)}";
        }
        public static DataTable GetArticleLinks(string inputdir, string computerpath, string siteurl)
        {
            string fullpath;
            DataTable dt = LinkTable();
            if (Directory.Exists(inputdir))
            {
                if (inputdir != null)
                {

                   
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

                            /* 2023 May 20 Uppercase */
                            name = Capitalize(name);

                            fullpath = path.Replace(computerpath, siteurl);
                           
                            fullpath = fullpath.Replace(@"\", @"/");  // Apr4 replace backslash with forward slash   

                            //            Response.Write ("File name is =" + path + "<br/>" +  computerpath + " <br/> " +  Global.Siteurl);

                            if ((extension.ToLower() == ".html") || (extension.ToLower() == ".aspx"))   // later add .php here
                            // 2022 added pdf and ppt if ((extension.ToLower() == ".html") || (extension.ToLower() == ".aspx") || (extension.ToLower() == ".pdf"))  // later add .php here
                            {
                                if ((name.ToLower() != "index") && (name.ToLower() != "default") && (name.ToLower() != "home") && (name.ToLower() != "privacypolicy"))  // add privacy policy in master file
                                {
                                    string pageTitle =null, pageKeywords = null, pageDescription = null; 
                                    PageMetaData(path, null, ref pageTitle, ref pageKeywords, ref pageDescription);
                                   // ReadDescription(inputdir + name, ref description);
                                    dt.Rows.Add(i, fullpath, name, pageTitle, pageKeywords, pageDescription);
                                    //      Response.Write ("name is = ~/" + name + extension + "<br/>" );
                                    // dt.Rows.Add(i, "~/" + name + extension, name);
                                    i++;
                                }



                               
                            }




                        }




                    }  // for




                    


                }  // if
            }

            return dt;

        }


        public static DataTable GetArticleLinks(string inputdir, string computerpath, string siteurl, int count)
        {
            string fullpath;
            DataTable dt = LinkTable();
            if (Directory.Exists(inputdir))
            {
                if (inputdir != null)
                {



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

                            /* 2023 May 20 Uppercase */
                            name = Capitalize(name);

                            fullpath = path.Replace(computerpath, siteurl);
                          
                            fullpath = fullpath.Replace(@"\", @"/");  // Apr4 replace backslash with forward slash   
                           
                            //            Response.Write ("File name is =" + path + "<br/>" +  computerpath + " <br/> " +  Global.Siteurl);

                            if ((extension.ToLower() == ".html") || (extension.ToLower() == ".aspx"))   // later add php her
                            {
                                if ((name.ToLower() != "index") && (name.ToLower() != "default") && (name.ToLower() != "home") && (name.ToLower() != "privacypolicy"))
                                {
                                    string pageTitle = null, pageKeywords = null, pageDescription = null;
                                    PageMetaData(path, null, ref pageTitle, ref pageKeywords, ref pageDescription);
                                    // ReadDescription(inputdir + name, ref description);
                                    dt.Rows.Add(i, fullpath, name, pageTitle, pageKeywords, pageDescription);
                                    //      Response.Write ("name is = ~/" + name + extension + "<br/>" );
                                    // dt.Rows.Add(i, "~/" + name + extension, name);
                                    i++;
                                }




                            }

                            if (i >= count)
                                break;


                        }




                    }  // for







                }  // if
            }

            return dt;

        }
        public static DataTable GetArticleLinks(string inputdir, string computerpath, string siteurl, int count, int length)
        {
            string fullpath;
            DataTable dt = LinkTable();
            if (Directory.Exists(inputdir))
            {
                if (inputdir != null)
                {



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
                            MakeString(ref name, length);

                            /* 2023 May 20 Uppercase */
                            name = Capitalize(name);

                            extension = System.IO.Path.GetExtension(path);

                            fullpath = path.Replace(computerpath, siteurl);
                         
                            fullpath = fullpath.Replace(@"\", @"/");  // Apr4 replace backslash with forward slash   
                           
                            //            Response.Write ("File name is =" + path + "<br/>" +  computerpath + " <br/> " +  Global.Siteurl);

                            if ((extension.ToLower() == ".html") || (extension.ToLower() == ".aspx"))   // later add php her
                            {
                                if ((name.ToLower() != "index") && (name.ToLower() != "default") && (name.ToLower() != "home") && (name.ToLower() != "privacypolicy"))
                                {
                                    string pageTitle = null, pageKeywords = null, pageDescription = null;
                                    PageMetaData(path, null, ref pageTitle, ref pageKeywords, ref pageDescription);
                                    // ReadDescription(inputdir + name, ref description);
                                    dt.Rows.Add(i, fullpath, name, pageTitle, pageKeywords, pageDescription);
                                    //      Response.Write ("name is = ~/" + name + extension + "<br/>" );
                                    // dt.Rows.Add(i, "~/" + name + extension, name);
                                    i++;
                                }




                            }

                            if (i >= count)
                                break;


                        }




                    }  // for







                }  // if
            }

            return dt;

        }

        public static void MakeString(ref string  name, int length)
    {
        int namelength = name.Length;
        if (namelength > length)
        {
            name = name.Substring(0, length - 1);
        }
    }
        public static void ReadDescription(string path,  ref string  description)
    {
    }

        public static DataTable GetFolderLinks(string inputdir, string computerpath, string siteurl)
        {
            string fullpath;
            DataTable dt = LinkTable();
            if (inputdir != null)
            {


                
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

                        fullpath = path.Replace(computerpath, siteurl);
                        fullpath = fullpath.Replace(@"\", @"/");  // Apr4 replace backslash with forward slash   
                        //   Response.Write ("Full path is =" + fullpath + "<br/>");

                        if (extension.ToLower() == ".html")
                        {
                            if (name.ToLower() != "index")
                            {
                                dt.Rows.Add(i, fullpath, name);
                            }



                            i++;
                        }




                    }




                }  // for




              


            }  // if

            return dt;

        }


        public static DataTable  GetDirectoryLinks(string inputdir, string computerpath, string siteurl)
        {
            string fullpath;
            DataTable dt = LinkTable();
            if (inputdir != null)
            {


           

                dt.Rows.Add(0, siteurl, "Home");

                DirectoryInfo dInfo = new DirectoryInfo(inputdir);
                int i = 1;
                foreach (DirectoryInfo subdi in dInfo.GetDirectories())
                {
                    string path;
                    path = GetDefaultFile(inputdir + subdi.Name.ToString());
                //    path = inputdir + subdi.Name.ToString() + @"\" + "index.html";

                  

                    string url;
                    string name;


                    if (File.Exists(path))
                    {
                        // This path is a file

                        url = System.IO.Path.GetFileName(path);
                        // name = System.IO.Path.GetFileNameWithoutExtension(path);
                        name = subdi.Name.ToString();
                        // extension = System.IO.Path.GetExtension(path);

                        /* 2023 May 20 Uppercase */
                        name = Capitalize(name);


                        string locpath = inputdir + subdi.Name.ToString() + @"/";   // Apr4
                        //      Response.Write("Path = " + locpath + "," + sitepath + "<br/>");
                        fullpath = locpath.Replace(computerpath, siteurl);
                       
                        fullpath = fullpath.Replace(@"\", @"/");  // Apr4 replace backslash with forward slash  
                        
                        //   Response.Write ("Full path is =" + fullpath + "<br/>");
                        string cleanname = name;
                        KreateWebsites.Generate.ReplaceStr(ref cleanname, '-', ' ');

                        dt.Rows.Add(i, fullpath, cleanname);


                         i++;


                    }
                   

                       
              

                }  // for




            


            }  // if

            return dt;

        }


        public static DataTable GetDirectoryLinks(string inputdir, string computerpath, string siteurl, int count)
        {
            string fullpath;
            DataTable dt = LinkTable();
            if (inputdir != null)
            {




                dt.Rows.Add(0, siteurl, "Home");

                DirectoryInfo dInfo = new DirectoryInfo(inputdir);
                int i = 1;
                foreach (DirectoryInfo subdi in dInfo.GetDirectories())
                {
                    string path;
                    path = GetDefaultFile(inputdir + subdi.Name.ToString());
                    //    path = inputdir + subdi.Name.ToString() + @"\" + "index.html";



                    string url;
                    string name;


                    if (File.Exists(path))
                    {
                        // This path is a file

                        url = System.IO.Path.GetFileName(path);
                        // name = System.IO.Path.GetFileNameWithoutExtension(path);
                        name = subdi.Name.ToString();
                        // extension = System.IO.Path.GetExtension(path);

                        /* 2023 May 20 Uppercase */
                        name = Capitalize(name);


                        string locpath = inputdir + subdi.Name.ToString() + @"/";   //Apr4
                        //      Response.Write("Path = " + locpath + "," + sitepath + "<br/>");
                        fullpath = locpath.Replace(computerpath, siteurl);
                        fullpath = fullpath.Replace(@"\", @"/");  // Apr4 replace backslash with forward slash  
                        //   Response.Write ("Full path is =" + fullpath + "<br/>");
                        string cleanname = name;
                        KreateWebsites.Generate.ReplaceStr(ref cleanname, '-', ' ');

                        dt.Rows.Add(i, fullpath, cleanname);


                        i++;
                        if (i == count) 
                        break;

                    }





                }  // for







            }  // if

            return dt;

        }

        public  static string  GetDefaultFile(string dirpath)
        {
            string path;
            Generate.kreatelog(" getfilepath = " + dirpath);

            path = dirpath + @"\" + "index.html";

            if (File.Exists(path))
            {
                return path;

            }


            path = dirpath + @"\" + "default.htm";

            if (File.Exists(path))
            {
                return path;

            }

            path = dirpath + @"\" + "default.aspx";

            if (File.Exists(path))
            {
                return path;

            }

          
            path = dirpath + @"\" + "index.htm";

            if (File.Exists(path))
            {
                return path;

            }

            return null;

        }
        public static DataTable GetSiteLinks(string inputdir, string computerpath, string siteurl)
        {
            string fullpath;
            string parentdir = inputdir;
            DataTable dt = LinkTable2();
            if (inputdir != null)
            {




                dt.Rows.Add(0, siteurl, "Home");

                DirectoryInfo dInfo = new DirectoryInfo(inputdir);
                int i = 1;
                foreach (DirectoryInfo subdi in dInfo.GetDirectories())
                {
                    string path;
                  // test test  path = inputdir + subdi.Name.ToString() + @"\" + "index.html";

                    path = GetDefaultFile(inputdir + subdi.Name.ToString());

                    parentdir = inputdir + subdi.Name.ToString();
                    //  Response.Write("Path = " + inputdir + subdi.Name.ToString() + "<br/>");

                    //System.Web.HttpResponse.("path is ");

                    string url;
                    string name;


                 if (File.Exists(path))
                 //                if (path != null)  as GetDefaultfile return null
                    {
                        // This path is a file

                        url = System.IO.Path.GetFileName(path);
                        // name = System.IO.Path.GetFileNameWithoutExtension(path);
                        name = subdi.Name.ToString();
                        // extension = System.IO.Path.GetExtension(path);
                        string locpath = inputdir + subdi.Name.ToString() + @"/";   //Apr4
                        //      Response.Write("Path = " + locpath + "," + sitepath + "<br/>");
                        fullpath = locpath.Replace(computerpath, siteurl);
                        fullpath = fullpath.Replace(@"\", @"/");  // Apr4 replace backslash with forward slash  
                        //   Response.Write ("Full path is =" + fullpath + "<br/>");
                        string cleanname = name;
                        KreateWebsites.Generate.ReplaceStr(ref cleanname, '-', ' ');

                        dt.Rows.Add(i, fullpath, cleanname, 0);




                        i++;

                        

                        string[] fileEntries = Directory.GetFiles(parentdir);

                        foreach (string path2 in fileEntries)
                        {



                           

                            string url2;
                            string name2;
                            string extension2;
                            string fullpath2;

                            if (File.Exists(path2))
                            {
                                // This path is a file

                                url2 = System.IO.Path.GetFileName(path2);
                                name2 = System.IO.Path.GetFileNameWithoutExtension(path2);
                                extension2 = System.IO.Path.GetExtension(path2);

                                fullpath2 = path2.Replace(computerpath, siteurl);
                                fullpath2 = fullpath2.Replace(@"\", @"/");  // Apr4 replace backslash with forward slash  
                                //            Response.Write ("File name is =" + path + "<br/>" +  computerpath + " <br/> " +  Global.Siteurl);

                                if ((extension2.ToLower() == ".html") || (extension2.ToLower() == ".aspx"))
                                {
                                    if ((name2.ToLower() != "index") && (name2.ToLower() != "default") && (name2.ToLower() != "privacypolicy"))
                                    {
                                        dt.Rows.Add(i, fullpath2, name2,1);
                                        //      Response.Write ("name is = ~/" + name + extension + "<br/>" );
                                        // dt.Rows.Add(i, "~/" + name + extension, name);
                                    }



                                    i++;
                                }




                            }




                        }  // for





                    }




                }  // for



              



            }  // if

            return dt;

        }

        public static string GetUrl(string locpath, string computerpath, string siteurl,  ref string pageUrl,  ref string folderUrl)
        {
            
        

            folderUrl = locpath.Replace(computerpath, siteurl);  // returns url of parent folder
            pageUrl = pageUrl.Replace(computerpath, siteurl);
            folderUrl = folderUrl.Replace(@"\", @"/");  // replace backslash with forward slash         
            pageUrl = pageUrl.Replace(@"\", @"/");  // replace backslash with forward slash       
            
            return folderUrl;

        }
    }
}






