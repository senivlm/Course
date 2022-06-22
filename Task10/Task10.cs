using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Task10
{
    class Task10
    {
        public static void start()
        {
            string pathToText = @"../../../Task10/Subtask1/Text.txt";
            string pathToDictionary = @"../../../Task10/Subtask1/Dictionary.txt";
            Translator translator = new Translator(pathToText, pathToDictionary);
            string changedText = translator.ChangeWords();
            FileInteract.WriteToFile(@"../../../Task10/Subtask1/Result.txt", changedText);

            Matrix matrix = new Matrix(4, 4, FillTypes.Diagonaly);
            matrix.FillMatrix();

            Console.WriteLine(matrix);

            foreach(int i in matrix)
            {
                Console.WriteLine(i);
            }
        }
    }
}