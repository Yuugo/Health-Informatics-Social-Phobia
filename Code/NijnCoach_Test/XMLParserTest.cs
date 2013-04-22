using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NijnCoach;
using System.IO;

namespace NijnCoach_Test
{
    [TestFixture]
    class XMLParserTest
    {
        XMLParser parser;
        [TestFixtureSetUp]
        public void setUp()
        {
            parser = new XMLParser();
        }
        
        [Test]
        [ExpectedException(typeof(FileNotFoundException))]
        public void invalidFile()
        {
            parser.readXMLFromFile("asdf.xml");
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void emptyXML()
        {
            StreamReader reader = stringToStreamReader("");
            parser.readXML(reader);
        }


        private StreamReader stringToStreamReader(String s)
        {
            byte[] byteArray = Encoding.ASCII.GetBytes(s);
            MemoryStream stream = new MemoryStream(byteArray);
            return new StreamReader(stream);
        }
    }
}
