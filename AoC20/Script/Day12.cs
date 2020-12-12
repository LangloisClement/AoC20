using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC20
{
    class Day12
    {
        public static int Part1(string addr)
        {
            if (!System.IO.File.Exists(addr)) //check file
            {
                Console.WriteLine("ERREUR: FILE NOT FOUND");
                return -1;
            }
            else
            {
                string[] temp = System.IO.File.ReadAllLines(addr);
                int x = 0, y = 0;
                string directionsR = "ESWN", directionsL = "ENWS";
                char dir = 'E';
                for (int i = 0; i < temp.Length; i++)
                {
                    int t = int.Parse(temp[i].Remove(0, 1));
                    int m = directionsR.LastIndexOf(dir);
                    int n = directionsL.LastIndexOf(dir);
                    switch (temp[i][0])
                    {
                        case 'N':
                            x += t;
                            break;
                        case 'S':
                            x -= t;
                            break;
                        case 'E':
                            y += t;
                            break;
                        case 'W':
                            y -= t;
                            break;
                        case 'L':
                            t /= 90;
                            if (t + n - 4 < 0) dir = directionsL[t + n];
                            else dir = directionsL[t + n - 4];
                            break;
                        case 'R':
                            t /= 90;
                            if (t + m - 4 < 0) dir = directionsR[t + m];
                            else dir = directionsR[t + m - 4];
                            break;
                        case 'F':
                            switch (dir)
                            {
                                case 'N':
                                    x += t;
                                    break;
                                case 'S':
                                    x -= t;
                                    break;
                                case 'E':
                                    y += t;
                                    break;
                                case 'W':
                                    y -= t;
                                    break;
                            }
                            break;
                        default:
                            return -1;
                    }
                }
                return Math.Abs(x) + Math.Abs(y);
            }
        }
    }
}
