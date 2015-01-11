using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandSample.Commands
{
    [Command("sum")]
    public class SumCommand : ICommand
    {
        public void Execute(CommandContext context, string[] args)
        {
            try
            {
                var nums = args.Select((a) => Convert.ToInt32(a));
                Console.WriteLine("{0}", nums.Sum());
            }
            catch(Exception e)
            {
                Console.WriteLine("[sum] エラー:" + e.Message);
            }
        }
    }
}
