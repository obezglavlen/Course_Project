using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using ChatBot_Kursach.Exceptions;

namespace ChatBot_Kursach.WorkWithFiles
{
    class XMLFile
    {
        private XmlDocument mydoc = new XmlDocument();
        private XmlElement root;
        public XMLFile(string docname)
        {
            try
            {

                if (!File.Exists($"{docname}.xml")) throw new FileException(1);
                mydoc.Load($"{docname}.xml");
                root = mydoc.DocumentElement;
            }
            catch(FileException ex)
            {

            }

            catch(Exception ex)
            {
                new MyException(ex);
            }
        }
        public void LoadInfo()
        {
            foreach(XmlElement node in root)
            {
                XmlNode univer = node.ChildNodes[0];
                if(univer.InnerText == "Artesis")
                    Constants.__ArtesisStr = univer.InnerText;
                if (univer.InnerText == "Leuven")
                    Constants.__LeuvenStr = univer.InnerText;
                if (univer.InnerText == "Ilmenau")
                    Constants.__IlmenauStr = univer.InnerText;
                if (univer.InnerText == "Dortmund")
                    Constants.__DortmundStr = univer.InnerText;
                if (univer.InnerText == "Madrid")
                    Constants.__MadridStr = univer.InnerText;
                if (univer.InnerText == "Karint")
                    Constants.__KarintStr = univer.InnerText;
                if (univer.InnerText == "Thomas")
                    Constants.__ThomasStr = univer.InnerText;
                if (univer.InnerText == "Transilvania")
                    Constants.__TransilvaniaStr = univer.InnerText;
            }
        }
        
    }
}
