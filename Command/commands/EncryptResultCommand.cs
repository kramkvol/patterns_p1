using System;
namespace CiphersWithPatterns
{
    public class EncryptResultCommand : BaseCipherCommand
    {
        public EncryptResultCommand(ICipherStrategy inner, ILogger logger) : base(inner, logger) { }


        public override void Execute()
        {
            var decCipher = new ResultCipherDecorator(inner, logger);
            decCipher.Encrypt();
        }
    }
}
