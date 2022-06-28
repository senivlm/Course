using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Task12
{
    class GarbageCanHandler
    {
        private static string pathToGarbageCan = "../../../Task12/Subtask1/Storage/GarbageCan/Garbage.txt";
        public List<string> items;

        public GarbageCanHandler(List<string> items)
        {
            this.items = new List<string>(items);
        }

        public GarbageCanHandler()
        {
            items = new List<string>(GetItemsInCanFile());
        }

        public void AddProduct(string itemInfo)
        {
            UserInterface.WriteOnConsole($"Item added to Garbage Can {itemInfo}");
            FileInteract.WriteToFile(pathToGarbageCan, itemInfo + "\n");
            items.Add(itemInfo);
        }

        public void ClearCan()
        {
            items.Clear();
            FileInteract.CreateFile(pathToGarbageCan);
        }

        public void PrintItemsInCan()
        {
            UserInterface.WriteListStringOnConsole(items);
        }
        
        public List<string> GetItemsInCanFile()
        {
            List<string> result = FileInteract.ReadFromFile(pathToGarbageCan);
            return result;
        }
    }
}
