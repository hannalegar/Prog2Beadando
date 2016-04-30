using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog2_Beadando
{

    interface IAlkatresz
    {
        string Nev { get; set; }
        int Suly { get; set; }
        int Ar { get; set; }
        Tipus Tipus { get; set; }
        bool MukodoKepes { get; set; }
        List<Motor> KompatibilisMotorok { get; }
        List<Elektronika> KompatibilisElektronika { get; }
        List<Fekrendszer> KompatibilisFekrendszer { get; }
        List<Valto> KompatibilisValto { get; }
        List<Legszuro> KompatibilisLegszuro { get; }
        void Beepit(Auto auto);
        void Elromlik();
        void KompatibilisHozzaAd(IAlkatresz alkatresz);
    }
}
