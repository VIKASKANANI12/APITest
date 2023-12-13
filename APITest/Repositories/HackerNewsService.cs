using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using APITest.Model;
using APITest.Services;

namespace APITest.Repositories
{
    public class HackerNewsService : IHackerNewsService
    {
        private readonly HttpClient _httpClient;

        public HackerNewsService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<IEnumerable<Story>> GetBestStoriesAsync(int n)
        {
            var bestStoriesIds = await GetBestStoriesIdsAsync();
            var stories = new List<Story>();

            foreach (var storyId in bestStoriesIds.Take(n))
            {
                var story = await GetStoryDetailsAsync(storyId);
                if (story != null)
                {
                    stories.Add(story);
                }
            }

            return stories;
        }

        private async Task<IEnumerable<int>> GetBestStoriesIdsAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<int[]>("https://hacker-news.firebaseio.com/v0/beststories.json");
            return response ?? Array.Empty<int>();
        }

        public async Task<Story> GetStoryDetailsAsync(int storyId)
        {
            var response = await _httpClient.GetAsync($"https://hacker-news.firebaseio.com/v0/item/{storyId}.json");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var content = await response.Content.ReadAsStringAsync();
            var story = JsonSerializer.Deserialize<Story>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return story;
        }
    }

}
