using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinAppCafeteria
{
    class clVerifiacarCodigoProducto
    {
        string s1, s2;
        public clVerifiacarCodigoProducto(string s, string c)
        {
            s1 = s;
            s2 = c;
        }
        public bool validar()
        {
            
            bool aux=true;
            if (s1.Length >= 5)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (s1[i] != s2[i])
                    {
                        aux = false;
                    }
                }
            }
            else
            {
                aux = false;
            }
            if (aux == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
