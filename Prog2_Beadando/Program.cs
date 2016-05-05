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
            feldogoz1.Backtrack(feldogoz1.AlkatreszKikotes, feldogoz1.Auto, feldogoz1.AlkatreszKikotes);
            feldogoz1.AutokatLetrehoz();

            feldogoz1.Teszt();

            //try
            //{
            //    Feldolgoz feldolgoz2 = new Feldolgoz("Proba3.txt");
            //    feldolgoz2.Beolvas();
            //    feldolgoz2.Letrehoz();
            //    feldolgoz2.GrafotLetrehoz();
            //    feldolgoz2.Kikotes();
            //    feldolgoz2.AutokatLetrehoz();

            //    feldolgoz2.Teszt();

            //    feldolgoz2.Backtrack(feldolgoz2.AlkatreszKikotes, feldolgoz2.Auto, feldolgoz2.AlkatreszKikotes);
                

            //}
            //catch (NemTalaltAlkatresztException e)
            //{
            //    Console.WriteLine("Nem talált alkatrészt: " + e.Alkatresz.Nev);
            //}

            //try
            //{
            //    Feldolgoz feldolgoz3 = new Feldolgoz("Proba2.txt");
            //    feldolgoz3.Beolvas();
            //    feldolgoz3.Letrehoz();
            //    feldolgoz3.GrafotLetrehoz();
            //    feldolgoz3.Kikotes();
            //    feldolgoz3.AutokatLetrehoz();

            //    feldolgoz3.Teszt();

            //    feldolgoz3.Backtrack(feldolgoz3.AlkatreszKikotes, feldolgoz3.Auto, feldolgoz3.AlkatreszKikotes);

            //}
            //catch (NemTalaltAlkatresztException e)
            //{
            //    Console.WriteLine("Nem talált alkatrészt: " + e.Alkatresz.Nev);
            //}

            try
            {
                Feldolgoz feldogoz4 = new Feldolgoz("Proba4.txt");
                feldogoz4.Beolvas();
                feldogoz4.Letrehoz();
                feldogoz4.GrafotLetrehoz();
                feldogoz4.AutokatLetrehoz();
                feldogoz4.Teszt();

                Console.WriteLine("A legkönnyebb auto súlya: " + feldogoz4.LegkonyebbAuto(feldogoz4.Autok).AutoSulya());
                Console.WriteLine("motorja: " + feldogoz4.LegkonyebbAuto(feldogoz4.Autok).Motor.Nev);
                Console.WriteLine("féke: " + feldogoz4.LegkonyebbAuto(feldogoz4.Autok).Fekrendszer.Nev);
                Console.WriteLine("légsz: " + feldogoz4.LegkonyebbAuto(feldogoz4.Autok).Legszuro.Nev);
                Console.WriteLine("váltó: " + feldogoz4.LegkonyebbAuto(feldogoz4.Autok).Valto.Nev);
                Console.WriteLine("elektr.: " + feldogoz4.LegkonyebbAuto(feldogoz4.Autok).Elektronika.Nev);

                Console.WriteLine("A legolcsobb auto ára: " + feldogoz4.LegOlcsobbAuto(feldogoz4.Autok).AutoAra());
                Console.WriteLine("motorja: " + feldogoz4.LegOlcsobbAuto(feldogoz4.Autok).Motor.Nev);
                Console.WriteLine("féke: " + feldogoz4.LegOlcsobbAuto(feldogoz4.Autok).Fekrendszer.Nev);
                Console.WriteLine("légsz: " + feldogoz4.LegOlcsobbAuto(feldogoz4.Autok).Legszuro.Nev);
                Console.WriteLine("váltó: " + feldogoz4.LegOlcsobbAuto(feldogoz4.Autok).Valto.Nev);
                Console.WriteLine("elektr.: " + feldogoz4.LegOlcsobbAuto(feldogoz4.Autok).Elektronika.Nev);

                Console.ReadLine();

            }
            catch (NemTalalNevetException e)
            {
                Console.WriteLine("Ilyen névvel nem talált alkatreszt: " + e.Nev);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }


        }
    }
}
