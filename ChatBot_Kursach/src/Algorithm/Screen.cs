using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot_Kursach.Algorithms
{
    public class Screen
    {
        protected int ImagePath;
        protected string MainText;
        protected string TextToReturn;
        protected Question[] questions;

        public Screen(int imgPath, string mainText, Question[] Questions)
        {
            ImagePath = imgPath;
            MainText = mainText;
            questions = Questions;
        }

        public Screen()
        {
            ImagePath = (int)Constants.Images.ROBOT;
            MainText = "";
        }

        public int imagePath { get { return ImagePath; } }

        public virtual int CheckKeyword(string keyword)
        {
            for (int i = 0; i < questions.Length; i++)
            {
                if (questions[i].CheckKeyword(keyword) == true)
                    return questions[i].NextScreen;
            }
            return -1;

        }
        public virtual string Text
        {
            get
            {
                TextToReturn = "Бот: \n" + MainText + "\n\n";
                for (int i = 0; i < questions.Length; i++) TextToReturn += questions[i].text + '\n';
                return TextToReturn;
            }
        }

    }


    public class QScreen : Screen
    {

    }



}



