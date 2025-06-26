using System;
using System.Collections.Generic;
using System.Linq;
namespace CiphersWithPatterns { 
    public abstract class BaseCipherCommand : ICipherCommand 
    {
        protected ICipherStrategy inner;
        protected ILogger logger;

        public BaseCipherCommand(ICipherStrategy inner, ILogger logger)
        {
            this.inner = inner;
            this.logger = logger;
        }

        public virtual void Execute() { }
    }
}
