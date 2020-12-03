﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC20
{
    class Day3
    {
        bool[,] terrain;

        public bool[,] Terrain { get => terrain; set => terrain = value; }

        public Day3(string addr)
        {
            if (!System.IO.File.Exists(addr))
            {
                Console.WriteLine("ERREUR: FILE NOT FOUND");
                terrain = null;
            }
            else
            {
                string[] temp = System.IO.File.ReadAllLines(addr);
                terrain = new bool[temp.Length, temp[0].Length];
                for (int i = 0; i < temp.Length; i++)
                {
                    for (int j = 0; j < temp[0].Length; j++)
                    {
                        terrain[i, j] = temp[i][j] == '#';
                    }
                }
            }
        }

        public int Reponse()
        {
            int r = 0, i = 0, j = 0;
            while (i < terrain.GetLength(0))
            {
                if (terrain[i, j]) r++;
                i++;
                int a = j + 3 - terrain.GetLength(1);
                if (a < 0) j += 3;
                else j = a;
            }

            return r;
        }
    }
}
