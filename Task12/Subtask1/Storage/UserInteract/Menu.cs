using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Task12
{
    class Menu
    {
        public GarbageCanHandler garbageCan;
        public Storage storage;

        private Storage CreateStorage()
        {
            Storage storage;
            string interacts = "Можливостi створення складу\n" +
                "1. Додати продукти з файлу\n" +
                "2. Додати продукти у режимi дiалогу\n" +
                "3. Створити пустий склад";
            UserInterface.WriteOnConsole(interacts);
            int userInput = UserInterface.GetIntFromConsole("дiю для виконання");
            switch (userInput)
            {
                case 1:
                    storage = new();
                    storage.OutOfExpirationTimeEvent += garbageCan.AddProduct;
                    storage.AddFromFile(UserInterface.GetFilePath());
                    break;
                case 2:
                    storage = new();
                    storage.OutOfExpirationTimeEvent += garbageCan.AddProduct;
                    ProductUserInterface.AddProductsToStorage(storage);
                    break;
                case 3:
                    storage = new();
                    storage.OutOfExpirationTimeEvent += garbageCan.AddProduct;
                    break;
                default:
                    storage = null;
                    break;
            }

            return storage;
        }

        public Menu()
        {
            garbageCan = new();
            storage = CreateStorage();
            InteractWithStorage(storage);
        }

        public void InteractWithStorage(Storage storage)
        {
            while (true)
            {
                string interacts = "1. Дoдати продукт\n" +
                    "2. Надрукувати колекцiю м'ясних продуктiв\n" +
                    "3. Надрукувати колекцiю молочних продуктiв\n" +
                    "4. Змiнити цiни\n" +
                    "5. Показати усi продукти\n" +
                    "6. Видрукувати помилки\n" +
                    "7. Вирiшити помилки";
                UserInterface.WriteOnConsole(interacts);
                int userInput = UserInterface.GetIntFromConsole("дiю для виконання");
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
                        int percent = UserInterface.GetIntFromConsole("процент на який змiнити цiну");
                        storage.ChangePrice(percent);
                        break;
                    case 5:
                        UserInterface.WriteOnConsole(storage.ToString());
                        break;
                    case 6:
                        ErrorHandler.PrintErrors();
                        break;
                    case 7:
                        string date = UserInterface.GetStringFromConsole("дату пiсля якою шукати помилки");
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
