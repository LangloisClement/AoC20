using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC20
{
    class Day7
    {

        Dictionary<string, Tuple<List<Tuple<int, string>>, List<string>>> regle = new Dictionary<string, Tuple<List<Tuple<int, string>>, List<string>>>();
        List<string> repPart1 = new List<string>();

        public Day7(string addr)
        {
            if (!System.IO.File.Exists(addr))
            {
                regle = null;
                Console.WriteLine("FILE NOT FOUND");
            }
            else
            {
                foreach (string s in System.IO.File.ReadAllLines(addr))
                {
                    string[] temp = s.Split(' ');
                    string color = temp[0] + " " + temp[1];
                    if (!regle.ContainsKey(color))
                    {
                        List<Tuple<int, string>> enfant = new List<Tuple<int, string>>();
                        List<string> parent = new List<string>();
                        regle[color] = new Tuple<List<Tuple<int, string>>, List<string>>(enfant, parent);
                        int i = 4;
                        while (i < temp.Length)
                        {
                            if (Int32.TryParse(temp[i], out int n))
                            {
                                string colorBis = temp[i + 1] + " " + temp[i + 2];
                                enfant.Add(new Tuple<int, string>(n, colorBis));
                                if (regle.ContainsKey(colorBis))
                                {
                                    if (!regle[colorBis].Item2.Contains(color)) regle[colorBis].Item2.Add(color);
                                }
                                else
                                {
                                    regle[colorBis] = new Tuple<List<Tuple<int, string>>, List<string>>(null, new List<string>());
                                    regle[colorBis].Item2.Add(color);
                                }
                            }
                            i++;
                        }
                    }
                    else
                    {
                        List<Tuple<int, string>> enfant = new List<Tuple<int, string>>();
                        List<string> parent = regle[color].Item2;
                        regle[color] = new Tuple<List<Tuple<int, string>>, List<string>>(enfant, parent);
                        int i = 4;
                        while (i < temp.Length)
                        {
                            if (Int32.TryParse(temp[i], out int n))
                            {
                                string colorBis = temp[i + 1] + " " + temp[i + 2];
                                enfant.Add(new Tuple<int, string>(n, colorBis));
                                if (regle.ContainsKey(colorBis))
                                {
                                    if (!regle[colorBis].Item2.Contains(color)) regle[colorBis].Item2.Add(color);
                                }
                                else
                                {
                                    regle[colorBis] = new Tuple<List<Tuple<int, string>>, List<string>>(null, new List<string>());
                                    regle[colorBis].Item2.Add(color);
                                }
                            }
                            i++;
                        }
                    }
                }
            }
        }

        public List<string> RepPart1 { get => repPart1; set => repPart1 = value; }

        public void RechercheParent(string recherche, string color)
        {
            foreach (var v in regle[color].Item2)
            {
                if (!repPart1.Contains(v))
                {
                    repPart1.Add(v);
                    RechercheParent(recherche, v);
                }
            }
        }

        public int NbrEnfant(string color)
        {
            int r = 0;
            if (regle[color].Item1.Count == 0) return 1;
            foreach (var v in regle[color].Item1)
            {
                r += v.Item1 * NbrEnfantRec(v.Item2);
            }
            return r;
        }
        public int NbrEnfantRec(string color)
        {
            int r = 0;
            if (regle[color].Item1.Count == 0) return 1;
            foreach (var v in regle[color].Item1)
            {
                r += v.Item1 * NbrEnfantRec(v.Item2);
            }
            return ++r;
        }
    }
}
