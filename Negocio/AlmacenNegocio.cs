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
     public class AlmacenNegocio
    {
        //Listar
        public List<Almacen> ListarAlmacen(bool estado)
        {
            return AlmacenData.ListarAlmacen(estado);
        }
        
        //Actualizar
        public int ActualizarAlmacen(Almacen objAlm)
        {
            return AlmacenData.ActualizarAlmacen(objAlm);
        }

        //Registrar
        public int RegistrarAlmacen(Almacen objAlm)
        {
            return AlmacenData.RegistrarAlmacen(objAlm);
        }

        //Eliminar
        public int EliminarActivarAlmacen(Almacen objAlm)
        {
            return AlmacenData.EliminarActivarAlmacen(objAlm);
        }
    }
}