using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;



namespace WindowsFormsApplication1
{

    


    public partial class Form1 : Form
    {
        /// <summary>
        /// houdt het aantal vragen bij
        /// </summary>
        int questions = 0;
        /// <summary> 
        /// houdt het aantal opties dat de multiplechoice vraag nu bevat bij
        /// </summary>
        int opts = 2;
        /// <summary>
        /// houdt een lijst met alle vragen erin
        /// </summary>
        List<Question> list = new List<Question>();
      
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// slaat een vraag op en reset de velden als er op next question wordt geklikt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox0.Text != "")
            {
                //gaat uit vaan een open vraag als de vraag wordt verwerkt
                String type = "open";
                List<String> answer = new List<String>();
                List<String> emotion = new List<String>();
                int opt = 0;
                //alleen als de vraag multiple choice worden de opties uitgelezen
                if (radioButton2.Checked == true)
                {
                    type = "mult";
                    opt = opts;
                    answer.Add(textBox1.Text);
                    emotion.Add(comboBox1.Text);
                    answer.Add(textBox2.Text);
                    emotion.Add(comboBox2.Text);
                    //kijkt hoeveel opties er zijn en voegt deze toe aan de lijsten als deze bestaat
                    #region extraAnswers
                    if (opt > 2)
                    {
                        answer.Add(textBox3.Text);
                        emotion.Add(comboBox3.Text);
                    }
                    if (opt > 3)
                    {
                        answer.Add(textBox4.Text);
                        emotion.Add(comboBox4.Text);
                    }
                    if (opt > 4)
                    {
                        answer.Add(textBox5.Text);
                        emotion.Add(comboBox5.Text);
                    }
                    if (opt > 5)
                    {
                        answer.Add(textBox6.Text);
                        emotion.Add(comboBox6.Text);
                    }
                    if (opt > 6)
                    {
                        answer.Add(textBox7.Text);
                        emotion.Add(comboBox7.Text);
                    }
                    if (opt > 7)
                    {
                        answer.Add(textBox8.Text);
                        emotion.Add(comboBox8.Text);
                    }
                    #endregion
                }
                Question question = new Question(type, textBox0.Text, opt, answer, emotion);
                list.Add(question);
                questions++;
                reset();
            }
        }

