using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


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


        short  English;
        bool IsStudent;
        
        public MainClass()
        {
            screens = new Screen[40];//массив скринов. Последовательность: обязательно вторым[2] должен быть dynamic screen(это тот,
            //где список избранного), 4-6 занимает опросник. 4- вопрос студент или нет, 5- уровень английского, 
            //6 -OpScreen скрин с подобранными универами
            
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
            testQuestionList[0] = new Question("1. дізнатися, що таке міжнародна академічна мобільність\n", new  Regex("1|академічн|мобільн"), 1);
            testQuestionList[3] = new Question("4. пройти опитування, та отримати рекомендації щодо програми\n", new  Regex("4|опитуван|прой|рекомендац"), 4);
            testQuestionList[2] = new Question("3. переглянути всі програми академічної мобільності\n", new  Regex("3|всі|програм"), 3);
            testQuestionList[1] = new Question("2. переглянути обране\n", new Regex("2|обран"), 2);
            mistake = new Screen("robot", "Усе погано", new Question[] { new Question("0. Повернення до головного меню", new Regex("0"), 0) },false);
            screens[0] = new Screen("robot", "Привіт, я — чат-бот помічник по справам академічної мобільності. Я допоможу тобі обрати відповідну програму.\n" +
                "Спочатку, що ти хочешь введи відповідь, яка позначає те що ти хочешь.\n", testQuestionList, false);
            screens[1] = new Screen("send", "Screen 1", new Question[] { new Question ("0. Повернення до головного меню", new Regex("0"), 0) },true);
            screens[2] = new DynamicScreen("heart", "Screen 2\nСписок обраних програм:", new Question[] { new Question("0. Повернення до головного меню", new Regex("0"), 0) },false);
            screens[3] = new Screen("robot", "Screen 3", new Question[] { new Question("0. Повернення до головного меню", new Regex("0"), 0) },true);
            screens[4] = new Screen("heart", "Screen 4\nВи студент чи викладач?", new Question[] { new Question("1.Студент ", new Regex("1|студент"), -2),
                new Question("2.Викладач ",  new Regex("2|викладач"), -3),
             new Question("0. Повернення до головного меню/ні те, ні інше", new Regex("2|ні|майже"), 0)},true);
            screens[5] = new Screen("send", "Screen 5\nЯкий у вас рівень володіння англйською мовою?", new Question[] { new Question("1.В1", new Regex("b1|в1|1|перше"), -4),
                new Question("2.B2", new Regex("2|b2|в2|друге"), -5),
            new Question("3. С1 або вище", new Regex("3|c1|с1|третє"), -6),
            new Question("4. Повернення до головного меню/нижче за В1", new Regex("0|4|меню|головне|нижче в1|нижче b1|четверте"), 0)}, true);
            screens[6] = new OpScreen("robot", "Screen 6", new Question[] { new Question("0. Повернення до головного меню", new Regex("0"), 0),
            new Question("1. льовен", new Regex("1|льовен"), 0),
            new Question("2. Ільмен", new Regex("2|ільмен"), 0),
            new Question("3. Дортмунд", new Regex("3|дортмунд"), 0),
            new Question("4. Брашов", new Regex("4|брашов"), 0),
            new Question("5. Каринтій ", new Regex("5|каринтій"), 0),
            new Question("6. Мадрид", new Regex("6|мадрид"), 0),
            new Question("7. Бельгія", new Regex("7|бельгія"), 0),
            new Question("8. Антверпень ", new Regex("8|антверпень"), 0)
            }, true);
            //1:льовен, 2: Ыльмен, 3: Дортмунд, 4:Брашов, 5: Каринтій, 6: Мадрид, 7:Бельгія, 8:Антверпень, 
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

                    case -2:
                        trueCurrent++;
                        IsStudent = true;
                        break;
                    case -3:
                        trueCurrent++;
                        IsStudent = false;
                        break;
                    case -4:
                        trueCurrent++;
                        English = 1;
                        ((OpScreen)screens[6]).Set(English,IsStudent);

                        break;
                    case -5:
                        trueCurrent++;
                        English = 2;
                        ((OpScreen)screens[6]).Set(English, IsStudent);
                        break;
                    case -6:
                        trueCurrent++;
                        English = 3;
                        ((OpScreen)screens[6]).Set(English, IsStudent);
                        break;

                    default: break;
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