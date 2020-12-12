using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC20
{
    class Instruction //instruction in the game programme
    {
        string typeInst;
        int valeur;
        bool exe = false; //if has already been read

        public Instruction(string type, int valeur) //constructor
        {
            this.typeInst = type;
            this.valeur = valeur;
        }

        //properties
        public int Valeur { get => valeur; set => valeur = value; }
        public bool Exe { get => exe; set => exe = value; }
        public string TypeInst { get => typeInst; set => typeInst = value; }
    }


    class Day8
    {
        List<Instruction> prog = new List<Instruction>(); //game programme
        bool terminate = false; //if programme run to completion for Part 2


        public Day8(string addr) //constructor
        {
            if (!System.IO.File.Exists(addr)) //check file
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

        public int Execut() //Part1
        {
            int r = 0;
            for (int i = 0; i < prog.Count;)
            {
                if (prog[i].Exe) return r; //loop detection
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
            terminate = true; //run until the end
            return r;
        }

        public int Repair() //Part 2
        {
            for (int i = 0; i < prog.Count; i++) //test each instruction
            {
                if (prog[i].TypeInst == "jmp")
                {
                    prog[i].TypeInst = "nop"; //switch type
                    int r = Execut(); //test
                    if (terminate) return r;
                    else prog[i].TypeInst = "jmp";
                }
                else if (prog[i].TypeInst == "nop")
                {
                    prog[i].TypeInst = "jmp";
                    int r = Execut();
                    if (terminate) return r;
                    else prog[i].TypeInst = "nop";
                }
                foreach (var inst in prog) inst.Exe = false; //reset prog
            }
            Console.WriteLine("NOPE");
            return -1;
        }
    }
}
