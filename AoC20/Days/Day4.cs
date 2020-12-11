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

        public int Verrif()
        {
            int r = 0, i = 0;
            if (listPassport == null) return -1;
            foreach (var pass in listPassport)
            {
                
                if (pass.Count == 8 || (pass.Count == 7 && !pass.ContainsKey("cid")))
                {
                    i++;
                    VerrifByr(pass["byr"]);
                    VerrifIyr(pass["iyr"]);
                    VerrifEyr(pass["eyr"]);
                    VerrifHgt(pass["hgt"]);
                    VerrifHcl(pass["hcl"]);
                    VerrifEcl(pass["ecl"]);
                    VerrifPid(pass["pid"]);
                    if (VerrifByr(pass["byr"]) && VerrifIyr(pass["iyr"]) && VerrifEyr(pass["eyr"]) && VerrifHgt(pass["hgt"]) && VerrifHcl(pass["hcl"]) && VerrifEcl(pass["ecl"]) && VerrifPid(pass["pid"])) r++;
                }
            }
            return r;
        }

        private bool VerrifPid(string v)
        {
            if (v.Length != 9) return false;
            if (!Int32.TryParse(v, out int i)) return false;
            return true;
        }

        private bool VerrifEcl(string v)
        {
            switch (v)
            {
                case "amb":
                case "blu":
                case "brn":
                case "gry":
                case "grn":
                case "hzl":
                case "oth":
                    return true;
                    break;
                default:
                    return false;
                    break;
            }
        }

        private bool VerrifHcl(string v)
        {
            if (v[0] != '#' || v.Length != 7) return false;
            foreach (char c in v)
            {
                switch (c)
                {
                    case '#':
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                    case 'a':
                    case 'b':
                    case 'c':
                    case 'd':
                    case 'e':
                    case 'f':
                        break;
                    default:
                        return false;
                        break;
                }
            }
            return true;
        }

        private bool VerrifHgt(string v)
        {
            if (v.EndsWith("cm"))
            {
                if (Int32.TryParse(v.Remove(v.Length - 2), out int h))
                {
                    return h >= 150 && h <= 193;
                }
                else return false;
            }
            else if (v.EndsWith("in"))
            {
                if (Int32.TryParse(v.Remove(v.Length - 2), out int h))
                {
                    return (h >= 59 && h <= 76);
                }
                else return false;
            }
            else return false;
        }

        private bool VerrifEyr(string v)
        {
            if (Int32.TryParse(v, out int eyr))
            {
                return eyr >= 2020 && eyr <= 2030;
            }
            else return false;
        }

        private bool VerrifIyr(string v)
        {
            if (Int32.TryParse(v, out int iyr))
            {
                return iyr >= 2010 && iyr <= 2020;
            }
            else return false;
        }

        private bool VerrifByr(string v)
        {
            if (Int32.TryParse(v, out int byr))
            {
                return byr >= 1920 && byr <= 2002;
            }
            else return false;
        }
    }
}
