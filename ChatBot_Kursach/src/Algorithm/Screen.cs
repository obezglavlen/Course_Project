using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot_Kursach.Algorithms
{
    public class Screen
    {
        protected string ImagePath;
        protected string MainText;
        protected string TextToReturn;
        protected Question[] questions;
        protected bool ButtonVisible;
        public Screen(string imgPath, string mainText, Question[] Questions, bool ButonVisible)
        {
            ImagePath = imgPath;
            MainText = mainText;
            questions = Questions;
            ButtonVisible = ButonVisible;
        }

        public Screen() { }

        public string imagePath { get { return ImagePath; } }

        public bool Buttonvisible { get { return ButtonVisible; } }
        public virtual int CheckKeyword(string keyword)
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
            TextToReturn = "Бот: \n" + MainText + '\n';
            for (int i = 0; i < questions.Length; i++) TextToReturn += questions[i].text + '\n';
            return TextToReturn + "———————————————————————————————————————————\n";
        }

    }


    public class QScreen : Screen
    {

    }



}



