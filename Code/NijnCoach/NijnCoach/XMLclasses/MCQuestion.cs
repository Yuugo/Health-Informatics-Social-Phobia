using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace NijnCoach.XMLclasses
{
    public class MCQuestion : Entry
    {
        [XmlAttribute("value")]
        String value { get; set; }

        [XmlAttribute("options")]
        List<Option> options { get; set; }

        [XmlAttribute("answer")]
        Answer theAnswer { get; set; }
    }
}
