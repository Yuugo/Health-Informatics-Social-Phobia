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
        private const String xmlComment = "<IEntry AssemblyQualifiedName=\"NijnCoach.XMLclasses.Comment, NijnCoach, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\"><comment><value>blabla</value><emotion>happy</emotion></comment></IEntry>";
        private const String xmlOpenQuestion = "<IEntry AssemblyQualifiedName=\"NijnCoach.XMLclasses.OpenQuestion, NijnCoach, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\"><openQuestion><question>What was the most difficult situation? Please tell me how it went.</question><theAnswer /></openQuestion></IEntry>";
        private const String xmlMcQuestion = "<IEntry AssemblyQualifiedName=\"NijnCoach.XMLclasses.MCQuestion, NijnCoach, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\"><MCQuestion><question>How many social encounters did you have last week?</question><options><Option><tag>a</tag><emotion>angry</emotion><answer>1-3</answer></Option><Option><tag>b</tag><emotion>happy</emotion><answer>4-6</answer></Option><Option><tag>c</tag><emotion>neutral</emotion><answer>7 or more</answer></Option></options><theAnswer /></MCQuestion></IEntry>";

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
        public void commentTest()
        {
            StreamReader reader = stringToStreamReader(begin + "<entries>" + xmlComment + "</entries>" + end);
            Questionnaire theForm = parser.readXML(reader);
            Assert.NotNull(theForm.entries);
            Assert.AreEqual(1, theForm.entries.Count);
            Assert.IsInstanceOf<Comment>(theForm.entries[0]);
            Comment comment = (Comment) theForm.entries[0];
            Assert.AreEqual("blabla", comment.value);
            Assert.AreEqual("happy", comment.emotion);
        }

        [Test]
        public void openQuestionTest()
        {
            StreamReader reader = stringToStreamReader(begin + "<entries>" + xmlOpenQuestion + "</entries>" + end);
            Questionnaire theForm = parser.readXML(reader);
            Assert.NotNull(theForm.entries);
            Assert.IsInstanceOf<OpenQuestion>(theForm.entries[0]);
            OpenQuestion openQuestion = (OpenQuestion)theForm.entries[0];
            Assert.AreEqual("What was the most difficult situation? Please tell me how it went.", openQuestion.question);
            Assert.AreEqual("", openQuestion.theAnswer);
        }

        [Test]
        public void mcQuestionTest()
        {
            StreamReader reader = stringToStreamReader(begin + "<entries>" + xmlMcQuestion + "</entries>" + end);
            Questionnaire theForm = parser.readXML(reader);
            Assert.NotNull(theForm.entries);
            Assert.IsInstanceOf<MCQuestion>(theForm.entries[0]);
            MCQuestion mcQuestion = (MCQuestion)theForm.entries[0];
            Assert.AreEqual("How many social encounters did you have last week?", mcQuestion.question);
            Assert.AreEqual("", mcQuestion.theAnswer);
        }

        [Test]
        public void mcQuestionOptionsTest()
        {
            StreamReader reader = stringToStreamReader(begin + "<entries>" + xmlMcQuestion + "</entries>" + end);
            Questionnaire theForm = parser.readXML(reader);
            MCQuestion mcQuestion = (MCQuestion)theForm.entries[0];
            Assert.NotNull(mcQuestion.options);
            Assert.AreEqual(3, mcQuestion.options.Count);
            Assert.AreEqual("a", mcQuestion.options[0].tag);
            Assert.AreEqual("1-3", mcQuestion.options[0].answer);
            Assert.AreEqual("angry", mcQuestion.options[0].emotion);
            Assert.AreEqual("b", mcQuestion.options[1].tag);
            Assert.AreEqual("4-6", mcQuestion.options[1].answer);
            Assert.AreEqual("happy", mcQuestion.options[1].emotion);
            Assert.AreEqual("c", mcQuestion.options[2].tag);
            Assert.AreEqual("7 or more", mcQuestion.options[2].answer);
            Assert.AreEqual("neutral", mcQuestion.options[2].emotion);
        }


        private StreamReader stringToStreamReader(String s)
        {
            byte[] byteArray = Encoding.ASCII.GetBytes(s);
            MemoryStream stream = new MemoryStream(byteArray);
            return new StreamReader(stream);
        }
    }
}
