using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
namespace login.Misc
{


    public class PlaceHolderTextBox : TextBox
    {
        //az ISupportInitialize az határozza meg, hogy a designer kezdheti-e ezzel a controllal a betöltést. 
        //Ez kell ahhoz, hogy a formok ne mutassanak hibát, ha csak fehúztam a placeholdereket.
        /// <summary>
        /// megpróbáltam átlátszóvá tenni. Színek sikerültek, de átlátszó nem lett.
        /// </summary>
        public void styleSetter()
        {

            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Gray;
            BackColor = Color.Transparent;
            BackColor = SystemColors.InactiveBorder;
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
        /// ha a placeholdertext üres, akkor a get a szülőobjektum Text tulajdonságát adja vissza.
        /// </summary>
     
        public string getText()
        {
            if (isPlaceHolder)
            { return string.Empty; }
            else
            { return base.Text; }

        }
        public string setText(string text)
        {
            return base.Text= text;
        }
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
            
           
            if (isPlaceHolder)
                {
                    base.Text = "";
                    ForeColor = SystemColors.WindowText;
                    Font = new Font(Font, FontStyle.Regular);
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
