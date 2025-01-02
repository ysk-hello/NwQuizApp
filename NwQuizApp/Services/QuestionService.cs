using NwQuizApp.Models;
using System.Text.Json;

namespace NwQuizApp.Services
{
    public class QuestionService
    {
        public async Task<List<Question>> LoadQuestionsAsync(string year)
        {
            var fileName = $"questions_{year}.json";

            using var stream = await FileSystem.OpenAppPackageFileAsync(fileName);
            using var reader = new StreamReader(stream);
            var json = await reader.ReadToEndAsync();
            return JsonSerializer.Deserialize<List<Question>>(json) ?? new List<Question>();
        }
    }
}
