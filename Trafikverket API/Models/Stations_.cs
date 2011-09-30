using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Trafikverket_API.Models
{
    [XmlRoot("Stations")]
    public class Stations_
    {
        public Stations_() { Items = new List<Station>(); }

        [XmlArray("Station")]
        public List<Station> Items { get; set; }
    }
}
