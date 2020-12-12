using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC20
{
    class Day2
    {
        public static int NbrPassword(string addr) //Part1
        {
            if (!System.IO.File.Exists(addr)) return -1; //check file
            int r = 0;
            foreach (string s in System.IO.File.ReadAllLines(addr)) //foreach password in input
            {
                r += VerifPassword(s);
            }
            return r;
        }

        static int VerifPassword(string test) //test password
        {
            string[] temp = test.Split(':'); //parsing data
            string pass = temp[1]; //password to test
            char verif = temp[0][temp[0].Length - 1]; //char to test
            int min = Int32.Parse(temp[0].Split('-')[0]); //min nbr of occ
            int max = Int32.Parse(temp[0].Split('-')[1].Split(' ')[0]); //max nbr of occ
            int memo = 0;
            foreach (char c in pass)
            {
                if (c == verif) memo++;
                if (memo > max) return 0; //if there is more than max nbr
            }
            if (memo >= min) return 1; //if there is enough nbr
            else return 0;
        }

        public static int NbrPasswordCorige(string addr) //Part2
        {
            if (!System.IO.File.Exists(addr)) return -1;
            int r = 0;
            foreach (string s in System.IO.File.ReadAllLines(addr))
            {
                r += VerifPasswordCorige(s);
            }
            return r;
        }

        private static int VerifPasswordCorige(string s) //test password for part 2
        {
            string[] temp = s.Split(':'); //parsing data
            string pass = temp[1];
            char verif = temp[0][temp[0].Length - 1];
            int min = Int32.Parse(temp[0].Split('-')[0]);
            int max = Int32.Parse(temp[0].Split('-')[1].Split(' ')[0]);
            if (pass[min] == verif && pass[max] != verif) return 1; //XOR on the char test
            if (pass[min] != verif && pass[max] == verif) return 1;
            return 0;
        }
    }
}
