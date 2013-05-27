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
        /// <summary>
        /// Insert a Patient object into the Database. The object should have all his attributes defined already.
        /// </summary>
        /// <param name="patient">A comepleted Patient object.</param>
        /// <returns>Returns true if object was added, else false.</returns>
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
                //TODO: blabla
                MessageBox.Show(e.InnerException.ToString());
                return false;
            }
        }

        /// <summary>
        /// Insert a Questionnaire into the database under the given name.
        /// </summary>
        /// <param name="name">Name of the Questionnaire</param>
        /// <param name="questionnaire">The already created Questionnaire</param>
        /// <returns>Returns true if object was added, else false.</returns>
        public static Boolean InsertQuestionnairre(String name, int patientNo, Questionnaire questionnaire)
        {
            NijnCoachEntities theEntities = new NijnCoachEntities();
            Questionnairre questionForm = new Questionnairre();
            XMLParser parser = new XMLParser();
            string text = parser.writeXML(questionnaire);

            questionForm.Name = name;
            questionForm.Text = text;
            questionForm.Type = "Questionnaire";
            questionForm.FilledIn = false;
            questionForm.forPatient = (SByte)patientNo;
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
        /// Inserts the progress evalution into the database.
        /// </summary>
        /// <param name="name">The desired name for the evaluation.</param>
        /// <param name="filePath">The file that will be read and inserted into the database.</param>
        /// <returns>Returns true if object was added, else false.</returns>
        public static Boolean InsertProgressEvaluation(String name, Int32 patientNo, String filePath)
        {
            NijnCoachEntities theEntities = new NijnCoachEntities();
            StreamReader reader = new StreamReader(filePath);
            String contents = reader.ReadToEnd();
            
            ProgressEval objectToAdd = new ProgressEval();
            objectToAdd.Content = contents;
            objectToAdd.Name = name;
            objectToAdd.PatientNo = patientNo;

            try
            {
                theEntities.ProgressEvals.AddObject(objectToAdd);
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
        /// Insert audio file into the database.
        /// </summary>
        /// <param name="audioFile">The desired audio file</param>
        /// <returns>Returns true if object was added, else false.</returns>
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
        /// <param name="name">Name of the questionnaire.</param>
        /// <returns>The desired Questionnaire.</returns>
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

        /// <summary>
        /// Find the oldes, not filled in, questionnaire for the given patient.
        /// </summary>
        /// <param name="patientNo">The patientnumber for this patient.</param>
        /// <returns></returns>
        public static Questionnaire getQuestionnaireByPatient(Int32 patientNo)
        {
            try
            {
                NijnCoachEntities theEntities = new NijnCoachEntities();
                String result = theEntities.Questionnairres.Where(x => x.forPatient == patientNo && x.FilledIn == false).First<Questionnairre>().Text;
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

        /// <summary>
        /// Get the speech audio to be used by the avatar.
        /// </summary>
        /// <param name="name">Name of the audio File.</param>
        /// <returns>Returns the desired audio file as SpeechFile. Content is still encoded.</returns>
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

        /// <summary>
        /// Get a progress evaluation as String.
        /// </summary>
        /// <param name="name">the name of the evaluation.</param>
        /// <returns>Returns the desired evaluation as a string.</returns>
        public static String getProgressEvaluationByPatient(Int32 patientNo)
        {
            try
            {
                NijnCoachEntities theEntities = new NijnCoachEntities();
                ProgressEval result = theEntities.ProgressEvals.Where(x => x.PatientNo == patientNo).First<ProgressEval>();
                String contents = result.Content;
                return contents;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.InnerException.ToString());
                throw new FileNotFoundException();
            }

        }

        /// <summary>
        /// Stub method.
        /// </summary>
        public static void updateEval(Int32 patientNo, String newContent)
        {
            NijnCoachEntities theEntities = new NijnCoachEntities();
            try
            {
                ProgressEval eval = theEntities.ProgressEvals.Where(x => x.PatientNo == patientNo).First<ProgressEval>();
                eval.Content = newContent;
                theEntities.SaveChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.InnerException.ToString());
            }
        }

        public static void authenticateUser(String username, String password)
        {
            NijnCoachEntities theEntities = new NijnCoachEntities();
            try
            {

            }
            catch (Exception e)
            {
                MessageBox.Show(e.InnerException.ToString());
            }
        }

    }
}