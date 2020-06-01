using FlashcardsJsonConverter.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace FlashcardsJsonConverter
{
  public class Converter
  {
    public OperationResult<string> ConvertToJson(string filePath)
    {
      try
      {
        var text = File.ReadAllText(filePath);
        var lines = text.Split("[", StringSplitOptions.RemoveEmptyEntries);

        if (lines.Length % 2 == 1)
        {
          return OperationResult<string>.Failed("Failed on parsing questions and answers file. Missing question or answer");
        }

        var flashcards = GetFlashcards(lines);
        var flashcardsJson = JsonConvert.SerializeObject(flashcards);

        return OperationResult<string>.Success(flashcardsJson);
      }
      catch (Exception e)
      {

        return OperationResult<string>.Failed(e.Message);
      }            
    }   

    private List<Flashcard> GetFlashcards(string[] lines)
    {
      int counter = 1;
      List<Flashcard> flashcards = new List<Flashcard>();

      for (int i = 0; i < lines.Length - 1; i += 2)
      {
        // Todo: pass flashcardSetId from console parameters
        flashcards.Add(new Flashcard
        {
          Id = counter,
          FlashcardSetId = 1,
          IsLearned = false,
          IsPictureAnswer = false,
          PictureBlob = string.Empty,
          Name = lines[i].Replace("\r\n", " ")
          .Replace("\t", string.Empty)
          .Replace("\"", "'")
          .Trim(),
          Text = lines[i + 1].Replace("\r\n", " ")
          .Replace("\t", string.Empty)
          .Replace("\"", "'")
          .Trim()
        });

        counter++;
      }

      return flashcards;
    }
  }
}
