using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Course.Task14.Subtask2
{
    public static class StorageBinarySerializatorDeserializator
    {
        private const string pathToFile = "../../../Task14/Subtask2/Storage/SerializationInfo/Binary.dat";

        public static void BinarySerialization(this Storage storage, string pathToFile = pathToFile)
        {
            using (FileStream stream = new FileStream(pathToFile, FileMode.OpenOrCreate))
            {
                BinaryFormatter serializer = new BinaryFormatter();
                serializer.Serialize(stream, storage);
            }
        }

        public static Storage Deserialization(string pathToFile = pathToFile)
        {
            Storage storage = new Storage();
            using (FileStream stream = new FileStream(pathToFile, FileMode.Open))
            {
                BinaryFormatter serializer = new BinaryFormatter();
                storage = (Storage)serializer.Deserialize(stream);
            }
            return storage;
        }
    }
}
