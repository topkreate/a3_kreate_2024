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


public partial class Generate : BasePage
{

    protected string continent = Global.Continent.ToString();
    protected string country = Global.Country.ToString();
    protected string state = Global.State.ToString();
    protected string statename = Global.StateName.ToString();
    protected string city = Global.City.ToString();
    protected string category = Global.Category.ToString();
    protected string subcategory = Global.SubCategory.ToString();

    protected string thumbnail_path = Global.thumbnailpath.ToString();

    
    protected string url = " ";
    protected string name = " ";

    protected int year;
    protected int count = 5;

  
    protected string InputUrl;
    protected string OutputUrl;
    protected string InputFolder;
    protected string OutputFolder;
    protected string outputdir;
    public static bool overwrite = true;


  
   
    protected string SiteFolder;
  


    protected string local_path;
    protected string navigate_path;
    protected string pic_path;
    protected string ImagePath = Global.ImagePath.ToString();
    protected string picpage = Global.picpage;
    protected string sitepath;
    protected string computerpath;
    protected string datefolder = "holidays";

    protected void Page_Load(object sender, EventArgs e)
    {

    
       sitepath = Global.Siteurl; 
     computerpath = LocalPath.ComputerPath;
     SiteFolder = @"http://localhost:54704/placetosee.net/generate/";
        local_path = LocalPath.InputPath;

      //  pic_path = @"http://pictures.placetosee.net/India/";  // path of picture on web server
       // navigate_path = null;  // path where user will navigate to on clicking picture
       
        
        // OutputFolder = @"C:\e\a1_sites\10\places-to-see.net\output\";
        OutputFolder = LocalPath.OutPutPath;

  //      Generatesubdirs();


        textbox_sitepath.Text = sitepath;
        textbox_computerpath.Text = computerpath;
        textbox_sitefolder.Text = SiteFolder;
        textbox_inputpath.Text = local_path;
        textbox_outputpath.Text = OutputFolder;
        textbox_Photopath.Text = Global.photopath;
        check_overwrite.Text = overwrite.ToString(); ;


        button1.Click += new EventHandler(this.StartGenerate_Click);

      //  Generateholidays("2014");
     //   GenerateFestivalDates();
     //   GenerateFestivalList(2014); // generate index.html for each festival

        //   GenerateDiwaliDates();
          
        //    GeneratePhotos("Wallpaper") ;
        //  
        // GenerateFestivalYears(2014);


      //  GenerateCities();
       
    }
   

     void StartGenerate_Click(Object sender,
                           EventArgs e)

    {
         Button clickedButton = (Button)sender;
        clickedButton.Text = "...button clicked...";
        clickedButton.Enabled = false;

        sitepath = textbox_sitepath.Text.ToString() ;
         computerpath = textbox_computerpath.Text.ToString() ;
        SiteFolder = textbox_sitefolder.Text.ToString() ;
        local_path = textbox_inputpath.Text.ToString()  ;
        OutputFolder = textbox_outputpath.Text.ToString()  ;

        overwrite = Convert.ToBoolean(check_overwrite.Text.ToString());
       
       
       

  //      Response.Write("Checked is " + check_overwrite.Text.ToString() +  "  " + overwrite.ToString());
        string[] subdirectoryEntries = Directory.GetDirectories(local_path);


        DirectoryInfo dInfo = new DirectoryInfo(local_path);


        foreach (DirectoryInfo di in dInfo.GetDirectories())
        {

            ProcessFolder(di, local_path, OutputFolder);  // Copy parent directory, input path, output path
        }


       GenerateCities();
       GeneratePlaces();

    }

    protected void Generatesubdirs( )
    {

        string[] fileEntries = Directory.GetFiles(local_path);
    

       // Response.Write("input folder is " + ParentDir);
      string[] subdirectoryEntries = Directory.GetDirectories(local_path);


        DirectoryInfo dInfo = new DirectoryInfo(local_path);

         
        foreach (DirectoryInfo di in dInfo.GetDirectories())
    {
        
        ProcessFolder(di,local_path, OutputFolder);
    }
        foreach (FileInfo fi in dInfo.GetFiles())
    {
        //Do something with the file here
        //or create a method like:
        ProcessFile(fi) ;
    }


     
        
    }


