using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace NijnCoach.XMLclasses
{
    public class Questionnaire
    {
        [XmlRoot("header")]
        public class Header
        {
            [XmlElement("questionnaireNumber")]
            public Int16 number { get; set; }

            [XmlElement("createdBy")]
            public String createdBy { get; set; }

            [XmlElement("createdDate")]
            public DateTime dateCreated { get; set; }

            [XmlElement("filledBy")]
            public String filledBy { get; set; }

            [XmlElement("filledDate")]
            public DateTime dateFilled { get; set; }
        }
        [XmlAttribute("version")]
        public Double version { get; set; }
        
        public Header head { get; set; }

        public ListOfIEntry entries { get; set; }
    }
}
