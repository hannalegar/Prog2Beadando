using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog2_Beadando
{
    class Auto
    {
        /// <summary>
        /// Az auto motorját tárolja
        /// </summary>
        Motor motor;
        public Motor Motor
        {
            get { return motor; }
            set { motor = value; }
        }

        /// <summary>
        /// Az auto fékrendszerét tárolja
        /// </summary>
        Fekrendszer fekrendszer;
        public Fekrendszer Fekrendszer
        {
            get { return fekrendszer; }
            set { fekrendszer = value; }
        }

        /// <summary>
        /// Az auto légszűrőjét tárolja
        /// </summary>
        Legszuro legszuro;
        public Legszuro Legszuro
        {
            get { return legszuro; }
            set { legszuro = value; }
        }

        /// <summary>
        /// Az auto elektronikáját tárolja
        /// </summary>
        Elektronika elektronika;
        public Elektronika Elektronika
        {
            get { return elektronika; }
            set { elektronika = value; }
        }

        /// <summary>
        /// Az auto váltóját tárolja
        /// </summary>
        Valto valto;
        public Valto Valto
        {
            get { return valto; }
            set { valto = value; }
        }

        /// <summary>
        /// Megnézi, hogy két auto megegyezik-e.
        /// Azaz ha ugyan az a motorjuk, fékük, légszűrőjük, fékrendszerük illetve váltújuk, akkor igazat ad vissza, egyébként hamis
        /// </summary>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if ((obj as Auto).Elektronika == this.Elektronika && (obj as Auto).Fekrendszer == this.Fekrendszer && (obj as Auto).Legszuro == this.Legszuro && (obj as Auto).Motor == this.motor && (obj as Auto).Valto == this.Valto)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Vissza adja az auto súlyát
        /// </summary>
        /// <returns></returns>
        public int AutoSulya()
        {
            return Motor.Suly + Valto.Suly + Fekrendszer.Suly + Elektronika.Suly + Legszuro.Suly;
        }

        /// <summary>
        /// vissza adja az auto árát
        /// </summary>
        public int AutoAra()
        {
            return Motor.Ar + Elektronika.Ar + Fekrendszer.Ar + Legszuro.Ar + Valto.Ar;
        }

        /// <summary>
        /// Auto adatait vissza adja egy stringben
        /// </summary>
        public override string ToString()
        {
            return string.Format("Auto motorja: {0}\nAuto elektronikája: {1}\nAuto fékrendszere: {2}\nAuto légszűrője: {3}\nAuto váltója: {4}", this.motor.Nev, this.elektronika.Nev, this.fekrendszer.Nev, this.Legszuro.Nev, this.Valto.Nev);
        }
    }
}
