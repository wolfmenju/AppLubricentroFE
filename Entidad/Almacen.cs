﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Almacen
    {
        public Almacen()
        {
            this.nIdAlmacen = 0;
            this.sDescripcion = "";
            this.sDireccion = "";
            this.nIdSede = 0;
            this.sUsuario = "";
            this.bEstado = true;
        }
        
        public int nIdAlmacen { get; set; }
        public string sDescripcion { get; set; }
        public string sDireccion { get; set; }
        public int nIdSede { get; set; }
        public string sUsuario { get; set; }
        public bool bEstado { get; set; }
    }
}
