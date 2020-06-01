using CommandLine;

namespace FlashcardsJsonConverter
{
  public class CommandLineOptions
  {
    [Option('p', "path", Required = true, HelpText = "Flashcards input file path")]
    public string Path { get; set; }
  }
}
