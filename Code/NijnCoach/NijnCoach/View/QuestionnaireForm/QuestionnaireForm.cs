using System;
using NijnCoach.XMLclasses;
using System.Diagnostics;
using NijnCoach.View.AvatarDir;
using NijnCoach.Avatar;
using NijnCoach.View.Main;
using NijnCoach.View.Home;
using Un4seen.Bass;
using Un4seen.Bass.AddOn.Fx;
using NijnCoach.View.Overview;
using NijnCoach.Database;
using System.IO;
using System.Text;
using NijnCoach.View.Greet;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Forms;

namespace NijnCoach.View.Questionnaire
{
    public partial class QuestionnaireForm : AvatarContainer
    {
        private Timer timer;
        private XMLclasses.Questionnaire questionnaire;
        private int currentQuestion = 0;
        private int stream = 0;
        private XMLParser xpars = new XMLParser();
        private Boolean _loadAvatar = true;
        public QuestionnaireForm(Boolean _loadAvatar = true)
            : base(_loadAvatar)
        {
            this._loadAvatar = _loadAvatar;
            XMLParser parser = new XMLParser();
            #region license
            BassNet.Registration("w.kowaluk@gmail.com", "2X32382019152222");
            #endregion
            Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);
            try
            {
                XMLclasses.Questionnaire questionnaire = DBConnect.getQuestionnaireByPatient(MainClass.userNo);
                
                init(questionnaire);
            }
            catch (FileNotFoundException)
            {
                throw new NoQuestionnaireAvailableException();
                //MainForm.mainForm.replacePanel(new HomePanel(_loadAvatar));
            }
        }
        Dictionary<String, String> audioData = new Dictionary<string, string>();


        public QuestionnaireForm(XMLclasses.Questionnaire questionnaire, Boolean _loadAvatar = true)
            : base(_loadAvatar)
        {
            init(questionnaire);
            
        }

        private void init(XMLclasses.Questionnaire questionnaire)
        {
            if (questionnaire.entries.Count < 1)
            {
                System.Windows.MessageBox.Show("No questionnaires available for you.\nYou will be taken to the homepanel");
                throw new NoQuestionnaireAvailableException();
            }
            this.questionnaire = questionnaire;            
            initControls();
        }

        private void initControls()
        {
            currentQuestion = DBConnect.getQuestion(MainClass.userNo);
            if (currentQuestion > 0) buttonPrevious.Enabled = true;
            updatePanelQuestion(questionnaire.entries[currentQuestion]);
            progressBar.Minimum = 0;
            progressBar.Maximum = questionnaire.entries.Count;
            progressBar.Value = currentQuestion;
            if (questionnaire.entries.Count < 2)
            {
                buttonNext.Text = "Finish";
            }
        }

        private void nextEventHandler(object sender, EventArgs e)
        {
            if (currentQuestion + 1 == questionnaire.entries.Count)
            {
                saveEventHandler(sender, e);
                //TODO: Mark questionnaire as finished
                //TODO: fetch data for overview from database
                DBConnect.updateQuestionnaire(MainClass.userNo,xpars.writeXML(questionnaire), -1);

                try
                {
                    MainForm.mainForm.replacePanel(new OverviewPanel(_loadAvatar));
                }
                catch (Exception){
                    MainForm.mainForm.replacePanel(new HomePanel(_loadAvatar));
                }
            }
            else
            {                
                currentQuestion++;
                DBConnect.updateQuestionnaire(MainClass.userNo, xpars.writeXML(questionnaire), currentQuestion);
                updatePanelQuestion(questionnaire.entries[currentQuestion]);
                if (currentQuestion == questionnaire.entries.Count - 1)
                {
                    buttonNext.Text = "Finish";
                }
                if (questionnaire.entries[currentQuestion].Audio() == "")
                {
                    buttonPrevious.Enabled = true;
                }
                progressBar.Value = currentQuestion;
            }
        }

        private void previousEventHandler(object sender, EventArgs e)
        {
            Debug.Assert(currentQuestion - 1 >= 0, "Array out of bounds: IEntry does not exist");
            currentQuestion--;
            DBConnect.updateQuestionnaire(MainClass.userNo, xpars.writeXML(questionnaire), currentQuestion);
            updatePanelQuestion(questionnaire.entries[currentQuestion]);
            if (currentQuestion == 0)
            {
                buttonPrevious.Enabled = false;
            }
            buttonNext.Text = "Next";
            progressBar.Value = currentQuestion;
        }

