using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions


namespace ChatBot_Kursach.Algorithms
{

    public class MainClass
    {
        Question[] testQuestionList;
     //   Screen current;
        Screen[] screens;
        Screen mistake;
        int Current, trueCurrent;
        bool m=false;


        bool English;
        public MainClass()
        {
            screens = new Screen[40];
            Current = trueCurrent = 0;
            ////////////////////////////////////////
            /*string img, txt;
            string[] kv;//keyword
            string vopros;
            Question[] qqq;
            for(int i = 0; i < 40; i++)
            {
                qqq = new Question[xml[i].countQuestions];
                img = xml[i].img;
                txt = xml[i].txt;
                vopros = xml[i].vopros;
                kv = new string[xml[i].countofkv];
                for(int j=0;j<xml[i].countofkv;j++) kv[j]= xml[i].stringN;

                for(int j=0;i<xml[i].countQuestions;j++)
                qqq[i] = new Question(vopros,kv,xml[i].next);
                screens[i] = new Screen(img, txt, qqq);
            }

*/

            ///////////////////////////////
            testQuestionList = new Question[4];
            testQuestionList[0] = new Question("1. дізнатися, що таке міжнародна академічна мобільність\n", new Regex("1|академічн|мобільн"), 1);
            testQuestionList[3] = new Question("4. пройти опитування, та отримати рекомендації щодо програми\n", new Regex("4|опитуван|прой|рекомендац"), 4);
            testQuestionList[2] = new Question("3. переглянути всі програми академічної мобільності\n", new Regex("3|всі|програм"), 3);
            testQuestionList[1] = new Question("2. переглянути обране\n", new Regex("2|обран"), 2);
            mistake = new Screen("robot", "Усе погано", new Question[] { new Question("0. Повернення до головного меню", new Regex("0"), 0) },false);
            screens[0] = new Screen("robot", "Привіт, я — чат-бот помічник по справам академічної мобільності. Я допоможу тобі обрати відповідну програму.\n" +
                "Спочатку, що ти хочешь введи відповідь, яка позначає те що ти хочешь.\n", testQuestionList, false);
            screens[1] = new Screen("send", "Screen 1", new Question[] { new Question ("0. Повернення до головного меню", new Regex("0"), 0) },true);
            screens[2] = new DynamicScreen("heart", "Screen 2\nСписок обраних програм:", new Question[] { new Question("0. Повернення до головного меню", new Regex("0"), 0) },false);
            screens[3] = new Screen("robot", "Screen 3", new Question[] { new Question("0. Повернення до головного меню", new Regex("0"), 0) },true);
            screens[4] = new Screen("heart", "Screen 4\nЧи володієте в англійською мовою на рівні В1 або вище", new Question[] { new Question("1.Володію ", new Regex("1|волод|так"), -2),
                new Question("2.Не володію ", new Regex("2|Не волод|ні"), -3),
             new Question("0. Повернення до головного меню", new Regex("2|ні|майже|не волод"), 0)},true);
            screens[5] = new Screen("send", "Screen 5\nЯкий у вас середній бал?", new Question[] { new Question("0. Повернення до головного меню", new Regex("0"), 0) }, true);
            //  ((DynamicScreen)screens[2]).SetQuestionActive(1);
            ///////////////////////////////////////////////

        }



        public Screen Start()
        {
            return screens[0];
        }

        public String GetText()
        {
            if (m) return screens[trueCurrent].GetText() + "\n\nПомилка розпізнавання ключового слова";
            return screens[trueCurrent].GetText();
        }
        public String ImagePath { get { return screens[trueCurrent].imagePath; } }
        public bool IsButtonVisible {  get {  return screens[trueCurrent].Buttonvisible; } }
        
        
        public Screen CheckKeyWord(string keyword)
        {

            Current = screens[trueCurrent].CheckKeyword(keyword.ToLower());
            if (Current >= 0) trueCurrent = Current;
            else
            {
                switch (Current) {
                    case -1:
                        m = true;
                        return mistake;
                        break;
                    case -2:
                        trueCurrent++;
                        English = true;
                        break;
                    case -3:
                        trueCurrent++;
                        English = false;
                        break;
                    default:break;
                }
                //  if (keyword == "0" || keyword == "головна") { trueCurrent = 0; return screens[0]; }
                /*if (Current == -1)
                {
                    m = true;
                    return mistake;
                }
                if (Current == -2)
                {
                    trueCurrent++;
                    English = true;
                }*/
                
                
            }
            m = false;
             return screens[trueCurrent];
            // Тут надо try catch
            /* Current = screens[trueCurrent].CheckKeyword(keyword);
             if(Current>=0) trueCurrent = Current;

        // else Current = trueCurrent; 
         if (trueCurrent != -1) return screens[trueCurrent];
         else if (keyword == "0" || keyword == "головна") { trueCurrent = 0; return screens[0]; }
         return mistake; // Тут надо try catch*/
        }

        public void SetFavActive()
        {
            ((DynamicScreen)screens[2]).SetQuestionActive(trueCurrent);
        }
        public bool IsButtonLiked { get { return ((DynamicScreen)screens[2]).GetQuestionActive(trueCurrent); } }

    }
}