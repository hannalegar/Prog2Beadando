using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog2_Beadando
{
    abstract class Motor : Alkatresz
    {
        public Motor(string nev, int suly, int ar) : base(nev, suly, ar)
        {
            this.Tipus = Tipus.motor;
        }

        /// <summary>
        /// elromlás esetén megkeresi a beépítésre kerülő autóban a váltót és annak is meghívja az Elromlik metódusát
        /// </summary>
        public override void Elromlik()
        {
            base.Elromlik();
        }
    }
}

