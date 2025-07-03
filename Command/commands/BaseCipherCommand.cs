using Ciphers.Core;
using Ciphers.Singletone;

namespace Ciphers.Command.commands
{
    public class BaseCipherCommand : ICipherCommand
    {
        protected ICipherStrategy inner;
        protected ILogger logger;
        protected string action;

        public BaseCipherCommand(ICipherStrategy inner, ILogger logger, string action)
        {
            this.inner = inner;
            this.logger = logger;
            this.action = action;
        }

        public virtual void Execute() { }
    }
}
