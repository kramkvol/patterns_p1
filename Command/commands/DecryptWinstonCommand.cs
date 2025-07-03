using Ciphers.Core;
using Ciphers.Decorator;
using Ciphers.Singletone;
namespace Ciphers.Command.commands
{
    public class DecryptWinstonCommand : BaseCipherCommand
    {
        public DecryptWinstonCommand(ICipherStrategy inner, ILogger logger, string action) : base(inner, logger, action) { }

        public override void Execute()
        {
            WinstonCipherDecorator winstonDecorator = new (inner, logger);
            winstonDecorator.PrintGeneralInf();
            winstonDecorator.Decrypt();
            winstonDecorator.CleanDecrypt();
        }
    }
}
