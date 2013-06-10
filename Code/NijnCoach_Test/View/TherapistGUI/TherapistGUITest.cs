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
using NijnCoach.View.TherapistGUI;
using NijnCoach.View.Main;


namespace NijnCoach_Test.View.TherapistGUI
{
    [TestFixture]
    class TherapistGUITest : GuiTest
    {
        private object[] _parameters = new Object[0];
        private String _assembly = "NijnCoach.exe";
        private String _form = "NijnCoach.View.TherapistGUI.TherapistGUI";

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
            base.setUp();
            RaiseEvent("innerPanel.button1", "Click", new EventArgs());
        }

        protected override Form run()
        {
            MainClass.userNo = 2;
            return TherapistMain.main;
        }

        public virtual void clickOnOpenQuestion()
        {
            RaiseEvent("innerPanel.radioButton1", "Click", new EventArgs());
        }

        public virtual void clickOnMCradioButton()
        {
            RaiseEvent("innerPanel.radioButton2", "Click", new EventArgs());
        }

        public virtual void clickOnCommentradioButton()
        {
            RaiseEvent("innerPanel.radioButton3", "Click", new EventArgs());
        }

        public virtual void clickOnAddButton()
        {
            RaiseEvent("innerPanel.button2", "Click", new EventArgs());
        }

        public void clickOnRemoveButton()
        {
            RaiseEvent("innerPanel.button3", "Click", new EventArgs());
        }

        public void checkForVisibleQuestionLabelsToNumber(int j)
        {
            for (int i = 1; i <= j; i++)
            {
                Assert.IsTrue((bool)GetProperty("innerPanel.label" + i + ".Visible"));
            }     
        }

        public void checkForInVisibleQuestionLabelsFromNumber(int j)
        {
            for (int i = j; i <= 8; i++)
            {
                Assert.IsFalse((bool)GetProperty("innerPanel.label" + i + ".Visible"));
            }
        }

        public void checkForVisibleQuestionTextBoxesToNumber(int j)
        {
            for (int i = 1; i <= j; i++)
            {
                Assert.IsTrue((bool)GetProperty("innerPanel.textBox" + i + ".Visible"));
            }
        }

        public void checkForInVisibleQuestionTextBoxesFromNumber(int j)
        {
            for (int i = j; i <= 8; i++)
            {
                Assert.IsFalse((bool)GetProperty("innerPanel.textBox" + i + ".Visible"));
            }
        }

        public void checkForVisibleEmotionComboBoxToNumber(int j)
        {
            for (int i = 1; i <= j; i++)
            {
                Assert.IsTrue((bool)GetProperty("innerPanel.comboBox" + i + ".Visible"));
            }
        }

        public void checkForInVisibleEmotionComboBoxFromNumber(int j)
        {
            for (int i = j; i <= 8; i++)
            {
                Assert.IsFalse((bool)GetProperty("innerPanel.comboBox" + i + ".Visible"));
            }
        }

        #region overall tests
        [Test]
        public void testForVisibleAudioFrag()
        {
            Assert.IsTrue((bool)GetProperty("innerPanel.button4.Visible"));
        }

        [Test]
        public void testForClearAudioButton()
        {
            Object o = GetField("innerPanel.textBox9");
            ((TextBox)o).Text = "EEN RANDOM FILE";
            RaiseEvent("innerPanel.button6", "Click", new EventArgs());
            Assert.IsEmpty((String)GetProperty("innerPanel.textBox9.Text"));
        }

        #endregion



        #region Tests For Open Question

        
        [Test]
        public void testForCorrectRadioButtonCheckedinOpen()
        {
            clickOnOpenQuestion();
            Assert.IsTrue((bool) GetProperty("innerPanel.radioButton1.Checked"));
        }

        [Test]
        public void testForLabelQisQuestioninOpen()
        {
            clickOnOpenQuestion();
            Assert.AreEqual("Question", GetProperty("innerPanel.labelQ.Text"));
        }

        [Test]
        public void testForEmptyQuestionBoxinOpen()
        {
            clickOnOpenQuestion();
            Assert.IsEmpty((String)GetProperty("innerPanel.textBox0.Text"));
        }

