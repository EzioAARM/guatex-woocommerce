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
                        <LINEA_DETALLE>
                            <PIEZAS_DETALLE>{product.Cantidad}</PIEZAS_DETALLE>
                            <PESO_DETALLE>{product.Peso}</PESO_DETALLE>
                            <TIPO_ENVIO_DETALLE>{product.TipoEnvio}</TIPO_ENVIO_DETALLE>
                        </LINEA_DETALLE>";
                }
                string municipios = $@"
                <soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:ser=""http://servicio.wstomaservicios.guatex.com/"">
                   <soapenv:Header/>
                   <soapenv:Body>
                      <ser:tomaServicioGTX>
                         <!--Optional:-->
                         <xmlentrada>
                            <![CDATA[
                               <TOMA_SERVICIO>
                                  <USUARIO>{Properties.Settings.Default["UsuarioServicio"]}</USUARIO>
                                  <PASSWORD>{Properties.Settings.Default["PasswordServicio"]}</PASSWORD>
                                  <CODIGO_COBRO>{Properties.Settings.Default["CodigoCobroServicio"]}</CODIGO_COBRO>
                                  <SERVICIO>
                                     <TIPO_USUARIO>C</TIPO_USUARIO>
                                     <NOMBRE_REMITENTE>{Properties.Settings.Default["NombreRemitente"]}</NOMBRE_REMITENTE>
                                     <TELEFONO_REMITENTE>{addressPhone}</TELEFONO_REMITENTE>
                                     <DIRECCION_REMITENTE>{sendFromAddress}</DIRECCION_REMITENTE>
                                     <MUNICIPIO_ORIGEN>{idMunicipalityFrom}</MUNICIPIO_ORIGEN>
                                     <PUNTO_ORIGEN>A</PUNTO_ORIGEN>
                                     <ESTA_LISTO>S</ESTA_LISTO>
                                     <CODORIGEN>{idMunicipalityFrom}</CODORIGEN>
                                     <GUIA>
                                           <LLAVE_CLIENTE>{clientId}</LLAVE_CLIENTE>
                                           <CODIGO_COBRO_GUIA>{codigoCobroGuia}</CODIGO_COBRO_GUIA>
                                           <NOMBRE_DESTINATARIO>{clientName}</NOMBRE_DESTINATARIO>
                                           <TELEFONO_DESTINATARIO>{clientPhone}</TELEFONO_DESTINATARIO>
                                           <DIRECCION_DESTINATARIO>{clientFullAddress}</DIRECCION_DESTINATARIO>
                                           <MUNICIPIO_DESTINO>{clientMunicipalityId}</MUNICIPIO_DESTINO>
                                           <DESCRIPCION_ENVIO>{description}</DESCRIPCION_ENVIO>
                                           <RECOGE_OFICINA>{recogerOficina}</RECOGE_OFICINA>
                                           <CODDESTINO>{clientMunicipalityId}</CODDESTINO>
                                           <DETALLE_GUIA>
                                              <LINEA_DETALLE_GUIA>
                                                 {lineasDetalle}
                                              </LINEA_DETALLE_GUIA>
                                           </DETALLE_GUIA>
                                     </GUIA>
                                  </SERVICIO>
                               </TOMA_SERVICIO>
                            ]]>
                         </xmlentrada>
                      </ser:tomaServicioGTX>
                   </soapenv:Body>
                </soapenv:Envelope>";
                string endpoint = Properties.Settings.Default["UrlMunicipios"].ToString();
                XmlDocument text = BaseRequests.Execute(endpoint, municipios);
                File.WriteAllText("service_response.txt", text.ToString());
                string destinosContent = "";
                foreach (XmlNode node in text.DocumentElement.ChildNodes[0].ChildNodes[0].ChildNodes)
                {
                    if (node.Name == "return")
                    {
                        destinosContent = node.InnerText;
                    }
                }
                XElement elemento = XDocument.Parse(destinosContent)
                    .Descendants("SERVICIO")
                    .Elements()
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
                //.ForEach(destino =>
                //{
                //    guatexConsultaMunicipios.Destinos.Add(new Destino()
                //    {
                //        Codigo = int.Parse(destino.Element("CODIGO").Value),
                //        Nombre = destino.Element("NOMBRE").Value,
                //        PuntoCobertura = destino.Element("PUNTO_COBERTURA").Value,
                //        TipoTarifa = destino.Element("TIPO_TARIFA").Value,
                //        Departamento = destino.Element("DEPARTAMENTO")?.Value,
                //        Municipio = destino.Element("MUNICIPIO")?.Value,
                //        FrecuenciaVisita = destino.Element("FRECUENCIA_VISITA")?.Value,
                //        RecogeOficina = destino.Element("RECOGE_OFICINA").Value == "1",
                //        Depto = Convert.ToInt32(destino.Element("DEPTO")?.Value),
                //        Muni = Convert.ToInt32(destino.Element("MUNI")?.Value),
                //    });
                //});
                //XDocument.Parse(destinosContent)
                //    .Descendants("TIPOS_ENVIO")
                //    .Elements()
                //    .ToList()
                //    .ForEach(destino =>
                //    {
                //        guatexConsultaMunicipios.TiposEnvio.Add(new TipoEnvio()
                //        {
                //            Codigo = int.Parse(destino.Element("CODIGO").Value),
                //            Nombre = destino.Element("NOMBRE").Value
                //        });
                //    });
                //return guatexConsultaMunicipios;
                return null;
            }
            catch
            {
                throw;
            }
        }
    }
}
