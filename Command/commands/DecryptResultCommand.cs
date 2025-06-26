using System;
namespace CiphersWithPatterns
{
    public class DecryptResultCommand : BaseCipherCommand
    {
        public DecryptResultCommand(ICipherStrategy inner, ILogger logger) : base(inner, logger) { }

        public override void Execute()
        {
            var decCipher = new ResultCipherDecorator(inner, logger);
            decCipher.Decrypt();
        }
    }
}
