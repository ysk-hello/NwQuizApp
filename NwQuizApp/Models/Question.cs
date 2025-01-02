using System.Text.Json.Serialization;

namespace NwQuizApp.Models
{
    public class Question
    {
        [JsonPropertyName("no")]
        public int No { get; set; }

        [JsonPropertyName("question")]
        public string? QuestionText { get; set; }

        [JsonPropertyName("image")]
        public string? QuestionImage { get; set; }

        [JsonPropertyName("options")]
        public List<string>? Options { get; set; }
        
        [JsonPropertyName("answer")]
        public string? Answer { get; set; }

        [JsonPropertyName("explains")]
        public List<string>? Explains { get; set; }
    }
}
