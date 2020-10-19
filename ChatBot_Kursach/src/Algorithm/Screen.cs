using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot_Kursach.Algorithms
{


    //screeeen
    public class Screen
    {
        protected string ImagePath;
        protected string MainText;
        protected string TextToReturn;
        protected Question[] question;
        protected int count;

        public Screen(string imgPath, string mainText, int countOfQuestions, Question[] Questions)
        {
            ImagePath = imgPath;
            MainText = mainText;
            count = countOfQuestions;
            question = new Question[countOfQuestions];

            question = Questions;

        }

        public Screen() { }

        public string GetImagePath() { return ImagePath; }

        public int CheckKeyword(string keyword)
        {

            for (int i = 0; i < count; i++)
            {
                if (question[i].CheckKeyword(keyword))
                {
                    return question[i].NextScreen;
                }
            }
            return -1;

        }
        public virtual string GetText()
        {
            TextToReturn = MainText + "\n";
            for (int i = 0; i < count; i++) TextToReturn += "\n" + question[i].text;
            return TextToReturn;
        }

    }
}
