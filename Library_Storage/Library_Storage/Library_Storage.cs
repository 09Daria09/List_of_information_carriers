using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;
using Library_Print;


namespace Library_Storage
{
    [Serializable]
    [KnownType(typeof(Flash))]
    [KnownType(typeof(DVD))]
    [KnownType(typeof(HDD))]
    [XmlInclude(typeof(Flash))]
    [XmlInclude(typeof(DVD))]
    [XmlInclude(typeof(HDD))]
    [DataContract]
    public abstract class Storage
    {
        [DataMember]
        public string ManufacturerName { get; set; }
        [DataMember]
        public string Model { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public double StorageCapacityGB { get; set; }
        [DataMember]
        public static int Count { get; private set; }
        public virtual void Print(ILog log)
        {
            log.Print(ToString());
        }
        public override string ToString()
        {
            return $"Имя производителя: {ManufacturerName}\nМодель: {Model}" +
                $"\nНаименование: {Name}\nЕмкость носителя: {StorageCapacityGB}\nКоличество: {Count}";
        }
        public Storage(string manufacturerName, string model, string name, double storageCapacityGB)
        {
            ManufacturerName = manufacturerName;
            Model = model;
            Name = name;
            StorageCapacityGB = storageCapacityGB;
            Count++;
        }

        public Storage()
        {
            ManufacturerName = "Unknown";
            Model = "Unknown";
            Name = "Unknown";
            StorageCapacityGB = 0.0;
            Count++;
        }
    }

    [Serializable]
    [DataContract]
    public class Flash:Storage
    {
        [DataMember]
        public string SpeedUSB { get; set; }
        [DataMember]
        public string type { get; set; }
        public override void Print(ILog log) 
        {
            base.Print(log);
        }
        public Flash(string speedUSB, string manufacturerName, string model, string name, double storageCapacityGB): base(manufacturerName,model, name, storageCapacityGB)
        {
            type = "Flash";
            SpeedUSB = speedUSB;
        }
        public Flash() : base()
        {
            type = "Flash";
            SpeedUSB = "Unknown";
        }
        public override string ToString()
        {
            return type + "\n" + base.ToString() + "\n" + "Cкорость USB: " + SpeedUSB + "\n";
        }
        }

    [Serializable]
    [DataContract]
    public class DVD:Storage
    {
        [DataMember]
        public string writeSpeed { get; set; }
        [DataMember]
        public string type { get; set; }
        public override void Print(ILog log) 
        {
            base.Print(log);
        }
        public DVD(string WriteSpeed, string manufacturerName, string model, string name, double storageCapacityGB) : base(manufacturerName, model, name, storageCapacityGB)
        {
            type = "DVD";
            writeSpeed = WriteSpeed;
        }
        public DVD() : base()
        {
            type = "DVD";
            writeSpeed = "Unknown";
        }
        public override string ToString()
        {
            return type + "\n" + base.ToString() + "\n"+ "Cкорость записи: " + writeSpeed + "\n";
        }
    }

    [Serializable]
    [DataContract]
    public class HDD:Storage
    {
        [DataMember]
        public string spindleRotationSpeed { get; set; }
        [DataMember]
        public string type { get; set; }
        public override void Print(ILog log)
        {
           base.Print(log);
        }
        public HDD(string SpindleRotationSpeed, string manufacturerName, string model, string name, double storageCapacityGB) : base(manufacturerName, model, name, storageCapacityGB)
        {
            type = "HDD";
            spindleRotationSpeed = SpindleRotationSpeed;
        }
        public HDD() : base()
        {
            type = "HDD";
            spindleRotationSpeed = "Unknown";
        }
        public override string ToString()
        {
            return type + "\n" + base.ToString() + "\n"+ "Cкорость вращения шпинделя: " + spindleRotationSpeed + "\n";
        }
    }
}
