using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comun
{
    public static class Globales
    {
        public static DateTime FechaActual()
        {
            return ServerData.FechaActual();
        }
    }
}
