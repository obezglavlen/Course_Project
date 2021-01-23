
using System.Text.RegularExpressions;

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
