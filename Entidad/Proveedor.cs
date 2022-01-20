using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Proveedor
    {
        public Proveedor()
        {
            this.nIdProveedor = 0;
            this.sRazonSocial = "";
            this.sRuc = "";
            this.sDireccion = "";
            this.sCelular = "";
            this.sContacto = "";
            this.sUsuario = "";
            this.bEstado = true;
        }
        
        public int nTipo { get; set; }
        public int nIdProveedor { get; set; }
        public string sRazonSocial { get; set; }
        public string sRuc { get; set; }
        public string sDireccion { get; set; }
        public string sCelular { get; set; }
        public string sContacto { get; set; }
        public string sUsuario { get; set; }
        public bool bEstado { get; set; }

    }
}
