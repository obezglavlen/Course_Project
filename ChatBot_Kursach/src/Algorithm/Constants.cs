
using System.Text.RegularExpressions;


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
            TRANSILVANIA,
            LEUVEN_MAP,
            ILMENAU_MAP,
            DORTMUND_MAP,
            MADRID_MAP,
            KARINT_MAP,
            ARTESIS_MAP,
            THOMAS_MAP,
            TRANSILVANIA_MAP
        }

        public static Regex toMainRegex = new Regex("0|головне|меню|повернутися|назад");

        public static string __LeuvenStr = "";
        public static string __IlmenauStr = "";
        public static string __DortmundStr = "";
        public static string __MadridStr = "";
        public static string __KarintStr = "";
        public static string __ArtesisStr = "";
        public static string __ThomasStr = "";
        public static string __TransilvaniaStr = "";
        public static string __About = "";

        public static bool[] Liked;
    }
}
