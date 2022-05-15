using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
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
        public IEnumerable<Post> GetAll()
        {
            return _postRepository.GetAll();
        }
    }
}
