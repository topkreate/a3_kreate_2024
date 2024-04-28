using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data;
using System.Data.SqlClient;




    public partial class Default : BasePage
    {
  protected String itemstovisit = Global.Country;
  protected string continent = Global.Continent;
  protected string country = Global.Country;
  protected string state = Global.State;
  protected string statename = Global.StateName;
  protected string city = Global.City;
  protected string category = Global.Category;
  protected string subcategory = Global.SubCategory;
  protected string name;
  protected int count = 1000;
  protected int sortOrder;

  protected string list; 
  


        protected void Page_Load(object sender, EventArgs e)
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
          count = 100;
      }
      if (Request.QueryString["state"] != null)
      {
          state = Request.QueryString["state"];
          itemstovisit = state;
          count = 50;
      }
      if (Request.QueryString["statename"] != null)
      {
          statename = Request.QueryString["statename"];
          itemstovisit = statename;
          count = 50;
      }
      if (Request.QueryString["city"] != null)
      {
          city = Request.QueryString["city"];
          itemstovisit = statename;
          count = 10;
      }

      if (Request.QueryString["category"] != null)
      {
          category = Request.QueryString["category"];
          itemstovisit = statename;
          count = count / 2;
      }


      if (Request.QueryString["subcategory"] != null)
      {
          subcategory = Request.QueryString["subcategory"];
          itemstovisit = statename;
          count = count / 2;
      }
      if (Request.QueryString["name"] != null)
      {
          name = Request.QueryString["name"];
          itemstovisit = name;
      }
     

      if (Request.QueryString["count"] != null)
      {
          count = Convert.ToInt32(Request.QueryString["count"]);
      }

            DataTable dt;
          //  count = 4;
       
            KreateWebsites.Places.GetVariables();
      //      dt = KreateWebsites.Places.GetData(continent, country, state, statename, city, Global.Category, Global.SubCategory, count, 1);

            dt = KreateWebsites.Places.GetData(continent, country, state, statename, city, category, subcategory, name, count, 1, 10);

            if (dt.Rows.Count > 0)
            {

                 dt.Columns.Add("placeurl", typeof(String));
                dt.Columns.Add("cityurl", typeof(String));
                dt.Columns.Add("stateurl", typeof(String));
                dt.Columns.Add("countryurl", typeof(String));

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string url = dt.Rows[i]["biz_name"].ToString().Trim();
                    //   KreateWebsites.Generate.ReplaceStr(ref url, ' ', '-');


              //      dt.Rows[i]["countryurl"] = Global.Siteurl.ToString() + dt.Rows[i]["country"].ToString().Trim() + @"/";
               //     dt.Rows[i]["stateurl"] = dt.Rows[i]["countryurl"] + dt.Rows[i]["statename"].ToString().Trim() + @"/";
               //     dt.Rows[i]["cityurl"] = dt.Rows[i]["stateurl"] + dt.Rows[i]["city"].ToString().Trim() + @"/";
              //      dt.Rows[i]["placeurl"] = dt.Rows[i]["cityurl"] + dt.Rows[i]["biz_name"].ToString().Trim() + @"/";
               //     dt.Rows[i]["cityurl"] = Global.Siteurl.ToString() + dt.Rows[i]["city"].ToString().Trim() + @"/";
              //      dt.Rows[i]["placeurl"] =  dt.Rows[i]["cityurl"] + dt.Rows[i]["biz_name"].ToString().Trim() + @"/";

                    dt.Rows[i]["stateurl"] = Global.Siteurl.ToString() + "tourist-attraction.aspx?statename=" + dt.Rows[i]["statename"].ToString().Trim() + "&country=" + dt.Rows[i]["country"].ToString().Trim();
                    dt.Rows[i]["cityurl"] = Global.Siteurl.ToString() + "tourist-attraction.aspx?city=" + dt.Rows[i]["city"].ToString().Trim() + "&country=" + dt.Rows[i]["country"].ToString().Trim();
                    dt.Rows[i]["placeurl"] = Global.Siteurl.ToString() + "tourist-attraction.aspx?name=" + dt.Rows[i]["biz_name"].ToString().Trim() + "&country=" + dt.Rows[i]["country"].ToString().Trim();
                    if (i == 0)
                        list = dt.Rows[i]["biz_name"].ToString().Trim();
                    else

                        list = list + dt.Rows[i]["biz_name"].ToString().Trim() + " ;";
                }


                RepDetails.DataSource = dt;
                RepDetails.DataBind();

            }
    




          //  lblArea.Text = itemstovisit;
        Page.Title =  dt.Rows.Count.ToString() +  " tourist attraction to visit in  " + itemstovisit + " | Tour of " + itemstovisit   ;
        lblTitle.Text = Page.Title;

        HtmlMeta tag = new HtmlMeta();
        tag.Name = "description";
        tag.Content = Page.Title + " " + list + ". Click to see name of each place to get details ";
        Header.Controls.Add(tag);

        }

    }
