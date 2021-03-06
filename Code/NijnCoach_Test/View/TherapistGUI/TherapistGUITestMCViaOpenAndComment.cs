﻿using System;
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

namespace NijnCoach_Test.View.TherapistGUI
{
    [TestFixture]
    class TherapistGUITestMCViaOpenAndComment : TherapistGUITest
    {

        public override void clickOnMCradioButton()
        {
            clickOnCommentradioButton();
            clickOnOpenQuestion();
            clickOnCommentradioButton();
            clickOnOpenQuestion();
            base.clickOnMCradioButton();
        }
    }
}