        private void homeEventHandler(object sender, EventArgs e)
        {
            MainForm.mainForm.replacePanel(new HomePanel(_loadAvatar));
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
                panelQuestionIntern = new CommentPanel(panelQuestion.Width, panelQuestion.Height);
            }
            else if (entry is MCQuestion)
            {
                panelQuestionIntern = new MCQuestionPanel(panelQuestion.Width, panelQuestion.Height);
            }
            else if (entry is OpenQuestion)
            {
                panelQuestionIntern = new OpenQuestionPanel(panelQuestion.Width, panelQuestion.Height);
            }

            if (_loadAvatar) AvatarControl.setAvatarEmotionViaEntry(entry);
            panelQuestionIntern.entry = entry;
            panelQuestion.Controls.Add(panelQuestionIntern);
            playFromHD();
            panelQuestion.ResumeLayout();
        }

        //Fuck you MySQL
        void playFromHD()
        {
            var entry = questionnaire.entries[currentQuestion];
            if (entry.Audio() != "")
            {
                int length = bassGetLength();
                DisableButtonsOnTimer(length);
                AvatarControl.speak(entry.Audio(), length);
            }
            
        }

        void DisableButtonsOnTimer(int length)
        {
            if (length != -1)
            {
                buttonNext.Enabled = false;
                buttonPrevious.Enabled = false;
                buttonHome.Enabled = false;
                timer = new Timer();
                timer.Interval = length*1100;
                timer.Tick += new EventHandler(enableButtons);
                timer.Enabled = true;
            }
        }

        void enableButtons(object sender, EventArgs e)
        {
            buttonNext.Enabled = true;
            if (currentQuestion == 0)
                buttonPrevious.Enabled = false;
            else
                buttonPrevious.Enabled = true;
            buttonHome.Enabled = true;
            timer.Enabled = false;
        }

        /// <summary>
        /// Wrapper method used to obtain and play audio for the current question
        /// </summary>
        void playFromDB()
        {
            var entry = questionnaire.entries[currentQuestion];
            if(audioData[entry.Audio()] == "")
                audioData[entry.Audio()] = DBConnect.getSpeechFile(entry.Audio());
            if (entry.Audio() != "")
            {
                String content = DBConnect.getSpeechFile(entry.Audio());
                createTempAudioFile(content);
                AvatarControl.speak("C://ecoach//audio//" + questionnaire.entries[currentQuestion].Audio() + ".wav", bassGetLength());
                //bassPlay(tempPath);
            }
        }

        public int bassGetLength()
        {
            stream = Bass.BASS_StreamCreateFile("C://ecoach//audio//" + questionnaire.entries[currentQuestion].Audio(), 0, 0, BASSFlag.BASS_DEFAULT);
            BASSError error = Bass.BASS_ErrorGetCode();
            long len = Bass.BASS_ChannelGetLength(stream, BASSMode.BASS_POS_BYTES);
            int time = (int)Bass.BASS_ChannelBytes2Seconds(stream, len);
            return time;
        }

        public void bassPlay(string mp3path)
        {
            if (stream != 0)
            {
                Bass.BASS_StreamFree(stream);
            }
            stream = Bass.BASS_StreamCreateFile(mp3path, 0, 0, BASSFlag.BASS_DEFAULT);
            BASSError error = Bass.BASS_ErrorGetCode();
            long len = Bass.BASS_ChannelGetLength(stream, BASSMode.BASS_POS_BYTES);
            // the length of the audiofile
            int time = (int)Bass.BASS_ChannelBytes2Seconds(stream, len) * 1000;
            if (_loadAvatar)
            {
                AvatarControl.speak("1.wav", 30);
            }
            if (stream != 0)
            {
                //Bass.BASS_ChannelPlay(stream, false);
            }
        }

        /// <summary>
        /// Create a temporary file for Bass to play from and reduce loading time.
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public void createTempAudioFile(String content)
        {
            //String path = GetTempFilePathWithExtension("wav");
            using (FileStream fs = new FileStream("C://ecoach//audio//" + questionnaire.entries[currentQuestion].Audio() + ".wav", FileMode.OpenOrCreate))
            {
                byte[] decoded = System.Convert.FromBase64String(content);
                // Add some information to the file.
                fs.Write(decoded, 0, decoded.Length);
                fs.Close();
            }
            //return path;
        }


        /// <summary>
        /// Creates a random filepath with a given extension. Format: '.ext' or 'ext' are both allowed.
        /// </summary>
        /// <param name="extension"></param>
        /// <returns></returns>
        public string GetTempFilePathWithExtension(string extension)
        {
            var fileName = System.IO.Path.GetRandomFileName();
            var path = "C://ecoach//audio//tempAudio.wav";
            return Path.ChangeExtension(path, extension);
        }

        protected override void avatarLoaded() { }

        
    }


}
