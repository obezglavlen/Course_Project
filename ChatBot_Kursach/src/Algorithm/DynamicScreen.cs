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

<<<<<<< Updated upstream
        public DynamicScreen(string imgPath, string mainText, int countOfQuestions, Question[] Questions, bool AllActive) : base()
        {
            ImagePath = imgPath;
            MainText = mainText;
            count = countOfQuestions;
            IsQuestionActive = Enumerable.Repeat(false, countOfQuestions).ToArray();
            question = new Question[countOfQuestions];
            question = Questions;
            IsAllActive = AllActive;
=======
        public DynamicScreen(string imgPath, string mainText, Question[] Questions) : base()
        {
            ImagePath = imgPath;
            MainText = mainText;
            questions = Questions;
            IsQuestionActive = Enumerable.Repeat(false, questions.Length).ToArray();           
>>>>>>> Stashed changes
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
