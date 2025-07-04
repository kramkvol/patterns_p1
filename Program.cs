using Ciphers.Command.commands;
using Ciphers.Core;
using Ciphers.FactoryMethod;
using Ciphers.Singletone;
using Ciphers.UI;
using System;
using System.Reflection.Metadata;
using System.Windows.Forms;

namespace Ciphers
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            var logger = ConsoleLogger.Instance;

            label:
            logger.LogCharpter("Select UI mode:");
            logger.LogDebug("1. Console");
            logger.LogDebug("2. WinForms");
            logger.LogRequirement($"Write mode number: ");
            switch (Console.ReadLine())
            {
                case "1": RunConsoleApp(); break;
                case "2": RunWinFormsApp(); break;
                default:
                    {
                        logger.LogError("Invalid selection.");
                        goto label;
                    }
            }
        }

        private static void RunConsoleApp()
        {
            var logger = ConsoleLogger.Instance;
            string abc = "abcdefghijklmnopqrstuvwxyz";
            int rows = 5, cols = 5;
            string action;

            label2:
            logger.LogCharpter("Change the cipher's number (1 - Playfair, 2 - Winston, 3 - Vigenere): ");
            logger.LogRequirement($"Write cipher's number: ");
            string type = "";
            switch (Console.ReadLine()) { 
                case "1": type = "Playfair"; break;
                case "2": type = "Winston"; break;
                case "3": type = "Vigenere"; break;
                default:
                    {
                        logger.LogError("Invalid selection.");
                        goto label2;
                    }
            }

            var createdCipher = CipherFactoryMethod.Create(
                type,
                abc,
                rows,
                cols,
                UtilForText.ReadParameter("message", type),
                UtilForText.ReadParameter("key", type),
                UtilForText.ReadParameter("second key", type)
            );

            label3:
            logger.LogCharpter("Change the operation (1 - Encrypt, 2 - Decrypt): ");
            logger.LogRequirement($"Write operation: ");
            switch (Console.ReadLine())
            {
                case "1": action = "Encrypt"; break;
                case "2": action = "Decrypt"; break;
                default:
                    {
                        logger.LogError("Invalid selection.");
                        goto label3;
                    }
            }

            RunCipher runCipher = new (createdCipher, logger, action);
            runCipher.Execute();
        }

        private static void RunWinFormsApp()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CipherForm());
        }
    }
}
