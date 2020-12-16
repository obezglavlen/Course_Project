using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

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
            jsonString = File.ReadAllText($"..\\..\\src\\{filename}.json");
            Liked = JsonSerializer.Deserialize<LikedStruct>(jsonString);
            Constants.Liked = Liked.isliked;
        }

        static public void SaveInfo(string filename)
        {
            Liked.isliked = Constants.Liked;
            jsonString = JsonSerializer.Serialize<LikedStruct>(Liked);
            File.WriteAllText($"..\\..\\src\\{filename}.json", jsonString);
        }
    }
}
