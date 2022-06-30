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

        public string Text { get; private set; }

        public Translator(string pathToText, string pathToDictionary, Dictionary<string, string> dictionary, string text)
        {
            this.pathToText = pathToText;
            this.pathToDictionary = pathToDictionary;
            this.dictionary = dictionary;
            this.Text = text;
        }

        public Translator(string pathToText, string pathToDictionary)
        {
            this.pathToText = pathToText;
            this.pathToDictionary = pathToDictionary;
            dictionary = new Dictionary<string, string>();
            Text = "";

            AddToTextFromFile(pathToText);
            AddToDictionaryFromFile(pathToDictionary);
        }

        public void AddToTextFromFile(string pathToText)
        {
            List<string> stringList = FileInteract.ReadFromFile(pathToText);
            foreach (string line in stringList)
                AddText(line);
        }

        public void AddToDictionaryFromFile(string pathToDictionary)
        {
            List<string> stringList = FileInteract.ReadFromFile(pathToText);
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
            Text += line;
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
            var splitedText = Text.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < splitedText.Length; i++)
            {
                string tempWord = "";

                try
                {
                    tempWord = ChangeWordWithPunctuation(splitedText[i]);
                }
                catch (WordDoesntFoundExeption e)
                {
                    AddToDictionary(e.Message);
                    tempWord = ChangeWordWithPunctuation(splitedText[i]);
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
            foreach (char symbol in Text)
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

            StringBuilder result = new();
            char punctuation = word[word.Length - 1];
            result.Append(ChangeWordWithPunctuation(word[0..^1]));
            result.Append(punctuation);

            return result.ToString();
        }

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