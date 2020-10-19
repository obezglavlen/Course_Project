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

        public DynamicScreen(string imgPath, string mainText, int countOfQuestions, Question[] Questions) : base()
        {
            ImagePath = imgPath;
            MainText = mainText;
            count = countOfQuestions;
            IsQuestionActive = Enumerable.Repeat(false, countOfQuestions).ToArray();
            question = new Question[countOfQuestions];
            question = Questions;

        }

        public DynamicScreen() : base()
        {

        }

        public bool SetQuestionActive(int q)
        {
            IsQuestionActive[q] = !IsQuestionActive[q];
            return IsQuestionActive[q];

        }

        public override string GetText()
        {
            TextToReturn = MainText + "\n";

            for (int i = 0; i < count; i++) if (IsQuestionActive[i]) TextToReturn += "\n" + question[i].text;
            return TextToReturn;
        }
    }
}
