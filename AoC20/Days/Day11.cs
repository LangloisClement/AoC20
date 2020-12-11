using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC20
{
    class Day11
    {
        char[,] terrain;

        public char[,] Terrain { get => terrain; set => terrain = value; }

        public Day11(string addr)
        {
            if (!System.IO.File.Exists(addr))
            {
                Console.WriteLine("ERREUR: FILE NOT FOUND");
                terrain = null;
            }
            else
            {
                string[] temp = System.IO.File.ReadAllLines(addr);
                terrain = new char[temp.Length, temp[0].Length];
                for (int i = 0; i < temp.Length; i++)
                {
                    for (int j = 0; j < temp[0].Length; j++)
                    {
                        terrain[i, j] = temp[i][j];
                    }
                }
            }
        }

        public int Compte
        {
            get
            {
                int r = 0;
                foreach (char c in terrain)
                {
                    if (c == '#') r++;
                }
                return r;
            }
        }

        public void GameOfLife()
        {
            char[,] temp = (char[,])terrain.Clone();
            for (int i = 0; i < terrain.GetLength(0); i++)
            {
                for (int j = 0; j < terrain.GetLength(1); j++)
                {
                    switch (terrain[i, j])
                    {
                        case 'L':
                            if (NbrVoisin(i, j) == 0) temp[i, j] = '#';
                            else temp[i, j] = 'L';
                            break;
                        case '#':
                            if (NbrVoisin(i, j) >= 4) temp[i, j] = 'L';
                            else temp[i, j] = '#';
                            break;
                    }
                }
            }
            terrain = temp;
        }

        private int NbrVoisin(int i, int j)
        {
            int r = 0;
            if (i == 0 && j == 0)
            {
                if (terrain[i, j + 1] == '#') r++;
                if (terrain[i + 1, j] == '#') r++;
                if (terrain[i + 1, j + 1] == '#') r++;
            }
            else if (i == 0 && j == terrain.GetLength(1) - 1)
            {
                if (terrain[i, j - 1] == '#') r++;
                if (terrain[i + 1, j - 1] == '#') r++;
                if (terrain[i + 1, j] == '#') r++;
            }
            else if (i == terrain.GetLength(0) - 1 && j == 0)
            {
                if (terrain[i - 1, j] == '#') r++;
                if (terrain[i - 1, j + 1] == '#') r++;
                if (terrain[i, j + 1] == '#') r++;
            }
            else if (i == terrain.GetLength(0) - 1 && j == terrain.GetLength(1) - 1)
            {
                if (terrain[i - 1, j - 1] == '#') r++;
                if (terrain[i - 1, j] == '#') r++;
                if (terrain[i, j - 1] == '#') r++;
            }
            else if (i == 0)
            {
                if (terrain[i, j - 1] == '#') r++;
                if (terrain[i, j + 1] == '#') r++;
                if (terrain[i + 1, j - 1] == '#') r++;
                if (terrain[i + 1, j] == '#') r++;
                if (terrain[i + 1, j + 1] == '#') r++;

            }
            else if (i == terrain.GetLength(0) - 1)
            {
                if (terrain[i - 1, j - 1] == '#') r++;
                if (terrain[i - 1, j] == '#') r++;
                if (terrain[i - 1, j + 1] == '#') r++;
                if (terrain[i, j - 1] == '#') r++;
                if (terrain[i, j + 1] == '#') r++;

            }
            else if (j == 0)
            {
                if (terrain[i - 1, j] == '#') r++;
                if (terrain[i - 1, j + 1] == '#') r++;
                if (terrain[i, j + 1] == '#') r++;
                if (terrain[i + 1, j] == '#') r++;
                if (terrain[i + 1, j + 1] == '#') r++;

            }
            else if (j == terrain.GetLength(1) - 1)
            {
                if (terrain[i - 1, j - 1] == '#') r++;
                if (terrain[i - 1, j] == '#') r++;
                if (terrain[i, j - 1] == '#') r++;
                if (terrain[i + 1, j - 1] == '#') r++;
                if (terrain[i + 1, j] == '#') r++;

            }
            else
            {
                if (terrain[i - 1, j - 1] == '#') r++;
                if (terrain[i - 1, j] == '#') r++;
                if (terrain[i - 1, j + 1] == '#') r++;
                if (terrain[i, j - 1] == '#') r++;
                if (terrain[i, j + 1] == '#') r++;
                if (terrain[i + 1, j - 1] == '#') r++;
                if (terrain[i + 1, j] == '#') r++;
                if (terrain[i + 1, j + 1] == '#') r++;
            }
            return r;
        }

        public int Part1()
        {
            int memo = 0, current = 0;
            do
            {
                memo = current;
                GameOfLife();
                current = Compte;
            } while (memo != current);
            return current;
        }

        public override string ToString()
        {
            string r = "";
            for(int i = 0; i < terrain.GetLength(0); i++)
            {
                for(int j = 0; j < terrain.GetLength(1); j++)
                {
                    r += terrain[i,j]; 
                }
                r += "\n";
            }
            return r;
        }
    }
}
