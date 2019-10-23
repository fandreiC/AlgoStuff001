using System;
using System.Collections.Generic;

namespace PS001
{
    internal static class Solution03
    {
        enum Pharenteses
        {
            A1 = '(',
            A2 = ')',
            B1 = '[',
            B2 = ']',
            C1 = '{',
            C2 = '}',
            D = '0'
        }
        private static bool IsValid(string s)
        {
            bool noText = string.IsNullOrEmpty(s);
            if (noText == true) return true; ;
            char[] text = s.ToCharArray();
            bool ExitValidator = false;
            Pharenteses paranteza = Pharenteses.D;

            Dictionary<string, int> counters = new Dictionary<string, int>();
            counters.Add("A", 0);
            counters.Add("B", 0);
            counters.Add("C", 0);
            Dictionary<string, bool> validators = new Dictionary<string, bool>();
            validators.Add("A", false);
            validators.Add("B", false);
            validators.Add("C", false);

            int[] last = new int[text.Length];
            //int j = 0;
            for (int i = 0; i < last.Length; i++)
            {
                last[i] = 1;
            }

            for (int i = 0; i < text.Length; i++)
            {
                char character = text[i];

                //foreach (var character in text)
                //{

                CharacterCheck(character, out paranteza);
                // for different characters- no pharenteses
                if (paranteza.Equals(Pharenteses.D)) continue;

                if (paranteza.Equals(Pharenteses.A1) || paranteza.Equals(Pharenteses.B1) || paranteza.Equals(Pharenteses.C1))
                    ParantezeOpenCheck(paranteza, ref counters, ref validators);

                else
                {
                    for (int x = i - 1; x >= 0; x--)
                    {
                        if (last[x] == 1)
                        {
                            Pharenteses lastP;
                            CharacterCheck(text[x], out lastP);
                            string letter1 = lastP.ToString();
                            validators[letter1[0].ToString()] = true;
                            break;
                        }
                    }
                    ExitValidator = ParantezeCloseCheck(paranteza, ref counters, ref validators);
                    if (ExitValidator == false) return ExitValidator;

                    last[i] = 0;
                    for (int x = i - 1; x >= 0; x--)
                    {
                        if (last[x] == 1)
                        {
                            last[x] = 0;
                            break;
                        }
                    }

                }

            }
            for (int i = 0; i < last.Length; i++)
            {
                if (last[i] == 1)
                {
                    ExitValidator = false;
                    break;
                }
            }
            return ExitValidator;
        }
        private static bool ParantezeCloseCheck(Pharenteses paranteze, ref Dictionary<string, int> counter, ref Dictionary<string, bool> validator)
        {
            bool v = true;
            if (paranteze.Equals(Pharenteses.A2))
            {
                v = Anulator("A", ref counter, ref validator);
                counter["A"]--;
                validator["A"] = false;
            }
            if (paranteze.Equals(Pharenteses.B2))
            {
                v = Anulator("B", ref counter, ref validator);
                counter["B"]--;
                validator["B"] = false;
            }
            if (paranteze.Equals(Pharenteses.C2))
            {
                v = Anulator("C", ref counter, ref validator);
                counter["C"]--;
                validator["C"] = false;
            }
            return v;
        }
        private static bool Anulator(string letter, ref Dictionary<string, int> count, ref Dictionary<string, bool> valid)
        {
            if (count[letter] == 0) return false;
            if (valid[letter] == false) return false;
            return true;
        }
        private static void ParantezeOpenCheck(Pharenteses paranteze, ref Dictionary<string, int> counter, ref Dictionary<string, bool> validator)
        {
            if (paranteze.Equals(Pharenteses.A1))
            {
                validator["A"] = true;
                validator["B"] = false;
                validator["C"] = false; counter["A"]++;
            }
            if (paranteze.Equals(Pharenteses.B1))
            {
                validator["B"] = true;
                validator["A"] = false;
                validator["C"] = false; counter["B"]++;
            }
            if (paranteze.Equals(Pharenteses.C1))
            {
                validator["C"] = true;
                validator["B"] = false;
                validator["A"] = false; counter["C"]++;
            }
        }
        private static void CharacterCheck(char ch, out Pharenteses paranteza)
        {
            paranteza = Pharenteses.D;

            if (ch == (char)Pharenteses.A1) paranteza = Pharenteses.A1;
            if (ch == (char)Pharenteses.A2) paranteza = Pharenteses.A2;
            if (ch == (char)Pharenteses.B1) paranteza = Pharenteses.B1;
            if (ch == (char)Pharenteses.B2) paranteza = Pharenteses.B2;
            if (ch == (char)Pharenteses.C1) paranteza = Pharenteses.C1;
            if (ch == (char)Pharenteses.C2) paranteza = Pharenteses.C2;


        }
        public static void CheckValid()
        {
            //string txt = "(()()))(()";//false
            //string txt = "([)]";// false
            //string txt = "(([]){[]})";//true
            //string txt = "()";//false
            //string txt = "()()(()";//false
            //string txt = "";//false
            string txt = "(([]){[]})";//true

            bool a = IsValid(txt);
            Console.WriteLine("- " + a);
        }
    }

}
