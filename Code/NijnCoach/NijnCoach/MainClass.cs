using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NijnCoach.XMLclasses;
using NijnCoach.Database;

namespace NijnCoach
{
    class MainClass
    {
        public static void Main(String[] args)
        {
            Questionnaire q = new Questionnaire();
            DBConnect.InsertQuestionnairre("firstQuest", q);
        }
    }
}
