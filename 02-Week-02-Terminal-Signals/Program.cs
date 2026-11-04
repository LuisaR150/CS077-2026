using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Luisa.R
{
    internal class Program
    {
        static string name = "Good Morning Luisa";

        static void Main(string[] args)
        {
            Console.WriteLine(name);

            Console.Write("Enter terminal name: ");
            string terminalName = Console.ReadLine();

            Console.WriteLine("Terminal " + terminalName + " is online.");
        }
    }
}