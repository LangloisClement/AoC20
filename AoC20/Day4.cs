using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC20
{
    class Day4
    {
        List<Dictionary<string, string>> listPassport = new List<Dictionary<string, string>>();

        public List<Dictionary<string, string>> ListPassport { get => listPassport; set => listPassport = value; }

        public Day4(string addr)
        {
            if (!System.IO.File.Exists(addr))
            {
                Console.WriteLine("FILE NOT FOUND");
                listPassport = null;
            }
            else
            {
                string[] data = System.IO.File.ReadAllLines(addr);
                int i = 0;
                listPassport.Add(new Dictionary<string, string>());
                while (i < data.Length)
                {
                    if (data[i] == "") listPassport.Add(new Dictionary<string, string>());
                    else
                    {
                        string[] temp = data[i].Split(' ');
                        foreach (string s in temp)
                        {
                            listPassport[listPassport.Count - 1][s.Split(':')[0]] = s.Split(':')[1];
                        }
                    }
                    i++;
                }
            }
        }

        public int NbrValide()
        {
            int r = 0;
            if (listPassport == null) return -1;
            foreach (var pass in listPassport)
            {
                if (pass.Count == 8) r++;
                else if (pass.Count == 7 && !pass.ContainsKey("cid")) r++;
            }
            return r;
        }

    }
}
