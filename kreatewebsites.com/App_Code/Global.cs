using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public static class Global
{
    /// <summary>
    /// Global variable storing important stuff.
    /// </summary>
    /// 

   static string _list = " ";
    public static string list
    {
        get
        {
            return _list;
        }
        set
        {
            _list = value;
        }
    }

    static string _Continent = "All";

    /// <summary>
    /// Get or set the static important data.
    /// </summary>
    public static string Continent
    {
        get
        {
            return _Continent;
        }
        set
        {
            _Continent = value;
        }
    }

    static string _Country = "All";
    public static string Country
    {
        get
        {
            return _Country;
        }
        set
        {
            _Country = value;
        }
    }



    /// <summary>
    /// Get or set the static important data.
    /// </summary>
    /// 

    static string _Sitename ="Home";

    /// <summary>
    /// Get or set the static important data.
    /// </summary>
    public static string Sitename
    {
        get
        {
            return _Sitename;
        }
        set
        {
            _Sitename = value;
        }
    }


    static string _Siteurl = @"https://www.kreatewebsites.com/";

    /// <summary>
    /// Get or set the static important data.
    /// </summary>
    public static string Siteurl
    {
        get
        {
            return _Siteurl;
        }
        set
        {
            _Siteurl = value;
        }
    }

    static int _adID = 3;
    public static int adID
    {
        get
        {
            return _adID;
        }
        set
        {
            _adID = value;
        }

    }

    static int _genName = 0;
    public static int genName
    {
        get
        {
            return _genName;
        }
        set
        {
            _genName = value;
        }

    }


    static int _genTitle = 0;
    public static int genTitle
    {
        get
        {
            return _genTitle;
        }
        set
        {
            _genTitle = value;
        }

    }

    static int _genArticleurl = 0;
    public static int genArticleurl
    {
        get
        {
            return _genArticleurl;
        }
        set
        {
            _genArticleurl = value;
        }

    }

 //   static string _slidepath = @"https://pictures.kreatewebsites.com/slide16/";
    static string _slidepath = @"https://pictures.kreatewebsites.com/banner/" ;
    //  static string _imagepath = @"";

    /// <summary>
    /// Get or set the static important data.
    /// </summary>
    public static string SlidePath
    {
        get
        {
            return _slidepath;
        }
        set
        {
            _slidepath = value;
        }
    }

    
    static string _imagepath = @"https://pictures.kreatewebsites.com/";

  //  static string _imagepath = "";

    /// <summary>
    /// Get or set the static important data.
    /// </summary>
    public static string ImagePath
    {
        get
        {
            return _imagepath;
        }
        set
        {
            _imagepath = value;
        }
    }




    static string _picpage = @"pictures";
 
    /// <summary>
    /// Get or set the static important data.
    /// </summary>
    public static string picpage
    {
        get
        {
            return _picpage;
        }
        set
        {
            _picpage = value;
        }
    }

    static string _thumbnailpath = @"thumbnails_300/";

    /// <summary>
    /// Get or set the static important data.
    /// </summary>
    public static string thumbnailpath
    {
        get
        {
            return _thumbnailpath;
        }
        set
        {
            _thumbnailpath = value;
        }
    }


    static string _photopath = @"thumbnails_700/";
  

    /// <summary>
    /// Get or set the static important data.
    /// </summary>
    public static string photopath
    {
        get
        {
            return _photopath;
        }
        set
        {
            _photopath = value;
        }
    }

    static string _Placename = null;

    /// <summary>
    /// Get or set the static important data.
    /// </summary>
    public static string Placename
    {
        get
        {
            return _Placename;
        }
        set
        {
            _Placename = value;
        }
    }



    static string _State = "All";

    /// <summary>
    /// Get or set the static important data.
    /// </summary>
    public static string State
    {
        get
        {
            return _State;
        }
        set
        {
            _State = value;
        }
    }

    static string _StateName = "All";

    /// <summary>
    /// Get or set the static important data.
    /// </summary>
    public static string StateName
    {
        get
        {
            return _StateName;
        }
        set
        {
            _StateName = value;
        }
    }


    static string _City = "All";

    /// <summary>
    /// Get or set the static important data.
    /// </summary>
    public static string City
    {
        get
        {
            return _City;
        }
        set
        {
            _City = value;
        }
    }
    static string _Category = "All";

    /// <summary>
    /// Get or set the static important data.
    /// </summary>
    public static string Category
    {
        get
        {
            return _Category;
        }
        set
        {
            _Category = value;
        }
    }


    static string _SubCategory = null;

    /// <summary>
    /// Get or set the static important data.
    /// </summary>
    public static string SubCategory
    {
        get
        {
            return _SubCategory;
        }
        set
        {
            _SubCategory = value;
        }
    }



    static string _Featured = "Karwa Choth";

    /// <summary>
    /// Get or set the static important data.
    /// </summary>
    public static string Featured
    {
        get
        {
            return _Featured;
        }
        set
        {
            _Featured = value;
        }
    }
static string _Keyword = "Karwa Choth";
 public static string Keyword
    {
        get
        {
            return _Keyword;
        }
        set
        {
            _Keyword = value;
        }
    }

   

    
 static string _datefolder = @"when is";
 public static string Datefolder
 {
     get
     {
         return _datefolder;
     }
     set
     {
         _datefolder = value;
     }
 }

 static string _datefolder2 = @"when is";
 public static string Datefolder2
 {
     get
     {
         return _datefolder2;
     }
     set
     {
         _datefolder2 = value;
     }
 }

 static string _slides = "slides";
 public static string SlidesPage
 {
     get
     {
         return _slides;
     }
     set
     {
         _slides = value;
     }
 }
 static string _gallery = "gallery";
 public static string GalleryPage
 {
     get
     {
         return _gallery;
     }
     set
     {
         _gallery = value;
     }

     }

 public static class Slides
 {

     static string _name = "Slides and Banners";
     public static string name
     {
         get
         {
             return _name;
         }
         set
         {
             _name = value;
         }
     }

     static string _pages = @"slides.aspx";
     public static string pages
     {
         get
         {
             return _pages;
         }
         set
         {
             _pages = value;
         }
     }
     static string _page = @"slide.aspx";
     public static string page
     {
         get
         {
             return _page;
         }
         set
         {
             _page = value;
         }
     }
     static string title = "Slides and Banner";
     static string _url = "slides";

     public static string url
     {
         get
         {
             return _url;
         }
         set
         {
             _url = value;
         }
     }
     public static string sizepath = @"";
     public static string thumbnailpath = @"thumbnails_175/";
     public static string defaultpath = @"https://pictures.kreatewebsites.com/banner/";
     public static bool slidegenerate = true;  // use to denote whether to put slides on page or not
     public static bool picturegenerate = true;  // use to put whether to put pictures sections on page or not
     public static bool individualpage = false;  // use to denote whether individual page should be generated for each slide or not
     public static bool includepictures = false; //  If this is false it will use pictures.list and ignore individual pictures
 }


 public static class Pictures
 {

     static string _name = "Pictures";
     public static string name
     {
         get
         {
             return _name;
         }
         set
         {
             _name = value;
         }
     }

     static string _pages = @"photos-dir.aspx";
     public static string pages
     {
         get
         {
             return _pages;
         }
         set
         {
             _pages = value;
         }
     }
     static string _page = @"photo.aspx";
     public static string page
     {
         get
         {
             return _page;
         }
         set
         {
             _page = value;
         }
     }


     static string title = "Pictures";
     static string _url = "pictures";
     public static string url
     {
         get
         {
             return _url;
         }
         set
         {
             _url = value;
         }
     }
     public static string sizepath = @"thumbnails_175/";
     public static string thumbnailpath = @"thumbnails_175/";
     public static string fullpath = null;
     public static int width=500;
     public static int height=0;
     public static string defaultpath = @"https://pictures.kreatewebsites.com/";
     public static bool individualpage = true;  // use to denote whether individual page should be generated for each pictures or not
     public static bool includepictures = false ; //  If this is false it will use pictures.list and ignore individual pictures
     public static int picturescount = 3;

 }


 public static class Gallery
 {

     static string _name = "gallery";
     public static string name
     {
         get
         {
             return _name;
         }
         set
         {
             _name = value;
         }
     }

     static string _pages = @"gallery.aspx";
     public static string pages
     {
         get
         {
             return _pages;
         }
         set
         {
             _pages = value;
         }
     }


     static string title = "Gallery";
     static string _url = "gallery";
     public static string url
     {
         get
         {
             return _url;
         }
         set
         {
             _url = value;
         }
     }


  public static string photoviewer = @"photoviewer.php";
 


     public static string sizepath = @"";
     public static string thumbnailpath = @"thumbnails_300/";
     public static string defaultpath = @"https://pictures.kreatewebsites.com/";
     
     public static bool individualpage = false;
     public static string keyword = "Photos Gallery of" ;
     public static bool includepictures = false; //  If this is false it will use pictures.list and ignore individual pictures
     public static int gallerycount = 3;
     public static int direction = 1;
 }
}

