using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot_Kursach.Algorithms
{

    public class MainClass
    {
        Question[] testQuestionList;
     //   Screen current;
        Screen[] screens;
        Screen mistake;
        int Current, trueCurrent;

        public MainClass()
        {
            screens = new Screen[40];
            Current = trueCurrent = 0;


            ///////////////////////////////
            testQuestionList = new Question[4];
            testQuestionList[0] = new Question("1. дізнатися, що таке міжнародна академічна мобільність\n", new string[] { "1", "академічна", "мобільність" }, 1);
            testQuestionList[1] = new Question("2. пройти опитування, та отримати рекомендації щодо програми\n", new string[] { "2", "опитування", "пройти", "рекомендації" }, 2);
            testQuestionList[2] = new Question("3. переглянути всі програми академічної мобільності\n", new string[] { "3", "всі", "програми" }, 3);
            testQuestionList[3] = new Question("4. переглянути обране\n", new string[] { "4", "обране" }, 4);
            mistake = new Screen("robot", "Mistake", new Question[] { new Question("0. Повернення до головного меню", new string[] { "0" }, 0) });
            screens[0] = new Screen("robot", "Привіт, я — чат-бот помічник по справам академічної мобільності. Я допоможу тобі обрати відповідну програму.\n" +
                "Спочатку, що ти хочешь введи відповідь, яка позначає те що ти хочешь.\n", testQuestionList);
            screens[1] = new Screen("send", "Screen 1\n", new Question[] { new Question ("0. Повернення до головного меню", new string[] { "0" }, 0) });
            screens[2] = new DynamicScreen("heart", "Screen 2\n", new Question[] { new Question("0. Повернення до головного меню", new string[] { "0" }, 0) });
            screens[3] = new Screen("robot", "Screen 3\n", new Question[] { new Question("0. Повернення до головного меню", new string[] { "0" }, 0) });
            screens[4] = new Screen("heart", "Screen 4\n", new Question[] { new Question("0. Повернення до головного меню", new string[] { "0" }, 0) });
            //  ((DynamicScreen)screens[2]).SetQuestionActive(1);
            ///////////////////////////////////////////////

        }



        public Screen Start()
        {
            return screens[0];
        }

        public Screen CheckKeyWord(string keyword)
        {
            Current = screens[trueCurrent].CheckKeyword(keyword);
            if (Current >= 0) trueCurrent = Current;
            else
            {
                if (keyword == "0" || keyword == "головна") { trueCurrent = 0; return screens[0]; }
                return mistake;
            }
            return screens[trueCurrent];
        }

        public void SetFavActive(int i)
        {
   //         ((DynamicScreen)screens[2]).SetQuestionActive(i);
        }

    }
}