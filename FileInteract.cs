using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Course
{
    static class FileInteract
    {
        public static List<string> ReadFromFile(string filePath)
        {
            List<string> result = new List<string>();
            try
            {
                if (!File.Exists(filePath)) throw new FileNotFoundException($"File not found by {filePath}");
            }
            catch (FileNotFoundException e)
            {
                while (!File.Exists(filePath))
                {
                    Console.WriteLine(e.Message);
                    filePath = UserInterface.GetStringFromConsole("шлях до файлу");
                }
            }

            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                    result.Add(reader.ReadLine());
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

        public static void DeleteFile(string filePath)
        {
            File.Delete(filePath);
        }

        public static string FindEndOfWord(StreamReader reader)
        {
            StringBuilder result = new StringBuilder();
            result.Append((char)reader.Read());
            while (!reader.EndOfStream)
            {
                if (result[result.Length - 1] != 32)
                {
                    char temp = (char)reader.Read();
                    if (temp == '\n') break;
                    result.Append(temp);
                }
                else break;
            }
            return result.ToString();
        }

        public static string FindEndOfWord(StreamReader reader, string line)
        {
            StringBuilder result = new StringBuilder(line);
            if (line.Length == 0)
            {
                result.Append((char)reader.Read());
            }
            while (!reader.EndOfStream)
            {
                if (result[result.Length - 1] != 32)
                {
                    char temp = (char)reader.Read();
                    if (temp == '\n') break;
                    result.Append(temp);
                }
                else break;
            }
            return result.ToString();
        }
    }
}
