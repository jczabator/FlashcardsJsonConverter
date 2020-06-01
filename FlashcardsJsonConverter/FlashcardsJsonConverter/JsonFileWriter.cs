using FlashcardsJsonConverter.Model;
using System;
using System.IO;

namespace FlashcardsJsonConverter
{
  public class JsonFileWriter
  {
    private readonly string DefaultOutputPath = @"JsonOutput\flashcards.json";
    
    public OperationResult WriteToFile(string json)
    {
      try
      {
        EnsureDirectoryExists(DefaultOutputPath);
        using (StreamWriter writer = new StreamWriter(DefaultOutputPath))
        {
          writer.Write(json);
        }

        return OperationResult.Success();
      }
      catch (Exception e)
      {
        return OperationResult.Failed(e.Message);
      }      
    }

    private void EnsureDirectoryExists(string filePath)
    {
      FileInfo fileInfo = new FileInfo(filePath);
      if(!fileInfo.Directory.Exists)
      {
        Directory.CreateDirectory(fileInfo.DirectoryName);
      }
    }
  }
}
