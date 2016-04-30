using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog2_Beadando
{
    class Fekrendszer : Alkatresz
    {
        public Fekrendszer(string nev, int suly, int ar) : base (nev, suly, ar)
        {
            this.Tipus = Tipus.fekrendszer;
        }
    }
}
