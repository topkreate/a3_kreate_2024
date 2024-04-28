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

    protected string country = Global.Country.ToString();
    protected string state = Global.State.ToString();
    protected string category = Global.Category.ToString();
    protected string thumbnail_path = Global.thumbnailpath.ToString();
    protected string ImagePath = Global.ImagePath.ToString();
    protected string url = " ";
    protected string name = " ";

    protected int year;
    protected int count = 3;

   

    protected string subfolder;
    protected int pictureid = 0;

    protected string local_path;
    protected string navigate_path;
    protected string pic_path;
    protected string output_path;

    protected string articlefile;
  

    protected void Page_Load(object sender, EventArgs e)
    {



        GetVariables();
     //   Response.Write(local_path + subfolder + "<br/>");
       GetData(local_path + subfolder);
        articlefile = local_path + subfolder + @"\" + Global.picpage;
        MetaData();

        lblTitle.Text = Page.Title;

      //  GetArticleLinks(output_path + subfolder);

        //   GetData2(Mainfolder, subfolder);
    
       
    }

    protected void MetaData()
    {


        //   Response.Write("article file : " + articlefile);
        if (File.Exists(articlefile + ".title"))
        {


            Page.Title = System.IO.File.ReadAllText(articlefile + ".title");

        }
        else
        {

            //  Page.Title = Request.QueryString["name"];
            Page.Title = "Slide of " + subfolder;   // Make this line similar to above so that GetMetaData is same  c
        }

        if (File.Exists(articlefile + ".desc"))
        {
            string desc;
            desc = System.IO.File.ReadAllText(articlefile + ".desc");

            HtmlMeta tag = new HtmlMeta();
            tag.Name = "description";
            tag.Content = desc;

            Header.Controls.Add(tag);

        }

        if (File.Exists(articlefile + ".keywords"))
        {
            string keywords;
            keywords = System.IO.File.ReadAllText(articlefile + ".keywords");

            HtmlMeta tag = new HtmlMeta();
            tag.Name = "keywords";
            tag.Content = keywords;

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
    static DataTable GetTable(string inputdir)
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

    public void GetImagePath(string inputdir)
    {

        

        // Default value of pictures path is t\aken from global. The value can be overriden by providing a value in file pictures.path 
        ImagePath = Global.ImagePath.ToString();
        if (File.Exists(inputdir + @"\slides.path"))
        {
            string str = System.IO.File.ReadAllText(inputdir + @"\slides.path");

            ImagePath = str.TrimEnd('\r', '\n');  // This will remove any combination of carriage returns and newlines from 
         
        }
    }

  

    private void GetData(string inputdir)
    {


        DataTable dt = GetTable(inputdir);
        GetImagePath(inputdir);
     

    
        int i = 0;
        string url, imagefullurl;

    //    Response.Write("inputdir = " + inputdir + "<br/>" );

        string[] fileEntries = Directory.GetFiles(inputdir);

        //  This read image files from directory. 
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
                    imagefullurl = ImagePath + thumbnail_path + url;
                    dt.Rows.Add(i, imagefullurl, name);
                }


                i++;

                if (extension.ToLower() == ".inc")
                {
                    labeltext.Text = labeltext.Text + System.IO.File.ReadAllText(path);
                }



            }
            else
            {
                Console.WriteLine("No rows found.");
            }




        }  // for



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
                imagefullurl = ImagePath + thumbnail_path + url;
              //  Response.Write("name = " + name + "<br/>" + url);
                dt.Rows.Add(i, imagefullurl, name);
            }

            file.Close();


        }



        if (dt.Rows.Count > 0)
        {

            //     Response.Write("Count is " + dt.Rows.Count.ToString());

            RepDetails.DataSource = dt;
            RepDetails.DataBind();



        }



        //   GetPhotoLinks(inputdir); This add jpg url
        setslide(subfolder);

    }

    private void setslide(string subfolder)
    {
        /*
        string slideurl = "https://pictures.indiacitytrip.com/slide3/" + subfolder + ".jpg";

        if (File.Exists(slideurl))
        {

            slide.ImageUrl = slideurl;
        }
        else
        {
            slide.ImageUrl = "https://pictures.indiacitytrip.com/slide3/" + "USA.jpg";
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


    private void GetArticleLinks(string inputdir)
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


}
