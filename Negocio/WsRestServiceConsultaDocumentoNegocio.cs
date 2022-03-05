using Entidad;
using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class WsRestServiceConsultaDocumentoNegocio
    {
        private static ILog Log = LogManager.GetLogger(typeof(WsRestServiceDocumentoFeNegocio));
        private string _UrlConsultaDocumento = Convert.ToString(ConfigurationManager.AppSettings["UrlConsultaDocumento"]);

        public WsConsultaDocumentoResponse ConsultaDocumentoServicioExterno(string numero)
        {
            WsConsultaDocumentoResponse response = new WsConsultaDocumentoResponse();
            string UrlCompleto = "";

            if (numero.Length > 8) UrlCompleto = _UrlConsultaDocumento + "ruc?numero={0}";
            else UrlCompleto = _UrlConsultaDocumento + "dni?numero={0}";
            response = DoRequest<WsConsultaDocumentoResponse>(UrlCompleto, numero);

            return response;

        }

        T DoRequest<T>(string serviceUrl, string Ruc)
        {
            T response;

            try
            {
                WebRequest request = WebRequest.Create(string.Format(serviceUrl, Ruc.ToString()));
                request.Method = "GET";
                
                request.ContentType = "application/json";
                WebResponse responsews = request.GetResponse();
                Stream dataStream = responsews.GetResponseStream();

                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                response = JsonConvert.DeserializeObject<T>(responseFromServer);

                reader.Close();
                dataStream.Close();
                responsews.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return response;
        }

    }
}
