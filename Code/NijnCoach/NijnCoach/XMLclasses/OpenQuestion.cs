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

        [XmlElement("emotion")]
        public String emotion { get; set; }

        //[XML] logic done inside the Answer class.
        public String theAnswer { get; set; }

        public String Audio()
        {
            return audio;
        }

        public String Emotion()
        {
            return emotion;
        }
    }
}
