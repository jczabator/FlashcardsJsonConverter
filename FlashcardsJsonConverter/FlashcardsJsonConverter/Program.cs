using CommandLine;
using System;

namespace FlashcardsJsonConverter
{
  class Program
  {
    static void Main(string[] args)
    {
      Parser.Default.ParseArguments<CommandLineOptions>(args)
        .WithParsed<CommandLineOptions>(o =>
        {

          FlashcardsManager manager = new FlashcardsManager();
          manager.Process(o.Path);
          Console.ReadKey();
        });
    }
  }
}
