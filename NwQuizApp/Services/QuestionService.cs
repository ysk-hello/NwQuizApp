using NwQuizApp.Models;
using System.Text.Json;

namespace NwQuizApp.Services
{
    public class QuestionService
    {
        public async Task<List<Question>> LoadQuestionsAsync()
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("questions.json");
            using var reader = new StreamReader(stream);
            var json = await reader.ReadToEndAsync();
            return JsonSerializer.Deserialize<List<Question>>(json) ?? new List<Question>();
        }
    }
}
