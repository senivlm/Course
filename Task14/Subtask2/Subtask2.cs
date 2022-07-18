using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Course.Task14.Subtask2
{
    internal static class Subtask2
    {
        public static void Start()
        {
            Storage storage = new Storage();
            storage.AddProduct(new Meat("a", 14, new DateTime(2023, 05, 14), 23, Category.Prime, Sort.Veal));
            storage.AddProduct(new Meat("b", 544, new DateTime(2033, 05, 14), 23, Category.Prime, Sort.Veal));

            storage.XMLSerialization();
            storage.BinarySerialization();

            Storage storage1 = StorageBinarySerializatorDeserializator.Deserialization();
            Storage storage2 = StorageXMLSerializatorDeserializator.Deserialization();

            Console.WriteLine(storage1);
            Console.WriteLine(storage2);
        }
    }
}
