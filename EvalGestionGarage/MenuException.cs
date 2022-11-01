using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvalGestionGarage
{
    internal class MenuException : Exception
    {
        public MenuException()
        { 
        }

        public MenuException(int min, int max)
            : base("Le choix n'est pas compris entre " + min + " et " + max)
        {
        }
    }
}
