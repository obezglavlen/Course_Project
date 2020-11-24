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

        public DynamicScreen(int imgPath, string mainText, Question[] Questions, bool ButtonVisible) : base()
        {
            ImagePath = imgPath;
            MainText = mainText;
            questions = Questions;
            IsQuestionActive = Enumerable.Repeat(false, 10).ToArray();
            IsQuestionActive[0] = true;

            this.ButtonVisible = ButtonVisible;
        }

        public DynamicScreen() : base()
        {
            ImagePath = (int)Constants.Images.ROBOT;
            MainText = "";
            ButtonVisible = false;
        }

        public override int CheckKeyword(string keyword)
        {
            for (int i = 0; i < questions.Length; i++)
            {
                if(IsQuestionActive[i])
                if (questions[i].CheckKeyword(keyword) == true)
                    return questions[i].NextScreen;
            }
            return -1;

        }

        public bool GetQuestionActive(int q)
        {
            return IsQuestionActive[q];
        }
        public void SetQuestionActive(int q)
        {
            IsQuestionActive[q] = !IsQuestionActive[q];
        }

        public void ClearQuestionActive()
        {
            IsQuestionActive = Enumerable.Repeat(false, 10).ToArray();
            IsQuestionActive[0] = true;
        }
        public override string Text
        {
            get
            {
                TextToReturn = MainText + "\n";

                for (int i = 0; i < questions.Length; i++) if (IsQuestionActive[i]) TextToReturn += "\n" + questions[i].text;
                return TextToReturn;
            }
            
        }
    }
}
