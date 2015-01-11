using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace CommandSample
{
    public class CommandManager
    {
        private static Dictionary<string, ICommand> _commandCache;
        private static Lazy<IList<ICommand>> _commands = new Lazy<IList<ICommand>>(GetCommands);

        public CommandManager()
        {

        }

        public bool TryHandleCommand(string commandName, string[] args)
        {
            ICommand cmd = null;
            MatchCommand(commandName, out cmd);

            if (cmd == null)
                return false;

            var context = new CommandContext();
            cmd.Execute(context, args);

            return true;
        }

        private void MatchCommand(string commandName, out ICommand cmd)
        {
            if(_commandCache == null)
            {
                var commands = from c in _commands.Value
                               let commandAttribute = c.GetType()
                                                       .GetCustomAttributes(true)
                                                       .OfType<CommandAttribute>()
                                                       .FirstOrDefault()
                               where commandAttribute != null
                               select new
                               {
                                   Name = commandAttribute.CommandName,
                                   Command = c
                               };

                _commandCache = commands.ToDictionary(c => c.Name,
                                                      c => c.Command,
                                                      StringComparer.OrdinalIgnoreCase);
            }

            IList<string> candidates = candidates = _commandCache.Keys.Where(comm => comm.Equals(commandName, StringComparison.OrdinalIgnoreCase)).ToList();

            if(candidates.Count == 0)
            {
                throw new NotFoundCommandException(string.Format("該当するコマンドが見つかりませんでした。 : {0}", commandName));
            }

            if(candidates.Count > 1)
            {
                throw new CommandAmbiguityException(string.Format("コマンド名があいまいです。複数コマンドが該当しました。: {0}", commandName));
            }

            _commandCache.TryGetValue(candidates[0], out cmd);
        }

        private static IList<ICommand> GetCommands()
        {
            var catalog = new AssemblyCatalog(typeof(CommandManager).Assembly);
            var compositionContainer = new CompositionContainer(catalog);
            return compositionContainer.GetExportedValues<ICommand>().ToList();
        }
    }
}
