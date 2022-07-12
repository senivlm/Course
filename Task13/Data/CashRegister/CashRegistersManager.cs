using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Task13
{
    class CashRegistersManager
    {
        public Action<CashRegister> limitReachedAction; 

        private int limit;
        private Dictionary<double, CashRegister> cashRegisters;

        public int Limit { get => limit; }
        public Dictionary<double, CashRegister> CashRegisters { get => cashRegisters; }

        public CashRegistersManager(Dictionary<double, CashRegister> cashRegisters, int limit)
        {
            this.cashRegisters = new(cashRegisters);
            this.limit = limit;
        }

        public CashRegistersManager(int limit, params CashRegister[] cashRegisters)
        {
            this.limit = limit;
            this.cashRegisters = new();
            foreach (CashRegister cashRegister in cashRegisters)
                CashRegisters.Add(cashRegister.Coord, cashRegister);
        }

        public void ResortPersons()
        {
            foreach (var cashRegister in cashRegisters.Values)
            {
                while(cashRegister.Count > 0)
                {
                    if (cashRegister.Peek().Status == Statuses.Normal) break;
                    else
                    {
                        GetCashRegisterBySpecialization(cashRegister.Peek().Status).Enqueue(cashRegister.Dequeue());
                    }
                }
            }
        }

        public CashRegister GetCashRegisterBySpecialization(Statuses statuse)
        {
            if (statuse == Statuses.Normal) return null;
            foreach (var cashRegister in cashRegisters.Values)
            {
                if (statuse == cashRegister.StatuseSpecialization) return cashRegister;
            }
            return null;
        }

        public CashRegister GetCashRegisterWhithLowestQueue()
        {// Чарівні константи!
            int numberOfPersons = 200;
            bool isSimilarsQueuens = true;
            double key = 0;
            foreach (var cashRegister in cashRegisters.Values)
            {
                if (cashRegister.isClosed)
                {// Чарівні константи!
                    if (cashRegister.isClosedByLimite && cashRegister.Count <= limit / 2)
                    {
                        cashRegister.isClosed = false;
                        cashRegister.isClosedByLimite = false;
                    }
                }
                else if (cashRegister.Count >= limit)
                {
                    limitReachedAction?.Invoke(cashRegister);
                }
                else if (cashRegister.Count < numberOfPersons)
                {
                    numberOfPersons = cashRegister.Count;
                    key = cashRegister.Coord;
                }
                else if (cashRegister.Count != numberOfPersons) { isSimilarsQueuens = false; }
            }

            if (!isSimilarsQueuens) return CashRegisters[key];
            else return null;
        }

        public CashRegister GetClosestCashResister(double coord)
        {// Чарівні константи!
            double closestResult = 500;
            double key = 0;
            foreach (double coordOfCR in cashRegisters.Keys)
            {
                if (cashRegisters[coordOfCR].isClosed) { }
                else if (Math.Abs(coordOfCR - coord) < closestResult)
                {
                    closestResult = Math.Abs(coordOfCR - coord);
                    key = coordOfCR;
                }
            }

            return cashRegisters[key];
        }
    }
}
