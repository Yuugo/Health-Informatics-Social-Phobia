using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NijnCoach.XMLclasses;

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

        public Boolean InsertQuestionnairre(String name, String text)
        {
            NijnCoachEntities2 theEntities = new NijnCoachEntities2();
            Questionnairre questionForm = new Questionnairre();
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