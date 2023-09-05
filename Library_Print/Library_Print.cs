using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Print
{
    public interface ILog
    {
        void Print(string text);
    }
    public class ConsolLog : ILog
    {
        public void Print(string text)
        {
            Console.WriteLine(text);
        }
    }
    public class FileLog : ILog
    {
        public void Print(string text)
        {
            string filePath = "Storage.txt";

            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(text);
            }
            Process.Start(filePath);
        }
    }
}
