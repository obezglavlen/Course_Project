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

            for (int i = 0; i < count; i++)
            {
                if (keyword == keywords[i]) return true;
            }

            return false;
        }

    }
}
