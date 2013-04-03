using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace NijnCoach.XMLclasses
{
    public class Option
    {
        [XmlAttribute("tag")]
        String tag { get; set; }

        [XmlAttribute("emotion")]
        String emotion { get; set; }

        [XmlAttribute("value")]
        String value { get; set; }
    }
}
