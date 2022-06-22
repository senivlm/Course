using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Course.Task7
{
    class Storage
    {
        private List<Product> products;

        public Storage()
        {
            products = new List<Product>();
        }

        public Storage(params Product[] products)
        {
            this.products = new List<Product>();
            this.products.AddRange(products ?? null);
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
                                int weight;
                                int price;

                                //To upper case first letter
                                if (splitedLine[0][0] != char.ToUpper(splitedLine[0][0])) splitedLine[0] = char.ToUpper(splitedLine[0][0]) + splitedLine[0].Substring(1);
                                if (splitedLine[1][0] != char.ToUpper(splitedLine[1][0])) splitedLine[1] = char.ToUpper(splitedLine[1][0]) + splitedLine[1].Substring(1);

                                if (!int.TryParse(splitedLine[2], out price)) exeptions += "Incorect price, ";
                                if (!int.TryParse(splitedLine[3], out weight)) exeptions += "Incorect weight, ";

                                switch (splitedLine[0])
                                {
                                    case "Meat":
                                        Category category = default;
                                        Sort sort = default;

                                        //To upper case first letter
                                        if (splitedLine[4][0] != char.ToUpper(splitedLine[4][0])) splitedLine[4] = char.ToUpper(splitedLine[4][0]) + splitedLine[4].Substring(1);
                                        if (splitedLine[5][0] != char.ToUpper(splitedLine[5][0])) splitedLine[5] = char.ToUpper(splitedLine[5][0]) + splitedLine[5].Substring(1);

                                        //String to enum
                                        if (!Enum.IsDefined(typeof(Category), splitedLine[4])) exeptions += "Incorect category, ";
                                        else category = (Category)Enum.Parse(typeof(Category), splitedLine[4]);
                                        if (!Enum.IsDefined(typeof(Sort), splitedLine[5])) exeptions += "Incorect sort, ";
                                        else sort = (Sort)Enum.Parse(typeof(Sort), splitedLine[5]);

                                        //Create product or throw exception if one of arguments incorect
                                        if (exeptions.Length != 0) throw new ArgumentException(exeptions);
                                        else
                                        {
                                            products.Add(new Meat(splitedLine[1], price, weight, category, sort));
                                            break;
                                        }
                                    case "DairyProduct":
                                        int expirationDate = 0;
                                        if (!int.TryParse(splitedLine[4], out expirationDate)) exeptions += "Incorect expirationDate, ";
                                        if (exeptions.Length != 0) throw new ArgumentException(exeptions);
                                        else
                                        {
                                            products.Add(new DairyProducts(splitedLine[1], price, weight, expirationDate));
                                            break;
                                        }
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
