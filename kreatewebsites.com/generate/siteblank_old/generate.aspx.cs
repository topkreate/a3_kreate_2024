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

using System.Collections.Generic;


using System.Net;
using System.IO;


public partial class Default : BasePage
{
    protected string siteurl = null;
    protected String hostname = null;
    protected string pageurl = null;
    protected string absurl = "ABC";
    protected string websiteandquery = null;
    protected string path7 = null;
    protected string param = null;
    protected string InputUrl;
    protected string OutputUrl;
    protected string InputFolder;
    protected string OutputFolder;
    protected string photofolder ;
   
    protected void Page_Load(object sender, EventArgs e)
    {
        
        /*
        InputUrl = "http://www.thanks-giving.net//when-is.aspx?count=10";
        OutputUrl = "E:\\e\\a1_sites\\0\\happy-new-year.org\\when-is\\index.html";
      KreateWebsites.Generate.GenerateHTML(InputUrl, OutputUrl);
         
                
        */
   //   InputFolder = "http://www.thanks-giving.net//generate/";

    //    InputFolder = "http://localhost:51000/happy-new-year.org/generate/";
   //   OutputFolder = "c:\\e\\a1_sites\\0\\happy-new-year.org\\";
        InputFolder = @"http://localhost:51000/kreatewebsites.com/generate/siteblank/" ;
      OutputFolder = @"c:\e\a3_samples\1\Geography\";
      photofolder = @"C:\e\a1_sites\pictures.1000\festival\diwali\";

  //  GenerateContinent();
   //   GenerateCountries();
  //    GenerateStates();
   //   GenerateCities();
  //    GeneratePlaces();
 //    Generateholidays();

   //   GenerateDiwaliDates();
   //   GenerateFestivalDates();
    //    GeneratePhotos("Wallpaper") ;
   //   GeneratePhotos_dirscan("Wallpaper", "C:\\e\\a1_sites\\pictures.1000\\festival\\diwali\\");
   //   GeneratePhotos_dirscan("Wallpaper", photofolder);
      //  GenerateArticles_dirscan (@"C:\e\a1_sites\00-articles\festival\diwali\mantra\1\", "mantra");
     // GenerateFestivalYears(2014);
   //   GenerateFestivalList(2014); // generate index.html for each festival

    }

    protected void submit(Object sender,  EventArgs e)
    {
        //Generate.KreateWebsites.Generate.GenerateHTML(inputbox.Text.ToString(), outbox.Text.ToString());

    }

 

