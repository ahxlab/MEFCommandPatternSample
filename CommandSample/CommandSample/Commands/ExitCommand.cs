using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandSample.Commands
{
    [Command("exit")]
    public class ExitCommand :ICommand
    {
        public void Execute(CommandContext context, string[] args)
        {
            throw new ApplicationExitException();
        }
    }

    public class ApplicationExitException : Exception
    {
        public ApplicationExitException() : base() { }
    }
}
