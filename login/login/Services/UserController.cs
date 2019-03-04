using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login.Services
{
    public class UserController
    {
        List<string> forms;
        

      
        public void getall()
        {
            forms = new List<string>();
            string wanted_path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            DirectoryInfo Source = new DirectoryInfo(wanted_path);

            foreach (FileInfo fi in Source.GetFiles())
            {
                if (fi.Name.Contains("Designer"))
                {
                    string[] s = fi.Name.Split('.');
                    forms.Add(s[0]);
                    

                }
              


            }
        }
    }
}
