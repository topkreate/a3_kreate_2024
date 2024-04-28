
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Xml.Linq;
using System.Data.SqlClient;

using System.Collections.Generic;


using System.Net;
using System.IO;


namespace KreateWebsites
{
    public class Batch
    {






       

        public static void Copy(string local_path)
        {

            string subfolder;
            string[] fileEntries = Directory.GetFiles(local_path);



            string[] subdirectoryEntries = Directory.GetDirectories(local_path);

            foreach (string di in Directory.GetDirectories(local_path))
            {
                Console.WriteLine("di = " + di);
                CopyFolder(di, local_path);
            }





        



        }

        public static void CopyFolder(string dir, string local_path)
        {



            // just to check infine loop     if (loopi == 10)  return;   

            // local_path =  dir;
            //  Console.WriteLine("dir = " + dir);
            foreach (string di in Directory.GetDirectories(dir))
            {
                Console.WriteLine("di = " + di);
                GeneratePathFile(di);
                CopyFolder(di, local_path);

            }




        }
        public static void GeneratePathFile(string dir)
        {
            string strCmdText;

            strCmdText = @"/C echo " + dir + @" > " + dir + @"\gallery.path";

            //       strCmdText = @"/C dir " + dir + @" /b *.name *.png " + @" > "  + dir + @"\gallery5.list";
            Console.WriteLine("command = " + strCmdText);
            System.Diagnostics.Process.Start("CMD.exe", strCmdText);
        }
        public static void GeneratePictureList()
        {
        }

        public static void CopyFile(FileInfo fi)
        {

            //    Response.Write("file is " + fi.Name.ToString() );
        }




    }
}






