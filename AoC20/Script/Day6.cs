using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC20
{
    class Day6
    {
        List<List<char>> listGroupe = new List<List<char>>(); //list of group answer, each one being a list of char 

        public Day6(string addr, int part) //constructor, part being for Part 1 or 2
        {
            if (!System.IO.File.Exists(addr)) //check file
            {
                listGroupe = null;
                Console.WriteLine("FILE NOT FOUND");
            }
            else
            {
                List<string> repGroupe = new List<string>(); //for Part 2
                string[] data = System.IO.File.ReadAllLines(addr);
                int i = 0;
                listGroupe.Add(new List<char>()); //add new groupe answer
                while (i < data.Length)
                {
                    if (part == 1) //Part 1
                    {
                        if (data[i] == "") listGroupe.Add(new List<char>()); //last group finish, start new one
                        else
                        {
                            foreach (char c in data[i])
                            {
                                if (!listGroupe[listGroupe.Count - 1].Contains(c)) listGroupe[listGroupe.Count - 1].Add(c); //if c not in the group answer, add c
                            }
                        }
                    }
                    else //Part 2
                    {
                        if (data[i] == "") //when gathering is complet
                        {
                            foreach (char c in repGroupe[0]) //test each answer
                            {
                                bool flag = true;
                                foreach (string s in repGroupe)
                                {
                                    if (!s.Contains(c)) //if c is NOT in EACH answer, flag false and stop
                                    {
                                        flag = false;
                                        break;
                                    }
                                }
                                if (flag) listGroupe[listGroupe.Count - 1].Add(c); //add c
                            }
                            repGroupe.Clear(); //start new group
                            listGroupe.Add(new List<char>());
                        }
                        else
                        {
                            repGroupe.Add(data[i]); //gather all group's answer
                        }
                    }
                    i++;
                }
            }
        }

        public int NbrRep //property
        {
            get
            {
                int r = 0;
                foreach (List<char> l in listGroupe) r += l.Count; //foreach group, get the nbr of answer
                return r;
            }
        }


    }
}
