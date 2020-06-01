using FlashcardsJsonConverter.Model;
using System;

namespace FlashcardsJsonConverter
{
  public class FlashcardsManager
  {
    private readonly Converter _converter;
    private readonly JsonFileWriter _writer;

    public FlashcardsManager()
    {
      _converter = new Converter();
      _writer = new JsonFileWriter();
    }

    public void Process(string path)
    {      
      OperationResult<string> convertedJson = _converter.ConvertToJson(path);
      if (convertedJson.IsFailed)
      {
        Console.WriteLine(convertedJson.Message);
        return;
      }


      OperationResult writeFileResult = _writer.WriteToFile(convertedJson.Value);
      if (writeFileResult.IsFailed)
      {
        Console.WriteLine(writeFileResult.Message);
        return;
      }

      Console.WriteLine("Success");
    }
  }
}
