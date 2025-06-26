using System;

namespace CiphersWithPatterns
{
    public class InfoCipherCommand : BaseCipherCommand
    {
        public InfoCipherCommand(ICipherStrategy inner, ILogger logger) : base(inner, logger) { }

        public override void Execute()
        {
            var decCipher = new InfoCipherDecorator(inner, logger);
            decCipher.PrintGeneralInf();
        }
    }
}
