using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot_Kursach.Algorithms
{
    public class OpScreen : DynamicScreen
    {

        public OpScreen(int imgPath, string mainText, Question[] Questions, bool ButtonVisible) : base()
        {
            ImagePath = imgPath;
            MainText = mainText;
            questions = Questions;
            IsQuestionActive = Enumerable.Repeat(false, 10).ToArray();
            IsQuestionActive[0] = true;
            this.ButtonVisible = ButtonVisible;
        }

        public bool Set(short English, bool IsStudent)
        {
            IsQuestionActive = Enumerable.Repeat(false, questions.Length).ToArray();
            IsQuestionActive[0] = true;
            //1:льовен, 2: Ыльмен, 3: Дортмунд, 4:Брашов, 5: Каринтій, 6: Мадрид, 7:Бельгія, 8:Антверпень, 9:
            if (IsStudent)
            {
                if (English == 1)
                {
                    IsQuestionActive[1] = true;
                    IsQuestionActive[4] = true;
                    IsQuestionActive[5] = true;
                    IsQuestionActive[6] = true;
                    IsQuestionActive[8] = true;
                    IsQuestionActive[7] = true;
                }
                else
                {
                    IsQuestionActive[3] = true;
                    IsQuestionActive[2] = true;
                }

            }
            else if (English == 3) IsQuestionActive[2] = true;
            else
            {
                IsQuestionActive[7] = true;
                IsQuestionActive[3] = true;
                IsQuestionActive[8] = true;
                IsQuestionActive[6] = true;
                IsQuestionActive[5] = true;
                IsQuestionActive[1] = true;

            }

            return true;
        }

    }
}
