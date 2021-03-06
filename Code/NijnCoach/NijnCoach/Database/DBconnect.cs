﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NijnCoach.XMLclasses;
using System.Xml;
using System.IO;
using System.Security.Cryptography;

namespace NijnCoach.Database
{
    public static class DBConnect
    {
        /// <summary>
        /// Insert a Patient object into the Database. The object should have all his attributes defined already.
        /// </summary>
        /// <param name="patient">A comepleted Patient object.</param>
        /// <returns>Returns true if object was added, else false.</returns>
        public static Boolean insertPatient(Sickpeople patient)
        {
            NijnCoachEntities theEntities = new NijnCoachEntities();

            try
            {
                theEntities.Sickpeoples.AddObject(patient);
                theEntities.SaveChanges();
                return true;

            }
            catch (Exception e)
            {
                //TODO: blabla
                MessageBox.Show(e.Message.ToString());
                MessageBox.Show(e.StackTrace.ToString());
                return false;
            }
        }

        /// <summary>
        /// Insert a Questionnaire into the database under the given name.
        /// </summary>
        /// <param name="name">Name of the Questionnaire</param>
        /// <param name="questionnaire">The already created Questionnaire</param>
        /// <returns>Returns true if object was added, else false.</returns>
        public static Boolean InsertQuestionnairre(String name, Int32 patientNo, Questionnaire questionnaire)
        {
            NijnCoachEntities theEntities = new NijnCoachEntities();
            Questionnairre questionForm = new Questionnairre();
            XMLParser parser = new XMLParser();
            string text = parser.writeXML(questionnaire);

            questionForm.Name = name;
            questionForm.Text = text;
            questionForm.Type = "Questionnaire";
            questionForm.FilledIn = 0;
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
        public static Boolean InsertProgressEvaluation(String name, Int32 patientNo, String data)
        {
            NijnCoachEntities theEntities = new NijnCoachEntities();

            ProgressEval objectToAdd = new ProgressEval();
            objectToAdd.Content = data;
            objectToAdd.Emotion = "Happy";
            objectToAdd.Commentary = "";
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

        public static Boolean InsertUser(String type, String username, String pass)
        {
            NijnCoachEntities theEntities = new NijnCoachEntities();
            User user = new User();
            user.Password = pass;
            user.Type = type;
            user.Username = username;

            try
            {
                theEntities.Users.AddObject(user);
                theEntities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                //MessageBox.Show(e.InnerException.ToString());
                return false;
            }
        }

        /// <summary>
        /// Insert audio file into the database.
        /// </summary>
        /// <param name="audioFile">The desired audio file</param>
        /// <returns>Returns true if object was added, else false.</returns>
        public static Boolean InsertSpeechFile(string audioAsString, string naam, int part)
        {
            NijnCoachEntities theEntities = new NijnCoachEntities();


            AudioFile newSpeech = new AudioFile();
            newSpeech.Name = naam;
            newSpeech.PartNo = part;
            int songNumber;

            //Oh god
            try
            {
                var dat = theEntities.AudioFiles.Where(x => x.Name.Equals(naam));
                if (theEntities.AudioFiles.Count() == 0)
                    songNumber = 1;
                else if (dat.Count() != 0)
                    songNumber = dat.First<AudioFile>().TrackNo;
                else
                {
                    songNumber = theEntities.AudioFiles.OrderByDescending(u => u.TrackNo).First().TrackNo + 1;
                }

                newSpeech.TrackNo = songNumber;
                newSpeech.Encoding = audioAsString;
                theEntities.AudioFiles.AddObject(newSpeech);
                theEntities.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                //kijkt of de exception duplicate is en dus nog wel geaccepteerd kan worden
                Console.WriteLine(e.Message.ToString());
                string[] except = null;
                //split de exception in stukken             
                except = e.Message.Split(' ');
                if (except[2].Equals("Duplicate"))
                {
                    return true;
                }
                MessageBox.Show(e.Message.ToString());
                return false;
            }
        }

		#region PatientSelectors

        public static string getName(int userNo)
        {
            NijnCoachEntities theEntities = new NijnCoachEntities();
            Sickpeople pat = theEntities.Sickpeoples.Where(x => x.PatientNo == userNo).First<Sickpeople>();
            return pat.Fname + " " + pat.Lname;
        }

        public static Sickpeople getPatientByLastName(String name)
        {
            NijnCoachEntities theEntities = new NijnCoachEntities();
            Sickpeople result = theEntities.Sickpeoples.Where(x => x.Lname == name).First<Sickpeople>();
            return result;
        }

        public static Sickpeople getPatientByFirstName(String name)
        {
            NijnCoachEntities theEntities = new NijnCoachEntities();
            Sickpeople result = theEntities.Sickpeoples.Where(x => x.Fname == name).First<Sickpeople>();
            return result;
        }

        public static Sickpeople getPatientByNumber(int number)
        {
            NijnCoachEntities theEntities = new NijnCoachEntities();
            Sickpeople result = theEntities.Sickpeoples.Where(x => x.PatientNo == number).First<Sickpeople>();
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
                String result= theEntities.Questionnairres.Where(x => x.Name == name && x.FilledIn != -1).First<Questionnairre>().Text;
                XMLParser parser = new XMLParser();
                byte[] byteArray = Encoding.ASCII.GetBytes(result);
                MemoryStream stream = new MemoryStream(byteArray);
                StreamReader reader = new StreamReader(stream);
                return parser.readXML(reader);
            }
            catch (Exception)
            {
                return null;
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
                String result = theEntities.Questionnairres.Where(x => x.forPatient == patientNo && x.FilledIn >= 0).First<Questionnairre>().Text;
                XMLParser parser = new XMLParser();
                byte[] byteArray = Encoding.ASCII.GetBytes(result);
                MemoryStream stream = new MemoryStream(byteArray);
                StreamReader reader = new StreamReader(stream);
                return parser.readXML(reader);
            }
            catch (Exception)
            {
                throw new FileNotFoundException();
            }
        }

        /// <summary>
        /// Find the oldes, not filled in, questionnaire for the given patient.
        /// </summary>
        /// <param name="patientNo">The patientnumber for this patient.</param>
        /// <returns></returns>
        public static Questionnaire getQuestionnaireById(SByte id)
        {
            try
            {
                NijnCoachEntities theEntities = new NijnCoachEntities();
                String result = theEntities.Questionnairres.Where(x => x.Id == id).First<Questionnairre>().Text;
                XMLParser parser = new XMLParser();
                byte[] byteArray = Encoding.ASCII.GetBytes(result);
                MemoryStream stream = new MemoryStream(byteArray);
                StreamReader reader = new StreamReader(stream);
                return parser.readXML(reader);
            }
            catch (Exception)
            {
                throw new FileNotFoundException();
            }
        }

        /// <summary>
        /// Find the oldes, not filled in, questionnaire for the given patient.
        /// </summary>
        /// <param name="patientNo">The patientnumber for this patient.</param>
        /// <returns></returns>
        public static List<Questionnairre> getQuestionnairesByPatient(Int32 patientNo)
        {
            try
            {
                NijnCoachEntities theEntities = new NijnCoachEntities();
                List<Questionnairre> qs = theEntities.Questionnairres.Where(x => x.forPatient == patientNo).ToList<Questionnairre>();
                if (qs.Count == 0)
                {
                    return null;
                }
                return qs;
            }
            catch (Exception)
            {
                throw new FileNotFoundException();
            }
        }

        /// <summary>
        /// Get the question the patient stopped at.
        /// </summary>
        /// <param name="patientNo">The patientnumber for this patient.</param>
        /// <returns></returns>
        public static int getQuestion(Int32 patientNo)
        {
            try
            {
                NijnCoachEntities theEntities = new NijnCoachEntities();
                Questionnairre q = theEntities.Questionnairres.Where(x => x.forPatient == patientNo && x.FilledIn >= 0).First<Questionnairre>();

                return q.FilledIn;
            }
            catch (Exception)
            {
                throw new FileNotFoundException();
            }
        }

        /// <summary>
        /// Get the speech audio to be used by the avatar.
        /// </summary>
        /// <param name="name">Name of the audio File.</param>
        /// <returns>Returns the desired audio file as SpeechFile. Content is still encoded.</returns>
        public static String getSpeechFile(string name)
        {

            try
            {
                NijnCoachEntities theEntities = new NijnCoachEntities();
                List<AudioFile> partList = theEntities.AudioFiles.Where(x => x.Name == name).ToList<AudioFile>();
                String result = "";
                foreach (AudioFile trackPart in partList)
                {
                    result += trackPart.Encoding;
                }
                return result;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.InnerException.ToString());
                throw new FileNotFoundException();
            }
        }

