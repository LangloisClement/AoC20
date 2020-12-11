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

        public int Combinaison()
        {
            addapteurs.Add(0);
            addapteurs.Sort();
            int r = 0;
            for (int i = 0; i < addapteurs.Count - 3; i++)
            {
                if (addapteurs[i + 3] - addapteurs[i] == 3)
                {
                    r += CombiRec(i + 3);
                }
                if (addapteurs[i + 2] - addapteurs[i] == 3 || addapteurs[i + 2] - addapteurs[i] == 2)
                {
                    r += CombiRec(i + 2);
                }
                if (addapteurs[i + 1] - addapteurs[i] == 3 || addapteurs[i + 1] - addapteurs[i] == 2 || addapteurs[i + 1] - addapteurs[i] == 1)
                {
                    r += CombiRec(i + 1);
                }
            }
            return r;
        }

        private int CombiRec(int current)
        {
            if (current >= addapteurs.Count - 3) return 1;
            int r = 0;
            if (current == addapteurs.Count - 1) return 1;
            /*if (current == addapteurs.Count - 2)
            {
                
            }
            if (current == addapteurs.Count - 3)
            {

            }*/
            for (int i = current; i < addapteurs.Count - 3; i++)
            {
                if (addapteurs[i + 3] - addapteurs[i] == 3)
                {
                    r += CombiRec(i + 3);
                }
                if (addapteurs[i + 2] - addapteurs[i] == 3 || addapteurs[i + 2] - addapteurs[i] == 2)
                {
                    r += CombiRec(i + 2);
                }
                if (addapteurs[i + 1] - addapteurs[i] == 3 || addapteurs[i + 1] - addapteurs[i] == 2 || addapteurs[i + 1] - addapteurs[i] == 1)
                {
                    r += CombiRec(i + 1);
                }
            }
            return r;
        }

        public long Part2()
        {
            addapteurs.Add(0);
            addapteurs.Sort();
            addapteurs.Add(addapteurs[addapteurs.Count - 1] + 3);
            List<long> memo = new List<long> { 1 };
            for (int i = 1; i < addapteurs.Count; i++)
            {
                long rep = 0;
                for (int j = 0; j < i; j++)
                {
                    if (addapteurs[j] + 3 >= addapteurs[i]) rep += memo[j];
                }
                memo.Add(rep);
            }
            return memo[memo.Count - 1];
        }


    }
}
