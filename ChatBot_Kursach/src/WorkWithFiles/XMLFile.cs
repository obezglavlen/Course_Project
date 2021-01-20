
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
    static class XMLFile
    {
        static private XmlDocument mydoc = new XmlDocument();
        static private XmlElement root;
        public static void LoadInfo(string docname)
        {

            try
            {

                if (!File.Exists($".\\{docname}.xml")) throw new FileException(1);
                mydoc.Load($".\\{docname}.xml");
                root = mydoc.DocumentElement;
            }
            catch (FileException ex)
            {

            }

            catch (Exception ex)
            {
                new MyException(ex);
            }

            foreach (XmlElement node in root)
            {
                try
                {
                    XmlNode pointer = node.ChildNodes[0];
                    if (pointer == null) throw new FileException(2);
                    switch (pointer.InnerText)
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
                catch (FileException ex)
                {

                }
                catch (Exception ex)
                {
                    new MyException(ex);
                }
            }



        }

    }
}