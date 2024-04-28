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

public partial class Article : BasePage
{



    //  protected string festival = Global.Festival.ToString();
    protected string country = Global.Country;
    protected string state = Global.State;
    protected string category = Global.Category.ToString();
    protected string imageurl = "http://pictures.placetosee.net/places/defaultimg.jpg";
    protected string defaultimage = "http://pictures.beautifulsite.or/places/defaultimg.jpg";
    protected string ImagePath = Global.ImagePath.ToString();
    protected string thumbnail_path = Global.thumbnailpath.ToString();
    protected string imagename = " ";

    protected int year;
    protected int count = 3;

    protected string subfolder;
    protected int pictureid = 0;

    protected string local_path;
    protected string navigate_path;
    protected string pic_path;
    protected string output_path;

    protected string articlefile;



    string name;

    protected string slide = "city.jpg";
    protected string slidename = "";
    protected string slidestr = null;


    protected void Page_Load(object sender, EventArgs e)
    {
        GetVariables();
        slides();
        GetData();
        MetaData();
       GetPictures(local_path + subfolder);
    }


    protected void MetaData()
    {



        if (File.Exists(articlefile + ".title"))
        {

            Page.Title = System.IO.File.ReadAllText(articlefile + ".title");

        }
        else
        {
         
            Page.Title = name;
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
            tag.Content =keywords;

            Header.Controls.Add(tag);

        }

    }


    private void GetVariables()
    {


        slidename = Global.Sitename;


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
    private void GetData()
    {
        

        if (Request.QueryString["Url"] != null)
            articlefile = Request.QueryString["Url"];





        if (Request.QueryString["name"] != null)
        {
            name = Request.QueryString["name"];

            KreateWebsites.Generate.CleanStr(ref name);
        }

        if (Request.QueryString["name"] != null)
            imagename = Request.QueryString["name"];

        if (File.Exists(articlefile))
        {
            //     labeltext.Text = labeltext.Text + " File found ";
            labeltext.Text = System.IO.File.ReadAllText(articlefile);
        }

    //    lblTitle.Text = Page.Title;


/*
     imageurl = articlefile;
       imageurl = imageurl.Replace(".txt", ".jpg");



        if (File.Exists(imageurl))
        {

            imgMainImage.ImageUrl = imageurl;
        }
        else
            imgMainImage.ImageUrl = defaultimage;

*/

    }


    private void slides()
    {


       // Response.Write("Slide name = " + LocalPath.ImagePath + name + ".jpg");

        if (File.Exists(LocalPath.ImagePath+name+".jpg"))
            slidename = name;
     
        slide = Global.SlidePath + slidename + ".jpg";
        slidestr = "<img src='" + slide + "' width='1200' height='265' alt='slide of " + slidename + "' />";


    //    lblslide.Text = slidename;
    //    hypslide.Text = "See Pictures";
    //    hypslide.NavigateUrl = "pictures.html";

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
        if (File.Exists(inputdir + @"\pictures.path"))
        {
            string str = System.IO.File.ReadAllText(inputdir + @"\pictures.path");

            ImagePath = str.TrimEnd('\r', '\n');  // This will remove any combination of carriage returns and newlines from 

        }
    }



    private void GetPictures(string inputdir)
    {

       

        DataTable dt = GetTable(inputdir);
      GetImagePath(inputdir);


        int i = 0;
        string url, imagefullurl;

     //    Response.Write("inputdir = " + inputdir + "<br/>" );

        
        //  This read image files from directory.     


        //  This read pictures.list. You can specify picture filename in this file.
        string filename = Request.QueryString["name"];
        if (File.Exists(inputdir + @"\" + filename + ".list"))
        {
           

            System.IO.StreamReader file =
               new System.IO.StreamReader(inputdir + @"\" + filename + ".list" );
            while ((url = file.ReadLine()) != null)
            {
                name = url; // remove .jpg

                name = name.Replace(".jpg", "");
                name = name.Replace(".jpeg", "");
                name = name.Replace(".png", "");
                name = name.Replace(".JPG", "");
                name = name.Replace(".JPEG", "");
                name = name.Replace(".PNG", "");
                imagefullurl = ImagePath + thumbnail_path + url;  // specify full url in .list file does not allow thembinail
                
            //    Response.Write("name = " + name + "<br/>" + url);
                dt.Rows.Add(i, imagefullurl, name);
                i++;
            }

            file.Close();


        }



        if (dt.Rows.Count > 0)
        {

            //     Response.Write("Count is " + dt.Rows.Count.ToString());

      //      RepDetails.DataSource = dt;
      //      RepDetails.DataBind();



        }

       

 

    }


}
