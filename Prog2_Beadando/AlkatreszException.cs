using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog2_Beadando
{
    class AlkatreszException : ApplicationException
    {
        Alkatresz alkatresz;
        public Alkatresz Alkatresz
        {
            get { return alkatresz; }
            set { alkatresz = value; }
        }

        public AlkatreszException(Alkatresz alkatresz)
        {
            this.alkatresz = alkatresz;
        }
    }
}
