using System;
using NijnCoach.XMLclasses;
using System.Diagnostics;
using NijnCoach.View.AvatarDir;
using NijnCoach.Avatar;
using NijnCoach.View.Main;
using NijnCoach.View.Home;
using NijnCoach.View.Overview;


namespace NijnCoach.View.Questionnaire
{
    public partial class QuestionnaireForm : AvatarContainer
    {
        private XMLclasses.Questionnaire questionnaire;
        private int currentQuestion = 0;
        public QuestionnaireForm(Boolean _loadAvatar = true) : base(_loadAvatar)
        {
            XMLParser parser = new XMLParser();
            openFileDialog.ShowDialog();
            XMLclasses.Questionnaire questionnaire = parser.readXMLFromFile(openFileDialog.FileName);
            init(questionnaire);
        }

        public QuestionnaireForm(XMLclasses.Questionnaire questionnaire, Boolean _loadAvatar = true) : base(_loadAvatar)
        {
            init(questionnaire);
        }

        private void init(XMLclasses.Questionnaire questionnaire)
        {
            Debug.Assert(questionnaire.entries.Count > 0, "The number of entries in the questionnaire should at least be 1");
            this.questionnaire = questionnaire;
            initControls();
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

        private void nextEventHandler(object sender,EventArgs e){
            if (currentQuestion + 1 == questionnaire.entries.Count)
            {
                saveEventHandler(sender, e);
                //TODO: Mark questionnaire as finished
                //TODO: fetch data for overview from database
                MainForm.mainForm.replacePanel(new OverviewPanel());
            }
            else
            {
                currentQuestion++;
                updatePanelQuestion(questionnaire.entries[currentQuestion]);
                if (currentQuestion == questionnaire.entries.Count - 1)
                {
                    buttonNext.Text = "Finish";
                }
                buttonPrevious.Enabled = true;
                progressBar.Value = currentQuestion;
            }
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
            buttonNext.Text = "Next";
            buttonNext.Enabled = true;
            progressBar.Value = currentQuestion;
        }

        private void homeEventHandler(object sender, EventArgs e)
        {
            MainForm.mainForm.replacePanel(new HomePanel());
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


        protected override void avatarLoaded() { }
    }
}
