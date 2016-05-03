using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog2_Beadando
{
    abstract class Alkatresz : IAlkatresz
    {
        string nev; //minden alkatrésznek lesz egy neve
        public string Nev
        {
            get { return nev; }
            set { nev = value; }
        }

        int suly; //minden alkatresznek lesz egy súlya
        public int Suly
        {
            get { return suly; }
            set { suly = value; }
        }

        int ar; //minden alkatresznek lesz egy ára
        public int Ar
        {
            get { return ar; }
            set { ar = value; }
        }

        Tipus tipus; //minden alkatrésznek van típusa
        public Tipus Tipus
        {
            get { return tipus; }
            set { tipus = value; }
        }

        bool mukodokepes; //minden alkatrész vagy működik vagy nem
        public bool MukodoKepes
        {
            get { return mukodokepes; }
            set { mukodokepes = value; }
        }

        List<Alkatresz> osszesKompatibilisAlkatresz;
        public List<Alkatresz> OsszesKompatibilisAlkatresz
        {
            get { return osszesKompatibilisAlkatresz; }
            set { osszesKompatibilisAlkatresz = value; }
        }


        List<Motor> kompatibilisMotorok; //az adott alkatrésszel kompatibilis motorok listája
        public List<Motor> KompatibilisMotorok
        {
            get { return kompatibilisMotorok; }
        }

        List<Elektronika> kompatibilisElektronika; //az adott alkatrésszel kompatibilis elektronikák listája
        public List<Elektronika> KompatibilisElektronika
        {
            get { return kompatibilisElektronika; }
        }

        List<Fekrendszer> kompatibilisFekrendszer; //az adott alkatrésszel kompatibilis fékrendszerek listája
        public List<Fekrendszer> KompatibilisFekrendszer
        {
            get { return kompatibilisFekrendszer; }
        }

        List<Valto> kompatibilisValto; //az adott alkatrésszel kompatibilis váltók listája
        public List<Valto> KompatibilisValto
        {
            get { return kompatibilisValto; }
        }

        List<Legszuro> kompatibilisLegszuro; //az adott alkatrésszel kompatibilis légszűrők listája
        public List<Legszuro> KompatibilisLegszuro
        {
            get { return kompatibilisLegszuro; }
        }
        public void Beepit(Auto auto)
        {
            if (this.KompatibilisTobbiAlkatresszel(auto))
            {
                switch (tipus)
                {
                    case Tipus.motor:
                        auto.Motor = (this as Motor);
                        break;
                    case Tipus.legszuro:
                        auto.Legszuro = (this as Legszuro);
                        break;
                    case Tipus.fekrendszer:
                        auto.Fekrendszer = (this as Fekrendszer);
                        break;
                    case Tipus.elektronika:
                        auto.Elektronika = (this as Elektronika);
                        break;
                    case Tipus.valto:
                        auto.Valto = (this as Valto);
                        break;
                }
            }
            else
            {
                throw new BeepitException(this);
            }
        }

        public virtual void Elromlik()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// A megfelelő listához hozzáadja a paraméterül kapott alkatrészt. Ezáltal fog létrejönni a gráf
        /// </summary>
        /// <param name="alkatresz"></param>
        public void KompatibilisHozzaAd(IAlkatresz alkatresz)
        {
            if (osszesKompatibilisAlkatresz == null)
            {
                osszesKompatibilisAlkatresz = new List<Alkatresz>();
                osszesKompatibilisAlkatresz.Add(alkatresz as Alkatresz);
            }
            else
            {
                osszesKompatibilisAlkatresz.Add(alkatresz as Alkatresz);
            }

            switch (alkatresz.Tipus)
            {
                case Tipus.motor:
                    if (KompatibilisMotorok == null)
                    {
                        kompatibilisMotorok = new List<Motor>();
                        kompatibilisMotorok.Add(alkatresz as Motor);
                    }
                    else
                    {
                        kompatibilisMotorok.Add(alkatresz as Motor);
                    }
                    break;
                case Tipus.legszuro:
                    if (KompatibilisLegszuro == null)
                    {
                        kompatibilisLegszuro = new List<Legszuro>();
                        kompatibilisLegszuro.Add(alkatresz as Legszuro);
                    }
                    else
                    {
                        kompatibilisLegszuro.Add(alkatresz as Legszuro);
                    }
                    break;
                case Tipus.fekrendszer:
                    if (KompatibilisFekrendszer == null)
                    {
                        kompatibilisFekrendszer = new List<Fekrendszer>();
                        kompatibilisFekrendszer.Add(alkatresz as Fekrendszer);
                    }
                    else
                    {
                        kompatibilisFekrendszer.Add(alkatresz as Fekrendszer);
                    }
                    break;
                case Tipus.elektronika:
                    if (KompatibilisElektronika == null)
                    {
                        kompatibilisElektronika = new List<Elektronika>();
                        kompatibilisElektronika.Add(alkatresz as Elektronika);
                    }
                    else
                    {
                        kompatibilisElektronika.Add(alkatresz as Elektronika);
                    }
                    break;
                case Tipus.valto:
                    if (KompatibilisValto == null)
                    {
                        kompatibilisValto = new List<Valto>();
                        kompatibilisValto.Add(alkatresz as Valto);
                    }
                    else
                    {
                        kompatibilisValto.Add(alkatresz as Valto);
                    }
                    break;
                default:
                    break;
            }
        }

        public Alkatresz(string nev, int suly, int ar)
        {
            this.nev = nev;
            this.suly = suly;
            this.ar = ar;
            this.mukodokepes = true;
        }

        bool KompatibilisTobbiAlkatresszel(Auto auto)
        {
            int i = 0;
            if (auto.Motor == null)
            {
                i++;
            }
            if (auto.Fekrendszer == null)
            {
                i++;                
            }
            if (auto.Elektronika == null)
            {
                i++;
            }
            if (auto.Valto == null)
            {
                i++;
            }
            if (auto.Legszuro == null)
            {
                i++;
            }
            
            if (auto.Motor != null && auto.Motor.KompatiblisValamivel(this))
            {
                i++;
            }
            if (auto.Elektronika != null && auto.Elektronika.KompatiblisValamivel(this))
            {
                i++;
            }
            if (auto.Fekrendszer != null && auto.Fekrendszer.KompatiblisValamivel(this))
            {
                i++;
            }
            if (auto.Legszuro != null && auto.Legszuro.KompatiblisValamivel(this))
            {
                i++;
            }
            if (auto.Valto != null && auto.Valto.KompatiblisValamivel(this))
            {
                i++;
            }
            return i == 5;
        }

        bool KompatiblisValamivel(Alkatresz alkatresz)
        {
            /*
            int i = 0;
            if (alkatresz.kompatibilisElektronika == null)
            {
                i++;
            }
            if (alkatresz.kompatibilisFekrendszer == null)
            {
                i++;
            }
            if (alkatresz.KompatibilisLegszuro == null)
            {
                i++;
            }
            if (alkatresz.KompatibilisMotorok == null)
            {
                i++;
            }
            if (alkatresz.KompatibilisValto == null)
            {
                i++;
            }

            if (alkatresz.kompatibilisElektronika != null && alkatresz.KompatibilisElektronika.Contains(this))
            {
                i++;
            }
            if (alkatresz.kompatibilisFekrendszer != null && alkatresz.KompatibilisFekrendszer.Contains(this))
            {
                i++;
            }
            if (alkatresz.kompatibilisLegszuro != null && alkatresz.kompatibilisLegszuro.Contains(this))
            {
                i++;
            }
            if (alkatresz.kompatibilisMotorok != null && alkatresz.kompatibilisMotorok.Contains(this))
            {
                i++;
            }
            if (alkatresz.KompatibilisValto != null && alkatresz.KompatibilisValto.Contains(this))
            {
                i++;
            }

            return i == 5;
            */


            return alkatresz.osszesKompatibilisAlkatresz.Contains(this);
        }
    }
}
