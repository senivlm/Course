using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Task10
{
    class Translator
    {
        private string pathToText;
        private string pathToDictionary;
        private readonly int countVarieble = 3;
        private Dictionary<string, string> dictionary;
// Властивості пишуть з великої літери
        public string text { get; private set; }

        public Translator(string pathToText, string pathToDictionary, Dictionary<string, string> dictionary, string text)
        {
            this.pathToText = pathToText;
            this.pathToDictionary = pathToDictionary;
            this.dictionary = dictionary;
            this.text = text;
        }
// У методі розв'язуються кілька проблем. Їх слід розділяти в окремі методи
        public Translator(string pathToText, string pathToDictionary)
        {
            this.pathToText = pathToText;
            this.pathToDictionary = pathToDictionary;
            dictionary = new Dictionary<string, string>();
            text = "";

            List<string> stringList = FileInteract.ReadFromFile(pathToText);
            foreach (string line in stringList)
                AddText(line);

            stringList = FileInteract.ReadFromFile(pathToDictionary);
            foreach (string line in stringList)
            {
                try
                {
                    AddPairToDictionary(line);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public void AddText(string line)
        {
            text += line;
        }

        public void AddPairToDictionary(string line)
        {
            var splitedLine = line.Split('-', StringSplitOptions.RemoveEmptyEntries);
            if (splitedLine.Length != 2) throw new ArgumentException($"Incorrect line in dictionary. {line}");
            dictionary.Add(splitedLine[0], splitedLine[1]);
        }

        public string ChangeWords()
        {
            var spacesCounter = CountSpaces();
            StringBuilder result = new StringBuilder();
            var splitedText = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < splitedText.Length; i++)
            {
                string tempWord = "";

                try
                {
                    tempWord = ChangeWordWithPunctuation(splitedText[i]);
                    //if (char.IsPunctuation(splitedText[i][splitedText[i].Length - 1]))
                    //    tempWord = ChangeWord(splitedText[i][0..^1]) + splitedText[i][splitedText[i].Length - 1];
                    //else tempWord = ChangeWord(splitedText[i]);
                }
                catch (WordDoesntFoundExeption e)
                {
                    AddToDictionary(e.Message);
                    tempWord = ChangeWordWithPunctuation(splitedText[i]);
                    //tempWord = ChangeWord(splitedText[i]);
                    //if (punctuation != default) tempWord += punctuation;
                }
                result.Append(tempWord);

                if (i < spacesCounter.Count)
                {
                    for (int j = 0; j < spacesCounter[i]; j++)
                    {
                        result.Append(" ");
                    }
                }
            }

            return result.ToString();
        }

        private List<int> CountSpaces()
        {
            List<int> result = new List<int>();
            int counter = 0;
            foreach (char symbol in text)
            {
                if (char.IsWhiteSpace(symbol)) counter++;
                else if (counter != 0)
                {
                    result.Add(counter);
                    counter = 0;
                }
            }
            return result;
        }

        private string ChangeWordWithPunctuation(string word)
        {
            if (string.IsNullOrEmpty(word))
                return "";
            else if (char.IsLetterOrDigit(word[word.Length - 1]))
                return ChangeWord(word);

            string result = "";
            char punctuation = word[word.Length - 1];
            result = ChangeWordWithPunctuation(word[0..^1]);
            result += punctuation;

            return result;
        }
// У цій задачі краще було працювати з StringBuilder
        private string ChangeWord(string word)
        {
            string result = "";

            if (char.IsUpper(word[0]))
            {
                string tempWord = word.ToLower();
                if (!dictionary.ContainsKey(tempWord)) throw new WordDoesntFoundExeption(tempWord);
                result = char.ToUpper(dictionary[tempWord][0]) + dictionary[tempWord][1..];
            }
            else
            {
                if (!dictionary.ContainsKey(word)) throw new WordDoesntFoundExeption(word);
                result = dictionary[word];
            }

            return result;
        }

        private void AddToDictionary(string word)
        {
            string value = UserInterface.GetStringFromConsole($"замiну для слова {word}", countVarieble);
            if (string.IsNullOrEmpty(value)) value = word;
            dictionary.Add(word, value);
            FileInteract.WriteToFile(pathToDictionary, $"\n{word}-{value}");
        }
    }
}
