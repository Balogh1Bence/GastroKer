using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
namespace Gastro
{
    #region Rend
    public class Rend
    {
        #region Member Variables
        protected int _Tkod;
        protected int _Tmenny;
        protected string _Vnev;
        protected DateTime _Vdate;
        #endregion
        #region Constructors
        public Rend() { }
        public Rend(int Tmenny, string Vnev, DateTime Vdate)
        {
            this._Tmenny=Tmenny;
            this._Vnev=Vnev;
            this._Vdate=Vdate;
        }
        #endregion
        #region Public Properties
        public virtual int Tkod
        {
            get {return _Tkod;}
            set {_Tkod=value;}
        }
        public virtual int Tmenny
        {
            get {return _Tmenny;}
            set {_Tmenny=value;}
        }
        public virtual string Vnev
        {
            get {return _Vnev;}
            set {_Vnev=value;}
        }
        public virtual DateTime Vdate
        {
            get {return _Vdate;}
            set {_Vdate=value;}
        }
        #endregion
    }
    #endregion
}