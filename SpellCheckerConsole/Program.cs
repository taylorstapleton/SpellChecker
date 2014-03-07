using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellCheckerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string hello = Console.ReadLine();
                print(hello);
            }
        }

        static void print(string toPrint)
        {

            Console.WriteLine(toPrint);
        }
    }
}
