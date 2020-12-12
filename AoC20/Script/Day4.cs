using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC20
{
    class Day4
    {
        List<Dictionary<string, string>> listPassport = new List<Dictionary<string, string>>(); //list of passport, a passport being a dictionary "fieldName"="filedValue", with init

        public List<Dictionary<string, string>> ListPassport { get => listPassport; set => listPassport = value; } //porperty

        public Day4(string addr) //constructor
        {
            if (!System.IO.File.Exists(addr)) //check file
            {
                Console.WriteLine("FILE NOT FOUND");
                listPassport = null;
            }
            else
            {
                string[] data = System.IO.File.ReadAllLines(addr);
                int i = 0;
                listPassport.Add(new Dictionary<string, string>()); //init first dict
                while (i < data.Length)
                {
                    if (data[i] == "") listPassport.Add(new Dictionary<string, string>()); //if last dict if finish, then add new one
                    else
                    {
                        string[] temp = data[i].Split(' '); //parsing field: value
                        foreach (string s in temp)
                        {
                            listPassport[listPassport.Count - 1][s.Split(':')[0]] = s.Split(':')[1]; //adding field:value to last dict in list
                        }
                    }
                    i++;
                }
            }
        }

        public int NbrValide() //Part 1
        {
            int r = 0;
            if (listPassport == null) return -1; //securrity
            foreach (var pass in listPassport)
            {
                if (pass.Count == 8) r++; //if all field
                else if (pass.Count == 7 && !pass.ContainsKey("cid")) r++; //if all field but cid
            }
            return r;
        }

        public int Verrif() //Part 2
        {
            int r = 0;
            if (listPassport == null) return -1;
            foreach (var pass in listPassport)
            {
                if (pass.Count == 8 || (pass.Count == 7 && !pass.ContainsKey("cid"))) //if all field but cid
                {
                    //check all field value
                    if (VerrifByr(pass["byr"]) && VerrifIyr(pass["iyr"]) && VerrifEyr(pass["eyr"]) && VerrifHgt(pass["hgt"]) && VerrifHcl(pass["hcl"]) && VerrifEcl(pass["ecl"]) && VerrifPid(pass["pid"])) r++;
                }
            }
            return r;
        }

        private bool VerrifPid(string v) //check Pid
        {
            if (v.Length != 9) return false; //if not the correct lenght
            return int.TryParse(v, out int i); //if a number
        }

        private bool VerrifEcl(string v) //check Ecl
        {
            switch (v)
            {
                case "amb": //all valid color
                case "blu":
                case "brn":
                case "gry":
                case "grn":
                case "hzl":
                case "oth":
                    return true;
                default: //else
                    return false;
            }
        }

        private bool VerrifHcl(string v) //check Hcl
        {
            if (v[0] != '#' || v.Length != 7) return false; //if long enough and start with #
            foreach (char c in v)
            {
                switch (c)
                {
                    case '#': //if is an hex char
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
                }
            }
            return true;
        }

        private bool VerrifHgt(string v) //check Hgt
        {
            if (v.EndsWith("cm")) //test unit
            {
                if (Int32.TryParse(v.Remove(v.Length - 2), out int h)) //if a number
                {
                    return h >= 150 && h <= 193; //test range
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

        private bool VerrifEyr(string v) //check Eyr
        {
            if (Int32.TryParse(v, out int eyr)) //if a number
            {
                return eyr >= 2020 && eyr <= 2030; //test range
            }
            else return false;
        }

        private bool VerrifIyr(string v) //check Iyr
        {
            if (Int32.TryParse(v, out int iyr)) //if a number
            {
                return iyr >= 2010 && iyr <= 2020; //test range
            }
            else return false;
        }

        private bool VerrifByr(string v) //check Byr
        {
            if (Int32.TryParse(v, out int byr)) //if a number
            {
                return byr >= 1920 && byr <= 2002; //test range
            }
            else return false;
        }
    }
}
