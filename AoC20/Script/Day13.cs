using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC20
{
    class Day13
    {
        List<int> busID = new List<int>();
        int time = 0;

        public Day13(string addr)
        {
            if (!System.IO.File.Exists(addr))
            {
                busID = null;
                Console.WriteLine("FILE NOT FOUND");
            }
            else
            {
                string[] data = System.IO.File.ReadAllLines(addr);
                time = int.Parse(data[0]);
                foreach (string s in data[1].Split(','))
                {
                    if (int.TryParse(s, out int n)) busID.Add(n);
                }
            }
        }

        public int Part1()
        {
            int memo = int.MaxValue, bus = 0;
            foreach (int n in busID)
            {
                int next = n * ((time / n) + 1);
                if (next < memo)
                {
                    memo = next;
                    bus = n;
                }
            }
            return (memo - time) * bus;
        }
    }
}
