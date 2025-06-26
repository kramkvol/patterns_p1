using System;

namespace CiphersWithPatterns
{
    public class RunAllCipherCommand : BaseCipherCommand
    {
        public RunAllCipherCommand(ICipherStrategy inner, ILogger logger) : base(inner, logger) { }

        public override void Execute()
        {
            CommandInvoker invoker = new CommandInvoker();
            invoker.AddCommand(new InfoCipherCommand(inner, logger));
            invoker.AddCommand(new EncryptResultCommand(inner, logger));
            invoker.AddCommand(new DecryptResultCommand(inner, logger));
            invoker.RunAll();
            logger.LogSuccess($"{inner.GetType()} cipher completed successfully.\n");
        }
    }

}
