using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC20
{
    class Day1
    {
        public static int CalculeSolutionFor2(string addr) //Part1
        {
            if (!System.IO.File.Exists(addr)) return -1; //check file
            string[] temp = System.IO.File.ReadAllLines(addr); //read file
            int[] tab = new int[temp.Length]; //data array
            for (int i = 0; i < temp.Length; i++) tab[i] = Int32.Parse(temp[i]); //filling the data
            foreach (int j in tab)
            {
                int n = TestFor2(j, tab); //test for the pair
                if (n != -1) return j * n; //if found
            }
            return -1; //security return
        }

        static int TestFor2(int n, int[] tab) //test pair, n being the number and tab the data
        {
            foreach (int i in tab) if (i + n == 2020) return i; //brut force each
            return -1; //if not found
        }

        public static int CalculeSolutionFor3(string addr) //Part2
        {
            if (!System.IO.File.Exists(addr)) return -1;
            string[] temp = System.IO.File.ReadAllLines(addr);
            int[] tab = new int[temp.Length];
            for (int i = 0; i < temp.Length; i++) tab[i] = Int32.Parse(temp[i]);
            foreach (int j in tab)
            {
                int[] n = TestFor3(j, tab);
                if (n != null) return j * n[0] * n[1];
            }
            return -1;
        }

        static int[] TestFor3(int n, int[] tab) //test the trio
        {
            int[] r = new int[2];
            for (int i = 0; i < tab.Length; i++)
            {
                for (int j = 0; j < tab.Length; j++) if (n + tab[i] + tab[j] == 2020) { r[0] = tab[i]; r[1] = tab[j]; return r; }
            }
            return null;
        }





    }
}
