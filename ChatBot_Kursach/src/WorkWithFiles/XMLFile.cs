using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ChatBot_Kursach.WorkWithFiles
{
    class XMLFile
    {
        private XmlDocument mydoc = new XmlDocument();
        private XmlElement root;
        public XMLFile(string docname)
        {
            mydoc.Load($"..\\..\\src\\{docname}.xml");
            root = mydoc.DocumentElement;
        }
        public void LoadInfo()
        {
            foreach(XmlElement node in root)
            {
                XmlNode pointer = node.ChildNodes[0];
                switch(pointer.InnerText)
                {
                    case "about":
                        pointer = node.ChildNodes[1];
                        Constants.__About = pointer.InnerText;
                        break;
                    case "Artesis":
                        pointer = node.ChildNodes[1];
                        Constants.__ArtesisStr = pointer.InnerText;
                        break;
                    case "Leuven":
                        pointer = node.ChildNodes[1];
                        Constants.__LeuvenStr = pointer.InnerText;
                        break;
                    case "Ilmenau":
                        pointer = node.ChildNodes[1];
                        Constants.__IlmenauStr = pointer.InnerText;
                        break;
                    case "Dortmund":
                        pointer = node.ChildNodes[1];
                        Constants.__DortmundStr = pointer.InnerText;
                        break;
                    case "Madrid":
                        pointer = node.ChildNodes[1];
                        Constants.__MadridStr = pointer.InnerText;
                        break;
                    case "Karint":
                        pointer = node.ChildNodes[1];
                        Constants.__KarintStr = pointer.InnerText;
                        break;
                    case "Thomas":
                        pointer = node.ChildNodes[1];
                        Constants.__ThomasStr = pointer.InnerText;
                        break;
                    case "Transilvania":
                        pointer = node.ChildNodes[1];
                        Constants.__TransilvaniaStr = pointer.InnerText;
                        break;
                }
            }
        }
        
    }
}
