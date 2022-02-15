using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class WsDocumentoFeResponse
    {
        public string response { get; set; }
        public data data { get; set; }
        public string tipo_msj { get; set; }
        public string mensaje { get; set; }
        public string code { get; set; }
    }

    public class data
    {
        public string respuesta { get; set; }
        public string cod_sunat { get; set; }
        public string mensaje { get; set; }
        public string hash_cdr { get; set; }
        public string status_code { get; set; }
        public string nombre_file { get; set; }
        public string cdr { get; set; }
        public string xml { get; set; }
        public string hash_cpe { get; set; }
    } 
}
