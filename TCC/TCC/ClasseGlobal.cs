using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCC
{
    static class ClasseGlobal
    {
        private static bool adm;

        public static bool Adm
        {
            get { return adm; }
            set { adm = value; }
        }
    }
}
