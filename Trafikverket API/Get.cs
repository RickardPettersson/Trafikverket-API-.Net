using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Xml;

namespace Trafikverket_API
{
    public class Get
    {

        public static XmlDocument GetStations()
        {
            return HttpPost(@"
                            <ORIONML version='1.0'>
                                <REQUEST plugin='KartDB'>
                                    <PLUGINML table='Stations'></PLUGINML>
                                </REQUEST>
                            </ORIONML>");
        }

        public static XmlDocument GetMessages()
        {
            return HttpPost(@"
                            <ORIONML version='1.0'>
                                <REQUEST plugin='KartDB' locale='SE_sv'>
                                    <PLUGINML table='Messages' />
                                </REQUEST>
                            </ORIONML>");
        }

        public static XmlDocument GetTrafikinfo()
        {
            return HttpPost(@"
                            <ORIONML version='1.0'>
                                <REQUEST plugin='WOW' version='' locale='SE_sv'>
                                    <PLUGINML
                                        table='LpvTrafiklagen'
                                        filter=""TrafikplatsNamn = 'Stockholm C' AND (AnnonseradTidpunktAvgang > datetime('now','localtime','-15 minute') AND (datetime('now','+14 hour') > AnnonseradTidpunktAvgang))""
                                        orderby=''
                                        selectcolumns='' />
                                </REQUEST>
                            </ORIONML>");
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

                byte[] bytes = System.Text.Encoding.ASCII.GetBytes(sendXML);
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
