using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Task14.Subtask2
{
    class FileCreatorRemover
    {
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