    private void ProcessFolder(DirectoryInfo di, string local_path, string OutputFolder)
    {
      //  Response.Write("dir is " +  di.Name.ToString());


        string subfolder = di.Name.ToString();
        string localfolder = local_path ;

        GetImagePath(localfolder + subfolder);  // setting the image path

      //  OutputFolder = OutputFolder + subfolder + @"\"; // this does not work, pass sub folder to pass article so that it can create sidelink

  //   LocalPath.ComputerPath = OutputFolder + subfolder;  // so that article control can read it
  //   LocalPath.SitePath = LocalPath.SitePath + "subfolder";

        InputUrl = SiteFolder + "photos-dir.aspx?local_path=" + localfolder + "&subfolder=" + subfolder + "&pic_path=" + pic_path + "&navigate_path=" + navigate_path + "&output_path=" + OutputFolder + subfolder + @"\";

        OutputUrl = OutputFolder + subfolder + @"\" + picpage + ".html";

  //   Response.Write("url = " + InputUrl + "<br/> " + OutputUrl);
   GenerateHTML(InputUrl, OutputUrl); // Write gallery page


   InputUrl = SiteFolder + "gallery.aspx?local_path=" + localfolder + "&subfolder=" + subfolder + "&pic_path=" + pic_path + "&navigate_path=" + navigate_path + "&output_path=" + OutputFolder + subfolder + @"\";

   OutputUrl = OutputFolder + subfolder + @"\" + "gallery" + ".html";

   //   Response.Write("url = " + InputUrl + "<br/> " + OutputUrl);
   GenerateHTML(InputUrl, OutputUrl); // Write gallery page

   InputUrl = SiteFolder + "slides.aspx?local_path=" + localfolder + "&subfolder=" + subfolder + "&pic_path=" + pic_path + "&navigate_path=" + navigate_path + "&output_path=" + OutputFolder + subfolder + @"\";

   OutputUrl = OutputFolder + subfolder + @"\" + "slides" + ".html";

   //   Response.Write("url = " + InputUrl + "<br/> " + OutputUrl);
   GenerateHTML(InputUrl, OutputUrl); // Write gallery page


    GeneratePhotos_dirscan(local_path, OutputFolder, subfolder); // Write sub pages.  each page show 1 photo

    GenerateSlides_dirscan(local_path, OutputFolder, subfolder); // Write sub pages.  each page show 1 photo

        GenerateArticle(local_path, OutputFolder, subfolder); // Write sub pages.  each page show 1 photo


       local_path = local_path + subfolder + "\\";  // for recurssion.  Not tested
        OutputFolder = OutputFolder + subfolder + "\\"; // not tested
        string[] subdirectoryEntries = Directory.GetDirectories(localfolder);


        DirectoryInfo dInfo = new DirectoryInfo(local_path);

       
        foreach (DirectoryInfo subdi in dInfo.GetDirectories())
        {

            if (subdi.Name.ToString() != "thumbnails")
            {
               // local_path = local_path  + subfolder + "\\"  ;
               // OutputFolder =  OutputFolder + subfolder + "\\" ;
               ProcessFolder(subdi,local_path, OutputFolder);
            
                
            }
        }
         


    }

    private void ProcessFile(FileInfo fi)
    {

        Response.Write("file is " + fi.Name.ToString() );
    }

    protected void GenerateHTML(string inputurl, string outputurl)
    {

        try
        {

            if ((!File.Exists(outputurl)) || (overwrite))
            {
              //  Response.Write("in HTML : input " + inputurl + "<br/>");

            //    Response.Write("in HTML : output " + outputurl + "<br/>");


                WebRequest req = WebRequest.Create(inputurl);
                WebResponse res = req.GetResponse();
                StreamReader sr = new StreamReader(res.GetResponseStream());
                string html = sr.ReadToEnd();

                writefile(html, outputurl);
            }
        }
        catch (Exception e)
        {
            Response.Write("Exception" +  e.Message);
           
        }


    }

