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
     public class CompraNegocio
    {
        public List<Compra> ListarCompras(Compra objCompra)
        {
            return CompraData.ListarCompras(objCompra);
        }

        //Registrar
        public int RegistrarCompra(Compra objCompra)
        {
            return CompraData.RegistrarCompra(objCompra);
        }

        //Anular
        public int AnularCompra(Compra objCompra)
        {
            return CompraData.AnularCompra(objCompra);
        }
    }
}