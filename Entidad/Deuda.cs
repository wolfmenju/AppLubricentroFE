using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Deuda
    {
        public Deuda()
        {
            this.nTipo = 0;
            this.nIdDeuda = 0;
            this.dFecha = DateTime.Now;
            this.dFechaPago = DateTime.Now;
            this.nIdProveedor = 0;
            this.nIdReferencia = 0;
            this.bEntrada = false;
            this.sIdDocumento = "";
            this.sSerie = "";
            this.sRuc ="";
            this.nNumero = 0;
            this.fMonto = 0M;

            this.fSaldo = 0M;
            this.nSubTipo = 0;
            this.nIdDetalleDeuda = 0;
            this.sObservacion ="";
            this.sUsuario = "";
            this.bEstado = false;

        }

        public int nTipo { get; set; }
        public int nIdDeuda { get; set; }
        public DateTime dFecha { get; set; }
        public DateTime dFechaPago { get; set; }
        public int nIdProveedor { get; set; }
        public int nIdReferencia { get; set; }

        public bool bEntrada { get; set; }
        public string sIdDocumento { get; set; }
        public string sSerie { get; set; }
        public string sRuc { get; set; }
        public int nNumero { get; set; }
        public Decimal fMonto { get; set; }
        public Decimal fSaldo { get; set; }
        public int nSubTipo { get; set; }
        public int nIdDetalleDeuda { get; set; }
        public string sObservacion { get; set; } 
        public string sUsuario { get; set; }
        public bool bEstado { get; set; }
    }
}
