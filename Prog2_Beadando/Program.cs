using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
            //Proba.txt, Proba2.txt, Proba3.txt, Proba4.txt <-- tesztelés céljából hoztam létre őket

            try
            {
                Feldolgoz feldolgoz1 = new Feldolgoz("Proba.txt");
                feldolgoz1.MindentFeldolgoz();
                feldolgoz1.Teszt();
                feldolgoz1.Elromlas();

                //Feldolgoz feldolgoz2 = new Feldolgoz("Proba2.txt");
                //feldolgoz2.MindentFeldolgoz();
                //feldolgoz2.Teszt();

                //Feldolgoz feldolgoz3 = new Feldolgoz("Proba3.txt");
                //feldolgoz3.MindentFeldolgoz();
                //feldolgoz3.Teszt();

                //Feldolgoz feldolgoz4 = new Feldolgoz("Proba4.txt");
                //feldolgoz4.MindentFeldolgoz();
                //feldolgoz4.Teszt();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Rosszul lett megadva fájl név, vagy nem létezik amit fel szeretne dolgozni!");
            }
            catch (NemTalalNevetException e)
            {
                Console.WriteLine("ilyen névvel nem lett alkatrész létrehozva: " + e.Nev + "!");
            }
            catch (NemTalaltAlkatresztException e)
            {
                Console.WriteLine("Az adott alkatrészhez nem lehet autot összeállítani: " + e.Alkatresz.Nev + "!");
            }
            catch (OptimalizacioException)
            {
                Console.WriteLine("Optimalizáció megadása nem jó!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Hiba törtnént a programo futtatásakor!");
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine();
        }
    }
}