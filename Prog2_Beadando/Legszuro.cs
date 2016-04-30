using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog2_Beadando
{
    class Legszuro : Alkatresz
    {
        public Legszuro(string nev, int suly, int ar) : base(nev, suly, ar)
        {
            this.Tipus = Tipus.legszuro;
        }
    }
}
