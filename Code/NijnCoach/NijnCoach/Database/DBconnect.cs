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

        public static Boolean InsertSpeechFile(Object questionForm)
        {
            NijnCoachEntities theEntities = new NijnCoachEntities();
            try
            {
                
                return true;
            }
            catch (Exception e)
            {
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