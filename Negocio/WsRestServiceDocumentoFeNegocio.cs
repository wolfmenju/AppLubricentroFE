using Entidad;
using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class WsRestServiceDocumentoFeNegocio
    {
        private static ILog Log = LogManager.GetLogger(typeof(WsRestServiceDocumentoFeNegocio));

        public WsDocumentoFeResponse RegistroDocumentoFe(string SerializeRequestPerOutput)
        {
            WsDocumentoFeResponse rqResponse = new WsDocumentoFeResponse();
            string serviceUrl = "http://localhost/cpe_api/public/api/cp";
            
            rqResponse = DoRequest<WsDocumentoFeResponse>(serviceUrl,SerializeRequestPerOutput);

            return rqResponse;

        }

        T DoRequest<T>(string serviceUrl, string request)
        {
            T response;

            try
            {
                string ContentType = "application/json";
                System.Net.HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(new Uri(serviceUrl));
                httpRequest.Method = "POST";
                byte[] bytes = Encoding.UTF8.GetBytes(request);
                httpRequest.ContentType = ContentType;
                httpRequest.ContentLength = bytes.Length;

                Stream stream = httpRequest.GetRequestStream();
                stream.Write(bytes, 0, bytes.Length);
                stream.Close();

                WebResponse responsews = httpRequest.GetResponse();
                stream = responsews.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                string responseFromServer = reader.ReadToEnd();
                response = JsonConvert.DeserializeObject<T>(responseFromServer);
                reader.Close();
                stream.Close();
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
