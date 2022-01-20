using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Producto: ProductoHistorial
    {
        public Producto()
        {
            this.nIdProducto = 0;
            this.sPrincipioActivo = "";
            this.nIdLaboratorio = 0;
            this.nIdPresentacion = 0;
            this.bAlternativo = false;
            this.nStockMinimo = 0;
            this.sDescripcion = "";
            this.sUsuario = "";
            this.bEstado = true;
            this.dFechaVencimiento = DateTime.Now;
            this.sLaboratorio = "";
            this.sPresentacion = "";
            this.nTotal = 0;
        }
        
        public string sPrincipioActivo { get; set; }
        public int nIdLaboratorio { get; set; }
        public int nIdPresentacion { get; set; }
        public bool bAlternativo { get; set; }
        public int nStockMinimo { get; set; }
        public string sDescripcion { get; set; }
        public string sPresentacion { get; set; }
        public int? nTotal { get; set; }

    }
}
