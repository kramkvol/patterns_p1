using Ciphers.Core;
using Ciphers.Decorator;
using Ciphers.Singletone;
namespace Ciphers.Command.commands
{
    public class EncryptPlayfairCommand : BaseCipherCommand
    {
        public EncryptPlayfairCommand(ICipherStrategy inner, ILogger logger, string action) : base(inner, logger, action) { }

        public override void Execute()
        {
            PlayfairCipherDecorator playfairDecorator = new (inner, logger);
            playfairDecorator.PrintGeneralInf();
            playfairDecorator.Encrypt();
        }
    }
}
