using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login.Misc
{
    public class BackGroundBox : PictureBox
    {
        bool isPlaceHolder = true;
        string _ImgName;
        
        public string ImgName
        {
            get { return _ImgName; }
            set
            {
                
                _ImgName = value;
                
               
            }
        }





         private void Back()
        {
            SendToBack();
        }
        public void setImg(string img)
        {
            MessageBox.Show("Test1");
            Image=Image.FromFile(img);
            MessageBox.Show("Test2");
            SizeMode= PictureBoxSizeMode.StretchImage;
            Dock = DockStyle.Fill;
            Back();
              
        }
        
         
         void setSizes(Form f)
         {
            Height =f.Height;
            Width =f.Width;
         }
        
   
      

       
    }
}
