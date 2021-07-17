using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgenda.WindowsFormsApp
{
    public static class MetodosExtencao
    {
        public static bool EhVazia(this string auxPalavra) 
        {
            return auxPalavra.Length == 0;
        }
    }
}
