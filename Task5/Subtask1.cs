using System;
using System.IO;
using Course;
using System.Linq;

namespace Course.Task5.Subtask1
{
    class Vector
    {
        private int[] arr;
        private readonly string pathToTempArray = @"../../../Task5/TempArray.txt";
        private readonly string pathToTempArray1 = @"../../../Task5/TempArray1.txt";

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
            if (File.Exists(filePath))
            {
                int[] array;
                char[] line;
                FileInteract.CreateFile(pathToTempArray);
                FileInteract.CreateFile(pathToTempArray1);

                using (StreamReader reader = new StreamReader(filePath))
                {
                    int elementsInFile = CountElements(reader);
                    line = new char[elementsInFile / 2];
                }

                using (StreamReader reader = new StreamReader(filePath))
                {
                    reader.Read(line, 0, line.Length);

                    string temp = new string(line);

                    temp = FileInteract.FindEndOfWord(reader, temp);

                    array = StringToIntArray(temp);

                    SplitMergeSort(array);

                    WriteToFile(pathToTempArray, array);

                    array = StringToIntArray(reader.ReadLine());

                    SplitMergeSort(array);

                    WriteToFile(pathToTempArray1, array);
                }
            }
            else throw new ArgumentException("Wrong path to file");

            MergeFromFile(filePath);
        }

        private int CountElements(StreamReader reader)
        {
            int result = 0;
            while (!reader.EndOfStream)
            {
                if ((char)reader.Peek() == '\n') break;
                reader.Read();
                result++;
            }
            return result;
        }

        private void MergeFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                StreamReader reader = new StreamReader(pathToTempArray);
                StreamReader reader1 = new StreamReader(pathToTempArray1);
                FileInteract.CreateFile(filePath);

                int elementsInFile = CountElements(reader);
                char[] charArray = new char[elementsInFile / 2];
                reader.DiscardBufferedData();
                reader.BaseStream.Seek(0, SeekOrigin.Begin);
                reader.Read(charArray, 0, charArray.Length);
                string array = new string(charArray + " ");

                array = FileInteract.FindEndOfWord(reader, array);
                reader1.Read(charArray, 0, charArray.Length);
                foreach(char i in charArray)
                    array += i;
                array = FileInteract.FindEndOfWord(reader1, array);
                WriteToFile(filePath, Merge(StringToIntArray(array)));

                array = reader.ReadLine();
                array += reader1.ReadLine();
                WriteToFile(filePath, Merge(StringToIntArray(array)));
                reader.Close();
                reader1.Close();
            }
            else throw new ArgumentException("Wrong path to file");
        }

        //private int[] GetArray(string filePath, int step)
        //{
        //    char[] line1;
        //    char[] line2;
        //    string temp = "";
        //    int i = 0, j = 0;

        //    using (StreamReader reader = new StreamReader(filePath))
        //    {
        //        int elementsInFile = CountElements(reader);
        //        line1 = new char[elementsInFile / 2];
        //        reader.ReadLine();
        //        elementsInFile = CountElements(reader);
        //        line2 = new char[elementsInFile / 2];
        //    }

        //    using (StreamReader reader = new StreamReader(filePath))
        //    {
        //        do
        //        {
        //            reader.Read(line1, 0, line1.Length);
        //        } while (i++ != step);
        //        temp = new string(line1);
        //        temp = FileInteract.FindEndOfWord(reader, temp);
        //        reader.ReadLine();
        //        do
        //        {
        //            reader.Read(line2, 0, line2.Length);
        //        } while (j++ != step);
        //        foreach (char k in line2)
        //        {
        //            temp += k;
        //        }
        //        temp = FileInteract.FindEndOfWord(reader, temp);
        //    }
        //    return StringToIntArray(temp);
        //}

        private void WriteToFile(string filePath, int[] array)
        {
            if (File.Exists(filePath))
            {
                string text = "";
                for (int i = 0; i < array.Length - 1; i++)
                {
                    text += array[i] + " ";
                }
                text += array[array.Length - 1] + " ";
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

        private int[] Merge(int[] arr)
        {
            int i = 0, j = arr.Length / 2, k = 0;
            int middle = j, right = arr.Length;
            int[] temp = new int[right];
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
                arr[m] = temp[m];

            return arr;
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
