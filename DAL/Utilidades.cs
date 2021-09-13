using System;
using System.Collections.Generic;
using System.Text;

namespace RegistroDeUsuarios.DAL
{
    public class Utilidades
    {
        public static int ToInt(string value)
        {
            int aux = 0;

            int.TryParse(value, out aux);

            return aux;
        }
    }
}
