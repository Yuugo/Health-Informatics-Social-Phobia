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
    public static class DBConnect
    {
        public static Boolean insertPatient(Patient patient)
        {
            NijnCoachEntities theEntities = new NijnCoachEntities();
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

        public static Boolean InsertQuestionnairre(String name, Questionnaire questionnaire)
        {
            NijnCoachEntities theEntities = new NijnCoachEntities();
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

        /// <summary>
        /// load audio bestand op de server
        /// </summary>
        /// <param name="audioFile"></param>
        /// <returns></returns>
        public static Boolean InsertSpeechFile(string audioFile)
        {
            NijnCoachEntities theEntities = new NijnCoachEntities();
            //zet audio bestand om in string
            byte[] audio = File.ReadAllBytes(@audioFile);
            string audioAsString = System.Convert.ToBase64String(audio);
            string[] name = null;
            //split de bestandnaam in stukken zodat alleen de naam van het bestand overblijft             
            name = audioFile.Split('\\');
            string naam = name.Last();
            SpeechFile newSpeech = new SpeechFile();
            newSpeech.Id = 1;
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
                //kijkt of de exception duplicate is en dus nog wel geaccepteerd kan worden
                string exc = e.InnerException.ToString();
                string[] except = null;
                //split de exception in stukken             
                except = exc.Split(' ');
                if (except[2].Equals("Duplicate"))
                {
                    return true;
                }
                return false;
            }
        }

        #region PatientSelectors

        public static Patient getPatientByLastName(String name)
        {
            NijnCoachEntities theEntities = new NijnCoachEntities();            
            Patient result = theEntities.Patients.Where(x => x.Lname == name).First<Patient>();
            return result;
        }

        public static Patient getPatientByFirstName(String name)
        {
            NijnCoachEntities theEntities = new NijnCoachEntities();
            Patient result = theEntities.Patients.Where(x => x.Fname == name).First<Patient>();
            return result;
        }

        public static Patient getPatientByNumber(int number)
        {
            NijnCoachEntities theEntities = new NijnCoachEntities();
            Patient result = theEntities.Patients.Where(x => x.PatientNo == number).First<Patient>();
            return result;
        }
        #endregion
        /// <summary>
        /// Finds the questionnaire with the given name. Throws FileNotFoundException if it does not exist.
        /// </summary>
        /// <param name="name">Name of the questionnaire</param>
        /// <returns>The Questionnaire</returns>
        public static Questionnaire getQuestionnaireByName(String name)
        {
            try
            {
                NijnCoachEntities theEntities = new NijnCoachEntities();
                String result = theEntities.Questionnairres.Where(x => x.Name == name).First<Questionnairre>().Text;
                XMLParser parser = new XMLParser();
                StreamReader reader = new StreamReader(result);
                return parser.readXML(reader);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.InnerException.ToString());
                throw new FileNotFoundException();
            }
        }

        public static SpeechFile getSpeechFile(string name)
        {

            try
            {
                NijnCoachEntities theEntities = new NijnCoachEntities();
                SpeechFile result = theEntities.SpeechFiles.Where(x => x.Name == name).First<SpeechFile>();
                return result;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.InnerException.ToString());
                throw new FileNotFoundException();
            }
        }

        public static void updateQuery()
        {
            NijnCoachEntities theEntities = new NijnCoachEntities();
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