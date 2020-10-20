using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot_Kursach.Algorithms
{
    //Ya ibu sobak

    //screeeen
    public class Screen
    {
        protected string ImagePath;
        protected string MainText;
        protected string TextToReturn;
        protected Question[] questions;

        public Screen(string imgPath, string mainText, Question[] Questions)
        {
            ImagePath = imgPath;
            MainText = mainText;
            questions = Questions;

        }

        public Screen() { }

        public string imagePath { get { return ImagePath; } }

        public int CheckKeyword(string keyword)
        {
            for (int i = 0; i < questions.Length; i++)
            {
                if (questions[i].CheckKeyword(keyword) == true)
                    return questions[i].NextScreen;
            }
            return -1;

        }
        public virtual string GetText()
        {
            TextToReturn = MainText + "\n";
            for (int i = 0; i < questions.Length; i++) TextToReturn += "\n" + questions[i].text;
            return TextToReturn;
        }

    }
}
