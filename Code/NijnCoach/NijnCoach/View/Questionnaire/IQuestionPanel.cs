using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NijnCoach.View.Questionnaire
{
    public abstract class IQuestionPanel : System.Windows.Forms.FlowLayoutPanel
    {
        public IQuestionPanel(int w,int h)
        {
            this.Width = w;
            this.Height = h;
        }

        abstract public IEntry entry { get; set; }
        abstract public Boolean partlyDisabled {get; set;}

    }
}
