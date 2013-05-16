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

        public Boolean InsertSpeechFile(Object questionForm)
        {
            NijnCoachEntities2 theEntities = new NijnCoachEntities2();
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

        public Patient getPatientByLastName(String name)
        {
            NijnCoachEntities2 theEntities = new NijnCoachEntities2();            
            Patient result = theEntities.Patients.Where(x => x.Lname == name).First<Patient>();
            return result;
        }

        public Patient getPatientByFirstName(String name)
        {
            NijnCoachEntities2 theEntities = new NijnCoachEntities2();
            Patient result = theEntities.Patients.Where(x => x.Fname == name).First<Patient>();
            return result;
        }

        public Patient getPatientByNumber(int number)
        {
            NijnCoachEntities2 theEntities = new NijnCoachEntities2();
            Patient result = theEntities.Patients.Where(x => x.PatientNo == number).First<Patient>();
            return result;
        }
        #endregion
        /// <summary>
        /// Finds the questionnaire with the given name. Throws FileNotFoundException if it does not exist.
        /// </summary>
        /// <param name="name">Name of the questionnaire</param>
        /// <returns>The Questionnaire</returns>
        public Questionnaire getQuestionnaireByName(String name)
        {
            try
            {
                NijnCoachEntities2 theEntities = new NijnCoachEntities2();
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