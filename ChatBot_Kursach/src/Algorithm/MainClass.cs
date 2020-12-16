using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ChatBot_Kursach.Exceptions;


namespace ChatBot_Kursach.Algorithms
{
   
    public class MainClass {


        Question[] InitQuestionList;
     //   Screen current;
        Screen[] screens;
        Screen mistake;
        int Current, trueCurrent;
        string m;
        bool o=false;

        short English;
        bool IsStudent;


        public MainClass()
        {
            screens = new Screen[40];//массив скринов. Последовательность: обязательно вторым[2] должен быть dynamic screen(это тот,
            //где список избранного), 4-6 занимает опросник. 4- вопрос студент или нет, 5- уровень английского, 
            //6 -OpScreen скрин с подобранными универами
            mistake = new Screen((int)Constants.Images.NULL, "Під час роботи програми виникла помилка, будь ласка, перезапустіть програму, у разі повторення помилки перевстановіть програму", new Question[0]);
            Current = trueCurrent = 0;
            m = "";


            WorkWithFiles.XMLFile myxml = new WorkWithFiles.XMLFile("univers");
            myxml.LoadInfo();
            WorkWithFiles.JSONFile.LoadInfo("favorites");


            InitQuestionList = new Question[4];
            InitQuestionList[0] = new Question("1. дізнатися, що таке міжнародна академічна мобільність\n", new  Regex("1|академічн|мобільн"), 1);
            InitQuestionList[1] = new Question("2. переглянути обране\n", new Regex("2|обран"), 2);
            InitQuestionList[2] = new Question("3. переглянути всі програми академічної мобільності\n", new Regex("3|всі|програм"), 3);
            InitQuestionList[3] = new Question("4. пройти опитування, та отримати рекомендації щодо програми\n", new  Regex("4|опитуван|прой|рекомендац"), 4);

            screens[0] = new Screen((int)Constants.Images.NULL, "Привіт, я — чат-бот помічник по справам академічної мобільності. Я допоможу тобі обрати відповідну програму.\n" +
                "Спочатку, що ти хочешь введи відповідь, яка позначає те що ти хочешь.\n", InitQuestionList);
            screens[1] = new Screen((int)Constants.Images.MADRID, Constants.__About, new Question[] {
                new Question ("0. Повернення до головного меню", Constants.toMainRegex, 0)
            });
            screens[2] = new DynamicScreen((int)Constants.Images.NULL, "Список обраних програм:\n", new Question[] {
                                new Question("0. Повернення до головного меню", Constants.toMainRegex, 0),
                new Question("1. Льовен", new Regex("1|льовен"), 10),
                new Question("2. Ільменау", new Regex("2|ільменау"), 11),
                new Question("3. Дортмунд", new Regex("3|дортмунд"), 12),
                new Question("4. Трансильванiя", new Regex("4|трансильванiя"), 13),
                new Question("5. Каринтій ", new Regex("5|каринтій"), 14),
                new Question("6. Мадрид", new Regex("6|мадрид"), 15),
                new Question("7. Thomas More", new Regex("7|томас|thomas|more"), 16),
                new Question("8. Артесiс ", new Regex("8|артесiс"), 17)
            });
            screens[3] = new Screen((int)Constants.Images.NULL, "Ось всi доступнi програми академiчної мобiльностi:\n", new Question[] {
                new Question("0. Повернення до головного меню", Constants.toMainRegex, 0),
                new Question("1. Льовен", new Regex("1|льовен"), 10),
                new Question("2. Ільменау", new Regex("2|ільменау"), 11),
                new Question("3. Дортмунд", new Regex("3|дортмунд"), 12),
                new Question("4. Трансильванiя", new Regex("4|трансильванiя"), 13),
                new Question("5. Каринтій ", new Regex("5|каринтій"), 14),
                new Question("6. Мадрид", new Regex("6|мадрид"), 15),
                new Question("7. Thomas More", new Regex("7|томас|thomas|more"), 16),
                new Question("8. Артесiс ", new Regex("8|артесiс"), 17)
            });
            screens[4] = new Screen((int)Constants.Images.NULL, "Ви студент чи викладач?", new Question[] {
                new Question("1.Студент ", new Regex("1|студент"), -2),
                new Question("2.Викладач ",  new Regex("2|викладач"), -3),
                new Question("0. Повернення до головного меню/ні те, ні інше", Constants.toMainRegex, 0)
            });
            screens[5] = new Screen((int)Constants.Images.NULL, "Який у вас рівень володіння англйською мовою?", new Question[] {
                new Question("1.В1", new Regex("b1|в1|1|перше"), -4),
                new Question("2.B2", new Regex("2|b2|в2|друге"), -5),
                new Question("3. С1 або вище", new Regex("3|c1|с1|третє"), -6),
                new Question("0. Повернення до головного меню/нижче за В1", Constants.toMainRegex, 0)
            });
            screens[6] = new OpScreen((int)Constants.Images.NULL, "Судячи з ваших вiдповiдей, я можу вам порекомендувати один з" +
                "цих ВНЗ:\n", new Question[] { 
                new Question("0. Повернення до головного меню", Constants.toMainRegex, 0),
                new Question("1. Льовен", new Regex("1|льовен"), 10),
                new Question("2. Ільменау", new Regex("2|ільменау"), 11),
                new Question("3. Дортмунд", new Regex("3|дортмунд"), 12),
                new Question("4. Трансильванiя", new Regex("4|трансильванiя"), 13),
                new Question("5. Каринтій ", new Regex("5|каринтій"), 14),
                new Question("6. Мадрид", new Regex("6|мадрид"), 15),
                new Question("7. Thomas More", new Regex("7|томас|thomas|more"), 16),
                new Question("8. Артесiс ", new Regex("8|артесiс"), 17)
            });

            screens[10] = new Screen((int)Constants.Images.LEUVEN, Constants.__LeuvenStr, new Question[] {
                new Question("1 - Дiзнатися бiльше", new Regex("дiзнатися|бiльше|1"), 0),
                new Question("2. Додати в обране", new Regex("додат|обран|2"), -7),
                new Question("0. Повернення до головного меню", Constants.toMainRegex, 0),

            });
            screens[11] = new Screen((int)Constants.Images.ILMENAU, Constants.__IlmenauStr, new Question[] {
                new Question("1 - Дiзнатися бiльше", new Regex("дiзнатися|бiльше|1"), 0),
                new Question("2. Додати в обране", new Regex("додат|обран|2"), -7),
                new Question("0. Повернення до головного меню", Constants.toMainRegex, 0),

            });
            screens[12] = new Screen((int)Constants.Images.DORTMUND, Constants.__DortmundStr, new Question[] {
                new Question("1 - Дiзнатися бiльше", new Regex("дiзнатися|бiльше|1"), 0),
                new Question("2. Додати в обране", new Regex("додат|обран|2"), -7),
                new Question("0. Повернення до головного меню", Constants.toMainRegex, 0),
               
            });
            screens[13] = new Screen((int)Constants.Images.TRANSILVANIA, Constants.__TransilvaniaStr, new Question[] {
                new Question("1 - Дiзнатися бiльше", new Regex("дiзнатися|бiльше|1"), 0),
                new Question("2. Додати в обране", new Regex("додат|обран|2"), -7),
                new Question("0. Повернення до головного меню", Constants.toMainRegex, 0),
               
            });
            screens[14] = new Screen((int)Constants.Images.KARINT, Constants.__KarintStr, new Question[] {
                new Question("1 - Дiзнатися бiльше", new Regex("дiзнатися|бiльше|1"), 0),
                 new Question("2. Додати в обране", new Regex("додат|обран|2"), -7),
                new Question("0. Повернення до головного меню", Constants.toMainRegex, 0),
            });
            screens[15] = new Screen((int)Constants.Images.MADRID, Constants.__MadridStr, new Question[] {
                new Question("1 - Дiзнатися бiльше", new Regex("дiзнатися|бiльше|1"), 0),
                 new Question("2. Додати в обране", new Regex("додат|обран|2"), -7),
                new Question("0. Повернення до головного меню", Constants.toMainRegex, 0),
            });
            screens[16] = new Screen((int)Constants.Images.THOMAS, Constants.__ThomasStr, new Question[] {
                new Question("1 - Дiзнатися бiльше", new Regex("дiзнатися|бiльше|1"), 0),
                 new Question("2. Додати в обране", new Regex("додат|обран|2"), -7),
                new Question("0. Повернення до головного меню", Constants.toMainRegex, 0),
            });
            screens[17] = new Screen((int)Constants.Images.ARTESIS, Constants.__ArtesisStr, new Question[] {
                new Question("1 - Дiзнатися бiльше", new Regex("дiзнатися|бiльше|1"), 0),
                 new Question("2. Додати в обране", new Regex("додат|обран|2"), -7),
                new Question("0. Повернення до головного меню", Constants.toMainRegex, 0),
               
            });


        }
        


