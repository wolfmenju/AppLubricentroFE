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
     public class ProductoHistorialNegocio
    {
        //Listar
        public List<ProductoHistorial> ListarProductoHistorial(ProductoHistorial objProductoHist)
        {
            return ProductoHistorialData.ListarProductoHistorial(objProductoHist);
        }

        public int ActualizarProductoHistorial(ProductoHistorial objProductoHist)
        {
            return ProductoHistorialData.ActualizarProductoHistorial(objProductoHist);
        }
    }
}