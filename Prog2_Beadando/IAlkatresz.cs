using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog2_Beadando
{

    interface IAlkatresz
    {
        //Az alkatrész abstract osztályban, ami megvalósítja az interfészt le van írva minden, hogy mi micsoda illetve hogy mire való, iért lett létrehozva

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
