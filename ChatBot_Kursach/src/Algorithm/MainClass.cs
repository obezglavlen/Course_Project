using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot_Kursach.Algorithms
{

    public class MainClass
    {

        Question []q;
        Question s;
        Question[] ch;
        string []ans;
        string[] ans2;
        string[] ans3;
        string[] ans4;
        Screen current;
        Screen[] screens;
        Screen mistake;
        int Current;
        Screen ds;
        public MainClass()
        {
            screens = new Screen[40];
            Current = 0;
            ans = new string[2];
            ans[0] = "1";
            ans[1] = "2";
            s = new Question("ASD", ans, 2, 1);
            q = new Question[2];
            q[0] = s;
            q[1] = s;
            ch = new Question[4];
            ans = new string[1];
            ans2 = new string[1];
            ans3 = new string[1];
            ans4 = new string[1];
            ans[0] = "1";
            ch[0] = new Question("1. дізнатися, що таке міжнародна академічна мобільність\n", ans, 1, 1);
            ans2[0] = "2";
            ch[1] = new Question("2. пройти опитування, та отримати рекомендації щодо програми\n", ans2, 1, 2);
            ans3[0] = "3";
            ch[2] = new Question("3. переглянути всі програми академічної мобільності\n", ans3, 1, 3);
            ans4[0] = "4";
            ch[3] = new Question("4. переглянути обране\n", ans4, 1, 4);
            //public Question(string t, string[] ans, int countOfAnswers, int next)
            current = new Screen("txt.txt", "Maintext", 2, q, true);
               mistake = new Screen("txt.txt", "Mistake", 2, q, true);
            screens[0] = new Screen("robot", "Привіт, я — чат-бот помічник по справам академічної мобільності. Я допоможу тобі обрати відповідну програму.\n" +
                "Спочатку, що ти хочешь введи відповідь, яка позначає те що ти хочешь.\n", 4, ch, true);
            //public Screen(string imgPath, string mainText, int countOfQuestions, Question []Questions, bool AllActive )
            screens[1] = new DynamicScreen("send", "Screen 1", 2, q, true);
            screens[2] = new DynamicScreen("heart", "Screen 2", 2, q, true);
            screens[3] = new DynamicScreen("robot", "Screen 3", 2, q, true);
            screens[4] = new DynamicScreen("heart", "Screen 4", 2, q, true);
            //  ((DynamicScreen)screens[2]).SetQuestionActive(1);

        }



        public Screen Start()
        {
            return screens[0];
        }

        public Screen CheckKeyWord(string keyword)
        {
            //Current = screens[Current].CheckKeyword(keyword);
            Current = screens[0].CheckKeyword(keyword);
            //не забыть поменять screens[0] на screens[Current]
            if (Current != -1) return screens[Current];
            return mistake;
        }

        public void SetFavActive(int i)
        {
   //         ((DynamicScreen)screens[2]).SetQuestionActive(i);
        }

    }
}