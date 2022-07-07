using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace Course.Task13
{
    class Task13
    {
        static public void Start()
        {
            Simulation simulation = new Simulation(50, new CashRegister(0.5, 15),
                new CashRegister(0.8, 5),
                new CashRegister(0.2, 10)
                );

            simulation.StartSimulation();
        }
    }
}