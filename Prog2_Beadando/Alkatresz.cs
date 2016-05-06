using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog2_Beadando
{
    
        delegate void ElromlikEsemeny(Alkatresz alkatresz);

    abstract class Alkatresz : IAlkatresz
    {
         static Random rnd = new Random();
        
        public event ElromlikEsemeny elromlikEsemeny;
        EsemenyKezeles Ek = new EsemenyKezeles();

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

        /// <summary>
        /// Ebben a listában el van tárolva az össze alkatrész, amivel ez az alkatrész kompatibilis
        /// </summary>
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
        
        /// <summary>
        /// Beépíti az alkatrészt az Autoba, ha a már beépített alkatrészekkel kompatibilis
        /// HA nem tudja beépíteni hibát dob
        /// </summary>
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

        /// <summary>
        /// Elromlás esetén meghívódik ez a metódus
        /// </summary>
        public virtual void Elromlik()
        {
            if (elromlikEsemeny == null)
            {
                this.elromlikEsemeny += Ek.Elromlik;
            }
            elromlikEsemeny(this);
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

        /// <summary>
        /// Visszaadja, hiogy egy autoba be lehete-e építeni ezt az alkatrészt. Akkor ad vissza igazat ha az i = 5.
        /// Megnézi, hogy az autoban van e olya, hogy még nincs beépítbe alkatrész, ha igen akkor növeli eggyel az i -értékét, mert azzal egészen biztosan kompatibilis ez az alkatrész. 
        /// Majd megnézi, hogy a már beépített alkatrészek, kompatibilisek-e ezzel az alkatrésszel, ha igen akkor eggyel növeli az i-értékét
        /// Ha az i eléri az 5-öt, az azt jelenti, hogy be lehet építeni, mert mindennel kompatibilis
        /// </summary>
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

        /// <summary>
        /// Vissza adja, hogy egy adott alkatrész tartalmazz-e ezt az alkatrészt
        /// </summary>
        bool KompatiblisValamivel(Alkatresz alkatresz)
        {
            return alkatresz.osszesKompatibilisAlkatresz.Contains(this);
        }

        public void Hasznal()
        {
            if ( rnd.Next(0,100) > 50)
            {
                this.mukodokepes = false;
            }
            if (!this.mukodokepes)
            {
                this.Elromlik();
            }
        }

    }
}
