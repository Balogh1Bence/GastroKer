using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace login.Misc
{
    public class SetProperties
    {
        public SetProperties()
        {

        }
        public void setDataBases()
        {
            ProcessStartInfo apa = new ProcessStartInfo();
            apa.Verb = "runas";
            apa.CreateNoWindow = true;
            apa.UseShellExecute = false;
            apa.FileName = "c:\\xampp\\apache_start.bat";
            apa.WindowStyle = ProcessWindowStyle.Hidden;
            Process exeProcess = Process.Start(apa);
            ProcessStartInfo apa2 = new ProcessStartInfo();
            apa2.Verb = "runas";
            apa2.CreateNoWindow = true;
            apa2.UseShellExecute = false;
            apa2.FileName = "c:\\xampp\\mysql_start.bat";
            apa2.WindowStyle = ProcessWindowStyle.Hidden;
            Process exeProces = Process.Start(apa2);
            
            

            string path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            path += "\\Misc\\felh.sql";
            string path2 = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            path2 += "\\Misc\\gastro.sql";
            string text = System.IO.File.ReadAllText(path);
            
            string text2 = System.IO.File.ReadAllText(path2);
            
            string connStr = "SERVER=\"localhost\";"
               + "UID=\"root\";"
               + "PASSWORD=\"\";"
               + "PORT=\"3306\";";
            var conn = new MySqlConnection(connStr);
                var cmd = conn.CreateCommand();
            
                conn.Open();
                cmd.CommandText = "CREATE DATABASE IF NOT EXISTS `felh`;";
                cmd.ExecuteNonQuery();
            cmd.CommandText = "CREATE DATABASE IF NOT EXISTS `gastro`;";
            cmd.ExecuteNonQuery();


            string conF = "SERVER =\"localhost\";"
               + "DATABASE=\"felh\";"
               + "UID=\"root\";"
               + "PASSWORD=\"\";"
               + "PORT=\"3306\";";
            var conne = new MySqlConnection(conF);
            conne.Open();
            cmd.CommandText = text;
            cmd.ExecuteNonQuery();
            string conG = "SERVER =\"localhost\";"
               + "DATABASE=\"gastro\";"
               + "UID=\"root\";"
               + "PASSWORD=\"\";"
               + "PORT=\"3306\";";
            var connec = new MySqlConnection(conG);
            connec.Open();
            cmd.CommandText = text;
            cmd.ExecuteNonQuery();

        }
        public void Copy()
        {
            setDataBases();
            DirectoryInfo diSource = new DirectoryInfo(get());

            DirectoryInfo diTarget = new DirectoryInfo(getPath());
          

            CopyAll(diSource, diTarget);
        }

        public void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            Directory.CreateDirectory(target.FullName);

           
            foreach (FileInfo fi in source.GetFiles())
            {

                fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
            }

            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir =
                    target.CreateSubdirectory(diSourceSubDir.Name);
                CopyAll(diSourceSubDir, nextTargetSubDir);
            }
        }

        public string GetHtdocsDirectory()
        {
            string text = System.IO.File.ReadAllText(@"C:\xampp\apache\conf\httpd.conf");
            return text;
        }
        private string getPath()
        {
            string file = GetHtdocsDirectory();

            string myCapturedText = "";
            Regex regex = new Regex("(.*):/(.*)/htdocs");
            int i = 0;

            if (regex.IsMatch(file))
            {
                myCapturedText = regex.Match(file).Groups[i].Value;


            }

            string[] s = myCapturedText.Split('"');

            string n = s[1];
            /*n = "@" + '"' + n + '"';*/
            n+= "\\WebSite";
            return n;
        }
        private string get()
        {
            string wanted_path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            /*wanted_path = "@" + '"' + wanted_path + '"';*/
            wanted_path += "\\WebSite";
            return wanted_path;
        }
    }
}
