using System;
using System.IO;

namespace Course
{
    class FileInteract
    {
        public static string ReadFromFile(string filePath)
        {
            string result = "";
            using (StreamReader reader = new StreamReader(filePath))
            {
                result += reader.ReadLine() + "\n";
            }
            return result; 
        }

        public static void WriteToFile(string filePath, string str)
        {
            if (!File.Exists(filePath)) CreateFile(filePath);
            using (StreamWriter writer = File.AppendText(filePath))
            {
                writer.Write(str);
            }
        }

        public static void CreateFile(string filePath)
        {
            using (FileStream fs = File.Create(filePath)) { }
        }
    }
}
