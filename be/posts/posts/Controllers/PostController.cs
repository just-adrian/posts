using Microsoft.AspNetCore.Mvc;
using posts.dal;
using posts.dal.Exceptions;
using System.Net;

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

        [HttpDelete("{postId}")]
        public IActionResult Delete(int postId)
        {
            try
            {
                return Ok(_postRepository.Delete(postId));
            }
            catch (PostNotFoundException)
            {
                return BadRequest();
            }
            catch (System.Exception)
            { 
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
