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



    //  protected string festival = Global.Festival.ToString();
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
        GetVariables();
        GetData();
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


        pageTitle = "Greeting Card " + Request.QueryString["name"];

        KreateWebsites.Page.PageMetaData(articlefile, name, ref pageTitle, ref pageKeywords, ref pageDescription);
        Page.Title = pageTitle;

        /* 2023 */
        Page.MetaDescription = pageDescription;
        Page.MetaKeywords = pageKeywords;

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


        if (Request.QueryString["name"] != null)
            name = Request.QueryString["name"];

        imgMainImage.ImageUrl = imageurl;
        imgMainImage.AlternateText = name;


        articlefile = imageurl;  // imageurl has http://pictures...  it should be url
        articlefile = articlefile.Replace(".jpg", ".inc");
        articlefile = articlefile.Replace(".jpeg", ".inc");
        articlefile = articlefile.Replace(".JPG", ".inc");
        articlefile = articlefile.Replace(".JPEG", ".inc");
        articlefile = articlefile.Replace(".png", ".inc");
        articlefile = articlefile.Replace(".PNG", ".inc");

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

    
          pagecommentsfile = pagepath + @".comments";
          if (File.Exists(pagecommentsfile))
          {

              labeltext.Text = labeltext.Text + System.IO.File.ReadAllText(pagecommentsfile);
          }

          commentsfile = imagepath + @".comments";
          if (File.Exists(commentsfile))
          {

              labeltext.Text = labeltext.Text + System.IO.File.ReadAllText(commentsfile);
          }

          imagelinkfile = imagepath + @".link";
          if (File.Exists(imagelinkfile))
          {

              labeltext.Text = labeltext.Text + System.IO.File.ReadAllText(imagelinkfile);
          }

          pagelinkfile = pagepath + @".link";
          if (File.Exists(pagelinkfile))
          {

              labeltext.Text = labeltext.Text + System.IO.File.ReadAllText(pagelinkfile);
          }


        lblslide.Text = name;
      //  hypslide.Text = "All slides";
     //   hypslide.NavigateUrl = "slides.html";
        hypslide.Text = "Home";
        hypslide.NavigateUrl = "https://www.kreatewebsites.com/";


    }


    private void SharePage()
    {
      //  pageUrl = KreateWebsites.Page.GetUrl(Request.QueryString["output_path"], LocalPath.ComputerPath, Global.Siteurl, pageUrl, folderUrl);

        pageUrl = Request.QueryString["output_url"];
       folderUrl = Request.QueryString["output_path"];
       folderUrl = KreateWebsites.Page.GetUrl(Request.QueryString["output_path"], LocalPath.ComputerPath, Global.Siteurl, ref pageUrl, ref folderUrl);

        hyperEmail.Text = "Email this card";
        string subject = Page.Title;
        string body = "Here is your greeting card " + pageUrl;
        hyperEmail.NavigateUrl = "mailto:someone@example.com?Subject=" + subject + "&body=" + body;


    }


}
