using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog2_Beadando
{

    // abstract motor, légszűrú, fékrendszer, elektronika, válto

    public enum Tipus
    {
        motor, legszuro, fekrendszer, elektronika, valto, 
    }

    class Program
    {
        static void Main(string[] args)
        {
            Feldolgoz feldogoz1 = new Feldolgoz("Proba.txt");
            feldogoz1.Beolvas();
            feldogoz1.Letrehoz();
            feldogoz1.GrafotLetrehoz();
            feldogoz1.Kikotes();

            feldogoz1.Teszt();
         
        }
    }
}
