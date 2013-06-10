
﻿using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Windows.Forms;
using NijnCoach.XMLclasses;
using NijnCoach;
using NijnCoach.Database;




namespace NijnCoach.View.TherapistGUI
{
    public partial class TherapistGUI : Form
    {
       //houdt het aantal opties dat de multiplechoice vraag nu bevat bij
        int opts = 2;
        bool empty = true;
        //houdt een lijst met alle vragen erin
        List<TextBox> texts = new List<TextBox>();
        List<Label> labels = new List<Label>();
        List<ComboBox> combos = new List<ComboBox>();
        List<Button> buttons = new List<Button>();
        NijnCoach.XMLclasses.Questionnaire q = new NijnCoach.XMLclasses.Questionnaire();
        

        public TherapistGUI()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Lijsten met de benodigde form items daarin opgeslagen
            texts = new List<TextBox>() { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox0,textBox9 };
            labels = new List<Label>() { label0, label1, label2, label3, label4, label5, label6, label7, label8 };
            combos = new List<ComboBox>() { comboBox1, comboBox2, comboBox3, comboBox4, comboBox5, comboBox6, comboBox7, comboBox8 };
            buttons = new List<Button>() { button2, button3 };
            q.entries = new ListOfIEntry();
        }

        //slaat een vraag op en reset de velden als er op next question wordt geklikt
        private void button1_Click(object sender, EventArgs e)
        {
            addQuestion();

        }

