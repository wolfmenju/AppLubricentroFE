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
     public class ClienteNegocio
    {
        //Listar
        public List<Cliente> ListarCliente(Cliente objCliente)
        {
            return ClienteData.ListarCliente(objCliente);
        }

        //Registrar
        public int RegistrarCliente(Cliente objClien)
        {
            return ClienteData.RegistrarCliente(objClien);
        }

        //Actualizar
        public int ActualizarCliente(Cliente objClien)
        {
            return ClienteData.ActualizarCliente(objClien);
        }

        public int EliminarActivarCliente(Cliente objClien)
        {
            return ClienteData.EliminarActivarCliente(objClien);
        }


    }
}