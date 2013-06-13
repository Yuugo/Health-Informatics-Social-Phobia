using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace NijnCoach.XMLclasses
{
    [XmlRoot("comment")]
    public class Comment : IEntry
    {
        [XmlElement("value")]
        public String value { get; set; }

        [XmlElement("audio")]
        public String audio { get; set; }

        [XmlElement("emotion")]
        public String emotion { get; set; }

        [XmlElement("answer")]
        public String theAnswer { get; set; }

        public String Audio()
        {
            return audio;
        }

        public String Answer()
        {
            return "";
        }

        public String Emotion()
        {
            return emotion;
        }
    }
}
