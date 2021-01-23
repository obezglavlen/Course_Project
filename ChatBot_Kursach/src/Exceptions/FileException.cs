
using System.Linq;

namespace ChatBot_Kursach.Exceptions
{

    public class FileException : MyException
    {

        public FileException(int code) : base()
        {
            switch (code)
            {
                case 1:
                    what = "У директорії програми не знайдено файлу univers.xml.";
                    WorkWithFiles.JSONFile.SaveInfo("favorites");
                    InitAlert(what,true);
                    break;
                case 2:
                    what = "Файл univers.xml був пошкоджений.";
                    WorkWithFiles.JSONFile.SaveInfo("favorites");
                    InitAlert(what,true);
                    break;
                case 3:
                    Constants.Liked = Enumerable.Repeat(false, 10).ToArray();
                    Constants.Liked[0] = true;
                    what = "У директорії програми не знайдено файлу favorites.json, тому він був відновлений.";
                    WorkWithFiles.JSONFile.SaveInfo("favorites");
                    InitAlert(what, true);
                    break;
                default:
                    what = "При роботі з файлами виникла помилка.";
                    WorkWithFiles.JSONFile.SaveInfo("favorites");
                    InitAlert(what,true);
                    break;

            }
        }
        public FileException():base()
        {
            what = "Усе погано.";
            InitAlert(what,true);
        }

    }
}
