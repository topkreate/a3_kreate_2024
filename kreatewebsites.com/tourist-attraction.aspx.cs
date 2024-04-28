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
  protected String itemstovisit = "World";
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
          itemstovisit = city;
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
        //  itemstovisit = name;
      }
     

      if (Request.QueryString["count"] != null)
      {
          count = Convert.ToInt32(Request.QueryString["count"]);
      }

            DataTable dt;

       
            KreateWebsites.Places.GetVariables();
      //      dt = KreateWebsites.Places.GetData(continent, country, state, statename, city, Global.Category, Global.SubCategory, count, 1);

            dt = KreateWebsites.Places.GetData(continent, country, state, statename, city, category, subcategory, name, 1000, 1, 10);

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

/*
                    dt.Rows[i]["countryurl"] = Global.Siteurl.ToString() + dt.Rows[i]["country"].ToString().Trim() + @"/";
                    dt.Rows[i]["stateurl"] = dt.Rows[i]["countryurl"] + dt.Rows[i]["statename"].ToString().Trim() + @"/"; 
                    dt.Rows[i]["cityurl"] = dt.Rows[i]["stateurl"] + dt.Rows[i]["city"].ToString().Trim() + @"/"; */
                    dt.Rows[i]["cityurl"] = Global.Siteurl.ToString() + dt.Rows[i]["city"].ToString().Trim() + @"/";
                    dt.Rows[i]["placeurl"] = dt.Rows[i]["cityurl"] + dt.Rows[i]["biz_name"].ToString().Trim() + @"/";
  
                //    dt.Rows[i]["placeurl"] = Global.Siteurl + "tourist-attraction.aspx?name=" + dt.Rows[i]["biz_name"].ToString().Trim() ;
                    // dt.Rows[i]["url"] = Global.Siteurl.ToString() + dt.Rows[i]["country"].ToString().Trim() + @"/" + dt.Rows[i]["statename"].ToString().Trim() + @"/" + dt.Rows[i]["city"].ToString().Trim() + @"/" + url + @"/";

                    if (i == 0)
                        list = dt.Rows[i]["biz_name"].ToString().Trim();
                    else

                        list = list + dt.Rows[i]["biz_name"].ToString().Trim() + " ;";
                }


                RepDetails.DataSource = dt;
                RepDetails.DataBind();

            }


            creategallery();

/*

if (Request.QueryString["state"] != null)
       itemstovisit = itemstovisit + Request.QueryString["city"] + " ";

       if (Request.QueryString["state"] != null)
            itemstovisit = itemstovisit + Request.QueryString["state"] + " ";
              if (Request.QueryString["country"] != null)
            itemstovisit = itemstovisit + Request.QueryString["country"] + " ";

*/

            lblArea.Text = itemstovisit;
        Page.Title =  name +  " | Tourist attraction in " + itemstovisit   ; 


        HtmlMeta tag = new HtmlMeta();
  //      tag.Name = "description";
  //      tag.Content = Page.Title + " - " + list + " are " + count.ToString() + " best places to see in  " + itemstovisit ;
        Header.Controls.Add(tag);

        }

        protected void creategallery()
        {
            DataTable dt;
            KreateWebsites.Places.GetVariables();

            //   dt = KreateWebsites.Websites.GetImages("tourist", 10);
            dt = KreateWebsites.Websites.GetImages(country, name, 100);

            //    list = " ";
            if (dt.Rows.Count > 0)
            {


                dt.Columns.Add("url", typeof(String));
                dt.Columns.Add("stateurl", typeof(String));
                dt.Columns.Add("cityurl", typeof(String));
                dt.Columns.Add("seq", typeof(int));

                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    dt.Rows[i]["seq"] = i;

                    string url = dt.Rows[i]["biz_name"].ToString().Trim();
                    //   KreateWebsites.Generate.ReplaceStr(ref url, ' ', '-');



          //          string countryurl = dt.Rows[i]["country"].ToString().Trim();
                    //   KreateWebsites.Generate.ReplaceStr(ref countryurl, ' ', '-');
          //          string stateurl = dt.Rows[i]["state"].ToString().Trim();
                    //    KreateWebsites.Generate.ReplaceStr(ref stateurl, ' ', '-');

           //         string cityurl = dt.Rows[i]["city"].ToString().Trim();
                    //    KreateWebsites.Generate.ReplaceStr(ref cityurl, ' ', '-');

                    //   dt.Rows[i]["url"] = Global.Siteurl.ToString() +  countryurl + @"/" + stateurl + @"/" + cityurl + @"/" + url + @"/";
                    //    dt.Rows[i]["cityurl"] = Global.Siteurl.ToString() + countryurl  + @"/" + stateurl + @"/" + cityurl + @"/";
                    /*
                    dt.Rows[i]["url"] = Global.Siteurl.ToString() + "pictures.aspx?country=" + countryurl + "&statename=" + stateurl + "&city=" + cityurl + "&name=" + url;
                    dt.Rows[i]["cityurl"] = Global.Siteurl.ToString() + "city.aspx?country=" + countryurl + "&statename=" + stateurl + "&city=" + cityurl;
                    dt.Rows[i]["stateurl"] = Global.Siteurl.ToString() + "state.aspx?country=" + countryurl + "&statename=" + stateurl;
                     *   * */
                    dt.Rows[i]["imageurl"] = Global.ImagePath.ToString() + dt.Rows[i]["path"].ToString().Trim() + Global.thumbnailpath.ToString() + dt.Rows[i]["imagename"].ToString().Trim();
                   

                    //        list = list + " " + dt.Rows[i]["web_desc"].ToString().Trim();







                }
                RepPictures.DataSource = dt;
                RepPictures.DataBind();

            }

        }

    }
