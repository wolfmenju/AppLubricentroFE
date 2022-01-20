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
     public class DeudaNegocio
    {
        //Listar
        public List<Deuda> ListarDeuda(Deuda objDeuda)
        {
            return DeudaData.ListarDeuda(objDeuda);
        }

        public int RegistrarAbonoDeuda(Deuda objDeuda)
        {
            return DeudaData.RegistrarAbonoDeuda(objDeuda);
        }
    }
}