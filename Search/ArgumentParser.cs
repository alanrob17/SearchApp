using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search
{
    public static class ArgumentParser
    {
        public static IEnumerable<string> ParseArguments(IList<string> args)
        {
            if (args.Count == 1 && args[0].ToLowerInvariant().Contains("|"))
            {
                return args[0].Split('|');
            }
            return args;
        }
    }
}
