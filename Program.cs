using System;
using System.Windows.Forms;
using ThePlayfairCipher;

namespace CiphersWithPatterns
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            var logger = ConsoleLogger.Instance;
            logger.LogCharpter("Select UI mode:");
            logger.LogDebug("1. Console");
            logger.LogDebug("2. WinForms");

            switch (Console.ReadLine())
            {
                case "1":
                    RunConsoleApp();
                    break;
                case "2":
                    RunWinFormsApp();
                    break;
                default:
                    logger.LogError("Invalid selection.");
                    return;
            }
        }

        static void RunConsoleApp()
        {
            var logger = ConsoleLogger.Instance;
            logger.LogCharpter("Change the cipher's number (1 - Playfair, 2 - Winston, 3 - Vigenere): ");
            string type = "";
            switch (Console.ReadLine()) { 
                case "1":
                    type = "Playfair";
                    break;
                case "2":
                    type = "Winston";
                    break;
                case "3":
                    type = "Vigenere";
                    break;
                default:
                    logger.LogError("Invalid selection.");
                    return;
            }
            try
            {
                string abc = "abcdefghijklmnopqrstuvwxyz";
                int rows = 5, cols = 5;

                logger.LogInfo($"Running {type} cipher...");
                var baseCipher = CipherFactoryMethod.Create(
                    type, 
                    abc, 
                    rows, 
                    cols, 
                    readParameter("message", type),
                    readParameter("key", type),
                    readParameter("second key", type)
                );
                var cipher = new LoggingCipherDecorator(baseCipher);
                LoggingCipherDecorator decorator = new LoggingCipherDecorator(cipher);

                var context = new CipherContext(cipher);
                string encrypted = context.Encrypt();
                string decrypted = context.Decrypt(encrypted);
                string cleaned = context.CleanDecrypt(decrypted);

                logger.LogSuccess($"{type} cipher completed successfully.\n");
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception in {type} cipher: {ex.Message}");
            }
        }

        static void RunWinFormsApp()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        private static string readParameter(string parameter, string type)
        {
            if (parameter == "second key" && (type == "Playfair" || type == "Vigenere")) { return null; }
            var logger = ConsoleLogger.Instance;
            logger.LogRequirement($"Write {parameter}: ");
            return Console.ReadLine();
        }
    }
}
