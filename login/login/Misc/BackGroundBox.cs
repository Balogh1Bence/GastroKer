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
                setImg();
            }
        }
        public

     

        

        void setImg()
        {

            Image = Image.FromFile(ImgName);
              
        }

         void setTransparency()
         {   

         }
         void setSizes()
         {
            Height =;
            Width =;
         }
        
   
      

       
    }
}
