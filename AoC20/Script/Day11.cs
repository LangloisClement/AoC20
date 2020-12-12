using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC20
{
    class Day11
    {
        char[,] terrain; //lobby


        public Day11(string addr) //constructor
        {
            if (!System.IO.File.Exists(addr)) //check file
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

        public char[,] Terrain { get => terrain; set => terrain = value; } //property

        public int Compte //property for the number of persons
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

        public void GameOfLifeDirect() //game of life for Part 1 (direct contact)
        {
            char[,] temp = (char[,])terrain.Clone(); //temporary clone grid so that updates don't mess with the next one
            for (int i = 0; i < terrain.GetLength(0); i++)
            {
                for (int j = 0; j < terrain.GetLength(1); j++)
                {
                    switch (terrain[i, j])
                    {
                        case 'L':
                            if (NbrVoisinDirect(i, j) == 0) temp[i, j] = '#';
                            else temp[i, j] = 'L';
                            break;
                        case '#':
                            if (NbrVoisinDirect(i, j) >= 4) temp[i, j] = 'L';
                            else temp[i, j] = '#';
                            break;
                    }
                }
            }
            terrain = temp; //updating
        }

        private int NbrVoisinDirect(int i, int j) //nbr of neighbors (direct contact)
        {
            int r = 0;
            if (i == 0 && j == 0) //top left corner
            {
                if (terrain[i, j + 1] == '#') r++;
                if (terrain[i + 1, j] == '#') r++;
                if (terrain[i + 1, j + 1] == '#') r++;
            }
            else if (i == 0 && j == terrain.GetLength(1) - 1) //top right corner
            {
                if (terrain[i, j - 1] == '#') r++;
                if (terrain[i + 1, j - 1] == '#') r++;
                if (terrain[i + 1, j] == '#') r++;
            }
            else if (i == terrain.GetLength(0) - 1 && j == 0) //botom left corner
            {
                if (terrain[i - 1, j] == '#') r++;
                if (terrain[i - 1, j + 1] == '#') r++;
                if (terrain[i, j + 1] == '#') r++;
            }
            else if (i == terrain.GetLength(0) - 1 && j == terrain.GetLength(1) - 1) //botom right corner
            {
                if (terrain[i - 1, j - 1] == '#') r++;
                if (terrain[i - 1, j] == '#') r++;
                if (terrain[i, j - 1] == '#') r++;
            }
            else if (i == 0) //top side
            {
                if (terrain[i, j - 1] == '#') r++;
                if (terrain[i, j + 1] == '#') r++;
                if (terrain[i + 1, j - 1] == '#') r++;
                if (terrain[i + 1, j] == '#') r++;
                if (terrain[i + 1, j + 1] == '#') r++;

            }
            else if (i == terrain.GetLength(0) - 1) //botom side
            {
                if (terrain[i - 1, j - 1] == '#') r++;
                if (terrain[i - 1, j] == '#') r++;
                if (terrain[i - 1, j + 1] == '#') r++;
                if (terrain[i, j - 1] == '#') r++;
                if (terrain[i, j + 1] == '#') r++;

            }
            else if (j == 0) //left side
            {
                if (terrain[i - 1, j] == '#') r++;
                if (terrain[i - 1, j + 1] == '#') r++;
                if (terrain[i, j + 1] == '#') r++;
                if (terrain[i + 1, j] == '#') r++;
                if (terrain[i + 1, j + 1] == '#') r++;

            }
            else if (j == terrain.GetLength(1) - 1) //right side
            {
                if (terrain[i - 1, j - 1] == '#') r++;
                if (terrain[i - 1, j] == '#') r++;
                if (terrain[i, j - 1] == '#') r++;
                if (terrain[i + 1, j - 1] == '#') r++;
                if (terrain[i + 1, j] == '#') r++;

            }
            else //the rest
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
            do //looping until 2 identical iter
            {
                memo = current;
                GameOfLifeDirect();
                current = Compte;
            } while (memo != current);
            return current;
        }

        public int Part2()
        {
            int memo = 0, current = 0;
            do
            {
                memo = current;
                GameOfLifeLigne();
                current = Compte;
            } while (memo != current);
            return current;
        }

        private void GameOfLifeLigne() //game of life for Part 2 (lign of sight)
        {
            char[,] temp = (char[,])terrain.Clone();
            for (int i = 0; i < terrain.GetLength(0); i++)
            {
                for (int j = 0; j < terrain.GetLength(1); j++)
                {
                    switch (terrain[i, j])
                    {
                        case 'L':
                            if (NbrVoisinLigne(i, j) == 0) temp[i, j] = '#';
                            else temp[i, j] = 'L';
                            break;
                        case '#':
                            if (NbrVoisinLigne(i, j) >= 5) temp[i, j] = 'L';
                            else temp[i, j] = '#';
                            break;
                    }
                }
            }
            terrain = temp;
        }

        private int NbrVoisinLigne(int i, int j) //nbr of neighbor (lign of sight)
        {
            int r = 0, k = 0, l = 0;
            //diag hg
            while (true)
            {
                k--; l--;
                if (i + k < 0 || j + l < 0 || terrain[i + k, j + l] == 'L') break;
                if (terrain[i + k, j + l] == '#')
                {
                    r++;
                    break;
                }
            }
            k = 0; l = 0;
            //en haut
            while (true)
            {
                k--;
                if (i + k < 0 || terrain[i + k, j] == 'L') break;
                if (terrain[i + k, j] == '#')
                {
                    r++;
                    break;
                }
            }
            k = 0; l = 0;
            //diag hd
            while (true)
            {
                k--; l++;
                if (i + k < 0 || j + l >= terrain.GetLength(1) || terrain[i + k, j + l] == 'L') break;
                if (terrain[i + k, j + l] == '#')
                {
                    r++;
                    break;
                }
            }
            k = 0; l = 0;
            //a gauche
            while (true)
            {
                l--;
                if (j + l < 0 || terrain[i, j + l] == 'L') break;
                if (terrain[i, j + l] == '#')
                {
                    r++;
                    break;
                }
            }
            k = 0; l = 0;
            //a doite
            while (true)
            {
                l++;
                if (j + l >= terrain.GetLength(1) || terrain[i, j + l] == 'L') break;
                if (terrain[i, j + l] == '#')
                {
                    r++;
                    break;
                }
            }
            k = 0; l = 0;
            //diag bg
            while (true)
            {
                k++; l--;
                if (i + k >= terrain.GetLength(0) || j + l < 0 || terrain[i + k, j + l] == 'L') break;
                if (terrain[i + k, j + l] == '#')
                {
                    r++;
                    break;
                }
            }
            k = 0; l = 0;
            //en bas
            while (true)
            {
                k++;
                if (i + k >= terrain.GetLength(0) || terrain[i + k, j] == 'L') break;
                if (terrain[i + k, j] == '#')
                {
                    r++;
                    break;
                }
            }
            k = 0; l = 0;
            //diag bd
            while (true)
            {
                k++; l++;
                if (i + k >= terrain.GetLength(0) || j + l >= terrain.GetLength(1) || terrain[i + k, j + l] == 'L') break;
                if (terrain[i + k, j + l] == '#')
                {
                    r++;
                    break;
                }
            }
            return r;
        }

        public override string ToString()
        {
            string r = "";
            for (int i = 0; i < terrain.GetLength(0); i++)
            {
                for (int j = 0; j < terrain.GetLength(1); j++)
                {
                    r += terrain[i, j];
                }
                r += "\n";
            }
            return r;
        }
    }
}
