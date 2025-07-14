using System.Net.Http;
using System.Threading.Tasks;
using BookFinder.Model;
using Newtonsoft.Json.Linq;

namespace BookFinder.Services
{
    internal class GoogleBooksApiService : IBookApiService
    {
        public async Task<List<Book>> SearchBooksAsync(string query)
        {
            using var client = new HttpClient();
            string url = $"https://www.googleapis.com/books/v1/volumes?q={Uri.EscapeDataString(query)}";
            string json = await client.GetStringAsync(url);

            var results = new List<Book>();
            var data = JObject.Parse(json);

            foreach (var item in data["items"] ?? new JArray())
            {
                var volume = item["volumeInfo"];
                results.Add(new Book(
                    volume?["title"]?.ToString(),
                    string.Join(", ", volume?["authors"] ?? new JArray()),
                    volume?["publishedDate"]?.ToString()
                ));
            }

            return results;
        }
    }
}
