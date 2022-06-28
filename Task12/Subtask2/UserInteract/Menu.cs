using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Task12.Subtask2
{
    class Menu
    {
        Storage storage;

        private Storage CreateStorage()
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

        public void Start()
        {
            storage = CreateStorage();
            InteractWithStorage(storage);
        }

        private void InteractWithStorage(Storage storage)
        {
            while (true)
            {
                string interacts = "1. Дoдати продукт\n" +
                    "2. Надрукувати колекцію м'ясних продуктів\n" +
                    "3. Надрукувати колекцію молочних продуктів\n" +
                    "4. Змінити ціни\n" +
                    "5. Показати усі продукти\n" +
                    "6. Видрукувати помилки\n" +
                    "7. Вирішити помилки\n" +
                    "8. Знайти продукти";
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
                    case 8:
                        FindItems();
                        break;
                    default:
                        break;
                }
                userInput = UserInterface.GetIntFromConsole("для виходу 1");
                if (userInput == 1) break;
            }
        }

        private void FindItems()
        {
            List<Product> result = new(storage.products);
            while (true)
            {
                string interacts = "1. Знайти за назвою\n" +
                    "2. Знайти за цiною\n" +
                    "3. Знайти за вагою\n" +
                    "4. Знайти за терміном придатності\n" +
                    "5. Роздрукувати результат\n" +
                    "6. Очистити критерiї\n" +
                    "7. Повернутись";
                UserInterface.WriteOnConsole(interacts);
                int userInput = UserInterface.GetIntFromConsole("дію для виконання");
                switch (userInput)
                {
                    case 1:
                        Finder.FindByName("Meat", ref result);
                        break;
                    case 2:
                        Finder.FindByPrice(UserInterface.GetFloatFromConsole("цiну для пошуку", 3), ref result);
                        break;
                    case 3:
                        Finder.FindByWeight(UserInterface.GetIntFromConsole("вагу для пошуку"), ref result);
                        break;
                    case 4:
                        Finder.FindByExpirationDate(UserInterface.GetDateTimeFromConsole("дату для пошуку"), ref result);
                        break;
                    case 5:
                        UserInterface.WriteListOnConsole(result);
                        break;
                    case 6:
                        result = new(storage.products);
                        break;
                    case 7:
                        return;
                    default:
                        break;
                }
            }
        }
    }
}
