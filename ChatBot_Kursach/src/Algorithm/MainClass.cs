using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot_Kursach.Algorithms
{

    public struct Question
    {
        public string text;
        public string[] keywords;
        public int count;
        public int NextScreen;



        public Question(string t, string[] ans, int countOfAnswers, int next)
        {
            text = t;
            keywords = new string[countOfAnswers];
            count = countOfAnswers;
            keywords = ans;
            NextScreen = next;

        }
        public bool CheckKeyword(string keyword)
        {

                for(int i=0;i<count; i++)
                {
                    if (keyword == keywords[i]) return true;
                }

            return false;
        }

    }

    //screeeen
    public class Screen
    {
        protected string ImagePath;
        protected string MainText;
        protected string TextToReturn;
        protected Question []question;
        protected int count;
        protected bool IsAllActive;

        public Screen(string imgPath, string mainText, int countOfQuestions, Question []Questions, bool AllActive )
        {
            ImagePath = imgPath;
            MainText = mainText;
            count = countOfQuestions;
            question = new Question[countOfQuestions];

            question = Questions;
            IsAllActive = AllActive;
        }

        public Screen() { }

        public int CheckKeyword(string keyword)
        {

            for(int i = 0; i < count; i++)
            {
                if(question[i].CheckKeyword(keyword))
                {
                    return question[i].NextScreen;
                }
            }
            return -1;

        }
        public virtual string GetText()
        {
            TextToReturn = MainText+"\n";
            for (int i = 0; i < count; i++) TextToReturn += "\n" + question[i].text;
            return TextToReturn;
        }

    }
    public class UnivScreen: Screen
    {

    }

    public class DynamicScreen : Screen
   {
        protected bool[] IsQuestionActive;
        
        public DynamicScreen(string imgPath, string mainText, int countOfQuestions, Question[] Questions, bool AllActive) : base ()
        {
            ImagePath = imgPath;
            MainText = mainText;
            count = countOfQuestions;
            IsQuestionActive = new bool[countOfQuestions];
            question = new Question[countOfQuestions];
            question = Questions;
            IsAllActive = AllActive;
        }

        public DynamicScreen() : base()
        {

        }

        public void SetQuestionActive(bool b)
        {


        }
        public override string GetText() 
        {
            TextToReturn = MainText + "\n";
            
            for (int i = 0; i < count; i++) if (IsQuestionActive[i]) TextToReturn += "\n" + question[i].text;
            return TextToReturn;
        }

    }
    public class MainClass
    {
        public string[] program;

        Question []q;
        Question s;
        string []ans;
        Screen current;
        Screen[] screens;
        Screen mistake;
        int Current;

        public MainClass()
        {
            screens = new Screen[40];

            ans = new string[2];
            ans[0] = "1";
            ans[1] = "2";
            program = new string[9];
            s = new Question("ASD", ans, 2, 1);
            q = new Question[2];
            q[0]= s;
            q[1] = s;
            screens[2] = new DynamicScreen("txt.txt", "DynamicScreen", 2, q, true);
            current = new Screen("txt.txt", "Maintext", 2, q, true);
               mistake = new Screen("txt.txt", "Mistake", 2, q, true);


            
        }

        public Screen CheckKeyWord(string keyword)
        {
            Current = current.CheckKeyword(keyword);

            if (Current != -1) return screens[Current];
            return screens[2];
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

        /*public string GetProgram(string s)
        {
            int b;
            try
            {
                b = Convert.ToInt32(s);
            }
            catch(Exception e)
            {
                return Start()+ "\n\nОшибка ввода";
            }
            if (b > 0 && b < 9)
                return "Вы выбрали  программу " + program[b - 1];
            else if (b == 0) return Start();
            else return Start() +"\n\nТакой программы не существует\n";
        }*/
    }
}