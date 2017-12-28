using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            string path = @"C:\Users\student\Desktop\MY FILE.txt";
            FileInfo fileinfo = new FileInfo(path);
            Console.WriteLine(fileinfo.Exists);
            Console.WriteLine(fileinfo.Length);

            //Console.WriteLine("Please enter the string");
            //string text = Console.ReadLine();

            //using (FileStream flStream = new FileStream(path, FileMode.Append))
            //{
            //    byte[] array = System.Text.Encoding.Default.GetBytes(text);
            //    flStream.Write(array, 0, array.Length);
            //    Console.WriteLine("Text was saved to the file...");
            //}

            using (StreamWriter stream = new StreamWriter(path, true, System.Text.Encoding.Default))
            {
                for (int i = 0; i < 20; i++)
                {
                    stream.WriteLine(i);
                }
            }

            List<string> list = new List<string>();

            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                    list.Add(line);
            }
            Console.WriteLine();
            foreach (var item in list)
            {
                Console.Write(item);
            }

        }
    }
}
