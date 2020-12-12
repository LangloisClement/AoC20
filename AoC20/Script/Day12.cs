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
        public static int Part2(string addr)
        {
            if (!System.IO.File.Exists(addr)) //check file
            {
                Console.WriteLine("ERREUR: FILE NOT FOUND");
                return -1;
            }
            else
            {
                string[] temp = System.IO.File.ReadAllLines(addr);
                int x = 0, y = 0, Wx = 1, Wy = 10, memo = 0;
                for (int i = 0; i < temp.Length; i++)
                {
                    int t = int.Parse(temp[i].Remove(0, 1));
                    switch (temp[i][0])
                    {
                        case 'N':
                            Wx += t;
                            break;
                        case 'S':
                            Wx -= t;
                            break;
                        case 'E':
                            Wy += t;
                            break;
                        case 'W':
                            Wy -= t;
                            break;
                        case 'L':
                            t /= 90;
                            for (int n = 0; n < t; n++)
                            {
                                memo = Wx;
                                Wx = Wy;
                                Wy = -1 * memo;
                            }
                            break;
                        case 'R':
                            t /= 90;
                            for (int n = 0; n < t; n++)
                            {
                                memo = Wx;
                                Wx = -1 * Wy;
                                Wy = memo;
                            }
                            break;
                        case 'F':
                            x += t * Wx;
                            y += t * Wy;
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
