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

        //Listar
        public Cliente LeerCliente(int IdCliente)
        {
            List<Cliente> ListaCliente = new List<Cliente>();
            Cliente objClienteRes = new Cliente() { nTipo = 5, bEstado = true};
            ListaCliente =ClienteData.ListarCliente(objClienteRes);

            foreach (var item in ListaCliente)
            {
                if (item.nIdCliente == IdCliente)
                {
                    objClienteRes = item;
                    break;
                }
            }

            return objClienteRes;
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