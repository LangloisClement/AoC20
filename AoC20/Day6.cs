using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC20
{
    class Day6
    {
        List<List<char>> listGroupe = new List<List<char>>();

        public Day6(string addr, int part)
        {
            if (!System.IO.File.Exists(addr))
            {
                listGroupe = null;
                Console.WriteLine("FILE NOT FOUND");
            }
            else
            {
                List<string> repGroupe = new List<string>();
                string[] data = System.IO.File.ReadAllLines(addr);
                int i = 0;
                listGroupe.Add(new List<char>());
                while (i < data.Length)
                {
                    if (part == 1)
                    {
                        if (data[i] == "") listGroupe.Add(new List<char>());
                        else
                        {
                            foreach (char c in data[i])
                            {
                                if (!listGroupe[listGroupe.Count - 1].Contains(c)) listGroupe[listGroupe.Count - 1].Add(c);
                            }
                        }
                    }
                    else
                    {
                        if (data[i] == "")
                        {
                            foreach (char c in repGroupe[0])
                            {
                                bool flag = true;
                                foreach (string s in repGroupe)
                                {
                                    if (!s.Contains(c))
                                    {
                                        flag = false;
                                        break;
                                    }
                                }
                                if (flag) listGroupe[listGroupe.Count - 1].Add(c);
                            }
                            repGroupe.Clear();
                            listGroupe.Add(new List<char>());
                        }
                        else
                        {
                            repGroupe.Add(data[i]);
                        }
                    }
                    i++;
                }
            }
        }

        public int NbrRep
        {
            get
            {
                int r = 0;
                foreach (List<char> l in listGroupe) r += l.Count;
                return r;
            }
        }


    }
}
