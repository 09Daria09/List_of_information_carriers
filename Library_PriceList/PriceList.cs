using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library_Storage;
using Library_Print;
using System.Runtime.Serialization;
using Library_Serialize;

namespace Library_PriceList
{
    public class PriceList
    {
        public List<Storage> list = new List<Storage>();
        public bool Add(Storage item)
        {
            list.Add(item);
            return true;
        }
        public bool Remove(string item)
        {
            Storage foundProduct = list.Find(product => product.Model == item);

            if (foundProduct != null)
            {
                list.Remove(foundProduct);
                return true;
            }
            else
            {
               return false;
            }
        }
        public Storage Find(string item)
        {
            return list.Find(storage => storage.Model == item);
        }
        public bool Edit(Storage sourceElement, Storage modifiedElement)
        {
            int index = list.FindIndex(item => item == sourceElement);

            if (index != -1)
            {
                list.Insert(index, modifiedElement);
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Print(ILog log)
        {
            foreach (Storage item in list)
            {
                log.Print(item.ToString());
            }
        }
        public bool Save(ISerialize serializable)
        {
            serializable.Save(list);
            return true;
        }
        public List<Storage> Load(ISerialize serializable)
        {
            return list = serializable.Load();
        }
        public void Clear()
        {
            list.Clear();
        }
    }
}
