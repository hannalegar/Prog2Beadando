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
        //    Feldolgoz feldogoz1 = new Feldolgoz("Proba.txt");
        //    feldogoz1.Beolvas();
        //    feldogoz1.Letrehoz();
        //    feldogoz1.GrafotLetrehoz();
        //    feldogoz1.Kikotes();
        //    feldogoz1.Backtrack(feldogoz1.AlkatreszKikotes);

            //feldogoz1.Teszt();

            try
            {
                Feldolgoz feldolgoz2 = new Feldolgoz("Proba3.txt");
                feldolgoz2.Beolvas();
                feldolgoz2.Letrehoz();
                feldolgoz2.GrafotLetrehoz();
                feldolgoz2.Kikotes();
                feldolgoz2.Backtrack(feldolgoz2.AlkatreszKikotes);
            }
            catch (NemTalaltAlkatresztException e)
            {
                Console.WriteLine("Nem talált alkatrészt: " +  e.Alkatresz.Nev);
            }
        }
    }
}
