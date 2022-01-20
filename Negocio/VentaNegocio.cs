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
     public class VentaNegocio
    {
        public List<Venta> ListarVentas(Venta objVenta)
        {
            return VentaData.ListarVentas(objVenta);
        }

        //Registrar
        public int RegistrarVenta(Venta objVenta)
        {
            return VentaData.RegistrarVenta(objVenta);
        }

        //Anular
        public int AnularVenta(Venta objVenta)
        {
            return VentaData.AnularVenta(objVenta);
        }
    }
}