        [Test]
        public void testForInvisibleAnswerEmotionLabelinOpen()
        {
            clickOnOpenQuestion();
            Assert.IsFalse((bool)GetProperty("innerPanel.label0.Visible"));
            Assert.IsTrue((bool)GetProperty("innerPanel.label9.Visible"));
        }

        [Test]
        public void testForInvisibleAddButtoninOpen()
        {
            clickOnOpenQuestion();
            Assert.IsFalse((bool) GetProperty("innerPanel.button2.Visible"));
        }

        [Test]
        public void testForInvisibleRemoveButtoninOpen()
        {
            clickOnOpenQuestion();
            Assert.IsFalse((bool)GetProperty("innerPanel.button3.Visible"));
        }

        [Test]
        public void testForInvisibleQuestionLabelsinOpen()
        {
            clickOnOpenQuestion();
            checkForInVisibleQuestionLabelsFromNumber(1);
        }

        [Test]
        public void testForInvisibleQuestionTextBoxesinOpen()
        {
            clickOnOpenQuestion();
            checkForInVisibleQuestionTextBoxesFromNumber(1);
        }

        [Test]
        public void testForVisibleEmotionComboBoxinOpen()
        {
            clickOnOpenQuestion();
            checkForVisibleEmotionComboBoxToNumber(1);
        }

        [Test]
        public void testForInvisibleEmotionComboBoxinOpen()
        {
            clickOnOpenQuestion();
            checkForInVisibleEmotionComboBoxFromNumber(2);
        }

        #endregion

        #region Multiple Choice Tests

        [Test]
        public void testForCheckedMCradioButtonInMC()
        {
            clickOnMCradioButton();
            Assert.IsTrue((bool)GetProperty("innerPanel.radioButton2.Checked"));
        }

        [Test]
        public void testForLabelQisQuestionInMC()
        {
            clickOnMCradioButton();
            Assert.AreEqual("Question", GetProperty("innerPanel.labelQ.Text"));
        }

        [Test]
        public void testForVisibleQuestionLabelsInMC()
        {
            clickOnMCradioButton();
            checkForVisibleQuestionLabelsToNumber(2);
        }


        [Test]
        public void testForInVisibleQuestionLabelsInMC()
        {
            clickOnMCradioButton();
            checkForInVisibleQuestionLabelsFromNumber(3);
        }

        [Test]
        public void testForVisibleQuestionTextBoxesInMC()
        {
            clickOnMCradioButton();
            checkForVisibleQuestionTextBoxesToNumber(2);
        }


        [Test]
        public void testForInVisibleQuestionTextBoxesInMC()
        {
            clickOnMCradioButton();
            checkForInVisibleQuestionTextBoxesFromNumber(3);
        }

        [Test]
        public void testForVisibleEmotionComboBoxInMC()
        {
            clickOnMCradioButton();
            checkForVisibleEmotionComboBoxToNumber(2);
        }


        [Test]
        public void testForInVisibleEmotionComboBoxInMC()
        {
            clickOnMCradioButton();
            checkForInVisibleEmotionComboBoxFromNumber(3);
        }

        [Test]
        public void testForVisibleAddButtonInMC()
        {
            clickOnMCradioButton();
            Assert.IsTrue((bool)GetProperty("innerPanel.button2.Visible"));
        }

        [Test]
        public void testForVisibleRemoveButtonInMC()
        {
            clickOnMCradioButton();
            Assert.IsTrue((bool)GetProperty("innerPanel.button3.Visible"));
        }

        [Test]
        public void testForVerifyWhenAddClickedInMC()
        {
            clickOnMCradioButton();
            clickOnAddButton();
            checkForVisibleQuestionLabelsToNumber(3);
            checkForVisibleQuestionTextBoxesToNumber(3);
            checkForVisibleEmotionComboBoxToNumber(3);

            checkForInVisibleQuestionLabelsFromNumber(4);
            checkForInVisibleQuestionTextBoxesFromNumber(4);
            checkForInVisibleEmotionComboBoxFromNumber(4);  
        }

