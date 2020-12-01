using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC20
{
    class Day1
    {
        public static int CalculeSolutionFor2(string addr)
        {
            if (!System.IO.File.Exists(addr)) return -1;
            string[] temp = System.IO.File.ReadAllLines(addr);
            int[] tab = new int[temp.Length];
            for (int i = 0; i < temp.Length; i++) tab[i] = Int32.Parse(temp[i]);
            foreach (int j in tab)
            {
                int n = testFor2(j, tab);
                if (n != -1) return j * n;
            }
            return -1;
        }

        static int testFor2(int n, int[] tab)
        {
            foreach (int i in tab) if (i + n == 2020) return i;
            return -1;
        }

        public static int CalculeSolutionFor3(string addr)
        {
            if (!System.IO.File.Exists(addr)) return -1;
            string[] temp = System.IO.File.ReadAllLines(addr);
            int[] tab = new int[temp.Length];
            for (int i = 0; i < temp.Length; i++) tab[i] = Int32.Parse(temp[i]);
            foreach (int j in tab)
            {
                int[] n = testFor3(j, tab);
                if (n != null) return j * n[0]*n[1];
            }
            return -1;
        }

        static int[] testFor3(int n, int[] tab)
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
