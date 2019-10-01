using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    public class KorEngConverter
    {
        private static string[] FirstLetters = { "ㄱ", "ㄲ", "ㄴ", "ㄷ", "ㄸ", "ㄹ", "ㅁ", "ㅂ", "ㅃ", "ㅅ", "ㅆ", "ㅇ", "ㅈ", "ㅉ", "ㅊ", "ㅋ", "ㅌ", "ㅍ", "ㅎ" };
        private static string[] MidLetters = { "ㅏ", "ㅐ", "ㅑ", "ㅒ", "ㅓ", "ㅔ", "ㅕ", "ㅖ", "ㅗ", "ㅘ", "ㅙ", "ㅚ", "ㅛ", "ㅜ", "ㅝ", "ㅞ", "ㅟ", "ㅠ", "ㅡ", "ㅢ", "ㅣ" };
        private static string[] LastLetters = { "", "ㄱ", "ㄲ", "ㄳ", "ㄴ", "ㄵ", "ㄶ", "ㄷ", "ㄹ", "ㄺ", "ㄻ", "ㄼ", "ㄽ", "ㄾ", "ㄿ", "ㅀ", "ㅁ", "ㅂ", "ㅄ", "ㅅ", "ㅆ", "ㅇ", "ㅈ", "ㅊ", "ㅋ", "ㅌ", "ㅍ", "ㅎ" };
        private static Dictionary<string, string> KorEngTable = new Dictionary<string,string>();
        static KorEngConverter()
        {
            // 자음
            KorEngTable.Add("", "");
            KorEngTable.Add("ㄱ", "r");
            KorEngTable.Add("ㄲ", "rr");
            KorEngTable.Add("ㄳ", "rt");
            KorEngTable.Add("ㄴ", "s");
            KorEngTable.Add("ㄵ", "sw");
            KorEngTable.Add("ㄶ", "sg");
            KorEngTable.Add("ㄷ", "e");
            KorEngTable.Add("ㄸ", "ee");
            KorEngTable.Add("ㄹ", "f");
            KorEngTable.Add("ㄺ", "fr");
            KorEngTable.Add("ㄻ", "fa");
            KorEngTable.Add("ㄼ", "fq");
            KorEngTable.Add("ㄽ", "ft");
            KorEngTable.Add("ㄾ", "fx");
            KorEngTable.Add("ㄿ", "fv");
            KorEngTable.Add("ㅀ", "fg");
            KorEngTable.Add("ㅁ", "a");
            KorEngTable.Add("ㅂ", "q");
            KorEngTable.Add("ㅃ", "qq");
            KorEngTable.Add("ㅄ", "qt");
            KorEngTable.Add("ㅅ", "t");
            KorEngTable.Add("ㅆ", "tt");
            KorEngTable.Add("ㅇ", "d");
            KorEngTable.Add("ㅈ", "w");
            KorEngTable.Add("ㅉ", "ww");
            KorEngTable.Add("ㅊ", "c");
            KorEngTable.Add("ㅋ", "z");
            KorEngTable.Add("ㅌ", "x");
            KorEngTable.Add("ㅍ", "v");
            KorEngTable.Add("ㅎ", "g");

            // 모음
            KorEngTable.Add("ㅏ", "k");
            KorEngTable.Add("ㅐ", "o");
            KorEngTable.Add("ㅑ", "i");
            KorEngTable.Add("ㅒ", "o");
            KorEngTable.Add("ㅓ", "j");
            KorEngTable.Add("ㅔ", "p");
            KorEngTable.Add("ㅕ", "u");
            KorEngTable.Add("ㅖ", "p");
            KorEngTable.Add("ㅗ", "h");
            KorEngTable.Add("ㅘ", "hk");
            KorEngTable.Add("ㅙ", "ho");
            KorEngTable.Add("ㅚ", "hl");
            KorEngTable.Add("ㅛ", "y");
            KorEngTable.Add("ㅜ", "n");
            KorEngTable.Add("ㅝ", "nj");
            KorEngTable.Add("ㅞ", "np");
            KorEngTable.Add("ㅟ", "nl");
            KorEngTable.Add("ㅠ", "b");
            KorEngTable.Add("ㅡ", "m");
            KorEngTable.Add("ㅢ", "ml");
            KorEngTable.Add("ㅣ", "l");
        }

        private static int GetAInt(int unicode)
            => (unicode - 44032) / (21 * 28);
        
        private static int GetBInt(int unicode)
            => (unicode - 44032 - (GetAInt(unicode) * 21 * 28)) / 28;
        
        private static int GetCInt(int unicode)
            => (unicode - 44032 - (GetAInt(unicode) * 21 * 28) - (GetBInt(unicode) * 28));
        
        private static string GetAString(int i)
            => FirstLetters[i];
        
        private static string GetBString(int i)
            => MidLetters[i];       
        private static string GetCString(int i)
            => LastLetters[i];
        private static string Switch(string korLetter)
            => KorEngTable[korLetter];

        // 0
        private static List<int> GetUnicodes(string korSyllables)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(korSyllables);
            List<int> unicodes = new List<int>();
            for (int i = 0; i < bytes.Length; i += 2)
            {
                int unicode = bytes[i + 1] * 256 + bytes[i + 0];
                unicodes.Add(unicode);
            }

            return unicodes;
        }

        // 1
        private static string Resolve(string korSyllables)
        {
            List<int> unicodes = GetUnicodes(korSyllables);

            string result = "";
            foreach (int unicode in unicodes)
            {
                //check
                if (unicode < 44032 || unicode > 55199)
                {
                    byte[] bytes = BitConverter.GetBytes((short)unicode);
                    result += Encoding.Unicode.GetString(bytes);
                    continue;
                }

                result += GetAString(GetAInt(unicode));
                result += GetBString(GetBInt(unicode));
                result += GetCString(GetCInt(unicode));
            }

            return result;
        }

        // 2
        public static string Convert(string korString)
        {
            char[] chars = Resolve(korString).ToCharArray();
            string result = "";
            foreach (char c in chars)
            {
                try
                {
                    string eng = Switch(c.ToString());
                    result += eng;
                }
                catch (KeyNotFoundException)
                {
                    result += c.ToString();
                }

            }

            return result;
        }
           
    } // class
} // namespace
