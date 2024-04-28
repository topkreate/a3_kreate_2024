using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



public static class LocalPath
{

    static string _InputPath = @"C:\e\a3_input\kreatewebsites.com\input\";

    /// <summary>
    /// Get or set the static important data.
    /// </summary>
    public static string InputPath
    {
        get
        {
            return _InputPath;
        }
        set
        {
            _InputPath = value;
        }
    }



  //  static string _OutPutPath = @"C:\e\a1_sites\3\kreatewebsites.com\output\";
    static string _OutPutPath = @"C:\e\a2_generated_sites\kreatewebsites.com\output\";

    /// <summary>
    /// Get or set the static important data.
    /// </summary>
    public static string OutPutPath
    {
        get
        {
            return _OutPutPath;
        }
        set
        {
            _OutPutPath = value;
        }
    }

   static string _ComputerPath = LocalPath.OutPutPath + @"content\";


  //  static string _ComputerPath = LocalPath.OutPutPath ;
    /// <summary>
    /// Get or set the static important data.
    /// </summary>
    public static string ComputerPath
    {
        get
        {
            return _ComputerPath;
        }
        set
        {
            _ComputerPath = value;
        }
    }

    static string _Datefolder =  "holidays";

    /// <summary>
    /// Get or set the static important data.
    /// </summary>
    public static string Datefolder
    {
        get
        {
            return _Datefolder;
        }
        set
        {
            _Datefolder = value;
        }
    }


    static string _ImagePath =  @"C:\e\a1_sites\pictures.1000\slide3\";

    /// <summary>
    /// Get or set the static important data.
    /// </summary>
    public static string ImagePath
    {
        get
        {
            return _ImagePath;
        }
        set
        {
            _ImagePath = value;
        }
    }

    static string _SlidePath = @"C:\e\a1_sites\pictures.1000\slide3\";

    /// <summary>
    /// Get or set the static important data.
    /// </summary>
    public static string SlidePath
    {
        get
        {
            return _SlidePath;
        }
        set
        {
            _SlidePath = value;
        }
    }

}

