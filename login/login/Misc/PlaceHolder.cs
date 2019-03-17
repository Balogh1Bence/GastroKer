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
        /// <summary>
        /// megpróbáltam átlátszóvá tenni. Színek sikerültek, de átlátszó nem lett.
        /// </summary>
        public void styleSetter()
        {

            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Gray;
            BackColor = Color.Transparent;
            BackColor = System.Drawing.SystemColors.InactiveBorder;
        }



        bool isPlaceHolder = true;
        string _placeHolderText;
        
        /// <summary>
        /// a placeholdertext változó, és annak a settere és gettere
        /// </summary>
        public string PlaceHolderText
        {
            get { return _placeHolderText; }
            set
            {
                _placeHolderText = value;
                setPlaceholder();

            }


        }
        /// <summary>
        /// ha a placeholdertext üres, akkor a get tulajdonsága a szülőobjektum Text tulajdonsága.
        /// </summary>
        public new string Text
        {
            get => isPlaceHolder ? string.Empty : base.Text; 
                    
           

                set => base.Text = value;
            }
       /* public string getText()
        {
            if (isPlaceHolder)
            { return string.Empty; }
            else
            { return base.Text; }

        }*/
        public void setPlaceHolder(string placehold)
        {
            base.Text = placehold;
            
        }


       

        
        /// <summary>
        /// ha a szülőosztálytól örökölt Text tulajdonság üres, akkor a Textet beállítja a placeholderben megadott értékre.
        /// a Text stílusát beállítja szürkére és döltre.
        /// </summary>
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

           /// <summary>
           /// ha megkapja a focust, és van "placeholdere", akkor a Text tulajdonságot üresre állítja. visszaállítja a szöveg stílusát az eredetire.
           /// </summary>
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
        /// <summary>
        /// hozzáadja a gotfocus és lostfocus eseményt, az eseményekre a removeplaceholderrt és a setplaceholdert hívja meg.
        /// </summary>
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
        /// <summary>
        /// tulajdonság, van-e placeholdere. kívülről is elérhető.
        /// </summary>
            public bool hasPlaceHolder
            {
              get { return isPlaceHolder; }
            }
        }
    
}
