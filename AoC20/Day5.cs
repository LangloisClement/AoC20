using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC20
{
    class Day5
    {
        public static int MaxBoardId(string addr)
        {
            if (!System.IO.File.Exists(addr)) return -1;
            List<int> listId = new List<int>();
            foreach (string s in System.IO.File.ReadAllLines(addr))
            {
                int row = 0, column = 0;
                for (int i = 0; i < 7; i++)
                {
                    if (s[i] == 'B') row += (int)Math.Pow(2, 6 - i);
                }
                for (int i = 7; i < s.Length; i++)
                {
                    if (s[i] == 'R') column += (int)Math.Pow(2, 9 - i);
                }
                listId.Add((row * 8) + column);
            }
            return listId.Max();
        }


    }
}
