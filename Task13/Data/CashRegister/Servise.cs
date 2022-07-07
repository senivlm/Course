using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Course.Task13
{
    class Service
    {
        public void TryServe(IEnumerable<CashRegister> cashRegisters)
        {
            string result = "";
            foreach (var cashRegister in cashRegisters)
            {
                if (!cashRegister.IsEmpty())
                {
                    if (--cashRegister.Peek().TimeServise <= 0)
                    {
                        result += $"{cashRegister.Dequeue()} обслужений касою за наступними координатами {cashRegister.Coord}\nЧерга: {cashRegister.ToString()}\n";
                    }
                }
            }
            if (result.Length != 0) FileWriter.WriteToFile("../../../Task13/Files/Result.txt", result);
            Thread.Sleep(1000);
        }
    }
}
