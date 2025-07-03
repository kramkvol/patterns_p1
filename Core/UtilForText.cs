using Ciphers.Singletone;
using System;
using System.Text;

namespace Ciphers.Core
{
    public static class UtilForText
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

            StringBuilder filtered = new();
            foreach (char c in clean)
            {
                if (abc.Contains(c))
                    filtered.Append(c);
            }

            for (int i = 1; i < filtered.Length; i += 2)
            {
                if (filtered[i] == filtered[i - 1])
                {
                    filtered[i] = 'x';
                }
            }

            if (filtered.Length % 2 != 0)
            {
                filtered.Append('z');
            }

            return filtered.ToString();
        }
        public static string GetOnlyLetters(string key)
        {
            string str_before = key;
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
        public static string GetRepeatedKey(string message, string key)
        {
            string result = "";
            string preprocess_key = UtilForText.GetOnlyLetters(key);
            string preprocess_message = UtilForText.GetOnlyLetters(message);

            int int_div = preprocess_message.Length / preprocess_key.Length;
            int ostatok = preprocess_message.Length - (preprocess_key.Length * int_div);
            for (int i = 0; i < int_div; i++)
            {
                result += preprocess_key;
            }
            for (int z = 0; z < ostatok; z++)
            {
                result += preprocess_key[z];
            }
            return result.ToLower();
        }

        public static string ReadParameter(string parameter, string type)
        {
            if (parameter == "second key" && (type == "Playfair" || type == "Vigenere")) { return null; }
            var logger = ConsoleLogger.Instance;
            logger.LogRequirement($"Write {parameter}: ");
            return Console.ReadLine();
        }
    }
}