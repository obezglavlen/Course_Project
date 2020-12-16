using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ChatBot_Kursach
{
    static class Constants
    {
        public enum Images
        {
            NULL,
            ROBOT,
            SEND,
            HEART,
            LEUVEN,
            ILMENAU,
            DORTMUND,
            MADRID,
            KARINT,
            ARTESIS,
            THOMAS,
            TRANSILVANIA
        }

        public static Regex toMainRegex = new Regex("0|головне|меню|повернутися");

        public static string __LeuvenStr = "";
        public static string __IlmenauStr = "";
        public static string __DortmundStr = "";
        public static string __MadridStr = "";
        public static string __KarintStr = "";
        public static string __ArtesisStr = "";
        public static string __ThomasStr = "";
        public static string __TransilvaniaStr = "";
        public static string __About = "";
    }
}
