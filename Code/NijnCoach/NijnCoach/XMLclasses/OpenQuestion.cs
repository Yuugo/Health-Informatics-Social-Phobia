using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace NijnCoach.XMLclasses
{
    class OpenQuestion
    {
        [XmlAttribute("value")]
        String value { get; set; }

        [XmlAttribute("answer")]
        Answer theAnswer { get; set; }
    }
}
