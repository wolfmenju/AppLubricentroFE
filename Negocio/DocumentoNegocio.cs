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
     public class DocumentoNegocio
    {
        //Listar
        public List<Documento> ListarDocumento(Documento objDoc)
        {
            return DocumentoData.ListarDocumento(objDoc);
        }
        
        //Actualizar
        public int ActualizarDocumento(Documento objDocumt)
        {
            return DocumentoData.ActualizarDocumento(objDocumt);
        }

        //Registrar
        public int RegistrarDocumento(Documento objDocumt)
        {
            return DocumentoData.RegistrarDocumento(objDocumt);
        }

        //Eliminar
        public int EliminarActivarDocumento(Documento objDocumt)
        {
            return DocumentoData.EliminarActivarDocumento(objDocumt);
        }

    }
}