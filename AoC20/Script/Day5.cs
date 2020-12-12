using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC20
{
    class Day5
    {
        List<int> listId = new List<int>(); //list of seat Id

        public Day5(string addr) //constructor
        {
            if (!System.IO.File.Exists(addr)) listId = null; //check file
            foreach (string s in System.IO.File.ReadAllLines(addr))
            {
                int row = 0, column = 0;
                for (int i = 0; i < 7; i++)
                {
                    if (s[i] == 'B') row += (int)Math.Pow(2, 6 - i); //convert bin char to int nbr
                }
                for (int i = 7; i < s.Length; i++)
                {
                    if (s[i] == 'R') column += (int)Math.Pow(2, 9 - i);
                }
                listId.Add((row * 8) + column); //get Id
            }
        }

        public int MaxBoardId //property for Part 1
        {
            get => listId.Max();
        }

        public int GetSeat() //Part 2
        {
            listId.Sort();
            for (int i = 0; i < listId.Count - 1; i++) //foreach seat
            {
                if (listId[i] + 1 != listId[i + 1]) return listId[i] + 1; //if next seat is NOT next id
            }
            return -1;
        }
    }
}