    protected  void writefile(string html, string localpath)
    {
        // string localpath ;
        // localpath = "f:\\" + siteurl + "\\" + path7 + "\\" + param + ".html";
        //   localpath = "f:\\test\\" + param + ".html";
        //  StreamWriter _testData = new StreamWriter("f:\\" + siteurl + "\\" + path7 + "\\" + param) ;
        //   StreamWriter _testData = new StreamWriter("f:\\test\\data3.html", true);

  //      Response.Write("<br/> Directory created : " + localpath);
        Directory.CreateDirectory(Path.GetDirectoryName(localpath));

        //     StreamWriter _testData = new StreamWriter(localpath, true);  // to append to existing file
        StreamWriter _testData = new StreamWriter(localpath, false);  // to overwrite existing file
        _testData.WriteLine(html); // Write the file.
        _testData.Close(); // Close the instance of StreamWriter.
        _testData.Dispose(); // Dispose from memory.       

      Response.Write("<br/> File created : " + localpath   );
    }

    public void GetImagePath(string inputdir)
    {

    

        // Default value of pictures path is t\aken from global. The value can be overriden by providing a value in file pictures.path 
        ImagePath = Global.ImagePath.ToString();
        if (File.Exists(inputdir + @"\pictures.path"))
        {
            string str = System.IO.File.ReadAllText(inputdir + @"\pictures.path");

            ImagePath = str.TrimEnd('\r', '\n');  // This will remove any combination of carriage returns and newlines from 
  
        }
    }


