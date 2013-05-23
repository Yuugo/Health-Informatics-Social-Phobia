using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NijnCoach.XMLclasses;
using System.Diagnostics;
using NijnCoach.View.AvatarDir;
using NijnCoach.Avatar;


namespace NijnCoach.View.Questionnaire
{
    public partial class QuestionnaireForm : Panel
    {
        private XMLclasses.Questionnaire questionnaire;
        private int currentQuestion = 0;
        public QuestionnaireForm(Boolean _loadAvatar = true)
        {
            XMLParser parser = new XMLParser();
            InitializeComponent();
            openFileDialog.ShowDialog();
            XMLclasses.Questionnaire questionnaire = parser.readXMLFromFile(openFileDialog.FileName);
            init(questionnaire,_loadAvatar);
        }

        public QuestionnaireForm(XMLclasses.Questionnaire questionnaire, Boolean _loadAvatar = true)
        {
            InitializeComponent();
            init(questionnaire, _loadAvatar);
        }

        public void init(XMLclasses.Questionnaire questionnaire, Boolean _loadAvatar = true)
        {
            Debug.Assert(questionnaire.entries.Count > 0, "The number of entries in the questionnaire should at least be 1");
            this.questionnaire = questionnaire;
            initControls();
            if (_loadAvatar)
            {
                loadAvatar();
            }
        }

        private void initControls()
        {
            updatePanelQuestion(questionnaire.entries[currentQuestion]);
            progressBar.Minimum = 0;
            progressBar.Maximum = questionnaire.entries.Count;
            if (questionnaire.entries.Count < 2)
            {
                buttonNext.Enabled = false;
            }
        }

        public void loadAvatar()
        {
            Debug.Assert(panelAvatarIntern == null);
            panelAvatarIntern = new NijnCoach.View.AvatarDir.AvatarPanel(100, 100);
            panelAvatarIntern.Width = panelAvatar.Width;
            panelAvatarIntern.Height = panelAvatar.Height;
            panelAvatar.Controls.Add(panelAvatarIntern);
        }

        private void nextEventHandler(object sender,EventArgs e){
            Debug.Assert(currentQuestion + 1 < questionnaire.entries.Count, "Array out of bounds: IEntry does not exist");
            currentQuestion++;
            updatePanelQuestion(questionnaire.entries[currentQuestion]);
            if (currentQuestion == questionnaire.entries.Count - 1)
            {
                buttonNext.Enabled = false;
            }
            buttonPrevious.Enabled = true;
            progressBar.Value = currentQuestion;
        }

        private void previousEventHandler(object sender, EventArgs e)
        {
            Debug.Assert(currentQuestion - 1 >= 0, "Array out of bounds: IEntry does not exist");
            currentQuestion--;
            updatePanelQuestion(questionnaire.entries[currentQuestion]);
            if (currentQuestion == 0)
            {
                buttonPrevious.Enabled = false;
            }
            buttonNext.Enabled = true;
            progressBar.Value = currentQuestion;
        }

        private void homeEventHandler(object sender, EventArgs e)
        {
        }

        private void saveEventHandler(object sender, EventArgs e)
        {
            XMLParser reader = new XMLParser();
            reader.writeXMLToFile(questionnaire, "answers.xml"); //TODO: no static file name
        }

        public void updatePanelQuestion(IEntry entry)
        {
            Debug.Assert(entry != null);
            panelQuestion.SuspendLayout();
            panelQuestion.Controls.Clear();
            if (entry is Comment)
            {
                panelQuestionIntern = new CommentPanel(panelQuestion.Width,panelQuestion.Height);      
            }
            else if (entry is MCQuestion)
            {
                panelQuestionIntern = new MCQuestionPanel(panelQuestion.Width, panelQuestion.Height);
            }
            else if (entry is OpenQuestion)
            {
                panelQuestionIntern = new OpenQuestionPanel(panelQuestion.Width, panelQuestion.Height);
            }
            panelQuestionIntern.entry = entry;
            panelQuestion.Controls.Add(panelQuestionIntern);
            panelQuestion.ResumeLayout();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AvatarControl.happy();
        }

        private void panelAvatar_Paint(object sender, PaintEventArgs e)
        {
            
        }
    }
}
