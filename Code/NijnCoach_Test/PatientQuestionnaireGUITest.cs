using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Reflection;
using System.Threading;
using NUnit.Framework;
using NijnCoach.View.Questionnaire;
using NijnCoach.XMLclasses;
using NijnCoach;

namespace NijnCoach_Test
{
    [TestFixture]
    class PatientQuestionnaireGUITest: GuiTest
    {
        private const string xmlFile = "writeTest.xml";
        private XMLParser parser = null;
        private object[] _parameters = null;
        private String _assembly = "NijnCoach.exe";
        private String _form = "NijnCoach.View.Questionnaire.QuestionnaireForm";

        public override object[] getParameters()
        {
            return _parameters;
        }

        public override String getAssembly()
        {
            return _assembly;
        }

        public override String getForm()
        {
            return _form;
        }

        [TestFixtureSetUp]
        public override void setUp()
        {
            parser = new XMLParser();
            Questionnaire theForm = parser.readXMLFromFile(xmlFile);
            _parameters = new object[1] {theForm};
            base.setUp();
        }

        [Test]
        public void commentTest()
        {
            object commentText = GetProperty("panelQuestionIntern.labelComment.Text");
            Assert.AreEqual("blabla", commentText);
        }

        [Test]
        public void openQuestion()
        {
            Thread.Sleep(1000);
            RaiseEvent("buttonNext", "Click", new EventArgs());
            Thread.Sleep(1000);
            object openQuestionText = GetProperty("panelQuestionIntern.labelQuestion.Text");
            object openQuestionAnswer = GetProperty("panelQuestionIntern.textBoxAnswer.Text");
            Assert.AreEqual("What was the most difficult situation? Please tell me how it went.", openQuestionText);
            Assert.AreEqual("", openQuestionAnswer);
        }


    }
}
