using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NijnCoach;
using System.IO;
using NijnCoach.XMLclasses;

namespace NijnCoach_Test
{
    [TestFixture]
    class XMLParserTest
    {
        XMLParser parser;
        private const String begin = "<Questionnaire version=\"1\"><head><questionnaireNumber>0</questionnaireNumber><createdBy>Me</createdBy><createdDate>0001-01-01T00:00:00</createdDate><filledBy>Him</filledBy><filledDate>0001-01-01T00:00:00</filledDate></head>";
        private const String end = "</Questionnaire>";


        [TestFixtureSetUp]
        public void setUp()
        {
            parser = new XMLParser();
        }
        

        [Test]
        public void emptyQuestionnaireTest()
        {
            StreamReader reader = stringToStreamReader(begin+end);
            Questionnaire theForm = parser.readXML(reader);
            Assert.NotNull(theForm.head);
            Assert.AreEqual(0, theForm.head.number);
            Assert.AreEqual("Me", theForm.head.createdBy);
            Assert.AreEqual( "Him", theForm.head.filledBy);
            Assert.AreEqual(new DateTime(1,1,1,0,0,0), theForm.head.dateCreated);
            Assert.AreEqual(new DateTime(1, 1, 1, 0, 0, 0), theForm.head.dateFilled);
        }

        [Test]
        public void questionnaireWithOneEntryTest()
        {
            StreamReader reader = stringToStreamReader(begin + "<entries></entries>" + end);
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
