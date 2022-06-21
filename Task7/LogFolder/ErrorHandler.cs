using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Task7
{
    class ErrorHandler
    {
        static private string errorLogPath = @"../../../Task7/LogFolder/ErrorLog.txt";
        static private string SolvedError = @"../../../Task7/LogFolder/SolvedError.txt";

        static public void WriteError(Exception e, string errorLine)
        {
            string message = e.Message + $"|{errorLine}; {DateTime.Now}\n";
            FileInteract.WriteToFile(errorLogPath, message);
        }

        static private void MarkSolvedErrors(string errorLine)
        {
            string message = $"{errorLine}; {DateTime.Now}\n";
            FileInteract.WriteToFile(SolvedError, message);
        }

        static public void ChangeErrors(string dateString, Storage storage)
        {
            DateTime date;
            while (true)
            {
                var str = dateString.Split();
                int day = 0, month = 0, year = 0;

                if (str.Length != 3)
                {
                    dateString = UserInterface.GetStringFromConsole("коректну дату для пошуку помилок (день, мiсяць, рiк)");
                    continue;
                }
                if (int.TryParse(str[2], out year))
                {
                    if (year < 0)
                    {
                        year = UserInterface.GetIntFromConsole("коректний рiк для пошуку помилок");
                        continue;
                    }
                }
                else
                {
                    day = UserInterface.GetIntFromConsole("коректний день для пошуку помилок");
                    continue;
                }
                if (int.TryParse(str[1], out month))
                {
                    if (month < 1 || month > 12)
                    {
                        month = UserInterface.GetIntFromConsole("коректний мiсяць для пошуку помилок");
                        continue;
                    }
                }
                else
                {
                    day = UserInterface.GetIntFromConsole("коректний день для пошуку помилок");
                    continue;
                }
                if (int.TryParse(str[0], out day))
                {
                    if (day < 1 || day > DateTime.DaysInMonth(year, month))
                    {
                        day = UserInterface.GetIntFromConsole("коректний день для пошуку помилок");
                        continue;
                    }
                }
                else
                {
                    day = UserInterface.GetIntFromConsole("коректний день для пошуку помилок");
                    continue;
                }
                date = new DateTime(year, month, day);
                break;
            }
            FindErrors(date, storage);
        }

        static private void FindErrors(DateTime date, Storage storage)
        {
            List<string> errors = new List<string>();
            string line = "";
            string[] str;
            using (StreamReader reader = new StreamReader(errorLogPath))
            {
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    str = line.Split(';');
                    DateTime temp = DateTime.Parse(str[1]);
                    if (temp > date) errors.Add(str[0]);
                }
            }
//Повернути результат пошуку, а не роздруковувати. роздрук мав би бути в іншому файлі
            for (int i = 0; i < errors.Count; i++)
            {
                UserInterface.WriteOnConsole((i + 1) + ". " + errors[i]);
            }
            int errorNumber = UserInterface.GetIntFromConsole("номер проблеми яку хoчете вирiшити") - 1;
            UserInterface.WriteOnConsole(errors[errorNumber]);
            for (int i = 4; i > 0; i--)
            {
                switch (UserInterface.GetStringFromConsole("тип продукту"))
                {
                    case "Meat":
                        storage.AddProduct(ProductUserInterface.CreateMeat());
                        MarkSolvedErrors(errors[errorNumber]);
                        i = -1;
                        break;
                    case "DairyProduct":
                        storage.AddProduct(ProductUserInterface.CreateDairyProducts());
                        MarkSolvedErrors(errors[errorNumber]);
                        i = -1;
                        break;
                    default:
                        UserInterface.WriteOnConsole($"Продукту не iснує. Залишилось спроб {i - 1}");
                        break;
                }
            }
        }
    }
}
