using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NijnCoach.XMLclasses;
using System.Xml;
using System.IO;

namespace NijnCoach.Database
{
   

    class DBConnect
    {

        static void Main(String[] args)
        {
            byte[] audio = File.ReadAllBytes(@"C:\ecoach\audio\2.wav");
            string hoi = System.Convert.ToBase64String(audio);
        }
        public Boolean insertPatient(Patient patient)
        {
            NijnCoachEntities2 theEntities = new NijnCoachEntities2();
            try
            {
                theEntities.Patients.AddObject(patient);
                theEntities.SaveChanges();
                return true;
                 
            } catch (Exception e)
            {
                MessageBox.Show(e.InnerException.ToString());
                return false;
            }
        }

        public Boolean InsertQuestionnairre(String name, Questionnaire questionnaire)
        {
            NijnCoachEntities2 theEntities = new NijnCoachEntities2();
            Questionnairre questionForm = new Questionnairre();
            XMLParser parser = new XMLParser();
            string text = parser.writeXML(questionnaire);

            questionForm.Name = name;
            questionForm.Text = text;
            

            try
            {
                theEntities.Questionnairres.AddObject(questionForm);
                theEntities.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.InnerException.ToString());
                return false;
            }
        }

        public Boolean InsertSpeechFile(string audioFile)
        {
            NijnCoachEntities2 theEntities = new NijnCoachEntities2();
            byte[] audio = File.ReadAllBytes(@audioFile);
            string audioAsString = System.Convert.ToBase64String(audio);
            string[] name = null;
            //split de bestandnaam in stukken zodat alleen de naam van het bestand overblijft
            name = audioFile.Split('\\');
            string naam = name.Last();
            SpeechFile newSpeech = new SpeechFile();
            newSpeech.Id = 0;
            newSpeech.Name = naam;
            newSpeech.Encoding = audioAsString; 

            try
            {
                theEntities.SpeechFiles.AddObject(newSpeech);
                theEntities.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public void updateQuery()
        {
            NijnCoachEntities2 theEntities = new NijnCoachEntities2();
            try
            {
                Patient patient = theEntities.Patients.First<Patient>();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.InnerException.ToString());
            }
        }
    }
}