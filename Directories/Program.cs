using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Directories
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            string path = @"C:\";
            if(Directory.Exists(path))
            {
                Console.WriteLine("Sub directories:");
                string[] dirs = Directory.GetDirectories(path);
                foreach (var item in dirs)
                    Console.WriteLine(item);
            }
        }
    }
}
