using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Task13
{
    static class FileWriter
    {
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
    }
}
