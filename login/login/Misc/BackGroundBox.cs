﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login.Misc
{
    public class BackGroundBox : PictureBox
    {/// <summary>
    /// az osztályt azért hoztam létre, hogy ne kelljen mindent beállítani egy pictureboxnak.
    /// </summary>
        bool isPlaceHolder = true;
        string _ImgName;
        /// <summary>
        /// beállítja képnek a kapott útvonal képét.
        /// </summary>
        public string ImgName
        {
            get { return _ImgName; }
            set
            {
                
                _ImgName = value;
                
               
            }
        }




        /// <summary>
        /// hátra küldi
        /// </summary>
         private void Back()
        {
            SendToBack();
        }
        public void setImg(string img)
        {
           
            Image=Image.FromFile(img);
           
            SizeMode= PictureBoxSizeMode.StretchImage;
            Dock = DockStyle.Fill;
            Back();
              
        }
        
         
   
      

       
    }
}
