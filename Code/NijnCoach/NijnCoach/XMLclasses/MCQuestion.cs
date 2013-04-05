using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace NijnCoach.XMLclasses
{
    public class MCQuestion : IEntry
    {
        //[XML] logic done inside the Option class.
        [XmlArray]
        public List<Option> options { get; set; }

        //[XML] logic done inside the Answer class.
        public Answer theAnswer { get; set; }
    }
}
