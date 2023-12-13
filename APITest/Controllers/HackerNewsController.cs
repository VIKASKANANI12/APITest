using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;
using APITest.Model;
using APITest.Repositories;

namespace APITest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HackerNewsController : Controller
    {
        private readonly HackerNewsService _hackerNewsService;

        public HackerNewsController(HackerNewsService hackerNewsService)
        {
            _hackerNewsService = hackerNewsService;
        }

        [HttpGet("beststories")]
        public async Task<ActionResult<IEnumerable<Story>>> GetBestStories(int n)
        {
            var bestStories = await _hackerNewsService.GetBestStoriesAsync(n);
            return Ok(bestStories);
        }

    }
}
