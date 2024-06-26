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
    protected string name = "Slides";
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
     
     //   Response.Write(local_path + subfolder + "<br/>");
       GetData(local_path + subfolder);
       articlefile = local_path + subfolder + @"\" + Global.SlidesPage;
        MetaData();

        title.Text = Page.Title;

        //  GetArticleLinks(output_path + subfolder);

        //   GetData2(Mainfolder, subfolder);


        //  GetArticleLinks(output_path + subfolder);

        //   GetData2(Mainfolder, subfolder);

        /* 2023 */
        try
        {
           metadesc.Text = Page.MetaDescription;
        }
        catch { }



    }

    protected void MetaData()
    {


        pageTitle = "Slides of " + subfolder;


        KreateWebsites.Page.PageMetaData(articlefile, name, ref pageTitle, ref pageKeywords, ref pageDescription);
        Page.Title = pageTitle;
        /* it create , add to entry define in masterpage */
        Page.MetaDescription = pageDescription;
        Page.MetaKeywords = pageKeywords;


        /* duplicate entry */
        /* if existing tags are not there in master page then this will work*/
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
        DataTable dt;
        dt = KreateWebsites.Slides.GetData(inputdir);

        //DataTable dt = KreateWebsites.Photos.GetData(inputdir);
        GetColumnCount(ref count, inputdir);


        if (dt.Rows.Count > 0)
        {

            //     Response.Write("Count is " + dt.Rows.Count.ToString());

            RepDetails.RepeatColumns = count;
            RepDetails.RepeatDirection = RepeatDirection.Horizontal;

            RepDetails.DataSource = dt;
            RepDetails.DataBind();



        }



    }



    private void GetColumnCount(ref int count, string inputdir)
    {
        count = Global.Pictures.picturescount;
        //  Response.Write("input dir is " + inputdir);
        if (File.Exists(inputdir + @"\slides.count"))
        {
            string countstr = System.IO.File.ReadAllText(inputdir + @"\slides.count");
            count = Convert.ToInt32(countstr);
            //     Response.Write("count " + count.ToString());

        }
        //  direction = RepeatDirection.Horizontal;

    }





}
