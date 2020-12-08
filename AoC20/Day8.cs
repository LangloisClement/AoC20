using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC20
{
    class Instruction
    {
        string typeInst;
        int valeur;
        bool exe = false;

        public Instruction(string type, int valeur)
        {
            this.typeInst = type;
            this.valeur = valeur;
        }

        public int Valeur { get => valeur; set => valeur = value; }
        public bool Exe { get => exe; set => exe = value; }
        internal string TypeInst { get => typeInst; set => typeInst = value; }
    }


    class Day8
    {
        List<Instruction> prog = new List<Instruction>();

        public Day8(string addr)
        {
            if (!System.IO.File.Exists(addr))
            {
                prog = null;
                Console.WriteLine("FILE NOT FOUND");
            }
            else
            {
                string[] data = System.IO.File.ReadAllLines(addr);
                foreach (string s in data)
                {
                    string[] temp = s.Split(' ');
                    prog.Add(new Instruction(temp[0], int.Parse(temp[1])));
                }
            }
        }

        public int Execut()
        {
            int r = 0;
            for (int i = 0; i < prog.Count;)
            {
                if (prog[i].Exe) return r;
                else
                {
                    prog[i].Exe = true;
                    switch (prog[i].TypeInst)
                    {
                        case "acc":
                            r += prog[i].Valeur;
                            i++;
                            break;
                        case "jmp":
                            i += prog[i].Valeur;
                            break;
                        default:
                            i++;
                            break;
                    }
                }
            }
            return r;
        }
    }
}
