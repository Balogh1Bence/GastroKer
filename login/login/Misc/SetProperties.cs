using System;
using System.Collections.Generic;
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
        public void Copy()
        {
           

            DirectoryInfo diSource = new DirectoryInfo(get());
            DirectoryInfo diTarget = new DirectoryInfo(getPath());

            CopyAll(diSource, diTarget);
        }

        public void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            Directory.CreateDirectory(target.FullName);

            // Copy each file into the new directory.
            foreach (FileInfo fi in source.GetFiles())
            {

                fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
            }

            // Copy each subdirectory using recursion.
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
            return n;
        }
        private string get()
        {
            string wanted_path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            /*wanted_path = "@" + '"' + wanted_path + '"';*/
            return wanted_path;
        }
    }
}
