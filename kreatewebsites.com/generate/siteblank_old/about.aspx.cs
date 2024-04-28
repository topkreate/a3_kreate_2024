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

public partial class About : BasePage
{
    protected string continent = Global.Continent.ToString();
    protected string country = Global.Country.ToString();
    protected string state = Global.State.ToString();
    protected string statename = Global.StateName.ToString();
    protected string city = Global.City.ToString();
    protected string category = Global.Category.ToString();
    protected string subcategory = Global.SubCategory.ToString();


    protected Int16 count = 50;
    protected Int16 SortOrder = 3;
    protected string filename = "no.inc";
    protected string filename2 = "articles\\no.htm";


    public string placename = null;
    protected string placetype = null;
    protected string slidename = Global.Country.ToString();
    protected string slidestr = null;
    protected string slide = null;
    protected string list = null;

    protected string name = Global.Country.ToString();

    protected void Page_Load(object sender, EventArgs e)
    {
        

      


        // slides();
        //   Getcities();
        //  GetCategories();
        Getplacename();
        Gettopic();

        hyperlinkMore.Text = Global.Keyword.ToString()  + " of " +  Global.Country.ToString();
        hyperlinkMore.NavigateUrl = "https://www.indiacitytrip.com/" ;
        // Page.Response.Write("usa");

        Page.Title = "About " + name;

        HtmlMeta tag = new HtmlMeta();
        tag.Name = "description";
        tag.Content = Page.Title + ". Know about " + placename + " - " + Global.list.ToString() + " Click to see complete list ";
        Header.Controls.Add(tag);
    }

    protected void Getplacename()
    {



       

        if (Request.QueryString["state"] != null)
        {
            placename = placename + Request.QueryString["state"] + " ";
            state = Request.QueryString["state"];
            name = state;
        }

        if (Request.QueryString["statename"] != null)
        {
            placename = placename + Request.QueryString["state"] + " ";
            state = Request.QueryString["statename"];
            name = state;

        }
        if (Request.QueryString["city"] != null)
        {
            placename = placename + Request.QueryString["city"] + " ";
            city = Request.QueryString["city"];
            name = city;
        }
        


        //   if (placename == null)
        //     placename = Global.Country.ToString();




        if (Request.QueryString["category"] != null)
        {
            placetype = placetype + Request.QueryString["category"] + " ";
        }


        if (Request.QueryString["subcategory"] != null)
        {
            placetype = placetype + Request.QueryString["subcategory"] + " ";
        }
    }
    private void Gettopic()
    {


        string sp = "tourist_details_search";

        string list = " ";



        // string connect = @"SERVER=yellpproduct.db.5284911.hostedresource.com;Database=yellpproduct;UID=yellpproduct;PWD=Dhingra732!@;Trusted_Connection=False;";
        string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;

        //   string connect = "<%$ ConnectionStrings:films %>" ;
        //     ConnectionString="<%$ ConnectionStrings:films %>"
        using (SqlConnection conn = new SqlConnection(connect))
        {

            using (SqlCommand cmd = new SqlCommand(sp, conn))
            {

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@biz_name", name);
                cmd.Parameters.AddWithValue("@category", "all");



                cmd.Parameters.AddWithValue("@n", Current.Count);
                cmd.Parameters.AddWithValue("@SortOrder", 1);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                da.Fill(ds);


                DataTable dt = ds.Tables[0];

                if (dt.Rows.Count > 0)
                {

                    RepDetails.DataSource = dt;
                    RepDetails.DataBind();


                    int i = 0;
                    for (i = 0; i < dt.Rows.Count - 1; i++)
                    {

                        list = list + dt.Rows[i]["category"].ToString() + ",";

                    }
                    list = list + dt.Rows[i]["category"].ToString() + ".";

                }
                //  Response.Write(list);
                Global.list = list;

            }
        }
    }

   
}



    