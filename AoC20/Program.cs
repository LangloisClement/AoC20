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
            /*Day3 test = new Day3("../../Input/inputD3.txt");
            uint a = test.Reponse(1, 1), b = test.Reponse(1, 3), c = test.Reponse(1, 5), d = test.Reponse(1, 7), e = test.Reponse(2, 1);
            Console.WriteLine(a*b*c*d*e);*/
            //Console.WriteLine(new Day4("../../Input/inputD4.txt").Verrif());
            /*Day5 test = new Day5("../../Input/inputD5.txt");
            Console.WriteLine(test.GetSeat());*/
            //Console.WriteLine(new Day6("../../Input/inputD6.txt",2).NbrRep);
            Day7 day7 = new Day7("../../Input/inputD7.txt");
            //day7.RechercheParent("shiny gold", "shiny gold");
            //Console.WriteLine(day7.RepPart1.Count);
            Console.WriteLine(day7.NbrEnfant("shiny gold"));
            Console.ReadLine();
        }
    }
}
