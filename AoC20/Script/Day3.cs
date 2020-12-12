using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC20
{
    class Day3
    {
        bool[,] terrain; //forest map

        public bool[,] Terrain { get => terrain; set => terrain = value; } //property

        public Day3(string addr) //constructor
        {
            if (!System.IO.File.Exists(addr)) //check file
            {
                Console.WriteLine("ERREUR: FILE NOT FOUND");
                terrain = null;
            }
            else
            {
                string[] temp = System.IO.File.ReadAllLines(addr);
                terrain = new bool[temp.Length, temp[0].Length]; //init matrix
                for (int i = 0; i < temp.Length; i++)
                {
                    for (int j = 0; j < temp[0].Length; j++)
                    {
                        terrain[i, j] = temp[i][j] == '#'; //filling matrix
                    }
                }
            }
        }

        public uint Reponse(int down, int right) //part 1 and 2
        {
            uint r = 0;
            int i = 0, j = 0;
            while (i < terrain.GetLength(0)) //until the end of the forest
            {
                if (terrain[i, j]) r++; //if in a tree
                i += down;
                int a = j + right - terrain.GetLength(1); //looping/repeat mechanism
                if (a < 0) j += right; //if need to restart
                else j = a;
            }
            return r;
        }
    }
}
