using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace NijnCoach.XMLclasses
{
    public class MCQuestion : IEntry
    {
        [XmlElement("question")]
        public String question { get; set; }

        //[XML] logic done inside the Option class.
        [XmlArray]
        public List<Option> options { get; set; }

        [XmlElement("answer")]
        public String theAnswer { get; set; }
    }
}
