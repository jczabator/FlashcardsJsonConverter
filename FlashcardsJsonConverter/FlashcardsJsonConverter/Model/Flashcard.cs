using Newtonsoft.Json;

namespace FlashcardsJsonConverter.Model
{
  public class Flashcard
  {
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("flashcardSetId")]
    public int FlashcardSetId { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("text")]
    public string Text { get; set; }

    [JsonProperty("isPictureAnswer")]
    public bool IsPictureAnswer { get; set; }

    [JsonProperty("pictureBlob")]
    public string PictureBlob { get; set; }

    [JsonProperty("isLearned")]
    public bool IsLearned { get; set; } 
  }
}
