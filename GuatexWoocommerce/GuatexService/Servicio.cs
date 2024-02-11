using GuatexWoocommerce.Models;
using System.Xml;
using System.Xml.Linq;

namespace GuatexWoocommerce.GuatexService
{
    public class LineaDetalleGuia
    {
        public int Cantidad { get; set; }

        public decimal Peso { get; set; }

        public string TipoEnvio { get; set; }
    }

    public class Servicio
    {
        /// <summary>
        /// Solicitar el envío de un paquete a GUATEX
        /// </summary>
        /// <returns>Objeto que contiene la información del envío</returns>
        public GuatexSolicitudServicio Solicitar(string addressPhone, string sendFromAddress, int idMunicipalityFrom, string clientId,
            string codigoCobroGuia, string clientName, string clientPhone, string clientFullAddress, int clientMunicipalityId,
            string description, bool pickInOffice, List<LineaDetalleGuia> products)
        {
            try
            {
                string recogerOficina = pickInOffice ? "S" : "N";
                string lineasDetalle = "";
                foreach (var product in products)
                {
                    lineasDetalle += $@"
                        <LINEA_DETALLE_GUIA>
                            <PIEZAS_DETALLE>{product.Cantidad}</PIEZAS_DETALLE>
                            <PESO_DETALLE>{product.Peso}</PESO_DETALLE>
                            <TIPO_ENVIO_DETALLE>{product.TipoEnvio}</TIPO_ENVIO_DETALLE>
                        </LINEA_DETALLE_GUIA>";
                }
                string tomaDeServicio = $@"
                <soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:ser=""http://servicio.wstomaservicioscodimp.guatex.com/"">
                   <soapenv:Header/>
                   <soapenv:Body>
                      <ser:tomaServicioGTX>
                         <!--Optional:-->
                         <xmlentrada>
                            <![CDATA[
                               <TOMA_SERVICIO>
                                  <USUARIO>{Properties.Settings.Default["UsuarioTomaServicio"]}</USUARIO>
                                  <PASSWORD>{Properties.Settings.Default["PasswordTomaServicio"]}</PASSWORD>
                                  <CODIGO_COBRO>{Properties.Settings.Default["CodigoCobroTomaServicio"]}</CODIGO_COBRO>
                                  <SERVICIO>
                                     <TIPO_USUARIO>C</TIPO_USUARIO>
                                     <NOMBRE_REMITENTE>{Properties.Settings.Default["NombreRemitente"]}</NOMBRE_REMITENTE>
                                     <TELEFONO_REMITENTE>{addressPhone}</TELEFONO_REMITENTE>
                                     <DIRECCION_REMITENTE>{sendFromAddress}</DIRECCION_REMITENTE>
                                     <MUNICIPIO_ORIGEN>{idMunicipalityFrom}</MUNICIPIO_ORIGEN>
                                     <PUNTO_ORIGEN>A</PUNTO_ORIGEN>
                                     <ESTA_LISTO>S</ESTA_LISTO>
                                     <CODORIGEN>{idMunicipalityFrom}</CODORIGEN>
                                     <DESCRIPCION_ENVIO>{description}</DESCRIPCION_ENVIO>
                                     <GUIA>
                                           <LLAVE_CLIENTE>{clientId}</LLAVE_CLIENTE>
                                           <CODIGO_COBRO_GUIA>{codigoCobroGuia}</CODIGO_COBRO_GUIA>
                                           <NOMBRE_DESTINATARIO>{clientName}</NOMBRE_DESTINATARIO>
                                           <TELEFONO_DESTINATARIO>{clientPhone}</TELEFONO_DESTINATARIO>
                                           <DIRECCION_DESTINATARIO>{clientFullAddress}</DIRECCION_DESTINATARIO>
                                           <MUNICIPIO_DESTINO>{clientMunicipalityId}</MUNICIPIO_DESTINO>
                                           <PUNTO_DESTINO>A</PUNTO_DESTINO>
                                           <DESCRIPCION_ENVIO>{description}</DESCRIPCION_ENVIO>
                                           <RECOGE_OFICINA>{recogerOficina}</RECOGE_OFICINA>
                                           <CODDESTINO>{clientMunicipalityId}</CODDESTINO>
                                           <DETALLE_GUIA>
                                                {lineasDetalle}
                                           </DETALLE_GUIA>
                                     </GUIA>
                                  </SERVICIO>
                               </TOMA_SERVICIO>
                            ]]>
                         </xmlentrada>
                      </ser:tomaServicioGTX>
                   </soapenv:Body>
                </soapenv:Envelope>";
                string endpoint = Properties.Settings.Default["UrlTomaServicio"].ToString();
                XmlDocument text = BaseRequests.Execute(endpoint, tomaDeServicio);
                File.WriteAllText("service_response.txt", text.InnerText);
                string destinosContent = "";
                foreach (XmlNode node in text.DocumentElement.ChildNodes[0].ChildNodes[0].ChildNodes)
                {
                    if (node.Name == "return")
                    {
                        destinosContent = node.InnerText;
                    }
                }
                XElement elemento = XDocument.Parse(destinosContent)
                    .Descendants("RESPUESTA")
                    .Elements("SERVICIO")
                    .SingleOrDefault();
                GuatexSolicitudServicio guatexServicio = new()
                {
                    Codigo = elemento.Element("CODIGO").Value,
                    Guias = elemento
                        .Descendants("GUIAS")
                        .Elements()
                        .Select(x => new Guia
                        {
                            Id = x.Element("ID_GUIA").Value,
                            Numero = x.Element("NOGUIA").Value,
                            GuiasHijas = x
                                .Descendants("GUIAS_HIJAS")
                                .Elements()
                                .Select(y => y.ToString())
                                .ToList()
                        })
                        .ToList()
                };
                return guatexServicio;
            }
            catch
            {
                throw;
            }
        }

        public bool Cancelar(string numeroGuia)
        {
            string eliminarGuia = $@"
                <soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:ser=""http://servicio.wstomaservicios.guatex.com/"">
                   <soapenv:Header/>
                   <soapenv:Body>
                      <ser:eliminarServicioGTX>
                         <!--Optional:-->
                         <xmlentrada>
         	                <![CDATA[
                               <ELIMINAR_GUIA>
                                  <USUARIO>{Properties.Settings.Default["UsuarioTomaServicio"]}</USUARIO>
                                  <PASSWORD>{Properties.Settings.Default["PasswordTomaServicio"]}</PASSWORD>
                                  <CODIGO_COBRO>{Properties.Settings.Default["CodigoCobroTomaServicio"]}</CODIGO_COBRO>
                                  <NUMERO_GUIA>{numeroGuia}</NUMERO_GUIA>
                               </ELIMINAR_GUIA>
	                        ]]>
                         </xmlentrada>
                      </ser:eliminarServicioGTX>
                   </soapenv:Body>
                </soapenv:Envelope>";
            string endpoint = Properties.Settings.Default["UrlEliminarGuia"].ToString();
            XmlDocument text = BaseRequests.Execute(endpoint, eliminarGuia);
            if (text.InnerText.Contains("<EXITO>")) return true;
            else throw new Exception("Hubo un error cancelando la guía");
        }
    }
}
