using Ciphers.Command.commands;
using Ciphers.FactoryMethod;
using Ciphers.Singletone;
using Ciphers.UI;
using System;
using System.Windows.Forms;

namespace Ciphers
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
                case "1": RunConsoleApp(); break;
                case "2": RunWinFormsApp(); break;
                default: 
                    logger.LogError("Invalid selection."); 
                    return;
            }
        }

        private static void RunConsoleApp()
        {
            var logger = ConsoleLogger.Instance;
            string abc = "abcdefghijklmnopqrstuvwxyz";
            int rows = 5, cols = 5;
            string action;

            logger.LogCharpter("Change the cipher's number (1 - Playfair, 2 - Winston, 3 - Vigenere): ");
            string type = "";
            switch (Console.ReadLine()) { 
                case "1": type = "Playfair"; break;
                case "2": type = "Winston"; break;
                case "3": type = "Vigenere"; break;
                default:
                    logger.LogError("Invalid selection.");
                    return;
            }

            var createdCipher = CipherFactoryMethod.Create(
                type,
                abc,
                rows,
                cols,
                ReadParameter("message", type),
                ReadParameter("key", type),
                ReadParameter("second key", type)
            );

            logger.LogCharpter("Change the operation (1 - Encrypt, 2 - Decrypt): ");

            switch (Console.ReadLine())
            {
                case "1": action = "Encrypt"; break;
                case "2": action = "Decrypt"; break;
                default:
                    logger.LogError("Invalid selection.");
                    return;
            }

            RunCipher runCipher = new (createdCipher, logger, action);
            runCipher.Execute();
        }

        private static string ReadParameter(string parameter, string type)
        {
            if (parameter == "second key" && (type == "Playfair" || type == "Vigenere")) { return null; }
            var logger = ConsoleLogger.Instance;
            logger.LogRequirement($"Write {parameter}: ");
            return Console.ReadLine();
        }

        private static void RunWinFormsApp()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CipherForm());
        }
    }
}
