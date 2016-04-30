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
    }
}