    protected void Generateholidays()
    {
        InputUrl = InputFolder + "holidays.aspx?country=USA&year=2014";
        OutputUrl = OutputFolder + "holidays\\USA.html";
        KreateWebsites.Generate.GenerateHTML(InputUrl, OutputUrl);

        InputUrl = InputFolder + "holidays.aspx?country=India&year=2014";
        OutputUrl = OutputFolder + "holidays\\India.html";
        KreateWebsites.Generate.GenerateHTML(InputUrl, OutputUrl);

        InputUrl = InputFolder + "holidays.aspx?country=China&year=2014";
        OutputUrl = OutputFolder + "holidays\\China.html";
        KreateWebsites.Generate.GenerateHTML(InputUrl, OutputUrl);

        InputUrl = InputFolder + "holidays.aspx?country=UK&year=2014";
        OutputUrl = OutputFolder + "holidays\\UK.html";
        KreateWebsites.Generate.GenerateHTML(InputUrl, OutputUrl);

    }
    protected void GeneratePhotos(string size)
    {
        InputUrl = InputFolder + "photos.aspx?topic=Diwali"; 
        OutputUrl = OutputFolder + "wallpapers\\index.html";
        KreateWebsites.Generate.GenerateHTML(InputUrl, OutputUrl);
/*

        InputUrl = InputFolder + "photos.aspx?topic=Dusshera";
        OutputUrl = OutputFolder + "wallpapers\\Dusshera.html";
        KreateWebsites.Generate.GenerateHTML(InputUrl, OutputUrl);

        InputUrl = InputFolder + "photos.aspx?topic=Diwali";
        OutputUrl = OutputFolder + "wallpapers\\Diwali.html";
        KreateWebsites.Generate.GenerateHTML(InputUrl, OutputUrl);




        InputUrl = InputFolder + "photos.aspx?topic=Karwa Chauth";
        OutputUrl = OutputFolder + "wallpapers\\Karwa Chauth.html";
        KreateWebsites.Generate.GenerateHTML(InputUrl, OutputUrl);

        InputUrl = InputFolder + "photos.aspx?topic=New Year";
        OutputUrl = OutputFolder + "wallpapers\\New Year.html";
        KreateWebsites.Generate.GenerateHTML(InputUrl, OutputUrl);

        InputUrl = InputFolder + "photos.aspx?topic=Sankranti";
        OutputUrl = OutputFolder + "wallapapers\Sankranti.html";
        KreateWebsites.Generate.GenerateHTML(InputUrl, OutputUrl);

        InputUrl = InputFolder + "photos.aspx?topic=Pongal";
        OutputUrl = OutputFolder + "wallpapers\\Pongal.html";
        KreateWebsites.Generate.GenerateHTML(InputUrl, OutputUrl);

        InputUrl = InputFolder + "photos.aspx?topic=Lohri";
        OutputUrl = OutputFolder + "pictures\\Lohri.html";
        KreateWebsites.Generate.GenerateHTML(InputUrl, OutputUrl);

        InputUrl = InputFolder + "photos.aspx?topic=Rakhi";
        OutputUrl = OutputFolder + "wallpapers\\Rakhi.html";
        KreateWebsites.Generate.GenerateHTML(InputUrl, OutputUrl);

  */
        string sp = "wallpapers_search";


        string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;

        try
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.AddWithValue("@id", 0);
                    cmd.Parameters.AddWithValue("@category", "festival");
                    cmd.Parameters.AddWithValue("@category2", "all");
                    cmd.Parameters.AddWithValue("@topic", "Diwali");
                    cmd.Parameters.AddWithValue("@size", size);


                    cmd.Parameters.AddWithValue("@n", 100);
                    cmd.Parameters.AddWithValue("@SortOrder", 4);

                    conn.Open();


                    SqlDataReader reader = cmd.ExecuteReader();



                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            InputUrl = InputFolder + "photo.aspx?imageurl=" + reader["imageurl"] + "&name=" + reader["name"]; ;
                            Response.Write(InputUrl);
                            OutputUrl = OutputFolder + "wallpapers\\" + reader["name"].ToString() + ".html";
                            //     OutputUrl = OutputFolder + reader["country"].ToString() + "\\" + "cities-in-" + reader["Region"].ToString() + ".html";

                            Response.Write("<br/>");
                            Response.Write(OutputUrl);
                            Response.Write("<br/>");
                            //   InputUrl = InputFolder + reader.["statename"].tostring();
                            //     Console.WriteLine("{0}\t{1}", reader.GetInt32(0), reader.GetString(1));
                            KreateWebsites.Generate.GenerateHTML(InputUrl, OutputUrl);




                        }
                    }
                    else
                    {
                        Console.WriteLine("No rows found.");
                    }
                    conn.Close();



                }


            }
        }
        catch (Exception e)
        {
            Response.Write("Exception is : " + e.Message) ;
        }


    }


   


    protected void GenerateContinent()
    {


        try
        {

            // string sp = "regions_search";
            string sp = "continent_search";


            string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent","all");
                    cmd.Parameters.AddWithValue("@geo", "all");
                    cmd.Parameters.AddWithValue("@Country", "all");

                    cmd.Parameters.AddWithValue("@n", 200);
                    cmd.Parameters.AddWithValue("@SortOrder", 3);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();



                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            InputUrl = InputFolder + "default.aspx?continent=" + reader["continent"].ToString();
                            OutputUrl = OutputFolder + reader["continent"].ToString() + "\\index.html";
                            //     OutputUrl = OutputFolder + reader["country"].ToString() + "\\" + "cities-in-" + reader["Region"].ToString() + ".html";
                            Response.Write(InputUrl);
                            Response.Write("<br/>");
                            Response.Write(OutputUrl);
                            Response.Write("<br/>");
                            //   InputUrl = InputFolder + reader.["statename"].tostring();
                            //     Console.WriteLine("{0}\t{1}", reader.GetInt32(0), reader.GetString(1));
                            KreateWebsites.Generate.GenerateHTML(InputUrl, OutputUrl);




                        }
                    }
                    else
                    {
                        Console.WriteLine("No rows found.");
                    }
                    conn.Close();
                }

            }



        }
        catch (Exception ex)
        {
            Response.Write("Exception : " + ex.Message.ToString());

        }

        

    }

    protected void GenerateCountries()
    {


        try
        {

            // string sp = "regions_search";
            string sp = "countries_search";


            string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent", "all");
                    cmd.Parameters.AddWithValue("@geo", "all");
                    cmd.Parameters.AddWithValue("@Country","all");

                    cmd.Parameters.AddWithValue("@n", 2000);
                    cmd.Parameters.AddWithValue("@SortOrder", 1);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();



                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                           
                            //   InputUrl = InputFolder + reader.["statename"].tostring();
                            //     Console.WriteLine("{0}\t{1}", reader.GetInt32(0), reader.GetString(1));
                      


                         //   InputUrl = InputFolder + "default.aspx?continent=" + reader["continent"].ToString() + "&country=" + reader["country"].ToString() ;
                            InputUrl = InputFolder + "default.aspx?country=" + reader["country"].ToString() ;
                            OutputUrl = OutputFolder + reader["continent"].ToString() + "\\" + reader["country"].ToString() + "\\index.html";
                           

                            Response.Write(InputUrl);
                            Response.Write("<br/>");
                            Response.Write(OutputUrl);
                            Response.Write("<br/>");

                            KreateWebsites.Generate.GenerateHTML(InputUrl, OutputUrl);

                          
                        }
                    }
                    else
                    {
                        Console.WriteLine("No rows found.");
                    }
                    conn.Close();
                }

            }



        }
        catch (Exception ex)
        {
            Response.Write("Exception : " + ex.Message.ToString());

        }

    }
    protected void GenerateStates()
    {

        Response.Write("State started");

        try
        {

            // string sp = "regions_search";
          //  string sp = "regions_v2"; it does not have continent
            string sp = "regions_v3";
       
            string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Continent", Global.Continent.ToString());
                    cmd.Parameters.AddWithValue("@Country", Global.Country.ToString());

                    cmd.Parameters.AddWithValue("@n", 10000);
                    cmd.Parameters.AddWithValue("@SortOrder", 3);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();



                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            InputUrl = InputFolder + "default.aspx?continent=" + reader["continent"].ToString() + "&country=" + reader["country"].ToString() + "&statename=" + reader["Region"].ToString();
                            OutputUrl = OutputFolder + reader["continent"].ToString() + "\\" + reader["country"].ToString() + "\\" + reader["Region"].ToString() + "\\index.html";
                            KreateWebsites.Generate.GenerateHTML(InputUrl, OutputUrl);


                            
                       //     OutputUrl = OutputFolder + reader["country"].ToString() + "\\" + "cities-in-" + reader["Region"].ToString() + ".html";
                            Response.Write(InputUrl);
                            Response.Write("<br/>");
                            Response.Write(OutputUrl);
                            Response.Write("<br/>");
                            //   InputUrl = InputFolder + reader.["statename"].tostring();
                            //     Console.WriteLine("{0}\t{1}", reader.GetInt32(0), reader.GetString(1));
                          
                        }
                    }
                    else
                    {
                        Console.WriteLine("No rows found.");
                    }
                    conn.Close();
                }

            }



        }
        catch (Exception ex)
        {
            Response.Write("Exception : " + ex.Message.ToString());

        }

    }
    protected void GenerateCities()
    {

        try
        {
         //   string sp = "cities_search";  does noot have continent

            string sp = "cities_search_v2"; //v6 use null

            string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;


            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp,conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Continent", Global.Country.ToString());
                    cmd.Parameters.AddWithValue("@Country", Global.Country.ToString());
                    cmd.Parameters.AddWithValue("@Region", "all");
                    cmd.Parameters.AddWithValue("@n", 50000);
                    cmd.Parameters.AddWithValue("@SortOrder", 3);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();



                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            InputUrl = InputFolder + "?city=" + reader["city"].ToString();
                        //org    OutputUrl = OutputFolder +  reader["region"].ToString() + "\\" + reader["city"].ToString() + "\\index.html";
                            OutputUrl = OutputFolder + reader["continent"].ToString() + "\\" + reader["country"].ToString() + "\\" + reader["region"].ToString() + "\\" + reader["city"].ToString() + "\\index.html";
                           
                            Response.Write(InputUrl);
                            Response.Write("<br/>");
                            Response.Write(OutputUrl);
                            Response.Write("<br/>");
                            KreateWebsites.Generate.GenerateHTML(InputUrl, OutputUrl);

                            /*
                            InputUrl = InputFolder + "about.aspx?city=" + reader["city"].ToString();
                            OutputUrl = OutputFolder + reader["region"].ToString() + "\\" + reader["city"].ToString() + "\\about.html";
                           
                            KreateWebsites.Generate.GenerateHTML(InputUrl, OutputUrl);


                            InputUrl = InputFolder + "list.aspx?city=" + reader["city"].ToString();
                            OutputUrl = OutputFolder + reader["region"].ToString() + "\\" + reader["city"].ToString() + "\\attractions.html";
                            KreateWebsites.Generate.GenerateHTML(InputUrl, OutputUrl);
                             * */
                        }
                    }
                    else
                    {
                        Console.WriteLine("No rows found.");
                    }

                    conn.Close();
                }

            }

        }
        catch (Exception ex)
        {
            Response.Write("Exception : " + ex.Message.ToString());

        }
       


    }

    protected void GeneratePlaces()
    {

        try
        {
          //  string sp = "best_tourist_places_search"; does not have continent and statename
            string sp = "best_tourist_places_search_v5";

            string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;


            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Continent", Global.Continent.ToString());
                    cmd.Parameters.AddWithValue("@Country", Global.Country.ToString());

                    cmd.Parameters.AddWithValue("@State", "all");
                    cmd.Parameters.AddWithValue("@Statename", "all");

                    cmd.Parameters.AddWithValue("@city", "all");
                    cmd.Parameters.AddWithValue("@Category", "all");
                    cmd.Parameters.AddWithValue("@SubCategory", "all");
                    cmd.Parameters.AddWithValue("@n", 200000);
                    cmd.Parameters.AddWithValue("@SortOrder", 1);



                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();



                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            InputUrl = InputFolder + "?name=" + reader["biz_name"].ToString();
                    // org        OutputUrl = OutputFolder + reader["region"].ToString() + "\\" + reader["city"].ToString() + "\\"+ reader["biz_name"].ToString() + ".html";
                            OutputUrl = OutputFolder + reader["continent"].ToString() + "\\" + reader["country"].ToString() + "\\" + reader["region"].ToString() + "\\" + reader["city"].ToString() + "\\" + reader["biz_name"].ToString() + ".html";
                            // Console.WriteLine("{0}\t{1}", reader.GetInt32(0), reader.GetString(1));
                            Response.Write(InputUrl);
                            Response.Write("<br/>");
                            Response.Write(OutputUrl);
                            Response.Write("<br/>");
                            KreateWebsites.Generate.GenerateHTML(InputUrl, OutputUrl);

                 

                        }
                    }
                    else
                    {
                        Console.WriteLine("No rows found.");
                    }

                    conn.Close();
                }

            }

        }
        catch (Exception ex)
        {
            Response.Write("Exception : " + ex.Message.ToString());

        }



    }

    private void GenerateDiwaliDates()
    {


        string sp = "festival_search";


        string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;


        using (SqlConnection conn = new SqlConnection(connect))
        {

            using (SqlCommand cmd = new SqlCommand(sp, conn))
            {

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@year", 0);
                cmd.Parameters.AddWithValue("@festival", "Diwali");
                cmd.Parameters.AddWithValue("@category", "all");
                cmd.Parameters.AddWithValue("@country", "all" );


                cmd.Parameters.AddWithValue("@n", 20);
                cmd.Parameters.AddWithValue("@SortOrder", 1);


                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();



                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        InputUrl = InputFolder + "when-is.aspx?year=" + Convert.ToString(reader["year"] );
                        OutputUrl = OutputFolder + reader["year"].ToString() + "\\index.html";
                        //     OutputUrl = OutputFolder + reader["country"].ToString() + "\\" + "cities-in-" + reader["Region"].ToString() + ".html";
                        Response.Write(InputUrl);
                        Response.Write("<br/>");
                        Response.Write(OutputUrl);
                        Response.Write("<br/>");
                        //   InputUrl = InputFolder + reader.["statename"].tostring();
                        //     Console.WriteLine("{0}\t{1}", reader.GetInt32(0), reader.GetString(1));
                        KreateWebsites.Generate.GenerateHTML(InputUrl, OutputUrl);




                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                conn.Close();

               


            }




        }
    }

    private void GenerateFestivalDates()
    {


        string sp = "festival_search";


        string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;


        using (SqlConnection conn = new SqlConnection(connect))
        {

            using (SqlCommand cmd = new SqlCommand(sp, conn))
            {

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@year", 0);
                cmd.Parameters.AddWithValue("@festival", "all");
                cmd.Parameters.AddWithValue("@category", "all");
                cmd.Parameters.AddWithValue("@country", "all");


                cmd.Parameters.AddWithValue("@n", 500);
                cmd.Parameters.AddWithValue("@SortOrder", 1);


                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();



                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        InputUrl = InputFolder + "when-is.aspx?year=" + Convert.ToString(reader["year"] + "&festival=" + reader["festival"].ToString());
                        OutputUrl = OutputFolder + reader["festival"].ToString() + "\\" + reader["year"].ToString().Trim() + ".html";
                        //     OutputUrl = OutputFolder + reader["country"].ToString() + "\\" + "cities-in-" + reader["Region"].ToString() + ".html";
                        Response.Write(InputUrl);
                        Response.Write("<br/>");
                        Response.Write(OutputUrl);
                        Response.Write("<br/>");
                        //   InputUrl = InputFolder + reader.["statename"].tostring();
                        //     Console.WriteLine("{0}\t{1}", reader.GetInt32(0), reader.GetString(1));
                        KreateWebsites.Generate.GenerateHTML(InputUrl, OutputUrl);




                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                conn.Close();




            }




        }
    }





        private void GenerateFestivalList(int year)
        {
            // generate list of all festivals for a given year

            string sp = "festival_search_year";


            string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;


            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@year", year);
                    cmd.Parameters.AddWithValue("@festival", "all");
                    cmd.Parameters.AddWithValue("@category", "all");
                    cmd.Parameters.AddWithValue("@country", "all");


                    cmd.Parameters.AddWithValue("@n", 100);
                    cmd.Parameters.AddWithValue("@SortOrder", 1);


                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();



                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            InputUrl = InputFolder + "when-is.aspx?year=" + Convert.ToString(reader["year"] + "&festival=" + reader["festival"].ToString());
                            OutputUrl = OutputFolder + reader["festival"].ToString().Trim() + "\\"  + "index.html";
                            //     OutputUrl = OutputFolder + reader["country"].ToString() + "\\" + "cities-in-" + reader["Region"].ToString() + ".html";
                            Response.Write(InputUrl);
                            Response.Write("<br/>");
                            Response.Write(OutputUrl);
                            Response.Write("<br/>");
                            //   InputUrl = InputFolder + reader.["statename"].tostring();
                            //     Console.WriteLine("{0}\t{1}", reader.GetInt32(0), reader.GetString(1));
                            KreateWebsites.Generate.GenerateHTML(InputUrl, OutputUrl);




                        }
                    }
                    else
                    {
                        Console.WriteLine("No rows found.");
                    }
                    conn.Close();




                }




            }
        }

        private void GenerateFestivalYears(int startyear)
        {
            // for each year, default festival

            for (int i = 0; i < 10; i++)
            {

                InputUrl = "http://www.diwali.mobi/when-is-festival.aspx?year=" + startyear;
                OutputUrl = "E:\\e\\a1_sites\\0\\diwali.mobi\\festival\\" + startyear + ".html";
                KreateWebsites.Generate.GenerateHTML(InputUrl, OutputUrl);

                startyear++;
            }

        }




}

