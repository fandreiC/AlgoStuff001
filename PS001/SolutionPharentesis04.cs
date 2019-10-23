using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS001
{
    class SolutionPharentesis04
    {
        static private bool CheckThem(string text)
        {
            bool response = true;
            char[] chValue = text.ToCharArray();
            int[] shadow = new int[chValue.Length];
            for (int i = 0; i < shadow.Length; i++)
            {
                shadow[i] = 1;
            }
            Dictionary<string, char> paranteze = new Dictionary<string, char>()
            {
                { "A1",'('},  { "A2",')'},
                { "B1",'['},  { "B2",']'},
                { "C1",'{'},  { "C2",'}'},
                { "Z",'0'}
            };
            char pteze = paranteze.FirstOrDefault(x => x.Key == "Z").Value;
            string chKey = paranteze["Z"].ToString();
            Dictionary<string, int> Counter = new Dictionary<string, int>()
            {
                {"A1",0 },    {"B1",0 } ,    {"C1",0 }
            };
            Dictionary<string, bool> Validator = new Dictionary<string, bool>();
            Validator.Add("A1", false); Validator.Add("B1", false); Validator.Add("C1", false);

            for (int i = 0; i < chValue.Length; i++)
            {
                CharacterCheck(chValue[i], ref paranteze, ref chKey);

                if (chKey.Equals("Z")) { shadow[i] = 0; continue; }
                //if (paranteze.Keys.Any(x => x.Equals(chkey, StringComparison.CurrentCultureIgnoreCase)))                 

                int indexOfKey = Array.IndexOf(paranteze.Keys.ToArray(), chKey);
                if (indexOfKey == 0 || indexOfKey == 2 || indexOfKey == 4)
                    VerificareParantezeDeschise(ref paranteze, ref chKey, ref Counter, ref Validator);

                else
                {
                    for (int x = i - 1; x >= 0; x--)
                    {
                        if (shadow[x] == 1)
                        { //chValue[x]                           
                            var key = paranteze.Where(p => p.Value.ToString().Contains(chValue[x].ToString()))
                                .Select(p => p.Key.ToString());
                            string keyy = string.Empty;
                            foreach (var item in key)
                            {
                                keyy = item;
                            }
                            Validator[keyy.ToString()] = true; break;
                        }// bad
                    }

                    if (paranteze.ElementAt(1).Key.Equals(chKey) || paranteze.ElementAt(3).Key.Equals(chKey)
                       || paranteze.ElementAt(5).Key.Equals(chKey))
                        VerificareParantezeInschise(ref paranteze, ref chKey, ref Counter,
                            ref response, ref Validator);
                    if (!response) break;

                    shadow[i] = 0;
                    for (int x = i - 1; x >= 0; x--)
                    {
                        if (shadow[x] == 1) { shadow[x] = 0; break; }
                    }
                }
            }
            for (int i = 0; i < shadow.Length; i++)
            {
                if (shadow[i] == 1) { response = false; break; }
            }

            return response;
        }
        private static void VerificareParantezeInschise(ref Dictionary<string, char> paranteze,
           ref string chKey, ref Dictionary<string, int> counter, ref bool response,
           ref Dictionary<string, bool> valid)
        {
            string key = chKey;
            int index = Array.IndexOf(paranteze.Keys.ToArray(), chKey);
            key = paranteze.ElementAt(index - 1).Key;
            if (counter[key] <= 0) { response = false; return; }
            if (valid[key] == false) { response = false; return; }
            counter[key]--;
            valid[key] = false;
        }
        private static void VerificareParantezeDeschise(ref Dictionary<string, char> paranteze,
            ref string chKey, ref Dictionary<string, int> counter, ref Dictionary<string, bool> valid)
        {
            counter[chKey]++;
            valid[valid.ElementAt(0).Key] = valid[valid.ElementAt(1).Key] = valid[valid.ElementAt(2).Key] = false;
            valid[chKey] = true;

        }
        private static void CharacterCheck(char ch, ref Dictionary<string, char> paran, ref string uncaracter)
        {
            uncaracter = paran.FirstOrDefault(x => x.Value == ch).Key;
            if (uncaracter == null) uncaracter = "Z";
            //Console.WriteLine("key {0} , Value {1}",uncaracter,paran[uncaracter]);
        }

        static internal void ScreenMe()
        {
            //string txt = "(()()))(()";//false
            //string txt = "([)]";// false
            //string txt = "(([]){[]})";//true
            //string txt = "()";//false
            //string txt = "()()(()";//false
            //string txt = "";//false
            string txt = " ))(([]){[]})";//fasle

            bool a = CheckThem(txt);
            Console.WriteLine("Your text is : {0}", a);
        }
    }
}
