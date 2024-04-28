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
using System.IO;

public partial class Photos : BasePage
{

    protected static string country = Global.Country;
    protected static string state = Global.State;
    protected static string category = Global.Category;
    protected static string thumbnail_path = Global.thumbnailpath;
    protected static string ImagePath = Global.ImagePath;
    protected string url = " ";
    protected string name = " ";
    protected string pageTitle = null, pageKeywords = null, pageDescription = null;

    protected int year;
    protected int count = 3;

   

    protected static string subfolder;
    protected int pictureid = 0;

    protected string local_path;
    protected string navigate_path;
    protected string pic_path;
    protected string output_path;

    protected string articlefile = " ";
 //   protected static string thumbnail_path = KreateWebsites.Common.Pictures.thumbnailpath;

 //   protected static string ImagePath = KreateWebsites.Common.ImagePath;
    protected static string continent = Global.Continent;

    protected static string statename = Global.StateName;
    protected static string city = Global.City;

    protected static string subcategory = Global.SubCategory;
    protected static string title2;
    protected static string text;


    protected void Page_Load(object sender, EventArgs e)
    {



        GetVariables();
        name = Request.QueryString["name"];
        url = Request.QueryString["url"];   // new
        
        labeltext.Text = null;
        articlefile = Request.QueryString["url"]; 
      //  replaceextension(url,ref articlefile, @".imagelist", @".articleslist");
        articlefile  = url.Replace("imagelist", "articleslist");
   //     articlefile = url.   replace extention with .articleslist;
   //     replaceextension(url, ".imagelist", "articleslist");
        Response.Write("Get data = " + articlefile + "," + local_path + subfolder + "," + name);
        GetData(local_path + subfolder, articlefile);
    // fix it    GetCommentsData(local_path + subfolder);  //get comentslist  gallery.articleslist  gallery.commentslist
        string link = null;
  
        KreateWebsites.Page.PageLink(articlefile, ref link);
        if (link != null)
        {

           labeltext.Text = labeltext.Text + link;
        }

        MetaData();

        title.Text = Page.Title;

    
       
    }

    protected void MetaData()
    {


        pageTitle = "Photo list and gallery of " + subfolder;
         

            KreateWebsites.Page.PageMetaData(articlefile, name, ref pageTitle, ref pageKeywords, ref pageDescription);
            Page.Title = pageTitle;



            if (pageDescription != null)
            {

                HtmlMeta tag = new HtmlMeta();
                tag.Name = "description";
                tag.Content = pageDescription;

                Header.Controls.Add(tag);

            }
            if (pageKeywords != null)
            {

                HtmlMeta tag = new HtmlMeta();
                tag.Name = "keywords";
                tag.Content = pageKeywords;

                Header.Controls.Add(tag);

            }
       
    }

    private void GetVariables()
    {


        DateTime moment = DateTime.Now;


        // Year gets 1999. 
        year = moment.Year;

        // Month gets 1 (January). 
        int month = moment.Month;

        // Day gets 13. 
        int day = moment.Day;

        // Hour gets 3. 
        int hour = moment.Hour;

        // Minute gets 57. 
        int minute = moment.Minute;

        // Second gets 32. 
        int second = moment.Second;

        // Millisecond gets 11. 
        int millisecond = moment.Millisecond;

        if (Request.QueryString["id"] != null)
        {
            pictureid = Convert.ToInt32(Request.QueryString["id"]);

        }



        if (Request.QueryString["country"] != null)
        {
            country = Request.QueryString["country"];

        }

        if (Request.QueryString["state"] != null)
        {
            state = Request.QueryString["state"];

        }

        if (Request.QueryString["year"] != null)
        {
            year = Convert.ToInt16(Request.QueryString["year"]);

        }

        if (Request.QueryString["category"] != null)
        {
            category = Request.QueryString["category"];

        }

        if (Request.QueryString["count"] != null)
        {
            count = Convert.ToInt16(Request.QueryString["count"]);
        }
        if (Request.QueryString["subfolder"] != null)
        {
            subfolder = Request.QueryString["subfolder"];
        }

        if (Request.QueryString["local_path"] != null)
        {
            local_path = Request.QueryString["local_path"];
        }
        if (Request.QueryString["pic_path"] != null)
        {
            pic_path = Request.QueryString["pic_path"];
        }
        if (Request.QueryString["navigate_path"] != null)
        {
            navigate_path = Request.QueryString["navigate_path"];
        }

        if (Request.QueryString["output_path"] != null)
        {
            output_path = Request.QueryString["output_path"];
        }

    }
   



  

