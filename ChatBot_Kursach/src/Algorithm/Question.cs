using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatBot_Kursach.Algorithms
{

    public struct Question
    {
        public string text;
        Regex regex;
        public int NextScreen;

        public Question(string t, Regex ans, int next)
        {
            text = t;

            NextScreen = next;
            regex = ans;
        }

        public bool CheckKeyword(string keyword)
        {
            MatchCollection matches = regex.Matches(keyword);
            if (matches.Count >= 1) return true;
            return false;

        }

    }
}
