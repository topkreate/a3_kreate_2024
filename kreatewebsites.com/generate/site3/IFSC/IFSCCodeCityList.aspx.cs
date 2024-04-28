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
using System.Data;
using System.Data.SqlClient; 

public partial class Article : BasePage
{

    protected String itemstovisit = "World";
    protected string continent = null;
    protected string country = null;
    protected string state = null;
    protected string statename = null;
    protected string city = null;
    protected string district = null;
    protected string bank = null;
    protected string branch = null;
    protected string ifsc_code = null;
    protected string micr_code = null;
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
        
        GetPageMetaData();

      
    }




    private void GetData()
    {



        DataTable dt;
        dt = KreateWebsites.Finance.GetIFSCCode_city(bank, branch, city, district, state, ifsc_code, micr_code, count, sortOrder);
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
        itemstovisit = " ";

        if (Request.QueryString["bank"] != null)
        {
            bank = Request.QueryString["bank"];
            itemstovisit = bank;

        }

        if (Request.QueryString["branch"] != null)
        {
            branch = Request.QueryString["branch"];
            itemstovisit = itemstovisit + " " + branch; ;

        }


        if (Request.QueryString["city"] != null)
        {
            city = Request.QueryString["city"];
            itemstovisit = itemstovisit + city;

        }

        if (Request.QueryString["district"] != null)
        {
            district = Request.QueryString["district"];
            itemstovisit = itemstovisit + district;

        }

        
        if (Request.QueryString["state"] != null)
        {
            state = Request.QueryString["state"];
            itemstovisit = itemstovisit + state;

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

    private void GetPageMetaData()
    {

        Page.Title = "IFSC Code for Cities " + itemstovisit  ;
     //   lblTitle.Text = Page.Title;

    }
}
