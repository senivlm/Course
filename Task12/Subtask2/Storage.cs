using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Course.Task12.Subtask2
{
    class Storage
    {
        public List<Product> products { get; }

        #region Constructors
        public Storage()
        {
            products = new List<Product>();
        }

        public Storage(string filePath)
        {
            products = new List<Product>();
        Start:
            try
            {
                if (File.Exists(filePath))
                {
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        while (!reader.EndOfStream)
                        {
                            string line = reader.ReadLine();
                            try
                            {
                                var splitedLine = line.Split();
                                string exeptions = "";

                                //To upper case first letter
                                if (splitedLine[0][0] != char.ToUpper(splitedLine[0][0])) splitedLine[0] = char.ToUpper(splitedLine[0][0]) + splitedLine[0].Substring(1);

                                switch (splitedLine[0])
                                {
                                    case "Meat":
                                        //Create product or throw exception if one of arguments incorect
                                        products.Add(new Meat(line[5..]));
                                        break;
                                    case "DairyProduct":
                                        products.Add(new DairyProducts(line[13..]));
                                        break;
                                    default:
                                        exeptions += "Incorect product type, ";
                                        throw new ArgumentException(exeptions);
                                }
                            }
                            catch (IndexOutOfRangeException e) //Write exeptions to ErrorLog
                            {
                                ErrorHandler.WriteError(e, line);
                            }
                            catch (ArgumentException e)
                            {
                                ErrorHandler.WriteError(e, line);
                            }
                        }
                    }
                }
                else throw new FileNotFoundException();
            }
            catch (FileNotFoundException)
            {
                for (int i = 0; i < 3; i++)
                {
                    switch (UserInterface.GetIntFromConsole("якщо файл у даному репозиторiї 1, якщо нi 2"))
                    {
                        case 1:
                            filePath = "../../../" + UserInterface.GetStringFromConsole("назву файлу");
                            if (File.Exists(filePath))
                            {
                                goto Start;
                            }
                            else
                            {
                                UserInterface.WriteOnConsole("Файлу не iснує");
                                break;
                            }
                        case 2:
                            filePath = UserInterface.GetStringFromConsole("повний шлях до файлу");
                            if (File.Exists(filePath))
                            {
                                goto Start;
                            }
                            else
                            {
                                UserInterface.WriteOnConsole("Файлу не iснує");
                                break;
                            }
                        default:
                            break;
                    }
                }
            }
        }
        #endregion

        public void AddInDialog()
        {
            ProductUserInterface.AddProductsToStorage(this);
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public void ChangePrice(int percent)
        {
            foreach (Product i in products)
            {
                i.ChangePrice(percent);
            }
        }

        public Product this[int index]
        {
            get
            {
                if (index >= 0 && index < products.Count)
                {
                    return products[index];
                }
                throw new ArgumentOutOfRangeException();
            }

            set
            {
                if (index >= 0 && index < products.Count)
                {
                    products[index] = value;
                }
                throw new ArgumentOutOfRangeException();
            }
        }

        public List<Meat> GetMeats()
        {
            List<Meat> result = new List<Meat>();
            foreach (Product i in products)
            {
                if (i.GetType() == typeof(Meat)) result.Add((Meat)i);
            }
            return result;
        }

        public List<DairyProducts> GetDairyProducts()
        {
            List<DairyProducts> result = new List<DairyProducts>();
            foreach (Product i in products)
            {
                if (i.GetType() == typeof(DairyProducts)) result.Add((DairyProducts)i);
            }
            return result;
        }

        public override string ToString()
        {
            string result = "";
            foreach (Product i in products)
            {
                result += i + "\n";
            }
            return result;
        }
    }
}
