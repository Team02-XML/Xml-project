using System;
using System.Collections.Generic;
using System.Threading;
using System.Xml;

namespace XML_Project
{
    class Program
    {
        static XmlDocument xmlDoc = new XmlDocument();
        static XmlElement root = xmlDoc.CreateElement("html");
        static List<string> studentNames = new List<string> { "Norah", "Abdulrahman", "Mutaz", "Adel", "Sara" };
        public static void CreateXMLFile()
        {
            xmlDoc.AppendChild(root);
            XmlElement head = xmlDoc.CreateElement("head");
            root.AppendChild(head);
            XmlElement h1 = xmlDoc.CreateElement("h1");
            XmlText hText = xmlDoc.CreateTextNode("TUWAIQ STUDENTS");
            head.AppendChild(h1);
            h1.AppendChild(hText);
            CreateStudent();
            xmlDoc.Save(@"D:\\XMLProject.xml");
            Console.WriteLine(xmlDoc.InnerXml);
        }
        static void CreateStudent()
        {
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
            Thread writerThread = new Thread(CreateXMLFile);
            writerThread.Start();
            writerThread.Join();
            Thread readThread = new Thread(ReadXMLFile);
            readThread.Start();
        }
       
    }
}
