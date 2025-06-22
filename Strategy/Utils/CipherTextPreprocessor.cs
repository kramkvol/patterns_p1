using System.Linq;
using System.Text;

namespace CiphersWithPatterns
{
    public static class CipherTextPreprocessor
    {
        public static string GetUniqLettersReplace(string key, string abc)
        {
            string str_before = key.ToLower().Replace('j', 'i');
            string result = "";

            foreach (char c in str_before)
            {
                if (char.IsLetter(c) && !result.Contains(c) && abc.Contains(c))
                {
                    result += c;
                }
            }

            return result;
        }

        public static string GetBigramText(string message, string abc)
        {
            string clean = message.ToLower().Replace('j', 'i');
            StringBuilder result = new StringBuilder();

            foreach (char c in clean)
            {
                if (char.IsLetter(c) && abc.Contains(c))
                    result.Append(c);
            }

            StringBuilder bigrams = new StringBuilder();
            int i = 0;

            while (i < result.Length)
            {
                char first = result[i];
                char second = (i + 1 < result.Length) ? result[i + 1] : abc[abc.Length-1];

                if (first == second)
                {
                    bigrams.Append(first);
                    bigrams.Append('x');
                    i += 1;
                }
                else
                {
                    bigrams.Append(first);
                    bigrams.Append(second);
                    i += 2;
                }
            }

            if (bigrams.Length % 2 != 0)
                bigrams.Append(abc[abc.Length - 1]);

            return bigrams.ToString();
        }

        public static string PostprocessDecrypted(string decrypted)
        {
            string result = decrypted.Replace("x", "");
            if (result.EndsWith("z"))
                result = result.Substring(0, result.Length - 1);
            return result;
        }

        public static string GetOnlyLetters(string key)
        {
            string str_before = key.ToUpper();
            string result = "";

            foreach (char c in str_before)
            {
                if (char.IsLetter(c))
                {
                    result += c;
                }
            }

            return result;
        }

        public static string GetLongKey(string message, string key)
        {
            string result = "";
            int int_div = GetOnlyLetters(message).Length / GetOnlyLetters(key).Length;
            int ostatok = GetOnlyLetters(message).Length % GetOnlyLetters(key).Length;
            for (int i = 0; i < int_div; i++)
            {
                result += key;
            }
            for (int z = 0; z < ostatok; z++)
            {
                result += key[z];
            }
            return result;
        }
    }
}
