using System;

using System.Text.Json;
using System.IO;
using ChatBot_Kursach.Exceptions;

namespace ChatBot_Kursach.WorkWithFiles
{
    static class JSONFile
    {
        public struct LikedStruct
        {
            public bool[] isliked { get; set; }
        }

        static private LikedStruct Liked;

        static public string jsonString;

        static public void LoadInfo(string filename)
        {
            try
            {
                if (!File.Exists($".\\{filename}.json")) throw new FileException(3);
                jsonString = File.ReadAllText($".\\{filename}.json");
                Liked = JsonSerializer.Deserialize<LikedStruct>(jsonString);
                Constants.Liked = Liked.isliked;
            }
            catch (FileException ex)
            {
                
            }
        }

        static public void SaveInfo(string filename)
        {
            try
            {
                Liked.isliked = Constants.Liked;
                jsonString = JsonSerializer.Serialize<LikedStruct>(Liked);
                File.WriteAllText($".\\{filename}.json", jsonString);
            }
            catch(Exception ex)
            {
                new MyException(ex);
            }
        }
    }
}
