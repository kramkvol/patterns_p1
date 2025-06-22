namespace CiphersWithPatterns.Factory
{
    using System;

    namespace ThePlayfairCipher.Core
    {
        public static class CipherFactoryMethod
        {
            public static ICipherStrategy Create(
                string type,
                string abc,
                int rows,
                int cols,
                string message,
                string key1,
                string key2)
            {
                switch (type)
                {
                    case "Playfair":
                        if (string.IsNullOrWhiteSpace(type) || string.IsNullOrWhiteSpace(abc) || string.IsNullOrWhiteSpace(message) || string.IsNullOrWhiteSpace(key1))
                            throw new ArgumentException("Parameters cannot be null or empty.");
                        return new PlayfairCipherStrategy(abc, rows, cols, message, key1);
                    case "Winston":
                        if (string.IsNullOrWhiteSpace(type) || string.IsNullOrWhiteSpace(abc) || string.IsNullOrWhiteSpace(message) || string.IsNullOrWhiteSpace(key1) || string.IsNullOrWhiteSpace(key2))
                            throw new ArgumentException("Parameters cannot be null or empty.");
                        return new WinstonCipherStrategy(message, abc, rows, cols, key1, key2);
                    case "Vigenere":
                        if (string.IsNullOrWhiteSpace(type) || string.IsNullOrWhiteSpace(message) || string.IsNullOrWhiteSpace(key1))
                            throw new ArgumentException("Parameters cannot be null or empty.");
                        return new VigenereCipherStrategy(abc, message, key1);
                    default:
                        throw new NotSupportedException($"Cipher type '{type}' is not supported.");
                }
            }
        }
    }

}
