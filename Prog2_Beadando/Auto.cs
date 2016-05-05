using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog2_Beadando
{
    class Auto
    {
        Motor motor;
        public Motor Motor
        {
            get { return motor; }
            set { motor = value; }
        }

        Fekrendszer fekrendszer;
        public Fekrendszer Fekrendszer
        {
            get { return fekrendszer; }
            set { fekrendszer = value; }
        }

        Legszuro legszuro;
        public Legszuro Legszuro
        {
            get { return legszuro; }
            set { legszuro = value; }
        }

        Elektronika elektronika;
        public Elektronika Elektronika
        {
            get { return elektronika; }
            set { elektronika = value; }
        }

        Valto valto;
        public Valto Valto
        {
            get { return valto; }
            set { valto = value; }
        }

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

        public int AutoSulya()
        {
            return Motor.Suly + Valto.Suly + Fekrendszer.Suly + Elektronika.Suly + Legszuro.Suly;
        }

        public int AutoAra()
        {
            return Motor.Ar + Elektronika.Ar + Fekrendszer.Ar + Legszuro.Ar + Valto.Ar;
        }
    }
}
