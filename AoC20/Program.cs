﻿using System;
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
            /*Day3 test = new Day3("../../Input/inputD3.txt");
            uint a = test.Reponse(1, 1), b = test.Reponse(1, 3), c = test.Reponse(1, 5), d = test.Reponse(1, 7), e = test.Reponse(2, 1);
            Console.WriteLine(a*b*c*d*e);*/
            Console.WriteLine(new Day4("../../Input/inputD4.txt").Verrif());
            Console.ReadLine();
        }
    }
}
