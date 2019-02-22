using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
namespace Gastro
{
    #region Vevok
    public class MDVevok
    {
        #region Member Variables
        protected int _azon;
        protected string _nev;
        protected int _adoazon;
        protected int _banksz;
        protected int _tel;
        protected bool _dolg;
        protected bool _torzs;
        protected int _vasmenny;
        protected string _felh;
        protected string _jelsz;
        protected string _email;
        #endregion
        #region Constructors
        public MDVevok() { }
        public MDVevok(int azon, string felh, string jelsz)
        {
            this._azon = azon;
            this._felh = felh;
            this._jelsz = jelsz;
        }
        public MDVevok(int azon ,string nev, int adoazon, int banksz, int tel, bool dolg, bool torzs, int vasmenny, string felh, string jelsz, string email)
        {
            this._azon = azon;
            this._nev = nev;
            this._adoazon = adoazon;
            this._banksz = banksz;
            this._tel = tel;
            this._dolg = dolg;
            this._torzs = torzs;
            this._vasmenny = vasmenny;
            this._felh = felh;
            this._jelsz = jelsz;
            this._email = email;
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
        public virtual int Adoazon
        {
            get { return _adoazon; }
            set { _adoazon = value; }
        }
        public virtual int Banksz
        {
            get { return _banksz; }
            set { _banksz = value; }
        }
        public virtual int Tel
        {
            get { return _tel; }
            set { _tel = value; }
        }
        public virtual bool Dolg
        {
            get { return _dolg; }
            set { _dolg = value; }
        }
        public virtual bool Torzs
        {
            get { return _torzs; }
            set { _torzs = value; }
        }
        public virtual int Vasmenny
        {
            get { return _vasmenny; }
            set { _vasmenny = value; }
        }
        public virtual string Felh
        {
            get { return _felh; }
            set { _felh = value; }
        }
        public virtual string Jelsz
        {
            get { return _jelsz; }
            set { _jelsz = value; }
        }
        public virtual string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        #endregion
    }
    #endregion
}