        public static SByte getUserNo(string name)
        {

            try
            {
                NijnCoachEntities theEntities = new NijnCoachEntities();
                SByte result = theEntities.Users.Where(x => x.Username == name).First<User>().PatientNo;
                return result;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.InnerException.ToString());
                throw new FileNotFoundException();
            }
        }

        public static bool getType(SByte userNo)
        {

            try
            {
                NijnCoachEntities theEntities = new NijnCoachEntities();
                String result = theEntities.Users.Where(x => x.PatientNo == userNo).First<User>().Type;
                if (result == "Therapist")
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.InnerException.ToString());
                throw new FileNotFoundException();
            }
        }

        /// <summary>
        /// Get the userNo of user if pass and log in match
        /// </summary>
        /// <param name="name">Name of the user, password of the user</param>
        /// <returns>Returns the number of the user</returns>
        public static SByte getUser(string name,string password)
        {
            SByte result = -1;

            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] encode = Encoding.ASCII.GetBytes(password);
            encode = md5.ComputeHash(encode);
            String pass = Encoding.ASCII.GetString(encode);

            try
            {
                NijnCoachEntities theEntities = new NijnCoachEntities();
                IQueryable<User> users = theEntities.Users.Where(x => x.Username == name && x.Password == pass);
                if (users.Count() != 0){
                    result = users.First().PatientNo;
                }
                
                return result;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.InnerException.ToString());
                throw new FileNotFoundException();
            }
        }



        /// <summary>
        /// Get all the progress evaluations in a List.
        /// </summary>
        /// <param name="name">the name of the evaluation.</param>
        /// <returns>Returns the evaluations in a List.</returns>
        public static List<ProgressEval> getProgressEvaluationByPatient(Int32 patientNo)
        {
            try
            {
                NijnCoachEntities theEntities = new NijnCoachEntities();
                List<ProgressEval> result = theEntities.ProgressEvals.Where(x => x.PatientNo == patientNo).ToList();
                return result;
            }
            catch (MySql.Data.MySqlClient.MySqlException e)
            {
                MessageBox.Show(e.InnerException.ToString());
                throw new FileNotFoundException();
            }

        }

        public static String getEvaluationCommentaryByPatient(Int32 patientNo)
        {
            try
            {
                NijnCoachEntities theEntities = new NijnCoachEntities();
                ProgressEval result = theEntities.ProgressEvals.Where(x => x.PatientNo == patientNo).First<ProgressEval>();
                String res = result.Commentary;
                return res;
            }
            catch (MySql.Data.MySqlClient.MySqlException e)
            {
                MessageBox.Show(e.InnerException.ToString());
                throw new FileNotFoundException();
            }
        }

        /// <summary>
        /// Stub method.
        /// </summary>
        public static void setEvaluationCommentaryByPatientAndName(Int32 patientNo, String name, String newContent, String emotion)
        {
            NijnCoachEntities theEntities = new NijnCoachEntities();
            try
            {
                ProgressEval eval = theEntities.ProgressEvals.Where(x => x.PatientNo == patientNo && x.Name == name).First<ProgressEval>();
                eval.Commentary = newContent;
                eval.Emotion = emotion;
                theEntities.SaveChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.InnerException.ToString());
            }
        }



        /// <summary>
        /// Stub method.
        /// </summary>
        public static void updateQuestionnaire(int patientNo, String q,int questions)
        {
            NijnCoachEntities theEntities = new NijnCoachEntities();

            try
            {
                Questionnairre newQ = theEntities.Questionnairres.Where(x => x.forPatient == patientNo && x.FilledIn >= 0).First<Questionnairre>();
                newQ.Text = q;
                newQ.FilledIn = questions;
                theEntities.SaveChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.InnerException.ToString());
            }
        }




        public static List<Sickpeople> getPatients()
        {
            NijnCoachEntities theEntities = new NijnCoachEntities();
            
            try
            {
                List<Sickpeople> patients= theEntities.Sickpeoples.Where(x => x.PatientNo == x.PatientNo).ToList<Sickpeople>();
                return patients;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.InnerException.ToString());
                return null;
            }
        }
    }
}