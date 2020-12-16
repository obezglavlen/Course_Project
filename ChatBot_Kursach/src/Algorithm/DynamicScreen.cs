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

        public DynamicScreen(int imgPath, string mainText, Question[] Questions) : base()
        {
            ImagePath = imgPath;
            MainText = mainText;
            questions = Questions;
            //IsQuestionActive = Enumerable.Repeat(false, 10).ToArray();
            IsQuestionActive = Constants.Liked;


        }

        public DynamicScreen() : base()
        {
            ImagePath = (int)Constants.Images.ROBOT;
            MainText = "";

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
            return IsQuestionActive[q-9];
        }
        public void SetQuestionActive(int q)
        {
            IsQuestionActive[q-9] = !IsQuestionActive[q-9];
        }

        public void ClearQuestionActive()
        {
            Constants.Liked = Enumerable.Repeat(false, 10).ToArray();
            Constants.Liked[0] = true;
            IsQuestionActive = Constants.Liked;
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
