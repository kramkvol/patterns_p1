using Ciphers.Decorator;
using Ciphers.Singletone;
using Ciphers.Strategy;

namespace Ciphers.Command.commands
{
    public class DecryptPlayfairCommand : BaseCipherCommand
    {
        public DecryptPlayfairCommand(ICipherStrategy inner, ILogger logger, string action) : base(inner, logger, action) { }

        public override void Execute()
        {
            PlayfairCipherDecorator playfairDecorator = new (inner, logger);
            playfairDecorator.PrintGeneralInf();
            playfairDecorator.Decrypt();
            playfairDecorator.CleanDecrypt();
        }
    }
}
