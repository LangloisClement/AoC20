using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC20
{
    class Day2
    {
        public static int NbrPassword(string addr)
        {
            if (!System.IO.File.Exists(addr)) return -1;
            int r = 0,test=0;
            foreach (string s in System.IO.File.ReadAllLines(addr))
            {
                r += VerifPassword(s);
                test++;
            }
            return r;
        }

        static int VerifPassword(string test)
        {
            string[] temp = test.Split(':');
            string pass = temp[1];
            char verif = temp[0][temp[0].Length - 1];
            int min = Int32.Parse(temp[0].Split('-')[0]);
            int max = Int32.Parse(temp[0].Split('-')[1].Split(' ')[0]);
            int memo = 0;
            foreach (char c in pass)
            {
                if (c == verif) memo++;
                if (memo > max) return 0;
            }
            if (memo >= min) return 1;
            else return 0;
        }

        public static int NbrPasswordCorige(string addr)
        {
            if (!System.IO.File.Exists(addr)) return -1;
            int r = 0;
            foreach(string s in System.IO.File.ReadAllLines(addr))
            {
                r += VerifPasswordCorige(s);
            }
            return r;
        }

        private static int VerifPasswordCorige(string s)
        {
            string[] temp = s.Split(':');
            string pass = temp[1];
            char verif = temp[0][temp[0].Length - 1];
            int min = Int32.Parse(temp[0].Split('-')[0]);
            int max = Int32.Parse(temp[0].Split('-')[1].Split(' ')[0]);
            if (pass[min] == verif && pass[max] != verif) return 1;
            if (pass[min] != verif && pass[max] == verif) return 1;
            return 0;
        }
    }
}
