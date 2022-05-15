using Microsoft.AspNetCore.Mvc;
using posts.api;
using posts.dal;

namespace posts.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;

        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] PaginationValues paginationValues)
        {
            return Ok(_postRepository.Get(paginationValues));
        }
    }
}
