using APITest.Model;

namespace APITest.Services
{
    public interface IHackerNewsService
    {
        Task<IEnumerable<Story>> GetBestStoriesAsync(int n);
    }
}
