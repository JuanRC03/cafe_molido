using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinAppCafeteria
{
    class IdenitificadorTIpoProducto
    {
        public string s1,s2, aux;
        public IdenitificadorTIpoProducto(string s, string s_aux)
        {
            s1 = s;
            aux = s_aux;
        }
        public string retornarIdentificador()
        {
            s2 = "";
            for(int i = 0; i < s1.Length; i++)
            {
                if (i < 4)
                {
                    s2 = s2 + aux[i];
                }
                else
                {
                    s2 = s2 + s1[i];
                }
            }
            return s2;
        }
    }
}
