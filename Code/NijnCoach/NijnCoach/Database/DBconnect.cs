using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NijnCoach.XMLclasses;
using System.Xml;

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