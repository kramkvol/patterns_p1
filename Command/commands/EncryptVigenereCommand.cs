using Ciphers.Core;
using Ciphers.Decorator;
using Ciphers.Singletone;
namespace Ciphers.Command.commands
{
    public class EncryptVigenereCommand : BaseCipherCommand
    {
        public EncryptVigenereCommand(ICipherStrategy inner, ILogger logger, string action) : base(inner, logger, action) { }

        public override void Execute()
        {
            VigenereCipherDecorator cipherDecorator = new (inner, logger);
            cipherDecorator.PrintGeneralInf();
            cipherDecorator.Encrypt();
        }
    }
}
