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
            object panelQuestion = GetField(testForm, "panelQuestionIntern");
            object labelComment = GetField(panelQuestion, "labelComment");
            object commentText = GetProperty(labelComment, "Text");
            Assert.AreEqual("blabla", commentText);
            //InvokeMethod("nextEventHandler");
        }


    }
}
