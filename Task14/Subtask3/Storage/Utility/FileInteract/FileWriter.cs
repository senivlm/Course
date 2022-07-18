using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Task14
{
    static class FileWriter
    {
        public static void WriteToFile(string filePath, string message)
        {
            if (!File.Exists(filePath)) FileCreatorRemover.CreateFile(filePath);
            using (StreamWriter writer = File.AppendText(filePath))
            {
                writer.Write(message);
            }
        }

        public static void WriteListToFile<T>(string filePath, List<T> listOfItems)
        {
            if (!File.Exists(filePath)) FileCreatorRemover.CreateFile(filePath);
            using (StreamWriter writer = File.AppendText(filePath))
            {
                foreach(T item in listOfItems)
                {
                    writer.WriteLine(item);
                }
            }
        }
    }
}