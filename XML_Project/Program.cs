using System;
using System.Collections.Generic;
using System.Threading;
using System.Xml;

namespace XML_Project
{
    class Program
    {
        public static void CreateXMLFile()
        {
            List<string> studentNames = new List<string> { "Norah", "Abdulrahman", "Mutaz", "Adel", "Sara" };
            XmlDocument xmlDoc = new XmlDocument();
            XmlElement root = xmlDoc.CreateElement("html");
            xmlDoc.AppendChild(root);

            XmlElement head = xmlDoc.CreateElement("head");
            root.AppendChild(head);


            XmlElement h1 = xmlDoc.CreateElement("h1");
            XmlText hText = xmlDoc.CreateTextNode("TUWAIQ STUDENTS");
            head.AppendChild(h1);
            h1.AppendChild(hText);


            XmlElement students = xmlDoc.CreateElement("students");
            root.AppendChild(students);

            foreach (var name in studentNames)
            {
                XmlElement student = xmlDoc.CreateElement("student");
                XmlElement studentName = xmlDoc.CreateElement("name");
                XmlText stNameText = xmlDoc.CreateTextNode(name);
                student.AppendChild(studentName);
                studentName.AppendChild(stNameText);
                students.AppendChild(student);

            }

            xmlDoc.Save(@"D:\\XMLProject.xml");
            Console.WriteLine(xmlDoc.InnerXml);
        }

        static void ReadXMLFile()
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(@"D:\\XMLProject.xml");
            foreach (XmlNode node in xmldoc.DocumentElement.ChildNodes)
            {
                string element = node.Name;
                Console.Write(element + ": ");
                string text = node.InnerText;
                Console.WriteLine(text);
            }

        }

        static void Main(string[] args)
        {
            CreateXMLFile();
            Thread writerThread = new Thread(CreateXMLFile);
            writerThread.Start();
            writerThread.Join();
            Thread readThread = new Thread(ReadXMLFile);
            readThread.Start();

            ReadXMLFile();

        }
       
    }
}
