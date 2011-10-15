using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Trafikverket_API.Models;

namespace Trafikverket_API
{
    public class Get
    {
        /// <summary>
        /// Get a list of all stations from Trafikverket.se
        /// </summary>
        /// <returns>List of Station objects</returns>
        public static List<Station> Stations()
        {
            XmlDocument doc = HttpPost(@"
                            <ORIONML version='1.0'>
                                <REQUEST plugin='KartDB'>
                                    <PLUGINML table='Stations'></PLUGINML>
                                </REQUEST>
                            </ORIONML>");


            XmlSerializer ser = new XmlSerializer(typeof(Models.stationORIONML));
            Models.stationORIONML orionml;
            using (XmlTextReader reader = new XmlTextReader(new StringReader(doc.OuterXml)))
            {
                orionml = (Models.stationORIONML)ser.Deserialize(reader);
            }

            List<Station> stations = orionml.RESPONSE[0].Stations.ToList();

            return stations;
        }

        /// <summary>
        /// Get a list of all messages
        /// </summary>
        /// <returns>List of Message objects</returns>
        public static List<Message> Messages()
        {
            XmlDocument doc = HttpPost(@"
                            <ORIONML version='1.0'>
                                <REQUEST plugin='KartDB' locale='SE_sv'>
                                    <PLUGINML table='Messages' />
                                </REQUEST>
                            </ORIONML>");

            XmlSerializer ser = new XmlSerializer(typeof(Models.messageORIONML));
            Models.messageORIONML orionml;
            using (XmlTextReader reader = new XmlTextReader(new StringReader(doc.OuterXml)))
            {
                orionml = (Models.messageORIONML)ser.Deserialize(reader);
            }

            List<Message> messages = orionml.RESPONSE[0].Messages.ToList();

            // TODO: Loop each message and add a list of stations by read the data in "PaverkadePlatser" and match with Station.Signatur

            return messages;
        }

        public static List<Trafiklage> Trafiklage(string TrafikplatsNamn, int Status)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"<ORIONML version='1.0'>
                                <REQUEST plugin='WOW' version='' locale='SE_sv'>
                                    <PLUGINML
                                        table='LpvTrafiklagen' ");
            sb.Append("filter=\"TrafikplatsNamn = '" + TrafikplatsNamn + "'");

            if (Status == 1)
            {
                sb.Append(" AND ArAnkomstTag = true AND (AnnonseradTidpunktAnkomst > datetime('now','localtime','-0 minute') AND (datetime('now','+14 hour') > AnnonseradTidpunktAnkomst))\"");
            }
            else
            {
                sb.Append(" AND ArAvgangTag = true AND (AnnonseradTidpunktAvgang > datetime('now','localtime','-0 minute') AND (datetime('now','+14 hour') > AnnonseradTidpunktAvgang))\"");
            }

            sb.Append(@" orderby='' selectcolumns='' />
                        </REQUEST>
                    </ORIONML>");
            XmlDocument doc = HttpPost(sb.ToString());

            XmlSerializer ser = new XmlSerializer(typeof(Models.trafiklageORIONML));
            Models.trafiklageORIONML orionml;
            using (XmlTextReader reader = new XmlTextReader(new StringReader(doc.OuterXml)))
            {
                orionml = (Models.trafiklageORIONML)ser.Deserialize(reader);
            }

            List<Trafiklage> trafiklagen = orionml.RESPONSE[0].LpvTrafiklagen.ToList();

            List<Trafiklage> result = (from e in trafiklagen
                                       orderby e.AnnonseradTidpunktAvgang
                                       select e).ToList();

            return result;
        }

        public static List<TrainInfo> Train(string TagGrupp)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<ORIONML version=\"1.0\"><REQUEST plugin=\"WOW\" version=\"\" locale=\"SE_sv\"><PLUGINML table=\"LpvTrafiklagen\" ");
            sb.Append("filter=\"TagGrupp = '" + TagGrupp + "'\" orderby=\"TagGrupp,TagGruppOrdning\" selectcolumns=\"\"></PLUGINML></REQUEST></ORIONML>");

            XmlDocument doc = HttpPost(sb.ToString());

            XmlSerializer ser = new XmlSerializer(typeof(Models.traininfoORIONML));
            Models.traininfoORIONML orionml;
            using (XmlTextReader reader = new XmlTextReader(new StringReader(doc.OuterXml)))
            {
                orionml = (Models.traininfoORIONML)ser.Deserialize(reader);
            }

            List<TrainInfo> trafiklagen = orionml.RESPONSE[0].LpvTrafiklagen.ToList();


            return trafiklagen;
        }

        private static XmlDocument HttpPost(string sendXML)
        {
            XmlDocument xmldoc = null;
            HttpWebRequest req = null;
            HttpWebResponse rsp = null;
            try
            {
                string uri = "http://www.trafikverket.se/Trafikverket/Orion/OrionProxy.ashx";
                req = (HttpWebRequest)HttpWebRequest.Create(uri);

                req.Method = "POST";
                req.ContentType = "text/xml; encoding='utf-8'";

                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(sendXML);
                req.ContentLength = bytes.Length;
                Stream writer = req.GetRequestStream();
                writer.Write(bytes, 0, bytes.Length);
                writer.Close();

                // Send the data to the webserver
                rsp = (HttpWebResponse)req.GetResponse();

                if (rsp.StatusCode == HttpStatusCode.OK)
                {
                    //Get response stream 
                    Stream objResponseStream = rsp.GetResponseStream();

                    //Load response stream into XMLReader
                    XmlTextReader objXMLReader = new XmlTextReader(objResponseStream);

                    //Declare XMLDocument
                    xmldoc = new XmlDocument();
                    xmldoc.Load(objXMLReader);

                    //Close XMLReader
                    objXMLReader.Close();
                }
            }
            catch (WebException webEx)
            {
                Log("HttpPost - WebException: " + webEx.ToString());
            }
            catch (Exception ex)
            {
                Log("HttpPost - Exception: " + ex.ToString());
            }
            finally
            {
                if (req != null) req.GetRequestStream().Close();
                if (rsp != null) rsp.GetResponseStream().Close();
            }

            return xmldoc;
        }

        private static void Log(string logMessage)
        {
            // TODO: Log to file or something
        }
    }
}
