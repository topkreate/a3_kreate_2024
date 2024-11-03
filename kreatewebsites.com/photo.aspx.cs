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

public partial class Photo : BasePage
{


    protected string country = Global.Country;
    protected string state = Global.State;
    protected string category = Global.Category;
    protected string imageurl = " ";
    protected string name = " ";
    protected string pageTitle = null, pageKeywords = null, pageDescription = null, pageUrl = Global.Siteurl, folderUrl = Global.Siteurl;

    protected int year;
    protected int count = 3;


    protected int pictureid = 0;


    string articlefile, imagepath, pagepath;

    protected void Page_Load(object sender, EventArgs e)
    {
        //Response.Write("ttttttttttttt");
        GetVariables();
        GetData();
        articlefile = name;
        /* 2024 article file is overwritten with .inc */
        // Response.Write("Article file is ", articlefile);
        
        if (Request.QueryString["imageurl"] != null)
        {
            articlefile = Request.QueryString["imageurl"];
        }
        if (Request.QueryString["name"] != null)
        {
            name = Request.QueryString["name"];
        }
        string localurl = null;
        if (Request.QueryString["localurl"] != null)
        {
            localurl = Request.QueryString["localurl"];
        }

        string url = null;
        if (Request.QueryString["url"] != null)
        {
             url = Request.QueryString["url"];
        }

        articlefile = name; // write new metadata function
        articlefile = localurl;

        //string message1 = "article file is =" + articlefile;
        //string message2 = "name is =" + name;

        // string message1 = "localurl  is =" + localurl;
        // string message2 = "url is =" + url;
        // Response.Write(message1);
        // Response.Write(message2);
        
        MetaData();
        SharePage();

        /* 2023 */
        try
        {
            metadesc.Text = Page.MetaDescription;
        }
        catch { }


    }

    protected void MetaData()
    {


        pageTitle = "Photo " + Request.QueryString["name"];

        KreateWebsites.Page.PageMetaData(articlefile, name, ref pageTitle, ref pageKeywords, ref pageDescription);
        
        //Response.Write("page title =" + pageTitle);

        Page.Title = pageTitle;
        

        /* 2023 need to fill this programatically
        pageDescription = "Slides for ";
        pageKeywords = "Photos, pictures ";
        */


        Page.MetaDescription = pageDescription;
        Page.MetaKeywords = pageKeywords;

        title.Text = Page.Title;

        // Below is not effective
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

 
        GetCommentsData();  //get comentslist  gallery.articleslist  gallery.commentslist
        string link = null;
        KreateWebsites.Page.PageLink(articlefile, ref link);
        if (link != null)
        {

            
            labeltext.Text = labeltext.Text + link;
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

        if (Request.QueryString["imageurl"] != null)
        {
            articlefile = Request.QueryString["imageurl"];
        }
      
        if (Request.QueryString["url"] != null)
        {
            pagepath = Request.QueryString["url"];
        }
        if (Request.QueryString["localurl"] != null)
        {
            imagepath = Request.QueryString["localurl"];
        }

        if (Request.QueryString["name"] != null)
        {
         name = Request.QueryString["name"];
        }

    }
    private void GetData()
    {
        string articlefile;
        string commentsfile, pagecommentsfile;
        string imagelinkfile, pagelinkfile;

        commentsfile = imagepath + @".comments";
        if (Request.QueryString["ImageUrl"] != null)
            imageurl = Request.QueryString["ImageUrl"];


        

        imgMainImage.ImageUrl = imageurl;
        imgMainImage.AlternateText = name;
    
       imgMainImage.Width = 600;


        articlefile = imageurl;  // imageurl has http://pictures...  it should be url
        articlefile = articlefile.Replace(".jpg", ".inc");
        articlefile = articlefile.Replace(".jpeg", ".inc");
        articlefile = articlefile.Replace(".JPG", ".inc");
        articlefile = articlefile.Replace(".JPEG", ".inc");
        articlefile = articlefile.Replace(".png", ".inc");
        articlefile = articlefile.Replace(".PNG", ".inc");


     //   Response.Write("articlefile = " + articlefile);
     
     if (Request.QueryString["name"] != null)
        {
      //      name = Request.QueryString["name"];
       //     lblTitle.Text = name;
        }
        else
        {
   //         lblTitle.Text = articlefile;
        }

     
        if (File.Exists(articlefile))
        {
      
            labeltext.Text = labeltext.Text + System.IO.File.ReadAllText(articlefile);
        }

          // There are 2 comments  - page and image.   Pagepath and imagepath - if they are same
          pagecommentsfile = pagepath + @".comments";
          if (File.Exists(pagecommentsfile))
          {

              labeltext.Text = labeltext.Text + System.IO.File.ReadAllText(pagecommentsfile);
          }

          commentsfile = imagepath + @".comments";
          if (File.Exists(commentsfile))
          {

            // Duplicate comments.  As comment is repeater too in photo. either it should bot be repeater
            // labeltext.Text = labeltext.Text + System.IO.File.ReadAllText(commentsfile);
          }

          imagelinkfile = imagepath + @".link";
          if (File.Exists(imagelinkfile))
          {
            // Duplicate comments.  As comment is repeater too in photo. either it should bot be repeater
            labeltext.Text = labeltext.Text + System.IO.File.ReadAllText(imagelinkfile);
        }

        pagelinkfile = pagepath + @".link";
          if (File.Exists(pagelinkfile))
          {

              labeltext.Text = labeltext.Text + System.IO.File.ReadAllText(pagelinkfile);
          }
    }

    /* Fix this and make it configurable */
    private void SharePage()
    {

        pageUrl = Request.QueryString["output_url"];
       folderUrl = Request.QueryString["output_path"];

         folderUrl = KreateWebsites.Page.GetUrl(Request.QueryString["output_path"],LocalPath.ComputerPath, Global.Siteurl, ref pageUrl, ref folderUrl);

        /*
        hyperEmail.Text = "Email this Page";
        string subject = "Photo : " + Page.Title;
        string body = "Here is your Photo " + pageUrl + ". See more  at " +  folderUrl ;
        hyperEmail.NavigateUrl = "mailto:Type Email address ?Subject=" + subject + "&body=" + body;
        */


    }
    private void GetCommentsData()
    {


     //   string commentslist = Request.QueryString["output_path"] + Request.QueryString["name"] +  ".articleslist";
        string commentslist = Request.QueryString["localurl"] +  ".articleslist";

   //     Response.Write("commentlist = " + commentslist);
        // DataTable dt = GetTable(inputdir);
        DataTable dt = KreateWebsites.Articles.GetListData(commentslist);

        if (dt.Rows.Count > 0)
        {

            //     Response.Write("Count is " + dt.Rows.Count.ToString());

            RepComments.DataSource = dt;
            RepComments.DataBind();



        }





    }


}
