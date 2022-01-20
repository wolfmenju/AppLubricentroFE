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
    public class ProveedorNegocio
    {
        //Listar
        public List<Proveedor> ListarProveedor(bool bActivo)
        {
            return ProveedorData.ListarProveedor(bActivo);
        }

        //Registrar
        public int RegistrarProveedor(Proveedor objProvee)
        {
            return ProveedorData.RegistrarProveedor(objProvee);
        }

        //Actualizar
        public int ActualizarProveedor(Proveedor objProvee)
        {
            return ProveedorData.ActualizarProveedor(objProvee);
        }

        public int EliminarActivarProveedor(Proveedor objProvee)
        {
            return ProveedorData.EliminarActivarProveedor(objProvee);
        }
    }
}