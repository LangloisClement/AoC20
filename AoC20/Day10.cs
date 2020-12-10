using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC20
{

    class Day10
    {
        List<int> addapteurs = new List<int>();

        public Day10(string addr)
        {
            if (!System.IO.File.Exists(addr))
            {
                addapteurs = null;
                Console.WriteLine("FILE NOT FOUND");
            }
            else
            {
                string[] data = System.IO.File.ReadAllLines(addr);
                for (int i = 0; i < data.Length; i++)
                {
                    addapteurs.Add(int.Parse(data[i]));
                }
            }
        }

        public int Test()
        {
            addapteurs.Add(0);
            addapteurs.Sort();
            int plus1 = 0, plus2 = 0, plus3 = 0;
            for (int i = 0; i < addapteurs.Count - 1; i++)
            {
                switch (addapteurs[i + 1] - addapteurs[i])
                {
                    case 1: plus1++; break;
                    case 2: plus2++; break;
                    case 3: plus3++; break;
                    default: Console.WriteLine("ERROR"); break;
                }
            }

            return ++plus3 * plus1;
        }
    }
}
