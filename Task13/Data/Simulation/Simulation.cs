using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Course.Task13
{
    class Simulation
    {
        private readonly int timeForGenerationPerson = 2;
        private int limitReachedCounter = 0;
        private bool stopGeneratePersons = false;

        private CashRegistersManager cashRegistersManager;
        private Service service;
        private PersonGenerator personGenerator;
        private int numberOfPersons;

        public Simulation(int numberOfPersons, params CashRegister[] cashRegisters)
        {
            cashRegistersManager = new(10, cashRegisters);
            cashRegistersManager.limitReachedAction = ReactionOnLimitReached;
            service = new();
            personGenerator = new();
            this.numberOfPersons = numberOfPersons;
        }

        public void StartSimulation()
        {
            personGenerator.GenerateAndWritePersonsToFile(numberOfPersons);
            Thread secondThread = new Thread(SimulationProcess);
            secondThread.Start();
            while (true)
            {
                int userInput = UserInterface.GetIntFromConsole("для зупинки 1, для закриття черги 2, для виходу 3");
                if(userInput == 3)
                {
                    secondThread.Interrupt();
                    break;
                }
                switch (userInput)
                {
                    case 1:
                        secondThread.Interrupt();
                        break;
                    case 2:
                        int temp = UserInterface.GetIntFromConsole("яку касу закрити");
                        cashRegistersManager.CashRegisters.Values.ToArray()[temp - 1].isClosed = true;
                        while (cashRegistersManager.CashRegisters.Values.ToArray()[temp - 1].Count > 0)
                        {
                            EnqueuePerson(cashRegistersManager.CashRegisters.Values.ToArray()[temp - 1].Dequeue());
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private void ReactionOnLimitReached(CashRegister cashRegister)
        {
            cashRegister.isClosed = true;
            cashRegister.isClosedByLimite = true;
            limitReachedCounter++;
            if (limitReachedCounter == 2)
            {
                stopGeneratePersons = true;
                limitReachedCounter = 0;
            }
            int userInput = UserInterface.GetIntFromConsole("на яку касу переробити касу, якщо не змінювати 3, Pensioner - 2, Invalid - 1");
            cashRegister.StatuseSpecialization = (Statuses)Enum.GetValues(typeof(Statuses)).GetValue(userInput - 1);
            cashRegistersManager.ResortPersons();
        }

        private void EnqueuePerson(Person person)
        {
            var cashRegister = cashRegistersManager.GetCashRegisterBySpecialization(person.Status);
            if (cashRegister == null) cashRegister = cashRegistersManager.GetCashRegisterWhithLowestQueue();
            if (cashRegister == null) cashRegistersManager.GetClosestCashResister(person.Coordinate).Enqueue(person);
            else cashRegister.Enqueue(person);
        }

        private void SimulationProcess()
        {
            int time = 0;
            int counter = 0;
            while (true)
            {
                try
                {
                    if (!stopGeneratePersons)
                    {
                        time++;
                        if (time % timeForGenerationPerson == 0 && counter < numberOfPersons)
                        {
                            EnqueuePerson(personGenerator.GetPersonFromFile(counter++));
                        }
                    }
                    else
                    {
                        int personsCount = 0;
                        foreach (var cashRegister in cashRegistersManager.CashRegisters.Values)
                        {
                            personsCount += cashRegister.Count;
                        }
                        if (personsCount < cashRegistersManager.Limit) stopGeneratePersons = false;
                    }
                    service.TryServe(cashRegistersManager.CashRegisters.Values);
                }
                catch (ThreadInterruptedException) { }
            }
        }
    }
}
