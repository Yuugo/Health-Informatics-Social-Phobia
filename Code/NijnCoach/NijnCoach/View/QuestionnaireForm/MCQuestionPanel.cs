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
using NijnCoach.Avatar;

namespace NijnCoach.View.Questionnaire
{
    public partial class MCQuestionPanel : IQuestionPanel
    {
        private MCQuestion _entry;
        private Boolean _partlyDisabled = false;
        private List<System.Windows.Forms.RadioButton> options = new List<System.Windows.Forms.RadioButton>();

        public MCQuestionPanel(int w, int h) : base(w, h)
        {
            InitializeComponent();
        }
        public override IEntry entry
        {
            get { return _entry; }
            set
            {
                Debug.Assert(value is MCQuestion);
                _entry = (MCQuestion)value;
                this.SuspendLayout();
                labelQuestion.Text = _entry.question;
                foreach(Option option in _entry.options){
                    RadioButton radio = new RadioButton();
                    radio.Text = option.answer;
                    radio.Tag = option.tag;
                    radio.Name = "Radio" + option.tag;
                    radio.CheckedChanged += new EventHandler(optionEventHandler);
                    radio.Enabled = !_partlyDisabled;
                    if(option.tag == _entry.theAnswer)
                        radio.Checked = true;
                    options.Add(radio);
                    this.Controls.Add(radio);
                }
                this.ResumeLayout();
            }
        }

        private void optionEventHandler(object sender,EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb != null && rb.Checked)
            {
                _entry.theAnswer = (String)rb.Tag;
                foreach (Option o in _entry.options)
                {
                    if (o.tag.Equals(rb.Tag)) AvatarControl.setAvatarEmotionViaString(o.emotion, 10);
                }
            }
        }

        public override Boolean partlyDisabled
        {
            get { return _partlyDisabled; }
            set
            {
                _partlyDisabled = value;
                foreach (RadioButton r in options)
                {
                    r.Enabled = !value;
                }
            }
        }
    }
}
