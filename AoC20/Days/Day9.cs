using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC20
{
    class Day9
    {
        long[] code;

        public Day9(string addr)
        {

            if (!System.IO.File.Exists(addr))
            {
                code = null;
                Console.WriteLine("FILE NOT FOUND");
            }
            else
            {
                string[] data = System.IO.File.ReadAllLines(addr);
                code = new long[data.Length];
                for (int i = 0; i < data.Length; i++)
                {
                    code[i] = long.Parse(data[i]);
                }
            }
        }

        public long[] Code { get => code; set => code = value; }

        public long Test(int taillePrean)
        {
            for (int i = taillePrean; i < code.Length; i++)
            {
                if (!Combinaison(i, taillePrean)) return code[i];
            }
            return -1;
        }

        private bool Combinaison(int v, int taillePrean)
        {
            for (int i = 0; i < taillePrean; i++)
            {
                for (int j = i; j < taillePrean; j++)
                {
                    if (code[i + (v - taillePrean)] + code[j + (v - taillePrean)] == code[v] && code[i + (v - taillePrean)] != code[j + (v - taillePrean)]) return true;
                }
            }
            return false;
        }

        public long Weakness(int taillePrean)
        {
            long probleme = Test(taillePrean);
            List<long> rep = new List<long>();
            for (int i = 0; i < code.Length; i++)
            {
                rep.Add(code[i]);
                for (int j = i + 1; j < code.Length; j++)
                {
                    rep.Add(code[j]);
                    long somme = rep.Sum();
                    if (somme == probleme) return rep.Max() + rep.Min();
                    else if (somme > probleme)
                    {
                        break;
                    }
                }
                rep.Clear();
            }
            return -1;
        }
    }
}
