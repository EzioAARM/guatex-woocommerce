using GuatexWoocommerce.Models;
using System.Xml;
using System.Xml.Linq;

namespace GuatexWoocommerce.GuatexService
{
    public class Consultas
    {
        /// <summary>
        /// Consulta los municipios permitidos por GUATEX
        /// </summary>
        /// <returns>Objeto que contiene los destinos y tipos de envíos</returns>
        public GuatexConsultaMunicipios ConsultaMunicipios()
        {
            try
            {
                string municipios = $@"
                <soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:ser=""http://servicio.wsmunicipiosgtx.guatex.com/"">
                   <soapenv:Header/>
                   <soapenv:Body>
                      <ser:consultarMunicipios>
                         <!--Optional:-->
                         <xmlCredenciales><![CDATA[
                            <CONSULTA_MUNICIPIOS>
                               <USUARIO>{Properties.Settings.Default["UsuarioMunicipios"]}</USUARIO>
                               <PASSWORD>{Properties.Settings.Default["PasswordMunicipios"]}</PASSWORD>
                               <CODIGO_COBRO>{Properties.Settings.Default["CodigoCobroMunicipios"]}</CODIGO_COBRO>
                            </CONSULTA_MUNICIPIOS>
                         ]]></xmlCredenciales>
                      </ser:consultarMunicipios>
                   </soapenv:Body>
                </soapenv:Envelope>";
                string endpoint = Properties.Settings.Default["UrlMunicipios"].ToString();
                XmlDocument text = BaseRequests.Execute(endpoint, municipios);
                string destinosContent = "";
                foreach (XmlNode node in text.DocumentElement.ChildNodes[0].ChildNodes[0].ChildNodes)
                {
                    if (node.Name == "return")
                    {
                        destinosContent = node.InnerText;
                    }
                }
                GuatexConsultaMunicipios guatexConsultaMunicipios = new();
                XDocument.Parse(destinosContent)
                    .Descendants("DESTINOS")
                    .Elements()
                    .ToList()
                    .ForEach(destino =>
                    {
                        guatexConsultaMunicipios.Destinos.Add(new Destino()
                        {
                            Codigo = int.Parse(destino.Element("CODIGO").Value),
                            Nombre = destino.Element("NOMBRE").Value,
                            PuntoCobertura = destino.Element("PUNTO_COBERTURA").Value,
                            TipoTarifa = destino.Element("TIPO_TARIFA").Value,
                            Departamento = destino.Element("DEPARTAMENTO")?.Value,
                            Municipio = destino.Element("MUNICIPIO")?.Value,
                            FrecuenciaVisita = destino.Element("FRECUENCIA_VISITA")?.Value,
                            RecogeOficina = destino.Element("RECOGE_OFICINA").Value == "1",
                            Depto = Convert.ToInt32(destino.Element("DEPTO")?.Value),
                            Muni = Convert.ToInt32(destino.Element("MUNI")?.Value),
                        });
                    });
                XDocument.Parse(destinosContent)
                    .Descendants("TIPOS_ENVIO")
                    .Elements()
                    .ToList()
                    .ForEach(destino =>
                    {
                        guatexConsultaMunicipios.TiposEnvio.Add(new TipoEnvio()
                        {
                            Codigo = int.Parse(destino.Element("CODIGO").Value),
                            Nombre = destino.Element("NOMBRE").Value
                        });
                    });
                return guatexConsultaMunicipios;
            }
            catch
            {
                throw;
            }
        }
    }
}
