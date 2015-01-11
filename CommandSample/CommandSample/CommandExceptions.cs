using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandSample
{
    public class NotFoundCommandException : Exception
    {
        public NotFoundCommandException(string msg) : base(msg) { }
    }

    public class CommandAmbiguityException : Exception
    {
        public CommandAmbiguityException(string msg) : base(msg) { }
    }
}
