using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using NijnCoach.XMLclasses;

namespace NijnCoach.XMLclasses
{
    public class ListOfIEntry : List<IEntry>, IXmlSerializable
    {
        public ListOfIEntry() : base() { }

        public System.Xml.Schema.XmlSchema GetSchema() { return null; }

        public void ReadXml(XmlReader reader)
        {
            reader.ReadStartElement("entries");
            while (reader.IsStartElement("IEntry"))
            {
                Type type = Type.GetType(reader.GetAttribute("AssemblyQualifiedName"));
                XmlSerializer serial = new XmlSerializer(type);

                reader.ReadStartElement("IEntry");
                this.Add((IEntry)serial.Deserialize(reader));
                reader.ReadEndElement(); //Ientry
            }
            reader.ReadEndElement(); //ListOfIentry
        }

        public void WriteXml(XmlWriter writer)
        {
            foreach (IEntry entry in this)
            {
                writer.WriteStartElement("IEntry");
                writer.WriteAttributeString("AssemblyQualifiedName", entry.GetType().AssemblyQualifiedName);
                XmlSerializer xmlSerializer = new XmlSerializer(entry.GetType());
                xmlSerializer.Serialize(writer, entry);
                writer.WriteEndElement();
            }
        }
    }
}
