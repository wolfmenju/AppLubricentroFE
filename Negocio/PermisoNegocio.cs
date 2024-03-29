﻿using Comun;
using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
     public class PermisoNegocio
    {
        //Listar
        public List<Permiso> ListarPermiso(string sIdUsuario, int xTipo)
        {
            return PermisoData.ListarPermiso(sIdUsuario,xTipo);
        }

        //Actualizar
        public int ActualizarPermiso(Permiso obj)
        {
            return PermisoData.ActualizarPermiso(obj);
        }
        
    }
}