using Ciphers.Decorator;
using Ciphers.Singletone;
using Ciphers.Strategy;
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
