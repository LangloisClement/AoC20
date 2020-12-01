using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC20
{
    class Day1
    {
        public static int CalculeSolution(string addr)
        {
            if (!System.IO.File.Exists(addr)) return -1;
            string[] temp = System.IO.File.ReadAllLines(addr);
            int[] tab = new int[temp.Length];
            for (int i = 0; i < temp.Length; i++) tab[i] = Int32.Parse(temp[i]);
            foreach(int j in tab)
            {
                int n = test(j, tab);
                if (n != -1) return j * n;
            }
            return -1;
        }

        static int test(int n, int[] tab)
        {
            foreach (int i in tab) if (i + n == 2020) return i;
            return -1;
        }
    }
}
