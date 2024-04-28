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
    protected string district = null;
    protected string bank = null;
    protected string branch = null;
    protected string ifsc_code = null ;
    protected string micr_code=null ;
    // protected string category = Global.Category;
   
    protected int count = 1;
    protected int sortOrder = 2;  // sort by mobile id in desc 
    protected int direction = 1;
    protected int spin = 1;
   
    protected int year;
    protected DateTime startdate;
    protected DateTime enddate;
    protected void Page_Load(object sender, EventArgs e)
    {
        GetVariables();
        GetData();

    }



    private void GetData()
    {
        
        
        
        DataTable dt ;
        dt = KreateWebsites.Finance.GetIFSCCode(bank,branch, city, district, state, ifsc_code,micr_code, count, sortOrder);
      //  dt = KreateWebsites.Electronics.GetMobiles(company, os, osversion, model, category, count, sortOrder, direction, spin);
      
          
        if (dt.Rows.Count > 0)
        {

            RepDetails.DataSource = dt;
            RepDetails.DataBind();


        }

        /*
        lblSite.Text = Global.Sitename;
        lblSite.NavigateUrl = Global.Siteurl;
        lblTitle.Text = Page.Title;
        lblTitle2.Text = "Mobile Phones for Diwali " + year.ToString();  */
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

        if (Request.QueryString["district"] != null)
        {
            district = Request.QueryString["district"];
            itemstovisit = statename;

        }


        if (Request.QueryString["branch"] != null)
        {
           branch = Request.QueryString["branch"];
            itemstovisit = statename;

        }

        if (Request.QueryString["bank"] != null)
        {
            bank = Request.QueryString["bank"];

        }
       


        if (Request.QueryString["count"] != null)
        {
            count = Convert.ToInt32(Request.QueryString["count"]);
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