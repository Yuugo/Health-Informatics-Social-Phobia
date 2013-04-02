using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace NijnCoach
{
    class XMLParser
    {
        XmlDocument doc { get; set; }

        /*
         * Constructor class, loads the Xml file from path given in parameter.
         */
        public XMLParser(string name)
        {
            doc.LoadXml(name);
        }

        public static void Main(String[] args)
        {

        }
        
    }
}
