using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinAppCafeteria
{
    class Class1
    {
        public string s1, s2;
        public Class1(string c1)
        {
            s1 = c1;
        }
        public string agregarEspacio()
        {
            int n1=29;
            s2 = "";
            
            for(int i = 0; i < s1.Length; i++)
            {
                if (i == n1)
                {
                    s2 = s2 + s1[i];
                    s2 = s2 + " \n ";
                    n1 = n1 + 30;

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
