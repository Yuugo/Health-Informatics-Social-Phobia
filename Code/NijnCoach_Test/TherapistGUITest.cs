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


namespace NijnCoach_Test
{
    [TestFixture]
    class TherapistGUITest : GuiTest
    {
        private object[] _parameters = null;

        private String _assembly = "NijnCoach.exe";
        private String _form = "NijnCoach.TherapistGUI.Form1";

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
           // Object theForm = new Form1();
           // _parameters = new object[1] { new Form1() };
           // base.setUp();
        }

        [Test]
        public void test1()
        {
            object selectedRadioButton = GetProperty("radioButton1.Checked");
            Assert.AreEqual(true, selectedRadioButton);
        }


    }
}