    private void GetData(string inputdir, string articlefile)
    {
      //  articlefile = inputdir + @"\" + Global.Pictures.pages;

        DataTable dt;
        string comments = null;
        string commentfile = articlefile+ @".comments";

       Response.Write("Get data = " + articlefile + "," + inputdir + "," + name);
       dt = GetData2(articlefile, inputdir, name);
     /*   
        dt = KreateWebsites.Images.GetData(articlefile, inputdir,name);

        GetColumnCount(ref count, inputdir, name);

        if (dt.Rows.Count > 0)
        {


            RepDetails.RepeatColumns = count;
            RepDetails.RepeatDirection = RepeatDirection.Horizontal;
            RepDetails.DataSource = dt;
            RepDetails.DataBind();



        }


        GetArticleData(articlefile + @".articlelist");
        PrintComments(articlefile, ref comments) ;



     labeltext.Text =  comments;


        string link = null;
        KreateWebsites.Page.PageLink(articlefile, ref link);
        if (link != null)
        {

         labeltext.Text = labeltext.Text + link;
        }

    
        setslide(subfolder);
      * */

    }

    private void setslide(string subfolder)
    {
        
    }



    private void PrintComments(string articlefile, ref string  comments)
    {

        KreateWebsites.Photos.GetImageComments(articlefile, ref comments);

    }

    private void GetArticleData(string filename)
    {




        // DataTable dt = GetTable(inputdir);
        DataTable dt = KreateWebsites.Articles.GetListData(filename);

        if (dt.Rows.Count > 0)
        {

            //     Response.Write("Count is " + dt.Rows.Count.ToString());

            RepComments.DataSource = dt;
            RepComments.DataBind();



        }





    }

    private void GetColumnCount(ref int count, string inputdir, string name)
    {
        count = Global.Gallery.gallerycount;

        if (File.Exists(inputdir + @"\images.count"))
        {
            string countstr = System.IO.File.ReadAllText(inputdir + @"\images.count");
            count = Convert.ToInt32(countstr);

        }

        if (File.Exists(inputdir + @"\" + name + @".count"))
        {
            string countstr = System.IO.File.ReadAllText(inputdir + @"\" + name + @".count");
            count = Convert.ToInt32(countstr);

        }
        //  direction = RepeatDirection.Horizontal;

    }
    private void GetCommentsData(string filename)
    {




        // DataTable dt = GetTable(inputdir);
        DataTable dt = KreateWebsites.Articles.GetListData(filename);

        if (dt.Rows.Count > 0)
        {

            //     Response.Write("Count is " + dt.Rows.Count.ToString());

            RepComments.DataSource = dt;
            RepComments.DataBind();



        }





    }

    protected static void replaceextension(string path, ref string  path_new, string ext_old, string ext_new)
    {
       // string url1, name1, extension1,path1;
        
        //   Response.Write("path = " + path + "," + path_new);
     //   path_new = path.Replace(ext_old, ext_new);
        /*    
            path1 = System.IO.Path.GetFullPath(path);
            url1 = System.IO.Path.GetFileName(path);
            name1 = System.IO.Path.GetFileNameWithoutExtension(path);
            extension1 = System.IO.Path.GetExtension(path);
         * 

            Response.Write("url1 = " + url1 + "," + name1 + "," + extension1 + "," + path1);
         * */
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

    private  DataTable GetData2(string articlefile, string inputdir, string name)
    {


        string displayname;
        string alt = "photos";


        DataTable dt = GetTable();
        KreateWebsites.Images.GetImagePath(inputdir, name);
        KreateWebsites.Images.GetThumbnailPath(inputdir);//Jan 2016

        //   string[] fileEntries = Directory.GetFiles(inputdir);
        int i = 0;
        string url, imagefullurl = null, thumbnailurl = null;
        string navigateurl, navigateurl2 = null;

        bool pictures_individualpage = KreateWebsites.Common.Pictures.individualpage;



        KreateWebsites.Generate.kreatelog("in GetImageData articlefile =" + articlefile);
        //  This read pictures.list. or myfile.imagelist.  You can specify picture filename in this file.
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

                Response.Write("url and name = " + url + "," + name + "<br/>");

                KreateWebsites.Photos.GetImageFullUrl(ImagePath, url, thumbnail_path, ref imagefullurl, ref thumbnailurl); // later enable this test

                KreateWebsites.Generate.kreatelog("Imagefullurl " + imagefullurl);

                displayname = name;
                KreateWebsites.Photos.GetPictureAttributes(inputdir, name, ref text, ref displayname);
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
                navigateurl2 = KreateWebsites.Common.Pictures.defaultpath + KreateWebsites.Common.Gallery.photoviewer + @"?imageurl=" + imagefullurl; // Jan 2016

                KreateWebsites.Photos.GetAltTag(inputdir, @"pictures.keyword", imagefullurl, name, displayname, title2, continent, country, state, statename, city, category, subcategory, ref alt);
               
                Response.Write ("Error = " + "," + inputdir + "," + name + "," + url + "," +  navigateurl + "<br/>") ;
         //ERROR       KreateWebsites.Photos.GetPictureNavigateurl(inputdir, name, url, ref  navigateurl); //Jan 29 2016
                dt.Rows.Add(i, thumbnailurl, name, displayname, alt, imagefullurl, title2, text, continent, country, state, statename, city, category, subcategory, navigateurl, navigateurl2);
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
        KreateWebsites.Photos.setslide(subfolder);


        return dt;

    }
}
