using System;
using System.IO;

namespace Course.Task5.Subtask1
{
    class Vector
    {
        private int[] arr;

        public Vector()
        {
            arr = Array.Empty<int>();
        }

        public Vector(int lenght)
        {
            arr = new int[lenght];
        }

        public void SortFromFile(string filePath)
        {
            string pathToTempArray = @"D:\Course\Task5\TempArray.txt";

            if (File.Exists(filePath))
            {
                int[] array;
                char[] line;
                CreateTempFile(pathToTempArray);
                using (StreamReader reader = new StreamReader(filePath))
                {
                    line = new char[reader.ReadLine().Length / 2];
                }

                using (StreamReader reader = new StreamReader(filePath))
                {
                    reader.Read(line, 0, line.Length);

                    string temp = new string(line);

                    FindEnd(reader, ref temp);

                    array = StringToIntArray(temp);

                    SplitMergeSort(array);

                    WriteToFile(pathToTempArray, array, true);

                    array = StringToIntArray(reader.ReadLine());

                    SplitMergeSort(array);

                    WriteToFile(pathToTempArray, array, true);
                }
            }
            else throw new ArgumentException("Wrong path to file");

            MergeFromFile(pathToTempArray);
        }

        private void MergeFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                int[] array;
                char[] line1;
                char[] line2;
                string pathToMainFile = @"../../../Task5/Array.txt";

                using (StreamReader reader = new StreamReader(filePath))
                {
                    line1 = new char[reader.ReadLine().Length / 2];
                    line2 = new char[reader.ReadLine().Length / 2];
                }

                using (StreamReader reader = new StreamReader(filePath))
                {
                    reader.Read(line1, 0, line1.Length);
                    string temp = new string(line1);
                    FindEnd(reader, ref temp);

                    reader.ReadLine();
                    reader.Read(line2, 0, line2.Length);

                    
                    foreach (char i in line2)
                    {
                        temp += i;
                    }
                    FindEnd(reader, ref temp);

                    array = StringToIntArray(temp);

                    SplitMergeSort(array);
                    CreateTempFile(pathToMainFile);
                    WriteToFile(pathToMainFile, array, false);
                }

                using (StreamReader reader = new StreamReader(filePath))
                {
                    reader.Read(line1, 0, line1.Length);
                    FindEnd(reader, new string(line1));
                    string temp = reader.ReadLine();
                    temp += " ";

                    reader.Read(line2, 0, line2.Length);
                    FindEnd(reader, new string(line2));
                    temp += reader.ReadLine();

                    array = StringToIntArray(temp);

                    Merge(array, 0, array.Length / 2, array.Length);
                    WriteToFile(pathToMainFile, array, false);
                }

                DeleteTempFile(filePath);
            }
            else throw new ArgumentException("Wrong path to file");
        }

        private void FindEnd(StreamReader reader, ref string line)
        {
            while (true)
            {
                if (line[line.Length - 1] != 32)
                {
                    line += (char)reader.Read();
                }
                else break;
            }
        }

        private void FindEnd(StreamReader reader, string line)
        {
            while (true)
            {
                if (line[line.Length - 1] != 32)
                {
                    line += (char)reader.Read();
                }
                else break;
            }
        }

        private void CreateTempFile(string filePath)
        {
            using (FileStream fs = File.Create(filePath)) { }
        }

        private void DeleteTempFile(string filePath)
        {
            File.Delete(filePath);
        }

        private void WriteToFile(string filePath, int[] array, bool isNewString)
        {
            if (File.Exists(filePath))
            {
                string text = "";
                for(int i = 0; i < array.Length - 1; i++)
                {
                    text += array[i] + " ";
                }
                text += array[array.Length - 1];
                if (isNewString) text += "\n";
                else text += " ";
                using (StreamWriter writer = File.AppendText(filePath))
                {
                    writer.Write(text);
                }
            }
        }

        private void Merge(int[] arr, int left, int middle, int right)
        {
            int i = left, j = middle, k = 0;
            int[] temp = new int[right - left];
            while (i < middle && j < right)
            {
                if (arr[i] < arr[j])
                    temp[k++] = arr[i++];
                else
                    temp[k++] = arr[j++];
            }

            if (i == middle)
                for (; j < right; j++)
                    temp[k++] = arr[j];
            else
                while (i < middle)
                    temp[k++] = arr[i++];

            for (int m = 0; m < temp.Length; m++)
                arr[m + left] = temp[m];
        }

        private void Split(int[] arr, int firstIndex, int lastIndex)
        {
            if (lastIndex - firstIndex <= 1) return;

            int middle = (firstIndex + lastIndex) / 2;
            Split(arr, firstIndex, middle);
            Split(arr, middle, lastIndex);
            Merge(arr, firstIndex, middle, lastIndex);
        }

        public void SplitMergeSort(int[] arr)
        {
            Split(arr, 0, arr.Length);
        }

        private int[] StringToIntArray(string line)
        {
            int count = 0;
            string[] k = line.Split(' ');
            int[] arr = new int[k.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                if (k[i] == "") continue;
                if (!int.TryParse(k[i], out arr[i])) throw new Exception("File contains characters other than numbers");
                count++;
            }

            int[] result = new int[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = arr[i];
            }

            return result;
        }

        public override string ToString()
        {
            string arrLine = "";
            foreach (int a in arr)
            {
                arrLine += a + " ";
            }
            return arrLine;
        }
    }
}
