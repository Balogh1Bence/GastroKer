using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
namespace login.models
{
    #region Regitermekek
    public class Regitermekek
    {
        #region Member Variables
        int _Tkod;
        string _Tnev;
        int _Tar;
        int _Tkeszl;
        string _Tmert;
        int _Tkatkod;
        int _Tvonkod;
        DateTime _Tszavido;
        bool _Tegalizalte;
        #endregion
        #region Constructors
        public Regitermekek() { }
        public Regitermekek(int Tkod, string Tnev, int Tar, int Tkeszl, string Tmert, int Tkatkod, int Tvonkod, DateTime Tszavido, bool Tegalizalte)
        {
            this._Tkod = Tkod;
            this._Tnev = Tnev;
            this._Tar = Tar;
            this._Tkeszl = Tkeszl;
            this._Tmert = Tmert;
            this._Tkatkod = Tkatkod;
            this._Tvonkod = Tvonkod;
            this._Tszavido = Tszavido;
            this._Tegalizalte = Tegalizalte;
        }
        #endregion
        #region Public Properties
        public virtual int Tkod
        {
            get { return _Tkod; }
            set { _Tkod = value; }
        }
        public virtual string Tnev
        {
            get { return _Tnev; }
            set { _Tnev = value; }
        }
        public virtual int Tar
        {
            get { return _Tar; }
            set { _Tar = value; }
        }
        public virtual int Tkeszl
        {
            get { return _Tkeszl; }
            set { _Tkeszl = value; }
        }
        public virtual string Tmert
        {
            get { return _Tmert; }
            set { _Tmert = value; }
        }
        public virtual int Tkatkod
        {
            get { return _Tkatkod; }
            set { _Tkatkod = value; }
        }
        public virtual int Tvonkod
        {
            get { return _Tvonkod; }
            set { _Tvonkod = value; }
        }
        public virtual DateTime Tszavido
        {
            get { return _Tszavido; }
            set { _Tszavido = value; }
        }
        public virtual bool Tegalizalte
        {
            get { return _Tegalizalte; }
            set { _Tegalizalte = value; }
        }
        #endregion
    }
    #endregion
}

