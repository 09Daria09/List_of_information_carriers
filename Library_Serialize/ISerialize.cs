using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Library_Storage;

namespace Library_Serialize
{
    public interface ISerialize
    {
        void Save(List<Storage> item);
        List<Storage> Load();
    }
    public class XMLSerialize : ISerialize
    {
        FileStream stream = null;
        XmlSerializer serializer = null;
        public XMLSerialize() { }

        public List<Storage> Load()
        {
            List<Storage> item = new List<Storage>();
            stream = new FileStream("Storage.xml", FileMode.Open);
            serializer = new XmlSerializer(typeof(List<Storage>));
            item = (List<Storage>)serializer.Deserialize(stream);
            string s = String.Empty;
            foreach (Storage j in item)
            {
                s += j.ToString();
            }
            Console.WriteLine(s);
            stream.Close();
            return item;
        }

        public void Save(List<Storage> item)
        {
            using (FileStream stream = new FileStream("Storage.xml", FileMode.Create))
            {
                serializer = new XmlSerializer(typeof(List<Storage>));
                serializer.Serialize(stream, item);
            }
        }
    }
    public class JSONSerialize : ISerialize
    {
        FileStream stream = null;
        DataContractJsonSerializer jsonFormatter = null;
        public JSONSerialize() { }
        public List<Storage> Load()
        {
            List<Storage> list = new List<Storage>();
            stream = new FileStream("Storage.json", FileMode.Open);
            jsonFormatter = new DataContractJsonSerializer(typeof(List<Storage>));
            list = (List<Storage>)jsonFormatter.ReadObject(stream);
            string s = String.Empty;
            foreach (Storage j in list)
            {
                s += j.ToString();
            }
            Console.WriteLine(s);
            stream.Close();
            return list;
        }

        public void Save(List<Storage> item)
        {
            using (stream = new FileStream("Storage.json", FileMode.Create))
            {
                jsonFormatter = new DataContractJsonSerializer(typeof(List<Storage>));
                jsonFormatter.WriteObject(stream, item);
            }
            stream.Close();
        }
    }
}
