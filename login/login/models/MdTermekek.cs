using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace login.models
{
    public class MdTermekek
    {

        int Tkod;
        string Tnev;
        int Tar;
        int Tkeszl;
        string Tmert;
        int Tkatkod;
        int Tvonkod;
        DateTime Tszavido;
  
        bool Tegalizalte;
        public int getTkod() { return Tkod; }
        public string getTNev() { return Tnev; }
        public int getTar() { return Tar; }
        public int getTkeszl() { return Tkeszl; }
        public string getMert() { return Tmert; }
        public int getTkatkod() { return Tkatkod; }
        public int getTvonkod() { return Tvonkod; }
        public DateTime getSzavido() { return Tszavido; }
   
        public bool getTegalizalte() { return Tegalizalte; }
        public void setTkod(int Tkod) { this.Tkod = Tkod; }
        public void setTnev(string Tnev) { this.Tnev = Tnev; }
        public void setTar(int Tar) { this.Tar = Tar; }
        public void setTkeszl(int Tkeszl) { this.Tkeszl = Tkeszl; }
        public void setTmert(string Tmert) { this.Tmert = Tmert; }
        public void setTkatkod(int Tkatkod) { this.Tkatkod = Tkatkod; }
        public void setTvonkod(int Tvonkod) { this.Tvonkod = Tvonkod; }
        public void setTSzavido(DateTime Tszavido) { this.Tszavido = Tszavido; }

        public void setTegaliz(bool Tegalizalte) { this.Tegalizalte = Tegalizalte; }

        public MdTermekek(int tkod, string tnev, int tar, int tkeszl, string tmert, int tkatkod, int tvonkod, DateTime tszavido, bool tegalizalte)
        {
            Tkod = tkod;
            Tnev = tnev;
            Tar = tar;
            Tkeszl = tkeszl;
            Tmert = tmert;
            Tkatkod = tkatkod;
            Tvonkod = tvonkod;
            Tszavido = tszavido;
            Tegalizalte = tegalizalte;
        }

        public override string ToString()
        {
            return Tkatkod + " " + Tnev + " " + Tar + " " + Tkatkod + " " + Tmert + " " + Tkatkod + " " + Tvonkod + " " + Tszavido+ " " + Tegalizalte;
        }
    }
}
