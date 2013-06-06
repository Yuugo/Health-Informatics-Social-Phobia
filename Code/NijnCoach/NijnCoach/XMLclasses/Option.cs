using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace NijnCoach.XMLclasses
{
    [XmlRoot("option")]
    public class Option
    {
        [XmlElement("tag")]
        public String tag { get; set; }

        [XmlElement("emotion")]
        public String emotion { get; set; }

        [XmlElement("answer")]
        public String answer { get; set; }


    }
}
