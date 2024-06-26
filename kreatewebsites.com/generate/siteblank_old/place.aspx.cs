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
using System.Xml;
using System.Xml.Xsl;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;


public partial class Default : BasePage
{
    protected string placetype = "cities";
    protected string filename = "no.inc";
    protected string filename2 = "articles\\no.htm";

    protected string slide = "city.jpg";
    protected string placename = "";
    protected string slidestr = null;
    protected string slidename = null;


    protected string continent = Global.Continent.ToString();
    protected string country = Global.Country.ToString();
    protected string state = Global.State.ToString();
    protected string statename = Global.StateName.ToString();
    protected string city = Global.City.ToString();
    protected string category = Global.Category.ToString();
    protected string thumbnail_path = Global.thumbnailpath.ToString();
    protected string ImagePath = Global.ImagePath.ToString();
    protected string url = " ";
    protected string name = " ";

    protected int year;
    protected int count = 12;




    protected string subfolder;
    protected int pictureid = 0;

    protected string local_path;
    protected string navigate_path;
    protected string pic_path;
    protected string output_path;


    protected void Page_Load(object sender, EventArgs e)
    {
        GetVariables();
      //  placename = Request.QueryString["name"];

        Page.Title = Global.Sitename + "|" + "Best attractions  " + placename;
   


        HtmlMeta tag = new HtmlMeta();
        tag.Name = "description";
        tag.Content = Page.Title + " ." + Global.Sitename.ToString() + " has complete detail of " + placename + ". Use this  guide on " + placename + " tour to know address, when to visit, speciality and other information";
        Header.Controls.Add(tag);

        //slides();
       // Getcities();
        //Getplaces();
        GetData();
        Page.DataBind();


     
                      /*                        <asp:HyperLink ID="HyperLink2" runat="server" Text='<%#Eval("biz_name")%>' NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "biz_name", "http://www.uscitytrip.net/attractions.aspx?name={0}") %>' /> 
         
        */
    }

    private void GetVariables()
    {


        DateTime moment = DateTime.Now;


        // Year gets 1999. 
        int year = moment.Year;

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

        if (Request.QueryString["continent"] != null)
        {
            continent = Request.QueryString["continent"];

        }

        if (Request.QueryString["country"] != null)
        {
            country = Request.QueryString["country"];

        }

        if (Request.QueryString["state"] != null)
        {
            state = Request.QueryString["state"];

        }
        if (Request.QueryString["statename"] != null)
        {
            statename = Request.QueryString["state"];

        }

        if (Request.QueryString["city"] != null)
        {
            city = Request.QueryString["city"];

        }

        if (Request.QueryString["placename"] != null)
        {
            placename = Request.QueryString["placename"];

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


    private void slides()
    {
        

        if (File.Exists(LocalPath.SlidePath + country + ".jpg"))
        {
                 slidename = country;
        }
        if (File.Exists(LocalPath.SlidePath + state + ".jpg"))
        {
            slidename = state;
        }
        if (File.Exists(LocalPath.SlidePath + statename + ".jpg"))
        {
            slidename = statename;
        }
        if (File.Exists(LocalPath.SlidePath + city + ".jpg"))
        {
            slidename = city;
        }
        if (File.Exists(LocalPath.SlidePath + city + ".jpg"))
        {
            slidename = city;
        }

        else
            slidename = Global.Country.ToString();

        slide = Global.SlidePath + slidename + ".jpg";

    
        slidestr = "<img src='" + slide + "' width='1200' height='265' alt='image slide of " + slidename + "' />";


        /*

        slide =  "http://pictures.uscitytrip.net/banner/" + placename + ".jpg";
       
        slidestr = "<img src='" + slide + "' width='1200' height='265' alt='image slide of " + placename + "' />";

         */
        Label1.Text = Page.Title;


    }

    private void featuredCountry()
    {

        
    }

    

   

    private void GetData()
    {

      //  labeltitle.Text = Page.Title;
        string sp = "tourist_detail";

      
        string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;

 
        using (SqlConnection conn = new SqlConnection(connect))
        {

            using (SqlCommand cmd = new SqlCommand(sp, conn))
            {

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Country", country);
                cmd.Parameters.AddWithValue("@name", placename);
      

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                da.Fill(ds);


                DataTable dt = ds.Tables[0];

                if (dt.Rows.Count > 0)
                {

                    RepDetails.DataSource = dt;
                    RepDetails.DataBind();
                }



                

                //  conn.Open();

                //    cmd.ExecuteNonQuery();



            }
        }
    }
}
