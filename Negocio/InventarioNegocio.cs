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
     public class InventarioNegocio
    {
        //Listar
        public List<Inventario> ListarInventario(Inventario objInventario)
        {
            return InventarioData.ListarInventario(objInventario);
        }

        public int ActualizarInventario(Inventario objInventario)
        {
            return InventarioData.ActualizarInventario(objInventario);
        }
    }
}