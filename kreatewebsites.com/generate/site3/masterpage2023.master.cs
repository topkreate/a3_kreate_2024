using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class Master : System.Web.UI.MasterPage
{


    //  protected string festival = Global.Festival.ToString();
    protected string country = Global.Country;
    protected string state = Global.State;
    protected string category = Global.Category;
    protected string imageurl = "https://pictures.indiacitytrip.com/places/defaultimg.jpg";
    protected string defaultimage = "https://pictures.indiacitytrip.com/places/defaultimg.jpg";
    protected string imagename = " ";

    protected int year;
    protected int count = 3;
    protected string pageTitle = null, pageKeywords = null, pageDescription = null;


    protected int pictureid = 0;
    string articlefile;
    string name;

    protected void Page_Load(object sender, EventArgs e)
    {
        KreateWebsites.Page.PageMetaData(articlefile, name, ref pageTitle, ref pageKeywords, ref pageDescription);

        metadesc.Text = pageDescription;
        //Page.Title = pageTitle;

        //Page.MetaDescription = pageDescription;
        //Page.MetaKeywords = pageKeywords;
        /*  topheader.Text = Global.Sitename.ToString();
         topheader.NavigateUrl = Global.Siteurl.ToString(); */
        /* bettwr as header is encapsulated
        if (topheader != null)
        {
            topheader.Text = Page.Title;
        }
        //  topheader.NavigateUrl = Global.Siteurl.ToString(); 

        if (hyperlinkHome != null)
        {
            hyperlinkHome.Text = "Home";
            hyperlinkHome.NavigateUrl = Global.Siteurl.ToString();
        }

        */

    }

    protected void MetaData()
    {

        KreateWebsites.Page.PageMetaData(articlefile, name, ref pageTitle, ref pageKeywords, ref pageDescription);
        //Page.Title = pageTitle;

        //Page.MetaDescription = pageDescription;
        //Page.MetaKeywords = pageKeywords;

        
        /* Below is not  effective
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
}
