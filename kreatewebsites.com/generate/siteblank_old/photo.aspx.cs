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
    protected string country = Global.Country.ToString();
    protected string state = Global.State.ToString();
    protected string category = Global.Category.ToString();
    protected string imageurl = " ";
    protected string imagename = " ";

    protected int year;
    protected int count = 3;


    protected int pictureid = 0;


    string articlefile;

    protected void Page_Load(object sender, EventArgs e)
    {
        GetVariables();
        GetData();
        MetaData();



    }

    protected void MetaData()
    {


     //   Response.Write("In meta data " + articlefile + "<br/>");
        // not working on http, not working as local folder name is not given
        if (File.Exists(articlefile + ".title"))
        {

            Page.Title = System.IO.File.ReadAllText(articlefile + ".title");

        }
        else
        {

            Page.Title = Request.QueryString["name"];
        }

        if (File.Exists(articlefile + ".desc"))
        {
            string desc;
            desc = System.IO.File.ReadAllText(articlefile + ".desc");

            HtmlMeta tag = new HtmlMeta();
            tag.Name = "description";
            tag.Content = Page.Title + desc;

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

        if (Request.QueryString["imageurl"] != null)
        {
            articlefile = Request.QueryString["imageurl"];
        }


    }
    private void GetData()
    {
        string articlefile;

        if (Request.QueryString["ImageUrl"] != null)
            imageurl = Request.QueryString["ImageUrl"];


        if (Request.QueryString["name"] != null)
            imagename = Request.QueryString["name"];

        imgMainImage.ImageUrl = imageurl;

        articlefile = imageurl;
        articlefile = articlefile.Replace(".jpg", ".inc");
        articlefile = articlefile.Replace(".jpeg", ".inc");

      //  Response.Write(articlefile);

     //   labeltext.Text = articlefile;
        if (File.Exists(articlefile))
        {
       //     labeltext.Text = labeltext.Text + " File found ";
            labeltext.Text = labeltext.Text + System.IO.File.ReadAllText(articlefile);
        }




    }





}
