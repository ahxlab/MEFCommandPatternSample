using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandSample.Commands
{
    [Command("hoge")]
    public class HogeCommand :ICommand
    {
        public void Execute(CommandContext context, string[] args)
        {
            Console.WriteLine("ほげげ！！！");
        }
    }
}
