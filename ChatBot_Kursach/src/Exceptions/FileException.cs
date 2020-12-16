using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                    InitAlert(what);
                    break;


                default:
                    what = "При роботі з файлами виникла помилка.";
                    InitAlert(what);
                    break;

            }
        }
        public FileException():base()
        {
            what = "Усе погано.";
            InitAlert(what);
        }

    }
}
