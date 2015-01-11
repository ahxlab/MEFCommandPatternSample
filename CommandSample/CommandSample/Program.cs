using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var cmdMng = new CommandManager();

            while(true)
            {
                var lineStr = Console.ReadLine();
                var lineStrParts = lineStr.Split(' ');

                string cmdName = lineStrParts[0];
                string[] cmdArgs = new string[0];
                if(lineStrParts.Length > 1)
                {
                    cmdArgs = lineStrParts.Skip(1).ToArray();
                }

                try
                {
                    cmdMng.TryHandleCommand(cmdName, cmdArgs);
                }
                catch (NotFoundCommandException exc1) 
                {
                    Console.WriteLine(exc1.Message);
                }
                catch (CommandAmbiguityException exc2)
                {
                    Console.WriteLine(exc2.Message);
                }
                catch (Commands.ApplicationExitException)
                {
                    break;
                }
            }
        }
    }
}
