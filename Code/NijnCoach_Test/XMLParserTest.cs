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
        [Test]
        [ExpectedException(typeof(FileNotFoundException))]
        public void invalidFile()
        {
            XMLParser parser = new XMLParser();
            parser.readXMLFromFile("");
        }
    }
}
