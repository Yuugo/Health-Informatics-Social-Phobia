using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace NijnCoach.XMLclasses
{
    [XmlRoot("openQuestion")]
    public class OpenQuestion : IEntry
    {
        [XmlElement("question")]
        public String question { get; set; }

        [XmlElement("audio")]
        public String audio { get; set; }

        //[XML] logic done inside the Answer class.
        public String theAnswer { get; set; }
    }
}
