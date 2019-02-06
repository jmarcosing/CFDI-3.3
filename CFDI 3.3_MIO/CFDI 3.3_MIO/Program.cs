using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace CFDI_3._3_MIO
{
    class Program
    {
        static private string path = @"C:\Users\Juan Camilo\source\repos\CFDI 3.3_MIO\";

        static private void Main(string[] args)
        {
            //obtener numero de certificado-----------------------------------------------------------------------------------
            //modifiquen por su path

            //string pathCer = path + @"CFDI 3.3_MIO\CSD01_AAA010101AAA.cer";
            // string pathKey = path + @"CFDI 3.3_MIO\CSD01_AAA010101AAA.key";
            // string clavePrivada = "12345678a";

            //OBTENEMOS EL NUMERO
            //string numeroCertificado, aa, b, c;



            //LLEMANOS LA CLASE COMPROBATE
            Comprobante oComprobante = new Comprobante();
            oComprobante.Version = "3.3";
            oComprobante.Serie = "H";
            oComprobante.Folio = "1";
            oComprobante.Fecha = DateTime.Now.ToString("yyyy-MM-ddtHH:mm:ss");
            oComprobante.Sello = "";
            oComprobante.FormaPago = "99";
            oComprobante.NoCertificado = "";
            oComprobante.Certificado = "";
            oComprobante.SubTotal = 10m;
            oComprobante.Descuento = 1;
            oComprobante.Moneda = "MXN";
            oComprobante.Total = 9;
            oComprobante.TipoDeComprobante = "I";
            oComprobante.MetodoPago = "PUE";
            oComprobante.LugarExpedicion = "20131";

            ComprobanteEmisor oEmisor = new ComprobanteEmisor();
            oEmisor.Rfc = "POWE8710601DM7";
            oEmisor.Nombre = "UNA RAZON";
            oEmisor.RegimenFiscal = "605";

            ComprobanteReceptor oReceptor = new ComprobanteReceptor();
            oReceptor.Nombre = "PEPE SA DE CV";
            oReceptor.Rfc = "PEPE0808013H1";
            oReceptor.UsoCFDI = "P01";            

            oComprobante.Emisor = oEmisor;
            oComprobante.Receptor = oReceptor;

            List<ComprobanteConcepto> lstConceptos = new List<ComprobanteConcepto>();
            ComprobanteConcepto oConcepto = new ComprobanteConcepto();
            oConcepto.Importe = 19.2m;
            oConcepto.ClaveProdServ = "92111704";
            oConcepto.Cantidad = 1;
            oConcepto.ClaveUnidad = "C81";
            oConcepto.Descripcion = "un misil para la guerra";
            oConcepto.ValorUnitario = 10m;
            oConcepto.Descuento = 1;

            lstConceptos.Add(oConcepto);

            oComprobante.Conceptos = lstConceptos.ToArray();


            XML(oComprobante);

        }

        static void XML(Comprobante oComprobante)
        {
            string pathXML = path +@"miPrimerXML.xml";

            XmlSerializer oXmlSerializar = new XmlSerializer(typeof(Comprobante));

            string sXml = "";

            using (var sww = new StringWriter())
            {
                using (XmlWriter writter = XmlWriter.Create(sww))
                {
                    oXmlSerializar.Serialize(writter, oComprobante);
                    sXml = sww.ToString();
                }
            }

            //guardamos el string en un archivo
            System.IO.File.WriteAllText(pathXML, sXml);

        }
        
    }
}
