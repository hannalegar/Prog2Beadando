using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog2_Beadando
{
    class NemTalalNevetException : ApplicationException
    {
        string nev;
        public string Nev
        {
            get { return nev; }
            set { nev = value; }
        }

        public NemTalalNevetException(string nev)
        {
            this.nev = nev;
        }
    }
}
