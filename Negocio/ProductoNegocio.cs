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
     public class ProductoNegocio
    {
        //Listar
        public List<Producto> ListarProducto(Producto objProducto)
        {
            return ProductoData.ListarProducto(objProducto);
        }

        //Registrar
        public int RegistrarProducto(Producto objProduc)
        {
            return ProductoData.RegistrarProducto(objProduc);
        }

        //Actualizar
        public int ActualizarProducto(Producto objProduc)
        {
            return ProductoData.ActualizarProducto(objProduc);
        }
        
        public int EliminarActivarProducto(Producto objProduc)
        {
            return ProductoData.EliminarActivarProducto(objProduc);
        }
    }
}