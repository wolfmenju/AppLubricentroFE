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
     public class MedioPagoNegocio
    {
        //Listar
        public List<MedioPago> ListarMedioPago(bool estado)
        {
            return MedioPagoData.ListarMedioPago(estado);
        }
        
        //Actualizar
        public int ActualizarMedioPago(MedioPago objMedPago)
        {
            return MedioPagoData.ActualizarMedioPago(objMedPago);
        }

        //Registrar
        public int RegistrarMedioPago(MedioPago objMedPago)
        {
            return MedioPagoData.RegistrarMedioPago(objMedPago);
        }

        //Eliminar
        public int EliminarActivarMedioPago(MedioPago objMedPago)
        {
            return MedioPagoData.EliminarActivarMedioPago(objMedPago);
        }
    }
}