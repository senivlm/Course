using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Task14.Subtask2
{
    static class FileReader
    {
        public static List<string> ReadFromFile(string filePath)
        {
            List<string> result = new List<string>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                    result.Add(reader.ReadLine());
            }

            return result;
        }

        public static string ReadLine(string filePath)
        {
            string result = "";
            using (StreamReader reader = new StreamReader(filePath))
            {
                result = reader.ReadLine();
            }

            return result;
        }

        public static string GetLineByCounter(string filePath, int counter)
        {
            string result;
            using (StreamReader reader = new StreamReader(filePath))
            {
                for (int i = 0; i < counter; i++)
                    reader.ReadLine();
                result = reader.ReadLine();
            }

            return result;
        }
    }
}
