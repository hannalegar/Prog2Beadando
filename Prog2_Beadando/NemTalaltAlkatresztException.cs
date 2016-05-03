using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog2_Beadando
{
    class NemTalaltAlkatresztException : AlkatreszException
    {
        public NemTalaltAlkatresztException(Alkatresz alkatresz) : base (alkatresz)
        {

        }
    }
}
