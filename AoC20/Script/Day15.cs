using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC20
{
    class Day15
    {
        static int[] test = { 3, 1, 2 };
        static int[] input = { 15, 5, 1, 4, 7, 0 };

        public static int Part1(int nbrTour)
        {
            List<int> memo = new List<int>();
            int i = 0, temp = -1;
            while (i < input.Length - 1)
            {
                memo.Add(input[i]);
                i++;
            }
            temp = input[i];
            while (i < nbrTour)
            {
                if (memo.Contains(temp))
                {
                    int lastof = memo.FindLastIndex(delegate (int a) { return a == temp; });
                    memo.Add(temp);
                    temp = i - lastof;
                }
                else
                {
                    memo.Add(temp);
                    temp = 0;
                }
                i++;
            }
            return memo.Last();
        }







    }
}
