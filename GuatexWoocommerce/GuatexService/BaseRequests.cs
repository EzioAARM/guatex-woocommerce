using System.Net;
using System.Xml;

namespace GuatexWoocommerce.GuatexService
{
    public class BaseRequests
    {
        /// <summary>
        /// Create a SOAP web request to [endpoint]
        /// </summary>
        /// <param name="endpoint">Endpoint to send the request</param>
        /// <returns>New Web Request</returns>
        public static HttpWebRequest CreateWebRequest(string endpoint)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(endpoint);
            webRequest.Headers.Add(@"SOAP:Action");
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }

        /// <summary>
        /// Execute a POST request to [endpoint] with [xmlEnvelope] as body
        /// </summary>
        /// <param name="endpoint">Endpoint to send the request</param>
        /// <param name="xmlEnvelope">SOAP content</param>
        /// <returns>XML Response</returns>
        public static XmlDocument Execute(string endpoint, string xmlEnvelope)
        {
            try
            {
                HttpWebRequest request = CreateWebRequest(endpoint);
                XmlDocument soapEnvelopeXml = new();
                soapEnvelopeXml.LoadXml(xmlEnvelope);

                using (Stream stream = request.GetRequestStream())
                {
                    soapEnvelopeXml.Save(stream);
                }
                WebResponse response = request.GetResponse();
                StreamReader reader = new(response.GetResponseStream());
                return new XmlDocument()
                {
                    InnerXml = reader.ReadToEnd()
                };
            }
            catch (WebException)
            {
                XmlDocument soapEnvelopeXml = new();
                soapEnvelopeXml.LoadXml(xmlEnvelope);
                return soapEnvelopeXml;
            }
        }
    }
}