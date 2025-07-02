using Ciphers.Command.commands;
using System.Collections.Generic;
namespace Ciphers.Command
{
    public class CommandInvoker
    {
        private readonly List<BaseCipherCommand> commands = new();

        public void AddCommand(BaseCipherCommand command) => commands.Add(command);

        public void RunAll()
        {
            foreach (var command in commands)
            {
                command.Execute();
            }
        }
    }
}

