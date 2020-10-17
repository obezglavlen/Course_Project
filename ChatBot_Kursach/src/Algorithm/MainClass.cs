using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot_Kursach.Algorithms
{
    public class MainClass
    {
        public string[] program;



        public MainClass()
        {
            program = new string[9];

            for (int i = 0; i < 9; i++)
            {
                program[i] = (i + 1).ToString();
                // f >> programs[i];
            }
        }

        public void init()
        {
            program = new string[9];

            for (int i = 0; i < 9; i++)
            {
                program[i] = (i + 1).ToString();

            }
        }
        public string GetProgram(int b)
        {
            if (b > 0 && b < 9)
                return program[b];
            else return "Такой программы не существует";
        }
        public string GetText(string s)
        {
            switch (s)
            {
                case "1":
                    return "Вы выбрали  программу " + program[0];
                    break;
                case "2":
                    return "Вы выбрали  программу " + program[1];
                    break;
                case "3":
                    return "Вы выбрали  программу " + program[2];
                    break;
                case "4":
                    return "Вы выбрали  программу " + program[3];
                    break;
                case "5":
                    return "Вы выбрали  программу " + program[4];
                    break;
                case "6":
                    return "Вы выбрали  программу " + program[5];
                    break;

                case "7":
                    return "Вы выбрали  программу " + program[6];
                    break;
                case "8":
                    return "Вы выбрали  программу " + program[7];
                    break;

            }

            return "asd";
        }



    }
}
