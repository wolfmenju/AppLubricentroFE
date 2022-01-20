using Comun;
using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
     public class SalidaNegocio
    {
        //Registrar
        public int ActualizaSalida(Salida objVenta)
        {
            return SalidaData.ActualizaSalida(objVenta);
        }

        public int ActualizaIngreso(Salida objVenta)
        {
            return SalidaData.ActualizaIngreso(objVenta);
        }
    }
}