using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot_Kursach.Algorithms
{

    public class DynamicScreen : Screen
    {
        protected bool[] IsQuestionActive;

        public DynamicScreen(string imgPath, string mainText, Question[] Questions) : base()
        {
            ImagePath = imgPath;
            MainText = mainText;
            questions = Questions;
            IsQuestionActive = Enumerable.Repeat(false, questions.Length).ToArray();           
        }

        public DynamicScreen() : base()
        {

        }

        public bool GetQuestionActive(int q)
        {

            return IsQuestionActive[q];
        }
        public bool SetQuestionActive(int q)
        {
            IsQuestionActive[q] = !IsQuestionActive[q];
            return IsQuestionActive[q];

        }

        public override string GetText()
        {
            TextToReturn = MainText + "\n";

            for (int i = 0; i < questions.Length; i++) if (IsQuestionActive[i]) TextToReturn += "\n" + questions[i].text;
            return TextToReturn;
        }
    }
}
