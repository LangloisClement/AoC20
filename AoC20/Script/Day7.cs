using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC20
{
    class Day7
    {
        //a bag is: a color (dict Key), a list of bag in it (tuple Item1 (with nbr and color)) and a list of "parents" (tuple Item2)
        Dictionary<string, Tuple<List<Tuple<int, string>>, List<string>>> regle = new Dictionary<string, Tuple<List<Tuple<int, string>>, List<string>>>();
        List<string> repPart1 = new List<string>(); //Part 1 answer

        public Day7(string addr) //constructor
        {
            if (!System.IO.File.Exists(addr)) //check file
            {
                regle = null;
                Console.WriteLine("FILE NOT FOUND");
            }
            else
            {
                foreach (string s in System.IO.File.ReadAllLines(addr))
                {
                    string[] temp = s.Split(' '); //parsing data
                    string color = temp[0] + " " + temp[1]; //color of the curent bag
                    if (!regle.ContainsKey(color)) //if the bag does NOT exist in dict
                    {
                        List<Tuple<int, string>> enfant = new List<Tuple<int, string>>(); //init new bag contains
                        List<string> parent = new List<string>(); //init new bag "parent"
                        regle[color] = new Tuple<List<Tuple<int, string>>, List<string>>(enfant, parent); //creat new bag
                        int i = 4; //rest of the lign
                        while (i < temp.Length) //until the end
                        {
                            if (Int32.TryParse(temp[i], out int n)) //if it's a nbr, it means new type of bag contained
                            {
                                string colorBis = temp[i + 1] + " " + temp[i + 2]; //new color
                                enfant.Add(new Tuple<int, string>(n, colorBis)); //add bag in "child"
                                if (regle.ContainsKey(colorBis)) //if bag already in dict
                                {
                                    if (!regle[colorBis].Item2.Contains(color)) regle[colorBis].Item2.Add(color); //add as "parent" if not already there
                                }
                                else
                                {
                                    regle[colorBis] = new Tuple<List<Tuple<int, string>>, List<string>>(null, new List<string>()); //creat "parent" and add
                                    regle[colorBis].Item2.Add(color);
                                }
                            }
                            i++;
                        }
                    }
                    else //if the bag EXIST in dict
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

        public List<string> RepPart1 { get => repPart1; set => repPart1 = value; } //property for Part 1

        public void RechercheParent(string color) //Part 1,colr being the bag currently tested
        {
            foreach (var v in regle[color].Item2) //foreach "parent" of a bag
            {
                if (!repPart1.Contains(v)) //if NOT in rep already
                {
                    repPart1.Add(v);
                    RechercheParent(v); //test its "parent"
                }
            }
        }

        public int NbrEnfant(string color) //Part 2, color is the starting point
        {
            int r = 0;
            if (regle[color].Item1.Count == 0) return 1;
            foreach (var v in regle[color].Item1)
            {
                r += v.Item1 * NbrEnfantRec(v.Item2); //recursif search
            }
            return r;
        }
        public int NbrEnfantRec(string color) //color is the curent test bag
        {
            int r = 0;
            if (regle[color].Item1.Count == 0) return 1; //if empty return itself
            foreach (var v in regle[color].Item1) //else for each child
            {
                r += v.Item1 * NbrEnfantRec(v.Item2);
            }
            return ++r; //return nbr of bag inside plus it self
        }
    }
}
