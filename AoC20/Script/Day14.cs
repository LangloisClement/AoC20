using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC20
{
    class Day14
    {
        Dictionary<int, char[]> memoire = new Dictionary<int, char[]>();

        public Day14(string addr)
        {
            if (!System.IO.File.Exists(addr))
            {
                memoire = null;
                Console.WriteLine("FILE NOT FOUND");
            }
            else
            {
                string[] data = System.IO.File.ReadAllLines(addr);
                char[] mask = new char[36];
                for (int i = 0; i < data.Length; i++)
                {
                    string[] temp = data[i].Split('=');
                    if (temp[0] == "mask ")
                    {
                        mask = temp[1].Remove(0, 1).ToCharArray();
                    }
                    if (temp[0].Contains("mem"))
                    {
                        if (int.TryParse(temp[0].Remove(temp[0].Length - 2).Remove(0, 4), out int n))
                        {
                            long val = long.Parse(temp[1].Remove(0, 1));
                            memoire[n] = ValMasked(mask, IntToBin36(val));

                        }
                        else
                        {
                            Console.WriteLine("ERROR");
                            break;
                        }
                    }
                }
            }
        }

        private char[] ValMasked(char[] mask, char[] val)
        {
            char[] r = new char[36];
            for (int i = 0; i < 36; i++)
            {
                if (mask[i] != 'X') r[i] = mask[i];
                else r[i] = val[i];
            }
            return r;
        }

        private char[] IntToBin36(long val)
        {
            char[] r = new char[36];
            for (int i = 35; i >= 0; i--)
            {
                if (val >= Math.Pow(2, i))
                {
                    r[35 - i] = '1';
                    val -= (long)Math.Pow(2, i);
                }
                else r[35 - i] = '0';
            }
            return r;
        }

        public long Part1
        {
            get
            {
                long r = 0;
                foreach (var keyValue in memoire)
                {
                    r += Bin36ToLong(keyValue.Value);
                }

                return r;
            }
        }

        private long Bin36ToLong(char[] value)
        {
            long r = 0;
            for (int i = 0; i < 36; i++)
            {
                if (value[i] == '1') r += (long)Math.Pow(2, 35 - i);
            }
            return r;
        }
    }
}