        [Test]
        public void testForVerifyWhenRemoveClickedWithTwoOptionsInMC()
        {
            clickOnMCradioButton();
            clickOnRemoveButton();

            checkForVisibleQuestionLabelsToNumber(2);
            checkForVisibleQuestionTextBoxesToNumber(2);
            checkForVisibleEmotionComboBoxToNumber(2);

            checkForInVisibleQuestionLabelsFromNumber(3);
            checkForInVisibleQuestionTextBoxesFromNumber(3);
            checkForInVisibleEmotionComboBoxFromNumber(3);  
        }

        [Test]
        public void testForVerifyWhenRemoveClickedWithThreeOptionsInMC()
        {
            clickOnMCradioButton();
            clickOnAddButton();
            clickOnRemoveButton();

            checkForVisibleQuestionLabelsToNumber(2);
            checkForVisibleQuestionTextBoxesToNumber(2);
            checkForVisibleEmotionComboBoxToNumber(2);

            checkForInVisibleQuestionLabelsFromNumber(3);
            checkForInVisibleQuestionTextBoxesFromNumber(3);
            checkForInVisibleEmotionComboBoxFromNumber(3);
        }

        [Test]
        public void testForVisibleEmotionAnswerLabelInMC()
        {
            clickOnMCradioButton();
            Assert.IsTrue((bool)GetProperty("innerPanel.label0.Visible"));
            Assert.IsTrue((bool)GetProperty("innerPanel.label9.Visible"));
        }



        #endregion

        #region tests for Comment

        [Test]
        public void testForCorrectRadioButtonCheckedinComment()
        {
            clickOnCommentradioButton();
            Assert.IsTrue((bool)GetProperty("innerPanel.radioButton3.Checked"));
        }

        [Test]
        public void testForLabelQisCommentinComment()
        {
            clickOnCommentradioButton();
            Assert.AreEqual("Comment", GetProperty("innerPanel.labelQ.Text"));
        }

        [Test]
        public void testForEmptyQuestionBoxinComment()
        {
            clickOnCommentradioButton();
            Assert.IsEmpty((String)GetProperty("innerPanel.textBox0.Text"));
        }

        [Test]
        public void testForInvisibleAnswerEmotionLabelinComment()
        {
            clickOnCommentradioButton();
            Assert.IsFalse((bool)GetProperty("innerPanel.label0.Visible"));
            Assert.IsTrue((bool)GetProperty("innerPanel.label9.Visible"));
        }

        [Test]
        public void testForInvisibleAddButtoninComment()
        {
            clickOnCommentradioButton();
            Assert.IsFalse((bool)GetProperty("innerPanel.button2.Visible"));
        }

        [Test]
        public void testForInvisibleRemoveButtoninComment()
        {
            clickOnCommentradioButton();
            Assert.IsFalse((bool)GetProperty("innerPanel.button3.Visible"));
        }

        [Test]
        public void testForInvisibleQuestionLabelsinComment()
        {
            clickOnCommentradioButton();
            checkForInVisibleQuestionLabelsFromNumber(1);
        }

        [Test]
        public void testForInvisibleQuestionTextBoxesinComment()
        {
            clickOnCommentradioButton();
            checkForInVisibleQuestionTextBoxesFromNumber(1);
        }

        [Test]
        public void testForVisibleEmotionComboBoxInComment()
        {
            clickOnCommentradioButton();
            checkForVisibleEmotionComboBoxToNumber(1);
        }

        [Test]
        public void testForInvisibleEmotionComboBoxinComment()
        {
            clickOnCommentradioButton();
            checkForInVisibleEmotionComboBoxFromNumber(2);
        }

        #endregion

        #region Finish and Next Tests

        [Test]
        public void testForNextButton()
        {
            clickOnOpenQuestion();
            Object o = GetField("innerPanel.textBox0");
            ((TextBox)o).Text = "Hallo";
            RaiseEvent("innerPanel.button1", "Click", new EventArgs());

            Assert.IsEmpty((String)GetProperty("innerPanel.textBox0.Text"));
        }

        #endregion
    }
}
