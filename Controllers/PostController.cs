using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TwitterAPI.Contracts;
using TwitterAPI.Models.DTO;
using TwitterAPI.Models.PostDto;
using TwitterAPI.Repository;

namespace TwitterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {

        private readonly IPostRepository _postRepository;

        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostGetDto>>> Get()
        {
            var posts = await _postRepository.Get();

            return Ok(posts);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<PostGetDto>> GetById(Guid Id)
        {
            var post = await _postRepository.GetById(Id);

            return Ok(post);
        }


        [HttpPost]
        public async Task<IActionResult> Add([FromBody] PostAddDto postDto)
        {

            var newPost = new PostAddDto(postDto.Description, postDto.MediaUrl, postDto.UserId);

            await _postRepository.Add(newPost);

            return Ok();
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<PostUpdateDto>> Add([FromBody] PostUpdateDto postDto, Guid Id)
        {

            var updatePost = await _postRepository.Update(postDto, Id);           
            return Ok(updatePost);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            await _postRepository.Delete(Id);

            return Ok();
        }
    }
}
