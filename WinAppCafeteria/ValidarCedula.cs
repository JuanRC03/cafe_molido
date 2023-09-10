using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinAppCafeteria
{
    class ValidarCedula
    {
        public ValidarCedula()
        {

        }
        public String validar(string cedula)
        {
            char[] ced = cedula.ToArray();
            int total = 0;
            int ultimo_digito = int.Parse(ced[9].ToString());
            if (ced.Length == 10)
            {
                int digito_region = int.Parse(cedula.Substring(0, 2));
                if (digito_region >= 1 && digito_region <= 24)
                {
                    for (int i = 0; i < (ced.Length - 1); i++)
                    {
                        int digito = int.Parse(ced[i].ToString());
                        if (i % 2 == 0)
                        {
                            digito = int.Parse(ced[i].ToString()) * 2;
                            if (digito > 9)
                                digito -= 9;
                        }
                        total += digito;
                    }
                    total = 10 - (total % 10);
                    int digito_validador;
                    if (total > 9)
                    {
                        digito_validador = 0;
                    }
                    else
                    {
                        digito_validador = total;
                    }

                    if (digito_validador == ultimo_digito)
                    {
                        return "V";
                    }
                    else
                    {
                        return "La cédula " + cedula + " es incorrecta";
                    }
                }
                else
                {
                    return "La cédula " + cedula + " no pertenece a ninguna región";
                }
            }
            else
            {
                return "La cédula " + cedula + " no tiene 10 Digitos";
            }
        }
    }
}
