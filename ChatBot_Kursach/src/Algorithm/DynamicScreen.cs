
using System.Linq;
using ChatBot_Kursach.Exceptions;

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
            try
            {
                if (q >= 10 && q <= 18)
                    return IsQuestionActive[q - 9];
                else throw new MyException(2);
            }
            catch(MyException ex)
            {
                return false;
            }
        }
        public void SetQuestionActive(int q)
        {
            try
            {
                if (q >= 10 && q <= 18)
            IsQuestionActive[q-9] = !IsQuestionActive[q-9];
                
                else throw new MyException(2);
            }
            catch (MyException ex)
            {
            }
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
