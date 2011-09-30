using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Trafikverket_API.Models
{
    [XmlRoot("Station")]
    public class Station
    {
        [XmlAttribute("Id")]
        public string Id { get; set; }

        [XmlAttribute("EPSG")]
        public string EPSG { get; set; }

        [XmlAttribute("IkonNiva")]
        public string IkonNiva { get; set; }

        [XmlAttribute("Namn")]
        public string Namn { get; set; }

        [XmlAttribute("Signatur")]
        public string Signatur { get; set; }

        [XmlAttribute("Timestamp")]
        public DateTime Timestamp { get; set; }

        [XmlAttribute("EW")]
        public int EW { get; set; }

        [XmlAttribute("NS")]
        public string NS { get; set; }

        [XmlAttribute("CountyNo")]
        public int CountyNo { get; set; }

        [XmlAttribute("Prognostisering")]
        public bool Prognostisering { get; set; }
    }
}
