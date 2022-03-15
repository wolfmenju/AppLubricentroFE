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
     public class ServicioNegocio
    {
        //Listar
        public List<Servicio> ListarServicio(Servicio objServicio)
        {
            return ServicioData.ListarServicio(objServicio);
        }

        //Registrar
        public int RegistrarServicio(Servicio objServicio)
        {
            return ServicioData.RegistrarServicio(objServicio);
        }

        //Actualizar
        public int ActualizarServicio(Servicio objServicio)
        {
            return ServicioData.ActualizarServicio(objServicio);
        }

        public int EliminarActivarServicio(Servicio objServicio)
        {
            return ServicioData.EliminarActivarServicio(objServicio);
        }
    }
}