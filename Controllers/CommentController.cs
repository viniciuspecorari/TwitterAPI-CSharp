using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TwitterAPI.Contracts;
using TwitterAPI.Models;

namespace TwitterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;

        public CommentController(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(AddCommentDto commentDto)
        {
            await _commentRepository.AddComment(commentDto);

            return Ok();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<IEnumerable<GetCommentsPostDto>>> GetComments(Guid Id)
        {
            var comments = await _commentRepository.GetComments(Id);
            return Ok(comments);
        }
    }
}
