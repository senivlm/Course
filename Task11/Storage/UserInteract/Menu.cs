using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Task11
{
    class Menu
    {
        private static Storage CreateStorage()
        {
            Storage storage;
            string interacts = "Можливості створення складу\n" +
                "1. Додати продукти з файлу\n" +
                "2. Додати продукти у режимі діалогу\n" +
                "3. Створити пустий склад";
            UserInterface.WriteOnConsole(interacts);
            int userInput = UserInterface.GetIntFromConsole("дію для виконання");
            switch (userInput)
            {
                case 1:
                    storage = new(UserInterface.GetFilePath());
                    break;
                case 2:
                    storage = new();
                    ProductUserInterface.AddProductsToStorage(storage);
                    break;
                case 3:
                    storage = new();
                    break;
                default:
                    storage = null;
                    break;
            }

            return storage;
        }

        public static void Start()
        {
            Storage storage = CreateStorage();
            InteractWithStorage(storage);
        }

        private static void InteractWithStorage(Storage storage)
        {
            while (true)
            {
                string interacts = "1. Дoдати продукт\n" +
                    "2. Надрукувати колекцію м'ясних продуктів\n" +
                    "3. Надрукувати колекцію молочних продуктів\n" +
                    "4. Змінити ціни\n" +
                    "5. Показати усі продукти\n" +
                    "6. Видрукувати помилки\n" +
                    "7. Вирішити помилки";
                UserInterface.WriteOnConsole(interacts);
                int userInput = UserInterface.GetIntFromConsole("дію для виконання");
                switch (userInput)
                {
                    case 1:
                        ProductUserInterface.AddProductsToStorage(storage);
                        break;
                    case 2:
                        UserInterface.WriteOnConsole(storage.GetMeats().ToString());
                        break;
                    case 3:
                        UserInterface.WriteOnConsole(storage.GetDairyProducts().ToString());
                        break;
                    case 4:
                        int percent = UserInterface.GetIntFromConsole("процент на який змінити ціну");
                        storage.ChangePrice(percent);
                        break;
                    case 5:
                        UserInterface.WriteOnConsole(storage.ToString());
                        break;
                    case 6:
                        ErrorHandler.PrintErrors();
                        break;
                    case 7:
                        string date = UserInterface.GetStringFromConsole("дату після якою шукати помилки");
                        ErrorHandler.ChangeErrors(date, storage);
                        break;
                    default:
                        break;
                }
                userInput = UserInterface.GetIntFromConsole("для виходу 1");
                if (userInput == 1) break;
            }
        }
    }
}
