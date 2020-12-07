using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC20
{
    internal class Bag
    {
        string color;
        List<Tuple<int, string>> contenu=new List<Tuple<int, string>>();
        List<Bag> bags = new List<Bag>();

        public List<Tuple<int, string>> Contenu { get => contenu; set => contenu = value; }
        public string Color { get => color; set => color = value; }

        public Bag(string data)
        {
            string[] temp = data.Split(' ');
            this.color = temp[0]+" "+temp[1];
            int i = 4;
            while (i < temp.Length)
            {
                if(Int32.TryParse(temp[i],out int n))
                {
                    contenu.Add(new Tuple<int, string>(n, temp[i + 1] + " " + temp[i + 2]));
                }
                i++;
            }
        }

        public override bool Equals(object obj)
        {
            var bag = obj as Bag;
            return bag != null &&
                   color == bag.color;
        }
    }




    class Day7
    {
        List<Bag> regle = new List<Bag>();
        List<Bag> repPart1 = new List<Bag>();

        public Day7(string addr)
        {
            if (!System.IO.File.Exists(addr))
            {
                regle = null;
                Console.WriteLine("FILE NOT FOUND");
            }
            else
            {
                foreach(string s in System.IO.File.ReadAllLines(addr))
                {
                    Bag t = new Bag(s);
                    if(!regle.Contains(t)) regle.Add(t);
                }
            }
        }

        public void Part1(string color)
        {
            foreach(Bag b in regle)
            {
                if (!repPart1.Contains(b))
                {
                    foreach(Tuple<int,string> contient in b.Contenu)
                    {
                        Bag temp = new Bag(contient.Item2);
                        regle.
                    }
                }
            }

        }


        public List<Bag> Regle { get => regle; set => regle = value; }
        internal List<Bag> RepPart1 { get => repPart1; set => repPart1 = value; }
    }
}
