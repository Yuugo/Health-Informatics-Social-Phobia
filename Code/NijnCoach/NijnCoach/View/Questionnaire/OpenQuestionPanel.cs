using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using NijnCoach.XMLclasses;

namespace NijnCoach.View.Questionnaire
{
    public partial class OpenQuestionPanel : IQuestionPanel
    {
        private OpenQuestion _entry;
        public OpenQuestionPanel(int w,int h) : base(w, h)
        {
            InitializeComponent();
        }

        public override IEntry entry
        {
            get { return _entry; }
            set
            {
                Debug.Assert(value is OpenQuestion);
                _entry = (OpenQuestion)value;
                this.SuspendLayout();
                labelQuestion.Text = _entry.question;
                textBoxAnswer.Text = _entry.theAnswer;
                this.ResumeLayout();
            }
        }

        private void answerEventHandler(object sender, EventArgs e)
        {
            _entry.theAnswer = (String)textBoxAnswer.Text;
        }
    }
}
