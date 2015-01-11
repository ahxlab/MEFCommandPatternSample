using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandSample
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CommandAttribute : Attribute
    {
        public string CommandName { private set; get; }

        public CommandAttribute(string commandName)
        {
            this.CommandName = commandName;
        }
    }
}