        public String GetText()
        {
            
            if (o)
            {
                o = false;
                return screens[trueCurrent].Text + "\n\nСписок обраного оновлено";
            }
            return screens[trueCurrent].Text + m;
        }
        public int ImagePath { get { return screens[trueCurrent].imagePath; } }

        
        
        public void CheckKeyWord(string keyword)
        {

            try
            {
                // throw  new MyException(1);
            

            Current = screens[trueCurrent].CheckKeyword(keyword.ToLower());

                if (Current >= 0)
                {
                    trueCurrent = Current;
                    m = "";
                }
                else if (Current == -1) throw new MyException(1);
                else
                {
                    switch (Current)
                    {
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
                            ((OpScreen)screens[6]).Set(English, IsStudent);
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
                        case -7:
                            o = true;
                            ((DynamicScreen)screens[2]).SetQuestionActive(trueCurrent);
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

                // Тут надо try catch
                /* Current = screens[trueCurrent].CheckKeyword(keyword);
                 if(Current>=0) trueCurrent = Current;

            // else Current = trueCurrent; 
             if (trueCurrent != -1) return screens[trueCurrent];
             else if (keyword == "0" || keyword == "головна") { trueCurrent = 0; return screens[0]; }
             return mistake; // Тут надо try catch*/
            }
            catch (MyException ex)
            {
                m = "\n\n"+ ex.what;

            }
            catch (Exception ex)
            {
                new MyException(ex);

            }
        }

        

    public void ClearFav()
        {
            ((DynamicScreen)screens[2]).ClearQuestionActive();
        }
       // public bool IsButtonLiked { get { return ((DynamicScreen)screens[2]).GetQuestionActive(trueCurrent - 9); } }

    }
}