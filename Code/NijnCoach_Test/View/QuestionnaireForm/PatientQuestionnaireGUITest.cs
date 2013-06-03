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
using System.Collections.Generic;

namespace NijnCoach_Test.View.QuestionnaireForm
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

        [SetUp]
        public override void setUp()
        {
            parser = new XMLParser();
            Questionnaire theForm = parser.readXMLFromFile(xmlFile);
            _parameters = new object[2] {theForm, false};
            base.setUp();
        }

        [Test]
        public void commentTest()
        {
            object commentText = GetProperty("panelQuestionIntern.labelComment.Text");
            Assert.AreEqual("blabla", commentText);
        }

        [Test]
        public void openQuestionTextTest()
        {
            RaiseEvent("buttonNext", "Click", new EventArgs());
            object openQuestionText = GetProperty("panelQuestionIntern.labelQuestion.Text");
            object openQuestionAnswer = GetProperty("panelQuestionIntern.textBoxAnswer.Text");
            Assert.AreEqual("What was the most difficult situation? Please tell me how it went.", openQuestionText);
            Assert.AreEqual("", openQuestionAnswer);
        }

        [Test]
        public void mcQuestionTextTest()
        {
            RaiseEvent("buttonNext", "Click", new EventArgs());
            RaiseEvent("buttonNext", "Click", new EventArgs());
            object mcQuestionText = GetProperty("panelQuestionIntern.labelQuestion.Text");
            Assert.AreEqual("How many social encounters did you have last week?", mcQuestionText);
        }

        [Test]
        public void mcQuestionOptionsTest()
        {
            RaiseEvent("buttonNext", "Click", new EventArgs());
            RaiseEvent("buttonNext", "Click", new EventArgs());
            System.Windows.Forms.Control.ControlCollection options = (System.Windows.Forms.Control.ControlCollection)GetProperty("panelQuestionIntern.Controls");
            Control[] radios = (Control[]) options.Find("Radioa", false);
            String text = radios[0].Text;
            Assert.AreEqual("1-3", text);
        }

    }
}
