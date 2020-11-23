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
        protected bool ButtonVisible;
        public Screen(int imgPath, string mainText, Question[] Questions, bool ButtonVisible)
        {
            ImagePath = imgPath;
            MainText = mainText;
            questions = Questions;
            this.ButtonVisible = ButtonVisible;
        }

        public Screen()
        {
            ImagePath = (int)Constants.Images.ROBOT;
            MainText = "";
            ButtonVisible = false;
        }

        public int imagePath { get { return ImagePath; } }

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
        public virtual string Text
        {
            get
            {
                TextToReturn = "Бот: \n" + MainText + '\n';
                for (int i = 0; i < questions.Length; i++) TextToReturn += questions[i].text + '\n';
                return TextToReturn;
            }
        }

    }


    public class QScreen : Screen
    {

    }



}



