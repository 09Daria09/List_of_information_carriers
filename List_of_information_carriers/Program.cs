using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library_PriceList;
using Library_Print;
using Library_Storage;
using Library_Serialize;
using System.Security.Cryptography.X509Certificates;

namespace List_of_information_carriers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ILog Cons = new ConsolLog();
            ILog file = new FileLog();
            PriceList priceList = new PriceList();
            ISerialize serializeJSON = new JSONSerialize();
            ISerialize serializeXML = new XMLSerialize();
            Storage storage = null;

            bool Continue = true;
            while (Continue)
            {
                Console.WriteLine("1.Добавить\n2.Удалить\n3.Изменить\n4.Найти\n5.Показать список\n6.Сохранить\n7.Загрузить\n8.Выход ");
                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 1)
                {
                    Console.WriteLine("Что желаете добавить?\n1.HDD\n2.DVD\n3.Flash");
                    int choice1 = Convert.ToInt32(Console.ReadLine());
                    switch (choice1)
                    {
                        case 1:
                            Console.WriteLine("Введите данные для создания объекта HDD:");

                            Console.Write("Имя производителя: ");
                            string manufacturerNameHDD = Console.ReadLine();

                            Console.Write("Модель: ");
                            string modelHDD = Console.ReadLine();

                            Console.Write("Наименование: ");
                            string nameHDD = Console.ReadLine();

                            Console.Write("Емкость носителя (в GB): ");
                            double storageCapacityGBHDD;
                            double.TryParse(Console.ReadLine(), out storageCapacityGBHDD);

                            Console.Write("Cкорость записи: ");
                            string writeSpeedHDD = Console.ReadLine();

                            storage = new HDD(writeSpeedHDD, manufacturerNameHDD, modelHDD, nameHDD, storageCapacityGBHDD);

                            Console.WriteLine("Объект HDD успешно создан и добавлен в список.");
                            priceList.Add(storage);
                            break;
                        case 2:
                            Console.WriteLine("Введите данные для создания объекта DVD:");

                            Console.Write("Имя производителя: ");
                            string manufacturerNameDVD = Console.ReadLine();

                            Console.Write("Модель: ");
                            string modelDVD = Console.ReadLine();

                            Console.Write("Наименование: ");
                            string nameDVD = Console.ReadLine();

                            Console.Write("Емкость носителя (в GB): ");
                            double storageCapacityGBDVD;
                            double.TryParse(Console.ReadLine(), out storageCapacityGBDVD);

                            Console.Write("Cкорость записи: ");
                            string writeSpeedDVD = Console.ReadLine();

                            storage = new DVD(writeSpeedDVD, manufacturerNameDVD, modelDVD, nameDVD, storageCapacityGBDVD);

                            Console.WriteLine("Объект DVD успешно создан и добавлен в список.");

                            priceList.Add(storage);
                            break;
                        case 3:
                            Console.WriteLine("Введите данные для создания объекта Flash:");

                            Console.Write("Имя производителя: ");
                            string manufacturerName = Console.ReadLine();

                            Console.Write("Модель: ");
                            string model = Console.ReadLine();

                            Console.Write("Наименование: ");
                            string name = Console.ReadLine();

                            Console.Write("Емкость носителя (в GB): ");
                            double storageCapacityGB;
                            double.TryParse(Console.ReadLine(), out storageCapacityGB);

                            Console.Write("Cкорость USB: ");
                            string speedUSB = Console.ReadLine();

                            storage = new Flash(speedUSB, manufacturerName, model, name, storageCapacityGB);

                            Console.WriteLine("Объект Flash успешно создан и добавлен в список.");

                            priceList.Add(storage);
                            break;
                    }
                }
                if (choice == 2)
                {
                    Console.WriteLine("Напишите модель, которую желаете удалить:");
                    string NameModel = Console.ReadLine();

                    if (priceList.Remove(NameModel))
                    {
                        Console.WriteLine("Успешно удалено");
                    }
                    else
                    {
                        Console.WriteLine("Модель не найдена");
                    }

                }
                if (choice == 3)
                {
                    priceList.Edit(storage, storage);
                }
                if (choice == 4)
                {
                    Console.WriteLine("Напишите модель, которую желаете найти:");
                    string NameModel = Console.ReadLine();

                    storage = priceList.Find(NameModel);
                    if (storage != null)
                    {
                        Console.WriteLine(storage.ToString());
                    }
                    else
                    {
                        Console.WriteLine("Модель не найдена");
                    }


                }
                if (choice == 5)
                {
                    Console.WriteLine("1.Вывести на консоль\n2.Вывести с файла");
                    int choiceInput = Convert.ToInt32(Console.ReadLine());
                    switch (choiceInput)
                    {
                        case 1:
                            priceList.Print(Cons);
                            break;
                        case 2:
                            priceList.Print(file);
                            break;

                    }
                }
                if (choice == 6)
                {
                    Console.WriteLine("В каком формате вы хотите сохранить?\n1.XML\n2.JSON");
                    int choiceInput = Convert.ToInt32(Console.ReadLine());
                    switch (choiceInput)
                    {
                        case 1:
                            if (priceList.Save(serializeXML))
                            {
                                Console.WriteLine("Успешно сохранено");
                            }
                            else
                            {
                                Console.WriteLine("Не удалось сохранить");
                            }
                            break;
                        case 2:
                            if (priceList.Save(serializeJSON))
                            {
                                Console.WriteLine("Успешно сохранено");
                            }
                            else
                            {
                                Console.WriteLine("Не удалось сохранить");
                            }
                            break;
                    }
                }
                if (choice == 7)
                {
                    Console.WriteLine("С какого файла вы хотите загрузить информацию?\n1.XML\n2.JSON");
                    int choiceInput = Convert.ToInt32(Console.ReadLine());
                    switch (choiceInput)
                    {
                        case 1:
                            priceList.Clear();
                            priceList.Load(serializeXML);
                            break;
                        case 2:
                            priceList.Clear();
                            priceList.Load(serializeJSON);
                            break;
                    }
                }
                if (choice == 8)
                {
                    Continue = false;
                }
            }

        }
    }
}
