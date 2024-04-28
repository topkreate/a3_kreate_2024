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

    protected string country = Global.Country;
    protected string state = Global.State;
    protected string category = Global.Category;
    protected string thumbnail_path = Global.thumbnailpath;
    protected string ImagePath = Global.ImagePath;
    protected string url = " ";
    protected string name = " ";
    protected string pageTitle = null, pageKeywords = null, pageDescription = null;

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
    
       GetData(local_path + subfolder);
        articlefile = local_path + subfolder + @"\" + Global.Gallery.pages;
        MetaData();

     // Dec 2020  title.Text = Page.Title;

        string inputdir = Request.QueryString["local_path"] +   Request.QueryString["subfolder"]  ;
    //    Response.Write("Gallery comment = " + inputdir + @"\gallery.comments");
        if (File.Exists(inputdir + @"\gallery.comments"))
        {

             labeltext.Text = labeltext.Text + System.IO.File.ReadAllText(inputdir + @"\gallery.comments");
        }
        GetCommentsData(local_path + subfolder);  //get comentslist  gallery.articleslist  gallery.commentslist
        string link = null;
        KreateWebsites.Page.PageLink(articlefile, ref link);
        if (link != null)
        {

            labeltext.Text = labeltext.Text + link;
        }

        /* 2023 */
        try
        {
            metadesc.Text = Page.MetaDescription;
        }
        catch { }

    }
    protected void MetaData()
    {


        pageTitle = "Gallery of " + subfolder;
        name = pageTitle;


        KreateWebsites.Page.PageMetaData(articlefile, name, ref pageTitle, ref pageKeywords, ref pageDescription);
        Page.Title = pageTitle;
        /* it create , add to entry define in masterpage */
        Page.MetaDescription = pageDescription;
        Page.MetaKeywords = pageKeywords;


        /* 2023 *
        /*
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
        */

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




  

    private void GetData(string inputdir)
    {


        int count=Global.Gallery.gallerycount;
        DataTable dt = KreateWebsites.Gallery.GetData(inputdir);

        GetColumnCount(ref count, inputdir);

        if (dt.Rows.Count > 0)
        {


            RepDetails.RepeatColumns = count;
            RepDetails.RepeatDirection = RepeatDirection.Horizontal;
            RepDetails.DataSource = dt;
            RepDetails.DataBind();



        }


        setslide(subfolder);

    }

    private void GetArticlesHyp(string inputdir)
    {



   

    }

    private void setslide(string subfolder)
    {
       
    }




    private void GetCommentsData(string inputdir)
    {
        

       

        // DataTable dt = GetTable(inputdir);
        DataTable dt = KreateWebsites.Articles.GetListData(inputdir, "gallery.articleslist");

        if (dt.Rows.Count > 0)
        {

            //     Response.Write("Count is " + dt.Rows.Count.ToString());

            RepComments.DataSource = dt;
            RepComments.DataBind();



        }





    }

   private void GetColumnCount (ref int count, string inputdir)
{
    count = Global.Gallery.gallerycount;

    if (File.Exists(inputdir + @"\gallery.count"))
    {
        string countstr = System.IO.File.ReadAllText(inputdir + @"\gallery.count");
        count = Convert.ToInt32(countstr);

      }
 //  direction = RepeatDirection.Horizontal;

}


}