        /// <summary>
        /// haalt alle opties voor multiple choice weg en reset de counter voor opties als er op open vraag wordt geklikt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            #region buttons
            button2.Visible = false;
            button3.Visible = false;
            #endregion
            #region labels
            label0.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            #endregion
            #region textboxes
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
            textBox8.Visible = false;
            #endregion
            #region comboboxes
            comboBox1.Visible = false;
            comboBox2.Visible = false;
            comboBox3.Visible = false;
            comboBox4.Visible = false;
            comboBox5.Visible = false;
            comboBox6.Visible = false;
            comboBox7.Visible = false;
            comboBox8.Visible = false;
            #endregion
            opts = 2;
        }

        /// <summary>
        /// Laat de opties voor multiple choice als de radio voor multiple choice wordt aangklikt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            #region buttons
            button2.Visible = true;
            button3.Visible = true;
            #endregion
            #region labels
            label0.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            #endregion
            #region textboxes
            textBox1.Visible = true;
            textBox2.Visible = true;
            #endregion
            #region comboboxes
            comboBox1.Visible = true;
            comboBox2.Visible = true;
            #endregion
        }

        /// <summary>
        /// haalt een multiplechoice optie weg als er op de knop "Remove" wordt geklikt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            switch (opts)
            {
                case 3:
                    three(false);
                    break;
                case 4:
                    four(false);
                    break;
                case 5:
                    five(false);
                    break;
                case 6:
                    six(false);
                    break;
                case 7:
                    seven(false);
                    break;
                case 8:
                    eight(false);
                    break;
                default:
                    opts++;
                    break;
            }
            opts--;
        }

        /// <summary>
        /// voegt een multiplechoice optie toe als er op de knop "Add" wordt geklikt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            opts++;
            switch (opts)
            {
                case 3:
                    three(true);
                    break;
                case 4:
                    four(true);
                    break;
                case 5:
                    five(true);
                    break;
                case 6:
                    six(true);
                    break;
                case 7:
                    seven(true);
                    break;
                case 8:
                    eight(true);
                    break;
                default:
                    opts--;
                    break;
            }
            
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //opent directory om xml bestand op te slaan
            saveFileDialog1.ShowDialog();
            //start met maken xml string een lange string
            String xml = "<entries>\n";
            //gaat alle vragen langs
            for (int i = 0; i < list.Count; i++)
            {
                    //vraagt de question op en stopt het type en de vraag in string
                    Question q = list[i];
                    xml += "\t<entry type=\"" + q.getType() + "\">\n";
                    xml += "\t\t<question>\n\t\t\t" + q.getQuestion() + "\n";
                    //gaat alle opties met emoties af als het een multiplechoice vraag is
                    if (q.getType() == "mult")
                    {
                        xml += "\t\t\t<options>\n";
                        for (int j = 0; j < q.getOptions(); j++)
                        {
                            xml += "\t\t\t\t<option>\n";
                            //geeft de tag in ascii van de optie beginnen met A = 65;
                            xml += "\t\t\t\t\t<tag>" + Convert.ToChar(65+j) + "</tag>\n";
                            xml += "\t\t\t\t\t<emotion>" + q.getEmotions()[j] + "</emotion>\n\t\t\t\t\t";
                            xml += q.getAnswers()[j] + "\n\t\t\t\t</option>\n";
                        }
                        xml += "\t\t\t</options>\n";
                    }
                    xml += "\t\t</question>\n\t\t<answer>\n\t\t</answer>\n\t</entry>\n";
            }
            xml += "</entries";
            //schrijft de string naar het bestand
            if (saveFileDialog1.FileName != "")
            {
                StreamWriter streamWriter = new StreamWriter(saveFileDialog1.FileName);
                streamWriter.Write(xml);
                streamWriter.Close();
            }
        }

        #region changingVisibilityMultipleChoiceOptions
        private void three(Boolean b)
        {
            label3.Visible = b;
            textBox3.Visible = b;
            comboBox3.Visible = b;
        }

        private void four(Boolean b)
        {
            label4.Visible = b;
            textBox4.Visible = b;
            comboBox4.Visible = b;
        }

        private void five(Boolean b)
        {
            label5.Visible = b;
            textBox5.Visible = b;
            comboBox5.Visible = b;
        }

        private void six(Boolean b)
        {
            label6.Visible = b;
            textBox6.Visible = b;
            comboBox6.Visible = b;
        }

        private void seven(Boolean b)
        {
            label7.Visible = b;
            textBox7.Visible = b;
            comboBox7.Visible = b;
        }

        private void eight(Boolean b)
        {
            label8.Visible = b;
            textBox8.Visible = b;
            comboBox8.Visible = b;
        }
        #endregion
        
        /// <summary>
        /// reset de velden bij een nieuwe vraag
        /// </summary>
        private void reset()
        {
            #region textboxes
            textBox0.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            #endregion
            #region comboboxes
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            comboBox5.Text = "";
            comboBox6.Text = "";
            comboBox7.Text = "";
            comboBox8.Text = "";
            #endregion

        }

    }

    /// <summary>
    /// klasse Question om de ingevulde vragen mee op te slaan
    /// </summary>
    class Question
    {
        String type;
        String question;
        int options;
        List<String> answers;
        List<String> emotions;

        public Question()
        {
            type = "";
            question = "";
            options = 0;
            answers = new List<String>();
            emotions = new List<String>();

        }

        public Question(String typ, String quest, int opt, List<String> ans, List<String> emo)
        {
            type = typ;
            question = quest;
            options = opt;
            answers = ans;
            emotions = emo;
        }

        public String getType()
        {
            return type;
        }

        public String getQuestion()
        {
            return question;
        }

        public int getOptions()
        {
            return options;
        }

        public List<String> getAnswers()
        {
            return answers;
        }

        public List<String> getEmotions()
        {
            return emotions;
        }

    }
}
