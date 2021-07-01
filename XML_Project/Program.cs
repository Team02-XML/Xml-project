using System;
using System.Xml;

namespace XML_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadXMLFile();
        }

        static void ReadXMLFile()
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(@"");
            foreach (XmlNode node in xmldoc.DocumentElement.ChildNodes)
            {
                string element = node.Name;
                Console.Write(element + ": ");
                string text = node.InnerText;
                Console.WriteLine(text);
            }

        }
    }
}