public static class Articles
{


   public static string _articlelist = @"Articlelist.aspx";  // no such page exist as of now.
    public static string Articlelist
    {
        get
        {
            return _articlelist;
        }
        set
        {
            _articlelist = value;
        }
    }






    public static string articlepage = "articles"; //articles.title
    static string _pages = @"Articles.aspx";  // no such page exist as of now.
    public static string pages
    {
        get
        {
            return _pages;
        }
        set
        {
            _pages = value;
        }
    }
    static string _page = @"Article.aspx";
    public static string page
    {
        get
        {
            return _page;
        }
        set
        {
            _page = value;
        }
    }


}
public static class Sitemap
{
    public static string foldernamepage = "folder-names-generate.aspx";
    public static string folderlinkpage = "folder-link-generate.aspx";
    public static string foldernameOutputpage = "foldermap.htm";
    public static string folderlinkOutputpage = "folderlink.htm";
}
public static class Current
{
    /// <summary>
    /// Global variable storing important stuff.
    /// </summary>
    /// 


    static string _Name = "Karwa Choth";
    public static string Name
    {
        get
        {
            return _Name;
        }
        set
        {
            _Name = value;
        }
    }

    static Int16 _Count = 5;
    public static Int16 Count
    {
        get
        {
            return _Count;
        }
        set
        {
            _Count = value;
        }
    }

    static string _Country = null;
    public static string Country
    {
        get
        {
            return _Country;
        }
        set
        {
            _Country = value;
        }
    }

    
    static string _Placename = null;

    /// <summary>
    /// Get or set the static important data.
    /// </summary>
    public static string Placename
    {
        get
        {
            return _Placename;
        }
        set
        {
            _Placename = value;
        }
    }



    static string _State = null;

    /// <summary>
    /// Get or set the static important data.
    /// </summary>
    public static string State
    {
        get
        {
            return _State;
        }
        set
        {
            _State = value;
        }
    }

    static string _StateName = null;

    /// <summary>
    /// Get or set the static important data.
    /// </summary>
    public static string StateName
    {
        get
        {
            return _StateName;
        }
        set
        {
            _StateName = value;
        }
    }


    static string _City = null;

    /// <summary>
    /// Get or set the static important data.
    /// </summary>
    public static string City
    {
        get
        {
            return _City;
        }
        set
        {
            _City = value;
        }
    }
   






}