        //haalt alle opties voor multiple choice weg en reset de counter voor opties als er op open vraag wordt geklikt
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            labelQ.Text = "Question";
            for (int i = 0; i < 8; i++) { texts[i].Visible = false; }
            for (int i = 0; i < 9; i++) { labels[i].Visible = false; }
            for (int i = 1; i < 8; i++) { combos[i].Visible = false; }
            for (int i = 0; i < 2; i++) { buttons[i].Visible = false; }
            opts = 2;
        }


        //Laat de opties voor multiple choice als de radio voor multiple choice wordt aangklikt
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            labelQ.Text = "Question";
            for (int i = 0; i < 2; i++) { texts[i].Visible = true; }
            for (int i = 0; i < 3; i++) { labels[i].Visible = true; }
            for (int i = 0; i < 2; i++) { combos[i].Visible = true; }
            for (int i = 0; i < 2; i++) { buttons[i].Visible = true; }
        }

        //haalt alle opties voor multiple choice weg en reset de counter voor opties als er op comment wordt geklikt
        private void radioButton3_CheckedChanged_1(object sender, EventArgs e)
        {
            labelQ.Text = "Comment";
            for (int i = 0; i < 8; i++) { texts[i].Visible = false; }
            for (int i = 0; i < 9; i++) { labels[i].Visible = false; }
            for (int i = 1; i < 8; i++) { combos[i].Visible = false; }
            for (int i = 0; i < 2; i++) { buttons[i].Visible = false; }
            opts = 2;
        }

        //haalt een multiplechoice optie weg als er op de knop "Remove" wordt geklikt
        private void button3_Click(object sender, EventArgs e)
        {

            if (opts > 2)
            {
                opts--;
                texts[opts].Visible = false;
                combos[opts].Visible = false;
                labels[opts + 1].Visible = false;
            }


        }

        //voegt een multiplechoice optie toe als er op de knop "Add" wordt geklikt
        private void button2_Click(object sender, EventArgs e)
        {
            if (opts < 8)
            {
                texts[opts].Visible = true;
                combos[opts].Visible = true;
                labels[opts + 1].Visible = true;
                opts++;
            }


        }

        private void button5_Click(object sender, EventArgs e)
        {
            saveFileDialog dialog = new saveFileDialog();
            addQuestion();
            if (dialog.ShowDialog() == DialogResult.OK && empty == false)
            {
                q.version = 1.00;
                q.head = new NijnCoach.XMLclasses.Questionnaire.Header
                {
                    createdBy = "Me",
                    dateCreated = new DateTime(),
                    filledBy = "Him",
                    dateFilled = new DateTime()
                };

                XMLParser xpars = new XMLParser();
                String theXML = xpars.writeXML(q);
                DBConnect.InsertQuestionnairre(dialog.saveFileTextBox.Text, Int32.Parse(dialog.patientNoBox.Text), q);
                MessageBox.Show("Questionnaire has been saved");
                q = new NijnCoach.XMLclasses.Questionnaire();
                q.entries = new ListOfIEntry();                
            }
        }

        //voegt nieuwe vraag toe aan lijst als vrragentextbox niet leeg is
        private void addQuestion()
        {
            //doe niets als vraag leeg is
            if (textBox0.Text != "")
            {
                //checkt of er geen probleem is met het audiofile
                if (addAudio())
                {
                    if (radioButton1.Checked == true)
                    {
                        q.entries.Add(new OpenQuestion { question = textBox0.Text, audio = textBox9.Text, theAnswer = "" });
                    }
                    if (radioButton2.Checked == true)
                    {
                        List<Option> opties = new List<Option>();
                        for (int i = 0; i < opts; i++)
                        {
                            opties.Add(new Option { tag = Convert.ToChar(65 + i).ToString(), answer = texts[i].Text, emotion = combos[i].Text });
                        }

                        q.entries.Add(new MCQuestion { question = textBox0.Text, audio = textBox9.Text, options = opties, theAnswer = "" });
                    }

                    if (radioButton3.Checked == true)
                    {
                        q.entries.Add(new Comment { value = textBox0.Text, audio = textBox9.Text, emotion = comboBox1.Text });
                    }
                    empty = false;
                    reset();
                }
            }
        }

        //reset de velden bij een nieuwe vraag
        private void reset()
        {
            for (int i = 0; i < 10; i++) { texts[i].Text = ""; }
            for (int i = 0; i < 8; i++) { combos[i].Text = ""; }
        }

        //laadt audiobestand in
        private void button4_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string audioPath = openFileDialog1.FileName.ToString();
            string[] name = null;
            //split de bestandnaam in stukken zodat alleen de naam van het bestand overblijft
            name = audioPath.Split('\\');
            textBox9.Text = name.Last();
            //upload openFileDialog1.Text to server


            /*
            byte[] audio = File.ReadAllBytes(@audioFile);
            string audioAsString = System.Convert.ToBase64String(audio);
            byte[] binaryData = Convert.FromBase64String(audioAsString);
            File.WriteAllBytes("C:/ecoach/audio/4.wav", binaryData);
            */

            //bassPlay(audioFile);


        }

        //uploadt audiobestand als er geen probleem mee is
        public bool addAudio()
        {
            if (textBox9.Text != "")
            {
                string audioPath = openFileDialog1.FileName.ToString();
                //uploadt het bestand of geeft een aan dat er een probleem is met het file als het bestand niet upgeloadt kon worden
                //bassPlay(audioFile);
                byte[] audio = File.ReadAllBytes(@audioPath);
                string audioAsString = System.Convert.ToBase64String(audio);
                List<string> audioSplit = Split(audioAsString, 1000000);
                string[] name = null;

                //split de bestandnaam in stukken zodat alleen de naam van het bestand overblijft             
                name = audioPath.Split('\\');
                string naam = name.Last();
                for (int i = 0; i < audioSplit.Count; i++)
                {

                    if (!DBConnect.InsertSpeechFile(audioSplit[i], naam, i))
                    {
                        MessageBox.Show("Problem with file");
                        return false;
                    };
                }
            }
            return true;
        }

        //split audio in parts van ongeveer 1mb
        static List<string> Split(string str, int size)
        {
            List<string> spl = new List<string>();

            for (int i = 0; i < str.Length; i += size)
            {
                if ((i + size) < str.Length)
                    spl.Add(str.Substring(i, size));
                else
                    spl.Add(str.Substring(i));
            }
            return spl;
        }

        //maakt de textbox voor audio bestanden leeg
        private void button6_Click(object sender, EventArgs e)
        {
            textBox9.Text = "";
        }

    }
}
