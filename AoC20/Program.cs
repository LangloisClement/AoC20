using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC20
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello world");
            //Console.WriteLine(Day1.CalculeSolutionFor3("../../Input/inputD1.txt"));
            //Console.WriteLine(Day2.NbrPasswordCorige("../../Input/inputD2.txt"));
            Day3 test = new Day3("../../Input/inputD3.txt");
            Console.WriteLine(test.Reponse());
            Console.ReadLine();
        }
    }
}
