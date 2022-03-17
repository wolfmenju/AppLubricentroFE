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
     public class PedidoNegocio
    {
        //Registrar
        public int RegistrarPedido(Pedido objPedido)
        {
            return PedidoData.RegistrarPedido(objPedido);
        }

        /*
        public List<Pedido> ListarVentas(Pedido objVenta)
        {
            return VentaData.ListarVentas(objVenta);
        }
        
        //Anular
        public int AnularVenta(Venta objVenta)
        {
            return VentaData.AnularVenta(objVenta);
        }

        public int ActualizarVentaNotficacionSunat(Venta objVenta)
        {
            return VentaData.ActualizarVentaNotficacionSunat(objVenta);
        }
        */

    }
}