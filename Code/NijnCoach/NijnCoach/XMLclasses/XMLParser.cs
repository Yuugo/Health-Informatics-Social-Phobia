using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using NijnCoach.XMLclasses;
using System.IO;

namespace NijnCoach
{
    public class XMLParser
    {
        String path { get; set; }

        //Method used to deserialize(XML to object) XML
        public Questionnaire readXML()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Questionnaire));
            StreamReader reader = new StreamReader("writeTest.xml");
            Questionnaire theForm = (Questionnaire)serializer.Deserialize(reader);
            reader.Close();
            return theForm;
        }

        //Method used to serialize(object to XML) XML
        public void writeXML(Questionnaire q, String fileName)
        {
        #region ExampleObject
            /*
            q = new Questionnaire()
            {
                version = 1.00,
                head = new Questionnaire.Header
                {
                    createdBy = "Me",
                    dateCreated = new DateTime(),
                    filledBy = "Him",
                    dateFilled = new DateTime()
                },
                entries = new ListOfIEntry
                {
                    new Comment 
                    {
                        value = "blabla",
                        emotion = "happy"
                    },
                    new OpenQuestion
                    {
                        question = "What was the most difficult situation? Please tell me how it went.",
                        theAnswer = new Answer()
                    },
                    new MCQuestion
                    {                        
                        options = new List<Option> 
                        {
                            new Option 
                            {
                                tag = "a",
                                emotion = "angry",
                                answer = "1-3"
                            },
                            new Option
                            {
                                tag = "b",
                                emotion = "happy",
                                answer = "4-6"
                            },
                            new Option
                            {
                                tag = "c",
                                emotion = "neutral",
                                answer = "7 or more"
                            }
                        },
                        theAnswer = new Answer()
                    }
                }
            };
             */
            #endregion
            XmlSerializer ser = new XmlSerializer(typeof(Questionnaire));
            StringBuilder sb = new StringBuilder();
            StringWriter writer = new StringWriter(sb);
            ser.Serialize(writer, q);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(sb.ToString());
            doc.Save(fileName);
        }
    }
}
