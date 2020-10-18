using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot_Kursach.Algorithms
{

    struct Question
    {
        public string text;
        public string[] answer;
        public int NextScreen;
        public bool IsActive;


        public Question(string t, string[] ans, int countOfAnswers, int next, bool act)
        {
            text = t;
            answer = new string[countOfAnswers];
            answer = ans;
            NextScreen = next;
            IsActive = act;
        }

    }
    struct Screen
    {

        public Question a;

    }
    public class MainClass
    {
        public string[] program;



        public MainClass()
        {
            program = new string[9];

            for (int i = 0; i < 9; i++)
            {
                program[i] = $"{(i + 1)}";
                // f >> programs[i];
            }
        }

        /*public void init()
        {
            program = new string[9];

            for (int i = 0; i < 9; i++)
            {
                program[i] = (i + 1).ToString();

            }
        }*/

        static public string Start()
        {
            return
                "Привіт, я — чат-бот помічник по справам академічної мобільності. Я допоможу тобі обрати відповідну програму.\n" +
                "Спочатку, що ти хочешь введи відповідь, яка позначає те що ти хочешь.\n" +
                "1 - дізнатися, що таке міжнародна академічна мобільність\n" +
                "2 - пройти опитування, та отримати рекомендації щодо програми\n" +
                "3 - переглянути всі програми академічної мобільності\n" +
                "4 - переглянути обране\n\n";
        }

        public string GetProgram(string s)
        {
            int b;
            try
            {
                b = Convert.ToInt32(s);
            }
            catch(Exception e)
            {
                return "Введите номер программы";
            }
            if (b > 0 && b < 9)
                return "Вы выбрали  программу " + program[b - 1];
            else return "Такой программы не существует";
        }
    }
}