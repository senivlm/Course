using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Course.Task14.Subtask2
{
    public static class StorageXMLSerializatorDeserializator
    {
        private const string pathToFile = "../../../Task14/Subtask2/Storage/SerializationInfo/StorageInfo.xml";

        public static void XMLSerialization(this Storage storage, string pathToFile = pathToFile)
        {
            using (FileStream stream = new FileStream(pathToFile, FileMode.OpenOrCreate))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Storage));
                serializer.Serialize(stream, storage);
            }
        }

        public static Storage Deserialization(string pathToFile = pathToFile)
        {
            Storage storage = new Storage();
            using (FileStream stream = new FileStream(pathToFile, FileMode.Open))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Storage));
                storage = (Storage)serializer.Deserialize(stream);
            }
            return storage;
        }
    }
}
