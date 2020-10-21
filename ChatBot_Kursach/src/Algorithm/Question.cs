namespace ChatBot_Kursach.Algorithms
{
    public struct Question
    {
        public string text;
        public string[] keywords;
        public int NextScreen;

        public Question(string t, string[] ans, int next)
        {
            text = t;
            keywords = ans;
            NextScreen = next;
        }

        public bool CheckKeyword(string keyword)
        {
            for (int i = 0; i < keywords.Length; i++)
            {
                if (keyword == keywords[i]) return true;
            }
            return false;
        }
    }
}