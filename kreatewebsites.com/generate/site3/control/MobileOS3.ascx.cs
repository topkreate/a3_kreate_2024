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
using System.Data.Sql;
using System.Data.SqlClient;




public partial class featured : System.Web.UI.UserControl
{


    protected String itemstovisit = "World";
    protected string continent = Global.Continent;
    protected string country = Global.Country;
    protected string state = Global.State;
    protected string statename = Global.StateName;
    protected string city = Global.City;
    // protected string category = Global.Category;
    protected string category = "All";
    protected string subcategory = Global.SubCategory;
    protected string company = "All";
    protected string os = "All";
    protected string model = "All";
    protected string osversion = "All";
    protected int count = 20;
    protected int sortOrder = 2;  // sort by mobile id in desc 
    protected int direction = 1;
    protected int spin = 1;
    protected string language = "Hindi";
    protected string name = "all";
    protected string actor = "all";
    protected string director = "all";
    protected string producer = "all";
    protected int year;
    protected DateTime startdate;
    protected DateTime enddate;
    protected void Page_Load(object sender, EventArgs e)
    {
        GetData();

    }



    private void GetData()
    {
        DataTable dt ;
      
       dt = KreateWebsites.Electronics.GetMobileOSList();
          
        if (dt.Rows.Count > 0)
        {

            RepDetails.DataSource = dt;
            RepDetails.DataBind();


        }

      
    }


    protected void GetVariables()
    {




        if (Request.QueryString["continent"] != null)
        {
            continent = Request.QueryString["continent"];
            itemstovisit = continent;
        }

        if (Request.QueryString["country"] != null)
        {
            country = Request.QueryString["country"];
            itemstovisit = country;

        }
        if (Request.QueryString["state"] != null)
        {
            state = Request.QueryString["state"];
            itemstovisit = state;

        }
        if (Request.QueryString["statename"] != null)
        {
            statename = Request.QueryString["statename"];
            itemstovisit = statename;

        }
        if (Request.QueryString["city"] != null)
        {
            city = Request.QueryString["city"];
            itemstovisit = statename;

        }

        if (Request.QueryString["category"] != null)
        {
            category = Request.QueryString["category"];
            itemstovisit = statename;

        }


        if (Request.QueryString["subcategory"] != null)
        {
            subcategory = Request.QueryString["subcategory"];
            itemstovisit = statename;

        }

        if (Request.QueryString["model"] != null)
        {
            model = Request.QueryString["model"];

        }
        if (Request.QueryString["company"] != null)
        {
            company = Request.QueryString["company"];

        }
        if (Request.QueryString["os"] != null)
        {
            os = Request.QueryString["os"];

        }
        if (Request.QueryString["osversion"] != null)
        {
            osversion = Request.QueryString["osversion"];

        }


        if (Request.QueryString["count"] != null)
        {
            count = Convert.ToInt32(Request.QueryString["count"]);
        }
        if (Request.QueryString["year"] != null)
        {
            year = Convert.ToInt32(Request.QueryString["year"]);
        }

        if (Request.QueryString["language"] != null)
        {
            language = Request.QueryString["language"];
        }






    }

 

    protected void GetDateTimeVariables()
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




        enddate = new DateTime(year, month, day);

        startdate = enddate.AddDays(-365);

    }

}