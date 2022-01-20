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
     public class InventarioDetalleNegocio
    {
        //Listar
        public List<InventarioDetalle> ListarInventarioDetalle(InventarioDetalle objInventarioDetalle)
        {
            return InventarioDetalleData.ListarInventarioDetalle(objInventarioDetalle);
        }

        public int ActualizarInventarioDetalle(InventarioDetalle objInventarioDetalle)
        {
            return InventarioDetalleData.ActualizarInventarioDetalle(objInventarioDetalle);
        }
    }
}