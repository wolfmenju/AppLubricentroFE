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
     public class CajaNegocio
    {
        //Listar
        public List<Caja> ListarCaja(Caja objCaja)
        {
            return CajaData.ListarCaja(objCaja);
        }

        //Listar
        public int ValidarCaja(Caja objCaja)
        {
            List<Caja> List=CajaData.ListarCaja(objCaja);
            int resp = 0;

            foreach (var item in List)
            {
                resp = item.nIdCaja;
                break;
            }

            return resp;
        }

        //Actualizar
        public int ActualizarCaja(Caja objCaja)
        {
            return CajaData.ActualizarCaja(objCaja);
        }
    }
}