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
    public partial class CommentPanel : IQuestionPanel
    {
        private Comment _entry;
        public CommentPanel(int w,int h) : base(w, h)
        {
            InitializeComponent();
        }
        public override IEntry entry
        {
            get { return _entry; }
            set
            {
                Debug.Assert(labelComment != null);
                Debug.Assert(value is Comment);
                _entry = (Comment)value;
                labelComment.Text = _entry.value;
            }
        }

        public override Boolean partlyDisabled {
            get { return false; }
            set { }
        }
    }
}
