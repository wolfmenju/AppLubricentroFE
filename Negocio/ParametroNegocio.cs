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
     public class ParametroNegocio
    {
        //Listar
        public List<Parametro> ListarParametro(Parametro objPara)
        {
            return ParametrosData.ListarParametro(objPara);
        }

        //Listar
        public string LeerUnParametro(string xClave)
        {
            Parametro objPara = new Parametro() { nTipo= 5, sClave= xClave};

            List<Parametro> ListarParametro = ParametrosData.ListarParametro(objPara);
            string sValor = "NO DISPONIBLE, CONSULTE CON INGUIRISOT";

            foreach (var item in ListarParametro)
            {
                sValor = item.sValor;
                break;
            }

            return sValor;
        }

        //Actualizar
        public int ActualizarParametro(Parametro objPara)
        {
            return ParametrosData.ActualizarParametro(objPara);
        }

        //Registrar
        public int RegistrarParametro(Parametro objPara)
        {
            return ParametrosData.RegistrarParametro(objPara);
        }

        //Eliminar
        public int EliminarActivarParametro(Parametro objPara)
        {
            return ParametrosData.EliminarActivarParametro(objPara);
        }

    }
}