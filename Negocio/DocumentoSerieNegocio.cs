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
     public class DocumentoSerieNegocio
    {
        //Listar
        public List<DocumentoSerie> ListarDocumentoSerie(DocumentoSerie objDocSerie)
        {
            return DocumentoSerieData.ListarDocumentoSerie(objDocSerie);
        }
        
        //Actualizar
        public int ActualizarDocumentoSerie(DocumentoSerie objDocumt)
        {
            return DocumentoSerieData.ActualizarDocumentoSerie(objDocumt);
        }

        //Registrar
        public int RegistrarDocumentoSerie(DocumentoSerie objDocumt)
        {
            return DocumentoSerieData.RegistrarDocumentoSerie(objDocumt);
        }

        //Eliminar
        public int EliminarActivarDocumentoSerie(DocumentoSerie objDocumt)
        {
            return DocumentoSerieData.EliminarActivarDocumentoSerie(objDocumt);
        }
    }
}