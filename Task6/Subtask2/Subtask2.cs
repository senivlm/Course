using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Task6
{
    class Subtask2
    {
        public static string ReadFromFile(string filePath)
        {
            StringBuilder str = new StringBuilder();
            if (!File.Exists(filePath)) throw new FileNotFoundException();
            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                    str.Append(reader.ReadLine() + "\n");
            }

            return str.ToString();
        }

        public static void PrintText(string text)
        {
            UserInterface.WriteOnConsole(text);
        }

        public static List<string> SplitTextOnSentence(string text)
        {
            List<string> result = new List<string>();
            var str = text.Split('.');
            for(int i = 0; i < str.Length; i++)
            {
                if (str[i] == "\n") continue;
                if (str[i][0] == ' ') str[i] = str[i].Remove(0, 1);
                if (str[i].Contains("\n")) str[i] = str[i].Replace('\n', ' ');
                result.Add(str[i] + ".");
            }
            return result;
        }

        public static void ChangeText(string text)
        {
            PrintText(text + "\n\n");
            List<string> b = SplitTextOnSentence(text);
            for(int i = 0; i < b.Count; i++)
            {
                UserInterface.WriteOnConsole($"{i + 1}. {b[i]} \n");
            }

            while (true)
            {
                int j = 0, k = 0;
                while (j < 1 || j > b.Count - 1)
                    j = UserInterface.GetIntFromConsole("номер стрiчки для змiни") - 1;
                while (k < 1 || k > 3)
                    k = UserInterface.GetIntFromConsole("номер операцiї. 1.Вставка 2.Замiна 3.Видалення");
                switch (k)
                {
                    case 1:
                        b[j] = b[j].Insert(b[j].IndexOf(UserInterface.GetStringFromConsole("cлово перед яким вставити(з пробілом)")),
                            UserInterface.GetStringFromConsole("слова для вставки"));
                        break;
                    case 2:
                        b[j] = b[j].Replace(UserInterface.GetStringFromConsole("cлово для замiни"),
                            UserInterface.GetStringFromConsole("cлово на яке замiняється"));
                        break;
                    case 3:
                        string temp = UserInterface.GetStringFromConsole("cлово для видалення(з пробілом)");
                        b[j] = b[j].Remove(b[j].IndexOf(temp), temp.Length);
                        break;
                    default:
                        break;
                }

                UserInterface.WriteOnConsole($"{j + 1}. {b[j]} \n");

                if (UserInterface.GetIntFromConsole("для закiнчення введiть 1") == 1) break;
            }
        }

        public static string GetLongestWord(string text)
        {
            string result = "";
            var temp = text.Split();
            foreach(string i in temp)
            {
                if (i == "-") continue;
                string str = i.Trim('.', ',', '!', '?', ':', ':', '"');
                if (str.Length > result.Length) result = str;
            }

            return result;
        }

        public static string GetShortestWord(string text)
        {
            var temp = text.Split();
            string result = temp[0];
            foreach (string i in temp)
            {
                if (i == "-") continue;
                string str = i.Trim('.', ',', '!', '?', ':', ':', '"');
                if (str.Length < result.Length) result = str;
            }

            return result;
        }

        public static void PrintTextToFileWhithSplit(string filePath, string text)
        {
            var temp = SplitTextOnSentence(text);
            string str = "";
            foreach (string i in temp)
            {
                UserInterface.WriteOnConsole("Найкоротше слово " + GetShortestWord(i) + "\n");
                UserInterface.WriteOnConsole("Найдовше слово " + GetLongestWord(i) + "\n");
                str += i + "\n";
            }
            FileInteract.WriteToFile(filePath, str);
        }
    }
}