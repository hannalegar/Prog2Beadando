using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog2_Beadando
{
    class BeepitException : AlkatreszException
    {
        public BeepitException(Alkatresz alkatresz) : base (alkatresz)
        {

        }
    }
}
