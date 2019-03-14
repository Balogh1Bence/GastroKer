using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login.Misc
{

   
    public class PlaceHolderTextBox : TextBox
        {
            public void styleSetter()
            {

            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Gray;
            BackColor = Color.Transparent;
            BackColor = System.Drawing.SystemColors.InactiveBorder;
        }
        private System.ComponentModel.IContainer components = null;


        bool isPlaceHolder = true;
            string _placeHolderText;
        
            public string PlaceHolderText
            {
                get { return _placeHolderText; }
                set
                {
                    _placeHolderText = value;
                    setPlaceholder();
               
                }

            
            }
       
            public new string Text
            {
                get => isPlaceHolder ? string.Empty : base.Text;
                set => base.Text = value;
            }



        /*
        this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        this.BackColor = Color.Transparent;*/
        //when the control loses focus, the placeholder is shown
        private void setPlaceholder()
            {
            /*if (Text != null)
            { return; }*/
          
            if (string.IsNullOrEmpty(base.Text))
                {
                    base.Text = PlaceHolderText;
                    
                    this.ForeColor = Color.Gray;
                    this.Font = new Font(this.Font, FontStyle.Italic);
                    isPlaceHolder = true;
                styleSetter();
                }
            }

            //when the control is focused, the placeholder is removed
            private void removePlaceHolder()
            {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            
            /*if (Text != null)
            { return; }*/
            if (isPlaceHolder)
                {
                    base.Text = "";
                    this.ForeColor = System.Drawing.SystemColors.WindowText;
                    this.Font = new Font(this.Font, FontStyle.Regular);
                    isPlaceHolder = false;
                styleSetter();
                }
            }
            public PlaceHolderTextBox()
            {
                
                GotFocus += removePlaceHolder;
                LostFocus += setPlaceholder;
           
            }

            private void setPlaceholder(object sender, EventArgs e)
            {
                setPlaceholder();
            }

            private void removePlaceHolder(object sender, EventArgs e)
            {
                removePlaceHolder();
            }
            public bool hasPlaceHolder
            {
              get { return isPlaceHolder; }
            }
        }
    
}
