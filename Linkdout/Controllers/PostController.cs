using Linkdout.DTO;
using Linkdout.Moodels;
using Linkdout.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Linkdout.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]

    public class PostController : ControllerBase
    {
        private PostService postService;

        public PostController(PostService _postService) { postService = _postService; }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<PostListDTO>> getAllPosts()
        {
            return Ok(await postService.getAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PostModel>> getSinglePost(int id)
        {
            return Ok(await postService.getPostById(id));
        }


    }
}
