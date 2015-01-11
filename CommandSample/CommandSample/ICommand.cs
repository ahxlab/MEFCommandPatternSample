using System.ComponentModel.Composition;

namespace CommandSample
{
    [InheritedExport]
    public interface ICommand
    {
        void Execute(CommandContext context, string[] args);
    }
}
