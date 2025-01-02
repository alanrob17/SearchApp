using Search.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Search
{
    public class Program
    {
        static int Main(string[] args)
        {
            var argList = ArgumentParser.ParseArguments(args).ToArray();

            if (argList.Length == 0)
            {
                PrintUsage();
                return 1;
            }

            var directorySearcher = new DirectorySearcher(@"G:\Training\");
            var searchResults = directorySearcher.Search(argList);

            ResultsPrinter.Print(searchResults);

            return 0;
        }

        private static void PrintUsage()
        {
            Console.WriteLine("No search terms provided.");
        }
    }
}
