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
        List<Tuple<int, Bag>> contenu = new List<Tuple<int, Bag>>();
        public List<Tuple<int, Bag>> Contenu { get => contenu; set => contenu = value; }
        public string Color { get => color; set => color = value; }
        public Bag(string data)
        {
            string[] temp = data.Split(' ');
            this.color = temp[0] + " " + temp[1];
            int i = 4;
            while (i < temp.Length)
            {
                if (Int32.TryParse(temp[i], out int n))
                {
                    contenu.Add(new Tuple<int, Bag>(n, new Bag(temp[i + 1] + " " + temp[i + 2])));
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
                foreach (string s in System.IO.File.ReadAllLines(addr))
                {
                    Bag t = new Bag(s);
                    if (!regle.Contains(t)) regle.Add(t);
                    else
                    {
                        regle.Remove(t);
                        regle.Add(t);
                    }
                }
            }
        }
        public List<Bag> Regle { get => regle; set => regle = value; }
        internal List<Bag> RepPart1 { get => repPart1; set => repPart1 = value; }
    }
    class Day7Bis
    {
        Dictionary<string, List<Tuple<int, string>>> regle = new Dictionary<string, List<Tuple<int, string>>>();
        List<string> repPart1 = new List<string>();

        public Day7Bis(string addr)
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
                        regle[color] = new List<Tuple<int, string>>();
                        int i = 4;
                        while (i < temp.Length)
                        {
                            if (Int32.TryParse(temp[i], out int n))
                            {
                                regle[color].Add(new Tuple<int, string>(n, temp[i + 1] + " " + temp[i + 2]));
                            }
                            i++;
                        }
                    }
                }
            }
        }

        public void Part1(string recherche)
        {
            foreach (var v in regle) //pour chaque couleur
            {
                Recursif(recherche, v.Key);
            }
        }

        void Recursif(string recherche, string color)
        {
            if (!repPart1.Contains(color)) //si pas dans la liste
            {
                foreach (var v in regle[color]) //pour chaque sac dans la couleur en cours
                {
                    if (v.Item2 == recherche || repPart1.Contains(v.Item2)) //si c'est ce qu'on cherhce
                    {
                        repPart1.Add(color); //ajoute la couleur
                    }
                    else
                    {
                        Recursif(recherche, v.Item2);
                    }
                }
            }
        }
    }
}
