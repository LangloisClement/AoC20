using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC20
{
    class Day5
    {
        List<int> listId = new List<int>();

        public Day5(string addr)
        {
            if (!System.IO.File.Exists(addr)) listId = null;
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
        }

        public int MaxBoardId
        {
            get => listId.Max();
        }

        public int GetSeat()
        {
            listId.Sort();
            for(int i = 0; i < listId.Count-1; i++)
            {
                if (listId[i] + 1 != listId[i + 1]) return listId[i] + 1;
            }
            return -1;
        }
    }
}
