using Ciphers.Core;
using Ciphers.Decorator;
using Ciphers.Singletone;
namespace Ciphers.Command.commands
{
    public class EncryptWinstonCommand : BaseCipherCommand
    {
        public EncryptWinstonCommand(ICipherStrategy inner, ILogger logger, string action) : base(inner, logger, action) { }

        public override void Execute()
        {
            WinstonCipherDecorator winstonDecorator = new (inner, logger);
            winstonDecorator.PrintGeneralInf();
            winstonDecorator.Encrypt();
        }
    }
}