    protected void GeneratePhotos_dirscan(string inputdir, string outputdir, string picsubfolder)
    {



        string imageurl;
        string imagename;
        string extension;
        string imagefullurl;

       // string picdir = outputdir + "\\" + picsubfolder;
        string picdir = inputdir + "\\" + picsubfolder;  // if there is bug chnage it to input
     

      //  Response.Write("<br/>In Gen Photo  = " + inputdir + " " + picsubfolder);
        try
        {
            string[] fileEntries = Directory.GetFiles(picdir);
            int i = 0;

            GetImagePath(inputdir+ @"\" + picsubfolder);   // public function.  use pictures.path file if given, otherwise use Global path
            foreach (string path in fileEntries)
            {



             //   Response.Write("<br/>In path  = " + path);

                if (File.Exists(path))
                {
                    // This path is a file

                    imageurl = System.IO.Path.GetFileName(path);
                    imagename = System.IO.Path.GetFileNameWithoutExtension(path);


                 

                    imagefullurl  =  ImagePath  + Global.photopath +  imageurl ;
                    extension = System.IO.Path.GetExtension(path);

                    if ((extension.ToLower() == ".jpg") || (extension.ToLower() == ".jpeg") || (extension.ToLower() == ".png"))
                    {


                      //  InputUrl = SiteFolder + "photo.aspx?imageurl=" + imagefullurl + "&name=" + imagename + "&output_path=" + picdir + @"\";  //output path for article  control to generate links
                       InputUrl = SiteFolder + "photo.aspx?imageurl=" + imagefullurl + "&name=" + imagename + "&output_path=" + outputdir + @"\";  //output path for article  control to generate links
           
                        OutputUrl = outputdir + picsubfolder + "/" + imagename + ".html";  

                        /*
                        InputUrl = SiteFolder + "slide.aspx?imageurl=" + imagefullurl + "&name=" + imagename + "&output_path=" + outputdir + @"\";  //output path for article  control to generate links
                        OutputUrl = outputdir + picsubfolder + "/" + imagename + ".html";
                         */
                        i++;

                 //       Response.Write("Inputurl = " + InputUrl + "<br/>");
                       
               

                     //   Response.Write("<br/>");
                      //  Response.Write(OutputUrl);


                        GenerateHTML(InputUrl, OutputUrl);


                    }

                }
                else
                {
                    Console.WriteLine("No rows found.");
                }




            }  // for


      //      Response.Write("input dir = " + inputdir + @"\" + picsubfolder + @"\pictures.list");

            //  This read pictures.list. You can specify picture filename in this file.
            if (File.Exists(inputdir + @"\" + picsubfolder + @"\pictures.list"))
            {
           

                System.IO.StreamReader file =
                   new System.IO.StreamReader(inputdir +  @"\" + picsubfolder + @"\pictures.list");
                while ((imageurl = file.ReadLine()) != null)
                {
                    //name = url; // remove .jpg

               
                    imagename = imageurl.Replace(".jpg", "");
                    imagename = imagename.Replace(".jpeg", "");
                    imagename = imagename.Replace(".png", "");
                    imagename = imagename.Replace(".JPG", "");
                    imagename = imagename.Replace(".JPEG", "");
                    imagename = imagename.Replace(".PNG", "");
/* works for 3 character extension
                    imagename = imageurl.Remove(imageurl.Length - 4, 4); */

                    imagefullurl = ImagePath + Global.photopath + imageurl;

                   InputUrl = SiteFolder + "photo.aspx?imageurl=" + imagefullurl + "&name=" + imagename + "&output_path=" + picdir + @"\";
           
                    OutputUrl = outputdir + picsubfolder + "/" + imagename + ".html";

                    /*
                    InputUrl = SiteFolder + "slide.aspx?imageurl=" + imagefullurl + "&name=" + imagename + "&output_path=" + picdir + @"\";

                    OutputUrl = outputdir + picsubfolder + "/" + imagename + ".html";
                     */ 

                    GenerateHTML(InputUrl, OutputUrl);
                 
                }

                file.Close();


            }

        }
        catch (Exception e)
        {
            Response.Write("Exception is : " + e.Message);
        }


    }



    protected void GenerateSlides_dirscan(string inputdir, string outputdir, string picsubfolder)
    {



        string imageurl;
        string imagename;
        string extension;
        string imagefullurl;

        // string picdir = outputdir + "\\" + picsubfolder;
        string picdir = inputdir + "\\" + picsubfolder;  // if there is bug chnage it to input


        //  Response.Write("<br/>In Gen Photo  = " + inputdir + " " + picsubfolder);
        try
        {
            string[] fileEntries = Directory.GetFiles(picdir);
            int i = 0;

            GetImagePath(inputdir + @"\" + picsubfolder);   // public function.  use pictures.path file if given, otherwise use Global path
            foreach (string path in fileEntries)
            {



                //   Response.Write("<br/>In path  = " + path);

                if (File.Exists(path))
                {
                    // This path is a file

                    imageurl = System.IO.Path.GetFileName(path);
                    imagename = System.IO.Path.GetFileNameWithoutExtension(path);




                    imagefullurl = ImagePath + Global.photopath + imageurl;
                    extension = System.IO.Path.GetExtension(path);

                    if ((extension.ToLower() == ".jpg") || (extension.ToLower() == ".jpeg") || (extension.ToLower() == ".png"))
                    {


                      
                        /*       InputUrl = SiteFolder + "photo.aspx?imageurl=" + imagefullurl + "&name=" + imagename + "&output_path=" + outputdir + @"\";  //output path for article  control to generate links
           
                               OutputUrl = outputdir + picsubfolder + "/" + imagename + ".html";  */

                        InputUrl = SiteFolder + "slide.aspx?imageurl=" + imagefullurl + "&name=" + imagename + "&output_path=" + outputdir + @"\";  //output path for article  control to generate links
                        OutputUrl = outputdir + picsubfolder + "/" + imagename + ".html";
                        i++;

                  //      Response.Write("Inputurl = " + InputUrl + "<br/>");



                        //   Response.Write("<br/>");
                        //  Response.Write(OutputUrl);


                        GenerateHTML(InputUrl, OutputUrl);


                    }

                }
                else
                {
                    Console.WriteLine("No rows found.");
                }




            }  // for


            //      Response.Write("input dir = " + inputdir + @"\" + picsubfolder + @"\pictures.list");

            //  This read pictures.list. You can specify picture filename in this file.
            if (File.Exists(inputdir + @"\" + picsubfolder + @"\slides.list"))
            {


                System.IO.StreamReader file =
                   new System.IO.StreamReader(inputdir + @"\" + picsubfolder + @"\slides.list");
                while ((imageurl = file.ReadLine()) != null)
                {
                    //name = url; // remove .jpg


                    imagename = imageurl.Replace(".jpg", "");
                    imagename = imagename.Replace(".jpeg", "");
                    imagename = imagename.Replace(".png", "");
                    imagename = imagename.Replace(".JPG", "");
                    imagename = imagename.Replace(".JPEG", "");
                    imagename = imagename.Replace(".PNG", "");
                    /* works for 3 character extension
                                        imagename = imageurl.Remove(imageurl.Length - 4, 4); */

                    imagefullurl = ImagePath + Global.photopath + imageurl;

                    //      InputUrl = SiteFolder + "photo.aspx?imageurl=" + imagefullurl + "&name=" + imagename + "&output_path=" + picdir + @"\";

                    //    OutputUrl = outputdir + picsubfolder + "/" + imagename + ".html";


                    InputUrl = SiteFolder + "slide.aspx?imageurl=" + imagefullurl + "&name=" + imagename + "&output_path=" + picdir + @"\";

                    OutputUrl = outputdir + picsubfolder + "/" + imagename + ".html";
                    Response.Write("slide = " + InputUrl);

                    GenerateHTML(InputUrl, OutputUrl);

                }

                file.Close();


            }

        }
        catch (Exception e)
        {
            Response.Write("Exception is : " + e.Message);
        }


    }


    protected void GenerateArticle(string inputdir, string outputdir, string subfolder)
    {




        string localfolder = local_path;

        string dir = inputdir + subfolder;
        string OutputFolder = outputdir + subfolder + @"\" ; // to pass article so that it can create sidelink




  //      Response.Write("<br/> OutputFolder = " + OutputFolder);
        try
        {
            string[] fileEntries = Directory.GetFiles(dir);
            int i = 0;


            foreach (string path in fileEntries)
            {

                
                string url;
                string name;
                string extension;
                string fullurl;

                if (File.Exists(path))
                {
                    // This path is a file

                    url = System.IO.Path.GetFileName(path);
                    name = System.IO.Path.GetFileNameWithoutExtension(path);

                    fullurl = inputdir + subfolder + "\\" + url;
                    extension = System.IO.Path.GetExtension(path);

                 //   Response.Write("<br/> Path = " + path);
                    if ((extension.ToLower() == ".txt") ||  (extension.ToLower() == ".htm"))
                    {

                        
                     //   InputUrl = SiteFolder + "article.aspx?url=" + path + "&name=" + name + "&output_path=" + OutputFolder ;

                        InputUrl = SiteFolder + "article.aspx?url=" + path + "&name=" + name + "&output_path=" + OutputFolder + "&local_path=" + localfolder + "&subfolder=" + subfolder + "&pic_path=" + pic_path + "&navigate_path=" + navigate_path ;

                     //    Response.Write(InputUrl);
                        OutputUrl = outputdir + subfolder + "/" + name + ".html";




                      //  InputUrl = SiteFolder + "photos-dir.aspx?local_path=" + localfolder + "&subfolder=" + subfolder + "&pic_path=" + pic_path + "&navigate_path=" + navigate_path + "&output_path=" + OutputFolder + subfolder + @"\";

                     

                           Response.Write("url = " + InputUrl + "<br/> " + OutputUrl);
                     //   GenerateHTML(InputUrl, OutputUrl); // Write gallery page







                        i++;

                        //   Response.Write("<br/>");
                        //  Response.Write(OutputUrl);

            //            Response.Write("<br/> InputUrl : " + InputUrl + " AND " + OutputUrl);
                      GenerateHTML(InputUrl, OutputUrl);


                    }

                }
                else
                {
                    Console.WriteLine("No rows found.");
                }




            }  // for



        }
        catch (Exception e)
        {
            Response.Write("Exception is : " + e.Message);
        }


    }


    protected void Generateholidays(string year)
    {
        InputFolder = SiteFolder ;

        InputUrl = InputFolder + "holidays.aspx?festival=ThanksGiving" ;
        OutputUrl = OutputFolder + datefolder + @"\" + "index.html";
        GenerateHTML(InputUrl, OutputUrl);

        InputUrl = InputFolder + "holidays.aspx?country=USA&year=" + year;
        OutputUrl = OutputFolder + datefolder + @"\" + "USA.html" ;
        GenerateHTML(InputUrl, OutputUrl);

        InputUrl = InputFolder + "holidays.aspx?country=India&year=" + year;
        OutputUrl = OutputFolder + datefolder + @"\" + "India.html";
        GenerateHTML(InputUrl, OutputUrl);

        InputUrl = InputFolder + "holidays.aspx?country=China&year=" + year;
        OutputUrl = OutputFolder + datefolder + @"\" + "China.html";
        GenerateHTML(InputUrl, OutputUrl);

        InputUrl = InputFolder + "holidays.aspx?country=UK&year=" + year;
        OutputUrl = OutputFolder + datefolder + @"\" +  "UK.html";
        GenerateHTML(InputUrl, OutputUrl);

    }
    protected void GeneratePhotos(string size)
    {
        InputUrl = InputFolder + "photos.aspx?topic=Diwali";
        OutputUrl = OutputFolder + "wallpapers\\index.html";
        GenerateHTML(InputUrl, OutputUrl);
        /*

                InputUrl = InputFolder + "photos.aspx?topic=Dusshera";
                OutputUrl = OutputFolder + "wallpapers\\Dusshera.html";
                GenerateHTML(InputUrl, OutputUrl);

                InputUrl = InputFolder + "photos.aspx?topic=Diwali";
                OutputUrl = OutputFolder + "wallpapers\\Diwali.html";
                GenerateHTML(InputUrl, OutputUrl);




                InputUrl = InputFolder + "photos.aspx?topic=Karwa Chauth";
                OutputUrl = OutputFolder + "wallpapers\\Karwa Chauth.html";
                GenerateHTML(InputUrl, OutputUrl);

                InputUrl = InputFolder + "photos.aspx?topic=New Year";
                OutputUrl = OutputFolder + "wallpapers\\New Year.html";
                GenerateHTML(InputUrl, OutputUrl);

                InputUrl = InputFolder + "photos.aspx?topic=Sankranti";
                OutputUrl = OutputFolder + "wallapapers\Sankranti.html";
                GenerateHTML(InputUrl, OutputUrl);

                InputUrl = InputFolder + "photos.aspx?topic=Pongal";
                OutputUrl = OutputFolder + "wallpapers\\Pongal.html";
                GenerateHTML(InputUrl, OutputUrl);

                InputUrl = InputFolder + "photos.aspx?topic=Lohri";
                OutputUrl = OutputFolder + "pictures\\Lohri.html";
                GenerateHTML(InputUrl, OutputUrl);

                InputUrl = InputFolder + "photos.aspx?topic=Rakhi";
                OutputUrl = OutputFolder + "wallpapers\\Rakhi.html";
                GenerateHTML(InputUrl, OutputUrl);

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
                        //    Response.Write(InputUrl);
                            OutputUrl = OutputFolder + "wallpapers\\" + reader["name"].ToString() + ".html";
                            //     OutputUrl = OutputFolder + reader["country"].ToString() + "\\" + "cities-in-" + reader["Region"].ToString() + ".html";

                     //       Response.Write("<br/>");
                     //       Response.Write(OutputUrl);
                     //       Response.Write("<br/>");
                            //   InputUrl = InputFolder + reader.["statename"].tostring();
                            //     Console.WriteLine("{0}\t{1}", reader.GetInt32(0), reader.GetString(1));
                            GenerateHTML(InputUrl, OutputUrl);




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
            Response.Write("Exception is : " + e.Message);
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
                    cmd.Parameters.AddWithValue("@Continent", "all");
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
                        //    Response.Write(InputUrl);
                        //    Response.Write("<br/>");
                        //    Response.Write(OutputUrl);
                        //    Response.Write("<br/>");
                            //   InputUrl = InputFolder + reader.["statename"].tostring();
                            //     Console.WriteLine("{0}\t{1}", reader.GetInt32(0), reader.GetString(1));
                            GenerateHTML(InputUrl, OutputUrl);




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
                    cmd.Parameters.AddWithValue("@Country", "all");

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
                            InputUrl = InputFolder + "default.aspx?country=" + reader["country"].ToString();
                            OutputUrl = OutputFolder + reader["continent"].ToString() + "\\" + reader["country"].ToString() + "\\index.html";


                     //       Response.Write(InputUrl);
                     //       Response.Write("<br/>");
                     //       Response.Write(OutputUrl);
                     //       Response.Write("<br/>");

                            GenerateHTML(InputUrl, OutputUrl);


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


        try
        {

            // string sp = "regions_search";
            string sp = "regions_v2";


            string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Country", Global.Country.ToString());

                    cmd.Parameters.AddWithValue("@n", 100);
                    cmd.Parameters.AddWithValue("@SortOrder", 3);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();



                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            InputUrl = InputFolder + "default.aspx?continent=" + reader["continent"].ToString() + "&country=" + reader["country"].ToString() + "&statename=" + reader["Region"].ToString();
                            OutputUrl = OutputFolder + reader["continent"].ToString() + "\\" + reader["country"].ToString() + "\\" + reader["Region"].ToString() + "\\index.html";
                            GenerateHTML(InputUrl, OutputUrl);



                            //     OutputUrl = OutputFolder + reader["country"].ToString() + "\\" + "cities-in-" + reader["Region"].ToString() + ".html";
                        //    Response.Write(InputUrl);
                        //    Response.Write("<br/>");
                        //    Response.Write(OutputUrl);
                        //    Response.Write("<br/>");
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

        InputFolder = SiteFolder ;
        string citiesfolder = OutputFolder +  @"content\" ;
        int count = 25;

        try
        {
            string sp = "cities_search_v2";


            string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;


            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Continent", continent);
                    cmd.Parameters.AddWithValue("@Country", country);
                    cmd.Parameters.AddWithValue("@Region", statename);
                 //   cmd.Parameters.AddWithValue("@n", 5000);
                    cmd.Parameters.AddWithValue("@n", count);
                    cmd.Parameters.AddWithValue("@SortOrder", 3);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();



                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            InputUrl = InputFolder + "city.aspx" + "?city=" + reader["city"].ToString();
                            OutputUrl = citiesfolder + reader["country"].ToString() + @"\" + reader["city"].ToString() + @"\index.html";
                           // OutputUrl = OutputFolder + @"content\"  + reader["country"].ToString() + @"\" + reader["region"].ToString() + "\\" + reader["city"].ToString() + "\\index.html";
                           
                            Response.Write(InputUrl);
                      //      Response.Write("<br/>");
                      //      Response.Write(OutputUrl);
                      //      Response.Write("<br/>");
                            GenerateHTML(InputUrl, OutputUrl);


                     //       InputUrl = InputFolder + "about.aspx?city=" + reader["city"].ToString();
                     //       OutputUrl = OutputFolder + reader["region"].ToString() + "\\" + reader["city"].ToString() + "\\about.html";
                     //       GenerateHTML(InputUrl, OutputUrl);


                     //       InputUrl = InputFolder + "list.aspx?city=" + reader["city"].ToString();
                     //       OutputUrl = OutputFolder + reader["region"].ToString() + "\\" + reader["city"].ToString() + "\\attractions.html";
                     //       GenerateHTML(InputUrl, OutputUrl);
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
        InputFolder = SiteFolder;
        string citiesfolder = OutputFolder + @"content\";
        int count = 100;

        Response.Write("In Places <br/>");
        try
        {
            string sp = "best_tourist_places_search_v5";


            string connect = ConfigurationManager.ConnectionStrings["films"].ConnectionString;


            using (SqlConnection conn = new SqlConnection(connect))
            {

                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {

                    Response.Write(" values : " + continent + " ," + country + " ," + state + " ," + statename + " ," + city + " ," + category + " ," + subcategory + "<br/>"); 

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Continent", continent);
                    cmd.Parameters.AddWithValue("@Country", country);

                    cmd.Parameters.AddWithValue("@State", state);
                    cmd.Parameters.AddWithValue("@Statename", statename);
                    cmd.Parameters.AddWithValue("@city", city);
                    cmd.Parameters.AddWithValue("@Category", category);
                    cmd.Parameters.AddWithValue("@SubCategory", subcategory);
                    cmd.Parameters.AddWithValue("@n", count);
                    cmd.Parameters.AddWithValue("@SortOrder", 1);



                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();



                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                          
                            InputUrl = InputFolder + "place.aspx" + "?country=" + reader["country"].ToString() + "&placename=" + reader["biz_name"].ToString();
                         //   OutputUrl = OutputFolder + @"content\" + reader["country"].ToString() + @"\" + reader["statename"].ToString() + @"\" + reader["e_city"].ToString() + @"\" + reader["biz_name"].ToString() + ".html";
                            OutputUrl = citiesfolder +  reader["country"].ToString() + @"\" + reader["e_city"].ToString() + @"\" + reader["biz_name"].ToString() + ".html";
                            // Console.WriteLine("{0}\t{1}", reader.GetInt32(0), reader.GetString(1));
                            Response.Write("Input Url: " + InputUrl);
                       //     Response.Write("<br/>");
                       //     Response.Write(OutputUrl);
                       //     Response.Write("<br/>");
                            GenerateHTML(InputUrl, OutputUrl);



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
                cmd.Parameters.AddWithValue("@country", "all");


                cmd.Parameters.AddWithValue("@n", 20);
                cmd.Parameters.AddWithValue("@SortOrder", 1);


                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();



                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        InputUrl = InputFolder + "when-is.aspx?year=" + Convert.ToString(reader["year"]);
                        OutputUrl = OutputFolder + datefolder + @"\" + reader["year"].ToString() + "\\index.html";
                        //     OutputUrl = OutputFolder + reader["country"].ToString() + "\\" + "cities-in-" + reader["Region"].ToString() + ".html";
               //         Response.Write(InputUrl);
               //         Response.Write("<br/>");
               //         Response.Write(OutputUrl);
               //         Response.Write("<br/>");
                        //   InputUrl = InputFolder + reader.["statename"].tostring();
                        //     Console.WriteLine("{0}\t{1}", reader.GetInt32(0), reader.GetString(1));
                        GenerateHTML(InputUrl, OutputUrl);




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
                        OutputUrl = OutputFolder + datefolder + @"\"  + reader["festival"].ToString() + @"\" + reader["year"].ToString().Trim() + ".html";
                        //     OutputUrl = OutputFolder + reader["country"].ToString() + "\\" + "cities-in-" + reader["Region"].ToString() + ".html";
                    //    Response.Write(InputUrl);
                     //   Response.Write("<br/>");
                     //   Response.Write(OutputUrl);
                     //   Response.Write("<br/>");
                        //   InputUrl = InputFolder + reader.["statename"].tostring();
                        //     Console.WriteLine("{0}\t{1}", reader.GetInt32(0), reader.GetString(1));
                        GenerateHTML(InputUrl, OutputUrl);




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
                        OutputUrl = OutputFolder + datefolder + @"\"  + reader["festival"].ToString().Trim() + "\\" + "index.html";
                        //     OutputUrl = OutputFolder + reader["country"].ToString() + "\\" + "cities-in-" + reader["Region"].ToString() + ".html";
             //           Response.Write(InputUrl);
             //           Response.Write("<br/>");
             //           Response.Write(OutputUrl);
             //           Response.Write("<br/>");
                        //   InputUrl = InputFolder + reader.["statename"].tostring();
                        //     Console.WriteLine("{0}\t{1}", reader.GetInt32(0), reader.GetString(1));
                        GenerateHTML(InputUrl, OutputUrl);




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
            GenerateHTML(InputUrl, OutputUrl);

            startyear++;
        }

    }

}