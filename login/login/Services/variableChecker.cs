using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login.Services
{
    public class variableChecker
    {
        string allText;

        public variableChecker()
        {
            getallText();
         
        }

        public void getallText()
        {
            string wanted_path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            DirectoryInfo Source = new DirectoryInfo(wanted_path);

            foreach (FileInfo fi in Source.GetFiles())
            {
                /*if (fi.Name.Contains("Designer"))
                {
                    string[] s = fi.Name.Split('.');
                    forms.Add(s[0]);
                    

                }*/

                allText += System.IO.File.ReadAllText(fi.DirectoryName + "\\" + fi.Name);
                



            }
            

            


            
        }
        public int getOne (string searchFor)
        {
            int i = 0;
         
            int intcounter = 0;
            MatchCollection matches = Regex.Matches(allText, searchFor);
            return matches.Count;
        }
    }
}
