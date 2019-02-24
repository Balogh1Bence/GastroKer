using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
namespace login.models
{
    #region Besz
    public class MDBesz
    {
        #region Member Variables
        protected int _azon;
        protected string _nev;
        protected int _tel;
        protected string _email;
        protected string _kapcsnev;
        #endregion
        #region Constructors
        public MDBesz() { }
        public MDBesz(int azon, string nev, int tel, string email, string kapcsnev)
        {
            this._azon = azon;
            this._nev = nev;
            this._tel = tel;
            this._email = email;
            this._kapcsnev = kapcsnev;
        }
        #endregion
        #region Public Properties
        public virtual int Azon
        {
            get { return _azon; }
            set { _azon = value; }
        }
        public virtual string Nev
        {
            get { return _nev; }
            set { _nev = value; }
        }
        public virtual int Tel
        {
            get { return _tel; }
            set { _tel = value; }
        }
        public virtual string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public virtual string Kapcsnev
        {
            get { return _kapcsnev; }
            set { _kapcsnev = value; }
        }
        #endregion
    }
    #endregion
}