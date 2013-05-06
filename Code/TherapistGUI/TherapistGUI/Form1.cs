using System;
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




namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        /// <summary> 
        /// houdt het aantal opties dat de multiplechoice vraag nu bevat bij
        /// </summary>
        int opts = 2;
        List<TextBox> texts = new List<TextBox>();
        List<Label> labels = new List<Label>();
        List<ComboBox> combos = new List<ComboBox>();
        List<Button> buttons = new List<Button>();
        Questionnaire q = new Questionnaire();
      
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Lijsten met de benodigde form items daarin opgeslagen
            texts = new List<TextBox>() { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox0 };
            labels = new List<Label>() { label0, label1, label2, label3, label4, label5, label6, label7, label8 };
            combos = new List<ComboBox>() { comboBox1, comboBox2, comboBox3, comboBox4, comboBox5, comboBox6, comboBox7, comboBox8 };
            buttons = new List<Button>() { button2, button3 };
            q.entries = new ListOfIEntry();
        }

        /// <summary>
        /// slaat een vraag op en reset de velden als er op next question wordt geklikt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            addQuestion();
        }

        /// <summary>
        /// haalt alle opties voor multiple choice weg en reset de counter voor opties als er op open vraag wordt geklikt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            labelQ.Text = "Question";
            for (int i = 0; i < 8; i++) { texts[i].Visible = false; }
            for (int i = 1; i < 9; i++) { labels[i].Visible = false; }
            for (int i = 1; i < 8; i++) { combos[i].Visible = false; }
            for (int i = 0; i < 2; i++) { buttons[i].Visible = false; }
            opts = 2;
        }


        /// <summary>
        /// Laat de opties voor multiple choice als de radio voor multiple choice wordt aangklikt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            labelQ.Text = "Question";
            for (int i = 0; i < 2; i++) { texts[i].Visible = true; }
            for (int i = 0; i < 3; i++) { labels[i].Visible = true; }
            for (int i = 0; i < 2; i++) { combos[i].Visible = true; }
            for (int i = 0; i < 2; i++) { buttons[i].Visible = true; }
        }

        /// <summary>
        /// haalt alle opties voor multiple choice weg en reset de counter voor opties als er op comment wordt geklikt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton3_CheckedChanged_1(object sender, EventArgs e)
        {
            labelQ.Text = "Comment";
            for (int i = 0; i < 8; i++) { texts[i].Visible = false; }
            for (int i = 1; i < 9; i++) { labels[i].Visible = false; }
            for (int i = 1; i < 8; i++) { combos[i].Visible = false; }
            for (int i = 0; i < 2; i++) { buttons[i].Visible = false; }
            opts = 2;
        }

        /// <summary>
        /// haalt een multiplechoice optie weg als er op de knop "Remove" wordt geklikt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// voegt een multiplechoice optie toe als er op de knop "Add" wordt geklikt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            //neemt vraag op als deze er nog staat
            addQuestion();
            saveFileDialog1.ShowDialog();

            q.version = 1.00;
            q.head = new Questionnaire.Header
            {
                createdBy = "Me",
                dateCreated = new DateTime(),
                filledBy = "Him",
                dateFilled = new DateTime()
            };
            
            XMLParser xpars = new XMLParser();
            xpars.writeXML(q, saveFileDialog1.FileName);

        }

        /// <summary>
        /// Voegt nieuwe vraag toe aan lijst als vrragentextbox niet leeg is.
        /// </summary>
        private void addQuestion()
        {
            //doe niets als vraag leeg is
            if (textBox0.Text != "")
            {

                if (radioButton1.Checked == true)
                {
                    q.entries.Add(new OpenQuestion { question = textBox0.Text, theAnswer = "" });
                }
                if (radioButton2.Checked == true)
                {
                    List<Option> opties = new List<Option>();
                    for (int i = 0; i < opts; i++)
                    {
                        opties.Add(new Option { tag = Convert.ToChar(65 + i).ToString(), answer = texts[i].Text, emotion = combos[i].Text });
                    }

                    q.entries.Add(new MCQuestion { question = textBox0.Text, options = opties, theAnswer = "" });
                }

                if (radioButton3.Checked == true)
                {
                    q.entries.Add(new Comment { value = textBox0.Text, emotion = comboBox1.Text });
                }
                reset();
            }
        }

        /// <summary>
        /// reset de velden bij een nieuwe vraag
        /// </summary>
        private void reset()
        {
            for (int i = 0; i < 9; i++) { texts[i].Text = ""; }
            for (int i = 0; i < 8; i++) { combos[i].Text = ""; }
        }
    }
}
