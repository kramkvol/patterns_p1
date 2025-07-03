using Ciphers.Core;
using Ciphers.Singletone;
namespace Ciphers.Command.commands
{
    public class RunCipher : BaseCipherCommand
    {
        public RunCipher(ICipherStrategy inner, ILogger logger, string action) : base(inner, logger, action) { }

        public override void Execute()
        {
            CommandInvoker invoker = new();
            switch ((inner.GetCipher(), action))
            {
                case ("Playfair", "Encrypt"):
                    invoker.AddCommand(new EncryptPlayfairCommand(inner, logger, action));
                    break;
                case ("Playfair", "Decrypt"):
                    invoker.AddCommand(new DecryptPlayfairCommand(inner, logger, action));
                    break;
                case ("Winston", "Encrypt"):
                    invoker.AddCommand(new EncryptWinstonCommand(inner, logger, action));
                    break;
                case ("Winston", "Decrypt"):
                    invoker.AddCommand(new DecryptWinstonCommand(inner, logger, action));
                    break;
                case ("Vigenere", "Encrypt"):
                    invoker.AddCommand(new EncryptVigenereCommand(inner, logger, action));
                    break;
                case ("Vigenere", "Decrypt"):
                    invoker.AddCommand(new DecryptVigenereCommand(inner, logger, action));
                    break;
                default:
                    logger.LogError("Invalid selection.");
                    return;
            }

            invoker.RunAll();
            logger.LogSuccess($"{inner.GetCipher()} cipher completed successfully.");
        }
    }
}