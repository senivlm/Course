using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace Course.Task6
{//Назви класів краще, щоб були за змістом сутності
    class Subtask1
    {
        public int quarterInfo;
        public int apartmenCount;
        public DateTime[] receivingInfo;
        public List<ClientInfo>[] clientsInfo;

        #region Constructors
        public Subtask1()
        {
            quarterInfo = default;
            apartmenCount = default;
            receivingInfo = Array.Empty<DateTime>();
            clientsInfo = Array.Empty<List<ClientInfo>>();
        }

        public Subtask1(string filePath)
        {
            if (File.Exists(filePath))
            {
                clientsInfo = new List<ClientInfo>[3];
                for(int i = 0; i < clientsInfo.Length; i++)
                {
                    clientsInfo[i] = new List<ClientInfo>();
                }
                receivingInfo = new DateTime[3];
                using (StreamReader reader = new StreamReader(filePath))
                {
                    try
                    {
                        string line = reader.ReadLine();
                        string[] str = line.Split();
                        string exceptions = "";

                        while (true)
                        {
                            if (str.Length == 2)
                            {
                                if (!int.TryParse(str[0], out quarterInfo)) exceptions += "Incorect quarterInfo\n";
                                if (!int.TryParse(str[1], out apartmenCount)) exceptions += "Incorect apartmenCount\n";
                                if (exceptions.Length != 0) throw new ArgumentException(exceptions);
                                break;
                            }
                            else
                            {
                                str = UserInterface.GetSplitedStringFromConsole(2, "необхiдний квартал та кiлькiсть квартир");
                            }
                        }

                        int monthForm = (quarterInfo - 1) * 3 + 1;
                        for (int i = 0; i < 3; i++)
                        {
                            line = reader.ReadLine();
                            str = line.Split();

                            while (str.Length != 2)
                            {
                                str = UserInterface.GetSplitedStringFromConsole(2, "день та рiк подання показникiв за " +
                                    $"{CultureInfo.GetCultureInfo("ua-UA").DateTimeFormat.GetMonthName(i + monthForm)}");
                            }
                            int day = 0, year = 0;

                            if (!int.TryParse(str[1], out year))
                            {
                                do
                                {
                                    year = UserInterface.GetIntFromConsole("правильний рiк");
                                } while (year > 0);
                            }
                            if (!int.TryParse(str[0], out day))
                            {
                                do
                                {
                                    day = UserInterface.GetIntFromConsole("правильний день подання показникiв у " +
                                        $"{CultureInfo.GetCultureInfo("ua - UA").DateTimeFormat.GetMonthName(i + monthForm)} {year} року");
                                } while (day > 0 && day < DateTime.DaysInMonth(year, i + monthForm));
                            }

                            receivingInfo[i] = new DateTime(year, i + monthForm, day);

                            while (true)
                            {
                                line = reader.ReadLine();
                                if (line == "" || line == null) break;
                                clientsInfo[i].Add(new ClientInfo(line));
                            }
                            int a = 0;
                        }
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }
            }
            else throw new FileNotFoundException();
        }
        #endregion

        #region WriteToFileMethods
        public void WriteToFile(string filePath)
        {
            FileInteract.WriteToFile(filePath, this.ToString());
        }

        public void WriteToFileOneApartment(string filePath, int apartmentNumber)
        {
            string result = $"Квартал: { quarterInfo}. Кiлькiсть квартир: { apartmenCount}\n\n";
            for (int i = 0; i < receivingInfo.Length; i++)
            {
                result += String.Format("{0,-15} {1,-2} {2,-8} {3,-4}\n", "Дати подання показникiв:",
                    receivingInfo[i].Day, CultureInfo.GetCultureInfo("ua-UA").DateTimeFormat.GetMonthName(receivingInfo[i].Month), receivingInfo[i].Year);
                result += String.Format("{0,-15} {1,-20} {2,-30} {3,-30}\n", "Номер квартири", "Прiзвище власника", "Вихiднi показники лiчильника", "Вхiднi показники лiчильника");

                foreach (ClientInfo j in clientsInfo[i]) 
                    if(j.apartmenNumber == apartmentNumber) result += j + "\n";

                result += "\n";
            }

            FileInteract.WriteToFile(filePath, result);
        }
        #endregion

        #region FindMethods
        public string FindSurnameWhoUseMaxEnergy()
        {
            int maxEnergy = 0;
            int indexOfClient = 0;

            for(int i = 0; i < clientsInfo[0].Count; i++)
            {
                int temp = 0;
                for(int j = 0; j < 3; j++)
                {
                    temp += clientsInfo[j][i].GetTheNumberOfUsedEnergy();
                }
                if (temp > maxEnergy)
                {
                    indexOfClient = i;
                    maxEnergy = temp;
                }
            }

            string result = clientsInfo[0][indexOfClient].surname;

            return result;
        }

        public int FindApartmentWhereEnergyDontUse()
        {
            int indexOfClient = 0;

            for (int i = 0; i < clientsInfo[0].Count; i++)
            {
                int temp = 0;
                for (int j = 0; j < 3; j++)
                {
                    temp += clientsInfo[j][i].GetTheNumberOfUsedEnergy();
                }
                if (temp == 0)
                {
                    indexOfClient = i;
                }
            }

            return clientsInfo[0][indexOfClient].apartmenNumber;
        }

        public List<(int, int)> FindPriceOfEnergyForAllApartments(int energyPrice)
        {
            List<(int, int)> result = new List<(int, int)>();
            for (int i = 0; i < clientsInfo[0].Count; i++)
            {
                int temp = 0;
                for (int j = 0; j < 3; j++)
                {
                    temp += clientsInfo[j][i].GetTheNumberOfUsedEnergy();
                }
                result.Add((i + 1, temp * energyPrice));
            }

            return result;
        }

        public int FindNumbersOfDaysFromLastRemoval()
        {
            TimeSpan result = DateTime.Now.Subtract(receivingInfo[2]);
            return result.Days;
        }
        #endregion

        public void PrintInfo()
        {
            Console.WriteLine(FindNumbersOfDaysFromLastRemoval());
        }

        public static List<Subtask1> operator +(Subtask1 a, Subtask1 b)
        {
            List<Subtask1> result = new List<Subtask1>();
            result.Add(a);
            result.Add(b);
            return result;
        }

        public static List<Subtask1> operator -(Subtask1 a, Subtask1 b)
        {
            List<Subtask1> result = new List<Subtask1>();
            result.Add(a);
            result.Add(b);
            return result;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder($"Квартал: {quarterInfo}. Кiлькiсть квартир: {apartmenCount}\n\n");

            for(int i = 0; i < receivingInfo.Length; i++)
            {
                result.AppendFormat("{0,-15} {1,-2} {2,-8} {3,-4}\n", "Дати подання показникiв:",
                    receivingInfo[i].Day, CultureInfo.GetCultureInfo("ua-UA").DateTimeFormat.GetMonthName(receivingInfo[i].Month), receivingInfo[i].Year);
                result.AppendFormat("{0,-15} {1,-20} {2,-30} {3,-30}\n", "Номер квартири", "Прiзвище власника", "Вихiднi показники лiчильника", "Вхiднi показники лiчильника");
                foreach (ClientInfo j in clientsInfo[i]) result.Append(j + "\n");
                result.Append("\n");
            }

            return result.ToString();
        }
    }
}
