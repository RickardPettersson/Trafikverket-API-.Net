﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.5446
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Xml.Serialization;

// 
// This source code was auto-generated by xsd, Version=2.0.50727.3038.
// 
namespace Trafikverket_API.Models
{

    [XmlRoot("ORIONML")]
    public partial class stationORIONML
    {

        private stationORIONMLRESPONSE[] rESPONSEField;

        private string versionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("RESPONSE", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public stationORIONMLRESPONSE[] RESPONSE
        {
            get
            {
                return this.rESPONSEField;
            }
            set
            {
                this.rESPONSEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string version
        {
            get
            {
                return this.versionField;
            }
            set
            {
                this.versionField = value;
            }
        }
    }

    [XmlRoot("RESPONSE")]
    public partial class stationORIONMLRESPONSE
    {

        private Station[] stationsField;

        private string localeField;

        private string pluginField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("Station", typeof(Station), Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        public Station[] Stations
        {
            get
            {
                return this.stationsField;
            }
            set
            {
                this.stationsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string locale
        {
            get
            {
                return this.localeField;
            }
            set
            {
                this.localeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string plugin
        {
            get
            {
                return this.pluginField;
            }
            set
            {
                this.pluginField = value;
            }
        }
    }

    [XmlRoot("Station")]
    public partial class Station
    {

        private string idField;

        private string ePSGField;

        private string ikonNivaField;

        private string namnField;

        private string signaturField;

        private string timestampField;

        private string ewField;

        private string nsField;

        private string countyNoField;

        private string prognostiseringField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Id")]
        public string Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EPSG")]
        public string EPSG
        {
            get
            {
                return this.ePSGField;
            }
            set
            {
                this.ePSGField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("IkonNiva")]
        public string IkonNiva
        {
            get
            {
                return this.ikonNivaField;
            }
            set
            {
                this.ikonNivaField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Namn")]
        public string Namn
        {
            get
            {
                return this.namnField;
            }
            set
            {
                this.namnField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Signatur")]
        public string Signatur
        {
            get
            {
                return this.signaturField;
            }
            set
            {
                this.signaturField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Timestamp")]
        public string Timestamp
        {
            get
            {
                return this.timestampField;
            }
            set
            {
                this.timestampField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EW")]
        public string EW
        {
            get
            {
                return this.ewField;
            }
            set
            {
                this.ewField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("NS")]
        public string NS
        {
            get
            {
                return this.nsField;
            }
            set
            {
                this.nsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CountyNo")]
        public string CountyNo
        {
            get
            {
                return this.countyNoField;
            }
            set
            {
                this.countyNoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Prognostisering")]
        public string Prognostisering
        {
            get
            {
                return this.prognostiseringField;
            }
            set
            {
                this.prognostiseringField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class NewDataSet
    {

        private stationORIONML[] itemsField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ORIONML")]
        public stationORIONML[] Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }
    }
}