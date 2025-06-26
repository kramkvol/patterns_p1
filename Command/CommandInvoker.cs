using System.Collections.Generic;

namespace CiphersWithPatterns
{
    public class CommandInvoker
    {
        private readonly List<ICipherCommand> commands = new List<ICipherCommand>();

        public void AddCommand(ICipherCommand command)
        {
            commands.Add(command);
        }

        public void RunAll()
        {
            foreach (var command in commands)
            {
                command.Execute();
            }
        }
    }
}

